namespace PayPal.Risk
{
	public enum MagnesSourceFlow
	{
		Paypal = 10,
		Ebay = 11,
		Braintree = 12,
		Simility = 17,
		Default = -1
	}

	public enum MagnesEnvironment : uint
	{
		Live = 0,
		Sandbox = 1,
		Stage = 2
	}
}
