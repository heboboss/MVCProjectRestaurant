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
        static int aktualneZamowienie;

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

        [HttpGet]
        public ActionResult Usun(int? id)
        {
            if (id != null)
            {
                listaKlientow.RemoveAt((int)id);
                listaZamowien.RemoveAt((int)id);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Zamowienie(int ? id)
        {
            ViewBag.id = (int)id;
            aktualneZamowienie = (int)id;
            return View(listaZamowien[(int)id]);
        }

        [HttpGet]
        public ActionResult EdytujZamowienie(int? id ,int? idZam)
        {
            ViewBag.id = (int)id;
            return View(idZam != null
                ? listaZamowien[aktualneZamowienie][(int)idZam]
                : new ZamowienieModel());
        }

        [HttpPost]
        public ActionResult EdytujZamowienie(int? id, int? idZam, ZamowienieModel zamowienie)
        {
            ViewBag.id = (int)id;
            if (idZam == null)
            {
                listaZamowien[aktualneZamowienie].Add(zamowienie);
            }
            else
                listaZamowien[aktualneZamowienie][(int)idZam] = zamowienie;
            return RedirectToAction("Zamowienie", new { id = aktualneZamowienie });
        }

        [HttpGet]
        public ActionResult UsunZamowienie(int? idZam)
        {
            if(idZam != null)
            {
                listaZamowien[aktualneZamowienie].RemoveAt((int)idZam);
            }

            return RedirectToAction("Zamowienie", new { id = aktualneZamowienie });
        }


    }
}