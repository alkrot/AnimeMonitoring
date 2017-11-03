using AngleSharp;
using AnimeMonitoring.Models;

namespace AnimeMonitoring.Controllers
{
    internal class Controller
    {
        private FormMain formMain;

        /// <summary>
        /// Инцилиазция
        /// </summary>
        /// <param name="formMain">Форма как вьюшка</param>
		public Controller(FormMain formMain)
        {
            this.formMain = formMain;
        }

        /// <summary>
        /// Определение по ссылки к какой модели отнсится и добавление в список
        /// </summary>
        /// <param name="url">ссылка</param>
        public async void AddAnime(string url)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync(url);

            if (document.Body.TextContent.Length == 0) return;

            if (url.Contains("smotret-anime.ru"))
            {
                Anime365 anime365 = new Anime365(document);
                formMain.AddView(anime365);
            }
            else if (url.Contains("aniplay.tv"))
            {
                Aniplay aniplay = new Aniplay(document);
                formMain.AddView(aniplay);
            }
            else if (url.Contains("sovetromantica.com"))
            {
                SovetRomantic sovetRomantic = new SovetRomantic(document);
                formMain.AddView(sovetRomantic);
            }
            else if (url.Contains("rutracker"))
            {
                RutrackerForAnime rutrackerForAnime = new RutrackerForAnime(document);
                formMain.AddView(rutrackerForAnime);
            }
            else if (url.Contains("page-30260297"))
            {
                WOA woa = new WOA(document);
                formMain.AddView(woa);
            }
        }
    }
}
