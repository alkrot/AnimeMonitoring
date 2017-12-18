using AngleSharp.Dom;
using System;
using System.Collections.Generic;
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

        #region Свойства
        public string Url => url;

        public bool NewSeries => newSeries;

        public string ImageUrl => imageUrl;

        public string[] Name => name;

        public string Description => description;

        public int Count => count;

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
        #endregion

        /// <summary>
        /// Конструктор для инцилизации класса хранения информации
        /// </summary>
        /// <param name="document">Страница сайта</param>
        public Model(IDocument document)
        {
            url = document.BaseUri;
            Parse(document);
        }

        /// <summary>
        /// Абстрактный метод для извлечение информации с сайта
        /// </summary>
        /// <param name="document">Страничка сайта</param>
		protected abstract void Parse(IDocument document);

        /// <summary>
        /// Абстрактный метод получение количество видео с страницысайта
        /// </summary>
        /// <param name="element">Элемент в котором находится видео</param>
        /// <returns></returns>
		protected abstract int GetCountVideo(IElement element);

        /// <summary>
        /// Получение информация есть ли новое видео
        /// </summary>
        /// <param name="doc">Страница сайта</param>
        /// <returns>Булево значение</returns>
		public bool IsNewVideo(IDocument doc)
        {
            int getCount = GetCountVideo(doc.Body);
            bool newS = (count < getCount);
            if (newS)
            {
                Parse(doc);
                count = getCount;
                newSeries = newS;
            }
            return newS;
        }

        public void AbortedNewSeries()
        {
            newSeries = false;
        }

        public override string ToString()
        {
            return (newSeries ? "*" : "") + Name.First();
        }

        protected void WriteLog(string txt)
        {
            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine(txt);
            }
        }

        public override bool Equals(object obj)
        {
            var model = (Model)obj;
            return url == model.url;
        }

        public override int GetHashCode()
        {
            return 1227826894 + EqualityComparer<string>.Default.GetHashCode(url);
        }
    }
}
