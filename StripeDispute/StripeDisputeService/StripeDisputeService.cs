using Newtonsoft.Json;
using SaavorService;
using Stripe;
using Stripe.Identity;
using Stripe.Issuing;
using StripeDispute.Model;
using StripeDispute.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace StripeDispute.StripeDisputeService
{
    /// <summary>
    /// StripeDisputeService
    /// </summary>
    public class StripeDisputeService
    {
        /// <summary>
        /// StripeDisputeService
        /// </summary>
        public StripeDisputeService()
        {
            string ApiKey = ConfigurationManager.AppSettings["SecretKey"];
            StripeConfiguration.ApiKey = ApiKey;
        }

        /// <summary>
        /// GetInvoke
        /// </summary>
        public void GetInvoke()
        {
            string filePath = Path.Combine(ConfigurationManager.AppSettings["LogFilePath"], DateTime.Now.ToString("MM-dd-yyyy") + "_Logs.txt");
            List<string> lines = new List<string> { string.Format("********* {0}: Stripe Dispute Service Status **************\n", DateTime.UtcNow.ToString()) };
            string message = string.Empty;
            AppDBContext appDBContext = new AppDBContext();
            try
            {
                var disputes = GetDisputes();
                var disputesDT = new DataTable();
                if(disputes != null && disputes.Count > 0)
                {
                    disputesDT = CreateDataTable.Create(disputes);
                    var result = appDBContext.Save(disputesDT);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            lines = new List<string> { string.Format("{0}\n************END**********\n\n", message) };
            System.IO.File.AppendAllLines(filePath, lines);
        }
        private static List<DisputeModel> GetDisputes()
        {
            var disputeService = new Stripe.DisputeService();
            var options = new Stripe.DisputeListOptions
            {
                Limit = 100,
            };
            var disputes = disputeService.List(options);
            var result = new List<DisputeModel>();
            long disputeFee = 0;
            if (disputes != null && disputes.Count() > 0)
            {
                foreach(var item in disputes)
                {
                    var balanceTransactions = item.BalanceTransactions.FirstOrDefault();
                    disputeFee = balanceTransactions.FeeDetails.FirstOrDefault().Amount;
                    var responseDate = item.EvidenceDetails?.DueBy;
                    result.Add(new DisputeModel
                    {
                        DisputeId = item.Id,
                        ChargeId =  item.ChargeId,
                        PaymentIntentId = item.PaymentIntentId,
                        Amount = Convert.ToDecimal(item.Amount) / 100,
                        Reason = item.Reason,
                        Status = item.Status,
                        DisputeDate = Convert.ToDateTime(item.Created),
                        DisputeFee = Convert.ToDecimal(disputeFee) / 100,
                        ResponseDate = (DateTime)responseDate
                    });
                }
            }
            return result;
        }
    }
}
