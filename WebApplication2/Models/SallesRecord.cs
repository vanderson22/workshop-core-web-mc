using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models.Enums;

namespace WebApplication2.Models {
    public class SallesRecord {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SallesStatus SallesStatus { get; set; }
        public Seller Seller { get; set; }

        public SallesRecord() {
        }

        public SallesRecord(int id, DateTime date, double amount, SallesStatus sallesStatus, Seller seller) {
            Id = id;
            Date = date;
            Amount = amount;
            SallesStatus = sallesStatus;
            Seller = seller;
        }
    }
}
