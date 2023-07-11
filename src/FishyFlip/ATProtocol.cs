// <copyright file="ATProtocol.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using FishyFlip.Tools;
using System.Collections.Generic;

namespace FishyFlip;

public sealed class ATProtocol : IDisposable
{
    private ATProtocolOptions options;
    private HttpClient client;
    private ATWebSocketProtocol webSocketProtocol;
    private bool disposedValue;
    private SessionManager sessionManager;

    public ATProtocol(ATProtocolOptions options)
    {
        this.options = options;
        this.client = options.HttpClient ?? throw new NullReferenceException(nameof(options.HttpClient));
        this.webSocketProtocol = new ATWebSocketProtocol(this);
        this.sessionManager = new SessionManager(this);
    }

    public event EventHandler<SubscribedRepoEventArgs>? OnSubscribedRepoMessage;

    public ATProtocolOptions Options => this.options;

    internal HttpClient Client => this.client;

    public async Task<Result<Session>> LoginAsync(string identifier, string password, CancellationToken cancellationToken = default)
    {
        Result<Session> result =
            await this.client.Post<Login, Session>(Constants.Urls.AtProtoServer.Login, this.options.JsonSerializerOptions, new Login(identifier, password), cancellationToken);

        return
            result
                .Match(
                s =>
                {
                    this.OnUserLoggedIn(s);
                    return result;
                },
                error => error!);
    }

    public async Task<Result<Blob?>> GetBlobAsync(AtDid did, Cid cid, CancellationToken cancellationToken = default)
    {
        string url = $"{Constants.Urls.AtProtoSync.GetBlob}?did={did}&cid={cid}";
        return await this.client.GetBlob(url, this.options.JsonSerializerOptions, cancellationToken, this.options.Logger);
    }

    public async Task<Result<Session>> RefreshSessionAsync(
        Session session,
        CancellationToken cancellationToken = default)
    {
        this.client
            .DefaultRequestHeaders
            .Authorization = new AuthenticationHeaderValue("Bearer", session.RefreshJwt);

        var result = await this.client.Post<Session>(Constants.Urls.AtProtoServer.RefreshSession, this.options.JsonSerializerOptions, cancellationToken, this.options.Logger);
        return
            result
                .Match(
                s =>
                {
                    this.sessionManager?.SetSession(s);
                    return result;
                },
                error => error!);
    }

    public async Task<Result<PostRecord?>> GetPostAsync(ATIdentifier repo, string rkey, Cid? cid = null, CancellationToken cancellationToken = default)
        => await this.GetRecordAsync<PostRecord>(Constants.FeedType.Post, repo, rkey, cid, cancellationToken);

    public async Task<Result<T?>> GetRecordAsync<T>(string collection, ATIdentifier repo, string rkey, Cid? cid = null, CancellationToken cancellationToken = default)
        where T : ATFeedTypeAPI
    {
        string url = $"{Constants.Urls.AtProtoRepo.GetRecord}?collection={collection}&repo={repo}&rkey={rkey}";
        if (cid is not null)
        {
            url += $"&cid={cid}";
        }

        return await this.client.Get<T>(url, this.options.JsonSerializerOptions, cancellationToken, this.options.Logger);
    }

    /// <summary>
    /// Start the ATProtocol SubscribeRepos sync session.
    /// </summary>
    /// <param name="token">Cancellation Token.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task StartSubscribeReposAsync(CancellationToken? token = default)
        => this.webSocketProtocol.ConnectAsync(token);

    /// <summary>
    /// Stops the ATProtocol SubscribeRepos sync session.
    /// </summary>
    /// <param name="token">Cancellation Token.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task StopSubscribeReposAsync(CancellationToken? token = default)
    {
        this.webSocketProtocol.CloseAsync(token: token).FireAndForgetSafeAsync();
        return Task.CompletedTask;
    }

    internal void OnSubscribedRepoMessageInternal(SubscribedRepoEventArgs e)
        => this.OnSubscribedRepoMessage?.Invoke(this, e);

    private void OnUserLoggedIn(Session session)
    {
        if (this.sessionManager is null)
        {
            this.sessionManager = new SessionManager(this, session);
        }
        else
        {
            this.sessionManager.SetSession(session);
        }
    }

    void IDisposable.Dispose()
    {
        this.Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (!this.disposedValue)
        {
            if (disposing)
            {
                this.client.Dispose();
            }

            this.disposedValue = true;
        }
    }
}