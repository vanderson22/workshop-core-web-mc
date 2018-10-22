using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Data {
    public class SeedingService {


        private WebApplication2Context _context { get; set; }

        public SeedingService(WebApplication2Context context) {
            _context = context;
        }


        public void seed() {

            if (    _context.Departments.Any() ||
                    _context.SallesRecord.Any() ||
                    _context.Seller.Any()
                  )
                //Banco de dados está populado
                return;

            Departments d1 = new Departments() { Id = 1, Nome = "Computers" };
            Departments d2 = new Departments() { Id = 2, Nome = "Eletronics" };
            Departments d3 = new Departments() { Id = 3, Nome = @"Book's" };
            Departments d4 = new Departments() { Id = 4, Nome = "Fashion" };

            /*   Seller s1 = new Seller(1, "bob", "bob@gmail.com", new DateTime(1998, 4, 21) ,  1000.0);
               Seller s2 = new Seller(2, "Melissa", "Melissa@gmail.com", new DateTime(1984, 1, 21), 1200.0);
               Seller s3 = new Seller(3, "Jane", "Jane@hotmail.com", new DateTime(1992, 4, 21), 1100.0);
               Seller s5 = new Seller(4, "Richard", "Richard@gmail.com", new DateTime(1998, 4, 26), 1000.0);

               SallesRecord sr1 = new SallesRecord(1, new DateTime(2018, 4, 26), 100.0, Models.Enums.SallesStatus.Billed, s1);

               SallesRecord sr2 = new SallesRecord(2, new DateTime(2018, 4, 26), 11110.0, Models.Enums.SallesStatus.Billed, s3);
               SallesRecord sr3 = new SallesRecord(3, new DateTime(2018, 4, 26), 12200.0, Models.Enums.SallesStatus.Pending, s2);
               SallesRecord sr4 = new SallesRecord(4, new DateTime(2018, 4, 26), 1100.0, Models.Enums.SallesStatus.Cancelled, s1);
               SallesRecord sr5 = new SallesRecord(5, new DateTime(2018, 4, 26), 1100.0, Models.Enums.SallesStatus.Billed, s5);
  
          
            _context.AddRange(s1, s2, s3, s5);
            _context.AddRange(sr1, sr2, sr3,sr4 ,sr5);
               */
            _context.AddRange(d1, d2, d3, d4);
      

            //salvando alterações
            _context.SaveChanges();

        }
    }
}
