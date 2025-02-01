using System.Text;

namespace FAC.Models;

public class TransactionCaptureRequest
{
    public string TransactionIdentifier { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal? TaxAmount { get; set; }
    public string ExternalIdentifier { get; set; }
    public string ExternalGroupIdentifier { get; set; }
}

public class RiskManagementRequest
{
    public string TransactionIdentifier { get; set; } = Guid.NewGuid().ToString();
    public decimal TotalAmount { get; set; }
    public string CurrencyCode { get; set; } = "320";
    public bool ThreeDSecure { get; set; } = true;
    public bool FraudCheck { get; set; } = false;
    public Source Source { get; set; }
    public string OrderIdentifier { get; set; } = $"ORD-{Guid.NewGuid()}";
    public BillingAddress BillingAddress { get; set; }
    public ExtendedData ExtendedData { get; set; }
}

public class TransactionRequest
{
    public string TransactionIdentifier { get; set; } = Guid.NewGuid().ToString();
    public decimal TotalAmount { get; set; }
    public string CurrencyCode { get; set; }
    public bool ThreeDSecure { get; set; } = true;
    public Source Source { get; set; }
    public string OrderIdentifier { get; set; }
    public BillingAddress BillingAddress { get; set; }
    public ExtendedData ExtendedData { get; set; }
}

public class SaleRequest
{
    public string TransactionIdentifier { get; set; } = Guid.NewGuid().ToString();
    public decimal TotalAmount { get; set; }
    public string CurrencyCode { get; set; } = "320"; // Lempira
    public bool ThreeDSecure { get; set; } = true;
    public Source Source { get; set; }
    public string OrderIdentifier { get; set; } = $"ORD-{Guid.NewGuid()}";
    public BillingAddress BillingAddress { get; set; }
    public ExtendedData ExtendedData { get; set; }
}

public class TransactionRefundRequest
{
    public bool Refund { get; set; } = true;
    public string TransactionIdentifier { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal? TaxAmount { get; set; }
    public string ExternalIdentifier { get; set; }
    public string ExternalGroupIdentifier { get; set; }
}

public class TransactionVoidRequest
{
    public string TransactionIdentifier { get; set; }
    public string ExternalIdentifier { get; set; }
    public string TerminalCode { get; set; }
    public string TerminalSerialNumber { get; set; }
    public bool AutoReversal { get; set; } = false;
}

// Secondary Models ------------------------------------------------------------------

public class Source
{
    public string CardPan { get; set; }
    public string CardCvv { get; set; }
    public string CardExpiration { get; set; }
    public string CardholderName { get; set; }
}

public class BillingAddress
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Line1 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string CountryCode { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
}

public class ExtendedData
{
    public ThreeDSecure ThreeDSecure { get; set; }
    public string MerchantResponseUrl { get; set; }
}

public class ThreeDSecure
{
    public int ChallengeWindowSize { get; set; } = 4;
    public string ChallengeIndicator { get; set; } = "01";
}



