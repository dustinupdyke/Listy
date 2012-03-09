using System.Linq;
using System.Web.Mvc;
using Listy.Models;

namespace Listy.Controllers
{
	public class ListsController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Id = null;
			return View();
		}

		public ActionResult Index2(string id)
		{
			ViewBag.Id = id;
			return View();
		}

		public ActionResult Read(string id)
		{
			var model = ListyModel.LoadById(id);
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public ActionResult Create()
		{
			var rawFormValues = Server.UrlDecode(Request.Form.ToString());
			var model = new ListyModel();
			return Json(model.Create(rawFormValues), JsonRequestBehavior.AllowGet);
		}
	}
}
