using AngleSharp.Dom;
using System;
using System.Text.RegularExpressions;

namespace AnimeMonitoring.Models
{
	[Serializable]
	internal class RutrackerForAnime : Model
	{
		public RutrackerForAnime(IDocument document) : base(document)
		{
		}

		protected override int getCountVideo(IElement document)
		{
			return 0;
		}

		private int getCountVideo(string title)
		{
			string series = Regex.Match(title, "\\[(\\d+[-\\d+]*) из \\d+\\]").Groups[1].Value.ToString();
			int count;
			bool flag = int.TryParse(series, out count);
			int result;
			if (flag)
			{
				result = count;
			}
			else
			{
				result = int.Parse(series.Split(new char[]
				{
					'-'
				})[1].Trim());
			}
			return result;
		}

		public new bool isNewVideo(IDocument document)
		{
			int getCount = getCountVideo(document.Title);
			this.newSeries = (count < getCount);
			bool newSeries = this.newSeries;
			if (newSeries)
			{
                Parse(document);
                count = getCount;
			}
			return this.newSeries;
		}

		private string getDescritpion(IElement doc)
		{
			int startIndex = doc.TextContent.IndexOf("Описание:");
			int endIndex = doc.TextContent.IndexOf("Информационные ссылки", startIndex);
			return doc.TextContent.Substring(startIndex, endIndex - startIndex).Replace("Описание:", "");
		}

		protected override void Parse(IDocument document)
		{
			try
			{
                name = document.Title.Split(new char[]
				{
					'/'
				});
                count = getCountVideo(document.Title);
                imageUrl = document.GetElementsByTagName("var")[0].GetAttribute("title");
                description = getDescritpion(document.Body);                               
                
			}
			catch (Exception er)
			{
				base.WriteLog(string.Concat(new object[]
				{
					er.Source,
					":",
					er.TargetSite,
					":",
					er.Message
				}));
			}
		}
	}
}
