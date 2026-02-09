using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripeDispute.Model
{
    public class DisputeResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("balance_transaction")]
        public string BalanceTransaction { get; set; }

        [JsonProperty("balance_transactions")]
        public List<BalanceTransaction> BalanceTransactions { get; set; }

        [JsonProperty("charge")]
        public string Charge { get; set; }

        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("enhanced_eligibility_types")]
        public List<object> EnhancedEligibilityTypes { get; set; }

        [JsonProperty("evidence")]
        public Evidence Evidence { get; set; }

        [JsonProperty("evidence_details")]
        public EvidenceDetails EvidenceDetails { get; set; }

        [JsonProperty("is_charge_refundable")]
        public bool IsChargeRefundable { get; set; }

        [JsonProperty("livemode")]
        public bool Livemode { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonProperty("payment_intent")]
        public string PaymentIntent { get; set; }

        [JsonProperty("payment_method_details")]
        public PaymentMethodDetails PaymentMethodDetails { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class BalanceTransaction
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("available_on")]
        public long AvailableOn { get; set; }

        [JsonProperty("balance_type")]
        public string BalanceType { get; set; }

        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("exchange_rate")]
        public object ExchangeRate { get; set; }

        [JsonProperty("fee")]
        public int Fee { get; set; }

        [JsonProperty("fee_details")]
        public List<FeeDetail> FeeDetails { get; set; }

        [JsonProperty("net")]
        public int Net { get; set; }

        [JsonProperty("reporting_category")]
        public string ReportingCategory { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class FeeDetail
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("application")]
        public object Application { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Evidence
    {
        [JsonProperty("access_activity_log")]
        public object AccessActivityLog { get; set; }

        [JsonProperty("billing_address")]
        public object BillingAddress { get; set; }

        [JsonProperty("cancellation_policy")]
        public object CancellationPolicy { get; set; }

        [JsonProperty("cancellation_policy_disclosure")]
        public object CancellationPolicyDisclosure { get; set; }

        [JsonProperty("cancellation_rebuttal")]
        public object CancellationRebuttal { get; set; }

        [JsonProperty("customer_communication")]
        public object CustomerCommunication { get; set; }

        [JsonProperty("customer_email_address")]
        public object CustomerEmailAddress { get; set; }

        [JsonProperty("customer_name")]
        public object CustomerName { get; set; }

        [JsonProperty("customer_purchase_ip")]
        public object CustomerPurchaseIp { get; set; }

        [JsonProperty("customer_signature")]
        public object CustomerSignature { get; set; }

        [JsonProperty("duplicate_charge_documentation")]
        public object DuplicateChargeDocumentation { get; set; }

        [JsonProperty("duplicate_charge_explanation")]
        public object DuplicateChargeExplanation { get; set; }

        [JsonProperty("duplicate_charge_id")]
        public object DuplicateChargeId { get; set; }

        [JsonProperty("enhanced_evidence")]
        public Dictionary<string, object> EnhancedEvidence { get; set; }

        [JsonProperty("product_description")]
        public object ProductDescription { get; set; }

        [JsonProperty("receipt")]
        public object Receipt { get; set; }

        [JsonProperty("refund_policy")]
        public object RefundPolicy { get; set; }

        [JsonProperty("refund_policy_disclosure")]
        public object RefundPolicyDisclosure { get; set; }

        [JsonProperty("refund_refusal_explanation")]
        public object RefundRefusalExplanation { get; set; }

        [JsonProperty("service_date")]
        public object ServiceDate { get; set; }

        [JsonProperty("service_documentation")]
        public object ServiceDocumentation { get; set; }

        [JsonProperty("shipping_address")]
        public object ShippingAddress { get; set; }

        [JsonProperty("shipping_carrier")]
        public object ShippingCarrier { get; set; }

        [JsonProperty("shipping_date")]
        public object ShippingDate { get; set; }

        [JsonProperty("shipping_documentation")]
        public object ShippingDocumentation { get; set; }

        [JsonProperty("shipping_tracking_number")]
        public object ShippingTrackingNumber { get; set; }

        [JsonProperty("uncategorized_file")]
        public object UncategorizedFile { get; set; }

        [JsonProperty("uncategorized_text")]
        public string UncategorizedText { get; set; }
    }

    public class EvidenceDetails
    {
        [JsonProperty("due_by")]
        public long DueBy { get; set; }

        [JsonProperty("enhanced_eligibility")]
        public Dictionary<string, object> EnhancedEligibility { get; set; }

        [JsonProperty("has_evidence")]
        public bool HasEvidence { get; set; }

        [JsonProperty("past_due")]
        public bool PastDue { get; set; }

        [JsonProperty("submission_count")]
        public int SubmissionCount { get; set; }
    }

    public class PaymentMethodDetails
    {
        [JsonProperty("card")]
        public CardDetails Card { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class CardDetails
    {
        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("case_type")]
        public string CaseType { get; set; }

        [JsonProperty("network_reason_code")]
        public string NetworkReasonCode { get; set; }
    }
}
