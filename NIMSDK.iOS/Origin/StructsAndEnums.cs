using System;
using ObjCRuntime;

namespace NIMSDK.iOS
{
	[Native]
	public enum NIMLocalAntiSpamOperate : nint
	{
		OperateFileNotExists,
		ResultLocalReplace,
		ResultLocalForbidden,
		ResultServerForbidden,
		ResultNotHit
	}

	[Native]
	public enum NIMMessageType : nint
	{
		Text = 0,
		Image = 1,
		Audio = 2,
		Video = 3,
		Location = 4,
		Notification = 5,
		File = 6,
		Tip = 10,
		Robot = 11,
		Custom = 100
	}

	[Native]
	public enum NIMNetCallType : nint
	{
		Audio = 1,
		Video = 2
	}

	[Native]
	public enum NIMLocalErrorCode : nint
	{
		InvalidParam = 1,
		InvalidMedia = 2,
		InvalidPicture = 3,
		InvalidUrl = 4,
		IOError = 5,
		InvalidToken = 6,
		HttpReqeustFailed = 7,
		AudioRecordErrorNoPermission = 8,
		AudioRecordErrorInitFailed = 9,
		AudioRecordErrorRecordFailed = 10,
		AudioPlayErrorInitFailed = 11,
		SQLFailed = 12,
		UserInfoNeeded = 13,
		AppKeyNeed = 14,
		AutoLoginRetryLimit = 15,
		SameOperationInProgress = 16,
		RequestChatroomAddressesFailed = 17,
		TeamReceiptDisabled = 18,
		ManualCancelTask = 19,
		ResourcesOverdue = 20,
		SceneUnregistered = 21
	}

	[Native]
	public enum NIMRemoteErrorCode : nint
	{
		CodeInvalidVersion = 201,
		CodeInvalidPass = 302,
		CodeInvalidCRC = 402,
		CodeForbidden = 403,
		CodeNotExist = 404,
		CodeReadOnly = 406,
		CodeTimeoutError = 408,
		CodeParameterError = 414,
		CodeConnectionError = 415,
		CodeFrequently = 416,
		CodeExist = 417,
		AccountBlock = 422,
		CodeUnknownError = 500,
		CodeServerDataError = 501,
		CodeNotEnough = 507,
		CodeDomainExpireOld = 508,
		CodeInvalidProtocol = 509,
		CodeUserNotExist = 510,
		CodeServiceUnavailable = 514,
		CodeTeamMemberLimit = 801,
		CodeTeamAccessError = 802,
		CodeTeamNotExists = 803,
		CodeNotInTeam = 804,
		CodeTeamInvaildType = 805,
		CodeTeamCountLimit = 806,
		CodeTeamAlreadyIn = 809,
		CodeTeamNotMember = 810,
		CodeTeamBlackList = 812,
		CodeEUnpacket = 998,
		CodeEPacket = 999,
		CodeInBlackList = 7101,
		CodeInvalidChatroom = 13002,
		CodeInChatroomBlackList = 13003,
		CodeInChatroomMuteList = 13004,
		CodeInChatroomAllMute = 13006,
		CodeSignalResPeerNIMOffline = 10201,
		CodeSignalResPeerPushOffline = 10202,
		CodeSignalResRoomNotExists = 10404,
		CodeSignalResRoomHasExists = 10405,
		CodeSignalResRoomMemberNotExists = 10406,
		CodeSignalResRoomMemberHasExists = 10407,
		CodeSignalResInviteNotExists = 10408,
		CodeSignalResInviteHasReject = 10409,
		CodeSignalResInviteHasAccept = 10410,
		CodeSignalResUidConflict = 10417,
		CodeSignalResRoomMemberExceed = 10419
	}

	[Native]
	public enum NIMChatroomQueueModificationLevel : nint
	{
		Anyone,
		Manager
	}

	[Native]
	public enum NIMChatroomConnectionState : nint
	{
		Entering = 0,
		EnterOK = 1,
		EnterFailed = 2,
		LoseConnection = 3
	}

	[Native]
	public enum NIMChatroomKickReason : nint
	{
		InvalidRoom = 1,
		ByManager = 2,
		ByConflictLogin = 3,
		Blacklist = 5
	}

