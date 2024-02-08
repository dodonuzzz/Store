using Serilog;
using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using Yeniden_Chum_Bucket.Interfaces;
using Yeniden_Chum_Bucket.Models;

namespace Yeniden_Chum_Bucket.Controllers
{
    public class ProductController : Controller
    {
        public ProductController()
        {

        }
        public readonly ProductContext _myDependency;
        private readonly ProductContext _productContext;

        public ProductController(IMyDependency myDependency, ProductContext productContext)
        {
            _myDependency = (ProductContext)myDependency;
            _productContext = productContext;
        }


        [HttpPost]
        public ActionResult UpdateProductImages()
        {

            _productContext.SaveChanges();

            return View();
        }


        // GET: Product
        public ActionResult Index()
        {
            var productProvider = new ProductProvider(); // Örnek bir ProductProvider sınıfı
            var product = productProvider.GetProduct(); // ProductProvider sınıfındaki metot kullanılıyor

            // Diğer işlemleri yapın
            return View(product);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productContext.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return PartialView("_CreateFormPartial");
        }

        // POST: Product/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UrunAdi,Fiyat")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productContext.Products.Add(product);
                    _productContext.SaveChanges();

                    // Log the successful creation of a product
                    Log.Information("Product created: {ProductName}", product.UrunAdi);

                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Lütfen gerekli alanları doğru bir şekilde doldurun.");
                return PartialView("_CreateFormPartial", product);

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Create işlemi sırasında bir hata oluştu");
                ModelState.AddModelError("", "Bir hata oluştu, lütfen tekrar deneyin.");

                // Log the error that occurred during product creation
                Log.Error("Product creation error: {ErrorMessage}", ex.Message);

                return PartialView("_CreateFormPartial", product);
            }
        }




        // GET: Product/EditForm/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productContext.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return PartialView("_EditFormPartial", product);
        }

        // POST: Product/SaveEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UrunAdi,Fiyat")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productContext.Entry(product).State = EntityState.Modified;
                _productContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView("_EditFormPartial", product);
        }


        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productContext.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = _productContext.Products.Find(id);
            _productContext.Products.Remove(product);
            _productContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _productContext.Dispose();
            }
            base.Dispose(disposing);
        }

    }

}
