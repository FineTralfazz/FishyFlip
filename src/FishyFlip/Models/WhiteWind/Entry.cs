// <copyright file="Entry.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace FishyFlip.Models.WhiteWind;

/// <summary>
/// Represents an Entry in the WhiteWind Blog.
/// </summary>
public class Entry : ATRecord
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Entry"/> class.
    /// </summary>
    /// <param name="content">The content of the blog post.</param>
    /// <param name="title">The title of the blog post.</param>
    /// <param name="theme">The theme of the blog post.</param>
    /// <param name="createdAt">The date and time when the entry action was created.</param>
    /// <param name="blobs">The blobs for a given post.</param>
    /// <param name="type">The type of the follow action.</param>
    [JsonConstructor]
    public Entry(string? content, string? title, string? theme, DateTime? createdAt, FishyFlip.Models.WhiteWind.BlobMetadata[]? blobs,  string? type)
        : base(type)
    {
        this.Content = content;
        this.Title = title;
        this.Theme = theme;
        this.CreatedAt = createdAt;
        this.Blobs = blobs;
    }

    /// <summary>
    /// Gets the title of the blog post.
    /// </summary>
    public string? Title { get; }

    /// <summary>
    /// Gets the content of the blog post.
    /// </summary>
    public string? Content { get; }

    /// <summary>
    /// Gets the theme of the blog post.
    /// </summary>
    public string? Theme { get; }

    /// <summary>
    /// Gets the blobs for a given post.
    /// </summary>
    public FishyFlip.Models.WhiteWind.BlobMetadata[]? Blobs { get; }

    /// <summary>
    /// Gets the date and time when the entry action was created.
    /// </summary>
    public DateTime? CreatedAt { get; }
}