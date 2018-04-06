using Inventory.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.DataAccess.Business
{
    public class PaymentBS
    {
        static AppDbContext appDb = new AppDbContext();

        public static  Payment GetPaymentById(int id)
        {
            return appDb.Payments.FirstOrDefault(item => item.PaymentId == id);
        }

        public static  List<Payment> GetAllPayments()
        {
            return appDb.Payments.ToList();
        }

        public static  Payment AddPayment(Payment payment)
        {
            if (GetPaymentById(payment.PaymentId) != null)
            {
                EditPayment(payment);
                return payment;
            }
            else
            {
                var record = appDb.Payments.Add(payment);
                appDb.SaveChanges();
                return record;
            }
        }

        public static  void EditPayment(Payment record)
        {
            var itm = appDb.Payments.FirstOrDefault(item => item.PaymentId == record.PaymentId);

            itm.Remarks = record.Remarks;
            itm.OrderId = record.OrderId;
            itm.PaymentDateTime = record.PaymentDateTime;
            itm.PaymentMethod = record.PaymentMethod;
            itm.UserId = record.UserId;
            itm.Balance = record.Balance;
            itm.Amount = record.Amount;

            appDb.SaveChanges();
        }
    }
}
