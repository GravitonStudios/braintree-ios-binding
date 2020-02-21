using System;
using BraintreeCard;
using BraintreeCore;
using BraintreePaymentFlow;
using CardinalMobile;
using Foundation;
using ObjCRuntime;

namespace BraintreePaymentFlow
{
    //    @interface BTPaymentFlowRequest : NSObject
    [BaseType(typeof(NSObject))]
    interface BTPaymentFlowRequest { }

    //@interface BTPaymentFlowResult : NSObject
    [BaseType(typeof(NSObject))]
    interface BTPaymentFlowResult { }

    [Static]
    partial interface BTPaymentFlowDriverConstants
    {
        // extern NSString *const _Nonnull BTPaymentFlowDriverErrorDomain;
        [Field("BTPaymentFlowDriverErrorDomain", "__Internal")]
        NSString ErrorDomain { get; }
    }

    partial interface IBTPaymentFlowDriverDelegate { }

    //    /**
    // @brief Protocol for payment flow processing via BTPaymentFlowRequestDelegate.
    // */
    //    @protocol BTPaymentFlowDriverDelegate
    [Protocol, BaseType(typeof(NSObject))]
    interface BTPaymentFlowDriverDelegate
    {
        ///**
        // @brief Use when payment URL is ready for processing.
        // */
        //- (void) onPaymentWithURL:(NSURL* _Nullable) url error:(NSError* _Nullable) error;
        [Export("onPaymentWithURL:error:")]
        void OnPaymentWithURL(NSUrl url, NSError error);

        ///**
        // @brief Use when the payment flow was cancelled.
        // */
        //- (void) onPaymentCancel;
        [Export("onPaymentCancel")]
        void OnPaymentCancel();

        ///**
        // @brief Use when the payment flow has completed or encountered an error.
        // @param result The BTPaymentFlowResult of the payment flow.
        // @param error NSError containing details of the error.
        // */
        //- (void) onPaymentComplete:(BTPaymentFlowResult* _Nullable) result error:(NSError* _Nullable) error;
        [Export("onPaymentComplete:error:")]
        void OnPaymentComplete(BTPaymentFlowResult result, NSError error);

        ///**
        // @brief Returns the base return URL scheme used by the driver.
        // @return A NSString representing the base return URL scheme used by the driver.
        // */
        //- (NSString*) returnURLScheme;
        [Export("returnURLScheme")]
        string returnURLScheme();

        ///**
        // @brief Returns the BTAPIClient used by the BTPaymentFlowDriverDelegate.
        // @return The BTAPIClient used by the driver.
        // */
        //- (BTAPIClient*) apiClient;
        [Export("apiClient")]
        BTAPIClient ApiClient();
    }

    //    /**
    //     @brief Protocol for payment flow processing.
    //     */
    //    @protocol BTPaymentFlowRequestDelegate
    [Protocol, BaseType(typeof(NSObject))]
    interface BTPaymentFlowRequestDelegate
    {

        ///**
        // @brief Handle payment request for a variety of web/app switch flows.

        // @discussion Use the delegate to handle success/error/cancel flows.

        // @param request A BTPaymentFlowRequest request.
        // @param delegate The BTPaymentFlowDriverDelegate to handle response.
        // */
        //- (void) handleRequest:(BTPaymentFlowRequest*) request client:(BTAPIClient*) apiClient paymentDriverDelegate:(id<BTPaymentFlowDriverDelegate>) delegate;
        [Export("handleRequest:client:paymentDriverDelegate:")]
        void HandleRequest(BTPaymentFlowRequest request, BTAPIClient client, BTPaymentFlowDriverDelegate @delegate);

        ///**
        // @brief Check if this BTPaymentFlowRequestDelegate can handle the URL from the source application.

        // @param url The URL to check.
        // @param sourceApplication The source application to sent the URL.
        // @return True if the BTPaymentFlowRequestDelegate can handle the URL. Otherwise return false.
        // */
        //- (BOOL) canHandleAppSwitchReturnURL:(NSURL*) url sourceApplication:(NSString*) sourceApplication;
        [Export("canHandleAppSwitchReturnURL:sourceApplication:")]
        bool CanHandleAppSwitchReturnURL(NSUrl url, string sourceApplication);

