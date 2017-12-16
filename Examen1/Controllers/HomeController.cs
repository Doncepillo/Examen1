using Examen1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen1.Controllers
{
    public class HomeController : Controller
    {
        testEntities1 cnx;

        public HomeController()
        {
            cnx = new testEntities1();

        }
        public ActionResult Formulario()
        {

            return View();
        }

        public ActionResult Listado()
        {

            cnx.Database.Connection.Open();

            List<VACAS> vacas = cnx.VACAS.ToList();
            cnx.Database.Connection.Close();
            return View(vacas);
        }


        public ActionResult Guardar(int diio, string nombre, string sexo, string raza, int edad, string tipo, string rebaño)
        {
            VACAS vacas = new VACAS()
            {
                diio = diio,
                nombre = nombre,
                sexo = sexo,
                raza = raza,
                edad = edad,
                tipo = tipo,
                rebaño = rebaño
            };

            cnx.VACAS.Add(vacas);
            cnx.SaveChanges();
            return View("Listado", cnx.VACAS.ToList());

        }



        public ActionResult Ficha(int diio)
        {

            return View(cnx.VACAS.Where(x=>x.diio == diio).First());
            
        }


        

        public ActionResult Ver(string diio)
        {


            return View("Ficha", null);
        }
    }
}