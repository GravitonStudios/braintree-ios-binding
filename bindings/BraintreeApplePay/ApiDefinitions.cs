using System;
using BraintreeApplePay;
using BraintreeCore;
using Foundation;
using ObjCRuntime;
using PassKit;

namespace BraintreeApplePay
{
	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern double BraintreeApplePayVersionNumber;
		[Field ("BraintreeApplePayVersionNumber", "__Internal")]
		double BraintreeApplePayVersionNumber { get; }

		// extern const unsigned char [] BraintreeApplePayVersionString;
		[Field ("BraintreeApplePayVersionString", "__Internal")]
		byte[] BraintreeApplePayVersionString { get; }
	}

	// @interface BTApplePayCardNonce : BTPaymentMethodNonce
	[BaseType (typeof(BTPaymentMethodNonce))]
	interface BTApplePayCardNonce
	{
		// @property (readonly, nonatomic, strong) BTBinData * _Nonnull binData;
		[Export ("binData", ArgumentSemantic.Strong)]
		BTBinData BinData { get; }

		// -(instancetype _Nullable)initWithNonce:(NSString * _Nonnull)nonce localizedDescription:(NSString * _Nullable)description type:(NSString * _Nonnull)type json:(BTJSON * _Nonnull)json;
		[Export ("initWithNonce:localizedDescription:type:json:")]
		IntPtr Constructor (string nonce, [NullAllowed] string description, string type, BTJSON json);
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull BTApplePayErrorDomain;
		[Field ("BTApplePayErrorDomain", "__Internal")]
		NSString BTApplePayErrorDomain { get; }
	}

	// @interface BTApplePayClient : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface BTApplePayClient
	{
		// -(instancetype _Nonnull)initWithAPIClient:(BTAPIClient * _Nonnull)apiClient __attribute__((objc_designated_initializer));
		[Export ("initWithAPIClient:")]
		[DesignatedInitializer]
		IntPtr Constructor (BTAPIClient apiClient);

		// -(void)paymentRequest:(void (^ _Nonnull)(PKPaymentRequest * _Nullable, NSError * _Nullable))completion;
		[Export ("paymentRequest:")]
		void PaymentRequest (Action<PKPaymentRequest, NSError> completion);

		// -(void)tokenizeApplePayPayment:(PKPayment * _Nonnull)payment completion:(void (^ _Nonnull)(BTApplePayCardNonce * _Nullable, NSError * _Nullable))completionBlock;
		[Export ("tokenizeApplePayPayment:completion:")]
		void TokenizeApplePayPayment (PKPayment payment, Action<BTApplePayCardNonce, NSError> completionBlock);
	}

	// @interface ApplePay (BTConfiguration)
	[Category]
	[BaseType (typeof(BTConfiguration))]
	interface BTConfiguration_ApplePay
	{
		// @property (readonly, assign, nonatomic) BOOL isApplePayEnabled;
		[Export ("isApplePayEnabled")]
		bool IsApplePayEnabled { get; }

		// @property (readonly, nonatomic) NSArray<PKPaymentNetwork> * _Nullable applePaySupportedNetworks;
		[NullAllowed, Export ("applePaySupportedNetworks")]
		string[] ApplePaySupportedNetworks { get; }

		// @property (readonly, assign, nonatomic) BOOL canMakeApplePayPayments;
		[Export ("canMakeApplePayPayments")]
		bool CanMakeApplePayPayments { get; }

		// @property (readonly, nonatomic) NSString * _Nullable applePayCountryCode;
		[NullAllowed, Export ("applePayCountryCode")]
		string ApplePayCountryCode { get; }

		// @property (readonly, nonatomic) NSString * _Nullable applePayCurrencyCode;
		[NullAllowed, Export ("applePayCurrencyCode")]
		string ApplePayCurrencyCode { get; }

		// @property (readonly, nonatomic) NSString * _Nullable applePayMerchantIdentifier;
		[NullAllowed, Export ("applePayMerchantIdentifier")]
		string ApplePayMerchantIdentifier { get; }
	}
}
