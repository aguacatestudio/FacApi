namespace FacApi;

public class AuthRequest
{
    public string TransacctionIdentifier { get; set; }
    public decimal TotalAmount { get; set; }
    public string CurrencyCode { get; set; }
    public bool ThreeDSecure { get; set; }
    public SourceModel Source { get; set; }
    public string OrderIdentifier { get; set; }
    public BillingAddressModel BillingAddress { get; set; }
    public bool AddressMatch { get; set; }
    public ExtendedDataModel ExtendedData { get; set; }
}

public class SourceModel
{
    public string CardPan { get; set; }
    public string CardCvv { get; set; }
    public string CardExpiration { get; set; }
    public string CardholderName { get; set; }
}

public class BillingAddressModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Line1 { get; set; }
    public string Line2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string CountryCode { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
}

public class ExtendedDataModel
{
    public ThreeDSecureModel ThreeDSecure { get; set; }
    public string MerchantResponseUrl { get; set; }
}

public class ThreeDSecureModel
{
    public int ChallengeWindowSize { get; set; }
    public string ChallengeIndicator { get; set; }
}