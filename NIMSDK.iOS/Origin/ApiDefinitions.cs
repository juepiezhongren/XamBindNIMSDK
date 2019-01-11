using System;
using CoreGraphics;
using Foundation;
using NIMSDK;
using ObjCRuntime;
using UIKit;

namespace NIMSDK.iOS
{
	// @interface NIMAntiSpamOption : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMAntiSpamOption
	{
		// @property (assign, nonatomic) BOOL yidunEnabled;
		[Export ("yidunEnabled")]
		bool YidunEnabled { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable content;
		[NullAllowed, Export ("content")]
		string Content { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable businessId;
		[NullAllowed, Export ("businessId")]
		string BusinessId { get; set; }

		// @property (assign, nonatomic) BOOL hitClientAntispam;
		[Export ("hitClientAntispam")]
		bool HitClientAntispam { get; set; }
	}

	// @interface NIMLocalAntiSpamCheckOption : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMLocalAntiSpamCheckOption
	{
		// @property (copy, nonatomic) NSString * _Nonnull content;
		[Export ("content")]
		string Content { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable replacement;
		[NullAllowed, Export ("replacement")]
		string Replacement { get; set; }
	}

	// @interface NIMLocalAntiSpamCheckResult : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMLocalAntiSpamCheckResult
	{
		// @property (readonly, assign, nonatomic) NIMLocalAntiSpamOperate type;
		[Export ("type", ArgumentSemantic.Assign)]
		NIMLocalAntiSpamOperate Type { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull content;
		[Export ("content")]
		string Content { get; }
	}

	// @protocol NIMAntispamManager <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMAntispamManager
	{
		// @required -(NIMLocalAntiSpamCheckResult * _Nonnull)checkLocalAntispam:(NIMLocalAntiSpamCheckOption * _Nonnull)option error:(NSError * _Nullable * _Nullable)error;
		[Abstract]
		[Export ("checkLocalAntispam:error:")]
		NIMLocalAntiSpamCheckResult Error (NIMLocalAntiSpamCheckOption option, [NullAllowed] out NSError error);
	}

	// typedef void (^NIMApnsHandler)(NSError * _Nullable);
	delegate void NIMApnsHandler ([NullAllowed] NSError arg0);

	// typedef NSUInteger (^NIMBadgeHandler)();
	delegate nuint NIMBadgeHandler ();

	// @protocol NIMApnsManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMApnsManagerDelegate
	{
		// @required -(void)onOtherClientChangedPushNotificationMultiportConfig;
		[Abstract]
		[Export ("onOtherClientChangedPushNotificationMultiportConfig")]
		void OnOtherClientChangedPushNotificationMultiportConfig ();
	}

	// @protocol NIMApnsManager <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMApnsManager
	{
		// @required -(NIMPushNotificationSetting * _Nullable)currentSetting;
		[Abstract]
		[NullAllowed, Export ("currentSetting")]
		[Verify (MethodToProperty)]
		NIMPushNotificationSetting CurrentSetting { get; }

		// @required -(void)updateApnsSetting:(NIMPushNotificationSetting * _Nonnull)setting completion:(NIMApnsHandler _Nullable)completion;
		[Abstract]
		[Export ("updateApnsSetting:completion:")]
		void UpdateApnsSetting (NIMPushNotificationSetting setting, [NullAllowed] NIMApnsHandler completion);

		// @required -(NIMPushNotificationMultiportConfig * _Nullable)currentMultiportConfig;
		[Abstract]
		[NullAllowed, Export ("currentMultiportConfig")]
		[Verify (MethodToProperty)]
		NIMPushNotificationMultiportConfig CurrentMultiportConfig { get; }

		// @required -(void)updateApnsMultiportConfig:(NIMPushNotificationMultiportConfig * _Nonnull)config completion:(NIMApnsHandler _Nullable)completion;
		[Abstract]
		[Export ("updateApnsMultiportConfig:completion:")]
		void UpdateApnsMultiportConfig (NIMPushNotificationMultiportConfig config, [NullAllowed] NIMApnsHandler completion);

		// @required -(void)registerBadgeCountHandler:(NIMBadgeHandler _Nonnull)handler;
		[Abstract]
		[Export ("registerBadgeCountHandler:")]
		void RegisterBadgeCountHandler (NIMBadgeHandler handler);

		// @required -(void)addDelegate:(id<NIMApnsManagerDelegate> _Nonnull)delegate;
		[Abstract]
		[Export ("addDelegate:")]
		void AddDelegate (NIMApnsManagerDelegate @delegate);

		// @required -(void)removeDelegate:(id<NIMApnsManagerDelegate> _Nonnull)delegate;
		[Abstract]
		[Export ("removeDelegate:")]
		void RemoveDelegate (NIMApnsManagerDelegate @delegate);
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const NIMLocalErrorDomain;
		[Field ("NIMLocalErrorDomain", "__Internal")]
		NSString NIMLocalErrorDomain { get; }

		// extern NSString *const NIMRemoteErrorDomain;
		[Field ("NIMRemoteErrorDomain", "__Internal")]
		NSString NIMRemoteErrorDomain { get; }
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const NIMNOSSceneTypeAvatar;
		[Field ("NIMNOSSceneTypeAvatar", "__Internal")]
		NSString NIMNOSSceneTypeAvatar { get; }

		// extern NSString *const NIMNOSSceneTypeMessage;
		[Field ("NIMNOSSceneTypeMessage", "__Internal")]
		NSString NIMNOSSceneTypeMessage { get; }
	}

	// @protocol NIMMessageObject <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMMessageObject
	{
		// @required @property (nonatomic, weak) NIMMessage * _Nullable message;
		[Abstract]
		[NullAllowed, Export ("message", ArgumentSemantic.Weak)]
		NIMMessage Message { get; set; }

		// @required -(NIMMessageType)type;
		[Abstract]
		[Export ("type")]
		[Verify (MethodToProperty)]
		NIMMessageType Type { get; }
	}

	// @interface NIMAudioObject : NSObject <NIMMessageObject>
	[BaseType (typeof(NSObject))]
	interface NIMAudioObject : INIMMessageObject
	{
		// -(instancetype _Nonnull)initWithSourcePath:(NSString * _Nonnull)sourcePath;
		[Export ("initWithSourcePath:")]
		IntPtr Constructor (string sourcePath);

		// -(instancetype _Nonnull)initWithData:(NSData * _Nonnull)data extension:(NSString * _Nonnull)extension;
		[Export ("initWithData:extension:")]
		IntPtr Constructor (NSData data, string extension);

		// -(instancetype _Nonnull)initWithSourcePath:(NSString * _Nonnull)sourcePath scene:(NSString * _Nonnull)scene;
		[Export ("initWithSourcePath:scene:")]
		IntPtr Constructor (string sourcePath, string scene);

		// -(instancetype _Nonnull)initWithData:(NSData * _Nonnull)data extension:(NSString * _Nonnull)extension scene:(NSString * _Nonnull)scene;
		[Export ("initWithData:extension:scene:")]
		IntPtr Constructor (NSData data, string extension, string scene);

		// @property (readonly, copy, nonatomic) NSString * _Nullable path;
		[NullAllowed, Export ("path")]
		string Path { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable url;
		[NullAllowed, Export ("url")]
		string Url { get; }

		// @property (assign, nonatomic) NSInteger duration;
		[Export ("duration")]
		nint Duration { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable md5;
		[NullAllowed, Export ("md5")]
		string Md5 { get; }
	}

	// @protocol NIMBroadcastManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMBroadcastManagerDelegate
	{
		// @required -(void)onReceiveBroadcastMessage:(NIMBroadcastMessage * _Nonnull)broadcastMessage;
		[Abstract]
		[Export ("onReceiveBroadcastMessage:")]
		void OnReceiveBroadcastMessage (NIMBroadcastMessage broadcastMessage);
	}

	// @protocol NIMBroadcastManager <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMBroadcastManager
	{
		// @required -(void)addDelegate:(id<NIMBroadcastManagerDelegate> _Nonnull)delegate;
		[Abstract]
		[Export ("addDelegate:")]
		void AddDelegate (NIMBroadcastManagerDelegate @delegate);

		// @required -(void)removeDelegate:(id<NIMBroadcastManagerDelegate> _Nonnull)delegate;
		[Abstract]
		[Export ("removeDelegate:")]
		void RemoveDelegate (NIMBroadcastManagerDelegate @delegate);
	}

	// @interface NIMBroadcastMessage : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMBroadcastMessage
	{
		// @property (readonly, assign, nonatomic) int64_t broadcastId;
		[Export ("broadcastId")]
		long BroadcastId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable sender;
		[NullAllowed, Export ("sender")]
		string Sender { get; }

		// @property (readonly, assign, nonatomic) NSTimeInterval timestamp;
		[Export ("timestamp")]
		double Timestamp { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable content;
		[NullAllowed, Export ("content")]
		string Content { get; }
	}

	// @interface NIMResourceQueryOption : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMResourceQueryOption
	{
		// @property (copy, nonatomic) NSArray<NSString *> * _Nullable extensions;
		[NullAllowed, Export ("extensions", ArgumentSemantic.Copy)]
		string[] Extensions { get; set; }

		// @property (assign, nonatomic) NSTimeInterval timeInterval;
		[Export ("timeInterval")]
		double TimeInterval { get; set; }
	}

	// @interface NIMCacheQueryResult : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMCacheQueryResult
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull path;
		[Export ("path")]
		string Path { get; }

		// @property (readonly, nonatomic, strong) NSDate * _Nonnull creationDate;
		[Export ("creationDate", ArgumentSemantic.Strong)]
		NSDate CreationDate { get; }

		// @property (readonly, assign, nonatomic) long long fileLength;
		[Export ("fileLength")]
		long FileLength { get; }
	}

	// typedef void (^NIMSendMessageReceiptBlock)(NSError * _Nullable);
	delegate void NIMSendMessageReceiptBlock ([NullAllowed] NSError arg0);

	// typedef void (^NIMSendTeamMessageReceiptsBlock)(NSError * _Nullable, NSArray<NIMMessageReceipt *> * _Nullable);
	delegate void NIMSendTeamMessageReceiptsBlock ([NullAllowed] NSError arg0, [NullAllowed] NIMMessageReceipt[] arg1);

	// typedef void (^NIMRevokeMessageBlock)(NSError * _Nullable);
	delegate void NIMRevokeMessageBlock ([NullAllowed] NSError arg0);

	// typedef void (^NIMQueryReceiptDetailBlock)(NSError * _Nullable, NIMTeamMessageReceiptDetail * _Nullable);
	delegate void NIMQueryReceiptDetailBlock ([NullAllowed] NSError arg0, [NullAllowed] NIMTeamMessageReceiptDetail arg1);

	// @protocol NIMChatManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMChatManagerDelegate
	{
		// @optional -(void)willSendMessage:(NIMMessage * _Nonnull)message;
		[Export ("willSendMessage:")]
		void WillSendMessage (NIMMessage message);

		// @optional -(void)uploadAttachmentSuccess:(NSString * _Nonnull)urlString forMessage:(NIMMessage * _Nonnull)message;
		[Export ("uploadAttachmentSuccess:forMessage:")]
		void UploadAttachmentSuccess (string urlString, NIMMessage message);

		// @optional -(void)sendMessage:(NIMMessage * _Nonnull)message progress:(float)progress;
		[Export ("sendMessage:progress:")]
		void SendMessage (NIMMessage message, float progress);

		// @optional -(void)sendMessage:(NIMMessage * _Nonnull)message didCompleteWithError:(NSError * _Nullable)error;
		[Export ("sendMessage:didCompleteWithError:")]
		void SendMessage (NIMMessage message, [NullAllowed] NSError error);

		// @optional -(void)onRecvMessages:(NSArray<NIMMessage *> * _Nonnull)messages;
		[Export ("onRecvMessages:")]
		void OnRecvMessages (NIMMessage[] messages);

		// @optional -(void)onRecvMessageReceipts:(NSArray<NIMMessageReceipt *> * _Nonnull)receipts;
		[Export ("onRecvMessageReceipts:")]
		void OnRecvMessageReceipts (NIMMessageReceipt[] receipts);

		// @optional -(void)onRecvRevokeMessageNotification:(NIMRevokeMessageNotification * _Nonnull)notification;
		[Export ("onRecvRevokeMessageNotification:")]
		void OnRecvRevokeMessageNotification (NIMRevokeMessageNotification notification);

		// @optional -(void)fetchMessageAttachment:(NIMMessage * _Nonnull)message progress:(float)progress;
		[Export ("fetchMessageAttachment:progress:")]
		void FetchMessageAttachment (NIMMessage message, float progress);

		// @optional -(void)fetchMessageAttachment:(NIMMessage * _Nonnull)message didCompleteWithError:(NSError * _Nullable)error;
		[Export ("fetchMessageAttachment:didCompleteWithError:")]
		void FetchMessageAttachment (NIMMessage message, [NullAllowed] NSError error);
	}

	// @protocol NIMChatManager <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMChatManager
	{
		// @required -(BOOL)sendMessage:(NIMMessage * _Nonnull)message toSession:(NIMSession * _Nonnull)session error:(NSError * _Nullable * _Nullable)error;
		[Abstract]
		[Export ("sendMessage:toSession:error:")]
		bool SendMessage (NIMMessage message, NIMSession session, [NullAllowed] out NSError error);

		// @required -(BOOL)resendMessage:(NIMMessage * _Nonnull)message error:(NSError * _Nullable * _Nullable)error;
		[Abstract]
		[Export ("resendMessage:error:")]
		bool ResendMessage (NIMMessage message, [NullAllowed] out NSError error);

		// @required -(BOOL)forwardMessage:(NIMMessage * _Nonnull)message toSession:(NIMSession * _Nonnull)session error:(NSError * _Nullable * _Nullable)error;
		[Abstract]
		[Export ("forwardMessage:toSession:error:")]
		bool ForwardMessage (NIMMessage message, NIMSession session, [NullAllowed] out NSError error);

		// @required -(void)sendMessageReceipt:(NIMMessageReceipt * _Nonnull)receipt completion:(NIMSendMessageReceiptBlock _Nullable)completion;
		[Abstract]
		[Export ("sendMessageReceipt:completion:")]
		void SendMessageReceipt (NIMMessageReceipt receipt, [NullAllowed] NIMSendMessageReceiptBlock completion);

		// @required -(void)sendTeamMessageReceipts:(NSArray<NIMMessageReceipt *> * _Nonnull)receipts completion:(NIMSendTeamMessageReceiptsBlock _Nullable)completion;
		[Abstract]
		[Export ("sendTeamMessageReceipts:completion:")]
		void SendTeamMessageReceipts (NIMMessageReceipt[] receipts, [NullAllowed] NIMSendTeamMessageReceiptsBlock completion);

		// @required -(void)refreshTeamMessageReceipts:(NSArray<NIMMessage *> * _Nonnull)messages;
		[Abstract]
		[Export ("refreshTeamMessageReceipts:")]
		void RefreshTeamMessageReceipts (NIMMessage[] messages);

		// @required -(void)queryMessageReceiptDetail:(NIMMessage * _Nonnull)message completion:(NIMQueryReceiptDetailBlock _Nonnull)completion;
		[Abstract]
		[Export ("queryMessageReceiptDetail:completion:")]
		void QueryMessageReceiptDetail (NIMMessage message, NIMQueryReceiptDetailBlock completion);

		// @required -(void)revokeMessage:(NIMMessage * _Nonnull)message completion:(NIMRevokeMessageBlock _Nullable)completion;
		[Abstract]
		[Export ("revokeMessage:completion:")]
		void RevokeMessage (NIMMessage message, [NullAllowed] NIMRevokeMessageBlock completion);

		// @required -(BOOL)fetchMessageAttachment:(NIMMessage * _Nonnull)message error:(NSError * _Nullable * _Nullable)error;
		[Abstract]
		[Export ("fetchMessageAttachment:error:")]
		bool FetchMessageAttachment (NIMMessage message, [NullAllowed] out NSError error);

		// @required -(void)cancelFetchingMessageAttachment:(NIMMessage * _Nonnull)message;
		[Abstract]
		[Export ("cancelFetchingMessageAttachment:")]
		void CancelFetchingMessageAttachment (NIMMessage message);

		// @required -(BOOL)messageInTransport:(NIMMessage * _Nonnull)message;
		[Abstract]
		[Export ("messageInTransport:")]
		bool MessageInTransport (NIMMessage message);

		// @required -(float)messageTransportProgress:(NIMMessage * _Nonnull)message;
		[Abstract]
		[Export ("messageTransportProgress:")]
		float MessageTransportProgress (NIMMessage message);

		// @required -(void)addDelegate:(id<NIMChatManagerDelegate> _Nonnull)delegate;
		[Abstract]
		[Export ("addDelegate:")]
		void AddDelegate (NIMChatManagerDelegate @delegate);

		// @required -(void)removeDelegate:(id<NIMChatManagerDelegate> _Nonnull)delegate;
		[Abstract]
		[Export ("removeDelegate:")]
		void RemoveDelegate (NIMChatManagerDelegate @delegate);
	}

	// @interface NIMChatroom : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMChatroom
	{
		// @property (copy, nonatomic) NSString * _Nullable roomId;
		[NullAllowed, Export ("roomId")]
		string RoomId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable announcement;
		[NullAllowed, Export ("announcement")]
		string Announcement { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable creator;
		[NullAllowed, Export ("creator")]
		string Creator { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable ext;
		[NullAllowed, Export ("ext")]
		string Ext { get; set; }

		// @property (assign, nonatomic) NSInteger onlineUserCount;
		[Export ("onlineUserCount")]
		nint OnlineUserCount { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable broadcastUrl;
		[NullAllowed, Export ("broadcastUrl")]
		string BroadcastUrl { get; set; }

		// @property (assign, nonatomic) NIMChatroomQueueModificationLevel queueModificationLevel;
		[Export ("queueModificationLevel", ArgumentSemantic.Assign)]
		NIMChatroomQueueModificationLevel QueueModificationLevel { get; set; }

		// -(BOOL)inAllMuteMode;
		[Export ("inAllMuteMode")]
		[Verify (MethodToProperty)]
		bool InAllMuteMode { get; }
	}

	// typedef void (^NIMChatroomHandler)(NSError * _Nullable);
	delegate void NIMChatroomHandler ([NullAllowed] NSError arg0);

	// typedef void (^NIMChatroomMemberHandler)(NSError * _Nullable, NIMChatroomMember * _Nullable);
	delegate void NIMChatroomMemberHandler ([NullAllowed] NSError arg0, [NullAllowed] NIMChatroomMember arg1);

	// typedef void (^NIMChatroomEnterHandler)(NSError * _Nullable, NIMChatroom * _Nullable, NIMChatroomMember * _Nullable);
	delegate void NIMChatroomEnterHandler ([NullAllowed] NSError arg0, [NullAllowed] NIMChatroom arg1, [NullAllowed] NIMChatroomMember arg2);

	// typedef void (^NIMChatroomInfoHandler)(NSError * _Nullable, NIMChatroom * _Nullable);
	delegate void NIMChatroomInfoHandler ([NullAllowed] NSError arg0, [NullAllowed] NIMChatroom arg1);

	// typedef void (^NIMChatroomMembersHandler)(NSError * _Nullable, NSArray<NIMChatroomMember *> * _Nullable);
	delegate void NIMChatroomMembersHandler ([NullAllowed] NSError arg0, [NullAllowed] NIMChatroomMember[] arg1);

	// typedef void (^NIMChatroomQueueInfoHandler)(NSError * _Nullable, NSArray<NSDictionary<NSString *,NSString *> *> * _Nullable);
	delegate void NIMChatroomQueueInfoHandler ([NullAllowed] NSError arg0, [NullAllowed] NSDictionary<NSString, NSString>[] arg1);

	// typedef void (^NIMChatroomQueueRemoveHandler)(NSError * _Nullable, NSDictionary<NSString *,NSString *> * _Nullable);
	delegate void NIMChatroomQueueRemoveHandler ([NullAllowed] NSError arg0, [NullAllowed] NSDictionary<NSString, NSString> arg1);

	// typedef void (^NIMChatroomQueueBatchUpdateHandler)(NSError * _Nullable, NSArray<NSString *> * _Nullable);
	delegate void NIMChatroomQueueBatchUpdateHandler ([NullAllowed] NSError arg0, [NullAllowed] string[] arg1);

	// typedef void (^NIMFetchChatroomHistoryBlock)(NSError * _Nullable, NSArray<NIMMessage *> * _Nullable);
	delegate void NIMFetchChatroomHistoryBlock ([NullAllowed] NSError arg0, [NullAllowed] NIMMessage[] arg1);

	// @protocol NIMChatroomManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMChatroomManagerDelegate
	{
		// @optional -(void)chatroomBeKicked:(NIMChatroomBeKickedResult * _Nonnull)result;
		[Export ("chatroomBeKicked:")]
		void ChatroomBeKicked (NIMChatroomBeKickedResult result);

		// @optional -(void)chatroom:(NSString * _Nonnull)roomId connectionStateChanged:(NIMChatroomConnectionState)state;
		[Export ("chatroom:connectionStateChanged:")]
		void Chatroom (string roomId, NIMChatroomConnectionState state);

		// @optional -(void)chatroom:(NSString * _Nonnull)roomId autoLoginFailed:(NSError * _Nonnull)error;
		[Export ("chatroom:autoLoginFailed:")]
		void Chatroom (string roomId, NSError error);
	}

	// @protocol NIMChatroomManager <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMChatroomManager
	{
		// @required -(void)enterChatroom:(NIMChatroomEnterRequest * _Nonnull)request completion:(NIMChatroomEnterHandler _Nullable)completion;
		[Abstract]
		[Export ("enterChatroom:completion:")]
		void EnterChatroom (NIMChatroomEnterRequest request, [NullAllowed] NIMChatroomEnterHandler completion);

		// @required -(void)exitChatroom:(NSString * _Nonnull)roomId completion:(NIMChatroomHandler _Nullable)completion;
		[Abstract]
		[Export ("exitChatroom:completion:")]
		void ExitChatroom (string roomId, [NullAllowed] NIMChatroomHandler completion);

		// @required -(void)fetchMessageHistory:(NSString * _Nonnull)roomId option:(NIMHistoryMessageSearchOption * _Nonnull)option result:(NIMFetchChatroomHistoryBlock _Nullable)result;
		[Abstract]
		[Export ("fetchMessageHistory:option:result:")]
		void FetchMessageHistory (string roomId, NIMHistoryMessageSearchOption option, [NullAllowed] NIMFetchChatroomHistoryBlock result);

		// @required -(void)fetchChatroomInfo:(NSString * _Nonnull)roomId completion:(NIMChatroomInfoHandler _Nullable)completion;
		[Abstract]
		[Export ("fetchChatroomInfo:completion:")]
		void FetchChatroomInfo (string roomId, [NullAllowed] NIMChatroomInfoHandler completion);

		// @required -(void)updateChatroomInfo:(NIMChatroomUpdateRequest * _Nonnull)request completion:(NIMChatroomHandler _Nullable)completion;
		[Abstract]
		[Export ("updateChatroomInfo:completion:")]
		void UpdateChatroomInfo (NIMChatroomUpdateRequest request, [NullAllowed] NIMChatroomHandler completion);

		// @required -(void)updateMyChatroomMemberInfo:(NIMChatroomMemberInfoUpdateRequest * _Nonnull)request completion:(NIMChatroomHandler _Nullable)completion;
		[Abstract]
		[Export ("updateMyChatroomMemberInfo:completion:")]
		void UpdateMyChatroomMemberInfo (NIMChatroomMemberInfoUpdateRequest request, [NullAllowed] NIMChatroomHandler completion);

		// @required -(void)fetchChatroomMembers:(NIMChatroomMemberRequest * _Nonnull)request completion:(NIMChatroomMembersHandler _Nullable)completion;
		[Abstract]
		[Export ("fetchChatroomMembers:completion:")]
		void FetchChatroomMembers (NIMChatroomMemberRequest request, [NullAllowed] NIMChatroomMembersHandler completion);

		// @required -(void)fetchChatroomMembersByIds:(NIMChatroomMembersByIdsRequest * _Nonnull)request completion:(NIMChatroomMembersHandler _Nullable)completion;
		[Abstract]
		[Export ("fetchChatroomMembersByIds:completion:")]
		void FetchChatroomMembersByIds (NIMChatroomMembersByIdsRequest request, [NullAllowed] NIMChatroomMembersHandler completion);

		// @required -(void)markMemberManager:(NIMChatroomMemberUpdateRequest * _Nonnull)request completion:(NIMChatroomHandler _Nullable)completion;
		[Abstract]
		[Export ("markMemberManager:completion:")]
		void MarkMemberManager (NIMChatroomMemberUpdateRequest request, [NullAllowed] NIMChatroomHandler completion);

		// @required -(void)markNormalMember:(NIMChatroomMemberUpdateRequest * _Nonnull)request completion:(NIMChatroomHandler _Nullable)completion;
		[Abstract]
		[Export ("markNormalMember:completion:")]
		void MarkNormalMember (NIMChatroomMemberUpdateRequest request, [NullAllowed] NIMChatroomHandler completion);

		// @required -(void)updateMemberBlack:(NIMChatroomMemberUpdateRequest * _Nonnull)request completion:(NIMChatroomHandler _Nullable)completion;
		[Abstract]
		[Export ("updateMemberBlack:completion:")]
		void UpdateMemberBlack (NIMChatroomMemberUpdateRequest request, [NullAllowed] NIMChatroomHandler completion);

		// @required -(void)updateMemberMute:(NIMChatroomMemberUpdateRequest * _Nonnull)request completion:(NIMChatroomHandler _Nullable)completion;
		[Abstract]
		[Export ("updateMemberMute:completion:")]
		void UpdateMemberMute (NIMChatroomMemberUpdateRequest request, [NullAllowed] NIMChatroomHandler completion);

		// @required -(void)updateMemberTempMute:(NIMChatroomMemberUpdateRequest * _Nonnull)request duration:(unsigned long long)duration completion:(NIMChatroomHandler _Nullable)completion;
		[Abstract]
		[Export ("updateMemberTempMute:duration:completion:")]
		void UpdateMemberTempMute (NIMChatroomMemberUpdateRequest request, ulong duration, [NullAllowed] NIMChatroomHandler completion);

		// @required -(void)kickMember:(NIMChatroomMemberKickRequest * _Nonnull)request completion:(NIMChatroomHandler _Nullable)completion;
		[Abstract]
		[Export ("kickMember:completion:")]
		void KickMember (NIMChatroomMemberKickRequest request, [NullAllowed] NIMChatroomHandler completion);

		// @required -(void)updateChatroomQueueObject:(NIMChatroomQueueUpdateRequest * _Nonnull)request completion:(NIMChatroomHandler _Nullable)completion;
		[Abstract]
		[Export ("updateChatroomQueueObject:completion:")]
		void UpdateChatroomQueueObject (NIMChatroomQueueUpdateRequest request, [NullAllowed] NIMChatroomHandler completion);

		// @required -(void)removeChatroomQueueObject:(NIMChatroomQueueRemoveRequest * _Nonnull)request completion:(NIMChatroomQueueRemoveHandler _Nullable)completion;
		[Abstract]
		[Export ("removeChatroomQueueObject:completion:")]
		void RemoveChatroomQueueObject (NIMChatroomQueueRemoveRequest request, [NullAllowed] NIMChatroomQueueRemoveHandler completion);

		// @required -(void)fetchChatroomQueue:(NSString * _Nonnull)roomId completion:(NIMChatroomQueueInfoHandler _Nullable)completion;
		[Abstract]
		[Export ("fetchChatroomQueue:completion:")]
		void FetchChatroomQueue (string roomId, [NullAllowed] NIMChatroomQueueInfoHandler completion);

		// @required -(void)dropChatroomQueue:(NSString * _Nonnull)roomId completion:(NIMChatroomHandler _Nullable)completion;
		[Abstract]
		[Export ("dropChatroomQueue:completion:")]
		void DropChatroomQueue (string roomId, [NullAllowed] NIMChatroomHandler completion);

		// @required -(void)batchUpdateChatroomQueueObject:(NIMChatroomQueueBatchUpdateRequest * _Nonnull)request completion:(NIMChatroomQueueBatchUpdateHandler _Nullable)completion;
		[Abstract]
		[Export ("batchUpdateChatroomQueueObject:completion:")]
		void BatchUpdateChatroomQueueObject (NIMChatroomQueueBatchUpdateRequest request, [NullAllowed] NIMChatroomQueueBatchUpdateHandler completion);

		// @required -(void)addDelegate:(id<NIMChatroomManagerDelegate> _Nonnull)delegate;
		[Abstract]
		[Export ("addDelegate:")]
		void AddDelegate (NIMChatroomManagerDelegate @delegate);

		// @required -(void)removeDelegate:(id<NIMChatroomManagerDelegate> _Nonnull)delegate;
		[Abstract]
		[Export ("removeDelegate:")]
		void RemoveDelegate (NIMChatroomManagerDelegate @delegate);
	}

	// @interface NIMChatroomBeKickedResult : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMChatroomBeKickedResult
	{
		// @property (copy, nonatomic) NSString * _Nonnull roomId;
		[Export ("roomId")]
		string RoomId { get; set; }

		// @property (assign, nonatomic) NIMChatroomKickReason reason;
		[Export ("reason", ArgumentSemantic.Assign)]
		NIMChatroomKickReason Reason { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull ext;
		[Export ("ext")]
		string Ext { get; set; }
	}

	// typedef void (^NIMRequestChatroomAddressesCallback)(NSError * _Nullable, NSArray<NSString *> * _Nullable);
	delegate void NIMRequestChatroomAddressesCallback ([NullAllowed] NSError arg0, [NullAllowed] string[] arg1);

	// typedef void (^NIMRequestChatroomAddressesHandler)(NSString * _Nonnull, NIMRequestChatroomAddressesCallback _Nonnull);
	delegate void NIMRequestChatroomAddressesHandler (string arg0, NIMRequestChatroomAddressesCallback arg1);

	// @interface NIMChatroomIndependentMode : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMChatroomIndependentMode
	{
		// @property (copy, nonatomic) NSString * _Nullable username;
		[NullAllowed, Export ("username")]
		string Username { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable token;
		[NullAllowed, Export ("token")]
		string Token { get; set; }

		// +(void)registerRequestChatroomAddressesHandler:(NIMRequestChatroomAddressesHandler _Nonnull)handler;
		[Static]
		[Export ("registerRequestChatroomAddressesHandler:")]
		void RegisterRequestChatroomAddressesHandler (NIMRequestChatroomAddressesHandler handler);
	}

	// @interface NIMChatroomEnterRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMChatroomEnterRequest
	{
		// @property (copy, nonatomic) NSString * _Nonnull roomId;
		[Export ("roomId")]
		string RoomId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable roomNickname;
		[NullAllowed, Export ("roomNickname")]
		string RoomNickname { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable roomAvatar;
		[NullAllowed, Export ("roomAvatar")]
		string RoomAvatar { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable roomExt;
		[NullAllowed, Export ("roomExt")]
		string RoomExt { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable roomNotifyExt;
		[NullAllowed, Export ("roomNotifyExt")]
		string RoomNotifyExt { get; set; }

		// @property (assign, nonatomic) NSInteger retryCount;
		[Export ("retryCount")]
		nint RetryCount { get; set; }

		// @property (nonatomic, strong) NIMChatroomIndependentMode * _Nullable mode;
		[NullAllowed, Export ("mode", ArgumentSemantic.Strong)]
		NIMChatroomIndependentMode Mode { get; set; }
	}

	// @interface NIMChatroomMember : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMChatroomMember
	{
		// @property (copy, nonatomic) NSString * _Nullable userId;
		[NullAllowed, Export ("userId")]
		string UserId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable roomNickname;
		[NullAllowed, Export ("roomNickname")]
		string RoomNickname { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable roomAvatar;
		[NullAllowed, Export ("roomAvatar")]
		string RoomAvatar { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable roomAvatarThumbnail;
		[NullAllowed, Export ("roomAvatarThumbnail")]
		string RoomAvatarThumbnail { get; }

		// @property (copy, nonatomic) NSString * _Nullable roomExt;
		[NullAllowed, Export ("roomExt")]
		string RoomExt { get; set; }

		// @property (assign, nonatomic) NIMChatroomMemberType type;
		[Export ("type", ArgumentSemantic.Assign)]
		NIMChatroomMemberType Type { get; set; }

		// @property (assign, nonatomic) BOOL isMuted;
		[Export ("isMuted")]
		bool IsMuted { get; set; }

		// @property (assign, nonatomic) BOOL isTempMuted;
		[Export ("isTempMuted")]
		bool IsTempMuted { get; set; }

		// @property (assign, nonatomic) unsigned long long tempMuteDuration;
		[Export ("tempMuteDuration")]
		ulong TempMuteDuration { get; set; }

		// @property (assign, nonatomic) BOOL isInBlackList;
		[Export ("isInBlackList")]
		bool IsInBlackList { get; set; }

		// @property (assign, nonatomic) BOOL isOnline;
		[Export ("isOnline")]
		bool IsOnline { get; set; }

		// @property (assign, nonatomic) NSTimeInterval enterTimeInterval;
		[Export ("enterTimeInterval")]
		double EnterTimeInterval { get; set; }
	}

	// @interface NIMChatroomMemberRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMChatroomMemberRequest
	{
		// @property (copy, nonatomic) NSString * _Nonnull roomId;
		[Export ("roomId")]
		string RoomId { get; set; }

		// @property (assign, nonatomic) NIMChatroomFetchMemberType type;
		[Export ("type", ArgumentSemantic.Assign)]
		NIMChatroomFetchMemberType Type { get; set; }

		// @property (nonatomic, strong) NIMChatroomMember * _Nullable lastMember;
		[NullAllowed, Export ("lastMember", ArgumentSemantic.Strong)]
		NIMChatroomMember LastMember { get; set; }

		// @property (assign, nonatomic) NSUInteger limit;
		[Export ("limit")]
		nuint Limit { get; set; }
	}

	// @interface NIMChatroomMembersByIdsRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMChatroomMembersByIdsRequest
	{
		// @property (copy, nonatomic) NSString * _Nonnull roomId;
		[Export ("roomId")]
		string RoomId { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull userIds;
		[Export ("userIds", ArgumentSemantic.Copy)]
		string[] UserIds { get; set; }
	}

	// @interface NIMChatroomMemberUpdateRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMChatroomMemberUpdateRequest
	{
		// @property (copy, nonatomic) NSString * _Nonnull roomId;
		[Export ("roomId")]
		string RoomId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull userId;
		[Export ("userId")]
		string UserId { get; set; }

		// @property (assign, nonatomic) BOOL enable;
		[Export ("enable")]
		bool Enable { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable notifyExt;
		[NullAllowed, Export ("notifyExt")]
		string NotifyExt { get; set; }
	}

	// @interface NIMChatroomMemberInfoUpdateRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMChatroomMemberInfoUpdateRequest
	{
		// @property (copy, nonatomic) NSString * _Nonnull roomId;
		[Export ("roomId")]
		string RoomId { get; set; }

		// @property (copy, nonatomic) NSDictionary * _Nonnull updateInfo;
		[Export ("updateInfo", ArgumentSemantic.Copy)]
		NSDictionary UpdateInfo { get; set; }

		// @property (assign, nonatomic) BOOL needNotify;
		[Export ("needNotify")]
		bool NeedNotify { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable notifyExt;
		[NullAllowed, Export ("notifyExt")]
		string NotifyExt { get; set; }

		// @property (assign, nonatomic) BOOL needSave;
		[Export ("needSave")]
		bool NeedSave { get; set; }
	}

	// @interface NIMChatroomMemberKickRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMChatroomMemberKickRequest
	{
		// @property (copy, nonatomic) NSString * _Nonnull roomId;
		[Export ("roomId")]
		string RoomId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull userId;
		[Export ("userId")]
		string UserId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable notifyExt;
		[NullAllowed, Export ("notifyExt")]
		string NotifyExt { get; set; }
	}

	// @interface NIMNotificationContent : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMNotificationContent
	{
		// -(NIMNotificationType)notificationType;
		[Export ("notificationType")]
		[Verify (MethodToProperty)]
		NIMNotificationType NotificationType { get; }
	}

	// @interface NIMChatroomNotificationMember : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMChatroomNotificationMember
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable userId;
		[NullAllowed, Export ("userId")]
		string UserId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable nick;
		[NullAllowed, Export ("nick")]
		string Nick { get; }
	}

	// @interface NIMChatroomNotificationContent : NIMNotificationContent
	[BaseType (typeof(NIMNotificationContent))]
	interface NIMChatroomNotificationContent
	{
		// @property (readonly, assign, nonatomic) NIMChatroomEventType eventType;
		[Export ("eventType", ArgumentSemantic.Assign)]
		NIMChatroomEventType EventType { get; }

		// @property (readonly, copy, nonatomic) NIMChatroomNotificationMember * _Nullable source;
		[NullAllowed, Export ("source", ArgumentSemantic.Copy)]
		NIMChatroomNotificationMember Source { get; }

		// @property (readonly, copy, nonatomic) NSArray<NIMChatroomNotificationMember *> * _Nullable targets;
		[NullAllowed, Export ("targets", ArgumentSemantic.Copy)]
		NIMChatroomNotificationMember[] Targets { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable notifyExt;
		[NullAllowed, Export ("notifyExt")]
		string NotifyExt { get; }

		// @property (readonly, copy, nonatomic) id _Nullable ext;
		[NullAllowed, Export ("ext", ArgumentSemantic.Copy)]
		NSObject Ext { get; }
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull NIMChatroomEventInfoMutedKey;
		[Field ("NIMChatroomEventInfoMutedKey", "__Internal")]
		NSString NIMChatroomEventInfoMutedKey { get; }

		// extern NSString *const _Nonnull NIMChatroomEventInfoTempMutedKey;
		[Field ("NIMChatroomEventInfoTempMutedKey", "__Internal")]
		NSString NIMChatroomEventInfoTempMutedKey { get; }

		// extern NSString *const _Nonnull NIMChatroomEventInfoTempMutedDurationKey;
		[Field ("NIMChatroomEventInfoTempMutedDurationKey", "__Internal")]
		NSString NIMChatroomEventInfoTempMutedDurationKey { get; }

		// extern NSString *const _Nonnull NIMChatroomEventInfoQueueChangeTypeKey;
		[Field ("NIMChatroomEventInfoQueueChangeTypeKey", "__Internal")]
		NSString NIMChatroomEventInfoQueueChangeTypeKey { get; }

		// extern NSString *const _Nonnull NIMChatroomEventInfoQueueChangeItemKey;
		[Field ("NIMChatroomEventInfoQueueChangeItemKey", "__Internal")]
		NSString NIMChatroomEventInfoQueueChangeItemKey { get; }

		// extern NSString *const _Nonnull NIMChatroomEventInfoQueueChangeItemsKey;
		[Field ("NIMChatroomEventInfoQueueChangeItemsKey", "__Internal")]
		NSString NIMChatroomEventInfoQueueChangeItemsKey { get; }

		// extern NSString *const _Nonnull NIMChatroomEventInfoQueueChangeItemValueKey;
		[Field ("NIMChatroomEventInfoQueueChangeItemValueKey", "__Internal")]
		NSString NIMChatroomEventInfoQueueChangeItemValueKey { get; }
	}

	// @interface NIMChatroomQueueUpdateRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMChatroomQueueUpdateRequest
	{
		// @property (copy, nonatomic) NSString * _Nonnull roomId;
		[Export ("roomId")]
		string RoomId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull key;
		[Export ("key")]
		string Key { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull value;
		[Export ("value")]
		string Value { get; set; }

		// @property (assign, nonatomic) BOOL transient;
		[Export ("transient")]
		bool Transient { get; set; }
	}

	// @interface NIMChatroomQueueRemoveRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMChatroomQueueRemoveRequest
	{
		// @property (copy, nonatomic) NSString * _Nonnull roomId;
		[Export ("roomId")]
		string RoomId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable key;
		[NullAllowed, Export ("key")]
		string Key { get; set; }
	}

	// @interface NIMChatroomQueueBatchUpdateRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMChatroomQueueBatchUpdateRequest
	{
		// @property (copy, nonatomic) NSString * _Nonnull roomId;
		[Export ("roomId")]
		string RoomId { get; set; }

		// @property (copy, nonatomic) NSDictionary * _Nonnull elements;
		[Export ("elements", ArgumentSemantic.Copy)]
		NSDictionary Elements { get; set; }

		// @property (assign, nonatomic) BOOL needNotify;
		[Export ("needNotify")]
		bool NeedNotify { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull notifyExt;
		[Export ("notifyExt")]
		string NotifyExt { get; set; }
	}

	// @interface NIMChatroomUpdateRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMChatroomUpdateRequest
	{
		// @property (copy, nonatomic) NSString * _Nonnull roomId;
		[Export ("roomId")]
		string RoomId { get; set; }

		// @property (copy, nonatomic) NSDictionary * _Nonnull updateInfo;
		[Export ("updateInfo", ArgumentSemantic.Copy)]
		NSDictionary UpdateInfo { get; set; }

		// @property (assign, nonatomic) BOOL needNotify;
		[Export ("needNotify")]
		bool NeedNotify { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable notifyExt;
		[NullAllowed, Export ("notifyExt")]
		string NotifyExt { get; set; }
	}

	// typedef void (^NIMFetchMessageHistoryBlock)(NSError * _Nullable, NSArray<NIMMessage *> * _Nullable);
	delegate void NIMFetchMessageHistoryBlock ([NullAllowed] NSError arg0, [NullAllowed] NIMMessage[] arg1);

	// typedef void (^NIMUpdateMessageBlock)(NSError * _Nullable);
	delegate void NIMUpdateMessageBlock ([NullAllowed] NSError arg0);

	// typedef void (^NIMImportRecentSessionsBlock)(NSError * _Nullable, NSArray<NIMImportedRecentSession *> * _Nullable);
	delegate void NIMImportRecentSessionsBlock ([NullAllowed] NSError arg0, [NullAllowed] NIMImportedRecentSession[] arg1);

	// typedef void (^NIMRemoveRemoteSessionBlock)(NSError * _Nullable);
	delegate void NIMRemoveRemoteSessionBlock ([NullAllowed] NSError arg0);

	// typedef void (^NIMSearchMessageBlock)(NSError * _Nullable, NSArray<NIMMessage *> * _Nullable);
	delegate void NIMSearchMessageBlock ([NullAllowed] NSError arg0, [NullAllowed] NIMMessage[] arg1);

	// typedef void (^NIMGlobalSearchMessageBlock)(NSError * _Nullable, NSDictionary<NIMSession *,NSArray<NIMMessage *> *> * _Nullable);
	delegate void NIMGlobalSearchMessageBlock ([NullAllowed] NSError arg0, [NullAllowed] NSDictionary<NIMSession, NSArray<NIMMessage>> arg1);

	// @protocol NIMConversationManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMConversationManagerDelegate
	{
		// @optional -(void)didAddRecentSession:(NIMRecentSession * _Nonnull)recentSession totalUnreadCount:(NSInteger)totalUnreadCount;
		[Export ("didAddRecentSession:totalUnreadCount:")]
		void DidAddRecentSession (NIMRecentSession recentSession, nint totalUnreadCount);

		// @optional -(void)didUpdateRecentSession:(NIMRecentSession * _Nonnull)recentSession totalUnreadCount:(NSInteger)totalUnreadCount;
		[Export ("didUpdateRecentSession:totalUnreadCount:")]
		void DidUpdateRecentSession (NIMRecentSession recentSession, nint totalUnreadCount);

		// @optional -(void)didRemoveRecentSession:(NIMRecentSession * _Nonnull)recentSession totalUnreadCount:(NSInteger)totalUnreadCount;
		[Export ("didRemoveRecentSession:totalUnreadCount:")]
		void DidRemoveRecentSession (NIMRecentSession recentSession, nint totalUnreadCount);

		// @optional -(void)messagesDeletedInSession:(NIMSession * _Nonnull)session;
		[Export ("messagesDeletedInSession:")]
		void MessagesDeletedInSession (NIMSession session);

		// @optional -(void)allMessagesDeleted;
		[Export ("allMessagesDeleted")]
		void AllMessagesDeleted ();

		// @optional -(void)allMessagesRead;
		[Export ("allMessagesRead")]
		void AllMessagesRead ();
	}

	// @protocol NIMConversationManager <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMConversationManager
	{
		// @required -(void)deleteMessage:(NIMMessage * _Nonnull)message;
		[Abstract]
		[Export ("deleteMessage:")]
		void DeleteMessage (NIMMessage message);

		// @required -(void)deleteAllmessagesInSession:(NIMSession * _Nonnull)session option:(NIMDeleteMessagesOption * _Nullable)option;
		[Abstract]
		[Export ("deleteAllmessagesInSession:option:")]
		void DeleteAllmessagesInSession (NIMSession session, [NullAllowed] NIMDeleteMessagesOption option);

		// @required -(void)deleteAllMessages:(NIMDeleteMessagesOption * _Nullable)option;
		[Abstract]
		[Export ("deleteAllMessages:")]
		void DeleteAllMessages ([NullAllowed] NIMDeleteMessagesOption option);

		// @required -(void)addEmptyRecentSessionBySession:(NIMSession * _Nonnull)session;
		[Abstract]
		[Export ("addEmptyRecentSessionBySession:")]
		void AddEmptyRecentSessionBySession (NIMSession session);

		// @required -(void)deleteRecentSession:(NIMRecentSession * _Nonnull)recentSession;
		[Abstract]
		[Export ("deleteRecentSession:")]
		void DeleteRecentSession (NIMRecentSession recentSession);

		// @required -(void)markAllMessagesRead;
		[Abstract]
		[Export ("markAllMessagesRead")]
		void MarkAllMessagesRead ();

		// @required -(void)markAllMessagesReadInSession:(NIMSession * _Nonnull)session;
		[Abstract]
		[Export ("markAllMessagesReadInSession:")]
		void MarkAllMessagesReadInSession (NIMSession session);

		// @required -(void)updateMessage:(NIMMessage * _Nonnull)message forSession:(NIMSession * _Nonnull)session completion:(NIMUpdateMessageBlock _Nullable)completion;
		[Abstract]
		[Export ("updateMessage:forSession:completion:")]
		void UpdateMessage (NIMMessage message, NIMSession session, [NullAllowed] NIMUpdateMessageBlock completion);

		// @required -(void)saveMessage:(NIMMessage * _Nonnull)message forSession:(NIMSession * _Nonnull)session completion:(NIMUpdateMessageBlock _Nullable)completion;
		[Abstract]
		[Export ("saveMessage:forSession:completion:")]
		void SaveMessage (NIMMessage message, NIMSession session, [NullAllowed] NIMUpdateMessageBlock completion);

		// @required -(void)importRecentSessions:(NSArray<NIMImportedRecentSession *> * _Nonnull)importedRecentSession completion:(NIMImportRecentSessionsBlock _Nullable)completion;
		[Abstract]
		[Export ("importRecentSessions:completion:")]
		void ImportRecentSessions (NIMImportedRecentSession[] importedRecentSession, [NullAllowed] NIMImportRecentSessionsBlock completion);

		// @required -(NSArray<NIMMessage *> * _Nullable)messagesInSession:(NIMSession * _Nonnull)session message:(NIMMessage * _Nullable)message limit:(NSInteger)limit;
		[Abstract]
		[Export ("messagesInSession:message:limit:")]
		[return: NullAllowed]
		NIMMessage[] MessagesInSession (NIMSession session, [NullAllowed] NIMMessage message, nint limit);

		// @required -(NSArray<NIMMessage *> * _Nullable)messagesInSession:(NIMSession * _Nonnull)session messageIds:(NSArray<NSString *> * _Nonnull)messageIds;
		[Abstract]
		[Export ("messagesInSession:messageIds:")]
		[return: NullAllowed]
		NIMMessage[] MessagesInSession (NIMSession session, string[] messageIds);

		// @required -(NSInteger)allUnreadCount;
		[Abstract]
		[Export ("allUnreadCount")]
		[Verify (MethodToProperty)]
		nint AllUnreadCount { get; }

		// @required -(NSInteger)allUnreadCount:(BOOL)notify;
		[Abstract]
		[Export ("allUnreadCount:")]
		nint AllUnreadCount (bool notify);

		// @required -(NSArray<NIMRecentSession *> * _Nullable)allRecentSessions;
		[Abstract]
		[NullAllowed, Export ("allRecentSessions")]
		[Verify (MethodToProperty)]
		NIMRecentSession[] AllRecentSessions { get; }

		// @required -(NIMRecentSession * _Nullable)recentSessionBySession:(NIMSession * _Nonnull)session;
		[Abstract]
		[Export ("recentSessionBySession:")]
		[return: NullAllowed]
		NIMRecentSession RecentSessionBySession (NIMSession session);

		// @required -(void)fetchMessageHistory:(NIMSession * _Nonnull)session option:(NIMHistoryMessageSearchOption * _Nonnull)option result:(NIMFetchMessageHistoryBlock _Nullable)result;
		[Abstract]
		[Export ("fetchMessageHistory:option:result:")]
		void FetchMessageHistory (NIMSession session, NIMHistoryMessageSearchOption option, [NullAllowed] NIMFetchMessageHistoryBlock result);

		// @required -(void)searchMessages:(NIMSession * _Nonnull)session option:(NIMMessageSearchOption * _Nonnull)option result:(NIMSearchMessageBlock _Nullable)result;
		[Abstract]
		[Export ("searchMessages:option:result:")]
		void SearchMessages (NIMSession session, NIMMessageSearchOption option, [NullAllowed] NIMSearchMessageBlock result);

		// @required -(void)searchAllMessages:(NIMMessageSearchOption * _Nonnull)option result:(NIMGlobalSearchMessageBlock _Nullable)result;
		[Abstract]
		[Export ("searchAllMessages:result:")]
		void SearchAllMessages (NIMMessageSearchOption option, [NullAllowed] NIMGlobalSearchMessageBlock result);

		// @required -(void)deleteRemoteSessions:(NSArray<NIMSession *> * _Nonnull)sessions completion:(NIMRemoveRemoteSessionBlock _Nullable)completion;
		[Abstract]
		[Export ("deleteRemoteSessions:completion:")]
		void DeleteRemoteSessions (NIMSession[] sessions, [NullAllowed] NIMRemoveRemoteSessionBlock completion);

		// @required -(void)updateRecentLocalExt:(NSDictionary * _Nullable)ext recentSession:(NIMRecentSession * _Nonnull)recentSession;
		[Abstract]
		[Export ("updateRecentLocalExt:recentSession:")]
		void UpdateRecentLocalExt ([NullAllowed] NSDictionary ext, NIMRecentSession recentSession);

		// @required -(void)addDelegate:(id<NIMConversationManagerDelegate> _Nonnull)delegate;
		[Abstract]
		[Export ("addDelegate:")]
		void AddDelegate (NIMConversationManagerDelegate @delegate);

		// @required -(void)removeDelegate:(id<NIMConversationManagerDelegate> _Nonnull)delegate;
		[Abstract]
		[Export ("removeDelegate:")]
		void RemoveDelegate (NIMConversationManagerDelegate @delegate);
	}

	// @interface NIMCreateTeamOption : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMCreateTeamOption
	{
		// @property (copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; set; }

		// @property (assign, nonatomic) NIMTeamType type;
		[Export ("type", ArgumentSemantic.Assign)]
		NIMTeamType Type { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable avatarUrl;
		[NullAllowed, Export ("avatarUrl")]
		string AvatarUrl { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable intro;
		[NullAllowed, Export ("intro")]
		string Intro { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable announcement;
		[NullAllowed, Export ("announcement")]
		string Announcement { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable clientCustomInfo;
		[NullAllowed, Export ("clientCustomInfo")]
		string ClientCustomInfo { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable postscript;
		[NullAllowed, Export ("postscript")]
		string Postscript { get; set; }

		// @property (assign, nonatomic) NIMTeamJoinMode joinMode;
		[Export ("joinMode", ArgumentSemantic.Assign)]
		NIMTeamJoinMode JoinMode { get; set; }

		// @property (assign, nonatomic) NIMTeamInviteMode inviteMode;
		[Export ("inviteMode", ArgumentSemantic.Assign)]
		NIMTeamInviteMode InviteMode { get; set; }

		// @property (assign, nonatomic) NIMTeamBeInviteMode beInviteMode;
		[Export ("beInviteMode", ArgumentSemantic.Assign)]
		NIMTeamBeInviteMode BeInviteMode { get; set; }

		// @property (assign, nonatomic) NIMTeamUpdateInfoMode updateInfoMode;
		[Export ("updateInfoMode", ArgumentSemantic.Assign)]
		NIMTeamUpdateInfoMode UpdateInfoMode { get; set; }

		// @property (assign, nonatomic) NIMTeamUpdateClientCustomMode updateClientCustomMode;
		[Export ("updateClientCustomMode", ArgumentSemantic.Assign)]
		NIMTeamUpdateClientCustomMode UpdateClientCustomMode { get; set; }

		// @property (assign, nonatomic) NSUInteger maxMemberCountLimitation;
		[Export ("maxMemberCountLimitation")]
		nuint MaxMemberCountLimitation { get; set; }
	}

	// @protocol NIMCustomAttachment <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMCustomAttachment
	{
		// @required -(NSString * _Nonnull)encodeAttachment;
		[Abstract]
		[Export ("encodeAttachment")]
		[Verify (MethodToProperty)]
		string EncodeAttachment { get; }

		// @optional -(BOOL)attachmentNeedsUpload;
		[Export ("attachmentNeedsUpload")]
		[Verify (MethodToProperty)]
		bool AttachmentNeedsUpload { get; }

		// @optional -(NSString * _Nonnull)attachmentPathForUploading;
		[Export ("attachmentPathForUploading")]
		[Verify (MethodToProperty)]
		string AttachmentPathForUploading { get; }

		// @optional -(void)updateAttachmentURL:(NSString * _Nonnull)urlString;
		[Export ("updateAttachmentURL:")]
		void UpdateAttachmentURL (string urlString);

		// @optional -(BOOL)attachmentNeedsDownload;
		[Export ("attachmentNeedsDownload")]
		[Verify (MethodToProperty)]
		bool AttachmentNeedsDownload { get; }

		// @optional -(NSString * _Nonnull)attachmentURLStringForDownloading;
		[Export ("attachmentURLStringForDownloading")]
		[Verify (MethodToProperty)]
		string AttachmentURLStringForDownloading { get; }

		// @optional -(NSString * _Nonnull)attachmentPathForDownloading;
		[Export ("attachmentPathForDownloading")]
		[Verify (MethodToProperty)]
		string AttachmentPathForDownloading { get; }
	}

	// @protocol NIMCustomAttachmentCoding <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMCustomAttachmentCoding
	{
		// @required -(id<NIMCustomAttachment> _Nullable)decodeAttachment:(NSString * _Nullable)content;
		[Abstract]
		[Export ("decodeAttachment:")]
		[return: NullAllowed]
		NIMCustomAttachment DecodeAttachment ([NullAllowed] string content);
	}

	// @interface NIMCustomObject : NSObject <NIMMessageObject>
	[BaseType (typeof(NSObject))]
	interface NIMCustomObject : INIMMessageObject
	{
		// @property (nonatomic, strong) id<NIMCustomAttachment> _Nullable attachment;
		[NullAllowed, Export ("attachment", ArgumentSemantic.Strong)]
		NIMCustomAttachment Attachment { get; set; }

		// +(void)registerCustomDecoder:(id<NIMCustomAttachmentCoding> _Nonnull)decoder;
		[Static]
		[Export ("registerCustomDecoder:")]
		void RegisterCustomDecoder (NIMCustomAttachmentCoding decoder);
	}

	// @interface NIMCustomSystemNotificationSetting : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMCustomSystemNotificationSetting
	{
		// @property (assign, nonatomic) BOOL shouldBeCounted;
		[Export ("shouldBeCounted")]
		bool ShouldBeCounted { get; set; }

		// @property (assign, nonatomic) BOOL apnsEnabled;
		[Export ("apnsEnabled")]
		bool ApnsEnabled { get; set; }

		// @property (assign, nonatomic) BOOL apnsWithPrefix;
		[Export ("apnsWithPrefix")]
		bool ApnsWithPrefix { get; set; }
	}

	// @interface NIMDeleteMessagesOption : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMDeleteMessagesOption
	{
		// @property (assign, nonatomic) BOOL removeSession;
		[Export ("removeSession")]
		bool RemoveSession { get; set; }

		// @property (assign, nonatomic) BOOL removeTable;
		[Export ("removeTable")]
		bool RemoveTable { get; set; }
	}

	// @interface NIMDocTranscodingInfo : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMDocTranscodingInfo
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull docId;
		[Export ("docId")]
		string DocId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull docName;
		[Export ("docName")]
		string DocName { get; }

		// @property (readonly, assign, nonatomic) NIMDocTranscodingFileType sourceType;
		[Export ("sourceType", ArgumentSemantic.Assign)]
		NIMDocTranscodingFileType SourceType { get; }

		// @property (readonly, assign, nonatomic) UInt64 sourceSize;
		[Export ("sourceSize")]
		ulong SourceSize { get; }

		// @property (readonly, assign, nonatomic) NIMDocTranscodingImageType targetType;
		[Export ("targetType", ArgumentSemantic.Assign)]
		NIMDocTranscodingImageType TargetType { get; }

		// @property (readonly, assign, nonatomic) NIMDocTranscodingState state;
		[Export ("state", ArgumentSemantic.Assign)]
		NIMDocTranscodingState State { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull sourceFileUrl;
		[Export ("sourceFileUrl")]
		string SourceFileUrl { get; }

		// @property (readonly, assign, nonatomic) NSUInteger numberOfPages;
		[Export ("numberOfPages")]
		nuint NumberOfPages { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable ext;
		[NullAllowed, Export ("ext")]
		string Ext { get; }

		// @property (readonly, assign, nonatomic) NSInteger transcodingFlag;
		[Export ("transcodingFlag")]
		nint TranscodingFlag { get; }

		// -(UInt64)transcodedTotalSize:(NIMDocTranscodingQuality)quality;
		[Export ("transcodedTotalSize:")]
		ulong TranscodedTotalSize (NIMDocTranscodingQuality quality);

		// -(CGSize)transcodedImagesSize:(NIMDocTranscodingQuality)quality;
		[Export ("transcodedImagesSize:")]
		CGSize TranscodedImagesSize (NIMDocTranscodingQuality quality);

		// -(NSString * _Nullable)transcodedUrl:(NSUInteger)pageNumber ofQuality:(NIMDocTranscodingQuality)quality;
		[Export ("transcodedUrl:ofQuality:")]
		[return: NullAllowed]
		string TranscodedUrl (nuint pageNumber, NIMDocTranscodingQuality quality);
	}

	// typedef void (^NIMDocTranscodingInquireCompleteBlock)(NSError * _Nullable, NIMDocTranscodingInfo * _Nullable);
	delegate void NIMDocTranscodingInquireCompleteBlock ([NullAllowed] NSError arg0, [NullAllowed] NIMDocTranscodingInfo arg1);

	// typedef void (^NIMDocTranscodingFetchCompleteBlock)(NSError * _Nullable, NSArray<NIMDocTranscodingInfo *> * _Nullable);
	delegate void NIMDocTranscodingFetchCompleteBlock ([NullAllowed] NSError arg0, [NullAllowed] NIMDocTranscodingInfo[] arg1);

	// typedef void (^NIMDocTranscodingDeleteCompleteBlock)(NSError * _Nullable);
	delegate void NIMDocTranscodingDeleteCompleteBlock ([NullAllowed] NSError arg0);

	// @protocol NIMDocTranscodingManager <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMDocTranscodingManager
	{
		// @required -(void)inquireDocInfo:(NSString * _Nonnull)docId completion:(NIMDocTranscodingInquireCompleteBlock _Nullable)completion;
		[Abstract]
		[Export ("inquireDocInfo:completion:")]
		void InquireDocInfo (string docId, [NullAllowed] NIMDocTranscodingInquireCompleteBlock completion);

		// @required -(void)fetchMyDocsInfo:(NSString * _Nullable)lastDocId limit:(NSUInteger)limit completion:(NIMDocTranscodingFetchCompleteBlock _Nullable)completion;
		[Abstract]
		[Export ("fetchMyDocsInfo:limit:completion:")]
		void FetchMyDocsInfo ([NullAllowed] string lastDocId, nuint limit, [NullAllowed] NIMDocTranscodingFetchCompleteBlock completion);

		// @required -(void)deleteDoc:(NSString * _Nonnull)docId completion:(NIMDocTranscodingDeleteCompleteBlock _Nullable)completion;
		[Abstract]
		[Export ("deleteDoc:completion:")]
		void DeleteDoc (string docId, [NullAllowed] NIMDocTranscodingDeleteCompleteBlock completion);
	}

	// typedef void (^NIMEventSubscribeBlock)(NSError * _Nullable, NIMSubscribeEvent * _Nullable);
	delegate void NIMEventSubscribeBlock ([NullAllowed] NSError arg0, [NullAllowed] NIMSubscribeEvent arg1);

	// typedef void (^NIMEventSubscribeResponseBlock)(NSError * _Nullable, NSArray * _Nullable);
	delegate void NIMEventSubscribeResponseBlock ([NullAllowed] NSError arg0, [NullAllowed] NSObject[] arg1);

	// typedef void (^NIMEventSubscribeQueryBlock)(NSError * _Nullable, NSArray * _Nullable);
	delegate void NIMEventSubscribeQueryBlock ([NullAllowed] NSError arg0, [NullAllowed] NSObject[] arg1);

	// @protocol NIMEventSubscribeManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMEventSubscribeManagerDelegate
	{
		// @optional -(void)onRecvSubscribeEvents:(NSArray * _Nonnull)events;
		[Export ("onRecvSubscribeEvents:")]
		[Verify (StronglyTypedNSArray)]
		void OnRecvSubscribeEvents (NSObject[] events);
	}

	// @protocol NIMEventSubscribeManager <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMEventSubscribeManager
	{
		// @required -(void)publishEvent:(NIMSubscribeEvent * _Nonnull)event completion:(NIMEventSubscribeBlock _Nullable)completion;
		[Abstract]
		[Export ("publishEvent:completion:")]
		void PublishEvent (NIMSubscribeEvent @event, [NullAllowed] NIMEventSubscribeBlock completion);

		// @required -(void)subscribeEvent:(NIMSubscribeRequest * _Nonnull)request completion:(NIMEventSubscribeResponseBlock _Nullable)completion;
		[Abstract]
		[Export ("subscribeEvent:completion:")]
		void SubscribeEvent (NIMSubscribeRequest request, [NullAllowed] NIMEventSubscribeResponseBlock completion);

		// @required -(void)unSubscribeEvent:(NIMSubscribeRequest * _Nonnull)request completion:(NIMEventSubscribeResponseBlock _Nullable)completion;
		[Abstract]
		[Export ("unSubscribeEvent:completion:")]
		void UnSubscribeEvent (NIMSubscribeRequest request, [NullAllowed] NIMEventSubscribeResponseBlock completion);

		// @required -(void)querySubscribeEvent:(NIMSubscribeRequest * _Nonnull)request completion:(NIMEventSubscribeQueryBlock _Nullable)completion;
		[Abstract]
		[Export ("querySubscribeEvent:completion:")]
		void QuerySubscribeEvent (NIMSubscribeRequest request, [NullAllowed] NIMEventSubscribeQueryBlock completion);

		// @required -(void)addDelegate:(id<NIMEventSubscribeManagerDelegate> _Nonnull)delegate;
		[Abstract]
		[Export ("addDelegate:")]
		void AddDelegate (NIMEventSubscribeManagerDelegate @delegate);

		// @required -(void)removeDelegate:(id<NIMEventSubscribeManagerDelegate> _Nonnull)delegate;
		[Abstract]
		[Export ("removeDelegate:")]
		void RemoveDelegate (NIMEventSubscribeManagerDelegate @delegate);
	}

	// @interface NIMFileObject : NSObject <NIMMessageObject>
	[BaseType (typeof(NSObject))]
	interface NIMFileObject : INIMMessageObject
	{
		// -(instancetype _Nonnull)initWithSourcePath:(NSString * _Nonnull)sourcePath;
		[Export ("initWithSourcePath:")]
		IntPtr Constructor (string sourcePath);

		// -(instancetype _Nonnull)initWithData:(NSData * _Nonnull)data extension:(NSString * _Nonnull)extension;
		[Export ("initWithData:extension:")]
		IntPtr Constructor (NSData data, string extension);

		// -(instancetype _Nonnull)initWithSourcePath:(NSString * _Nonnull)sourcePath scene:(NSString * _Nonnull)scene;
		[Export ("initWithSourcePath:scene:")]
		IntPtr Constructor (string sourcePath, string scene);

		// -(instancetype _Nonnull)initWithData:(NSData * _Nonnull)data extension:(NSString * _Nonnull)extension scene:(NSString * _Nonnull)scene;
		[Export ("initWithData:extension:scene:")]
		IntPtr Constructor (NSData data, string extension, string scene);

		// @property (copy, nonatomic) NSString * _Nullable displayName;
		[NullAllowed, Export ("displayName")]
		string DisplayName { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable path;
		[NullAllowed, Export ("path")]
		string Path { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable url;
		[NullAllowed, Export ("url")]
		string Url { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable md5;
		[NullAllowed, Export ("md5")]
		string Md5 { get; }

		// @property (readonly, assign, nonatomic) long long fileLength;
		[Export ("fileLength")]
		long FileLength { get; }
	}

	// @interface NIMImageOption : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMImageOption
	{
		// @property (assign, nonatomic) float compressQuality;
		[Export ("compressQuality")]
		float CompressQuality { get; set; }

		// @property (assign, nonatomic) NIMImageFormat format;
		[Export ("format", ArgumentSemantic.Assign)]
		NIMImageFormat Format { get; set; }
	}

	// @interface NIMImageObject : NSObject <NIMMessageObject>
	[BaseType (typeof(NSObject))]
	interface NIMImageObject : INIMMessageObject
	{
		// -(instancetype _Nonnull)initWithImage:(UIImage * _Nonnull)image;
		[Export ("initWithImage:")]
		IntPtr Constructor (UIImage image);

		// -(instancetype _Nonnull)initWithFilepath:(NSString * _Nonnull)filepath;
		[Export ("initWithFilepath:")]
		IntPtr Constructor (string filepath);

		// -(instancetype _Nonnull)initWithData:(NSData * _Nonnull)data extension:(NSString * _Nonnull)extension;
		[Export ("initWithData:extension:")]
		IntPtr Constructor (NSData data, string extension);

		// -(instancetype _Nonnull)initWithImage:(UIImage * _Nonnull)image scene:(NSString * _Nonnull)scene;
		[Export ("initWithImage:scene:")]
		IntPtr Constructor (UIImage image, string scene);

		// -(instancetype _Nonnull)initWithFilepath:(NSString * _Nonnull)filepath scene:(NSString * _Nonnull)scene;
		[Export ("initWithFilepath:scene:")]
		IntPtr Constructor (string filepath, string scene);

		// -(instancetype _Nonnull)initWithData:(NSData * _Nonnull)data extension:(NSString * _Nonnull)extension scene:(NSString * _Nonnull)scene;
		[Export ("initWithData:extension:scene:")]
		IntPtr Constructor (NSData data, string extension, string scene);

		// @property (copy, nonatomic) NSString * _Nullable displayName;
		[NullAllowed, Export ("displayName")]
		string DisplayName { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable path;
		[NullAllowed, Export ("path")]
		string Path { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable thumbPath;
		[NullAllowed, Export ("thumbPath")]
		string ThumbPath { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable url;
		[NullAllowed, Export ("url")]
		string Url { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable thumbUrl;
		[NullAllowed, Export ("thumbUrl")]
		string ThumbUrl { get; }

		// @property (readonly, assign, nonatomic) CGSize size;
		[Export ("size", ArgumentSemantic.Assign)]
		CGSize Size { get; }

		// @property (nonatomic, strong) NIMImageOption * _Nullable option;
		[NullAllowed, Export ("option", ArgumentSemantic.Strong)]
		NIMImageOption Option { get; set; }

		// @property (readonly, assign, nonatomic) long long fileLength;
		[Export ("fileLength")]
		long FileLength { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable md5;
		[NullAllowed, Export ("md5")]
		string Md5 { get; }
	}

	// @interface NIMImportedRecentSession : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMImportedRecentSession
	{
		// @property (copy, nonatomic) NIMSession * _Nonnull session;
		[Export ("session", ArgumentSemantic.Copy)]
		NIMSession Session { get; set; }

		// @property (assign, nonatomic) NSTimeInterval timestamp;
		[Export ("timestamp")]
		double Timestamp { get; set; }
	}

	// @interface NIMLocationObject : NSObject <NIMMessageObject>
	[BaseType (typeof(NSObject))]
	interface NIMLocationObject : INIMMessageObject
	{
		// -(instancetype _Nonnull)initWithLatitude:(double)latitude longitude:(double)longitude title:(NSString * _Nullable)title;
		[Export ("initWithLatitude:longitude:title:")]
		IntPtr Constructor (double latitude, double longitude, [NullAllowed] string title);

		// @property (readonly, assign, nonatomic) double latitude;
		[Export ("latitude")]
		double Latitude { get; }

		// @property (readonly, assign, nonatomic) double longitude;
		[Export ("longitude")]
		double Longitude { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable title;
		[NullAllowed, Export ("title")]
		string Title { get; }
	}

	// @interface NIMLoginClient : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMLoginClient
	{
		// @property (readonly, assign, nonatomic) NIMLoginClientType type;
		[Export ("type", ArgumentSemantic.Assign)]
		NIMLoginClientType Type { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable os;
		[NullAllowed, Export ("os")]
		string Os { get; }

		// @property (readonly, assign, nonatomic) NSTimeInterval timestamp;
		[Export ("timestamp")]
		double Timestamp { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable customTag;
		[NullAllowed, Export ("customTag")]
		string CustomTag { get; }
	}

	// @interface NIMAutoLoginData : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMAutoLoginData
	{
		// @property (copy, nonatomic) NSString * _Nonnull account;
		[Export ("account")]
		string Account { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull token;
		[Export ("token")]
		string Token { get; set; }

		// @property (assign, nonatomic) BOOL forcedMode;
		[Export ("forcedMode")]
		bool ForcedMode { get; set; }
	}

	// typedef void (^NIMLoginHandler)(NSError * _Nullable);
	delegate void NIMLoginHandler ([NullAllowed] NSError arg0);

	// @protocol NIMLoginManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMLoginManagerDelegate
	{
		// @optional -(void)onKick:(NIMKickReason)code clientType:(NIMLoginClientType)clientType;
		[Export ("onKick:clientType:")]
		void OnKick (NIMKickReason code, NIMLoginClientType clientType);

		// @optional -(void)onLogin:(NIMLoginStep)step;
		[Export ("onLogin:")]
		void OnLogin (NIMLoginStep step);

		// @optional -(void)onAutoLoginFailed:(NSError * _Nonnull)error;
		[Export ("onAutoLoginFailed:")]
		void OnAutoLoginFailed (NSError error);

		// @optional -(void)onMultiLoginClientsChanged;
		[Export ("onMultiLoginClientsChanged")]
		void OnMultiLoginClientsChanged ();
	}

	// @protocol NIMLoginManager <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMLoginManager
	{
		// @required -(void)login:(NSString * _Nonnull)account token:(NSString * _Nonnull)token completion:(NIMLoginHandler _Nonnull)completion;
		[Abstract]
		[Export ("login:token:completion:")]
		void Login (string account, string token, NIMLoginHandler completion);

		// @required -(void)autoLogin:(NSString * _Nonnull)account token:(NSString * _Nonnull)token;
		[Abstract]
		[Export ("autoLogin:token:")]
		void AutoLogin (string account, string token);

		// @required -(void)autoLogin:(NIMAutoLoginData * _Nonnull)loginData;
		[Abstract]
		[Export ("autoLogin:")]
		void AutoLogin (NIMAutoLoginData loginData);

		// @required -(void)logout:(NIMLoginHandler _Nullable)completion;
		[Abstract]
		[Export ("logout:")]
		void Logout ([NullAllowed] NIMLoginHandler completion);

		// @required -(void)kickOtherClient:(NIMLoginClient * _Nonnull)client completion:(NIMLoginHandler _Nullable)completion;
		[Abstract]
		[Export ("kickOtherClient:completion:")]
		void KickOtherClient (NIMLoginClient client, [NullAllowed] NIMLoginHandler completion);

		// @required -(NSString * _Nonnull)currentAccount;
		[Abstract]
		[Export ("currentAccount")]
		[Verify (MethodToProperty)]
		string CurrentAccount { get; }

		// @required -(BOOL)isLogined;
		[Abstract]
		[Export ("isLogined")]
		[Verify (MethodToProperty)]
		bool IsLogined { get; }

		// @required -(NIMSDKAuthMode)currentAuthMode;
		[Abstract]
		[Export ("currentAuthMode")]
		[Verify (MethodToProperty)]
		NIMSDKAuthMode CurrentAuthMode { get; }

		// @required -(NSArray<NIMLoginClient *> * _Nullable)currentLoginClients;
		[Abstract]
		[NullAllowed, Export ("currentLoginClients")]
		[Verify (MethodToProperty)]
		NIMLoginClient[] CurrentLoginClients { get; }

		// @required -(void)addDelegate:(id<NIMLoginManagerDelegate> _Nonnull)delegate;
		[Abstract]
		[Export ("addDelegate:")]
		void AddDelegate (NIMLoginManagerDelegate @delegate);

		// @required -(void)removeDelegate:(id<NIMLoginManagerDelegate> _Nonnull)delegate;
		[Abstract]
		[Export ("removeDelegate:")]
		void RemoveDelegate (NIMLoginManagerDelegate @delegate);
	}

	// typedef void (^NIMAudioToTextBlock)(NSError * _Nullable, NSString * _Nullable);
	delegate void NIMAudioToTextBlock ([NullAllowed] NSError arg0, [NullAllowed] string arg1);

	// @interface NIMAudioToTextOption : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMAudioToTextOption
	{
		// @property (copy, nonatomic) NSString * _Nonnull url;
		[Export ("url")]
		string Url { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull filepath;
		[Export ("filepath")]
		string Filepath { get; set; }
	}

	// @protocol NIMMediaManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMMediaManagerDelegate
	{
		// @optional -(void)playAudio:(NSString * _Nonnull)filePath didBeganWithError:(NSError * _Nullable)error;
		[Export ("playAudio:didBeganWithError:")]
		void PlayAudio (string filePath, [NullAllowed] NSError error);

		// @optional -(void)playAudio:(NSString * _Nonnull)filePath didCompletedWithError:(NSError * _Nullable)error;
		[Export ("playAudio:didCompletedWithError:")]
		void PlayAudio (string filePath, [NullAllowed] NSError error);

		// @optional -(void)playAudioInterruptionBegin;
		[Export ("playAudioInterruptionBegin")]
		void PlayAudioInterruptionBegin ();

		// @optional -(void)playAudioInterruptionEnd;
		[Export ("playAudioInterruptionEnd")]
		void PlayAudioInterruptionEnd ();

		// @optional -(void)recordAudio:(NSString * _Nullable)filePath didBeganWithError:(NSError * _Nullable)error;
		[Export ("recordAudio:didBeganWithError:")]
		void RecordAudio ([NullAllowed] string filePath, [NullAllowed] NSError error);

		// @optional -(void)recordAudio:(NSString * _Nullable)filePath didCompletedWithError:(NSError * _Nullable)error;
		[Export ("recordAudio:didCompletedWithError:")]
		void RecordAudio ([NullAllowed] string filePath, [NullAllowed] NSError error);

		// @optional -(void)recordAudioDidCancelled;
		[Export ("recordAudioDidCancelled")]
		void RecordAudioDidCancelled ();

		// @optional -(void)recordAudioProgress:(NSTimeInterval)currentTime;
		[Export ("recordAudioProgress:")]
		void RecordAudioProgress (double currentTime);

		// @optional -(void)recordAudioInterruptionBegin;
		[Export ("recordAudioInterruptionBegin")]
		void RecordAudioInterruptionBegin ();

		// @optional -(void)recordAudioInterruptionEnd;
		[Export ("recordAudioInterruptionEnd")]
		void RecordAudioInterruptionEnd ();
	}

	// @protocol NIMMediaManager <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMMediaManager
	{
		// @required @property (assign, nonatomic) NSTimeInterval recordProgressUpdateTimeInterval;
		[Abstract]
		[Export ("recordProgressUpdateTimeInterval")]
		double RecordProgressUpdateTimeInterval { get; set; }

		// @required -(BOOL)switchAudioOutputDevice:(NIMAudioOutputDevice)outputDevice;
		[Abstract]
		[Export ("switchAudioOutputDevice:")]
		bool SwitchAudioOutputDevice (NIMAudioOutputDevice outputDevice);

		// @required -(void)setNeedProximityMonitor:(BOOL)needProximityMonitor;
		[Abstract]
		[Export ("setNeedProximityMonitor:")]
		void SetNeedProximityMonitor (bool needProximityMonitor);

		// @required -(BOOL)isPlaying;
		[Abstract]
		[Export ("isPlaying")]
		[Verify (MethodToProperty)]
		bool IsPlaying { get; }

		// @required -(void)play:(NSString * _Nonnull)filepath;
		[Abstract]
		[Export ("play:")]
		void Play (string filepath);

		// @required -(void)stopPlay;
		[Abstract]
		[Export ("stopPlay")]
		void StopPlay ();

		// @required -(BOOL)seek:(NSTimeInterval)timestamp;
		[Abstract]
		[Export ("seek:")]
		bool Seek (double timestamp);

		// @required -(BOOL)isRecording;
		[Abstract]
		[Export ("isRecording")]
		[Verify (MethodToProperty)]
		bool IsRecording { get; }

		// @required -(void)recordForDuration:(NSTimeInterval)duration;
		[Abstract]
		[Export ("recordForDuration:")]
		void RecordForDuration (double duration);

		// @required -(void)record:(NIMAudioType)type duration:(NSTimeInterval)duration;
		[Abstract]
		[Export ("record:duration:")]
		void Record (NIMAudioType type, double duration);

		// @required -(void)stopRecord;
		[Abstract]
		[Export ("stopRecord")]
		void StopRecord ();

		// @required -(void)cancelRecord;
		[Abstract]
		[Export ("cancelRecord")]
		void CancelRecord ();

		// @required -(float)recordPeakPower;
		[Abstract]
		[Export ("recordPeakPower")]
		[Verify (MethodToProperty)]
		float RecordPeakPower { get; }

		// @required -(float)recordAveragePower;
		[Abstract]
		[Export ("recordAveragePower")]
		[Verify (MethodToProperty)]
		float RecordAveragePower { get; }

		// @required -(void)transAudioToText:(NIMAudioToTextOption * _Nonnull)option result:(NIMAudioToTextBlock _Nonnull)result;
		[Abstract]
		[Export ("transAudioToText:result:")]
		void TransAudioToText (NIMAudioToTextOption option, NIMAudioToTextBlock result);

		// @required -(void)setDeactivateAudioSessionAfterComplete:(BOOL)deactivate;
		[Abstract]
		[Export ("setDeactivateAudioSessionAfterComplete:")]
		void SetDeactivateAudioSessionAfterComplete (bool deactivate);

		// @required -(void)addDelegate:(id<NIMMediaManagerDelegate> _Nonnull)delegate;
		[Abstract]
		[Export ("addDelegate:")]
		void AddDelegate (NIMMediaManagerDelegate @delegate);

		// @required -(void)removeDelegate:(id<NIMMediaManagerDelegate> _Nonnull)delegate;
		[Abstract]
		[Export ("removeDelegate:")]
		void RemoveDelegate (NIMMediaManagerDelegate @delegate);
	}

	// @interface NIMSession : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	interface NIMSession : INSCopying
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull sessionId;
		[Export ("sessionId")]
		string SessionId { get; }

		// @property (readonly, assign, nonatomic) NIMSessionType sessionType;
		[Export ("sessionType", ArgumentSemantic.Assign)]
		NIMSessionType SessionType { get; }

		// +(instancetype _Nonnull)session:(NSString * _Nonnull)sessionId type:(NIMSessionType)sessionType;
		[Static]
		[Export ("session:type:")]
		NIMSession Session (string sessionId, NIMSessionType sessionType);
	}

	// @interface NIMVideoObject : NSObject <NIMMessageObject>
	[BaseType (typeof(NSObject))]
	interface NIMVideoObject : INIMMessageObject
	{
		// -(instancetype _Nonnull)initWithSourcePath:(NSString * _Nonnull)sourcePath;
		[Export ("initWithSourcePath:")]
		IntPtr Constructor (string sourcePath);

		// -(instancetype _Nonnull)initWithData:(NSData * _Nonnull)data extension:(NSString * _Nonnull)extension;
		[Export ("initWithData:extension:")]
		IntPtr Constructor (NSData data, string extension);

		// -(instancetype _Nonnull)initWithSourcePath:(NSString * _Nonnull)sourcePath scene:(NSString * _Nonnull)scene;
		[Export ("initWithSourcePath:scene:")]
		IntPtr Constructor (string sourcePath, string scene);

		// -(instancetype _Nonnull)initWithData:(NSData * _Nonnull)data extension:(NSString * _Nonnull)extension scene:(NSString * _Nonnull)scene;
		[Export ("initWithData:extension:scene:")]
		IntPtr Constructor (NSData data, string extension, string scene);

		// @property (copy, nonatomic) NSString * _Nullable displayName;
		[NullAllowed, Export ("displayName")]
		string DisplayName { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable md5;
		[NullAllowed, Export ("md5")]
		string Md5 { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable path;
		[NullAllowed, Export ("path")]
		string Path { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable url;
		[NullAllowed, Export ("url")]
		string Url { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable coverUrl;
		[NullAllowed, Export ("coverUrl")]
		string CoverUrl { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable coverPath;
		[NullAllowed, Export ("coverPath")]
		string CoverPath { get; }

		// @property (readonly, assign, nonatomic) CGSize coverSize;
		[Export ("coverSize", ArgumentSemantic.Assign)]
		CGSize CoverSize { get; }

		// @property (assign, nonatomic) NSInteger duration;
		[Export ("duration")]
		nint Duration { get; set; }

		// @property (readonly, assign, nonatomic) long long fileLength;
		[Export ("fileLength")]
		long FileLength { get; }
	}

	// @interface NIMTeamNotificationContent : NIMNotificationContent
	[BaseType (typeof(NIMNotificationContent))]
	interface NIMTeamNotificationContent
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable sourceID;
		[NullAllowed, Export ("sourceID")]
		string SourceID { get; }

		// @property (readonly, assign, nonatomic) NIMTeamOperationType operationType;
		[Export ("operationType", ArgumentSemantic.Assign)]
		NIMTeamOperationType OperationType { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable targetIDs;
		[NullAllowed, Export ("targetIDs", ArgumentSemantic.Copy)]
		string[] TargetIDs { get; }

		// @property (readonly, nonatomic) NSString * _Nullable notifyExt;
		[NullAllowed, Export ("notifyExt")]
		string NotifyExt { get; }

		// @property (readonly, nonatomic, strong) id _Nullable attachment;
		[NullAllowed, Export ("attachment", ArgumentSemantic.Strong)]
		NSObject Attachment { get; }
	}

	// @interface NIMUpdateTeamInfoAttachment : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMUpdateTeamInfoAttachment
	{
		// @property (readonly, copy, nonatomic) NSDictionary<NSNumber *,NSString *> * _Nullable values;
		[NullAllowed, Export ("values", ArgumentSemantic.Copy)]
		NSDictionary<NSNumber, NSString> Values { get; }
	}

	// @interface NIMMuteTeamMemberAttachment : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMMuteTeamMemberAttachment
	{
		// @property (readonly, assign, nonatomic) BOOL flag;
		[Export ("flag")]
		bool Flag { get; }
	}

	// @interface NIMNetCallNotificationContent : NIMNotificationContent
	[BaseType (typeof(NIMNotificationContent))]
	interface NIMNetCallNotificationContent
	{
		// @property (assign, nonatomic) NIMNetCallType callType;
		[Export ("callType", ArgumentSemantic.Assign)]
		NIMNetCallType CallType { get; set; }

		// @property (assign, nonatomic) NIMNetCallEventType eventType;
		[Export ("eventType", ArgumentSemantic.Assign)]
		NIMNetCallEventType EventType { get; set; }

		// @property (assign, nonatomic) UInt64 callID;
		[Export ("callID")]
		ulong CallID { get; set; }

		// @property (assign, nonatomic) NSTimeInterval duration;
		[Export ("duration")]
		double Duration { get; set; }
	}

	// @interface NIMUnsupportedNotificationContent : NIMNotificationContent
	[BaseType (typeof(NIMNotificationContent))]
	interface NIMUnsupportedNotificationContent
	{
	}

	// @interface NIMNotificationObject : NSObject <NIMMessageObject>
	[BaseType (typeof(NSObject))]
	interface NIMNotificationObject : INIMMessageObject
	{
		// @property (readonly, nonatomic, strong) NIMNotificationContent * _Nonnull content;
		[Export ("content", ArgumentSemantic.Strong)]
		NIMNotificationContent Content { get; }

		// @property (readonly, assign, nonatomic) NIMNotificationType notificationType;
		[Export ("notificationType", ArgumentSemantic.Assign)]
		NIMNotificationType NotificationType { get; }
	}

	// @interface NIMTipObject : NSObject <NIMMessageObject>
	[BaseType (typeof(NSObject))]
	interface NIMTipObject : INIMMessageObject
	{
	}

	// @interface NIMRobotObject : NSObject <NIMMessageObject>
	[BaseType (typeof(NSObject))]
	interface NIMRobotObject : INIMMessageObject
	{
		// -(instancetype _Nonnull)initWithRobot:(NSString * _Nonnull)content robotId:(NSString * _Nonnull)robotId;
		[Export ("initWithRobot:robotId:")]
		IntPtr Constructor (string content, string robotId);

		// -(instancetype _Nonnull)initWithRobotId:(NSString * _Nonnull)robotId target:(NSString * _Nonnull)target param:(NSString * _Nonnull)param;
		[Export ("initWithRobotId:target:param:")]
		IntPtr Constructor (string robotId, string target, string param);

		// @property (readonly, assign, nonatomic) BOOL isFromRobot;
		[Export ("isFromRobot")]
		bool IsFromRobot { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable robotId;
		[NullAllowed, Export ("robotId")]
		string RobotId { get; }

		// @property (readonly, copy, nonatomic) NSDictionary * _Nullable response;
		[NullAllowed, Export ("response", ArgumentSemantic.Copy)]
		NSDictionary Response { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable responseForMessageId;
		[NullAllowed, Export ("responseForMessageId")]
		string ResponseForMessageId { get; }
	}

	// @interface NIMMessageSetting : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMMessageSetting
	{
		// @property (assign, nonatomic) BOOL historyEnabled;
		[Export ("historyEnabled")]
		bool HistoryEnabled { get; set; }

		// @property (assign, nonatomic) BOOL roamingEnabled;
		[Export ("roamingEnabled")]
		bool RoamingEnabled { get; set; }

		// @property (assign, nonatomic) BOOL syncEnabled;
		[Export ("syncEnabled")]
		bool SyncEnabled { get; set; }

		// @property (assign, nonatomic) BOOL shouldBeCounted;
		[Export ("shouldBeCounted")]
		bool ShouldBeCounted { get; set; }

		// @property (assign, nonatomic) BOOL apnsEnabled;
		[Export ("apnsEnabled")]
		bool ApnsEnabled { get; set; }

		// @property (assign, nonatomic) BOOL apnsWithPrefix;
		[Export ("apnsWithPrefix")]
		bool ApnsWithPrefix { get; set; }

		// @property (assign, nonatomic) BOOL routeEnabled;
		[Export ("routeEnabled")]
		bool RouteEnabled { get; set; }

		// @property (assign, nonatomic) BOOL teamReceiptEnabled;
		[Export ("teamReceiptEnabled")]
		bool TeamReceiptEnabled { get; set; }

		// @property (assign, nonatomic) BOOL persistEnable;
		[Export ("persistEnable")]
		bool PersistEnable { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull scene;
		[Export ("scene", ArgumentSemantic.Strong)]
		string Scene { get; set; }
	}

	// @interface NIMMessageReceipt : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMMessageReceipt
	{
		// @property (readonly, copy, nonatomic) NIMSession * _Nullable session;
		[NullAllowed, Export ("session", ArgumentSemantic.Copy)]
		NIMSession Session { get; }

		// @property (readonly, assign, nonatomic) NSTimeInterval timestamp;
		[Export ("timestamp")]
		double Timestamp { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull messageId;
		[Export ("messageId")]
		string MessageId { get; }

		// -(instancetype _Nonnull)initWithMessage:(NIMMessage * _Nonnull)message;
		[Export ("initWithMessage:")]
		IntPtr Constructor (NIMMessage message);
	}

	// @interface NIMTeamMessageReceiptDetail : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMTeamMessageReceiptDetail
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull messageId;
		[Export ("messageId")]
		string MessageId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull sessionId;
		[Export ("sessionId")]
		string SessionId { get; }

		// @property (readonly, copy, nonatomic) NSArray * _Nonnull readUserIds;
		[Export ("readUserIds", ArgumentSemantic.Copy)]
		[Verify (StronglyTypedNSArray)]
		NSObject[] ReadUserIds { get; }

		// @property (readonly, copy, nonatomic) NSArray * _Nonnull unreadUserIds;
		[Export ("unreadUserIds", ArgumentSemantic.Copy)]
		[Verify (StronglyTypedNSArray)]
		NSObject[] UnreadUserIds { get; }
	}

	// @interface NIMMessageApnsMemberOption : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMMessageApnsMemberOption
	{
		// @property (copy, nonatomic) NSArray<NSString *> * _Nullable userIds;
		[NullAllowed, Export ("userIds", ArgumentSemantic.Copy)]
		string[] UserIds { get; set; }

		// @property (assign, nonatomic) BOOL forcePush;
		[Export ("forcePush")]
		bool ForcePush { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable apnsContent;
		[NullAllowed, Export ("apnsContent")]
		string ApnsContent { get; set; }
	}

	// @interface NIMTeamMessageReceipt : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMTeamMessageReceipt
	{
		// @property (readonly, assign, nonatomic) NSInteger readCount;
		[Export ("readCount")]
		nint ReadCount { get; }

		// @property (readonly, assign, nonatomic) NSInteger unreadCount;
		[Export ("unreadCount")]
		nint UnreadCount { get; }
	}

	// @interface NIMMessage : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMMessage
	{
		// @property (readonly, assign, nonatomic) NIMMessageType messageType;
		[Export ("messageType", ArgumentSemantic.Assign)]
		NIMMessageType MessageType { get; }

		// @property (copy, nonatomic) NSString * _Nullable from;
		[NullAllowed, Export ("from")]
		string From { get; set; }

		// @property (readonly, copy, nonatomic) NIMSession * _Nullable session;
		[NullAllowed, Export ("session", ArgumentSemantic.Copy)]
		NIMSession Session { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull messageId;
		[Export ("messageId")]
		string MessageId { get; }

		// @property (copy, nonatomic) NSString * _Nullable text;
		[NullAllowed, Export ("text")]
		string Text { get; set; }

		// @property (nonatomic, strong) id<NIMMessageObject> _Nullable messageObject;
		[NullAllowed, Export ("messageObject", ArgumentSemantic.Strong)]
		NIMMessageObject MessageObject { get; set; }

		// @property (nonatomic, strong) NIMMessageSetting * _Nullable setting;
		[NullAllowed, Export ("setting", ArgumentSemantic.Strong)]
		NIMMessageSetting Setting { get; set; }

		// @property (nonatomic, strong) NIMAntiSpamOption * _Nullable antiSpamOption;
		[NullAllowed, Export ("antiSpamOption", ArgumentSemantic.Strong)]
		NIMAntiSpamOption AntiSpamOption { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable apnsContent;
		[NullAllowed, Export ("apnsContent")]
		string ApnsContent { get; set; }

		// @property (copy, nonatomic) NSDictionary * _Nullable apnsPayload;
		[NullAllowed, Export ("apnsPayload", ArgumentSemantic.Copy)]
		NSDictionary ApnsPayload { get; set; }

		// @property (nonatomic, strong) NIMMessageApnsMemberOption * _Nullable apnsMemberOption;
		[NullAllowed, Export ("apnsMemberOption", ArgumentSemantic.Strong)]
		NIMMessageApnsMemberOption ApnsMemberOption { get; set; }

		// @property (copy, nonatomic) NSDictionary * _Nullable remoteExt;
		[NullAllowed, Export ("remoteExt", ArgumentSemantic.Copy)]
		NSDictionary RemoteExt { get; set; }

		// @property (copy, nonatomic) NSDictionary * _Nullable localExt;
		[NullAllowed, Export ("localExt", ArgumentSemantic.Copy)]
		NSDictionary LocalExt { get; set; }

		// @property (nonatomic, strong) id _Nullable messageExt;
		[NullAllowed, Export ("messageExt", ArgumentSemantic.Strong)]
		NSObject MessageExt { get; set; }

		// @property (assign, nonatomic) NSTimeInterval timestamp;
		[Export ("timestamp")]
		double Timestamp { get; set; }

		// @property (readonly, assign, nonatomic) NIMMessageDeliveryState deliveryState;
		[Export ("deliveryState", ArgumentSemantic.Assign)]
		NIMMessageDeliveryState DeliveryState { get; }

		// @property (readonly, assign, nonatomic) NIMMessageAttachmentDownloadState attachmentDownloadState;
		[Export ("attachmentDownloadState", ArgumentSemantic.Assign)]
		NIMMessageAttachmentDownloadState AttachmentDownloadState { get; }

		// @property (readonly, assign, nonatomic) BOOL isReceivedMsg;
		[Export ("isReceivedMsg")]
		bool IsReceivedMsg { get; }

		// @property (readonly, assign, nonatomic) BOOL isOutgoingMsg;
		[Export ("isOutgoingMsg")]
		bool IsOutgoingMsg { get; }

		// @property (assign, nonatomic) BOOL isPlayed;
		[Export ("isPlayed")]
		bool IsPlayed { get; set; }

		// @property (readonly, assign, nonatomic) BOOL isDeleted;
		[Export ("isDeleted")]
		bool IsDeleted { get; }

		// @property (readonly, assign, nonatomic) BOOL isRemoteRead;
		[Export ("isRemoteRead")]
		bool IsRemoteRead { get; }

		// @property (readonly, assign, nonatomic) BOOL isTeamReceiptSended;
		[Export ("isTeamReceiptSended")]
		bool IsTeamReceiptSended { get; }

		// @property (readonly, nonatomic, strong) NIMTeamMessageReceipt * _Nullable teamReceiptInfo;
		[NullAllowed, Export ("teamReceiptInfo", ArgumentSemantic.Strong)]
		NIMTeamMessageReceipt TeamReceiptInfo { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable senderName;
		[NullAllowed, Export ("senderName")]
		string SenderName { get; }

		// @property (readonly, assign, nonatomic) NIMLoginClientType senderClientType;
		[Export ("senderClientType", ArgumentSemantic.Assign)]
		NIMLoginClientType SenderClientType { get; }
	}

	// @interface NIMMessageChatroomExtension : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMMessageChatroomExtension
	{
		// @property (copy, nonatomic) NSString * _Nullable roomNickname;
		[NullAllowed, Export ("roomNickname")]
		string RoomNickname { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable roomAvatar;
		[NullAllowed, Export ("roomAvatar")]
		string RoomAvatar { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable roomAvatarThumbnail;
		[NullAllowed, Export ("roomAvatarThumbnail")]
		string RoomAvatarThumbnail { get; }

		// @property (copy, nonatomic) NSString * _Nullable roomExt;
		[NullAllowed, Export ("roomExt")]
		string RoomExt { get; set; }
	}

	// @interface NIMMessageSearchOption : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMMessageSearchOption
	{
		// @property (assign, nonatomic) NSTimeInterval startTime;
		[Export ("startTime")]
		double StartTime { get; set; }

		// @property (assign, nonatomic) NSTimeInterval endTime;
		[Export ("endTime")]
		double EndTime { get; set; }

		// @property (assign, nonatomic) NSUInteger limit;
		[Export ("limit")]
		nuint Limit { get; set; }

		// @property (assign, nonatomic) NIMMessageSearchOrder order;
		[Export ("order", ArgumentSemantic.Assign)]
		NIMMessageSearchOrder Order { get; set; }

		// @property (copy, nonatomic) NSArray<NSNumber *> * _Nonnull messageTypes;
		[Export ("messageTypes", ArgumentSemantic.Copy)]
		NSNumber[] MessageTypes { get; set; }

		// @property (assign, nonatomic) BOOL allMessageTypes;
		[Export ("allMessageTypes")]
		bool AllMessageTypes { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable searchContent;
		[NullAllowed, Export ("searchContent")]
		string SearchContent { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * _Nullable fromIds;
		[NullAllowed, Export ("fromIds", ArgumentSemantic.Copy)]
		string[] FromIds { get; set; }
	}

	// @interface NIMHistoryMessageSearchOption : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMHistoryMessageSearchOption
	{
		// @property (assign, nonatomic) NSTimeInterval startTime;
		[Export ("startTime")]
		double StartTime { get; set; }

		// @property (assign, nonatomic) NSUInteger limit;
		[Export ("limit")]
		nuint Limit { get; set; }

		// @property (assign, nonatomic) NSTimeInterval endTime;
		[Export ("endTime")]
		double EndTime { get; set; }

		// @property (nonatomic, strong) NIMMessage * _Nullable currentMessage;
		[NullAllowed, Export ("currentMessage", ArgumentSemantic.Strong)]
		NIMMessage CurrentMessage { get; set; }

		// @property (assign, nonatomic) NIMMessageSearchOrder order;
		[Export ("order", ArgumentSemantic.Assign)]
		NIMMessageSearchOrder Order { get; set; }

		// @property (assign, nonatomic) BOOL sync;
		[Export ("sync")]
		bool Sync { get; set; }

		// @property (copy, nonatomic) NSArray<NSNumber *> * _Nonnull messageTypes;
		[Export ("messageTypes", ArgumentSemantic.Copy)]
		NSNumber[] MessageTypes { get; set; }
	}

	// @interface NIMPushNotificationSetting : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMPushNotificationSetting
	{
		// @property (assign, nonatomic) NIMPushNotificationDisplayType type;
		[Export ("type", ArgumentSemantic.Assign)]
		NIMPushNotificationDisplayType Type { get; set; }

		// @property (assign, nonatomic) BOOL noDisturbing;
		[Export ("noDisturbing")]
		bool NoDisturbing { get; set; }

		// @property (assign, nonatomic) NSUInteger noDisturbingStartH;
		[Export ("noDisturbingStartH")]
		nuint NoDisturbingStartH { get; set; }

		// @property (assign, nonatomic) NSUInteger noDisturbingStartM;
		[Export ("noDisturbingStartM")]
		nuint NoDisturbingStartM { get; set; }

		// @property (assign, nonatomic) NSUInteger noDisturbingEndH;
		[Export ("noDisturbingEndH")]
		nuint NoDisturbingEndH { get; set; }

		// @property (assign, nonatomic) NSUInteger noDisturbingEndM;
		[Export ("noDisturbingEndM")]
		nuint NoDisturbingEndM { get; set; }
	}

	// @interface NIMPushNotificationMultiportConfig : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMPushNotificationMultiportConfig
	{
		// @property (assign, nonatomic) BOOL shouldPushNotificationWhenPCOnline;
		[Export ("shouldPushNotificationWhenPCOnline")]
		bool ShouldPushNotificationWhenPCOnline { get; set; }
	}

	// @interface NIMRecentSession : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMRecentSession
	{
		// @property (readonly, copy, nonatomic) NIMSession * _Nullable session;
		[NullAllowed, Export ("session", ArgumentSemantic.Copy)]
		NIMSession Session { get; }

		// @property (readonly, nonatomic, strong) NIMMessage * _Nullable lastMessage;
		[NullAllowed, Export ("lastMessage", ArgumentSemantic.Strong)]
		NIMMessage LastMessage { get; }

		// @property (readonly, assign, nonatomic) NSInteger unreadCount;
		[Export ("unreadCount")]
		nint UnreadCount { get; }

		// @property (readonly, copy, nonatomic) NSDictionary * _Nullable localExt;
		[NullAllowed, Export ("localExt", ArgumentSemantic.Copy)]
		NSDictionary LocalExt { get; }
	}

	// @interface NIMRedPacketTokenRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMRedPacketTokenRequest
	{
		// @property (assign, nonatomic) NIMRedPacketServiceType type;
		[Export ("type", ArgumentSemantic.Assign)]
		NIMRedPacketServiceType Type { get; set; }
	}

	// typedef void (^NIMRedPacketTokenFetchBlock)(NSError * _Nullable, NSString * _Nullable);
	delegate void NIMRedPacketTokenFetchBlock ([NullAllowed] NSError arg0, [NullAllowed] string arg1);

	// @protocol NIMRedPacketManager <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMRedPacketManager
	{
		// @required -(void)fetchTokenWithRedPacketRequest:(NIMRedPacketTokenRequest * _Nonnull)request completion:(NIMRedPacketTokenFetchBlock _Nullable)completion;
		[Abstract]
		[Export ("fetchTokenWithRedPacketRequest:completion:")]
		void Completion (NIMRedPacketTokenRequest request, [NullAllowed] NIMRedPacketTokenFetchBlock completion);
	}

	// typedef void (^NIMResourceSearchHandler)(NSError * _Nullable, NSArray<NIMCacheQueryResult *> * _Nullable);
	delegate void NIMResourceSearchHandler ([NullAllowed] NSError arg0, [NullAllowed] NIMCacheQueryResult[] arg1);

	// typedef void (^NIMResourceDeleteHandler)(NSError * _Nullable, long long);
	delegate void NIMResourceDeleteHandler ([NullAllowed] NSError arg0, long arg1);

	// typedef void (^NIMUploadCompleteBlock)(NSString * _Nullable, NSError * _Nullable);
	delegate void NIMUploadCompleteBlock ([NullAllowed] string arg0, [NullAllowed] NSError arg1);

	// typedef void (^NIMFileQuickTransferCompleteBlock)(NSString * _Nullable, NSInteger, NSError * _Nullable);
	delegate void NIMFileQuickTransferCompleteBlock ([NullAllowed] string arg0, nint arg1, [NullAllowed] NSError arg2);

	// typedef void (^NIMHttpProgressBlock)(float);
	delegate void NIMHttpProgressBlock (float arg0);

	// typedef void (^NIMDownloadCompleteBlock)(NSError * _Nullable);
	delegate void NIMDownloadCompleteBlock ([NullAllowed] NSError arg0);

	// @protocol NIMResourceManager <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMResourceManager
	{
		// @required -(void)upload:(NSString * _Nonnull)filepath progress:(NIMHttpProgressBlock _Nullable)progress completion:(NIMUploadCompleteBlock _Nullable)completion;
		[Abstract]
		[Export ("upload:progress:completion:")]
		void Upload (string filepath, [NullAllowed] NIMHttpProgressBlock progress, [NullAllowed] NIMUploadCompleteBlock completion);

		// @required -(void)upload:(NSString * _Nonnull)filepath scene:(NSString * _Nonnull)scene progress:(NIMHttpProgressBlock _Nullable)progress completion:(NIMUploadCompleteBlock _Nullable)completion;
		[Abstract]
		[Export ("upload:scene:progress:completion:")]
		void Upload (string filepath, string scene, [NullAllowed] NIMHttpProgressBlock progress, [NullAllowed] NIMUploadCompleteBlock completion);

		// @required -(void)download:(NSString * _Nonnull)urlString filepath:(NSString * _Nonnull)filepath progress:(NIMHttpProgressBlock _Nullable)progress completion:(NIMDownloadCompleteBlock _Nullable)completion;
		[Abstract]
		[Export ("download:filepath:progress:completion:")]
		void Download (string urlString, string filepath, [NullAllowed] NIMHttpProgressBlock progress, [NullAllowed] NIMDownloadCompleteBlock completion);

		// @required -(void)cancelTask:(NSString * _Nonnull)filepath;
		[Abstract]
		[Export ("cancelTask:")]
		void CancelTask (string filepath);

		// @required -(NSString * _Nonnull)normalizeURLString:(NSString * _Nonnull)urlString;
		[Abstract]
		[Export ("normalizeURLString:")]
		string NormalizeURLString (string urlString);

		// @required -(NSString * _Nonnull)convertHttpToHttps:(NSString * _Nonnull)urlString;
		[Abstract]
		[Export ("convertHttpToHttps:")]
		string ConvertHttpToHttps (string urlString);

		// @required -(NSString * _Nonnull)convertURLToAcceleratedURL:(NSString * _Nonnull)urlString;
		[Abstract]
		[Export ("convertURLToAcceleratedURL:")]
		string ConvertURLToAcceleratedURL (string urlString);

		// @required -(NSString * _Nonnull)imageThumbnailURL:(NSString * _Nonnull)urlString;
		[Abstract]
		[Export ("imageThumbnailURL:")]
		string ImageThumbnailURL (string urlString);

		// @required -(NSString * _Nonnull)videoThumbnailURL:(NSString * _Nonnull)urlString;
		[Abstract]
		[Export ("videoThumbnailURL:")]
		string VideoThumbnailURL (string urlString);

		// @required -(void)searchResourceFiles:(NIMResourceQueryOption * _Nonnull)option completion:(NIMResourceSearchHandler _Nonnull)completion;
		[Abstract]
		[Export ("searchResourceFiles:completion:")]
		void SearchResourceFiles (NIMResourceQueryOption option, NIMResourceSearchHandler completion);

		// @required -(void)removeResourceFiles:(NIMResourceQueryOption * _Nonnull)option completion:(NIMResourceDeleteHandler _Nonnull)completion;
		[Abstract]
		[Export ("removeResourceFiles:completion:")]
		void RemoveResourceFiles (NIMResourceQueryOption option, NIMResourceDeleteHandler completion);

		// @required -(BOOL)enableFileQuickTransfer:(BOOL)enable;
		[Abstract]
		[Export ("enableFileQuickTransfer:")]
		bool EnableFileQuickTransfer (bool enable);
	}

	// @interface NIMRevokeMessageNotification : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMRevokeMessageNotification
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull fromUserId;
		[Export ("fromUserId")]
		string FromUserId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull messageFromUserId;
		[Export ("messageFromUserId")]
		string MessageFromUserId { get; }

		// @property (readonly, copy, nonatomic) NIMSession * _Nonnull session;
		[Export ("session", ArgumentSemantic.Copy)]
		NIMSession Session { get; }

		// @property (readonly, assign, nonatomic) NSTimeInterval timestamp;
		[Export ("timestamp")]
		double Timestamp { get; }

		// @property (readonly, nonatomic, strong) NIMMessage * _Nullable message;
		[NullAllowed, Export ("message", ArgumentSemantic.Strong)]
		NIMMessage Message { get; }
	}

	// @interface NIMRobot : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMRobot
	{
		// @property (copy, nonatomic) NSString * _Nullable userId;
		[NullAllowed, Export ("userId")]
		string UserId { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable botId;
		[NullAllowed, Export ("botId")]
		string BotId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable nickname;
		[NullAllowed, Export ("nickname")]
		string Nickname { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable intro;
		[NullAllowed, Export ("intro")]
		string Intro { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable avatarUrl;
		[NullAllowed, Export ("avatarUrl")]
		string AvatarUrl { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable thumbAvatarUrl;
		[NullAllowed, Export ("thumbAvatarUrl")]
		string ThumbAvatarUrl { get; }
	}

	// typedef void (^NIMRobotsHandler)(NSError * _Nullable, NSArray<NIMRobot *> * _Nullable);
	delegate void NIMRobotsHandler ([NullAllowed] NSError arg0, [NullAllowed] NIMRobot[] arg1);

	// @protocol NIMRobotManager <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMRobotManager
	{
		// @required -(NSArray<NIMRobot *> * _Nullable)allRobots;
		[Abstract]
		[NullAllowed, Export ("allRobots")]
		[Verify (MethodToProperty)]
		NIMRobot[] AllRobots { get; }

		// @required -(BOOL)isValidRobot:(NSString * _Nonnull)userId;
		[Abstract]
		[Export ("isValidRobot:")]
		bool IsValidRobot (string userId);

		// @required -(NIMRobot * _Nullable)robotInfo:(NSString * _Nonnull)userId;
		[Abstract]
		[Export ("robotInfo:")]
		[return: NullAllowed]
		NIMRobot RobotInfo (string userId);

		// @required -(void)fetchAllRobotsFromServer:(NIMRobotsHandler _Nullable)completion;
		[Abstract]
		[Export ("fetchAllRobotsFromServer:")]
		void FetchAllRobotsFromServer ([NullAllowed] NIMRobotsHandler completion);
	}

	// @interface NIMSDKOption : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMSDKOption
	{
		// @property (copy, nonatomic) NSString * _Nonnull appKey;
		[Export ("appKey")]
		string AppKey { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable apnsCername;
		[NullAllowed, Export ("apnsCername")]
		string ApnsCername { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable pkCername;
		[NullAllowed, Export ("pkCername")]
		string PkCername { get; set; }

		// +(instancetype _Nonnull)optionWithAppKey:(NSString * _Nonnull)appKey;
		[Static]
		[Export ("optionWithAppKey:")]
		NIMSDKOption OptionWithAppKey (string appKey);
	}

	// @protocol NIMSDKConfigDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMSDKConfigDelegate
	{
		// @optional -(BOOL)shouldIgnoreNotification:(NIMNotificationObject * _Nonnull)notification;
		[Export ("shouldIgnoreNotification:")]
		bool ShouldIgnoreNotification (NIMNotificationObject notification);
	}

	// @interface NIMSDKConfig : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMSDKConfig
	{
		// +(instancetype _Nonnull)sharedConfig;
		[Static]
		[Export ("sharedConfig")]
		NIMSDKConfig SharedConfig ();

		// @property (assign, nonatomic) BOOL fetchAttachmentAutomaticallyAfterReceiving;
		[Export ("fetchAttachmentAutomaticallyAfterReceiving")]
		bool FetchAttachmentAutomaticallyAfterReceiving { get; set; }

		// @property (assign, nonatomic) BOOL fetchAttachmentAutomaticallyAfterReceivingInChatroom;
		[Export ("fetchAttachmentAutomaticallyAfterReceivingInChatroom")]
		bool FetchAttachmentAutomaticallyAfterReceivingInChatroom { get; set; }

		// @property (assign, nonatomic) BOOL fileProtectionNone;
		[Export ("fileProtectionNone")]
		bool FileProtectionNone { get; set; }

		// @property (assign, nonatomic) BOOL shouldConsiderRevokedMessageUnreadCount;
		[Export ("shouldConsiderRevokedMessageUnreadCount")]
		bool ShouldConsiderRevokedMessageUnreadCount { get; set; }

		// @property (assign, nonatomic) BOOL shouldSyncUnreadCount;
		[Export ("shouldSyncUnreadCount")]
		bool ShouldSyncUnreadCount { get; set; }

		// @property (assign, nonatomic) BOOL shouldCountTeamNotification;
		[Export ("shouldCountTeamNotification")]
		bool ShouldCountTeamNotification { get; set; }

		// @property (assign, nonatomic) BOOL enabledHttpsForInfo;
		[Export ("enabledHttpsForInfo")]
		bool EnabledHttpsForInfo { get; set; }

		// @property (assign, nonatomic) BOOL enabledHttpsForMessage;
		[Export ("enabledHttpsForMessage")]
		bool EnabledHttpsForMessage { get; set; }

		// @property (assign, nonatomic) NSInteger maxAutoLoginRetryTimes;
		[Export ("maxAutoLoginRetryTimes")]
		nint MaxAutoLoginRetryTimes { get; set; }

		// @property (assign, nonatomic) NSInteger maximumLogDays;
		[Export ("maximumLogDays")]
		nint MaximumLogDays { get; set; }

		// @property (assign, nonatomic) BOOL animatedImageThumbnailEnabled;
		[Export ("animatedImageThumbnailEnabled")]
		bool AnimatedImageThumbnailEnabled { get; set; }

		// @property (assign, nonatomic) BOOL reconnectInBackgroundStateDisabled;
		[Export ("reconnectInBackgroundStateDisabled")]
		bool ReconnectInBackgroundStateDisabled { get; set; }

		// @property (assign, nonatomic) BOOL teamReceiptEnabled;
		[Export ("teamReceiptEnabled")]
		bool TeamReceiptEnabled { get; set; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		NIMSDKConfigDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<NIMSDKConfigDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull customTag;
		[Export ("customTag")]
		string CustomTag { get; set; }

		// -(void)setupSDKDir:(NSString * _Nonnull)sdkDir;
		[Export ("setupSDKDir:")]
		void SetupSDKDir (string sdkDir);
	}

	// @interface NIMUser : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMUser
	{
		// @property (copy, nonatomic) NSString * _Nullable userId;
		[NullAllowed, Export ("userId")]
		string UserId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable alias;
		[NullAllowed, Export ("alias")]
		string Alias { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable ext;
		[NullAllowed, Export ("ext")]
		string Ext { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable serverExt;
		[NullAllowed, Export ("serverExt")]
		string ServerExt { get; }

		// @property (readonly, nonatomic, strong) NIMUserInfo * _Nullable userInfo;
		[NullAllowed, Export ("userInfo", ArgumentSemantic.Strong)]
		NIMUserInfo UserInfo { get; }

		// -(BOOL)notifyForNewMsg;
		[Export ("notifyForNewMsg")]
		[Verify (MethodToProperty)]
		bool NotifyForNewMsg { get; }

		// -(BOOL)isInMyBlackList;
		[Export ("isInMyBlackList")]
		[Verify (MethodToProperty)]
		bool IsInMyBlackList { get; }
	}

	// @interface NIMUserInfo : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMUserInfo
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable nickName;
		[NullAllowed, Export ("nickName")]
		string NickName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable avatarUrl;
		[NullAllowed, Export ("avatarUrl")]
		string AvatarUrl { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable thumbAvatarUrl;
		[NullAllowed, Export ("thumbAvatarUrl")]
		string ThumbAvatarUrl { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable sign;
		[NullAllowed, Export ("sign")]
		string Sign { get; }

		// @property (readonly, assign, nonatomic) NIMUserGender gender;
		[Export ("gender", ArgumentSemantic.Assign)]
		NIMUserGender Gender { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable email;
		[NullAllowed, Export ("email")]
		string Email { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable birth;
		[NullAllowed, Export ("birth")]
		string Birth { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable mobile;
		[NullAllowed, Export ("mobile")]
		string Mobile { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable ext;
		[NullAllowed, Export ("ext")]
		string Ext { get; }
	}

	// @interface NIMUserRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMUserRequest
	{
		// @property (copy, nonatomic) NSString * _Nonnull userId;
		[Export ("userId")]
		string UserId { get; set; }

		// @property (assign, nonatomic) NIMUserOperation operation;
		[Export ("operation", ArgumentSemantic.Assign)]
		NIMUserOperation Operation { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable message;
		[NullAllowed, Export ("message")]
		string Message { get; set; }
	}

	// @interface NIMTeam : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMTeam
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable teamId;
		[NullAllowed, Export ("teamId")]
		string TeamId { get; }

		// @property (copy, nonatomic) NSString * _Nullable teamName;
		[NullAllowed, Export ("teamName")]
		string TeamName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable avatarUrl;
		[NullAllowed, Export ("avatarUrl")]
		string AvatarUrl { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable thumbAvatarUrl;
		[NullAllowed, Export ("thumbAvatarUrl")]
		string ThumbAvatarUrl { get; set; }

		// @property (readonly, assign, nonatomic) NIMTeamType type;
		[Export ("type", ArgumentSemantic.Assign)]
		NIMTeamType Type { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable owner;
		[NullAllowed, Export ("owner")]
		string Owner { get; }

		// @property (copy, nonatomic) NSString * _Nullable intro;
		[NullAllowed, Export ("intro")]
		string Intro { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable announcement;
		[NullAllowed, Export ("announcement")]
		string Announcement { get; set; }

		// @property (readonly, assign, nonatomic) NSInteger memberNumber;
		[Export ("memberNumber")]
		nint MemberNumber { get; }

		// @property (readonly, assign, nonatomic) NSInteger level;
		[Export ("level")]
		nint Level { get; }

		// @property (readonly, assign, nonatomic) NSTimeInterval createTime;
		[Export ("createTime")]
		double CreateTime { get; }

		// @property (assign, nonatomic) NIMTeamJoinMode joinMode;
		[Export ("joinMode", ArgumentSemantic.Assign)]
		NIMTeamJoinMode JoinMode { get; set; }

		// @property (assign, nonatomic) NIMTeamInviteMode inviteMode;
		[Export ("inviteMode", ArgumentSemantic.Assign)]
		NIMTeamInviteMode InviteMode { get; set; }

		// @property (assign, nonatomic) NIMTeamBeInviteMode beInviteMode;
		[Export ("beInviteMode", ArgumentSemantic.Assign)]
		NIMTeamBeInviteMode BeInviteMode { get; set; }

		// @property (assign, nonatomic) NIMTeamUpdateInfoMode updateInfoMode;
		[Export ("updateInfoMode", ArgumentSemantic.Assign)]
		NIMTeamUpdateInfoMode UpdateInfoMode { get; set; }

		// @property (assign, nonatomic) NIMTeamUpdateClientCustomMode updateClientCustomMode;
		[Export ("updateClientCustomMode", ArgumentSemantic.Assign)]
		NIMTeamUpdateClientCustomMode UpdateClientCustomMode { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable serverCustomInfo;
		[NullAllowed, Export ("serverCustomInfo")]
		string ServerCustomInfo { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable clientCustomInfo;
		[NullAllowed, Export ("clientCustomInfo")]
		string ClientCustomInfo { get; }

		// @property (readonly, assign, nonatomic) NIMTeamNotifyState notifyStateForNewMsg;
		[Export ("notifyStateForNewMsg", ArgumentSemantic.Assign)]
		NIMTeamNotifyState NotifyStateForNewMsg { get; }

		// -(BOOL)inAllMuteMode;
		[Export ("inAllMuteMode")]
		[Verify (MethodToProperty)]
		bool InAllMuteMode { get; }
	}

	// @interface NIMTeamMember : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMTeamMember
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable teamId;
		[NullAllowed, Export ("teamId")]
		string TeamId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable userId;
		[NullAllowed, Export ("userId")]
		string UserId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable invitor;
		[NullAllowed, Export ("invitor")]
		string Invitor { get; }

		// @property (assign, nonatomic) NIMTeamMemberType type;
		[Export ("type", ArgumentSemantic.Assign)]
		NIMTeamMemberType Type { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable nickname;
		[NullAllowed, Export ("nickname")]
		string Nickname { get; set; }

		// @property (readonly, assign, nonatomic) BOOL isMuted;
		[Export ("isMuted")]
		bool IsMuted { get; }

		// @property (readonly, assign, nonatomic) NSTimeInterval createTime;
		[Export ("createTime")]
		double CreateTime { get; }

		// @property (copy, nonatomic) NSString * _Nullable customInfo;
		[NullAllowed, Export ("customInfo")]
		string CustomInfo { get; set; }
	}

	// @interface NIMSystemNotification : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMSystemNotification
	{
		// @property (readonly, assign, nonatomic) int64_t notificationId;
		[Export ("notificationId")]
		long NotificationId { get; }

		// @property (readonly, assign, nonatomic) NIMSystemNotificationType type;
		[Export ("type", ArgumentSemantic.Assign)]
		NIMSystemNotificationType Type { get; }

		// @property (readonly, assign, nonatomic) NSTimeInterval timestamp;
		[Export ("timestamp")]
		double Timestamp { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable sourceID;
		[NullAllowed, Export ("sourceID")]
		string SourceID { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable targetID;
		[NullAllowed, Export ("targetID")]
		string TargetID { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable postscript;
		[NullAllowed, Export ("postscript")]
		string Postscript { get; }

		// @property (assign, nonatomic) BOOL read;
		[Export ("read")]
		bool Read { get; set; }

		// @property (assign, nonatomic) NSInteger handleStatus;
		[Export ("handleStatus")]
		nint HandleStatus { get; set; }

		// @property (readonly, nonatomic) NSString * _Nullable notifyExt;
		[NullAllowed, Export ("notifyExt")]
		string NotifyExt { get; }

		// @property (readonly, nonatomic, strong) id _Nullable attachment;
		[NullAllowed, Export ("attachment", ArgumentSemantic.Strong)]
		NSObject Attachment { get; }
	}

	// @interface NIMUserAddAttachment : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMUserAddAttachment
	{
		// @property (readonly, assign, nonatomic) NIMUserOperation operationType;
		[Export ("operationType", ArgumentSemantic.Assign)]
		NIMUserOperation OperationType { get; }
	}

	// @interface NIMSystemNotificationFilter : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMSystemNotificationFilter
	{
		// @property (copy, nonatomic) NSArray<NSNumber *> * _Nonnull notificationTypes;
		[Export ("notificationTypes", ArgumentSemantic.Copy)]
		NSNumber[] NotificationTypes { get; set; }
	}

	// @interface NIMCustomSystemNotification : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMCustomSystemNotification
	{
		// @property (readonly, assign, nonatomic) int64_t notificationId;
		[Export ("notificationId")]
		long NotificationId { get; }

		// @property (readonly, assign, nonatomic) NSTimeInterval timestamp;
		[Export ("timestamp")]
		double Timestamp { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable sender;
		[NullAllowed, Export ("sender")]
		string Sender { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable receiver;
		[NullAllowed, Export ("receiver")]
		string Receiver { get; }

		// @property (readonly, assign, nonatomic) NIMSessionType receiverType;
		[Export ("receiverType", ArgumentSemantic.Assign)]
		NIMSessionType ReceiverType { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable content;
		[NullAllowed, Export ("content")]
		string Content { get; }

		// @property (assign, nonatomic) BOOL sendToOnlineUsersOnly;
		[Export ("sendToOnlineUsersOnly")]
		bool SendToOnlineUsersOnly { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable apnsContent;
		[NullAllowed, Export ("apnsContent")]
		string ApnsContent { get; set; }

		// @property (copy, nonatomic) NSDictionary * _Nullable apnsPayload;
		[NullAllowed, Export ("apnsPayload", ArgumentSemantic.Copy)]
		NSDictionary ApnsPayload { get; set; }

		// @property (nonatomic, strong) NIMCustomSystemNotificationSetting * _Nullable setting;
		[NullAllowed, Export ("setting", ArgumentSemantic.Strong)]
		NIMCustomSystemNotificationSetting Setting { get; set; }

		// @property (nonatomic, strong) NIMAntiSpamOption * _Nullable antiSpamOption;
		[NullAllowed, Export ("antiSpamOption", ArgumentSemantic.Strong)]
		NIMAntiSpamOption AntiSpamOption { get; set; }

		// -(instancetype _Nonnull)initWithContent:(NSString * _Nonnull)content;
		[Export ("initWithContent:")]
		IntPtr Constructor (string content);
	}

	// @interface NIMSubscribeEvent : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMSubscribeEvent
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull eventId;
		[Export ("eventId")]
		string EventId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable from;
		[NullAllowed, Export ("from")]
		string From { get; }

		// @property (readonly, assign, nonatomic) NSTimeInterval timestamp;
		[Export ("timestamp")]
		double Timestamp { get; }

		// @property (assign, nonatomic) NSInteger type;
		[Export ("type")]
		nint Type { get; set; }

		// @property (assign, nonatomic) NSInteger value;
		[Export ("value")]
		nint Value { get; set; }

		// @property (assign, nonatomic) NSTimeInterval expiry;
		[Export ("expiry")]
		double Expiry { get; set; }

		// @property (assign, nonatomic) BOOL sendToOnlineUsersOnly;
		[Export ("sendToOnlineUsersOnly")]
		bool SendToOnlineUsersOnly { get; set; }

		// @property (assign, nonatomic) BOOL syncEnabled;
		[Export ("syncEnabled")]
		bool SyncEnabled { get; set; }

		// @property (readonly, nonatomic, strong) id _Nonnull subscribeInfo;
		[Export ("subscribeInfo", ArgumentSemantic.Strong)]
		NSObject SubscribeInfo { get; }

		// -(void)setExt:(NSString * _Nonnull)ext;
		[Export ("setExt:")]
		void SetExt (string ext);

		// -(NSString * _Nullable)ext:(NIMLoginClientType)type;
		[Export ("ext:")]
		[return: NullAllowed]
		string Ext (NIMLoginClientType type);
	}

	// @interface NIMSubscribeRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMSubscribeRequest
	{
		// @property (assign, nonatomic) NSInteger type;
		[Export ("type")]
		nint Type { get; set; }

		// @property (assign, nonatomic) NSTimeInterval expiry;
		[Export ("expiry")]
		double Expiry { get; set; }

		// @property (assign, nonatomic) BOOL syncEnabled;
		[Export ("syncEnabled")]
		bool SyncEnabled { get; set; }

		// @property (copy, nonatomic) NSArray * _Nonnull publishers;
		[Export ("publishers", ArgumentSemantic.Copy)]
		[Verify (StronglyTypedNSArray)]
		NSObject[] Publishers { get; set; }
	}

	// @interface NIMSubscribeOnlineInfo : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMSubscribeOnlineInfo
	{
		// @property (readonly, copy, nonatomic) NSArray * senderClientTypes;
		[Export ("senderClientTypes", ArgumentSemantic.Copy)]
		[Verify (StronglyTypedNSArray)]
		NSObject[] SenderClientTypes { get; }
	}

	// @interface NIMSubscribeResult : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMSubscribeResult
	{
		// @property (readonly, assign, nonatomic) NSInteger type;
		[Export ("type")]
		nint Type { get; }

		// @property (readonly, assign, nonatomic) NSTimeInterval expiry;
		[Export ("expiry")]
		double Expiry { get; }

		// @property (readonly, assign, nonatomic) NSTimeInterval timestamp;
		[Export ("timestamp")]
		double Timestamp { get; }

		// @property (readonly, copy, nonatomic) NSString * publisher;
		[Export ("publisher")]
		string Publisher { get; }
	}

	// @interface NIMSignalingMemberInfo : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMSignalingMemberInfo
	{
		// @property (copy, nonatomic) NSString * _Nonnull accountId;
		[Export ("accountId")]
		string AccountId { get; set; }

		// @property (assign, nonatomic) uint64_t uid;
		[Export ("uid")]
		ulong Uid { get; set; }

		// @property (assign, nonatomic) uint64_t createTimeStamp;
		[Export ("createTimeStamp")]
		ulong CreateTimeStamp { get; set; }

		// @property (assign, nonatomic) uint64_t expireTimeStamp;
		[Export ("expireTimeStamp")]
		ulong ExpireTimeStamp { get; set; }
	}

	// typedef void (^NIMSignalingCreateChannelBlock)(NSError * _Nullable, NIMSignalingChannelInfo * _Nullable);
	delegate void NIMSignalingCreateChannelBlock ([NullAllowed] NSError arg0, [NullAllowed] NIMSignalingChannelInfo arg1);

	// typedef void (^NIMSignalingJoinChannelBlock)(NSError * _Nullable, NIMSignalingChannelDetailedInfo * _Nullable);
	delegate void NIMSignalingJoinChannelBlock ([NullAllowed] NSError arg0, [NullAllowed] NIMSignalingChannelDetailedInfo arg1);

	// typedef void (^NIMSignalingCallBlock)(NSError * _Nullable, NIMSignalingChannelDetailedInfo * _Nullable);
	delegate void NIMSignalingCallBlock ([NullAllowed] NSError arg0, [NullAllowed] NIMSignalingChannelDetailedInfo arg1);

	// typedef void (^NIMSignalingAcceptBlock)(NSError * _Nullable, NIMSignalingChannelDetailedInfo * _Nullable);
	delegate void NIMSignalingAcceptBlock ([NullAllowed] NSError arg0, [NullAllowed] NIMSignalingChannelDetailedInfo arg1);

	// typedef void (^NIMSignalingOperationBlock)(NSError * _Nullable);
	delegate void NIMSignalingOperationBlock ([NullAllowed] NSError arg0);

	// @protocol NIMSignalManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMSignalManagerDelegate
	{
		// @optional -(void)nimSignalingOnlineNotifyEventType:(NIMSignalingEventType)eventType response:(NIMSignalingNotifyInfo * _Nonnull)notifyResponse;
		[Export ("nimSignalingOnlineNotifyEventType:response:")]
		void NimSignalingOnlineNotifyEventType (NIMSignalingEventType eventType, NIMSignalingNotifyInfo notifyResponse);

		// @optional -(void)nimSignalingMultiClientSyncNotifyEventType:(NIMSignalingEventType)eventType response:(NIMSignalingNotifyInfo * _Nonnull)notifyResponse;
		[Export ("nimSignalingMultiClientSyncNotifyEventType:response:")]
		void NimSignalingMultiClientSyncNotifyEventType (NIMSignalingEventType eventType, NIMSignalingNotifyInfo notifyResponse);

		// @optional -(void)nimSignalingOfflineNotify:(NSArray<NIMSignalingNotifyInfo *> * _Nonnull)notifyResponse;
		[Export ("nimSignalingOfflineNotify:")]
		void NimSignalingOfflineNotify (NIMSignalingNotifyInfo[] notifyResponse);

		// @optional -(void)nimSignalingChannelsSyncNotify:(NSArray<NIMSignalingChannelDetailedInfo *> * _Nonnull)notifyResponse;
		[Export ("nimSignalingChannelsSyncNotify:")]
		void NimSignalingChannelsSyncNotify (NIMSignalingChannelDetailedInfo[] notifyResponse);

		// @optional -(void)nimSignalingMembersSyncNotify:(NIMSignalingChannelDetailedInfo * _Nonnull)notifyResponse;
		[Export ("nimSignalingMembersSyncNotify:")]
		void NimSignalingMembersSyncNotify (NIMSignalingChannelDetailedInfo notifyResponse);
	}

	// @protocol NIMSignalManager <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMSignalManager
	{
		// @required -(void)signalingCreateChannel:(NIMSignalingCreateChannelRequest * _Nonnull)request completion:(NIMSignalingCreateChannelBlock _Nullable)completion;
		[Abstract]
		[Export ("signalingCreateChannel:completion:")]
		void SignalingCreateChannel (NIMSignalingCreateChannelRequest request, [NullAllowed] NIMSignalingCreateChannelBlock completion);

		// @required -(void)signalingCloseChannel:(NIMSignalingCloseChannelRequest * _Nonnull)request completion:(NIMSignalingOperationBlock _Nullable)completion;
		[Abstract]
		[Export ("signalingCloseChannel:completion:")]
		void SignalingCloseChannel (NIMSignalingCloseChannelRequest request, [NullAllowed] NIMSignalingOperationBlock completion);

		// @required -(void)signalingJoinChannel:(NIMSignalingJoinChannelRequest * _Nonnull)request completion:(NIMSignalingJoinChannelBlock _Nullable)completion;
		[Abstract]
		[Export ("signalingJoinChannel:completion:")]
		void SignalingJoinChannel (NIMSignalingJoinChannelRequest request, [NullAllowed] NIMSignalingJoinChannelBlock completion);

		// @required -(void)signalingLeaveChannel:(NIMSignalingLeaveChannelRequest * _Nonnull)request completion:(NIMSignalingOperationBlock _Nullable)completion;
		[Abstract]
		[Export ("signalingLeaveChannel:completion:")]
		void SignalingLeaveChannel (NIMSignalingLeaveChannelRequest request, [NullAllowed] NIMSignalingOperationBlock completion);

		// @required -(void)signalingInvite:(NIMSignalingInviteRequest * _Nonnull)request completion:(NIMSignalingOperationBlock _Nullable)completion;
		[Abstract]
		[Export ("signalingInvite:completion:")]
		void SignalingInvite (NIMSignalingInviteRequest request, [NullAllowed] NIMSignalingOperationBlock completion);

		// @required -(void)signalingCancelInvite:(NIMSignalingCancelInviteRequest * _Nonnull)request completion:(NIMSignalingOperationBlock _Nullable)completion;
		[Abstract]
		[Export ("signalingCancelInvite:completion:")]
		void SignalingCancelInvite (NIMSignalingCancelInviteRequest request, [NullAllowed] NIMSignalingOperationBlock completion);

		// @required -(void)signalingReject:(NIMSignalingRejectRequest * _Nonnull)request completion:(NIMSignalingOperationBlock _Nullable)completion;
		[Abstract]
		[Export ("signalingReject:completion:")]
		void SignalingReject (NIMSignalingRejectRequest request, [NullAllowed] NIMSignalingOperationBlock completion);

		// @required -(void)signalingAccept:(NIMSignalingAcceptRequest * _Nonnull)request completion:(NIMSignalingAcceptBlock _Nullable)completion;
		[Abstract]
		[Export ("signalingAccept:completion:")]
		void SignalingAccept (NIMSignalingAcceptRequest request, [NullAllowed] NIMSignalingAcceptBlock completion);

		// @required -(void)signalingControl:(NIMSignalingControlRequest * _Nonnull)request completion:(NIMSignalingOperationBlock _Nullable)completion;
		[Abstract]
		[Export ("signalingControl:completion:")]
		void SignalingControl (NIMSignalingControlRequest request, [NullAllowed] NIMSignalingOperationBlock completion);

		// @required -(void)signalingCall:(NIMSignalingCallRequest * _Nonnull)request completion:(NIMSignalingCallBlock _Nullable)completion;
		[Abstract]
		[Export ("signalingCall:completion:")]
		void SignalingCall (NIMSignalingCallRequest request, [NullAllowed] NIMSignalingCallBlock completion);

		// @required -(void)addDelegate:(id<NIMSignalManagerDelegate> _Nonnull)delegate;
		[Abstract]
		[Export ("addDelegate:")]
		void AddDelegate (NIMSignalManagerDelegate @delegate);

		// @required -(void)removeDelegate:(id<NIMSignalManagerDelegate> _Nonnull)delegate;
		[Abstract]
		[Export ("removeDelegate:")]
		void RemoveDelegate (NIMSignalManagerDelegate @delegate);
	}

	// @interface NIMSignalingCreateChannelRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMSignalingCreateChannelRequest
	{
		// @property (copy, nonatomic) NSString * _Nullable channelName;
		[NullAllowed, Export ("channelName")]
		string ChannelName { get; set; }

		// @property (assign, nonatomic) NIMSignalingChannelType channelType;
		[Export ("channelType", ArgumentSemantic.Assign)]
		NIMSignalingChannelType ChannelType { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable channelExt;
		[NullAllowed, Export ("channelExt")]
		string ChannelExt { get; set; }
	}

	// @interface NIMSignalingDelayChannelRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMSignalingDelayChannelRequest
	{
		// @property (copy, nonatomic) NSString * _Nonnull channelId;
		[Export ("channelId")]
		string ChannelId { get; set; }
	}

	// @interface NIMSignalingCloseChannelRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMSignalingCloseChannelRequest
	{
		// @property (copy, nonatomic) NSString * _Nonnull channelId;
		[Export ("channelId")]
		string ChannelId { get; set; }

		// @property (assign, nonatomic) BOOL offlineEnabled;
		[Export ("offlineEnabled")]
		bool OfflineEnabled { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable customInfo;
		[NullAllowed, Export ("customInfo")]
		string CustomInfo { get; set; }
	}

	// @interface NIMSignalingJoinChannelRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMSignalingJoinChannelRequest
	{
		// @property (copy, nonatomic) NSString * _Nonnull channelId;
		[Export ("channelId")]
		string ChannelId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable customInfo;
		[NullAllowed, Export ("customInfo")]
		string CustomInfo { get; set; }

		// @property (assign, nonatomic) uint64_t uid;
		[Export ("uid")]
		ulong Uid { get; set; }

		// @property (assign, nonatomic) BOOL offlineEnabled;
		[Export ("offlineEnabled")]
		bool OfflineEnabled { get; set; }
	}

	// @interface NIMSignalingLeaveChannelRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMSignalingLeaveChannelRequest
	{
		// @property (copy, nonatomic) NSString * _Nonnull channelId;
		[Export ("channelId")]
		string ChannelId { get; set; }

		// @property (assign, nonatomic) BOOL offlineEnabled;
		[Export ("offlineEnabled")]
		bool OfflineEnabled { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable customInfo;
		[NullAllowed, Export ("customInfo")]
		string CustomInfo { get; set; }
	}

	// @interface NIMSignalingInviteRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMSignalingInviteRequest
	{
		// @property (copy, nonatomic) NSString * _Nonnull channelId;
		[Export ("channelId")]
		string ChannelId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull accountId;
		[Export ("accountId")]
		string AccountId { get; set; }

		// @property (assign, nonatomic) BOOL offlineEnabled;
		[Export ("offlineEnabled")]
		bool OfflineEnabled { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull requestId;
		[Export ("requestId")]
		string RequestId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable customInfo;
		[NullAllowed, Export ("customInfo")]
		string CustomInfo { get; set; }

		// @property (nonatomic, strong) NIMSignalingPushInfo * _Nonnull push;
		[Export ("push", ArgumentSemantic.Strong)]
		NIMSignalingPushInfo Push { get; set; }
	}

	// @interface NIMSignalingCancelInviteRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMSignalingCancelInviteRequest
	{
		// @property (copy, nonatomic) NSString * _Nonnull channelId;
		[Export ("channelId")]
		string ChannelId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull accountId;
		[Export ("accountId")]
		string AccountId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull requestId;
		[Export ("requestId")]
		string RequestId { get; set; }

		// @property (assign, nonatomic) BOOL offlineEnabled;
		[Export ("offlineEnabled")]
		bool OfflineEnabled { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable customInfo;
		[NullAllowed, Export ("customInfo")]
		string CustomInfo { get; set; }
	}

	// @interface NIMSignalingRejectRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMSignalingRejectRequest
	{
		// @property (copy, nonatomic) NSString * _Nonnull channelId;
		[Export ("channelId")]
		string ChannelId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull accountId;
		[Export ("accountId")]
		string AccountId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull requestId;
		[Export ("requestId")]
		string RequestId { get; set; }

		// @property (assign, nonatomic) BOOL offlineEnabled;
		[Export ("offlineEnabled")]
		bool OfflineEnabled { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable customInfo;
		[NullAllowed, Export ("customInfo")]
		string CustomInfo { get; set; }
	}

	// @interface NIMSignalingAcceptRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMSignalingAcceptRequest
	{
		// @property (copy, nonatomic) NSString * _Nonnull channelId;
		[Export ("channelId")]
		string ChannelId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull accountId;
		[Export ("accountId")]
		string AccountId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull requestId;
		[Export ("requestId")]
		string RequestId { get; set; }

		// @property (assign, nonatomic) BOOL offlineEnabled;
		[Export ("offlineEnabled")]
		bool OfflineEnabled { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable acceptCustomInfo;
		[NullAllowed, Export ("acceptCustomInfo")]
		string AcceptCustomInfo { get; set; }

		// @property (assign, nonatomic) BOOL autoJoin;
		[Export ("autoJoin")]
		bool AutoJoin { get; set; }

		// @property (assign, nonatomic) uint64_t uid;
		[Export ("uid")]
		ulong Uid { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable joinCustomInfo;
		[NullAllowed, Export ("joinCustomInfo")]
		string JoinCustomInfo { get; set; }
	}

	// @interface NIMSignalingControlRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMSignalingControlRequest
	{
		// @property (copy, nonatomic) NSString * _Nonnull channelId;
		[Export ("channelId")]
		string ChannelId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable accountId;
		[NullAllowed, Export ("accountId")]
		string AccountId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable customInfo;
		[NullAllowed, Export ("customInfo")]
		string CustomInfo { get; set; }
	}

	// @interface NIMSignalingCallRequest : NIMSignalingCreateChannelRequest
	[BaseType (typeof(NIMSignalingCreateChannelRequest))]
	interface NIMSignalingCallRequest
	{
		// @property (assign, nonatomic) uint64_t uid;
		[Export ("uid")]
		ulong Uid { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull accountId;
		[Export ("accountId")]
		string AccountId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull requestId;
		[Export ("requestId")]
		string RequestId { get; set; }

		// @property (assign, nonatomic) BOOL offlineEnabled;
		[Export ("offlineEnabled")]
		bool OfflineEnabled { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable customInfo;
		[NullAllowed, Export ("customInfo")]
		string CustomInfo { get; set; }

		// @property (nonatomic, strong) NIMSignalingPushInfo * _Nullable push;
		[NullAllowed, Export ("push", ArgumentSemantic.Strong)]
		NIMSignalingPushInfo Push { get; set; }
	}

	// @interface NIMSignalingChannelInfo : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMSignalingChannelInfo
	{
		// @property (assign, nonatomic) NIMSignalingChannelType channelType;
		[Export ("channelType", ArgumentSemantic.Assign)]
		NIMSignalingChannelType ChannelType { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull channelName;
		[Export ("channelName")]
		string ChannelName { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull channelId;
		[Export ("channelId")]
		string ChannelId { get; set; }

		// @property (assign, nonatomic) uint64_t createTimeStamp;
		[Export ("createTimeStamp")]
		ulong CreateTimeStamp { get; set; }

		// @property (assign, nonatomic) uint64_t expireTimeStamp;
		[Export ("expireTimeStamp")]
		ulong ExpireTimeStamp { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull creatorId;
		[Export ("creatorId")]
		string CreatorId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull channelExt;
		[Export ("channelExt")]
		string ChannelExt { get; set; }

		// @property (assign, nonatomic) BOOL invalid;
		[Export ("invalid")]
		bool Invalid { get; set; }
	}

	// @interface NIMSignalingChannelDetailedInfo : NIMSignalingChannelInfo
	[BaseType (typeof(NIMSignalingChannelInfo))]
	interface NIMSignalingChannelDetailedInfo
	{
		// @property (nonatomic, strong) NSArray<NIMSignalingMemberInfo *> * _Nonnull members;
		[Export ("members", ArgumentSemantic.Strong)]
		NIMSignalingMemberInfo[] Members { get; set; }
	}

	// @interface NIMSignalingPushInfo : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMSignalingPushInfo
	{
		// @property (assign, nonatomic) BOOL needPush;
		[Export ("needPush")]
		bool NeedPush { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull pushTitle;
		[Export ("pushTitle")]
		string PushTitle { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull pushContent;
		[Export ("pushContent")]
		string PushContent { get; set; }

		// @property (nonatomic, strong) NSDictionary * _Nonnull pushPayload;
		[Export ("pushPayload", ArgumentSemantic.Strong)]
		NSDictionary PushPayload { get; set; }

		// @property (assign, nonatomic) BOOL needBadge;
		[Export ("needBadge")]
		bool NeedBadge { get; set; }
	}

	// @interface NIMSignalingNotifyInfo : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMSignalingNotifyInfo
	{
		// @property (assign, nonatomic) NIMSignalingEventType eventType;
		[Export ("eventType", ArgumentSemantic.Assign)]
		NIMSignalingEventType EventType { get; set; }

		// @property (nonatomic, strong) NIMSignalingChannelInfo * _Nonnull channelInfo;
		[Export ("channelInfo", ArgumentSemantic.Strong)]
		NIMSignalingChannelInfo ChannelInfo { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull fromAccountId;
		[Export ("fromAccountId")]
		string FromAccountId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull customInfo;
		[Export ("customInfo")]
		string CustomInfo { get; set; }

		// @property (assign, nonatomic) int64_t time;
		[Export ("time")]
		long Time { get; set; }
	}

	// @interface NIMSignalingCloseNotifyInfo : NIMSignalingNotifyInfo
	[BaseType (typeof(NIMSignalingNotifyInfo))]
	interface NIMSignalingCloseNotifyInfo
	{
	}

	// @interface NIMSignalingJoinNotifyInfo : NIMSignalingNotifyInfo
	[BaseType (typeof(NIMSignalingNotifyInfo))]
	interface NIMSignalingJoinNotifyInfo
	{
		// @property (nonatomic, strong) NIMSignalingMemberInfo * _Nonnull member;
		[Export ("member", ArgumentSemantic.Strong)]
		NIMSignalingMemberInfo Member { get; set; }
	}

	// @interface NIMSignalingLeaveNotifyInfo : NIMSignalingNotifyInfo
	[BaseType (typeof(NIMSignalingNotifyInfo))]
	interface NIMSignalingLeaveNotifyInfo
	{
	}

	// @interface NIMSignalingInviteNotifyInfo : NIMSignalingNotifyInfo
	[BaseType (typeof(NIMSignalingNotifyInfo))]
	interface NIMSignalingInviteNotifyInfo
	{
		// @property (copy, nonatomic) NSString * _Nonnull toAccountId;
		[Export ("toAccountId")]
		string ToAccountId { get; set; }

		// @property (nonatomic, strong) NIMSignalingPushInfo * _Nonnull push;
		[Export ("push", ArgumentSemantic.Strong)]
		NIMSignalingPushInfo Push { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull requestId;
		[Export ("requestId")]
		string RequestId { get; set; }
	}

	// @interface NIMSignalingCancelInviteNotifyInfo : NIMSignalingNotifyInfo
	[BaseType (typeof(NIMSignalingNotifyInfo))]
	interface NIMSignalingCancelInviteNotifyInfo
	{
		// @property (copy, nonatomic) NSString * _Nonnull toAccountId;
		[Export ("toAccountId")]
		string ToAccountId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull requestId;
		[Export ("requestId")]
		string RequestId { get; set; }
	}

	// @interface NIMSignalingRejectNotifyInfo : NIMSignalingNotifyInfo
	[BaseType (typeof(NIMSignalingNotifyInfo))]
	interface NIMSignalingRejectNotifyInfo
	{
		// @property (copy, nonatomic) NSString * _Nonnull toAccountId;
		[Export ("toAccountId")]
		string ToAccountId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull requestId;
		[Export ("requestId")]
		string RequestId { get; set; }
	}

	// @interface NIMSignalingAcceptNotifyInfo : NIMSignalingNotifyInfo
	[BaseType (typeof(NIMSignalingNotifyInfo))]
	interface NIMSignalingAcceptNotifyInfo
	{
		// @property (copy, nonatomic) NSString * _Nonnull toAccountId;
		[Export ("toAccountId")]
		string ToAccountId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull requestId;
		[Export ("requestId")]
		string RequestId { get; set; }
	}

	// @interface NIMSignalingControlNotifyInfo : NIMSignalingNotifyInfo
	[BaseType (typeof(NIMSignalingNotifyInfo))]
	interface NIMSignalingControlNotifyInfo
	{
	}

	// typedef void (^NIMUserBlock)(NSError * _Nullable);
	delegate void NIMUserBlock ([NullAllowed] NSError arg0);

	// typedef void (^NIMUserInfoBlock)(NSArray<NIMUser *> * _Nullable, NSError * _Nullable);
	delegate void NIMUserInfoBlock ([NullAllowed] NIMUser[] arg0, [NullAllowed] NSError arg1);

	// @protocol NIMUserManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMUserManagerDelegate
	{
		// @optional -(void)onFriendChanged:(NIMUser * _Nonnull)user;
		[Export ("onFriendChanged:")]
		void OnFriendChanged (NIMUser user);

		// @optional -(void)onBlackListChanged;
		[Export ("onBlackListChanged")]
		void OnBlackListChanged ();

		// @optional -(void)onMuteListChanged;
		[Export ("onMuteListChanged")]
		void OnMuteListChanged ();

		// @optional -(void)onUserInfoChanged:(NIMUser * _Nonnull)user;
		[Export ("onUserInfoChanged:")]
		void OnUserInfoChanged (NIMUser user);
	}

	// @protocol NIMUserManager <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMUserManager
	{
		// @required -(void)requestFriend:(NIMUserRequest * _Nonnull)request completion:(NIMUserBlock _Nullable)completion;
		[Abstract]
		[Export ("requestFriend:completion:")]
		void RequestFriend (NIMUserRequest request, [NullAllowed] NIMUserBlock completion);

		// @required -(void)deleteFriend:(NSString * _Nonnull)userId completion:(NIMUserBlock _Nullable)completion;
		[Abstract]
		[Export ("deleteFriend:completion:")]
		void DeleteFriend (string userId, [NullAllowed] NIMUserBlock completion);

		// @required -(NSArray<NIMUser *> * _Nullable)myFriends;
		[Abstract]
		[NullAllowed, Export ("myFriends")]
		[Verify (MethodToProperty)]
		NIMUser[] MyFriends { get; }

		// @required -(BOOL)isMyFriend:(NSString * _Nonnull)userId;
		[Abstract]
		[Export ("isMyFriend:")]
		bool IsMyFriend (string userId);

		// @required -(void)addToBlackList:(NSString * _Nonnull)userId completion:(NIMUserBlock _Nonnull)completion;
		[Abstract]
		[Export ("addToBlackList:completion:")]
		void AddToBlackList (string userId, NIMUserBlock completion);

		// @required -(void)removeFromBlackBlackList:(NSString * _Nonnull)userId completion:(NIMUserBlock _Nonnull)completion;
		[Abstract]
		[Export ("removeFromBlackBlackList:completion:")]
		void RemoveFromBlackBlackList (string userId, NIMUserBlock completion);

		// @required -(BOOL)isUserInBlackList:(NSString * _Nonnull)userId;
		[Abstract]
		[Export ("isUserInBlackList:")]
		bool IsUserInBlackList (string userId);

		// @required -(NSArray<NIMUser *> * _Nullable)myBlackList;
		[Abstract]
		[NullAllowed, Export ("myBlackList")]
		[Verify (MethodToProperty)]
		NIMUser[] MyBlackList { get; }

		// @required -(void)updateNotifyState:(BOOL)notify forUser:(NSString * _Nonnull)userId completion:(NIMUserBlock _Nullable)completion;
		[Abstract]
		[Export ("updateNotifyState:forUser:completion:")]
		void UpdateNotifyState (bool notify, string userId, [NullAllowed] NIMUserBlock completion);

		// @required -(BOOL)notifyForNewMsg:(NSString * _Nonnull)userId;
		[Abstract]
		[Export ("notifyForNewMsg:")]
		bool NotifyForNewMsg (string userId);

		// @required -(NSArray<NIMUser *> * _Nullable)myMuteUserList;
		[Abstract]
		[NullAllowed, Export ("myMuteUserList")]
		[Verify (MethodToProperty)]
		NIMUser[] MyMuteUserList { get; }

		// @required -(void)fetchUserInfos:(NSArray<NSString *> * _Nonnull)users completion:(NIMUserInfoBlock _Nullable)completion;
		[Abstract]
		[Export ("fetchUserInfos:completion:")]
		void FetchUserInfos (string[] users, [NullAllowed] NIMUserInfoBlock completion);

		// @required -(NIMUser * _Nullable)userInfo:(NSString * _Nonnull)userId;
		[Abstract]
		[Export ("userInfo:")]
		[return: NullAllowed]
		NIMUser UserInfo (string userId);

		// @required -(void)updateUser:(NIMUser * _Nonnull)user completion:(NIMUserBlock _Nullable)completion;
		[Abstract]
		[Export ("updateUser:completion:")]
		void UpdateUser (NIMUser user, [NullAllowed] NIMUserBlock completion);

		// @required -(void)updateMyUserInfo:(NSDictionary<NSNumber *,id> * _Nonnull)values completion:(NIMUserBlock _Nullable)completion;
		[Abstract]
		[Export ("updateMyUserInfo:completion:")]
		void UpdateMyUserInfo (NSDictionary<NSNumber, NSObject> values, [NullAllowed] NIMUserBlock completion);

		// @required -(void)addDelegate:(id<NIMUserManagerDelegate> _Nonnull)delegate;
		[Abstract]
		[Export ("addDelegate:")]
		void AddDelegate (NIMUserManagerDelegate @delegate);

		// @required -(void)removeDelegate:(id<NIMUserManagerDelegate> _Nonnull)delegate;
		[Abstract]
		[Export ("removeDelegate:")]
		void RemoveDelegate (NIMUserManagerDelegate @delegate);
	}

	// typedef void (^NIMTeamHandler)(NSError * _Nullable);
	delegate void NIMTeamHandler ([NullAllowed] NSError arg0);

	// typedef void (^NIMTeamCreateHandler)(NSError * _Nullable, NSString * _Nullable, NSArray<NSString *> * _Nullable);
	delegate void NIMTeamCreateHandler ([NullAllowed] NSError arg0, [NullAllowed] string arg1, [NullAllowed] string[] arg2);

	// typedef void (^NIMTeamMemberHandler)(NSError * _Nullable, NSArray<NIMTeamMember *> * _Nullable);
	delegate void NIMTeamMemberHandler ([NullAllowed] NSError arg0, [NullAllowed] NIMTeamMember[] arg1);

	// typedef void (^NIMTeamFetchInfoHandler)(NSError * _Nullable, NIMTeam * _Nullable);
	delegate void NIMTeamFetchInfoHandler ([NullAllowed] NSError arg0, [NullAllowed] NIMTeam arg1);

	// typedef void (^NIMTeamApplyHandler)(NSError * _Nullable, NIMTeamApplyStatus);
	delegate void NIMTeamApplyHandler ([NullAllowed] NSError arg0, NIMTeamApplyStatus arg1);

	// @protocol NIMTeamManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMTeamManagerDelegate
	{
		// @optional -(void)onTeamAdded:(NIMTeam * _Nonnull)team;
		[Export ("onTeamAdded:")]
		void OnTeamAdded (NIMTeam team);

		// @optional -(void)onTeamUpdated:(NIMTeam * _Nonnull)team;
		[Export ("onTeamUpdated:")]
		void OnTeamUpdated (NIMTeam team);

		// @optional -(void)onTeamRemoved:(NIMTeam * _Nonnull)team;
		[Export ("onTeamRemoved:")]
		void OnTeamRemoved (NIMTeam team);

		// @optional -(void)onTeamMemberChanged:(NIMTeam * _Nonnull)team;
		[Export ("onTeamMemberChanged:")]
		void OnTeamMemberChanged (NIMTeam team);
	}

	// @protocol NIMTeamManager <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMTeamManager
	{
		// @required -(NSArray<NIMTeam *> * _Nullable)allMyTeams;
		[Abstract]
		[NullAllowed, Export ("allMyTeams")]
		[Verify (MethodToProperty)]
		NIMTeam[] AllMyTeams { get; }

		// @required -(NIMTeam * _Nullable)teamById:(NSString * _Nonnull)teamId;
		[Abstract]
		[Export ("teamById:")]
		[return: NullAllowed]
		NIMTeam TeamById (string teamId);

		// @required -(BOOL)isMyTeam:(NSString * _Nonnull)teamId;
		[Abstract]
		[Export ("isMyTeam:")]
		bool IsMyTeam (string teamId);

		// @required -(void)createTeam:(NIMCreateTeamOption * _Nonnull)option users:(NSArray<NSString *> * _Nonnull)users completion:(NIMTeamCreateHandler _Nullable)completion;
		[Abstract]
		[Export ("createTeam:users:completion:")]
		void CreateTeam (NIMCreateTeamOption option, string[] users, [NullAllowed] NIMTeamCreateHandler completion);

		// @required -(void)dismissTeam:(NSString * _Nonnull)teamId completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("dismissTeam:completion:")]
		void DismissTeam (string teamId, [NullAllowed] NIMTeamHandler completion);

		// @required -(void)quitTeam:(NSString * _Nonnull)teamId completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("quitTeam:completion:")]
		void QuitTeam (string teamId, [NullAllowed] NIMTeamHandler completion);

		// @required -(void)addUsers:(NSArray<NSString *> * _Nonnull)users toTeam:(NSString * _Nonnull)teamId postscript:(NSString * _Nonnull)postscript completion:(NIMTeamMemberHandler _Nullable)completion;
		[Abstract]
		[Export ("addUsers:toTeam:postscript:completion:")]
		void AddUsers (string[] users, string teamId, string postscript, [NullAllowed] NIMTeamMemberHandler completion);

		// @required -(void)kickUsers:(NSArray<NSString *> * _Nonnull)users fromTeam:(NSString * _Nonnull)teamId completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("kickUsers:fromTeam:completion:")]
		void KickUsers (string[] users, string teamId, [NullAllowed] NIMTeamHandler completion);

		// @required -(void)updateTeamName:(NSString * _Nonnull)teamName teamId:(NSString * _Nonnull)teamId completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("updateTeamName:teamId:completion:")]
		void UpdateTeamName (string teamName, string teamId, [NullAllowed] NIMTeamHandler completion);

		// @required -(void)updateTeamAvatar:(NSString * _Nonnull)teamAvatarUrl teamId:(NSString * _Nonnull)teamId completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("updateTeamAvatar:teamId:completion:")]
		void UpdateTeamAvatar (string teamAvatarUrl, string teamId, [NullAllowed] NIMTeamHandler completion);

		// @required -(void)updateTeamJoinMode:(NIMTeamJoinMode)joinMode teamId:(NSString * _Nonnull)teamId completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("updateTeamJoinMode:teamId:completion:")]
		void UpdateTeamJoinMode (NIMTeamJoinMode joinMode, string teamId, [NullAllowed] NIMTeamHandler completion);

		// @required -(void)updateTeamInviteMode:(NIMTeamInviteMode)inviteMode teamId:(NSString * _Nonnull)teamId completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("updateTeamInviteMode:teamId:completion:")]
		void UpdateTeamInviteMode (NIMTeamInviteMode inviteMode, string teamId, [NullAllowed] NIMTeamHandler completion);

		// @required -(void)updateTeamBeInviteMode:(NIMTeamBeInviteMode)beInviteMode teamId:(NSString * _Nonnull)teamId completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("updateTeamBeInviteMode:teamId:completion:")]
		void UpdateTeamBeInviteMode (NIMTeamBeInviteMode beInviteMode, string teamId, [NullAllowed] NIMTeamHandler completion);

		// @required -(void)updateTeamUpdateInfoMode:(NIMTeamUpdateInfoMode)updateInfoMode teamId:(NSString * _Nonnull)teamId completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("updateTeamUpdateInfoMode:teamId:completion:")]
		void UpdateTeamUpdateInfoMode (NIMTeamUpdateInfoMode updateInfoMode, string teamId, [NullAllowed] NIMTeamHandler completion);

		// @required -(void)updateTeamUpdateClientCustomMode:(NIMTeamUpdateClientCustomMode)clientCustomMode teamId:(NSString * _Nonnull)teamId completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("updateTeamUpdateClientCustomMode:teamId:completion:")]
		void UpdateTeamUpdateClientCustomMode (NIMTeamUpdateClientCustomMode clientCustomMode, string teamId, [NullAllowed] NIMTeamHandler completion);

		// @required -(void)updateTeamIntro:(NSString * _Nonnull)intro teamId:(NSString * _Nonnull)teamId completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("updateTeamIntro:teamId:completion:")]
		void UpdateTeamIntro (string intro, string teamId, [NullAllowed] NIMTeamHandler completion);

		// @required -(void)updateTeamAnnouncement:(NSString * _Nonnull)announcement teamId:(NSString * _Nonnull)teamId completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("updateTeamAnnouncement:teamId:completion:")]
		void UpdateTeamAnnouncement (string announcement, string teamId, [NullAllowed] NIMTeamHandler completion);

		// @required -(void)updateTeamCustomInfo:(NSString * _Nonnull)info teamId:(NSString * _Nonnull)teamId completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("updateTeamCustomInfo:teamId:completion:")]
		void UpdateTeamCustomInfo (string info, string teamId, [NullAllowed] NIMTeamHandler completion);

		// @required -(void)updateTeamInfos:(NSDictionary<NSNumber *,NSString *> * _Nonnull)values teamId:(NSString * _Nonnull)teamId completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("updateTeamInfos:teamId:completion:")]
		void UpdateTeamInfos (NSDictionary<NSNumber, NSString> values, string teamId, [NullAllowed] NIMTeamHandler completion);

		// @required -(void)applyToTeam:(NSString * _Nonnull)teamId message:(NSString * _Nonnull)message completion:(NIMTeamApplyHandler _Nullable)completion;
		[Abstract]
		[Export ("applyToTeam:message:completion:")]
		void ApplyToTeam (string teamId, string message, [NullAllowed] NIMTeamApplyHandler completion);

		// @required -(void)passApplyToTeam:(NSString * _Nonnull)teamId userId:(NSString * _Nonnull)userId completion:(NIMTeamApplyHandler _Nullable)completion;
		[Abstract]
		[Export ("passApplyToTeam:userId:completion:")]
		void PassApplyToTeam (string teamId, string userId, [NullAllowed] NIMTeamApplyHandler completion);

		// @required -(void)rejectApplyToTeam:(NSString * _Nonnull)teamId userId:(NSString * _Nonnull)userId rejectReason:(NSString * _Nonnull)rejectReason completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("rejectApplyToTeam:userId:rejectReason:completion:")]
		void RejectApplyToTeam (string teamId, string userId, string rejectReason, [NullAllowed] NIMTeamHandler completion);

		// @required -(void)updateUserNick:(NSString * _Nonnull)userId newNick:(NSString * _Nonnull)newNick inTeam:(NSString * _Nonnull)teamId completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("updateUserNick:newNick:inTeam:completion:")]
		void UpdateUserNick (string userId, string newNick, string teamId, [NullAllowed] NIMTeamHandler completion);

		// @required -(void)updateMyCustomInfo:(NSString * _Nonnull)newInfo inTeam:(NSString * _Nonnull)teamId completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("updateMyCustomInfo:inTeam:completion:")]
		void UpdateMyCustomInfo (string newInfo, string teamId, [NullAllowed] NIMTeamHandler completion);

		// @required -(void)addManagersToTeam:(NSString * _Nonnull)teamId users:(NSArray<NSString *> * _Nonnull)users completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("addManagersToTeam:users:completion:")]
		void AddManagersToTeam (string teamId, string[] users, [NullAllowed] NIMTeamHandler completion);

		// @required -(void)removeManagersFromTeam:(NSString * _Nonnull)teamId users:(NSArray<NSString *> * _Nonnull)users completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("removeManagersFromTeam:users:completion:")]
		void RemoveManagersFromTeam (string teamId, string[] users, [NullAllowed] NIMTeamHandler completion);

		// @required -(void)transferManagerWithTeam:(NSString * _Nonnull)teamId newOwnerId:(NSString * _Nonnull)newOwnerId isLeave:(BOOL)isLeave completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("transferManagerWithTeam:newOwnerId:isLeave:completion:")]
		void TransferManagerWithTeam (string teamId, string newOwnerId, bool isLeave, [NullAllowed] NIMTeamHandler completion);

		// @required -(void)acceptInviteWithTeam:(NSString * _Nonnull)teamId invitorId:(NSString * _Nonnull)invitorId completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("acceptInviteWithTeam:invitorId:completion:")]
		void AcceptInviteWithTeam (string teamId, string invitorId, [NullAllowed] NIMTeamHandler completion);

		// @required -(void)rejectInviteWithTeam:(NSString * _Nonnull)teamId invitorId:(NSString * _Nonnull)invitorId rejectReason:(NSString * _Nonnull)rejectReason completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("rejectInviteWithTeam:invitorId:rejectReason:completion:")]
		void RejectInviteWithTeam (string teamId, string invitorId, string rejectReason, [NullAllowed] NIMTeamHandler completion);

		// @required -(void)updateNotifyState:(NIMTeamNotifyState)state inTeam:(NSString * _Nonnull)teamId completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("updateNotifyState:inTeam:completion:")]
		void UpdateNotifyState (NIMTeamNotifyState state, string teamId, [NullAllowed] NIMTeamHandler completion);

		// @required -(NIMTeamNotifyState)notifyStateForNewMsg:(NSString * _Nonnull)teamId;
		[Abstract]
		[Export ("notifyStateForNewMsg:")]
		NIMTeamNotifyState NotifyStateForNewMsg (string teamId);

		// @required -(void)updateMuteState:(BOOL)mute userId:(NSString * _Nonnull)userId inTeam:(NSString * _Nonnull)teamId completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("updateMuteState:userId:inTeam:completion:")]
		void UpdateMuteState (bool mute, string userId, string teamId, [NullAllowed] NIMTeamHandler completion);

		// @required -(void)updateMuteState:(BOOL)mute inTeam:(NSString * _Nonnull)teamId completion:(NIMTeamHandler _Nullable)completion;
		[Abstract]
		[Export ("updateMuteState:inTeam:completion:")]
		void UpdateMuteState (bool mute, string teamId, [NullAllowed] NIMTeamHandler completion);

		// @required -(void)fetchTeamMembers:(NSString * _Nonnull)teamId completion:(NIMTeamMemberHandler _Nullable)completion;
		[Abstract]
		[Export ("fetchTeamMembers:completion:")]
		void FetchTeamMembers (string teamId, [NullAllowed] NIMTeamMemberHandler completion);

		// @required -(void)fetchTeamMutedMembers:(NSString * _Nonnull)teamId completion:(NIMTeamMemberHandler _Nullable)completion;
		[Abstract]
		[Export ("fetchTeamMutedMembers:completion:")]
		void FetchTeamMutedMembers (string teamId, [NullAllowed] NIMTeamMemberHandler completion);

		// @required -(void)fetchTeamMembersFromServer:(NSString * _Nonnull)teamId completion:(NIMTeamMemberHandler _Nullable)completion;
		[Abstract]
		[Export ("fetchTeamMembersFromServer:completion:")]
		void FetchTeamMembersFromServer (string teamId, [NullAllowed] NIMTeamMemberHandler completion);

		// @required -(void)fetchTeamInfo:(NSString * _Nonnull)teamId completion:(NIMTeamFetchInfoHandler _Nullable)completion;
		[Abstract]
		[Export ("fetchTeamInfo:completion:")]
		void FetchTeamInfo (string teamId, [NullAllowed] NIMTeamFetchInfoHandler completion);

		// @required -(NIMTeamMember * _Nullable)teamMember:(NSString * _Nonnull)userId inTeam:(NSString * _Nonnull)teamId;
		[Abstract]
		[Export ("teamMember:inTeam:")]
		[return: NullAllowed]
		NIMTeamMember TeamMember (string userId, string teamId);

		// @required -(void)addDelegate:(id<NIMTeamManagerDelegate> _Nonnull)delegate;
		[Abstract]
		[Export ("addDelegate:")]
		void AddDelegate (NIMTeamManagerDelegate @delegate);

		// @required -(void)removeDelegate:(id<NIMTeamManagerDelegate> _Nonnull)delegate;
		[Abstract]
		[Export ("removeDelegate:")]
		void RemoveDelegate (NIMTeamManagerDelegate @delegate);
	}

	// typedef void (^NIMSystemNotificationHandler)(NSError * _Nullable);
	delegate void NIMSystemNotificationHandler ([NullAllowed] NSError arg0);

	// @protocol NIMSystemNotificationManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMSystemNotificationManagerDelegate
	{
		// @optional -(void)onReceiveSystemNotification:(NIMSystemNotification * _Nonnull)notification;
		[Export ("onReceiveSystemNotification:")]
		void OnReceiveSystemNotification (NSObject notification);

		// @optional -(void)onSystemNotificationCountChanged:(NSInteger)unreadCount;
		[Export ("onSystemNotificationCountChanged:")]
		void OnSystemNotificationCountChanged (nint unreadCount);

		// @optional -(void)onReceiveCustomSystemNotification:(NIMCustomSystemNotification * _Nonnull)notification;
		[Export ("onReceiveCustomSystemNotification:")]
		void OnReceiveCustomSystemNotification (NIMCustomSystemNotification notification);
	}

	// @protocol NIMSystemNotificationManager <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NIMSystemNotificationManager
	{
		// @required -(NSArray<NIMSystemNotification *> * _Nullable)fetchSystemNotifications:(NIMSystemNotification * _Nullable)notification limit:(NSInteger)limit;
		[Abstract]
		[Export ("fetchSystemNotifications:limit:")]
		[return: NullAllowed]
		NIMSystemNotification[] FetchSystemNotifications ([NullAllowed] NSObject notification, nint limit);

		// @required -(NSArray<NIMSystemNotification *> * _Nullable)fetchSystemNotifications:(NIMSystemNotification * _Nullable)notification limit:(NSInteger)limit filter:(NIMSystemNotificationFilter * _Nullable)filter;
		[Abstract]
		[Export ("fetchSystemNotifications:limit:filter:")]
		[return: NullAllowed]
		NIMSystemNotification[] FetchSystemNotifications ([NullAllowed] NSObject notification, nint limit, [NullAllowed] NSObject filter);

		// @required -(NSInteger)allUnreadCount;
		[Abstract]
		[Export ("allUnreadCount")]
		[Verify (MethodToProperty)]
		nint AllUnreadCount { get; }

		// @required -(NSInteger)allUnreadCount:(NIMSystemNotificationFilter * _Nullable)filter;
		[Abstract]
		[Export ("allUnreadCount:")]
		nint AllUnreadCount ([NullAllowed] NSObject filter);

		// @required -(void)deleteNotification:(NIMSystemNotification * _Nonnull)notification;
		[Abstract]
		[Export ("deleteNotification:")]
		void DeleteNotification (NSObject notification);

		// @required -(void)deleteAllNotifications;
		[Abstract]
		[Export ("deleteAllNotifications")]
		void DeleteAllNotifications ();

		// @required -(void)deleteAllNotifications:(NIMSystemNotificationFilter * _Nullable)filter;
		[Abstract]
		[Export ("deleteAllNotifications:")]
		void DeleteAllNotifications ([NullAllowed] NSObject filter);

		// @required -(void)markNotificationsAsRead:(NIMSystemNotification * _Nonnull)notification;
		[Abstract]
		[Export ("markNotificationsAsRead:")]
		void MarkNotificationsAsRead (NSObject notification);

		// @required -(void)markAllNotificationsAsRead;
		[Abstract]
		[Export ("markAllNotificationsAsRead")]
		void MarkAllNotificationsAsRead ();

		// @required -(void)markAllNotificationsAsRead:(NIMSystemNotificationFilter * _Nullable)filter;
		[Abstract]
		[Export ("markAllNotificationsAsRead:")]
		void MarkAllNotificationsAsRead ([NullAllowed] NSObject filter);

		// @required -(void)sendCustomNotification:(NIMCustomSystemNotification * _Nonnull)notification toSession:(NIMSession * _Nonnull)session completion:(NIMSystemNotificationHandler _Nullable)completion;
		[Abstract]
		[Export ("sendCustomNotification:toSession:completion:")]
		void SendCustomNotification (NIMCustomSystemNotification notification, NIMSession session, [NullAllowed] NIMSystemNotificationHandler completion);

		// @required -(void)addDelegate:(id<NIMSystemNotificationManagerDelegate> _Nonnull)delegate;
		[Abstract]
		[Export ("addDelegate:")]
		void AddDelegate (NIMSystemNotificationManagerDelegate @delegate);

		// @required -(void)removeDelegate:(id<NIMSystemNotificationManagerDelegate> _Nonnull)delegate;
		[Abstract]
		[Export ("removeDelegate:")]
		void RemoveDelegate (NIMSystemNotificationManagerDelegate @delegate);
	}

	// @interface NIMServerSetting : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMServerSetting
	{
		// @property (copy, nonatomic) NSString * _Nonnull module;
		[Export ("module")]
		string Module { get; set; }

		// @property (assign, nonatomic) NSInteger version;
		[Export ("version")]
		nint Version { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull lbsAddress;
		[Export ("lbsAddress")]
		string LbsAddress { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull linkAddress;
		[Export ("linkAddress")]
		string LinkAddress { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull nosLbsAddress;
		[Export ("nosLbsAddress")]
		string NosLbsAddress { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull nosUploadAddress;
		[Export ("nosUploadAddress")]
		string NosUploadAddress { get; set; }

		// @property (assign, nonatomic) BOOL httpsEnabled;
		[Export ("httpsEnabled")]
		bool HttpsEnabled { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable nosUploadHost;
		[NullAllowed, Export ("nosUploadHost")]
		string NosUploadHost { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull nosDownloadAddress;
		[Export ("nosDownloadAddress")]
		string NosDownloadAddress { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable nosAccelerateHost;
		[NullAllowed, Export ("nosAccelerateHost")]
		string NosAccelerateHost { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable nosAccelerateAddress;
		[NullAllowed, Export ("nosAccelerateAddress")]
		string NosAccelerateAddress { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable ntServerAddress;
		[NullAllowed, Export ("ntServerAddress")]
		string NtServerAddress { get; set; }
	}

	// typedef void (^NIMArchiveLogsHandler)(NSError * _Nonnull, NSString * _Nonnull);
	delegate void NIMArchiveLogsHandler (NSError arg0, string arg1);

	// @interface NIMSDK : NSObject
	[BaseType (typeof(NSObject))]
	interface NIMSDK
	{
		// +(instancetype _Nonnull)sharedSDK;
		[Static]
		[Export ("sharedSDK")]
		NIMSDK SharedSDK ();

		// -(NSString * _Nonnull)sdkVersion;
		[Export ("sdkVersion")]
		[Verify (MethodToProperty)]
		string SdkVersion { get; }

		// -(void)registerWithAppID:(NSString * _Nonnull)appKey cerName:(NSString * _Nullable)cerName;
		[Export ("registerWithAppID:cerName:")]
		void RegisterWithAppID (string appKey, [NullAllowed] string cerName);

		// -(void)registerWithOption:(NIMSDKOption * _Nonnull)option;
		[Export ("registerWithOption:")]
		void RegisterWithOption (NIMSDKOption option);

		// -(NSString * _Nullable)appKey;
		[NullAllowed, Export ("appKey")]
		[Verify (MethodToProperty)]
		string AppKey { get; }

		// -(BOOL)isUsingDemoAppKey;
		[Export ("isUsingDemoAppKey")]
		[Verify (MethodToProperty)]
		bool IsUsingDemoAppKey { get; }

		// -(void)updateApnsToken:(NSData * _Nonnull)token;
		[Export ("updateApnsToken:")]
		void UpdateApnsToken (NSData token);

		// -(void)updatePushKitToken:(NSData * _Nonnull)token;
		[Export ("updatePushKitToken:")]
		void UpdatePushKitToken (NSData token);

		// -(NSString * _Nonnull)currentLogFilepath;
		[Export ("currentLogFilepath")]
		[Verify (MethodToProperty)]
		string CurrentLogFilepath { get; }

		// -(void)archiveLogs:(NIMArchiveLogsHandler _Nonnull)completion;
		[Export ("archiveLogs:")]
		void ArchiveLogs (NIMArchiveLogsHandler completion);

		// -(void)enableConsoleLog;
		[Export ("enableConsoleLog")]
		void EnableConsoleLog ();

		// @property (nonatomic, strong) NIMServerSetting * _Nonnull serverSetting;
		[Export ("serverSetting", ArgumentSemantic.Strong)]
		NIMServerSetting ServerSetting { get; set; }

		// @property (nonatomic, strong) NSMutableDictionary * _Nonnull sceneDict;
		[Export ("sceneDict", ArgumentSemantic.Strong)]
		NSMutableDictionary SceneDict { get; set; }

		// @property (readonly, nonatomic, strong) id<NIMLoginManager> _Nonnull loginManager;
		[Export ("loginManager", ArgumentSemantic.Strong)]
		NIMLoginManager LoginManager { get; }

		// @property (readonly, nonatomic, strong) id<NIMChatManager> _Nonnull chatManager;
		[Export ("chatManager", ArgumentSemantic.Strong)]
		NIMChatManager ChatManager { get; }

		// @property (readonly, nonatomic, strong) id<NIMConversationManager> _Nonnull conversationManager;
		[Export ("conversationManager", ArgumentSemantic.Strong)]
		NIMConversationManager ConversationManager { get; }

		// @property (readonly, nonatomic, strong) id<NIMMediaManager> _Nonnull mediaManager;
		[Export ("mediaManager", ArgumentSemantic.Strong)]
		NIMMediaManager MediaManager { get; }

		// @property (readonly, nonatomic, strong) id<NIMTeamManager> _Nonnull teamManager;
		[Export ("teamManager", ArgumentSemantic.Strong)]
		NIMTeamManager TeamManager { get; }

		// @property (readonly, nonatomic, strong) id<NIMUserManager> _Nonnull userManager;
		[Export ("userManager", ArgumentSemantic.Strong)]
		NIMUserManager UserManager { get; }

		// @property (readonly, nonatomic, strong) id<NIMSystemNotificationManager> _Nonnull systemNotificationManager;
		[Export ("systemNotificationManager", ArgumentSemantic.Strong)]
		NIMSystemNotificationManager SystemNotificationManager { get; }

		// @property (readonly, nonatomic, strong) id<NIMApnsManager> _Nonnull apnsManager;
		[Export ("apnsManager", ArgumentSemantic.Strong)]
		NIMApnsManager ApnsManager { get; }

		// @property (readonly, nonatomic, strong) id<NIMResourceManager> _Nonnull resourceManager;
		[Export ("resourceManager", ArgumentSemantic.Strong)]
		NIMResourceManager ResourceManager { get; }

		// @property (readonly, nonatomic, strong) id<NIMChatroomManager> _Nonnull chatroomManager;
		[Export ("chatroomManager", ArgumentSemantic.Strong)]
		NIMChatroomManager ChatroomManager { get; }

		// @property (readonly, nonatomic, strong) id<NIMDocTranscodingManager> _Nonnull docTranscodingManager;
		[Export ("docTranscodingManager", ArgumentSemantic.Strong)]
		NIMDocTranscodingManager DocTranscodingManager { get; }

		// @property (readonly, nonatomic, strong) id<NIMEventSubscribeManager> _Nonnull subscribeManager;
		[Export ("subscribeManager", ArgumentSemantic.Strong)]
		NIMEventSubscribeManager SubscribeManager { get; }

		// @property (readonly, nonatomic, strong) id<NIMRobotManager> _Nonnull robotManager;
		[Export ("robotManager", ArgumentSemantic.Strong)]
		NIMRobotManager RobotManager { get; }

		// @property (readonly, nonatomic, strong) id<NIMRedPacketManager> _Nonnull redPacketManager;
		[Export ("redPacketManager", ArgumentSemantic.Strong)]
		NIMRedPacketManager RedPacketManager { get; }

		// @property (readonly, nonatomic, strong) id<NIMBroadcastManager> _Nonnull broadcastManager;
		[Export ("broadcastManager", ArgumentSemantic.Strong)]
		NIMBroadcastManager BroadcastManager { get; }

		// @property (readonly, nonatomic, strong) id<NIMAntispamManager> _Nonnull antispamManager;
		[Export ("antispamManager", ArgumentSemantic.Strong)]
		NIMAntispamManager AntispamManager { get; }

		// @property (readonly, nonatomic, strong) id<NIMSignalManager> _Nonnull signalManager;
		[Export ("signalManager", ArgumentSemantic.Strong)]
		NIMSignalManager SignalManager { get; }
	}
}
