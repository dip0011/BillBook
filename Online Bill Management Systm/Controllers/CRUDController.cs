using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Bill_Management_Systm.Models;
using System.Net.Http;

namespace Online_Bill_Management_Systm.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public ActionResult Index()
        {
            IEnumerable<BILL> BILLobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44372/api/BILLCrud");

            var consumeapi = hc.GetAsync("BILLCrud");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<BILL>>();
                displaydata.Wait();

                BILLobj = displaydata.Result;
            }
            return View(BILLobj);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BILL insertBILL)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44372/api/BILLCrud");

            var insertrecord = hc.PostAsJsonAsync<BILL>("BILLCrud", insertBILL);
            insertrecord.Wait();

            var saveData = insertrecord.Result;
            if (saveData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public ActionResult Details(int id)
        {
            BILLClass BILLobj = null;

            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44372/api/");

            var consumeapi = hc.GetAsync("BILLCrud?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<BILLClass>();
                displaydata.Wait();
                BILLobj = displaydata.Result;
            }
            return View(BILLobj);
        }
        
        public ActionResult Edit(int id)
        {
            BILLClass BILLobj = null;

            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44372/api/");

            var consumeapi = hc.GetAsync("BILLCrud?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<BILLClass>();
                displaydata.Wait();
                BILLobj = displaydata.Result;
            }
            return View(BILLobj);
        }

        [HttpPost]
        public ActionResult Edit(BILLClass bc)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44372/api/BILLCrud");

            var insertrecord = hc.PutAsJsonAsync<BILLClass>("BILLCrud", bc);
            insertrecord.Wait();

            var saveData = insertrecord.Result;
            if (saveData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Bill Record Not Updated ... !";
            }
            return View("bc");
        }

        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44372/api/BILLCrud");

            var delrecord = hc.DeleteAsync("BILLCrud/" + id.ToString());
            delrecord.Wait();

            var displaydata = delrecord.Result;
            if(displaydata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
} 