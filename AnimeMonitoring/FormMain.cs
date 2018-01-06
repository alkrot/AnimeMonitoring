using AngleSharp;
using AnimeMonitoring.Controllers;
using AnimeMonitoring.Models;
using System;
using System.Diagnostics;
using System.Drawing;
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
            foreach (TabPage tabPage in tabSite.TabPages)
            {
                var listBox = tabPage.Controls[0] as ListBox;
                while (listBox.FindString("*") > -1)
                {
                    int index = listBox.FindString("*");
                    listBox.ReplaceAnime(listBox.Items[index] as Model);
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
                try
                {
                    Clipboard.Clear();
                    Clipboard.SetText(((LinkLabel)sender).Text, TextDataFormat.Text);
                    ShowNotify("Ссылка скопирована");
                }
                catch (Exception er)
                {
                    ShowNotify(er.Message, er.Source, ToolTipIcon.Error);
                }
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
                            listBox.ReplaceAnime(anime);
                            ShowNotify(anime.Name[0], "Новая серия", timeout: 5000);
                            timerCheckVideo.Enabled = true;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void сохранитькакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.dat|*.dat|*.al|*.al";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
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

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveAnime();
        }

        private void выбранноеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var listBox = tabSite.SelectedTab.Controls[0] as ListBox;

            if (listBox.SelectedIndex >= 0 || listBox.SelectedItems.Count > 0)
            {
                var animeList = listBox.SelectedItems;
                CheckLookList(listBox, animeList);
            }
        }

        private void активномСпискеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var listBox = tabSite.SelectedTab.Controls[0] as ListBox;

            if (listBox.Items.Count > 0)
            {
                CheckLookList(listBox, listBox.Items);
            }
        }

        private void всеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TabPage tabPage in tabSite.TabPages)
            {
                var listBox = tabPage.Controls[0] as ListBox;
                CheckLookList(listBox, listBox.Items, false);
            }
            ShowNotify("Все было отмечено как увиденое");
        }

        private void tabChanged(object sender, EventArgs e)
        {
            var tabCtrl = (TabControl) sender;
            var tabPage = tabCtrl.SelectedTab;
            var list = tabPage.Controls[0] as ListBox;
            if(list.SelectedItem != null)
            {
                ShowAnimeDescription(list);
            }
        }
    }
}
