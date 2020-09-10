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
    public class ClientController : Controller {
        private ClientRepository _clientRepository = new ClientRepository();

        // GET: Client
        public ActionResult Index() {
            var clientVIewModel = Mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(_clientRepository.GetAll());
            return View(clientVIewModel);
        }

        // GET: Client/Details/5
        public ActionResult Details(Guid id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clientVIewModel = Mapper.Map<Client, ClientViewModel>(_clientRepository.GetById(id));

            if (clientVIewModel == null) {
                return HttpNotFound();
            }
            return View(clientVIewModel);
        }

        // GET: Client/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Client/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientViewModel clientViewModel) {
            var clientDomain = Mapper.Map<ClientViewModel, Client>(clientViewModel);
            if (ModelState.IsValid) {

                _clientRepository.Add(clientDomain);

                return RedirectToAction("Index");
            }

            return View(clientViewModel);
        }

        // GET: Client/Edit/5
        public ActionResult Edit(Guid id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = _clientRepository.GetById(id);

            if (client == null) {
                return HttpNotFound();
            }

            var clientViewModel = Mapper.Map<Client, ClientViewModel>(client);
            return View(clientViewModel);
        }

        // POST: Client/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientViewModel clientViewModel) {
            var clientDomain = Mapper.Map<ClientViewModel, Client>(clientViewModel);
            if (ModelState.IsValid) {

                _clientRepository.Update(clientDomain);
                return RedirectToAction("Index");
            }
            return View(clientViewModel);
        }

        // GET: Client/Delete/5
        public ActionResult Delete(Guid id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = _clientRepository.GetById(id);

            if (client == null) {
                return HttpNotFound();
            }

            var clientViewModel = Mapper.Map<Client, ClientViewModel>(client);
            return View(clientViewModel);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id) {
            var client = _clientRepository.GetById(id);
            _clientRepository.Remove(client);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                _clientRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
