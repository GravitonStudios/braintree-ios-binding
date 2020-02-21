﻿using System;
using BraintreeCore;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace BraintreeCore
{
    partial interface IBTAppSwitchHandler { };
    partial interface IBTAppSwitchDelegate { };
    partial interface IBTViewControllerPresentingDelegate { };

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    //partial interface Constants
    //{
    //	// extern double BraintreeCoreVersionNumber;
    //	[Field("BraintreeCoreVersionNumber", "__Internal")]
    //	double BraintreeCoreVersionNumber { get; }

    //	// extern const unsigned char [] BraintreeCoreVersionString;
    //	[Field("BraintreeCoreVersionString", "__Internal")]
    //	byte[] BraintreeCoreVersionString { get; }
    //}

    // @interface BTClientMetadata : NSObject <NSCopying, NSMutableCopying>
    [BaseType(typeof(NSObject))]
    interface BTClientMetadata : INSCopying, INSMutableCopying
    {
        // @property (readonly, assign, nonatomic) BTClientMetadataIntegrationType integration;
        [Export("integration", ArgumentSemantic.Assign)]
        BTClientMetadataIntegrationType Integration { get; }

        // @property (readonly, assign, nonatomic) BTClientMetadataSourceType source;
        [Export("source", ArgumentSemantic.Assign)]
        BTClientMetadataSourceType Source { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull sessionId;
        [Export("sessionId")]
        string SessionId { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull integrationString;
        [Export("integrationString")]
        string IntegrationString { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull sourceString;
        [Export("sourceString")]
        string SourceString { get; }

        // @property (readonly, nonatomic, strong) NSDictionary * _Nonnull parameters;
        [Export("parameters", ArgumentSemantic.Strong)]
        NSDictionary Parameters { get; }
    }

    // @interface BTMutableClientMetadata : BTClientMetadata
    [BaseType(typeof(BTClientMetadata))]
    interface BTMutableClientMetadata
    {
        // -(void)setIntegration:(BTClientMetadataIntegrationType)integration;
        [Export("setIntegration:")]
        void SetIntegration(BTClientMetadataIntegrationType integration);

        // -(void)setSource:(BTClientMetadataSourceType)source;
        [Export("setSource:")]
        void SetSource(BTClientMetadataSourceType source);

        // -(void)setSessionId:(NSString * _Nonnull)sessionId;
        [Export("setSessionId:")]
        void SetSessionId(string sessionId);
    }

    [Static]
    partial interface BTJSONConstants
    {
        // extern NSString *const _Nonnull BTJSONErrorDomain;
        [Field("BTJSONErrorDomain", "__Internal")]
        NSString ErrorDomain { get; }
    }

    // @interface BTJSON : NSObject
    [BaseType(typeof(NSObject))]
    interface BTJSON
    {
        // -(instancetype _Nonnull)initWithValue:(id _Nonnull)value;
        [Export("initWithValue:")]
        IntPtr Constructor(NSObject value);

        // -(instancetype _Nonnull)initWithData:(NSData * _Nonnull)data;
        [Export("initWithData:")]
        IntPtr Constructor(NSData data);

        // -(id _Nonnull)objectForKeyedSubscript:(NSString * _Nonnull)key;
        [Export("objectForKeyedSubscript:")]
        NSObject ObjectForKeyedSubscript(string key);

        // -(BTJSON * _Nonnull)objectAtIndexedSubscript:(NSUInteger)idx;
        [Export("objectAtIndexedSubscript:")]
        BTJSON ObjectAtIndexedSubscript(nuint idx);

        // @property (readonly, assign, nonatomic) BOOL isError;
        [Export("isError")]
        bool IsError { get; }

        // -(NSError * _Nullable)asError;
        [NullAllowed, Export("asError")]
        NSError AsError();

        // -(NSData * _Nullable)asJSONAndReturnError:(NSError * _Nullable * _Nullable)error;
        [Export("asJSONAndReturnError:")]
        [return: NullAllowed]
        NSData AsJSONAndReturnError([NullAllowed] out NSError error);

        // -(NSString * _Nullable)asPrettyJSONAndReturnError:(NSError * _Nullable * _Nullable)error;
        [Export("asPrettyJSONAndReturnError:")]
        [return: NullAllowed]
        string AsPrettyJSONAndReturnError([NullAllowed] out NSError error);

        // -(NSString * _Nullable)asString;
        [NullAllowed, Export("asString")]
        string AsString();

        // -(NSArray<BTJSON *> * _Nullable)asArray;
        [NullAllowed, Export("asArray")]
        BTJSON[] AsArray();

        // -(NSDecimalNumber * _Nullable)asNumber;
        [NullAllowed, Export("asNumber")]
        NSDecimalNumber AsNumber();

        // -(NSURL * _Nullable)asURL;
        [NullAllowed, Export("asURL")]
        NSUrl AsURL();

        // -(NSArray<NSString *> * _Nullable)asStringArray;
        [NullAllowed, Export("asStringArray")]
        string[] AsStringArray();

        // -(NSDictionary * _Nullable)asDictionary;
        [NullAllowed, Export("asDictionary")]
        NSDictionary AsDictionary();

        // -(NSInteger)asIntegerOrZero;
        [Export("asIntegerOrZero")]
        nint AsIntegerOrZero();

        // -(NSInteger)asEnum:(NSDictionary * _Nonnull)mapping orDefault:(NSInteger)defaultValue;
        [Export("asEnum:orDefault:")]
        nint AsEnum(NSDictionary mapping, nint defaultValue);

        // @property (readonly, assign, nonatomic) BOOL isString;
        [Export("isString")]
        bool IsString { get; }

        // @property (readonly, assign, nonatomic) BOOL isNumber;
        [Export("isNumber")]
        bool IsNumber { get; }

        // @property (readonly, assign, nonatomic) BOOL isArray;
        [Export("isArray")]
        bool IsArray { get; }

        // @property (readonly, assign, nonatomic) BOOL isObject;
        [Export("isObject")]
        bool IsObject { get; }

        // @property (readonly, assign, nonatomic) BOOL isBool;
        [Export("isBool")]
        bool IsBool { get; }

        // @property (readonly, assign, nonatomic) BOOL isTrue;
        [Export("isTrue")]
        bool IsTrue { get; }

        // @property (readonly, assign, nonatomic) BOOL isFalse;
        [Export("isFalse")]
        bool IsFalse { get; }

        // @property (readonly, assign, nonatomic) BOOL isNull;
        [Export("isNull")]
        bool IsNull { get; }
    }

    // @interface BTConfiguration : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface BTConfiguration
    {
        // -(instancetype _Nonnull)initWithJSON:(BTJSON * _Nonnull)json __attribute__((objc_designated_initializer));
        [Export("initWithJSON:")]
        [DesignatedInitializer]
        IntPtr Constructor(BTJSON json);

        // @property (readonly, nonatomic, strong) BTJSON * _Nonnull json;
        [Export("json", ArgumentSemantic.Strong)]
        BTJSON Json { get; }

        // +(BOOL)isBetaEnabledPaymentOption:(NSString * _Nonnull)paymentOption __attribute__((deprecated("Pay with Venmo is no longer in beta")));
        [Static]
        [Export("isBetaEnabledPaymentOption:")]
        bool IsBetaEnabledPaymentOption(string paymentOption);

        // +(void)setBetaPaymentOption:(NSString * _Nonnull)paymentOption isEnabled:(BOOL)isEnabled __attribute__((deprecated("Pay with Venmo is no longer in beta")));
        [Static]
        [Export("setBetaPaymentOption:isEnabled:")]
        void SetBetaPaymentOption(string paymentOption, bool isEnabled);
    }

    [Static]
    partial interface BTAPIClientConstants
    {
        // extern NSString *const _Nonnull BTAPIClientErrorDomain;
        [Field("BTAPIClientErrorDomain", "__Internal")]
        NSString BTAPIClientErrorDomain { get; }
    }

    delegate void GetTokenizationCompletionblock(BTPaymentMethodNonce nonce, NSError error);
    delegate void RegisterTokenizationCompleteBlock(BTAPIClient client, NSDictionary data, [BlockCallback]GetTokenizationCompletionblock subblock);
    delegate void FetchOrReturnRemoteConfigurationCompletionBlock(BTConfiguration configuration, NSError error);
    delegate void FetchPaymentMethodNoncesCompletionBlock(NSArray<BTPaymentMethodNonce> items, NSError error);
    delegate void BTJsonCompletionBlock(BTJSON json, NSHttpUrlResponse response, NSError error);

    // @interface BTAPIClient : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface BTAPIClient
    {
        // -(instancetype _Nullable)initWithAuthorization:(NSString * _Nonnull)authorization;
        [Export("initWithAuthorization:")]
        IntPtr Constructor(string authorization);

        // -(instancetype _Nonnull)copyWithSource:(BTClientMetadataSourceType)source integration:(BTClientMetadataIntegrationType)integration;
        [Export("copyWithSource:integration:")]
        BTAPIClient CopyWithSource(BTClientMetadataSourceType source, BTClientMetadataIntegrationType integration);

        // -(void)fetchOrReturnRemoteConfiguration:(void (^ _Nonnull)(BTConfiguration * _Nullable, NSError * _Nullable))completionBlock;
        [Export("fetchOrReturnRemoteConfiguration:")]
        void FetchOrReturnRemoteConfiguration([BlockCallback]FetchOrReturnRemoteConfigurationCompletionBlock completionBlock);

        // -(void)fetchPaymentMethodNonces:(void (^ _Nonnull)(NSArray<BTPaymentMethodNonce *> * _Nullable, NSError * _Nullable))completion;
        [Export("fetchPaymentMethodNonces:")]
        void FetchPaymentMethodNonces([BlockCallback]FetchPaymentMethodNoncesCompletionBlock completion);

        // -(void)fetchPaymentMethodNonces:(BOOL)defaultFirst completion:(void (^ _Nonnull)(NSArray<BTPaymentMethodNonce *> * _Nullable, NSError * _Nullable))completion;
        [Export("fetchPaymentMethodNonces:completion:")]
        void FetchPaymentMethodNonces(bool defaultFirst, [BlockCallback]FetchPaymentMethodNoncesCompletionBlock completion);

        // -(void)GET:(NSString * _Nonnull)path parameters:(NSDictionary<NSString *,NSString *> * _Nullable)parameters completion:(void (^ _Nullable)(BTJSON * _Nullable, NSHTTPURLResponse * _Nullable, NSError * _Nullable))completionBlock;
        [Export("GET:parameters:completion:")]
        void GET(string path, [NullAllowed] NSDictionary<NSString, NSString> parameters, [NullAllowed] [BlockCallback]BTJsonCompletionBlock completionBlock);

        // -(void)POST:(NSString * _Nonnull)path parameters:(NSDictionary * _Nullable)parameters completion:(void (^ _Nullable)(BTJSON * _Nullable, NSHTTPURLResponse * _Nullable, NSError * _Nullable))completionBlock;
        [Export("POST:parameters:completion:")]
        void POST(string path, [NullAllowed] NSDictionary parameters, [NullAllowed] [BlockCallback]BTJsonCompletionBlock completionBlock);
    }

    // @interface BTAppSwitch : NSObject
    [BaseType(typeof(NSObject))]
    interface BTAppSwitch
    {
        // @property (copy, nonatomic) NSString * _Nonnull returnURLScheme;
        [Export("returnURLScheme")]
        string ReturnURLScheme { get; set; }

        // +(instancetype _Nonnull)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        BTAppSwitch SharedInstance();

        // +(void)setReturnURLScheme:(NSString * _Nonnull)returnURLScheme;
        [Static]
        [Export("setReturnURLScheme:")]
        void SetReturnURLScheme(string returnURLScheme);

        // +(BOOL)handleOpenURL:(NSURL * _Nonnull)url sourceApplication:(NSString * _Nullable)sourceApplication;
        [Static]
        [Export("handleOpenURL:sourceApplication:")]
        bool HandleOpenURL2(NSUrl url, [NullAllowed] string sourceApplication);

        // +(BOOL)handleOpenURL:(NSURL * _Nonnull)url options:(NSDictionary * _Nonnull)options;
        [Static]
        [Export("handleOpenURL:options:")]
        bool HandleOpenURL(NSUrl url, NSDictionary options);

        // -(void)registerAppSwitchHandler:(Class<BTAppSwitchHandler> _Nonnull)handler;
        [Export("registerAppSwitchHandler:")]
        void RegisterAppSwitchHandler(IBTAppSwitchHandler handler);

        // -(void)unregisterAppSwitchHandler:(Class<BTAppSwitchHandler> _Nonnull)handler;
        [Export("unregisterAppSwitchHandler:")]
        void UnregisterAppSwitchHandler(IBTAppSwitchHandler handler);

        // -(BOOL)handleOpenURL:(NSURL * _Nonnull)url sourceApplication:(NSString * _Nonnull)sourceApplication;
        [Export("handleOpenURL:sourceApplication:")]
        bool HandleOpenURL(NSUrl url, string sourceApplication);
    }

    [Static]
    partial interface BTAppSwitchConstants
    {
        // extern NSString *const _Nonnull BTAppSwitchWillSwitchNotification;
        [Field("BTAppSwitchWillSwitchNotification", "__Internal")]
        NSString WillSwitchNotification { get; }

        // extern NSString *const _Nonnull BTAppSwitchDidSwitchNotification;
        [Field("BTAppSwitchDidSwitchNotification", "__Internal")]
        NSString DidSwitchNotification { get; }

        // extern NSString *const _Nonnull BTAppSwitchWillProcessPaymentInfoNotification;
        [Field("BTAppSwitchWillProcessPaymentInfoNotification", "__Internal")]
        NSString WillProcessPaymentInfoNotification { get; }

        // extern NSString *const _Nonnull BTAppSwitchNotificationTargetKey;
        [Field("BTAppSwitchNotificationTargetKey", "__Internal")]
        NSString NotificationTargetKey { get; }

        // extern NSString *const _Nonnull BTAppContextWillSwitchNotification;
        [Field("BTAppContextWillSwitchNotification", "__Internal")]
        NSString BTAppContextWillSwitchNotification { get; }

        // extern NSString *const _Nonnull BTAppContextDidReturnNotification;
        [Field("BTAppContextDidReturnNotification", "__Internal")]
        NSString BTAppContextDidReturnNotification { get; }
    }

    // @protocol BTAppSwitchDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface BTAppSwitchDelegate
    {
        // @required -(void)appSwitcherWillPerformAppSwitch:(id _Nonnull)appSwitcher;
        [Abstract]
        [Export("appSwitcherWillPerformAppSwitch:")]
        void AppSwitcherWillPerformAppSwitch(NSObject appSwitcher);

        // @required -(void)appSwitcher:(id _Nonnull)appSwitcher didPerformSwitchToTarget:(BTAppSwitchTarget)target;
        [Abstract]
        [Export("appSwitcher:didPerformSwitchToTarget:")]
        void AppSwitcher(NSObject appSwitcher, BTAppSwitchTarget target);

        // @required -(void)appSwitcherWillProcessPaymentInfo:(id _Nonnull)appSwitcher;
        [Abstract]
        [Export("appSwitcherWillProcessPaymentInfo:")]
        void AppSwitcherWillProcessPaymentInfo(NSObject appSwitcher);

        // @optional -(void)appContextWillSwitch:(id _Nonnull)appSwitcher;
        [Export("appContextWillSwitch:")]
        void AppContextWillSwitch(NSObject appSwitcher);

        // @optional -(void)appContextDidReturn:(id _Nonnull)appSwitcher;
        [Export("appContextDidReturn:")]
        void AppContextDidReturn(NSObject appSwitcher);
    }

    // @protocol BTAppSwitchHandler
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface BTAppSwitchHandler
    {
        // @required +(BOOL)canHandleAppSwitchReturnURL:(NSURL * _Nonnull)url sourceApplication:(NSString * _Nonnull)sourceApplication;
        //TODO Static method inside Protocol
        [Abstract]
        [Export("canHandleAppSwitchReturnURL:sourceApplication:")]
        bool CanHandleAppSwitchReturnURL(NSUrl url, string sourceApplication);

        // @required +(void)handleAppSwitchReturnURL:(NSURL * _Nonnull)url;
        //TODO Static method inside Protocol
        [Abstract]
        [Export("handleAppSwitchReturnURL:")]
        void HandleAppSwitchReturnURL(NSUrl url);

        // @optional -(BOOL)isiOSAppAvailableForAppSwitch;
        [Export("isiOSAppAvailableForAppSwitch")]
        bool IsiOSAppAvailableForAppSwitch { get; }
    }

    // @interface BTBinData : NSObject
    [BaseType(typeof(NSObject))]
    interface BTBinData
    {
        /*!
         @brief Create a `BTBinData` object from JSON.
         */
        // - (instancetype)initWithJSON:(BTJSON *)json;
        [Export("initWithJSON:")]
        IntPtr Constructor(BTJSON json);

        /*!
         @brief Whether the card is a prepaid card. Possible values: Yes/No/Unknown
         */
        // @property (nonatomic, nullable, readonly, copy) NSString *prepaid;
        [NullAllowed, Export("prepaid", ArgumentSemantic.Copy)]
        string Prepaid { get; }

        /*!
         @brief Whether the card is a healthcare card. Possible values: Yes/No/Unknown
         */
        // @property (nonatomic, nullable, readonly, copy) NSString *healthcare;
        [NullAllowed, Export("healthcare", ArgumentSemantic.Copy)]
        string Healthcare { get; }

        /*!
         @brief Whether the card is a debit card. Possible values: Yes/No/Unknown
         */
        // @property (nonatomic, nullable, readonly, copy) NSString *debit;
        [NullAllowed, Export("debit", ArgumentSemantic.Copy)]
        string debit { get; }

        /*!
         @brief A value indicating whether the issuing bank's card range is regulated by the Durbin Amendment due to the bank's assets. Possible values: Yes/No/Unknown
         */
        // @property (nonatomic, nullable, readonly, copy) NSString *durbinRegulated;
        [NullAllowed, Export("durbinRegulated", ArgumentSemantic.Copy)]
        string DurbinRegulated { get; }

        /*!
         @brief Whether the card type is a commercial card and is capable of processing Level 2 transactions. Possible values: Yes/No/Unknown
         */
        // @property (nonatomic, nullable, readonly, copy) NSString *commercial;
        [NullAllowed, Export("commercial", ArgumentSemantic.Copy)]
        string Commercial { get; }

        /*!
         @brief Whether the card is a payroll card. Possible values: Yes/No/Unknown
         */
        // @property (nonatomic, nullable, readonly, copy) NSString *payroll;
        [NullAllowed, Export("payroll", ArgumentSemantic.Copy)]
        string Payroll { get; }

        /*!
         @brief The bank that issued the credit card, if available.
         */
        // @property (nonatomic, nullable, readonly, copy) NSString *issuingBank;
        [NullAllowed, Export("issuingBank", ArgumentSemantic.Copy)]
        string IssuingBank { get; }

        /*!
         @brief The country that issued the credit card, if available.
         */
        //@property(nonatomic, nullable, readonly, copy) NSString* countryOfIssuance;
        [NullAllowed, Export("countryOfIssuance", ArgumentSemantic.Copy)]
        string CountryOfIssuance { get; }

        /*!
         @brief The code for the product type of the card (e.g. `D` (Visa Signature Preferred), `G` (Visa Business)), if available.
         */
        //@property (nonatomic, nullable, readonly, copy) NSString *productId;
        [NullAllowed, Export("productId", ArgumentSemantic.Copy)]
        string productId { get; }
    }

    [Static]
    partial interface BTClientTokenConstants
    {
        // extern NSString *const _Nonnull BTClientTokenKeyVersion;
        [Field("BTClientTokenKeyVersion", "__Internal")]
        NSString KeyVersion { get; }

        // extern NSString *const _Nonnull BTClientTokenErrorDomain;
        [Field("BTClientTokenErrorDomain", "__Internal")]
        NSString ErrorDomain { get; }

        // extern NSString *const _Nonnull BTClientTokenKeyAuthorizationFingerprint;
        [Field("BTClientTokenKeyAuthorizationFingerprint", "__Internal")]
        NSString KeyAuthorizationFingerprint { get; }

        // extern NSString *const _Nonnull BTClientTokenKeyConfigURL;
        [Field("BTClientTokenKeyConfigURL", "__Internal")]
        NSString KeyConfigURL { get; }
    }

    // @interface BTClientToken : NSObject <NSCoding, NSCopying>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface BTClientToken : INSCoding, INSCopying
    {
        // @property (readonly, nonatomic, strong) BTJSON * _Nonnull json;
        [Export("json", ArgumentSemantic.Strong)]
        BTJSON Json { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull authorizationFingerprint;
        [Export("authorizationFingerprint")]
        string AuthorizationFingerprint { get; }

        // @property (readonly, nonatomic, strong) NSURL * _Nonnull configURL;
        [Export("configURL", ArgumentSemantic.Strong)]
        NSUrl ConfigURL { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull originalValue;
        [Export("originalValue")]
        string OriginalValue { get; }

        // -(instancetype _Nullable)initWithClientToken:(NSString * _Nonnull)clientToken error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
        [Export("initWithClientToken:error:")]
        [DesignatedInitializer]
        IntPtr Constructor(string clientToken, [NullAllowed] out NSError error);
    }

    [Static]
    partial interface BTErrorConstants
    {
        // extern NSString *const _Nonnull BTCustomerInputBraintreeValidationErrorsKey;
        [Field("BTCustomerInputBraintreeValidationErrorsKey", "__Internal")]
        NSString BTCustomerInputBraintreeValidationErrorsKey { get; }

        // extern NSString *const BTHTTPErrorDomain;
        [Field("BTHTTPErrorDomain", "__Internal")]
        NSString BTHTTPErrorDomain { get; }

        // extern NSString *const BTHTTPURLResponseKey;
        [Field("BTHTTPURLResponseKey", "__Internal")]
        NSString BTHTTPURLResponseKey { get; }

        // extern NSString *const BTHTTPJSONResponseBodyKey;
        [Field("BTHTTPJSONResponseBodyKey", "__Internal")]
        NSString BTHTTPJSONResponseBodyKey { get; }
    }

    // @interface BTLogger : NSObject
    [BaseType(typeof(NSObject))]
    interface BTLogger
    {
        // +(instancetype)sharedLogger;
        [Static]
        [Export("sharedLogger")]
        BTLogger SharedLogger();

        // @property (assign, nonatomic) BTLogLevel level;
        [Export("level", ArgumentSemantic.Assign)]
        BTLogLevel Level { get; set; }
    }

    // @interface BTPostalAddress : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    interface BTPostalAddress : INSCopying
    {
        // @property (copy, nonatomic) NSString * _Nullable recipientName;
        [NullAllowed, Export("recipientName")]
        string RecipientName { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable streetAddress;
        [NullAllowed, Export("streetAddress")]
        string StreetAddress { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable extendedAddress;
        [NullAllowed, Export("extendedAddress")]
        string ExtendedAddress { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable locality;
        [NullAllowed, Export("locality")]
        string Locality { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable countryCodeAlpha2;
        [NullAllowed, Export("countryCodeAlpha2")]
        string CountryCodeAlpha2 { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable postalCode;
        [NullAllowed, Export("postalCode")]
        string PostalCode { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable region;
        [NullAllowed, Export("region")]
        string Region { get; set; }
    }

    // @interface BTPaymentMethodNonce : NSObject
    [BaseType(typeof(NSObject))]
    interface BTPaymentMethodNonce : INativeObject
    {
        // -(instancetype _Nullable)initWithNonce:(NSString * _Nonnull)nonce localizedDescription:(NSString * _Nullable)description type:(NSString * _Nonnull)type;
        [Export("initWithNonce:localizedDescription:type:")]
        IntPtr Constructor(string nonce, [NullAllowed] string description, string type);

        // -(instancetype _Nullable)initWithNonce:(NSString * _Nonnull)nonce localizedDescription:(NSString * _Nullable)description;
        [Export("initWithNonce:localizedDescription:")]
        IntPtr Constructor(string nonce, [NullAllowed] string description);

        // -(instancetype _Nullable)initWithNonce:(NSString * _Nonnull)nonce localizedDescription:(NSString * _Nonnull)description type:(NSString * _Nonnull)type isDefault:(BOOL)isDefault;
        [Export("initWithNonce:localizedDescription:type:isDefault:")]
        IntPtr Constructor(string nonce, string description, string type, bool isDefault);

        // @property (readonly, copy, nonatomic) NSString * _Nonnull nonce;
        [Export("nonce")]
        string Nonce { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull localizedDescription;
        [Export("localizedDescription")]
        string LocalizedDescription { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull type;
        [Export("type")]
        string Type { get; }

        // @property (readonly, assign, nonatomic) BOOL isDefault;
        [Export("isDefault")]
        bool IsDefault { get; }
    }

    // @interface BTPaymentMethodNonceParser : NSObject
    [BaseType(typeof(NSObject))]
    interface BTPaymentMethodNonceParser
    {
        // +(instancetype _Nonnull)sharedParser;
        [Static]
        [Export("sharedParser")]
        BTPaymentMethodNonceParser SharedParser();

        // @property (readonly, nonatomic, strong) NSArray<NSString *> * _Nonnull allTypes;
        [Export("allTypes", ArgumentSemantic.Strong)]
        string[] AllTypes { get; }

        // -(BOOL)isTypeAvailable:(NSString * _Nonnull)type;
        [Export("isTypeAvailable:")]
        bool IsTypeAvailable(string type);

        // -(void)registerType:(NSString * _Nonnull)type withParsingBlock:(BTPaymentMethodNonce * _Nullable (^ _Nonnull)(BTJSON * _Nonnull))jsonParsingBlock;
        [Export("registerType:withParsingBlock:")]
        void RegisterType(string type, Func<BTJSON, BTPaymentMethodNonce> jsonParsingBlock);

        // -(BTPaymentMethodNonce * _Nullable)parseJSON:(BTJSON * _Nonnull)json withParsingBlockForType:(NSString * _Nonnull)type;
        [Export("parseJSON:withParsingBlockForType:")]
        [return: NullAllowed]
        BTPaymentMethodNonce ParseJSON(BTJSON json, string type);
    }

    [Static]
    partial interface BTTokenizationServiceConstants
    {
        // extern NSString *const _Nonnull BTTokenizationServiceErrorDomain;
        [Field("BTTokenizationServiceErrorDomain", "__Internal")]
        NSString ErrorDomain { get; }

        // extern NSString *const _Nonnull BTTokenizationServiceAppSwitchDelegateOption;
        [Field("BTTokenizationServiceAppSwitchDelegateOption", "__Internal")]
        NSString AppSwitchDelegateOption { get; }

        // extern NSString *const _Nonnull BTTokenizationServiceViewPresentingDelegateOption;
        [Field("BTTokenizationServiceViewPresentingDelegateOption", "__Internal")]
        NSString ViewPresentingDelegateOption { get; }

        // extern NSString *const _Nonnull BTTokenizationServicePayPalScopesOption;
        [Field("BTTokenizationServicePayPalScopesOption", "__Internal")]
        NSString PayPalScopesOption { get; }

        // extern NSString *const _Nonnull BTTokenizationServiceAmountOption;
        [Field("BTTokenizationServiceAmountOption", "__Internal")]
        NSString AmountOption { get; }

        // extern NSString *const _Nonnull BTTokenizationServiceNonceOption;
        [Field("BTTokenizationServiceNonceOption", "__Internal")]
        NSString NonceOption { get; }
    }

    // @interface BTTokenizationService : NSObject
    [BaseType(typeof(NSObject))]
    interface BTTokenizationService
    {
        // +(instancetype _Nonnull)sharedService;
        [Static]
        [Export("sharedService")]
        BTTokenizationService SharedService();

        // -(void)registerType:(NSString * _Nonnull)type withTokenizationBlock:(void (^ _Nonnull)(BTAPIClient * _Nonnull, NSDictionary * _Nullable, void (^ _Nonnull)(BTPaymentMethodNonce * _Nullable, NSError * _Nullable)))tokenizationBlock;
        [Export("registerType:withTokenizationBlock:")]
        void RegisterType(string type, [BlockCallback]RegisterTokenizationCompleteBlock tokenizationBlock);

        // -(BOOL)isTypeAvailable:(NSString * _Nonnull)type;
        [Export("isTypeAvailable:")]
        bool IsTypeAvailable(string type);

        // -(void)tokenizeType:(NSString * _Nonnull)type withAPIClient:(BTAPIClient * _Nonnull)apiClient completion:(void (^ _Nonnull)(BTPaymentMethodNonce * _Nullable, NSError * _Nullable))completion;
        [Export("tokenizeType:withAPIClient:completion:")]
        void TokenizeType(string type, BTAPIClient apiClient, [BlockCallback]GetTokenizationCompletionblock completion);

        // -(void)tokenizeType:(NSString * _Nonnull)type options:(NSDictionary<NSString *,id> * _Nullable)options withAPIClient:(BTAPIClient * _Nonnull)apiClient completion:(void (^ _Nonnull)(BTPaymentMethodNonce * _Nullable, NSError * _Nullable))completion;
        [Export("tokenizeType:options:withAPIClient:completion:")]
        void TokenizeType(string type, [NullAllowed] NSDictionary<NSString, NSObject> options, BTAPIClient apiClient, [BlockCallback]GetTokenizationCompletionblock completion);

        // @property (readonly, nonatomic, strong) NSArray<NSString *> * _Nonnull allTypes;
        [Export("allTypes", ArgumentSemantic.Strong)]
        string[] AllTypes { get; }
    }

    // @protocol BTViewControllerPresentingDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface BTViewControllerPresentingDelegate
    {
        // @required -(void)paymentDriver:(id _Nonnull)driver requestsPresentationOfViewController:(UIViewController * _Nonnull)viewController;
        [Abstract]
        [Export("paymentDriver:requestsPresentationOfViewController:")]
        void RequestsPresentationOfViewController(NSObject driver, UIViewController viewController);

        // @required -(void)paymentDriver:(id _Nonnull)driver requestsDismissalOfViewController:(UIViewController * _Nonnull)viewController;
        [Abstract]
        [Export("paymentDriver:requestsDismissalOfViewController:")]
        void RequestsDismissalOfViewController(NSObject driver, UIViewController viewController);
    }

    // @interface BTPreferredPaymentMethodsResult : NSObject
    [BaseType(typeof(NSObject))]
    interface BTPreferredPaymentMethodsResult
    {
        // @property (readonly, assign, nonatomic) BOOL isPayPalPreferred;
        [Export("isPayPalPreferred")]
        bool IsPayPalPreferred { get; }
    }

    // @interface BTPreferredPaymentMethods : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface BTPreferredPaymentMethods
    {
        // -(instancetype _Nonnull)initWithAPIClient:(BTAPIClient * _Nonnull)apiClient __attribute__((objc_designated_initializer));
        [Export("initWithAPIClient:")]
        [DesignatedInitializer]
        IntPtr Constructor(BTAPIClient apiClient);

        // -(void)fetchPreferredPaymentMethods:(void (^ _Nonnull)(BTPreferredPaymentMethodsResult * _Nonnull))completion;
        [Export("fetchPreferredPaymentMethods:")]
        void FetchPreferredPaymentMethods(Action<BTPreferredPaymentMethodsResult> completion);
    }
}
