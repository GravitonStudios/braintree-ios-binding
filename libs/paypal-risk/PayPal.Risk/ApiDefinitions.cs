using System;
using Foundation;

namespace PayPal.Risk
{
	// @interface PPRMOCMagnesSDKResult : NSObject
	[BaseType (typeof(NSObject))]
	interface PPRMOCMagnesSDKResult
	{
		// -(id)initWithDeviceInfo:(NSDictionary *)deviceInfo withPayPalClientMetaDataId:(NSString *)cmid;
		[Export ("initWithDeviceInfo:withPayPalClientMetaDataId:")]
		IntPtr Constructor (NSDictionary deviceInfo, string cmid);

		// -(NSDictionary *)getDeviceInfo;
		[Export ("getDeviceInfo")]
		[Verify (MethodToProperty)]
		NSDictionary DeviceInfo { get; }

		// -(NSString *)getPayPalClientMetaDataId;
		[Export ("getPayPalClientMetaDataId")]
		[Verify (MethodToProperty)]
		string PayPalClientMetaDataId { get; }
	}

	// @interface PPRMOCMagnesSDK : NSObject
	[BaseType (typeof(NSObject))]
	interface PPRMOCMagnesSDK
	{
		// +(PPRMOCMagnesSDK *)shared;
		[Static]
		[Export ("shared")]
		[Verify (MethodToProperty)]
		PPRMOCMagnesSDK Shared { get; }

		// -(void)setUpEnvironment:(MagnesEnvironment)env withOptionalAppGuid:(NSString *)appGuid withOptionalAPNToken:(NSString *)apnToken disableRemoteConfiguration:(Boolean)isRemoteConfigDisabled disableBeacon:(Boolean)isBeaconDisabled forMagnesSource:(MagnesSourceFlow)magnesSource;
		[Export ("setUpEnvironment:withOptionalAppGuid:withOptionalAPNToken:disableRemoteConfiguration:disableBeacon:forMagnesSource:")]
		void SetUpEnvironment (MagnesEnvironment env, string appGuid, string apnToken, Boolean isRemoteConfigDisabled, Boolean isBeaconDisabled, MagnesSourceFlow magnesSource);

		// -(PPRMOCMagnesSDKResult *)collect;
		[Export ("collect")]
		[Verify (MethodToProperty)]
		PPRMOCMagnesSDKResult Collect { get; }

		// -(PPRMOCMagnesSDKResult *)collectWithPayPalClientMetadataId:(NSString *)cmid withAdditionalData:(NSDictionary *)additionalData;
		[Export ("collectWithPayPalClientMetadataId:withAdditionalData:")]
		PPRMOCMagnesSDKResult CollectWithPayPalClientMetadataId (string cmid, NSDictionary additionalData);

		// -(PPRMOCMagnesSDKResult *)collectAndSubmit;
		[Export ("collectAndSubmit")]
		[Verify (MethodToProperty)]
		PPRMOCMagnesSDKResult CollectAndSubmit { get; }

		// -(PPRMOCMagnesSDKResult *)collectAndSubmitWithPayPalClientMetadataId:(NSString *)cmid withAdditionalData:(NSDictionary *)additionalData;
		[Export ("collectAndSubmitWithPayPalClientMetadataId:withAdditionalData:")]
		PPRMOCMagnesSDKResult CollectAndSubmitWithPayPalClientMetadataId (string cmid, NSDictionary additionalData);
	}
}
