using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models {
    public class Seller {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double Salary { get; set; }
        public Departments Departments { get; set; }
        public int DepartmentsId { get; set; }
        public ICollection<SallesRecord> SallesRecords { get; set; } = new List<SallesRecord>();

        public Seller() {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double salary) {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Salary = salary;
        }

        public void AddSalles(SallesRecord sr) {
            SallesRecords.Add(sr);
        }

        public void RemoveSalles(SallesRecord sr) {
            SallesRecords.Remove(sr);
        }

        public double TotalSalles(DateTime initial, DateTime final) {


            return
                SallesRecords
                    .Where(sr => sr.Date >= initial && sr.Date <= final )
                    .Sum(sr=> sr.Amount);
        }

    }
}
