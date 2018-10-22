using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services {
    public class SellerService  {

        private readonly WebApplication2Context _context  ;

        public SellerService(WebApplication2Context context) {
            _context = context;
        }


        public List<Seller> FindAll() => _context.Seller.ToList();

        public void Insert(Seller Seller ) {

           // Seller.Departments = _context.Departments.First();
            _context.Add(Seller);
            _context.SaveChanges();
        }

        public Seller Delete(int id) => _context.Seller.First(m => m.Id == id);
    }
}
