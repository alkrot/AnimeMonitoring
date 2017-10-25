using AnimeMonitoring.Models;
using AnimeMonitoring.Controllers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using AngleSharp.Dom;

namespace AnimeMonitoring
{
    public partial class FormMain
    {
        Controller controller;

        /// <summary>
        /// Добавление модели в нужный список
        /// </summary>
        /// <param name="anime">Модель</param>
        /// <param name="list">Список - контрол</param>
        /// <param name="tab">Вкладка - контрол</param>
        internal void AddViewListTab(Model anime, ListBox list, TabPage tab)
        {
            if (!IsHas(list, anime))
            {
                timerCheckVideo.Enabled = false;
                list.Items.Add(anime);
                tabSite.SelectedTab = tab;
                timerCheckVideo.Enabled = true;
            }
        }

        /// <summary>
        /// Определение добавить модель
        /// </summary>
        /// <param name="m">Модель</param>
        public void AddView(Model m)
        {
            string name = m.GetType().Name;
            switch (name)
            {
                case "Anime365":
                    AddViewListTab(m, lAnime365, tabAnime365);
                    break;
                case "Aniplay":
                    AddViewListTab(m, lAniplay, tabAniplay);
                    break;
                case "SovetRomantic":
                    AddViewListTab(m, lSovetRomantic, tabSR);
                    break;
                case "WOA":
                    AddViewListTab(m, lWOA, tabWOA);
                    break;
                case "RutrackerForAnime":
                    AddViewListTab(m, lRutracker, tabRutracker);
                    break;
            }
        }

        /// <summary>
        /// Проверка есть ли в списке модель с сотвествующей ссылкой
        /// </summary>
        /// <param name="list">Список - контрол</param>
        /// <param name="anime">Модел</param>
        /// <returns>Булевое значение</returns>
        private bool IsHas(ListBox list, Model anime)
        {
            foreach (Model item in list.Items)
                if (item.Url == anime.Url)
                    return true;
            return false;
        }

        /// <summary>
        /// Вернуть индекс нужной модели в списке
        /// </summary>
        /// <param name="list">Список - контрол</param>
        /// <param name="anime">Модел</param>
        /// <returns>Индекс от 0, если не найден то -1</returns>
        private int IndexHas(ListBox list, Model anime)
        {
            for (int i = 0; i < list.Items.Count; i++)
            {
                Model model = (Model)list.Items[i];
                if (model.Name == anime.Name)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Обновление модели в списке
        /// </summary>
        /// <param name="list">Список - контрол</param>
        /// <param name="anime">Модел</param>
        private void ReplaceAnime(ListBox list, Model anime)
        {
            int index = IndexHas(list, anime);
            list.Items.RemoveAt(index);
            list.Items.Insert(index, anime);
        }

        /// <summary>
        /// Показ информации при клики на элемент в спсике
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowInfo(object sender, EventArgs e)
        {
            ListBox list = (ListBox)sender;
            if (list.Items.Count > 0 && list.SelectedIndex >= 0)
            {
                Model model = (Model)list.SelectedItem;
                pPoster.ImageLocation = model.ImageUrl;
                rDescription.Text = model.Info;
                linkAnimeUrl.Text = model.Url;
            }
        }

        /// <summary>
        /// Удаление модели из списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelAnime(object sender, KeyEventArgs e)
        {
            ListBox list = (ListBox)sender;
            if (list.Items.Count > 0 && list.SelectedIndex >= 0 && e.KeyData == Keys.Delete && MessageBox.Show("Удалить?", ((Model)list.SelectedItem).Name[0], MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                list.Items.RemoveAt(list.SelectedIndex);
            }
        }

        /// <summary>
        /// Сохранение в файл
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        private void SaveAnime(string path = "anime.dat")
        {
            string ext = Path.GetExtension(path);

            if (ext == ".dat")
            {
                List<Model> anime = new List<Model>();
                foreach (TabPage page in tabSite.TabPages)
                {
                    ListBox list = (ListBox)page.Controls[0];
                    foreach (Model model in list.Items)
                    {
                        anime.Add(model);
                    }
                }
                SaveBinnary(path, datList: anime);
            }

            if (ext == ".al")
            {
                List<string> anime = new List<string>();

                foreach (TabPage page in tabSite.TabPages)
                {
                    ListBox list = (ListBox)page.Controls[0];
                    foreach (Model model in list.Items)
                    {
                        anime.Add(model.Url);
                    }
                }
                SaveBinnary(path, alList: anime);
            }
        }

        /// <summary>
        /// Сериализация файла
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="datList">Список моделей</param>
        /// <param name="alList">Список ссылок</param>
        private static void SaveBinnary(string path, List<Model> datList = null, List<string> alList = null)
        {
            BinaryFormatter formater = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                if (datList != null && datList.Count > 0) formater.Serialize(fs, datList);
                if (alList != null && alList.Count > 0) formater.Serialize(fs, alList);
                MessageBox.Show("Список сохранен");
            }
        }

        /// <summary>
        /// Открытие файла
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        private void OpenAnime(string path = "anime.dat")
        {
            BinaryFormatter format = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                {
                    string ext = Path.GetExtension(path);
                    if (ext == ".dat")
                    {
                        List<Model> models = (List<Model>)format.Deserialize(fs);
                        foreach (Model model in models)
                        {
                            AddView(model);
                        }
                    }

                    if (ext == ".al")
                    {
                        List<string> alList = (List<string>)format.Deserialize(fs);
                        foreach (string item in alList)
                            controller.AddAnime(item);
                    }
                }
            }
        }

        /// <summary>
        /// Проверка для обновление модели в списке и оповещения
        /// </summary>
        /// <param name="anime">Модель</param>
        /// <param name="document">Страница сайта для этой модели</param>
        /// <returns>Булево значение</returns>
        private bool RefreshSeries(Model anime, IDocument document)
        {
            tStatusLabel.Text = "Проверка: " + anime.Name[0] + " Источник: " + anime.GetType().Name;
            if (anime.GetType().Name == "RutrackerForAnime") return (anime as RutrackerForAnime).IsNewVideo(document);
            return anime.IsNewVideo(document);
        }
    }
}
