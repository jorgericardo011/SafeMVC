using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Amount { get; set; }
        public SalesStatus Status { get; set; }

        public Seller Seller { get; set; }

     
        public SalesRecord(int id, DateTime data, double amount, SalesStatus status, Seller seller)
        {
            Id = id;
            Data = data;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
