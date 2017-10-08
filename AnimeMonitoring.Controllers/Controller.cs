using AngleSharp;
using AnimeMonitoring.Models;

namespace AnimeMonitoring.Controllers
{
    internal class Controller
	{
		private FormMain formMain;

		public Controller(FormMain formMain)
		{
			this.formMain = formMain;
		}

		
		public async void addAnime(string url)
		{
            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync(url);

            if (url.Contains("smotret-anime.ru"))
            {
                Anime365 anime365 = new Anime365(document);
                formMain.addView(anime365);
            }else if (url.Contains("aniplay.tv"))
            {
                Aniplay aniplay = new Aniplay(document);
                formMain.addView(aniplay);
            }else if (url.Contains("sovetromantica.com"))
            {
                SovetRomantic sovetRomantic = new SovetRomantic(document);
                formMain.addView(sovetRomantic);
            }else if (url.Contains("rutracker"))
            {
                RutrackerForAnime rutrackerForAnime = new RutrackerForAnime(document);
                formMain.addView(rutrackerForAnime);
            }else if (url.Contains("page-30260297"))
            {
                WOA woa = new WOA(document);
                formMain.addView(woa);
            }
		}
	}
}
