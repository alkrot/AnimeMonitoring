using AngleSharp.Dom;
using System;
using System.IO;
using System.Linq;

namespace AnimeMonitoring.Models
{
	[Serializable]
	public abstract class Model
	{
		protected string url;

		protected string imageUrl;

		protected string[] name;

		protected string description;

		protected int count;

		protected bool newSeries = false;

		public string Url
		{
			get
			{
				return url;
			}
		}

		public string ImageUrl
		{
			get
			{
				return imageUrl;
			}
		}

		public string[] Name
		{
			get
			{
				return name;
			}
		}

		public string Description
		{
			get
			{
				return description;
			}
		}

		public int Count
		{
			get
			{
				return count;
			}
		}

		public string Info
		{
			get
			{
				return string.Format("Количество: {3}\r\nНазвание: {1}\r\nОписание: {2}\r\n", new object[]
				{
                    imageUrl,
                    name.First(),
                    description,
                    count
                });
			}
		}

		public Model(IDocument document)
		{
            url = document.BaseUri;
            Parse(document);
		}

		protected abstract void Parse(IDocument document);

		protected abstract int getCountVideo(IElement document);

		public bool isNewVideo(IDocument doc)
		{
			int getCount = getCountVideo(doc.Body);
            newSeries = (count < getCount);
			bool flag = newSeries;
			if (flag)
			{
                Parse(doc);
                count = getCount;
			}
			return newSeries;
		}

		public override string ToString()
		{
			return Name.First() + (newSeries ? "*" : "");
		}

		protected void WriteLog(string txt)
		{
			using (StreamWriter writer = new StreamWriter("log.txt", true))
			{
				writer.WriteLine(txt);
			}
		}
	}
}
