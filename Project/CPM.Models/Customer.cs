using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Customer_First_Name { get; set; }

        public string Customer_Last_Name { get; set; }

        public string Customer_Phone_Number { get; set; }
    }
}