        ///**
        // @brief Handles the return URL and completes and post processing.

        // @param url The URL to check.
        // */
        //- (void) handleOpenURL:(NSURL*) url;
        [Export("handleOpenURL:")]
        void HandleOpenURL(NSUrl url);

        ///**
        // @brief A short and unique alphanumeric name for the payment flow.

        // @discussion Used for analytics/events. No spaces and all lowercase.
        // */
        //- (NSString*) paymentFlowName;
        [Export("paymentFlowName")]
        string PaymentFlowName();
    }

    //    /**
    //     @brief BTPaymentFlowDriver handles the shared aspects of web/app payment flows.

    //     @discussion Handles the app switching and shared logic for payment flows that use web or app switching.
    //     */
    //    @interface BTPaymentFlowDriver : NSObject<BTAppSwitchHandler, BTPaymentFlowDriverDelegate>
    [BaseType(typeof(NSObject)), DisableDefaultCtor]
    interface BTPaymentFlowDriver : IBTAppSwitchHandler, BTPaymentFlowDriverDelegate
    {

        ///**
        // @brief Initialize a new BTPaymentFlowDriver instance.

        // @param apiClient The API client.
        // */
        //- (instancetype) initWithAPIClient:(BTAPIClient*) apiClient NS_DESIGNATED_INITIALIZER;
        [Export("initWithAPIClient:"), DesignatedInitializer]
        BTPaymentFlowDriver Constructor(BTAPIClient client);

        //- (instancetype) init __attribute__((unavailable("Please use initWithAPIClient:")));

        ///**
        // @brief Starts a payment flow using a BTPaymentFlowRequest (usually subclassed for specific payment methods).

        // @param request A BTPaymentFlowRequest request.
        // @param completionBlock This completion will be invoked exactly once when the payment flow is complete or an error occurs.
        // */
        //- (void) startPaymentFlow:(BTPaymentFlowRequest<BTPaymentFlowRequestDelegate>*) request completion:(void (^)(BTPaymentFlowResult* _Nullable result, NSError * _Nullable error))completionBlock;
        [Export("startPaymentFlow:completion:")]
        void StartPaymentFlow(BTPaymentFlowRequest request, Action<BTPaymentFlowResult, NSError> completion);

		///**
		// @brief A required delegate to control the presentation and dismissal of view controllers.
		// */
		//@property(nonatomic, weak, nullable) id<BTViewControllerPresentingDelegate> viewControllerPresentingDelegate;
		//[Export("viewControllerPresentingDelegate", ArgumentSemantic.Weak), NullAllowed]
		//BTViewControllerPresentingDelegate ViewControllerPresentingDelegate { get; set; }

		[Wrap("WeakViewControllerPresentingDelegate")]
		[NullAllowed]
		BTViewControllerPresentingDelegate ViewControllerPresentingDelegate { get; set; }

		// @property (nonatomic, weak) id<BTViewControllerPresentingDelegate> _Nullable viewControllerPresentingDelegate;
		[NullAllowed, Export("viewControllerPresentingDelegate", ArgumentSemantic.Weak)]
		NSObject WeakViewControllerPresentingDelegate { get; set; }

		[Wrap("WeakAppSwitchDelegate")]
        [NullAllowed]
        BTAppSwitchDelegate AppSwitchDelegate { get; set; }

        // @property (nonatomic, weak) id<BTAppSwitchDelegate> _Nullable appSwitchDelegate;
        [NullAllowed, Export("appSwitchDelegate", ArgumentSemantic.Weak)]
        NSObject WeakAppSwitchDelegate { get; set; }
    }

    // @interface LocalPayment (BTConfiguration)
    [Category]
    [BaseType(typeof(BTConfiguration))]
    interface BTConfiguration_LocalPayment
    {
        // @property (readonly, assign, nonatomic) BOOL isLocalPaymentEnabled;
        [Static, Export("isLocalPaymentEnabled")]
        bool IsLocalPaymentEnabled { get; }
    }

