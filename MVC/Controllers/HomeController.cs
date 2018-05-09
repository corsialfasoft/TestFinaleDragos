using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers {
    public class HomeController : Controller {
        IDataModel dm = new DataModel();
        public ActionResult Index() {
            return View();
        }
        public ActionResult AddMenu() {
            return View();
        }
        [HttpPost]
        public ActionResult AddMenu(DateTime _data, string _pasto, string _primo,string _secondo, string _contorno, string _dolce) {
            Menu menu = new Menu{Data = _data, Pasto =_pasto,Primo=_pasto,Secondo=_secondo,Contorno=_contorno,Dolce=_dolce};
            dm.AddMenu(menu);
            ViewBag.Message = "Menu Inserito con successo";
            return ListaMenu();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult DettaglioMenu(int id) {
            ViewBag.Menu = dm.ShowMenu(id);
            return View();
        }
        public ActionResult DettaglioMenu() {
            return View();
        }

        public ActionResult ListaMenu() {
            ViewBag.Menus = dm.ListMenu();
            return View("ListaMenu");
        }
    }
}