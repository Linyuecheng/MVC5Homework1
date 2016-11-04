using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Homework1.Models;
using MVC5Homework1.Models.ViewModels;
using System.Data.Entity.Validation;

namespace MVC5Homework1.Controllers
{
    public class 客戶資料Controller : Controller
    {
        //private CustomDataEntities db = new CustomDataEntities();
        客戶資料Repository repo = RepositoryHelper.Get客戶資料Repository();

        // GET: 客戶資料
        public ActionResult Index(string CustomerName = "")
        {
            var 客戶資料 = repo.All().Where(c => c.Is刪除 == false);
            //var 客戶資料 = db.客戶資料.Where(c => c.Is刪除 == false);
            if (!string.IsNullOrWhiteSpace(CustomerName))
            {
                客戶資料 = 客戶資料.Where(c => c.客戶名稱.Contains(CustomerName));
            }
            return View(客戶資料.ToList());
        }

        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = repo.Find(id.Value);
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 客戶資料/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                repo.Add(客戶資料);
                repo.UnitOfWork.Commit();
                //db.客戶資料.Add(客戶資料);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = repo.Find(id.Value);
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                var db = repo.UnitOfWork.Context;
                db.Entry(客戶資料).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = repo.Find(id.Value);
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶資料 客戶資料 = repo.Find(id);
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            //db.客戶資料.Remove(客戶資料);
            //客戶資料.Is刪除 = true;
            string errMsg = string.Empty;
            try
            {
                repo.Delete(客戶資料);
                repo.UnitOfWork.Commit();
            }
            catch (DbEntityValidationException deve)
            {
                foreach (var deveErrs in deve.EntityValidationErrors)
                {
                    foreach (var err in deveErrs.ValidationErrors)
                    {
                        errMsg += err.ErrorMessage + err.PropertyName + "<br>";
                    }
                }
                return Content(errMsg);
            }

            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                repo.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult ShowCustomerInfo()
        {
            vw_CustomerInfoRepository vwRepo = RepositoryHelper.Getvw_CustomerInfoRepository();
            var data = vwRepo.All().OrderBy(c => c.客戶名稱).Take(50);
            //var data = db.vw_CustomerInfo.Take(10);
            return View(data);
        }

    }
}