    // @interface BTLocalPaymentResult : BTPaymentFlowResult
    [BaseType(typeof(BTPaymentFlowResult))]
    interface BTLocalPaymentResult
    {
        // @property (readonly, nonatomic, strong) BTPostalAddress * _Nullable billingAddress;
        [NullAllowed, Export("billingAddress", ArgumentSemantic.Strong)]
        BTPostalAddress BillingAddress { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable clientMetadataId;
        [NullAllowed, Export("clientMetadataId")]
        string ClientMetadataId { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable email;
        [NullAllowed, Export("email")]
        string Email { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable firstName;
        [NullAllowed, Export("firstName")]
        string FirstName { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable lastName;
        [NullAllowed, Export("lastName")]
        string LastName { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull localizedDescription;
        [Export("localizedDescription")]
        string LocalizedDescription { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull nonce;
        [Export("nonce")]
        string Nonce { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable payerId;
        [NullAllowed, Export("payerId")]
        string PayerId { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable phone;
        [NullAllowed, Export("phone")]
        string Phone { get; }

        // @property (readonly, nonatomic, strong) BTPostalAddress * _Nullable shippingAddress;
        [NullAllowed, Export("shippingAddress", ArgumentSemantic.Strong)]
        BTPostalAddress ShippingAddress { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull type;
        [Export("type")]
        string Type { get; }

        // -(instancetype _Nonnull)initWithNonce:(NSString * _Nonnull)nonce description:(NSString * _Nonnull)description type:(NSString * _Nonnull)type email:(NSString * _Nonnull)email firstName:(NSString * _Nonnull)firstName lastName:(NSString * _Nonnull)lastName phone:(NSString * _Nonnull)phone billingAddress:(BTPostalAddress * _Nonnull)billingAddress shippingAddress:(BTPostalAddress * _Nonnull)shippingAddress clientMetadataId:(NSString * _Nonnull)clientMetadataId payerId:(NSString * _Nonnull)payerId;
        [Export("initWithNonce:description:type:email:firstName:lastName:phone:billingAddress:shippingAddress:clientMetadataId:payerId:")]
        IntPtr Constructor(string nonce, string description, string type, string email, string firstName, string lastName, string phone, BTPostalAddress billingAddress, BTPostalAddress shippingAddress, string clientMetadataId, string payerId);
    }

    // @interface BTLocalPaymentRequest : BTPaymentFlowRequest <BTPaymentFlowRequestDelegate>
    [BaseType(typeof(BTPaymentFlowRequest))]
    interface BTLocalPaymentRequest : BTPaymentFlowRequestDelegate
    {
        // @property (copy, nonatomic) NSString * _Nullable paymentType;
        [NullAllowed, Export("paymentType")]
        string PaymentType { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable merchantAccountId;
        [NullAllowed, Export("merchantAccountId")]
        string MerchantAccountId { get; set; }

        // @property (copy, nonatomic) BTPostalAddress * _Nullable address;
        [NullAllowed, Export("address", ArgumentSemantic.Copy)]
        BTPostalAddress Address { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable amount;
        [NullAllowed, Export("amount")]
        string Amount { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable currencyCode;
        [NullAllowed, Export("currencyCode")]
        string CurrencyCode { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable email;
        [NullAllowed, Export("email")]
        string Email { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable givenName;
        [NullAllowed, Export("givenName")]
        string GivenName { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable surname;
        [NullAllowed, Export("surname")]
        string Surname { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable phone;
        [NullAllowed, Export("phone")]
        string Phone { get; set; }

        // @property (getter = isShippingAddressRequired, nonatomic) BOOL shippingAddressRequired;
        [Export("shippingAddressRequired")]
        bool ShippingAddressRequired { [Bind("isShippingAddressRequired")] get; set; }

        [Wrap("WeakLocalPaymentFlowDelegate")]
        [NullAllowed]
        BTLocalPaymentRequestDelegate LocalPaymentFlowDelegate { get; set; }

        // @property (nonatomic, weak) id<BTLocalPaymentRequestDelegate> _Nullable localPaymentFlowDelegate;
        [NullAllowed, Export("localPaymentFlowDelegate", ArgumentSemantic.Weak)]
        NSObject WeakLocalPaymentFlowDelegate { get; set; }
    }

    // @protocol BTLocalPaymentRequestDelegate
    [Protocol, BaseType(typeof(NSObject))]
    interface BTLocalPaymentRequestDelegate
    {
        // @required -(void)localPaymentStarted:(BTLocalPaymentRequest * _Nonnull)request paymentId:(NSString * _Nonnull)paymentId start:(void (^ _Nonnull)(void))start;
        [Abstract]
        [Export("localPaymentStarted:paymentId:start:")]
        void PaymentId(BTLocalPaymentRequest request, string paymentId, Action start);
    }

    // @interface LocalPayment (BTPaymentFlowDriver)
    [Category]
    [BaseType(typeof(BTPaymentFlowDriver))]
    interface BTPaymentFlowDriver_LocalPayment
    {
    }

	// @interface BTThreeDSecureResult : BTPaymentFlowResult
	[BaseType(typeof(BTPaymentFlowResult))]
	interface BTThreeDSecureResult
	{
		// @property (assign, nonatomic) BOOL success __attribute__((deprecated("Use `tokenizedCard.threeDSecureInfo.liabilityShiftPossible` and `tokenizedCard.threeDSecureInfo.liabilityShifted` instead.")));
		[Export("success")]
		bool Success { get; set; }

		// @property (assign, nonatomic) BOOL liabilityShifted __attribute__((deprecated("Use `tokenizedCard.threeDSecureInfo.liabilityShifted` instead.")));
		[Export("liabilityShifted")]
		bool LiabilityShifted { get; set; }

		// @property (assign, nonatomic) BOOL liabilityShiftPossible __attribute__((deprecated("Use `tokenizedCard.threeDSecureInfo.liabilityShiftPossible` instead.")));
		[Export("liabilityShiftPossible")]
		bool LiabilityShiftPossible { get; set; }

		// @property (nonatomic, strong) BTCardNonce * tokenizedCard;
		[Export("tokenizedCard", ArgumentSemantic.Strong)]
		BTCardNonce TokenizedCard { get; set; }

		// @property (copy, nonatomic) NSString * errorMessage __attribute__((deprecated("Use `tokenizedCard.threeDSecureInfo.errorMessage` instead.")));
		[Export("errorMessage")]
		string ErrorMessage { get; set; }

		// -(instancetype)initWithJSON:(BTJSON *)JSON;
		[Export("initWithJSON:")]
		IntPtr Constructor(BTJSON JSON);
	}

	// @interface BTThreeDSecurePostalAddress : NSObject <NSCopying>
	[BaseType(typeof(NSObject))]
	interface BTThreeDSecurePostalAddress : INSCopying
	{
		// @property (copy, nonatomic) NSString * _Nullable givenName;
		[NullAllowed, Export("givenName")]
		string GivenName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable surname;
		[NullAllowed, Export("surname")]
		string Surname { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable streetAddress;
		[NullAllowed, Export("streetAddress")]
		string StreetAddress { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable extendedAddress;
		[NullAllowed, Export("extendedAddress")]
		string ExtendedAddress { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable line3;
		[NullAllowed, Export("line3")]
		string Line3 { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable locality;
		[NullAllowed, Export("locality")]
		string Locality { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable region;
		[NullAllowed, Export("region")]
		string Region { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable postalCode;
		[NullAllowed, Export("postalCode")]
		string PostalCode { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable countryCodeAlpha2;
		[NullAllowed, Export("countryCodeAlpha2")]
		string CountryCodeAlpha2 { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable phoneNumber;
		[NullAllowed, Export("phoneNumber")]
		string PhoneNumber { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable firstName __attribute__((deprecated("Use givenName instead.")));
		[NullAllowed, Export("firstName")]
		string FirstName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable lastName __attribute__((deprecated("Use surname instead.")));
		[NullAllowed, Export("lastName")]
		string LastName { get; set; }
	}

	// @interface BTThreeDSecureAdditionalInformation : NSObject
	[BaseType(typeof(NSObject))]
	interface BTThreeDSecureAdditionalInformation
	{
		// @property (copy, nonatomic) BTThreeDSecurePostalAddress * _Nullable shippingAddress;
		[NullAllowed, Export("shippingAddress", ArgumentSemantic.Copy)]
		BTThreeDSecurePostalAddress ShippingAddress { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable shippingMethodIndicator;
		[NullAllowed, Export("shippingMethodIndicator")]
		string ShippingMethodIndicator { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable productCode;
		[NullAllowed, Export("productCode")]
		string ProductCode { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable deliveryTimeframe;
		[NullAllowed, Export("deliveryTimeframe")]
		string DeliveryTimeframe { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable deliveryEmail;
		[NullAllowed, Export("deliveryEmail")]
		string DeliveryEmail { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable reorderIndicator;
		[NullAllowed, Export("reorderIndicator")]
		string ReorderIndicator { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable preorderIndicator;
		[NullAllowed, Export("preorderIndicator")]
		string PreorderIndicator { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable preorderDate;
		[NullAllowed, Export("preorderDate")]
		string PreorderDate { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable giftCardAmount;
		[NullAllowed, Export("giftCardAmount")]
		string GiftCardAmount { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable giftCardCurrencyCode;
		[NullAllowed, Export("giftCardCurrencyCode")]
		string GiftCardCurrencyCode { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable giftCardCount;
		[NullAllowed, Export("giftCardCount")]
		string GiftCardCount { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable accountAgeIndicator;
		[NullAllowed, Export("accountAgeIndicator")]
		string AccountAgeIndicator { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable accountCreateDate;
		[NullAllowed, Export("accountCreateDate")]
		string AccountCreateDate { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable accountChangeIndicator;
		[NullAllowed, Export("accountChangeIndicator")]
		string AccountChangeIndicator { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable accountChangeDate;
		[NullAllowed, Export("accountChangeDate")]
		string AccountChangeDate { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable accountPwdChangeIndicator;
		[NullAllowed, Export("accountPwdChangeIndicator")]
		string AccountPwdChangeIndicator { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable accountPwdChangeDate;
		[NullAllowed, Export("accountPwdChangeDate")]
		string AccountPwdChangeDate { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable shippingAddressUsageIndicator;
		[NullAllowed, Export("shippingAddressUsageIndicator")]
		string ShippingAddressUsageIndicator { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable shippingAddressUsageDate;
		[NullAllowed, Export("shippingAddressUsageDate")]
		string ShippingAddressUsageDate { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable transactionCountDay;
		[NullAllowed, Export("transactionCountDay")]
		string TransactionCountDay { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable transactionCountYear;
		[NullAllowed, Export("transactionCountYear")]
		string TransactionCountYear { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable addCardAttempts;
		[NullAllowed, Export("addCardAttempts")]
		string AddCardAttempts { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable accountPurchases;
		[NullAllowed, Export("accountPurchases")]
		string AccountPurchases { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable fraudActivity;
		[NullAllowed, Export("fraudActivity")]
		string FraudActivity { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable shippingNameIndicator;
		[NullAllowed, Export("shippingNameIndicator")]
		string ShippingNameIndicator { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable paymentAccountIndicator;
		[NullAllowed, Export("paymentAccountIndicator")]
		string PaymentAccountIndicator { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable paymentAccountAge;
		[NullAllowed, Export("paymentAccountAge")]
		string PaymentAccountAge { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable addressMatch;
		[NullAllowed, Export("addressMatch")]
		string AddressMatch { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable accountId;
		[NullAllowed, Export("accountId")]
		string AccountId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable ipAddress;
		[NullAllowed, Export("ipAddress")]
		string IpAddress { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable orderDescription;
		[NullAllowed, Export("orderDescription")]
		string OrderDescription { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable taxAmount;
		[NullAllowed, Export("taxAmount")]
		string TaxAmount { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable userAgent;
		[NullAllowed, Export("userAgent")]
		string UserAgent { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable authenticationIndicator;
		[NullAllowed, Export("authenticationIndicator")]
		string AuthenticationIndicator { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable installment;
		[NullAllowed, Export("installment")]
		string Installment { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable purchaseDate;
		[NullAllowed, Export("purchaseDate")]
		string PurchaseDate { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable recurringEnd;
		[NullAllowed, Export("recurringEnd")]
		string RecurringEnd { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable recurringFrequency;
		[NullAllowed, Export("recurringFrequency")]
		string RecurringFrequency { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable sdkMaxTimeout;
		[NullAllowed, Export("sdkMaxTimeout")]
		string SdkMaxTimeout { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable workPhoneNumber;
		[NullAllowed, Export("workPhoneNumber")]
		string WorkPhoneNumber { get; set; }
	}

	// @interface BTThreeDSecureLookup : BTPaymentFlowResult
	[BaseType(typeof(BTPaymentFlowResult))]
	interface BTThreeDSecureLookup
	{
		// @property (copy, nonatomic) NSString * PAReq;
		[Export("PAReq")]
		string PAReq { get; set; }

		// @property (copy, nonatomic) NSString * MD;
		[Export("MD")]
		string MD { get; set; }

		// @property (copy, nonatomic) NSURL * acsURL;
		[Export("acsURL", ArgumentSemantic.Copy)]
		NSUrl AcsURL { get; set; }

		// @property (copy, nonatomic) NSURL * termURL;
		[Export("termURL", ArgumentSemantic.Copy)]
		NSUrl TermURL { get; set; }

		// @property (copy, nonatomic) NSString * threeDSecureVersion;
		[Export("threeDSecureVersion")]
		string ThreeDSecureVersion { get; set; }

		// @property (readonly, nonatomic) BOOL isThreeDSecureVersion2;
		[Export("isThreeDSecureVersion2")]
		bool IsThreeDSecureVersion2 { get; }

		// @property (copy, nonatomic) NSString * transactionId;
		[Export("transactionId")]
		string TransactionId { get; set; }

		// @property (nonatomic, strong) BTThreeDSecureResult * threeDSecureResult;
		[Export("threeDSecureResult", ArgumentSemantic.Strong)]
		BTThreeDSecureResult ThreeDSecureResult { get; set; }

		// -(instancetype)initWithJSON:(BTJSON *)JSON;
		[Export("initWithJSON:")]
		IntPtr Constructor(BTJSON JSON);

		// -(BOOL)requiresUserAuthentication;
		[Export("requiresUserAuthentication")]
		bool RequiresUserAuthentication { get; }
	}

	// @interface BTThreeDSecureV1UICustomization : NSObject
	[BaseType(typeof(NSObject))]
	interface BTThreeDSecureV1UICustomization
	{
		// @property (copy, nonatomic) NSString * _Nullable redirectButtonText;
		[NullAllowed, Export("redirectButtonText")]
		string RedirectButtonText { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable redirectDescription;
		[NullAllowed, Export("redirectDescription")]
		string RedirectDescription { get; set; }
	}

	// @interface BTThreeDSecureRequest : BTPaymentFlowRequest <BTPaymentFlowRequestDelegate>
	[BaseType(typeof(BTPaymentFlowRequest))]
	interface BTThreeDSecureRequest : BTPaymentFlowRequestDelegate
	{
		// @property (copy, nonatomic) NSString * _Nonnull nonce;
		[Export("nonce")]
		string Nonce { get; set; }

		// @property (copy, nonatomic) NSDecimalNumber * _Nonnull amount;
		[Export("amount", ArgumentSemantic.Copy)]
		NSDecimalNumber Amount { get; set; }

		// @property (copy, nonatomic) BTThreeDSecurePostalAddress * _Nullable billingAddress;
		[NullAllowed, Export("billingAddress", ArgumentSemantic.Copy)]
		BTThreeDSecurePostalAddress BillingAddress { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable mobilePhoneNumber;
		[NullAllowed, Export("mobilePhoneNumber")]
		string MobilePhoneNumber { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable email;
		[NullAllowed, Export("email")]
		string Email { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable shippingMethod;
		[NullAllowed, Export("shippingMethod")]
		string ShippingMethod { get; set; }

		// @property (nonatomic, strong) BTThreeDSecureAdditionalInformation * _Nullable additionalInformation;
		[NullAllowed, Export("additionalInformation", ArgumentSemantic.Strong)]
		BTThreeDSecureAdditionalInformation AdditionalInformation { get; set; }

		// @property (assign, nonatomic) BTThreeDSecureVersion versionRequested;
		[Export("versionRequested", ArgumentSemantic.Assign)]
		BTThreeDSecureVersion VersionRequested { get; set; }

		// @property (nonatomic) BOOL challengeRequested;
		[Export("challengeRequested")]
		bool ChallengeRequested { get; set; }

		// @property (nonatomic) BOOL exemptionRequested;
		[Export("exemptionRequested")]
		bool ExemptionRequested { get; set; }

		// @property (nonatomic, strong) UiCustomization * _Nullable uiCustomization;
		[NullAllowed, Export("uiCustomization", ArgumentSemantic.Strong)]
		UiCustomization UiCustomization { get; set; }

		// @property (nonatomic, strong) BTThreeDSecureV1UICustomization * _Nullable v1UICustomization;
		[NullAllowed, Export("v1UICustomization", ArgumentSemantic.Strong)]
		BTThreeDSecureV1UICustomization V1UICustomization { get; set; }

		[Wrap("WeakThreeDSecureRequestDelegate")]
		[NullAllowed]
		BTThreeDSecureRequestDelegate ThreeDSecureRequestDelegate { get; set; }

		// @property (nonatomic, weak) id<BTThreeDSecureRequestDelegate> _Nullable threeDSecureRequestDelegate;
		[NullAllowed, Export("threeDSecureRequestDelegate", ArgumentSemantic.Weak)]
		NSObject WeakThreeDSecureRequestDelegate { get; set; }
	}

	// @protocol BTThreeDSecureRequestDelegate
	[Protocol, BaseType(typeof(BTPaymentFlowDriver))]
	interface BTThreeDSecureRequestDelegate
	{
		// @required -(void)onLookupComplete:(BTThreeDSecureRequest * _Nonnull)request result:(BTThreeDSecureLookup * _Nonnull)result next:(void (^ _Nonnull)(void))next;
		[Abstract]
		[Export("onLookupComplete:result:next:")]
		void Result(BTThreeDSecureRequest request, BTThreeDSecureLookup result, Action next);
	}

	[Static]
	partial interface BTThreeDSecureFlowConstants
	{
		// extern NSString *const _Nonnull BTThreeDSecureFlowErrorDomain;
		[Field("BTThreeDSecureFlowErrorDomain", "__Internal")]
		NSString ErrorDomain { get; }
	}

	// @interface ThreeDSecure (BTPaymentFlowDriver)
	[Category]
	[BaseType(typeof(BTPaymentFlowDriver))]
	interface BTPaymentFlowDriver_ThreeDSecure
	{
		// -(void)prepareLookup:(BTPaymentFlowRequest<BTPaymentFlowRequestDelegate> * _Nonnull)request completion:(void (^ _Nonnull)(NSString * _Nullable, NSError * _Nullable))completionBlock;
		[Export("prepareLookup:completion:")]
		void PrepareLookup(BTPaymentFlowRequestDelegate request, Action<NSString, NSError> completionBlock);

		// -(void)initializeChallengeWithLookupResponse:(NSString * _Nonnull)lookupResponse request:(BTPaymentFlowRequest<BTPaymentFlowRequestDelegate> * _Nonnull)request completion:(void (^ _Nonnull)(BTPaymentFlowResult * _Nullable, NSError * _Nullable))completionBlock;
		[Export("initializeChallengeWithLookupResponse:request:completion:")]
		void InitializeChallengeWithLookupResponse(string lookupResponse, BTPaymentFlowRequestDelegate request, Action<BTPaymentFlowResult, NSError> completionBlock);
	}

	// @interface ThreeDSecure (BTConfiguration)
    [Category]
	[BaseType(typeof(BTConfiguration))]
	interface BTConfiguration_ThreeDSecure
	{
		// @property (readonly, nonatomic, strong) NSString * cardinalAuthenticationJWT;
		[Static, Export("cardinalAuthenticationJWT", ArgumentSemantic.Strong)]
		string CardinalAuthenticationJWT { get; }
	}

	////    @interface BTPaymentFlowDriver (ThreeDSecure)
	//[Category, BaseType(typeof(BTPaymentFlowDriver))]
	//interface BTPaymentFlowDriver_ThreeDSecure
	//{
	//    // -(void)prepareLookup:(BTPaymentFlowRequest<BTPaymentFlowRequestDelegate> * _Nonnull)request completion:(void (^ _Nonnull)(NSString * _Nullable, NSError * _Nullable))completionBlock;
	//    [Export("prepareLookup:completion:")]
	//    void PrepareLookup(BTPaymentFlowRequestDelegate request, Action<NSString, NSError> completionBlock);

	//    // -(void)initializeChallengeWithLookupResponse:(NSString * _Nonnull)lookupResponse request:(BTPaymentFlowRequest<BTPaymentFlowRequestDelegate> * _Nonnull)request completion:(void (^ _Nonnull)(BTPaymentFlowResult * _Nullable, NSError * _Nullable))completionBlock;
	//    [Export("initializeChallengeWithLookupResponse:request:completion:")]
	//    void InitializeChallengeWithLookupResponse(string lookupResponse, BTPaymentFlowRequestDelegate request, Action<BTPaymentFlowResult, NSError> completionBlock);
	//}

	////    /**
	//// @brief Used to initialize a 3D Secure payment flow
	//// */
	////    @interface BTThreeDSecureRequest : BTPaymentFlowRequest<BTPaymentFlowRequestDelegate>
	//[BaseType(typeof(BTPaymentFlowRequest))]
	//interface BTThreeDSecureRequest : BTPaymentFlowRequestDelegate
	//{

	//    //    /**
	//    //     @brief A nonce to be verified by ThreeDSecure
	//    //     */
	//    //    @property(nonatomic, copy) NSString* nonce;
	//    [Export("nonce")]
	//    string Nonce { get; set; }

	//    ///**
	//    // @brief The amount for the transaction.
	//    // */
	//    //@property(nonatomic, copy) NSDecimalNumber* amount;
	//    [Export("amount")]
	//    decimal Amount { get; set; }
	//}
	////@interface BTThreeDSecureResult : BTPaymentFlowResult
	//[BaseType(typeof(BTPaymentFlowResult))]
	//interface BTThreeDSecureResult
	//{
	//    ///**
	//    // @brief True if the 3D Secure flow was successful
	//    // */
	//    //@property(nonatomic, assign) BOOL success;
	//    [Export("success")]
	//    bool Success { get; set; }

	//    ///**
	//    // @brief Indicates whether the liability for fraud has been shifted away from the merchant
	//    // */
	//    //@property(nonatomic, assign) BOOL liabilityShifted;
	//    [Export("liabilityShifted")]
	//    bool LiabilityShifted { get; set; }

	//    ///**
	//    // @brief Indicates whether the card was eligible for 3D Secure
	//    // */
	//    //@property(nonatomic, assign) BOOL liabilityShiftPossible;
	//    [Export("liabilityShiftPossible")]
	//    bool LiabilityShiftPossible { get; set; }

	//    ///**
	//    // @brief The `BTCardNonce` resulting from the 3D Secure flow
	//    // */
	//    //@property(nonatomic, strong) BTCardNonce* tokenizedCard;
	//    [Export("tokenizedCard")]
	//    BTCardNonce TokenizedCard { get; set; }

	//    ///**
	//    // @brief The error message when the 3D Secure flow is unsuccessful
	//    // */
	//    //@property(nonatomic, copy) NSString* errorMessage;
	//    [Export("errorMessage")]
	//    string ErrorMessage { get; set; }

	//    ///**
	//    // @brief Initialize a BTThreeDSecureResult

	//    // @param JSON BTJSON used to initialize the BTThreeDSecureResult
	//    // */
	//    //- (instancetype) initWithJSON:(BTJSON*) JSON;
	//    [Export("initWithJSON:")]
	//    BTThreeDSecureResult Constructor(BTJSON json);
	//}
}
