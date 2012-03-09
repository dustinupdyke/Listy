using System.Collections.Generic;
using Listy.Models.Domain;
using Newtonsoft.Json;

namespace Listy.Models
{
	public class ListyModel
	{
		public ListyList Create(string rawFormData)
		{
			dynamic d = JsonConvert.DeserializeObject(rawFormData);

			var list = new ListyList();
			var items = new List<ListyItem>();

			foreach (var item in d.items)
			{
				items.Add(new ListyItem(item.order_id.Value.ToString(), item.artist.Value.ToString(), 
					item.song.Value.ToString(), item.comments.Value.ToString(), 
					item.videourl.Value.ToString(), item.thumburl.Value.ToString()));
			}
			list.Items = items;
			list.Id = d.list_id.Value.ToString();
			list.UserId = d.user_id.Value.ToString();

			list.Save();

			return list;
		}

		public static ListyList LoadById(string id)
		{
			return ListyList.LoadById(id);
		}
	}
}