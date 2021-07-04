using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Services.Exceptions;

namespace WebApplication2.Services
{
    public class SellerService
    {

        private readonly WebApplication2Context _context;

        public SellerService(WebApplication2Context context) {
            _context = context;
        }


        public List<Seller> FindAll() => _context.Seller.ToList();
        public Task<List<Seller>> FindAllAsync() => _context.Seller.ToListAsync();
        //Eager loading departments.
        public Seller FindById(int id) => _context.Seller.Include(o => o.Departments).FirstOrDefault(m => m.Id == id);

        public void Insert(Seller Seller) {

            // Seller.Departments = _context.Departments.First();
            _context.Add(Seller);
            _context.SaveChanges();
        }

        public Seller Delete(int id) => _context.Seller.First(m => m.Id == id);
        public void DeleteSeller(int id) {
            _context.Seller.Remove(this.FindById(id));
            _context.SaveChanges();

        }

        public void Update(Seller seller) {
            //Id exists on DB ?
            if (seller == null || !_context.Seller.Any(x => x.Id == seller.Id))
                throw new NotFoundException("Id [" + seller.Id + "] Not Found");

            try {

                _context.Update(seller);
                _context.SaveChanges();
            } catch (DbUpdateConcurrencyException e) {
                //throw customized exception
                throw new DbConcurrencyException(e.Message);
            }

        }
    }
}
