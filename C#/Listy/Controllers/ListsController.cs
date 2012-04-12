using System.Web.Mvc;
using Listy.Models;

namespace Listy.Controllers
{
	public class ListsController : Controller
	{
		public ActionResult Index(string id)
		{
			ViewBag.Id = id;

			if (string.IsNullOrEmpty(id))
				if (!string.IsNullOrEmpty(ApplicationDetails.ListId))
					return Redirect(string.Format("/lists/index/{0}", ApplicationDetails.ListId));
			
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
