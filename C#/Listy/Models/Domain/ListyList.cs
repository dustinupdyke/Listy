using System;
using System.Collections.Generic;
using System.Linq;

namespace Listy.Models.Domain
{
	public class ListyList
	{
		public string Id { get; set; }
		public string UserId { get; set; }
		public IEnumerable<ListyItem> Items { get; set; }
		
		public void Save()
		{
			using (var db = MongoDbSettings.GetDataBase())
			{
				var repository = db.GetCollection<ListyList>("list");
				if (string.IsNullOrEmpty(this.Id))
					this.Id = Guid.NewGuid().ToString();
				repository.Save(this);
			}
		}

		public static ListyList LoadById(string id)
		{
			using (var db = MongoDbSettings.GetDataBase())
			{
				var repository = db.GetCollection<ListyList>("list");
				
				// iterate over the products
				foreach (var listyList in repository.AsQueryable().ToList())
				{
					if(listyList.Id.Equals(id))
						return listyList;
				}
			}
			return null;	
		}
	}

	public class ListyItem
	{
		public string Id { get; set; }
		public string Artist { get; set; }
		public string Song { get; set; }
		public string VideoUrl { get; set; }
		public string ThumbUrl { get; set; }
		public string Comments { get; set; }

		public ListyItem()
		{ }

		public ListyItem(string id, string artist, string song, string comments, string videourl, string thumburl)
		{
			Artist = artist;
			Song = song;
			Id = id;
			VideoUrl = videourl;
			ThumbUrl = thumburl;
			Comments = comments;
		}
	}
}