using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAC.Models
{
    public class AliveResponse
    {
        public string Name { get; set; }
        public string AssemblyVersion { get; set; }
        public string ApiVersion { get; set; }
        public string Type { get; set; }
        public string Affinity { get; set; }
    }

    public class TransactionResponse
    {
        public int TransactionType { get; set; }
        public bool Approved { get; set; }
        public string TransactionIdentifier { get; set; }
        public decimal TotalAmount { get; set; }
        public string CurrencyCode { get; set; }
        public string IsoResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string OrderIdentifier { get; set; }
        public string RedirectData { get; set; }
        public string SpiToken { get; set; }
        public string AuthorizationCode { get; set; }
        public string RRN { get; set; }
        public string CardBrand { get; set; }
        public List<Error> Errors { get; set; }
        public FraudCheck FraudCheck { get; set; }
    }

    // Secondary Models ------------------------------------------------------------------

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
        public string FcScore { get; set; }
        public string FcTransId { get; set; }
    }
}
