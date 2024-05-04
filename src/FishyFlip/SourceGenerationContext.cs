// <copyright file="SourceGenerationContext.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace FishyFlip;

/// <summary>
/// ATProtocol Message Source Generation Context.
/// </summary>
[JsonSourceGenerationOptions(
    WriteIndented = true,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
[JsonSerializable(typeof(Embed))]
[JsonSerializable(typeof(CreateBlockRecord))]
[JsonSerializable(typeof(CreateFollowRecord))]
[JsonSerializable(typeof(CreateLikeRecord))]
[JsonSerializable(typeof(CreateListRecord))]
[JsonSerializable(typeof(CreateListItemRecord))]
[JsonSerializable(typeof(CreateInviteCode))]
[JsonSerializable(typeof(CreateInviteCodes))]
[JsonSerializable(typeof(CreateRepostRecord))]
[JsonSerializable(typeof(CreatePostRecord))]
[JsonSerializable(typeof(CreatePostResponse))]
[JsonSerializable(typeof(CreateMuteRecord))]
[JsonSerializable(typeof(CreateMuteListRecord))]
[JsonSerializable(typeof(CreateModerationReportPost))]
[JsonSerializable(typeof(CreateModerationReportRepo))]
[JsonSerializable(typeof(CreateSeenAtRecord))]
[JsonSerializable(typeof(CreateThreadGateRecord))]
[JsonSerializable(typeof(DeleteRecord))]
[JsonSerializable(typeof(Login))]
[JsonSerializable(typeof(FeedResultList))]
[JsonSerializable(typeof(PutPostRecord))]
[JsonSerializable(typeof(UpdateHandle))]
[JsonSerializable(typeof(AccountInviteCode))]
[JsonSerializable(typeof(AccountInviteCodes))]
[JsonSerializable(typeof(ActorBlocks))]
[JsonSerializable(typeof(ActorFollows))]
[JsonSerializable(typeof(ActorFollowers))]
[JsonSerializable(typeof(ActorMutes))]
[JsonSerializable(typeof(ActorProfile))]
[JsonSerializable(typeof(ActorRecord))]
[JsonSerializable(typeof(ActorResponse))]
[JsonSerializable(typeof(AdminRepoRef))]
[JsonSerializable(typeof(AppPassword))]
[JsonSerializable(typeof(AppPasswords))]
[JsonSerializable(typeof(ATDid))]
[JsonSerializable(typeof(ATFeedTypeAPI))]
[JsonSerializable(typeof(ATHandle))]
[JsonSerializable(typeof(ATIdentifier))]
[JsonSerializable(typeof(ATUri))]
[JsonSerializable(typeof(Blob))]
[JsonSerializable(typeof(BlobRecord))]
[JsonSerializable(typeof(Block))]
[JsonSerializable(typeof(BlockRecord))]
[JsonSerializable(typeof(BSList))]
[JsonSerializable(typeof(BSListItem))]
[JsonSerializable(typeof(CommitPath))]
[JsonSerializable(typeof(DescribeRepo))]
[JsonSerializable(typeof(DescribeServer))]
[JsonSerializable(typeof(Embed))]
[JsonSerializable(typeof(Models.WhiteWind.Entry))]
[JsonSerializable(typeof(Models.Internal.WhiteWind.CreateEntryRecord))]
[JsonSerializable(typeof(Models.WhiteWind.BlobMetadata))]
[JsonSerializable(typeof(ATError))]
[JsonSerializable(typeof(ErrorBody))]
[JsonSerializable(typeof(ErrorDetail))]
[JsonSerializable(typeof(External))]
[JsonSerializable(typeof(ExternalEmbed))]
[JsonSerializable(typeof(ExternalViewEmbed))]
[JsonSerializable(typeof(Facet))]
[JsonSerializable(typeof(FacetFeature))]
[JsonSerializable(typeof(FacetIndex))]
[JsonSerializable(typeof(FeedCollection))]
[JsonSerializable(typeof(FeedGenerator))]
[JsonSerializable(typeof(FeedGeneratorRecord))]
[JsonSerializable(typeof(FeedPostList))]
[JsonSerializable(typeof(FeedProfile))]
[JsonSerializable(typeof(FeedProfiles))]
[JsonSerializable(typeof(FeedRecord))]
[JsonSerializable(typeof(FeedViewPost))]
[JsonSerializable(typeof(FeedViewPostReply))]
[JsonSerializable(typeof(Follow))]
[JsonSerializable(typeof(FollowRecord))]
[JsonSerializable(typeof(FrameCommit))]
[JsonSerializable(typeof(FrameError))]
[JsonSerializable(typeof(FrameFooter))]
[JsonSerializable(typeof(FrameHeader))]
[JsonSerializable(typeof(FrameHeaderOperation))]
[JsonSerializable(typeof(FrameHandle))]
[JsonSerializable(typeof(FrameInfo))]
[JsonSerializable(typeof(FrameMigrate))]
[JsonSerializable(typeof(FrameNode))]
[JsonSerializable(typeof(FrameRepoOp))]
[JsonSerializable(typeof(FrameTombstone))]
[JsonSerializable(typeof(GeneratorFeed))]
[JsonSerializable(typeof(GeneratorView))]
[JsonSerializable(typeof(HandleResolution))]
[JsonSerializable(typeof(Head))]
[JsonSerializable(typeof(Image))]
[JsonSerializable(typeof(ImageEmbed))]
[JsonSerializable(typeof(ImageRef))]
[JsonSerializable(typeof(ImagesEmbed))]
[JsonSerializable(typeof(ImageViewEmbed))]
[JsonSerializable(typeof(InviteCode))]
[JsonSerializable(typeof(InviteCodes))]
[JsonSerializable(typeof(Label))]
[JsonSerializable(typeof(LatestCommit))]
[JsonSerializable(typeof(Like))]
[JsonSerializable(typeof(LikeRecord))]
[JsonSerializable(typeof(LikesFeed))]
[JsonSerializable(typeof(ListRecord))]
[JsonSerializable(typeof(ListItemRecord))]
[JsonSerializable(typeof(ListItemView))]
[JsonSerializable(typeof(ListItemViewRecord))]
[JsonSerializable(typeof(ListBlobs))]
[JsonSerializable(typeof(ListFeed))]
[JsonSerializable(typeof(ListRecords))]
[JsonSerializable(typeof(ListView))]
[JsonSerializable(typeof(ListViewRecord))]
[JsonSerializable(typeof(ModerationReasonType))]
[JsonSerializable(typeof(ModerationSubject))]
[JsonSerializable(typeof(ModerationRecord))]
[JsonSerializable(typeof(Notification))]
[JsonSerializable(typeof(NotificationCollection))]
[JsonSerializable(typeof(Ops))]
[JsonSerializable(typeof(Post))]
[JsonSerializable(typeof(PostCollection))]
[JsonSerializable(typeof(PostRecord))]
[JsonSerializable(typeof(PostView))]
[JsonSerializable(typeof(PostViewEmbed))]
[JsonSerializable(typeof(Profile))]
[JsonSerializable(typeof(ReasonRepost))]
[JsonSerializable(typeof(RecordEmbed))]
[JsonSerializable(typeof(RecordRef))]
[JsonSerializable(typeof(RecordViewEmbed))]
[JsonSerializable(typeof(RecordWithMediaEmbed))]
[JsonSerializable(typeof(RecordWithMediaViewEmbed))]
[JsonSerializable(typeof(Reply))]
[JsonSerializable(typeof(ReplyRef))]
[JsonSerializable(typeof(RepoList))]
[JsonSerializable(typeof(RepoList))]
[JsonSerializable(typeof(RepoRef))]
[JsonSerializable(typeof(Repost))]
[JsonSerializable(typeof(RepostedFeed))]
[JsonSerializable(typeof(RepostRecord))]
[JsonSerializable(typeof(RepoStrongRef))]
[JsonSerializable(typeof(SearchOption))]
[JsonSerializable(typeof(SearchResults))]
[JsonSerializable(typeof(ServerLinkProperties))]
[JsonSerializable(typeof(SkeletonFeedPost))]
[JsonSerializable(typeof(SkeletonReasonRepost))]
[JsonSerializable(typeof(Session))]
[JsonSerializable(typeof(SessionInfo))]
[JsonSerializable(typeof(Subject))]
[JsonSerializable(typeof(SubscribeRepoMessage))]
[JsonSerializable(typeof(SuggestionsRecord))]
[JsonSerializable(typeof(Success))]
[JsonSerializable(typeof(ThreadPostViewFeed))]
[JsonSerializable(typeof(ThreadView))]
[JsonSerializable(typeof(ThreadGate))]
[JsonSerializable(typeof(ThreadGateReason))]
[JsonSerializable(typeof(ThreadGateRecord))]
[JsonSerializable(typeof(Timeline))]
[JsonSerializable(typeof(UnknownEmbed))]
[JsonSerializable(typeof(UnreadCount))]
[JsonSerializable(typeof(UploadBlobResponse))]
[JsonSerializable(typeof(ATLinkRef))]
[JsonSerializable(typeof(Used))]
[JsonSerializable(typeof(Viewer))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}