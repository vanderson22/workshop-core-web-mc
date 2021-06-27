using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Models
{
    public class Departments
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Departments(int id, string nome) {
            Id = id;
            Nome = nome;
        }

        public Departments() {
        }



        public void AddSeller(Seller s) {

            Sellers.Add(s);
        }

        public double TotalSales(DateTime initial, DateTime final) {

            return Sellers
                            .Sum(
                                    s => s.TotalSales(initial, final)
                                  );
        }

        public double AverageBaseSalary() {

            return Sellers
                            .Average( s => s.Salary );
        }

    }
}
