using AngleSharp.Dom;
using System;

namespace AnimeMonitoring.Models
{
    [Serializable]
    public class SovetRomantic : Model
    {
        public SovetRomantic(IDocument document) : base(document)
        {
        }

        protected override int GetCountVideo(IElement document)
        {
            count = document.GetElementsByClassName("episodes-slick_item").Length;
            return count;
        }

        protected override void Parse(IDocument document)
        {
            try
            {
                name = document.GetElementsByClassName("anime-name")[0].GetElementsByTagName("div")[0].TextContent.Trim().Split(new char[]
                {
                    '/'
                });
                imageUrl = document.GetElementsByClassName("anime-poster")[0].GetAttribute("style").Split(new char[]
                {
                    '(',
                    ')'
                })[1];
                IElement descriptionHtml = document.GetElementsByClassName("block--full anime-description")[0];
                description = descriptionHtml.TextContent;
                count = GetCountVideo(document.Body);
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
