namespace FacApi;

//REQUEST - AUTH - RiskMgmt
public class TransactionRequest
{
    public bool Tokenize { get; set; }
    public string TransactionIdentifier { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal TipAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal OtherAmount { get; set; }
    public string CurrencyCode { get; set; }
    public string LocalTime { get; set; }
    public string LocalDate { get; set; }
    public bool AddressVerification { get; set; }
    public bool ThreeDSecure { get; set; }
    public bool BinCheck { get; set; }
    public bool FraudCheck { get; set; }
    public bool RecurringInitial { get; set; }
    public bool Recurring { get; set; }
    public bool CardOnFile { get; set; }
    public bool AccountVerification { get; set; }
    public Source Source { get; set; }
    public string TerminalId { get; set; }
    public string TerminalCode { get; set; }
    public string TerminalSerialNumber { get; set; }
    public string ExternalIdentifier { get; set; }
    public string ExternalBatchIdentifier { get; set; }
    public string ExternalGroupIdentifier { get; set; }
    public string OrderIdentifier { get; set; }
    public BillingAddress BillingAddress { get; set; }
    public ShippingAddress ShippingAddress { get; set; }
    public bool AddressMatch { get; set; }
    public ExtendedData ExtendedData { get; set; }
}

//REQUEST - CAPTURE
public class TransactionDetail
{
    public string TransactionIdentifier { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal TipAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal OtherAmount { get; set; }
    public string ExternalIdentifier { get; set; }
    public string ExternalGroupIdentifier { get; set; }
}

//RESPONSE - AUTH - CAPTURE - RiskMgmt
public class TransactionResponse
{
    public string OriginalTrxnIdentifier { get; set; }
    public int TransactionType { get; set; }
    public bool Approved { get; set; }
    public string AuthorizationCode { get; set; }
    public string TransactionIdentifier { get; set; }
    public decimal TotalAmount { get; set; }
    public string CurrencyCode { get; set; }
    public string RRN { get; set; }
    public string CardBrand { get; set; }
    public string CardSuffix { get; set; }
    public string IsoResponseCode { get; set; }
    public string EmvIssuerAuthenticationData { get; set; }
    public string EmvIssuerScripts { get; set; }
    public string EmvResponseCode { get; set; }
    public string ResponseMessage { get; set; }
    public RiskManagement RiskManagement { get; set; }
    public string CustomData { get; set; }
    public string Host { get; set; }
    public string PanToken { get; set; }
    public string ExternalIdentifier { get; set; }
    public string OrderIdentifier { get; set; }
    public List<Error> Errors { get; set; }
    public string RedirectData { get; set; }
    public string SpiToken { get; set; }
    public BillingAddress BillingAddress { get; set; }
}


public class Source
{
    public bool CardPresent { get; set; }
    public bool CardEmvFallback { get; set; }
    public bool ManualEntry { get; set; }
    public bool Debit { get; set; }
    public string AccountType { get; set; }
    public bool Contactless { get; set; }
    public string CardPan { get; set; }
    public string EncryptedCardPan { get; set; }
    public string MaskedPan { get; set; }
    public string CardCvv { get; set; }
    public string EncryptedCardCvv { get; set; }
    public string EncryptedCardExpiration { get; set; }
    public string CardExpiration { get; set; }
    public string Token { get; set; }
    public string TokenType { get; set; }
    public string CardTrack1Data { get; set; }
    public string CardTrack2Data { get; set; }
    public string CardTrack3Data { get; set; }
    public string CardTrackData { get; set; }
    public string EncryptedCardTrack1Data { get; set; }
    public string EncryptedCardTrack2Data { get; set; }
    public string EncryptedCardTrack3Data { get; set; }
    public string EncryptedCardTrackData { get; set; }
    public string Ksn { get; set; }
    public string EncryptedPinBlock { get; set; }
    public string PinBlockKsn { get; set; }
    public string CardEmvData { get; set; }
    public string CardholderName { get; set; }
    public string Wallet { get; set; }
}


public class BillingAddress
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Line1 { get; set; }
    public string Line2 { get; set; }
    public string City { get; set; }
    public string County { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string CountryCode { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string PhoneNumber2 { get; set; }
    public string PhoneNumber3 { get; set; }
}

public class ShippingAddress
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Line1 { get; set; }
    public string Line2 { get; set; }
    public string City { get; set; }
    public string County { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string CountryCode { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string PhoneNumber2 { get; set; }
    public string PhoneNumber3 { get; set; }
}

public class ExtendedData
{
    public SecondaryAddress SecondaryAddress { get; set; }
    public string CustomData { get; set; }
    public string Level2CustomData { get; set; }
    public string Level3CustomData { get; set; }
    public ThreeDSecure ThreeDSecure { get; set; }
    public Recurring Recurring { get; set; }
    public BrowserInfo BrowserInfo { get; set; }
    public string MerchantResponseUrl { get; set; }
    public HostedPage HostedPage { get; set; }
    public string FraudCheck { get; set; }
}

public class HostedPage
{
    public string PageSet { get; set; }
    public string PageName { get; set; }
}

public class BrowserInfo
{
    public string AcceptHeader { get; set; }
    public string Language { get; set; }
    public string ScreenHeight { get; set; }
    public string ScreenWidth { get; set; }
    public string TimeZone { get; set; }
    public string UserAgent { get; set; }
    public string IP { get; set; }
    public bool JavaEnabled { get; set; }
    public bool JavascriptEnabled { get; set; }
    public string ColorDepth { get; set; }
}

public class Recurring
{
    public bool Managed { get; set; }
    public string StartDate { get; set; }
    public string Frequency { get; set; }
    public string ExpiryDate { get; set; }
}

public class SecondaryAddress
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Line1 { get; set; }
    public string Line2 { get; set; }
    public string City { get; set; }
    public string County { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string CountryCode { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string PhoneNumber2 { get; set; }
    public string PhoneNumber3 { get; set; }
}


public class ThreeDSecure
{
    public string Eci { get; set; }
    public string Cavv { get; set; }
    public string Xid { get; set; }
    public string AuthenticationStatus { get; set; }
    public string StatusReason { get; set; }
    public string RedirectData { get; set; }
    public string AuthenticateUrl { get; set; }
    public string CardEnrolled { get; set; }
    public string ProtocolVersion { get; set; }
    public string FingerprintIndicator { get; set; }
    public string DsTransId { get; set; }
    public string ResponseCode { get; set; }
    public string CardholderInfo { get; set; }
    public string DSTransId { get; set; }
    public int ChallengeWindowSize { get; set; }
    public string ChannelIndicator { get; set; }
    public string RiIndicator { get; set; }
    public string ChallengeIndicator { get; set; }
    public string AuthenticationIndicator { get; set; }
    public string MessageCategory { get; set; }
    public string TransactionType { get; set; }
    public AccountInfo AccountInfo { get; set; }
    public List<MessageExtension> MessageExtensions { get; set; }
}

public class MessageExtension
{
    public string Name { get; set; }
    public string Id { get; set; }
    public bool CriticalityIndicator { get; set; }
    public string Version { get; set; }
    public string Data { get; set; }
}

public class AccountInfo
{
    public string AccountAgeIndicator { get; set; }
    public string AccountChangeDate { get; set; }
    public string AccountChangeIndicator { get; set; }
    public string AccountDate { get; set; }
    public string AccountPasswordChangeDate { get; set; }
    public string AccountPasswordChangeIndicator { get; set; }
    public string AccountPurchaseCount { get; set; }
    public string AccountProvisioningAttempts { get; set; }
    public string AccountDayTransactions { get; set; }
    public string AccountYearTransactions { get; set; }
    public string PaymentAccountAge { get; set; }
    public string PaymentAccountAgeIndicator { get; set; }
    public string ShipAddressUsageDate { get; set; }
    public string ShipAddressUsageIndicator { get; set; }
    public string ShipNameIndicator { get; set; }
    public string SuspiciousAccountActivity { get; set; }
}


public class Error
{
    public string Code { get; set; }
    public string Message { get; set; }
}
public class FraudCheck
{
    public string FcProvider { get; set; }
    public string ResponseCode { get; set; }
    public string FcResponseCode { get; set; }
    public string FcResponseMessage { get; set; }
    public string FcReasonCode { get; set; }
    public string FcScore { get; set; }
    public string FcDetails { get; set; }
    public string FcTransId { get; set; }
}
public class SourceDetails
{
    public bool CardPresent { get; set; }
    public bool CardEmvFallback { get; set; }
    public bool ManualEntry { get; set; }
    public bool Debit { get; set; }
    public bool Contactless { get; set; }
    public string CardPan { get; set; }
    public string MaskedPan { get; set; }
}

public class RiskManagement
{
    public string AvsResponseCode { get; set; }
    public string CvvResponseCode { get; set; }
    public ThreeDSecure ThreeDSecure { get; set; }
    public FraudCheck FraudCheck { get; set; }
}