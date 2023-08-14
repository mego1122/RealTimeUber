using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RealTimeUber.Controllers
{
    public class xController : Controller
    {
        // GET: xController
        public ActionResult Index()
        {
            return View();
        }

        // GET: xController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: xController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: xController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: xController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: xController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: xController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: xController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
