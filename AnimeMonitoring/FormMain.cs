using AngleSharp;
using AngleSharp.Dom;
using AnimeMonitoring.Controllers;
using AnimeMonitoring.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace AnimeMonitoring
{
    public partial class FormMain : Form
	{
		public FormMain()
		{
            InitializeComponent();
            controller = new Controller(this);
		}

        private Controller controller;

        private void btnAdd_Click(object sender, EventArgs e)
		{
			string[] lines = tUrl.Lines;
			for (int i = 0; i < lines.Length; i++)
			{
				string url = lines[i];
				if (!string.IsNullOrEmpty(url))
				{
                    controller.addAnime(url);
				}
			}
            tUrl.Clear();
		}

		private void addView(Model anime, ListBox list, TabPage tab)
		{
			if (!isHas(list, anime))
			{
                timerCheckVideo.Enabled = false;
				list.Items.Add(anime);
                tabSite.SelectedTab = tab;
                timerCheckVideo.Enabled = true;
			}
		}

		public void addView(Model m)
		{
			string name = m.GetType().Name;
            switch (name)
            {
                case "Anime365":
                    addView(m, lAnime365, tabAnime365);
                    break;
                case "Aniplay":
                    addView(m, lAniplay, tabAniplay);
                    break;
                case "SovetRomantic":
                    addView(m, lSovetRomantic, tabSR);
                    break;
                case "WOA":
                    addView(m, lWOA, tabWOA); 
                    break;
                case "RutrackerForAnime":
                    addView(m, lRutracker, tabRutracker);
                    break;
            }
		}

		private bool isHas(ListBox box, Model anime)
		{

			foreach (Model item in box.Items)
                if (item.Url == anime.Url)
                    return true;

			return false;
		}

		private int indexHas(ListBox list, Model anime)
		{
			for (int i = 0; i < list.Items.Count; i++)
			{
				Model model = (Model)list.Items[i];
				if (model.Name == anime.Name)
                    return i;
			}
			return -1;
		}

		private void replaceAnime(ListBox list, Model anime)
		{
			int index = indexHas(list, anime);
			list.Items.RemoveAt(index);
			list.Items.Insert(index, anime);
		}

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

		private void DelAnime(object sender, KeyEventArgs e)
		{
			ListBox list = (ListBox)sender;
			if (list.Items.Count > 0 && list.SelectedIndex >= 0 && e.KeyData == Keys.Delete && MessageBox.Show("Удалить?", ((Model)list.SelectedItem).Name[0], MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				list.Items.RemoveAt(list.SelectedIndex);
			}
		}

		private void SaveAnime(string file = "anime.dat")
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
			BinaryFormatter formater = new BinaryFormatter();
			using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
			{
				formater.Serialize(fs, anime);
				MessageBox.Show("Список сохранен");
			}
		}

		private void OpenAnime(string file = "anime.dat")
		{
			BinaryFormatter format = new BinaryFormatter();
			using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
			{
				if (fs.Length > 0)
				{
					List<Model> models = (List<Model>)format.Deserialize(fs);
					foreach (Model model in models)
					{
                        addView(model);
					}
				}
			}
		}

		private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
            SaveAnime();
		}

		private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
		{
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.dat|*.dat";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                OpenAnime(filename);
            }
        }

		private void FormMain_Load(object sender, EventArgs e)
		{
            OpenAnime();
            tabSite.SelectedIndex = 0;
		}

		private bool RefreshSeries(Model anime, IDocument document)
		{
            tStatusLabel.Text = "Проверка: " + anime.Name[0] + " Источник: " + anime.GetType().Name;
            notifyAnime.BalloonTipText = tStatusLabel.Text;
            notifyAnime.ShowBalloonTip(2000);
            if (anime.GetType().Name == "RutrackerForAnime") (anime as RutrackerForAnime).isNewVideo(document);
            return anime.isNewVideo(document);
		}

		private void linkAnimeUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
            if (e.Button == MouseButtons.Left)
            {
                Process.Start(((LinkLabel)sender).Text);
            }
            else if (e.Button == MouseButtons.Right)
            {
                Clipboard.SetText(((LinkLabel)sender).Text);
            }
		}

		private void label1_Click(object sender, EventArgs e)
		{
			if (splitContainer1.SplitterDistance > 25)
			{
                tUrl.Enabled = false;
                splitContainer1.SplitterDistance = 25;
			}
			else
			{
                tUrl.Enabled = true;
                splitContainer1.SplitterDistance = 200;
			}
		}

		private void labelUrlAnime_MouseEnter(object sender, EventArgs e)
		{
			((Label)sender).BackColor = Color.FromArgb(50, Color.LightBlue);
		}

		private void labelUrlAnime_MouseLeave(object sender, EventArgs e)
		{
			((Label)sender).BackColor = Color.WhiteSmoke;
		}

        private async void timerCheckVideo_Tick(object sender, EventArgs e)
        {
            try
            {
                var config = Configuration.Default.WithDefaultLoader();
                foreach (TabPage tabPage in tabSite.TabPages)
                {
                    ListBox listBox = (ListBox)tabPage.Controls[0];
                    var item = listBox.Items;
                    foreach (Model anime in item)
                    {
                        var document = await BrowsingContext.New(config).OpenAsync(anime.Url);

                        if (RefreshSeries(anime, document))
                        {
                            timerCheckVideo.Enabled = false;
                            replaceAnime(listBox, anime);
                            notifyAnime.ShowBalloonTip(3000, "Новая серия", anime.Name[0], ToolTipIcon.Info);
                            timerCheckVideo.Enabled = true;
                        }
                    }
                }
            }catch(Exception er)
            {

            }
        }

        private void сохранитькакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.dat|*.dat";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog.FileName;
                SaveAnime(filename);
            }
        }

        private void tUrl_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Lines.Length > 0 && !string.IsNullOrWhiteSpace(textBox.Lines[textBox.Lines.Length - 1]))
            {
                SendKeys.Send("{ENTER}");
            }
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }
    }
}
