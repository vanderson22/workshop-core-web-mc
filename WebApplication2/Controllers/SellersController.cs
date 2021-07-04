using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.Models.ViewModels;
using WebApplication2.Services;
using WebApplication2.Services.Exceptions;

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

        public IActionResult Delete(int? id) {

            return
                View(_sellerService.Delete(id.Value));
        }

        // GET: Seller/Details/5
        public IActionResult Details(int? id) {

            if (id == null)
                return NotFound();
            Seller seller = _sellerService.FindById(id.Value);
            if (seller == null)
                return NotFound();

            return
                View(seller);
        }

        // GET: Seller/Edit/5
        public IActionResult Edit(int? id) {

            var depto = _departmentsService.FindAll();
            if (id == null)
                return NotFound();

            var seller = _sellerService.FindById(id.Value);

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


        [HttpPost] // ficar atendo aos posts de formulário
        [AutoValidateAntiforgeryToken]
        public IActionResult RemoveSeller() {

            _sellerService.DeleteSeller(4);
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