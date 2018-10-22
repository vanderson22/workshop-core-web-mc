using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models.ViewModels {
    public class SellerFormViewModel {


        public SellerFormViewModel(List<Departments> depto) {
            this.DepartmentsList = depto;
        }
        public SellerFormViewModel() {

        }


        public Seller Seller { get; set; }
        public ICollection<Departments> DepartmentsList { get; set; }



    }
}