	[Native]
	public enum NIMChatroomMemberType : nint
	{
		Guest = -2,
		Limit = -1,
		Normal = 0,
		Creator = 1,
		Manager = 2,
		AnonymousGuest = 4
	}

	[Native]
	public enum NIMChatroomFetchMemberType : nint
	{
		Regular,
		Temp,
		RegularOnline
	}

	[Native]
	public enum NIMChatroomMemberInfoUpdateTag : nint
	{
		Nick = 5,
		Avatar = 6,
		Ext = 7
	}

	[Native]
	public enum NIMNotificationType : nint
	{
		Unsupport = 0,
		Team = 1,
		NetCall = 2,
		Chatroom = 3
	}

	[Native]
	public enum NIMChatroomEventType : nint
	{
		Enter = 301,
		Exit = 302,
		AddBlack = 303,
		RemoveBlack = 304,
		AddMute = 305,
		RemoveMute = 306,
		AddManager = 307,
		RemoveManager = 308,
		AddCommon = 309,
		RemoveCommon = 310,
		Closed = 311,
		InfoUpdated = 312,
		Kicked = 313,
		AddMuteTemporarily = 314,
		RemoveMuteTemporarily = 315,
		MemberUpdateInfo = 316,
		QueueChange = 317,
		RoomMuted = 318,
		RoomUnMuted = 319,
		QueueBatchChange = 320
	}

	[Native]
	public enum NIMChatroomQueueChangeType : nint
	{
		Invalid = 0,
		Offer = 1,
		Poll = 2,
		Drop = 3
	}

	[Native]
	public enum NIMChatroomQueueBatchChangeType : nint
	{
		Invalid = 0,
		PartClear = 4
	}

	[Native]
	public enum NIMChatroomUpdateTag : nint
	{
		Name = 3,
		Announcement = 4,
		BroadcastUrl = 5,
		Ext = 12,
		QueueModificationLevel = 16
	}

	[Native]
	public enum NIMTeamType : nint
	{
		Normal = 0,
		Advanced = 1
	}

	[Native]
	public enum NIMTeamJoinMode : nint
	{
		NoAuth = 0,
		NeedAuth = 1,
		RejectAll = 2
	}

	[Native]
	public enum NIMTeamInviteMode : nint
	{
		Manager = 0,
		All = 1
	}

	[Native]
	public enum NIMTeamBeInviteMode : nint
	{
		eedAuth = 0,
		oAuth = 1
	}

	[Native]
	public enum NIMTeamUpdateInfoMode : nint
	{
		Manager = 0,
		All = 1
	}

	[Native]
	public enum NIMTeamUpdateClientCustomMode : nint
	{
		Manager = 0,
		All = 1
	}

	[Native]
	public enum NIMTeamApplyStatus : nint
	{
		Invalid,
		AlreadyInTeam,
		WaitForPass
	}

	[Native]
	public enum NIMTeamMemberType : nint
	{
		Normal = 0,
		Owner = 1,
		Manager = 2,
		Apply = 3
	}

	[Native]
	public enum NIMTeamNotifyState : nint
	{
		All = 0,
		None = 1,
		OnlyManager = 2
	}

	[Native]
	public enum NIMDocTranscodingFileType : nint
	{
		Pt = 1,
		Ptx = 2,
		Df = 3
	}

	[Native]
	public enum NIMDocTranscodingImageType : nint
	{
		Unknown = 0,
		Jpg = 10,
		Png = 11
	}

	[Native]
	public enum NIMDocTranscodingQuality : nint
	{
		High = 1,
		Medium = 2,
		Low = 3
	}

	[Native]
	public enum NIMDocTranscodingState : nint
	{
		Unknown = 0,
		Preparing = 1,
		Ongoing = 2,
		Timeout = 3,
		Completed = 4,
		Failed = 5
	}

	[Native]
	public enum NIMImageFormat : nint
	{
		Jpeg,
		Png
	}

	[Native]
	public enum NIMLoginClientType : nint
	{
		Unknown = 0,
		Aos = 1,
		iOS = 2,
		Pc = 4,
		Wp = 8,
		Web = 16,
		Restful = 32,
		macOS = 64
	}

