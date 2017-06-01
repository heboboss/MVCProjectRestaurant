using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekt.Models;

namespace Projekt.Controllers
{
    public class MagazynController : Controller
    {
        static List<MagazynModel> listaSkladnikow = new List<MagazynModel>();

        // GET: Magazyn
        public ActionResult Index()
        {
            return View(listaSkladnikow);
        }

        [HttpGet]
        public ActionResult Edytuj(int? id)
        {
            return View(id != null
                ? listaSkladnikow[(int)id]
                : new MagazynModel());
        }
        [HttpPost]
        public ActionResult Edytuj(int? id, MagazynModel skladnik)
        {
            if (id == null)
                listaSkladnikow.Add(skladnik);
            else
                listaSkladnikow[(int)id] = skladnik;
            return RedirectToAction("Index");
        }

    }
}