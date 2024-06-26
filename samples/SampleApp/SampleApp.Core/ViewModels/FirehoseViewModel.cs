﻿// <copyright file="FirehoseViewModel.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System.Collections.ObjectModel;
using Drastic.Tools;
using Drastic.ViewModels;
using FishyFlip;
using FishyFlip.Events;
using FishyFlip.Models;

namespace SampleApp.ViewModels;

public class FirehoseViewModel : BaseViewModel
{
    private ATWebSocketProtocol webSocketProtocol;
    private AsyncCommand connectCommand;
    private AsyncCommand stopCommand;
    private AsyncCommand cleanCommand;

    public FirehoseViewModel(IServiceProvider services)
        : base(services)
    {
        var webProtocolBuilder = new ATWebSocketProtocolBuilder();
        this.webSocketProtocol = webProtocolBuilder.Build();
        this.webSocketProtocol.OnSubscribedRepoMessage += WebSocketProtocol_OnSubscribedRepoMessage;
        this.connectCommand = new AsyncCommand(this.ConnectAsync, () => !this.webSocketProtocol.IsConnected, this.Dispatcher, this.ErrorHandler);
        this.stopCommand = new AsyncCommand(this.StopAsync, () => this.webSocketProtocol.IsConnected, this.Dispatcher, this.ErrorHandler);
        this.cleanCommand = new AsyncCommand(this.CleanAsync, null, this.Dispatcher, this.ErrorHandler);
    }

    public AsyncCommand ConnectCommand => this.connectCommand;

    public AsyncCommand StopCommand => this.stopCommand;

    public AsyncCommand CleanCommand => this.cleanCommand;

    public ObservableCollection<ATRecord> Records { get; } = new ObservableCollection<ATRecord>();

    /// <inheritdoc/>
    public override void RaiseCanExecuteChanged()
    {
        base.RaiseCanExecuteChanged();
        this.connectCommand.RaiseCanExecuteChanged();
        this.stopCommand.RaiseCanExecuteChanged();
    }

    private async Task ConnectAsync()
    {
        await this.webSocketProtocol.StartSubscribeReposAsync();
        this.RaiseCanExecuteChanged();
    }

    private async Task StopAsync()
    {
        await this.webSocketProtocol.StopSubscriptionAsync();
        this.RaiseCanExecuteChanged();
    }

    private Task CleanAsync()
    {
        lock (this)
        {
            this.Records.Clear();
        }

        this.RaiseCanExecuteChanged();
        return Task.CompletedTask;
    }

    private void WebSocketProtocol_OnSubscribedRepoMessage(object? sender, SubscribedRepoEventArgs e)
    {
        Task.Run(() => this.HandleMessageAsync(e.Message)).FireAndForgetSafeAsync(this.ErrorHandler);
    }

    Task HandleMessageAsync(SubscribeRepoMessage message)
    {
        if (message.Commit is FrameCommit commit && message.Record is ATRecord record)
        {
            return this.HandleRecordAsync(commit, record);
        }

        return Task.CompletedTask;
    }

    private async Task HandleRecordAsync(FrameCommit commit, ATRecord wsRecord)
    {
        ATRecord? record = null;
        switch (wsRecord.Type)
        {
            case FishyFlip.Constants.FeedType.Post:
                record = (Post)wsRecord;
                break;
            case FishyFlip.Constants.FeedType.Like:
                record = (Like)wsRecord;
                break;
            case FishyFlip.Constants.FeedType.Generator:
            case FishyFlip.Constants.FeedType.Repost:
            case FishyFlip.Constants.GraphTypes.Follow:
            case FishyFlip.Constants.GraphTypes.List:
            case FishyFlip.Constants.GraphTypes.ListItem:
            case FishyFlip.Constants.GraphTypes.Block:
            case FishyFlip.Constants.ActorTypes.Profile:
            case FishyFlip.Constants.FeedType.ThreadGate:
            default:
                record = wsRecord;
                break;
        }

        lock (this)
        {
            this.Records.Add(record);
        }
    }
}
