using Ass_10WebApplication_PartialView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ass_10WebApplication_PartialView.Controllers
{
    public class CricketController : Controller
    {
        // GET: Cricket
        static List<Cricket> cric = new List<Cricket>()
        {
            new Cricket(){TeamId=1,TeamName="India",NOWC=2 },
            new Cricket(){TeamId=2,TeamName="Australia",NOWC=4},
            new Cricket(){TeamId=3,TeamName="West Indies",NOWC=2 },
            new Cricket(){TeamId=4,TeamName="England",NOWC=1}


        };

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Cricket());
        }
        [HttpPost]
        public ActionResult Create(Cricket cricket)
        {
            if (ModelState.IsValid)
            {
                cric.Add(cricket);
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Cricket cricketToEdit = cric.FirstOrDefault(c => c.TeamId == id);

            if (cricketToEdit == null)
            {
                return HttpNotFound();
            }

            return View(cricketToEdit);
        }

        [HttpPost]
        public ActionResult Edit(Cricket cricket)
        {
            if (ModelState.IsValid)
            {
                Cricket existingCricket = cric.FirstOrDefault(c => c.TeamId == cricket.TeamId);

                if (existingCricket != null)
                {
                    existingCricket.TeamName = cricket.TeamName;
                    existingCricket.NOWC = cricket.NOWC;
                }

                return RedirectToAction("Index");
            }

            return View(cricket);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Cricket cricketToDelete = cric.FirstOrDefault(c => c.TeamId == id);

            if (cricketToDelete == null)
            {
                return HttpNotFound();
            }

            return View(cricketToDelete);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cricket cricketToDelete = cric.FirstOrDefault(c => c.TeamId == id);

            if (cricketToDelete != null)
            {
                cric.Remove(cricketToDelete);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {

            Cricket cricketDetails = cric.FirstOrDefault(c => c.TeamId == id);


            if (cricketDetails == null)
            {
                return HttpNotFound();
            }


            return View(cricketDetails);
        }


        public ActionResult Index()
        {
            ViewBag.Msg = "Welcome to CricInfo";
            ViewBag.noEmp = cric.Count;

            return View(cric);
        }

        public ActionResult Display()
        {
            return View();
        }
       
    }
}