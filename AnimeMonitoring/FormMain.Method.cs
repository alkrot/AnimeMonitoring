﻿using AnimeMonitoring.Models;
using AnimeMonitoring.Controllers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using AngleSharp.Dom;
using System.Linq;

namespace AnimeMonitoring
{
    partial class FormMain
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
            if (!list.AnimeHasList(anime))
            {
                timerCheckVideo.Enabled = false;
                list.Items.Add(anime);
                tabSite.SelectedTab = tab;
                timerCheckVideo.Enabled = true;
            }
        }

        /// <summary>
        /// Определение куда добавить модель
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
        /// Показ информации при клики на элемент в спсике
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowInfo(object sender, EventArgs e)
        {
            ListBox list = (ListBox)sender;
            if (list.Items.Count > 0 && list.SelectedIndex >= 0)
            {
                ShowAnimeDescription(list);
            }
        }

        /// <summary>
        /// Показ иноформации о аниме в интерфейсе
        /// </summary>
        /// <param name="list">Список откуда брать</param>
        private void ShowAnimeDescription(ListBox list)
        {
            Model model = (Model)list.SelectedItem;
            pPoster.ImageLocation = model.ImageUrl;
            rDescription.Text = model.Info;
            linkAnimeUrl.Text = model.Url;
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
                ShowNotify("Аниме удалено из списка");
            }
        }

        /// <summary>
        /// Показ уведомления
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="icon">Тип иконки</param>
        public void ShowNotify(string message, string title = "АнимеМониторинг", ToolTipIcon icon = ToolTipIcon.None, int timeout = 3000)
        {
            notifyAnime.ShowBalloonTip(timeout, title, message, icon);
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
        private void SaveBinnary(string path, List<Model> datList = null, List<string> alList = null)
        {
            BinaryFormatter formater = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                if (datList != null && datList.Count > 0) formater.Serialize(fs, datList);
                if (alList != null && alList.Count > 0) formater.Serialize(fs, alList);
                ShowNotify("Список сохранен");
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

            var listBox = tabSite.Controls.Cast<TabPage>().ToDictionary(a => a, v => v.Controls[0]).Select(v => v.Value as ListBox);

            foreach(var list in listBox)
            {
                list.SetMarkTab();
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


        /// <summary>
        /// Отметить как увиденно в списке выбранные элементы
        /// </summary>
        /// <param name="listBox">Активный список</param>
        /// <param name="animeList">Выбранные элементы</param>
        private void CheckLookList(ListBox listBox, ListBox.SelectedObjectCollection animeList)
        {
            for (int i = 0; i < animeList.Count; i++)
            {
                var anime = animeList[i] as Model;
                if (anime.ToString().StartsWith("*"))
                {
                    anime.AbortedNewSeries();
                    listBox.ReplaceAnime(anime);
                }
            }
            ShowNotify("Выбранные элементы были отмечаны как увиденные");
        }

        /// <summary>
        /// Отметить все как увиденно списке
        /// </summary>
        /// <param name="listBox">Список</param>
        /// <param name="items">Элементы списка</param>
        private void CheckLookList(ListBox listBox, ListBox.ObjectCollection items, bool onlyList = true)
        {
            for (int i = 0; i < items.Count; i++)
            {
                var anime = items[i] as Model;
                if (anime.ToString().StartsWith("*"))
                {
                    anime.AbortedNewSeries();
                    listBox.ReplaceAnime(anime);
                }
            }
            if (onlyList)
                ShowNotify("В активном списке все отмечено как увиденое");
        }
    }
}
