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
    public class ToplantiController : Controller
    {

        ToplantiContext db = new ToplantiContext();
        public ActionResult Index() //GET: Toplanti
        {
            return View(db.Toplantilar.ToList());
        }

        #region Create Part

        [HttpGet]// Create Get
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]// Create Get
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Konu,T_Tarih,BaslangicSaat,BitisSaat")]Toplanti tp)
        {
            if (ModelState.IsValid)
            {

                db.Toplantilar.Add(tp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tp);
        }
        #endregion

        #region Edit Part
        public ActionResult Edit(int? id) //Edit Get
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toplanti tp = db.Toplantilar.Find(id);
            if (tp == null)
            {
                return HttpNotFound();
            }

            return View(tp);
        }
        [HttpPost]//Edit Post
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Konu,T_Tarih,BaslangicSaat,BitisSaat")]Toplanti tp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tp);
        }
        #endregion

        #region Katılımcılar
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICollection<Katilimci> kt = db.Katilimcilar.Where(x => x.ToplantiID == id).ToList();
            if (kt == null)
            {
                return HttpNotFound();
            }

            return View(kt);

        }
        #endregion

    }
}