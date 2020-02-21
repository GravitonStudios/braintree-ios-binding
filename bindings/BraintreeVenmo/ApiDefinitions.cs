using System;
using BraintreeCore;
using BraintreeVenmo;
using Foundation;
using ObjCRuntime;

namespace BraintreeVenmo
{
	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern double BraintreeVenmoVersionNumber;
		[Field ("BraintreeVenmoVersionNumber", "__Internal")]
		double BraintreeVenmoVersionNumber { get; }

		// extern const unsigned char [] BraintreeVenmoVersionString;
		[Field ("BraintreeVenmoVersionString", "__Internal")]
		byte[] BraintreeVenmoVersionString { get; }
	}

	// @interface Venmo (BTConfiguration)
	[Category]
	[BaseType (typeof(BTConfiguration))]
	interface BTConfiguration_Venmo
	{
		// +(void)enableVenmo:(BOOL)isEnabled __attribute__((deprecated("Venmo no longer relies on a user whitelist, thus this method is not needed")));
		[Static]
		[Export ("enableVenmo:")]
		void EnableVenmo (bool isEnabled);

		// @property (readonly, assign, nonatomic) BOOL isVenmoEnabled;
		[Export ("isVenmoEnabled")]
		bool IsVenmoEnabled { get; }

		// @property (readonly, nonatomic, strong) NSString * venmoAccessToken;
		[Export ("venmoAccessToken", ArgumentSemantic.Strong)]
		string VenmoAccessToken { get; }

		// @property (readonly, nonatomic, strong) NSString * venmoMerchantID;
		[Export ("venmoMerchantID", ArgumentSemantic.Strong)]
		string VenmoMerchantID { get; }

		// @property (readonly, nonatomic, strong) NSString * venmoEnvironment;
		[Export ("venmoEnvironment", ArgumentSemantic.Strong)]
		string VenmoEnvironment { get; }
	}

	// @interface BTVenmoAccountNonce : BTPaymentMethodNonce
	[BaseType (typeof(BTPaymentMethodNonce))]
	interface BTVenmoAccountNonce
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable username;
		[NullAllowed, Export ("username")]
		string Username { get; }
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull BTVenmoDriverErrorDomain;
		[Field ("BTVenmoDriverErrorDomain", "__Internal")]
		NSString BTVenmoDriverErrorDomain { get; }
	}

	// @interface BTVenmoDriver : NSObject <BTAppSwitchHandler>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface BTVenmoDriver : IBTAppSwitchHandler
	{
		// -(instancetype _Nonnull)initWithAPIClient:(BTAPIClient * _Nonnull)apiClient __attribute__((objc_designated_initializer));
		[Export ("initWithAPIClient:")]
		[DesignatedInitializer]
		IntPtr Constructor (BTAPIClient apiClient);

		// -(void)authorizeAccountAndVault:(BOOL)vault completion:(void (^ _Nonnull)(BTVenmoAccountNonce * _Nullable, NSError * _Nullable))completionBlock;
		[Export ("authorizeAccountAndVault:completion:")]
		void AuthorizeAccountAndVault (bool vault, Action<BTVenmoAccountNonce, NSError> completionBlock);

		// -(void)authorizeAccountWithProfileID:(NSString * _Nullable)profileId vault:(BOOL)vault completion:(void (^ _Nonnull)(BTVenmoAccountNonce * _Nullable, NSError * _Nullable))completionBlock __attribute__((swift_name("authorizeAccount(profileID:vault:completion:)")));
		[Export ("authorizeAccountWithProfileID:vault:completion:")]
		void AuthorizeAccountWithProfileID ([NullAllowed] string profileId, bool vault, Action<BTVenmoAccountNonce, NSError> completionBlock);

		// -(void)authorizeAccountWithCompletion:(void (^ _Nonnull)(BTVenmoAccountNonce * _Nullable, NSError * _Nullable))completionBlock __attribute__((deprecated("Use [BTVenmoDriver authorizeAccountAndVault:completion instead")));
		[Export ("authorizeAccountWithCompletion:")]
		void AuthorizeAccountWithCompletion (Action<BTVenmoAccountNonce, NSError> completionBlock);

		// -(BOOL)isiOSAppAvailableForAppSwitch;
		[Export ("isiOSAppAvailableForAppSwitch")]
		[Verify (MethodToProperty)]
		bool IsiOSAppAvailableForAppSwitch { get; }

		// -(void)openVenmoAppPageInAppStore;
		[Export ("openVenmoAppPageInAppStore")]
		void OpenVenmoAppPageInAppStore ();

		[Wrap ("WeakAppSwitchDelegate")]
		[NullAllowed]
		BTAppSwitchDelegate AppSwitchDelegate { get; set; }

		// @property (nonatomic, weak) id<BTAppSwitchDelegate> _Nullable appSwitchDelegate;
		[NullAllowed, Export ("appSwitchDelegate", ArgumentSemantic.Weak)]
		NSObject WeakAppSwitchDelegate { get; set; }
	}
}
