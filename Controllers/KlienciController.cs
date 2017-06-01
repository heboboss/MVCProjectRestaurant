using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Dodane żeby można było korzystać z klas znajdujących się w folderze "Models"
using Projekt.Models;

namespace Projekt.Controllers
{
    public class KlienciController : Controller
    {
        static List<KlientModel> listaKlientow = new List<KlientModel>();
        static List<List<ZamowienieModel>> listaZamowien = new List<List<ZamowienieModel>>();

        // GET: Klienci
        public ActionResult Index()
        {
            return View(listaKlientow);
        }

        [HttpGet]
        public ActionResult Edytuj(int ? id)
        {
            return View(id != null
                ? listaKlientow[(int)id]
                : new KlientModel());
        }

        [HttpPost]
        public ActionResult Edytuj(int ? id, KlientModel klient)
        {
            if (id == null)
            {
                listaKlientow.Add(klient);
                listaZamowien.Add(new List<ZamowienieModel>());
            }
            else
                listaKlientow[(int)id] = klient;
            return RedirectToAction("Index");
        }

        public ActionResult Zamowienie(int ? id)
        {
            return View(listaZamowien[(int)id]);
        }


    }
}