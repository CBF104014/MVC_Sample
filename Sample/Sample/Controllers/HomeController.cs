using Newtonsoft.Json;
using Sample.Cls;
using Sample.Models;
using Sample.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return LoginInfo();
        }


        [HttpPost]
        public ActionResult Index(Member _Member)
        {
            var Result = new MemberService().Read(_Member);
            if (Result.Count != 0) {
                Session["UserId"] = Result[0].UserId;
                ViewBag.UserId = Result[0].UserId;
            }
            return Json(Result);
        }

        [HttpPost]
        public ActionResult SignUp(Member _Member)
        {
            var rs = ReturnCode.Fail;
            MemberService service = new MemberService();
            var Result = service.Read(_Member);
            if (Result.Count == 0)
                rs = service.Create(_Member);
            return Json(rs);
        }

        public ActionResult Shop()
        {
            
            return LoginInfo();
        }

        public ActionResult Cart()
        {

            return LoginInfo();
        }

        public ActionResult Member()
        {
            var Result = new MemberService().ReadAll();
            ViewBag.Members = Result;
            return LoginInfo();
        }
        
        public ActionResult BackMGT()
        {
            return LoginInfo();
        }

        [HttpPost]
        public ActionResult SelBackMGT(Product product)
        {
            var Service = new ProductService();
            var Result = Service.Read("");
            return Json(JsonConvert.SerializeObject(Result));
        }

        [HttpPost]
        public ActionResult AddBackMGT(Product product)
        {
            var Service = new ProductService();
            return Json(Service.Create(product));
        }

        [HttpPost]
        public ActionResult UpdBackMGT(Product product)
        {
            var Service = new ProductService();
            return Json(Service.Update(product));
        }

        [HttpPost]
        public ActionResult DelBackMGT(Product product)
        {
            var Service = new ProductService();
            return Json(Service.Delete(product));
        }

        public ActionResult Test()
        {
            var Result = new MemberService().ReadAll();
            ViewBag.Members = Result;
            return LoginInfo();
        }


        #region 登入資訊
        #endregion
        public ActionResult LoginInfo() {
            var UserId = "";
            if (Session["UserId"] != null)
            {
                UserId = Session["UserId"].ToString();
            }
            ViewBag.UserId = UserId;
            return View(Json(new { UserId = UserId }));
        }
    }
}