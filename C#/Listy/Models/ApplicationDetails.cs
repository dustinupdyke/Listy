using System;
using System.Web;

namespace Listy.Models
{
	public static class ApplicationDetails
	{
		public static string ListId
		{
			get { return HttpContext.Current.Request["list_id"]; }
			set
			{
				var cookie = new HttpCookie("list_id");
				var now = DateTime.Now;
				cookie.Value = value;
				cookie.Expires = now.AddYears(5);
				HttpContext.Current.Response.Cookies.Add(cookie);
			}
		}
	}
}