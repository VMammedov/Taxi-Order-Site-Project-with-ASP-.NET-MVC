using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Utilities
{
    public class OrderNMessage
    {
        public int orderId { get; set; }
        public string message { get; set; }

        public OrderNMessage(int arg_orderId, string arg_message)
        {
            orderId = arg_orderId;
            message = arg_message;
        }

        public OrderNMessage()
        {
        }
    }
}
