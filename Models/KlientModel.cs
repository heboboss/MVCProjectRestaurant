using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class KlientModel
    {
        public String imie { set; get; }
        public String nazwisko { set; get; }
        public String data { set; get; }
        public List<ZamowienieModel> zamowienia;

        public KlientModel()
        {
            zamowienia = new List<ZamowienieModel>();
        }
    }
}