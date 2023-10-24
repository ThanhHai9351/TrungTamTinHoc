using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrungTamTinHoc.Models
{
    public class Payments
    {
        public string PaymentsID { get; set; }

        public string StudentID { get; set; }

        public string ClassromID { get; set; }

        public int AmountOfMoney { get; set; }

        public string Active { get; set; }

        public DateTime MoneyDate { get; set; }
    }
}
