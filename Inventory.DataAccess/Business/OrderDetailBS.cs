using Inventory.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.DataAccess.Business
{
    public class OrderDetailBS
    {
        static AppDbContext appDb = new AppDbContext();

        public static  OrderDetail GetOrderDetailById(int id)
        {
            return appDb.OrderDetails.FirstOrDefault(item => item.OrderDetailId == id);
        }

        public static  List<OrderDetail> GetAllOrderDetails()
        {
            return appDb.OrderDetails.ToList();
        }

        public static List<OrderDetail> GetAllOrderDetailsByOrderId(int orderId)
        {
            return appDb.OrderDetails.ToList().Where(item => item.OrderId == orderId).ToList();
        }

        public static  OrderDetail AddOrderDetail(OrderDetail orderDetail)
        {
            if (GetOrderDetailById(orderDetail.OrderDetailId) != null)
            {
                EditOrderDetail(orderDetail);
                return orderDetail;
            }
            else
            {
                var record = appDb.OrderDetails.Add(orderDetail);
                appDb.SaveChanges();
                return record;
            }
        }

        public static  void EditOrderDetail(OrderDetail record)
        {
            var itm = appDb.OrderDetails.FirstOrDefault(item => item.OrderDetailId == record.OrderDetailId);

            itm.Remarks = record.Remarks;
            itm.IsVoid = record.IsVoid;
            itm.Discount = record.Discount;
            itm.Qty = record.Qty;
            itm.Tax = record.Tax;
            itm.Total = record.Total;

            appDb.SaveChanges();
        }
    }
}
