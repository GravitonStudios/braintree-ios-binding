using System;
using Foundation;
using PayPalDataCollector;

namespace PayPalDataCollector
{
    // @interface PPDataCollector : NSObject
    [BaseType(typeof(NSObject))]
    interface PPDataCollector
    {
        // +(NSString * _Nonnull)clientMetadataID:(NSString * _Nullable)pairingID;
        [Static]
        [Export("clientMetadataID:")]
        string ClientMetadataID([NullAllowed] string pairingID);

        // +(NSString * _Nonnull)clientMetadataID __attribute__((deprecated("Use [PPDataCollector collectPayPalDeviceData] to generate a device data string.")));
        [Static]
        [Export("clientMetadataID")]
        string ClientMetadataI();

        // +(NSString * _Nonnull)collectPayPalDeviceData;
        [Static]
        [Export("collectPayPalDeviceData")]
        string CollectPayPalDeviceData();

        // +(PPRMOCMagnesSDKResult * _Nonnull)collectPayPalDeviceInfoWithClientMetadataID:(NSString * _Nullable)clientMetadataID;
        [Static]
        [Export("collectPayPalDeviceInfoWithClientMetadataID:")]
        PPRMOCMagnesSDKResult CollectPayPalDeviceInfoWithClientMetadataID([NullAllowed] string clientMetadataID);
    }
    
    // @interface PPRMOCMagnesSDKResult : NSObject
	[BaseType(typeof(NSObject))]
	interface PPRMOCMagnesSDKResult
	{
	    // -(id)initWithDeviceInfo:(NSDictionary *)deviceInfo withPayPalClientMetaDataId:(NSString *)cmid;
	    [Export("initWithDeviceInfo:withPayPalClientMetaDataId:")]
	    IntPtr Constructor(NSDictionary deviceInfo, string cmid);
	
	    // -(NSDictionary *)getDeviceInfo;
	    [Export("getDeviceInfo")]
	    NSDictionary DeviceInfo { get; }
	
	    // -(NSString *)getPayPalClientMetaDataId;
	    [Export("getPayPalClientMetaDataId")]
	    string PayPalClientMetaDataId { get; }
	}
}

