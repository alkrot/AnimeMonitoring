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

		protected override int GetCountVideo(IElement document)
		{
			return 0;
		}

        /// <summary>
        /// получение количество видео из заголовка
        /// </summary>
        /// <param name="title">Заголовок страницы сайта</param>
        /// <returns>Количество видео</returns>
		private int GetCountVideo(string title)
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

        /// <summary>
        /// Проверка есть ли новые видео
        /// </summary>
        /// <param name="document">Страница сайта</param>
        /// <returns>Булево значение</returns>
		public new bool IsNewVideo(IDocument document)
		{
			int getCount = GetCountVideo(document.Title);
			bool newS = (count < getCount);
			if (newS)
			{
                Parse(document);
                count = getCount;
                newSeries = newS;
			}
			return newSeries;
		}

        /// <summary>
        /// Получение описания (работает несовсем корректно)
        /// </summary>
        /// <param name="element">Элемент где оно находится</param>
        /// <returns></returns>
		private string getDescritpion(IElement element)
		{
			int startIndex = element.TextContent.IndexOf("Описание:");
			int endIndex = element.TextContent.IndexOf("Информационные ссылки", startIndex);
			return element.TextContent.Substring(startIndex, endIndex - startIndex).Replace("Описание:", "");
		}

        /// <summary>
        /// получение информации
        /// </summary>
        /// <param name="document">Страница сайта</param>
		protected override void Parse(IDocument document)
		{
			try
			{
                name = document.Title.Split(new char[]
				{
					'/'
				});
                count = GetCountVideo(document.Title);
                imageUrl = document.GetElementsByTagName("var")[0].GetAttribute("title");
                description = getDescritpion(document.Body);                               
                
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
