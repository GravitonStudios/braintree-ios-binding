using System;
using Foundation;
using PayPalDataCollector;

namespace PayPalDataCollector
{
	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern double PayPalDataCollectorVersionNumber;
		[Field ("PayPalDataCollectorVersionNumber", "__Internal")]
		double PayPalDataCollectorVersionNumber { get; }

		// extern const unsigned char [] PayPalDataCollectorVersionString;
		[Field ("PayPalDataCollectorVersionString", "__Internal")]
		byte[] PayPalDataCollectorVersionString { get; }
	}

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

	// @interface PPDataCollector : NSObject
	[BaseType (typeof(NSObject))]
	interface PPDataCollector
	{
		// +(NSString * _Nonnull)clientMetadataID:(NSString * _Nullable)pairingID;
		[Static]
		[Export ("clientMetadataID:")]
		string ClientMetadataID ([NullAllowed] string pairingID);

		// +(NSString * _Nonnull)clientMetadataID __attribute__((deprecated("Use [PPDataCollector collectPayPalDeviceData] to generate a device data string.")));
		[Static]
		[Export ("clientMetadataID")]
		[Verify (MethodToProperty)]
		string ClientMetadataID { get; }

		// +(NSString * _Nonnull)collectPayPalDeviceData;
		[Static]
		[Export ("collectPayPalDeviceData")]
		[Verify (MethodToProperty)]
		string CollectPayPalDeviceData { get; }

		// +(PPRMOCMagnesSDKResult * _Nonnull)collectPayPalDeviceInfoWithClientMetadataID:(NSString * _Nullable)clientMetadataID;
		[Static]
		[Export ("collectPayPalDeviceInfoWithClientMetadataID:")]
		PPRMOCMagnesSDKResult CollectPayPalDeviceInfoWithClientMetadataID ([NullAllowed] string clientMetadataID);
	}
}
