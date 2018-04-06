using Inventory.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.DataAccess.Business
{
    public class OrderBS
    {
        static AppDbContext appDb = new AppDbContext();

        public static  Order GetOrderById(int id)
        {
            return appDb.Orders.FirstOrDefault(item => item.OrderId == id);
        }

        public static  List<Order> GetAllOrders()
        {
            return appDb.Orders.ToList();
        }

        public static  bool IsOrderCompleted(int id)
        {
            var order = appDb.Orders.FirstOrDefault(item => item.OrderId == id);
            var payments = appDb.Payments.Where(item => item.OrderId == id);
            var totalPaid = payments.AsEnumerable().Sum(o => o.Amount);

            return totalPaid == order.TotalAmount;
        }

        public static  Order AddOrder(Order order)
        {
            if (GetOrderById(order.OrderId) != null)
            {
                EditOrder(order);
                return order;
            }
            else
            {
                var record = appDb.Orders.Add(order);
                appDb.SaveChanges();
                return record;
            }
        }

        public static  List<OrderDetail> GetActiveItemsInOrder(int id)
        {
           return appDb.OrderDetails.Where(item => item.OrderId == id && !item.IsVoid).ToList();
        }

        public static  List<OrderDetail> GetVoidItemsInOrder(int id)
        {
            return appDb.OrderDetails.Where(item => item.OrderId == id && item.IsVoid).ToList();
        }

        public static  void EditOrder(Order record)
        {
            var itm = appDb.Orders.FirstOrDefault(item => item.OrderId == record.OrderId);

            itm.Remarks = record.Remarks;
            itm.OrderDateTime = record.OrderDateTime;
            itm.CustomerId = record.CustomerId;

            appDb.SaveChanges();
        }

        public List<Payment> GetAllPaymentByOrderId(int id)
        {
            return appDb.Payments.Where(item => item.OrderId == id).ToList();
        }
    }
}
