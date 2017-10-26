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

        private void btnAdd_Click(object sender, EventArgs e)
		{
			string[] lines = tUrl.Lines;
			for (int i = 0; i < lines.Length; i++)
			{
				string url = lines[i];
				if (!string.IsNullOrEmpty(url))
				{
                    controller.AddAnime(url);
				}
			}
            tUrl.Clear();
		}

		

		private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
            SaveAnime();
            foreach(TabPage tabPage in tabSite.TabPages)
            {
                var listBox = tabPage.Controls[0] as ListBox;
                while(listBox.FindString("*") > -1)
                {
                    int index = listBox.FindString("*");
                    ReplaceAnime(listBox, listBox.Items[index] as Model);
                }
            }
		}

		private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
		{
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.dat|*.dat|*.al|*.al";
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
                            ReplaceAnime(listBox, anime);
                            notifyAnime.ShowBalloonTip(5000, "Новая серия", anime.Name[0], ToolTipIcon.Info);
                            timerCheckVideo.Enabled = true;
                        }
                    }
                }
            }catch
            {

            }
        }

        private void сохранитькакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.dat|*.dat|*.al|*.al";
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