	[Native]
	public enum NIMLoginStep : nint
	{
		Linking = 1,
		LinkOK,
		LinkFailed,
		Logining,
		LoginOK,
		LoginFailed,
		Syncing,
		SyncOK,
		LoseConnection,
		NetChanged
	}

	[Native]
	public enum NIMSDKAuthMode : nint
	{
		Undefined = 0,
		Im,
		Chatroom
	}

	[Native]
	public enum NIMKickReason : nint
	{
		Client = 1,
		Server = 2,
		ClientManually = 3
	}

	[Native]
	public enum NIMAudioOutputDevice : nint
	{
		Receiver,
		Speaker
	}

	[Native]
	public enum NIMAudioType : nint
	{
		Ac,
		Mr
	}

	[Native]
	public enum NIMSessionType : nint
	{
		P2p = 0,
		Team = 1,
		Chatroom = 2
	}

	[Native]
	public enum NIMTeamOperationType : nint
	{
		Invite = 0,
		Kick = 1,
		Leave = 2,
		Update = 3,
		Dismiss = 4,
		ApplyPass = 5,
		TransferOwner = 6,
		AddManager = 7,
		RemoveManager = 8,
		AcceptInvitation = 9,
		Mute = 10
	}

	[Native]
	public enum NIMTeamUpdateTag : nint
	{
		Name = 3,
		Intro = 14,
		Anouncement = 15,
		JoinMode = 16,
		ClientCustom = 18,
		ServerCustom = 19,
		Avatar = 20,
		BeInviteMode = 21,
		InviteMode = 22,
		UpdateInfoMode = 23,
		UpdateClientCustomMode = 24,
		MuteMode = 100
	}

	[Native]
	public enum NIMNetCallEventType : nint
	{
		Reject = -1,
		NoResponse = -2,
		Miss = 101,
		Bill = 102
	}

	[Native]
	public enum NIMMessageDeliveryState : nint
	{
		Failed,
		Delivering,
		Deliveried
	}

	[Native]
	public enum NIMMessageAttachmentDownloadState : nint
	{
		NeedDownload,
		Failed,
		Downloading,
		Downloaded
	}

	[Native]
	public enum NIMMessageSearchOrder : nint
	{
		Desc = 0,
		Asc = 1
	}

	[Native]
	public enum NIMPushNotificationDisplayType : nint
	{
		Detail = 1,
		NoDetail = 2
	}

	[Native]
	public enum NIMRedPacketServiceType : nint
	{
		NIMRedPacketServiceTypeJRMF = 1
	}

	[Native]
	public enum NIMUserOperation : nint
	{
		Add = 1,
		Request = 2,
		Verify = 3,
		Reject = 4
	}

	[Native]
	public enum NIMUserGender : nint
	{
		Unknown,
		Male,
		Female
	}

	[Native]
	public enum NIMSystemNotificationType : nint
	{
		TeamApply = 0,
		TeamApplyReject = 1,
		TeamInvite = 2,
		TeamIviteReject = 3,
		FriendAdd = 5
	}

	[Native]
	public enum NIMSubscribeSystemEventType : nint
	{
		NIMSubscribeSystemEventTypeOnline = 1
	}

	[Native]
	public enum NIMSubscribeEventOnlineValue : nint
	{
		Login = 1,
		Logout = 2,
		Disconnected = 3
	}

	[Native]
	public enum NIMSignalingChannelType : nint
	{
		Audio = 1,
		Video = 2,
		Custom = 3
	}

	[Native]
	public enum NIMSignalingEventType : nint
	{
		Close = 1,
		Join = 2,
		Invite = 3,
		CancelInvite = 4,
		Reject = 5,
		Accept = 6,
		Leave = 7,
		Contrl = 8
	}

	[Native]
	public enum NIMUserInfoUpdateTag : nint
	{
		Nick = 3,
		Avatar = 4,
		Sign = 5,
		Gender = 6,
		Email = 7,
		Birth = 8,
		Mobile = 9,
		Ext = 10
	}
}
