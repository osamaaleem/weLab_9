using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using weLab_9.Models;
using weLab_9.DAL;

namespace weLab_9.Controllers
{
    public class MarkerController : Controller
    {
        Marker marker = new Marker();
        MarkerEntity entity = new MarkerEntity();
        // GET: Books
        public ActionResult Index(string id)
        {
            List<Marker> markerList = entity.GetMarkers(id);
            return View(markerList);
        }
        public ActionResult AddMarker()
        {
            ViewBag.colorList = marker.GetColorList();
            return View();
        }
        [HttpPost]
        public ActionResult AddMarker(Marker marker)
        {
            ViewBag.colorList = marker.GetColorList();
            if (ModelState.IsValid)
            {
                int rowsAffected;
                rowsAffected = entity.AddMarker(marker);
                if (rowsAffected > 0)
                {
                    ViewBag.successMsg = "Values added";
                }
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult UpdateMarker(int id)
        {
            ViewBag.colorList = marker.GetColorList();
            return View(entity.GetMarkerById(id));
        }
        public ActionResult Delete(int id)
        {
            entity.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            return RedirectToAction("Index", new {id = id});
        }

    }
}