using System;
using ObjCRuntime;

namespace BraintreeUI
{
	[Native]
	public enum BTUIPaymentOptionType : long
	{
		Unknown = 0,
		Amex,
		DinersClub,
		Discover,
		MasterCard,
		Visa,
		Jcb,
		Laser,
		Maestro,
		UnionPay,
		Solo,
		Switch,
		UKMaestro,
		PayPal,
		Coinbase,
		Venmo
	}

	[Flags]
	[Native]
	public enum BTUICardFormOptionalFields : ulong
	{
		None = 0x0,
		Cvv = 1uL << 0,
		PostalCode = 1uL << 1,
		PhoneNumber = 1uL << 2,
		All = Cvv | PostalCode | PhoneNumber
	}

	[Native]
	public enum BTUICardFormField : ulong
	{
		Number = 0,
		Expiration,
		Cvv,
		PostalCode,
		PhoneNumber
	}

	[Native]
	public enum BTCardHintDisplayMode : long
	{
		ardType,
		VVHint
	}
}
