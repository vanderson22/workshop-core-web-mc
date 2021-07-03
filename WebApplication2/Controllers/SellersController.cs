using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.Models.ViewModels;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _sellerService;
        private readonly DepartmentsService _departmentsService;

        public SellersController(SellerService sellerService, DepartmentsService departmentsService) {
            _sellerService = sellerService;
            _departmentsService = departmentsService;
        }


        public IActionResult Index() {
            var lista = _sellerService.FindAll();

            return View(lista);
        }

        public IActionResult Create() {

            var depto = _departmentsService.FindAll();


            SellerFormViewModel viewModel = new SellerFormViewModel(depto);

            return View(viewModel);
        }

        private Exception Exception(string v) {
            throw new NotImplementedException();
        }

        public IActionResult Delete(int id) {


            return
                View(_sellerService.Delete(id));
        }

        // GET: Seller/Details/5
        public IActionResult Details(int id) {


            return
                View(_sellerService.FindById(id));
        }

        // GET: Seller/Edit/5
        public IActionResult Edit(int id) {

            var depto = _departmentsService.FindAll();
            var seller = _sellerService.FindById(id);

            SellerFormViewModel viewModel = new SellerFormViewModel(depto, seller);
            //Trazendo os dois objetos para @model
            return View(viewModel);

        }

        [HttpPost]
        [AutoValidateAntiforgeryToken] //csrf atack prevent
        public IActionResult Update(Seller seller) {

            _sellerService.Update(seller);
            return
              RedirectToAction(nameof(Index));
        }


        [HttpDelete]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteSeller(int? id) {


            return
              RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken] //csrf atack prevent
        public IActionResult Create(Seller Seller) {

            _sellerService.Insert(Seller);
            return
                RedirectToAction(nameof(Index));
        }

    }
}