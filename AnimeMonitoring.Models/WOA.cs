using AngleSharp.Dom;
using System;
using System.Text.RegularExpressions;

namespace AnimeMonitoring.Models
{
	[Serializable]
	internal class WOA : Model
	{
		public WOA(IDocument document) : base(document)
		{
		}

		protected override int getCountVideo(IElement document)
		{
			return Regex.Matches(document.InnerHtml.ToString(), "video-[0-9]*_[0_9]*").Count;
		}

		protected override void Parse(IDocument document)
		{
			try
			{
                name = document.Title.Split(new char[]
				{
					'/'
				});
                imageUrl = document.QuerySelector("img[style='width:280px; height:360px;']").GetAttribute("src");
                description = document.GetElementsByClassName("wk_table wk_table_no_border")[1].TextContent.Replace("Описание:", "");
                count = getCountVideo(document.Body);
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
