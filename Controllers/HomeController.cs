using CarsAgency.Data;
using CarsAgency.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAgency.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;


        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        private void fillCountryList()
        {
            List<SelectListItem> Country = (
                                            from e in _db.ManufacuringCountries
                                            orderby e.countryId
                                            select new SelectListItem() { Text = e.countryName, Value = e.countryId.ToString() }
                                            ).ToList();
            ViewBag.Country = Country;
        }

        private void fillGenderList()
        {
            List<SelectListItem> Gender = (
                                            from e in _db.GenderSet
                                            orderby e.GenderId
                                            select new SelectListItem() { Text = e.GenderName, Value = e.GenderId.ToString() }
                                            ).ToList();
            ViewBag.Gender = Gender;
        }

        public IActionResult Index()
        {
            //List<CarsModel> car = (from e in _db.CarsSet orderby e.CarId select e).ToList();
            fillCountryList();
            fillGenderList();
            var car = _db.CarsSet.Include("ManufacturingCountry").Include("Gender").ToList();
            return View(car);
        }


        [HttpGet]
        public IActionResult Create()
        {
            fillCountryList();
            fillGenderList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(CarsModel car)
        {


            if (ModelState.IsValid)
            {
                _db.CarsSet.Add(car);
                _db.SaveChanges();
                return RedirectToAction("Index", _db.CarsSet);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            fillCountryList();
            fillGenderList();

            CarsModel car = _db.CarsSet.Find(id);

            return View(car);
        }

        [HttpPost]
        public IActionResult Edit(CarsModel car)
        {
            if (ModelState.IsValid)
            {
                _db.CarsSet.Update(car);
                _db.SaveChanges();
                return RedirectToAction("Index", _db.CarsSet);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            CarsModel car = _db.CarsSet.Where(x => x.CarId == id).Include("ManufacturingCountry").Include("Gender").FirstOrDefault();
            _db.Dispose();
            return View(car);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteCar(int id)
        {
            if (ModelState.IsValid)
            {
                CarsModel car = _db.CarsSet.Find(id);
                _db.CarsSet.Remove(car);
                _db.SaveChanges();
                return RedirectToAction("Index", _db.CarsSet);
            }
            return View();
        }


        public IActionResult Details(int id)
        {
            CarsModel car = _db.CarsSet.Where(x => x.CarId == id).Include("ManufacturingCountry").Include("Gender").FirstOrDefault();
            _db.Dispose();
            return View(car);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
