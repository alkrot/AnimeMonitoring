using AngleSharp.Dom;
using System;

namespace AnimeMonitoring.Models
{
	[Serializable]
	public class Aniplay : Model
	{
		public Aniplay(IDocument document) : base(document)
		{
		}

		protected override int GetCountVideo(IElement document)
		{
			int result;
			try
			{
                result = document.GetElementsByClassName("episodes-list")[0].GetElementsByTagName("tr").Length;
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}

		protected override void Parse(IDocument document)
		{
			try
			{
                name = document.GetElementsByClassName("ap2-section-header")[0].TextContent.Trim().Split(new char[]
				{
					'/'
				});
                description = document.GetElementsByClassName("ap2-anime-description")[0].TextContent;
                imageUrl = "http://aniplay.tv" + document.GetElementsByClassName("ap2-anime-poster")[0].GetAttribute("src");
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
