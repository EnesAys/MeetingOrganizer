using MeetingOrganizer.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MeetingOrganizer.UI.Controllers
{
    public class KatilimciController : Controller
    {
        
        ToplantiContext db = new ToplantiContext();

        public ActionResult Index()     // GET: Katilimci
        {
            return View(db.Katilimcilar.ToList());
        }



        #region Create Part

        [HttpGet]// Create Get
        public ActionResult Create()
        {
            #region DDL Toplanti Doldurma
            List<SelectListItem> IcerikTurListe =
                     (from k in db.Toplantilar
                      select new SelectListItem
                      {
                          Text = k.Konu,
                          Value = k.ID.ToString()
                      }).ToList();



            ViewBag.Liste = IcerikTurListe;


            #endregion

            return View();
        }


        [HttpPost]// Create Get
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ad,Soyad,ToplantiID")]Katilimci kt)
        {
            if (ModelState.IsValid)
            {
                db.Katilimcilar.Add(kt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kt);
        }
        #endregion
        #region Edit Part
        public ActionResult Edit(int? id) //Edit Get
        {
            #region DDL Toplanti Doldurma
            List<SelectListItem> IcerikTurListe =
                     (from k in db.Toplantilar
                      select new SelectListItem
                      {
                          Text = k.Konu,
                          Value = k.ID.ToString()
                      }).ToList();



            ViewBag.Liste = IcerikTurListe;


            #endregion

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Katilimci tp = db.Katilimcilar.Find(id);
            if (tp == null)
            {
                return HttpNotFound();
            }

            return View(tp);
        }
        [HttpPost]//Edit Post
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ad,Soyad,ToplantiID")]Katilimci kt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kt);
        }
        #endregion
        #region DeletePart
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Katilimci kt = db.Katilimcilar.Find(id);
            if (kt == null)
            {
                return HttpNotFound();
            }

            return View(kt);
        }

        //Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Katilimci kt = db.Katilimcilar.Find(id);
            db.Katilimcilar.Remove(kt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion
    }
}