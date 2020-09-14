using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Desafio.Domain.Entities;
using Desafio.Infra.Data.Context;
using Desafio.Infra.Data.Repository;
using Desafio.Web.Models;

namespace Desafio.Web.Controllers {
    public class ProductController : Controller {
        private ProductRepository _productRepository = new ProductRepository();
        private ClientRepository _clientRepository = new ClientRepository();

        // GET: Product
        public ActionResult Index() {
            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(_productRepository.GetAll());
            ViewBag.ProductErro = TempData["ProductDelete"];
            return View(productViewModel);
        }

        // GET: Product/Details/5
        public ActionResult Details(Guid id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productViewModel = Mapper.Map<Product, ProductViewModel>(_productRepository.GetById(id));

            if (productViewModel == null) {
                return HttpNotFound();
            }
            return View(productViewModel);
        }

        // GET: Product/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Product/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel clientViewModel) {
            var clientDomain = Mapper.Map<ProductViewModel, Product>(clientViewModel);
            if (ModelState.IsValid) {

                _productRepository.Add(clientDomain);

                return RedirectToAction("Index");
            }

            return View(clientViewModel);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(Guid id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var client = _productRepository.GetById(id);

            if (client == null) {
                return HttpNotFound();
            }

            var clientViewModel = Mapper.Map<Product, ProductViewModel>(client);

            return View(clientViewModel);
        }

        // POST: Product/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel clientViewModel) {
            var clientDomain = Mapper.Map<ProductViewModel, Product>(clientViewModel);

            if (_clientRepository.GetWhere(c => c.ProductId == clientDomain.ProductId) != null && clientDomain.Ativo != true) {
                ModelState.AddModelError("Ativo", "Esse produto não pode ser inativado");
            }

            if (ModelState.IsValid) {

                _productRepository.Update(clientDomain);
                return RedirectToAction("Index");
            }
            return View(clientViewModel);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(Guid id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = _productRepository.GetById(id);

            if (_clientRepository.GetWhere(c => c.ProductId == id).Count > 0) {
                TempData["ProductDelete"] =  "Esse produto nao pode ser excluido";
            }

            if (client == null) {
                return HttpNotFound();
            }

            if (TempData["ProductDelete"] == null) {
                _productRepository.Remove(client);
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                _productRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
