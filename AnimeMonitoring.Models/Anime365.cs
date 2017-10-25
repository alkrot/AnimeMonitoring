using AngleSharp.Dom;
using System;

namespace AnimeMonitoring.Models
{
	[Serializable]
	public class Anime365 : Model
	{
		public Anime365(IDocument document) : base(document)
		{
		}

		protected override int GetCountVideo(IElement document)
		{
			return document.GetElementsByClassName("m-episode-item").Length;
		}

		protected override void Parse(IDocument document)
		{
			try
			{
                name = new string[]
				{
					document.GetElementsByClassName("line-1")[0].TextContent.Replace("смотреть онлайн", ""),
					document.GetElementsByClassName("line-2")[0].TextContent
				};
				IHtmlCollection<IElement> descDoc = document.GetElementsByClassName("card m-description-item");
				bool flag = descDoc.Length > 0;
				if (flag)
				{
                    description = descDoc[0].TextContent.Replace("Описание аниме", "");
				}
                imageUrl = "https://smotret-anime.ru" + document.QuerySelector("img[itemprop='contentUrl']").GetAttribute("src");
                count = GetCountVideo(document.Body);
			}
			catch (Exception er)
			{
                WriteLog(string.Concat(new object[]
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
