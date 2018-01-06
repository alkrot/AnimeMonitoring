using System.ComponentModel;
using System.Windows.Forms;

namespace AnimeMonitoring
{
    partial class FormMain
    {
        private IContainer components = null;

        private SplitContainer splitContainer1;

        private SplitContainer splitContainer2;

        private TextBox tUrl;

        private Button btnAdd;

        private SplitContainer splitContainer3;

        private TabControl tabSite;

        private TabPage tabAniplay;

        private ListBox lAniplay;

        private TabPage tabAnime365;

        private ListBox lAnime365;

        private TabPage tabSR;

        private ListBox lSovetRomantic;

        private SplitContainer splitContainer4;

        private PictureBox pPoster;

        private RichTextBox rDescription;

        private MenuStrip menuStrip1;

        private ToolStripMenuItem файлToolStripMenuItem;

        private ToolStripMenuItem открытьToolStripMenuItem;

        private ToolStripSeparator toolStripSeparator;

        private ToolStripMenuItem сохранитьToolStripMenuItem;

        private ToolStripMenuItem сохранитькакToolStripMenuItem;

        private ToolStripSeparator toolStripSeparator1;

        private ToolStripMenuItem выходToolStripMenuItem;

        private ToolStripMenuItem сервисToolStripMenuItem;

        private ToolStripMenuItem настройкиToolStripMenuItem;

        private ToolStripMenuItem справкаToolStripMenuItem;

        private ToolStripMenuItem содержаниеToolStripMenuItem;

        private ToolStripSeparator toolStripSeparator5;

        private ToolStripMenuItem опрограммеToolStripMenuItem;

        private Timer timerCheckVideo;

        private StatusStrip statusStrip1;

        private ToolStripStatusLabel tStatusLabel;

        private LinkLabel linkAnimeUrl;

        private Label labelUrlAnime;

        private TabPage tabRutracker;

        private ListBox lRutracker;

        private TabPage tabWOA;

        private ListBox lWOA;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tUrl = new System.Windows.Forms.TextBox();
            this.labelUrlAnime = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tabSite = new System.Windows.Forms.TabControl();
            this.tabAniplay = new System.Windows.Forms.TabPage();
            this.lAniplay = new System.Windows.Forms.ListBox();
            this.tabAnime365 = new System.Windows.Forms.TabPage();
            this.lAnime365 = new System.Windows.Forms.ListBox();
            this.tabSR = new System.Windows.Forms.TabPage();
            this.lSovetRomantic = new System.Windows.Forms.ListBox();
            this.tabRutracker = new System.Windows.Forms.TabPage();
            this.lRutracker = new System.Windows.Forms.ListBox();
            this.tabWOA = new System.Windows.Forms.TabPage();
            this.lWOA = new System.Windows.Forms.ListBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.pPoster = new System.Windows.Forms.PictureBox();
            this.linkAnimeUrl = new System.Windows.Forms.LinkLabel();
            this.rDescription = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитькакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отметитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.какУвиденоеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выбранноеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.активномСпискеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.содержаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.опрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerCheckVideo = new System.Windows.Forms.Timer(this.components);
            this.notifyAnime = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabSite.SuspendLayout();
            this.tabAniplay.SuspendLayout();
            this.tabAnime365.SuspendLayout();
            this.tabSR.SuspendLayout();
            this.tabRutracker.SuspendLayout();
            this.tabWOA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pPoster)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.splitContainer1.Size = new System.Drawing.Size(647, 461);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(5, 5);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tUrl);
            this.splitContainer2.Panel1.Controls.Add(this.labelUrlAnime);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnAdd);
            this.splitContainer2.Size = new System.Drawing.Size(15, 451);
            this.splitContainer2.SplitterDistance = 419;
            this.splitContainer2.TabIndex = 0;
            // 
            // tUrl
            // 
            this.tUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tUrl.Enabled = false;
            this.tUrl.Location = new System.Drawing.Point(0, 37);
            this.tUrl.Multiline = true;
            this.tUrl.Name = "tUrl";
            this.tUrl.Size = new System.Drawing.Size(15, 382);
            this.tUrl.TabIndex = 1;
            this.tUrl.TextChanged += new System.EventHandler(this.tUrl_TextChanged);
            // 
            // labelUrlAnime
            // 
            this.labelUrlAnime.BackColor = System.Drawing.Color.WhiteSmoke;
            this.labelUrlAnime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelUrlAnime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelUrlAnime.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelUrlAnime.Location = new System.Drawing.Point(0, 0);
            this.labelUrlAnime.Name = "labelUrlAnime";
            this.labelUrlAnime.Size = new System.Drawing.Size(15, 37);
            this.labelUrlAnime.TabIndex = 1;
            this.labelUrlAnime.Text = "Ссылки на аниме";
            this.labelUrlAnime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelUrlAnime.Click += new System.EventHandler(this.label1_Click);
            this.labelUrlAnime.MouseEnter += new System.EventHandler(this.labelUrlAnime_MouseEnter);
            this.labelUrlAnime.MouseLeave += new System.EventHandler(this.labelUrlAnime_MouseLeave);
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(0, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(15, 27);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(5, 434);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(613, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip";
            // 
            // tStatusLabel
            // 
            this.tStatusLabel.Name = "tStatusLabel";
            this.tStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(5, 5);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tabSite);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(613, 451);
            this.splitContainer3.SplitterDistance = 212;
            this.splitContainer3.TabIndex = 0;
            // 
            // tabSite
            // 
            this.tabSite.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabSite.Controls.Add(this.tabAniplay);
            this.tabSite.Controls.Add(this.tabAnime365);
            this.tabSite.Controls.Add(this.tabSR);
            this.tabSite.Controls.Add(this.tabRutracker);
            this.tabSite.Controls.Add(this.tabWOA);
            this.tabSite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSite.Location = new System.Drawing.Point(0, 0);
            this.tabSite.Multiline = true;
            this.tabSite.Name = "tabSite";
            this.tabSite.SelectedIndex = 0;
            this.tabSite.Size = new System.Drawing.Size(212, 451);
            this.tabSite.TabIndex = 0;
            // 
            // tabAniplay
            // 
            this.tabAniplay.Controls.Add(this.lAniplay);
            this.tabAniplay.Location = new System.Drawing.Point(4, 73);
            this.tabAniplay.Name = "tabAniplay";
            this.tabAniplay.Padding = new System.Windows.Forms.Padding(3);
            this.tabAniplay.Size = new System.Drawing.Size(204, 374);
            this.tabAniplay.TabIndex = 0;
            this.tabAniplay.Text = "Aniplay";
            this.tabAniplay.UseVisualStyleBackColor = true;
            // 
            // lAniplay
            // 
            this.lAniplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lAniplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lAniplay.FormattingEnabled = true;
            this.lAniplay.Location = new System.Drawing.Point(3, 3);
            this.lAniplay.Name = "lAniplay";
            this.lAniplay.Size = new System.Drawing.Size(198, 368);
            this.lAniplay.TabIndex = 0;
            this.lAniplay.SelectedIndexChanged += new System.EventHandler(this.ShowInfo);
            this.lAniplay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DelAnime);
            // 
            // tabAnime365
            // 
            this.tabAnime365.Controls.Add(this.lAnime365);
            this.tabAnime365.Location = new System.Drawing.Point(4, 73);
            this.tabAnime365.Name = "tabAnime365";
            this.tabAnime365.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnime365.Size = new System.Drawing.Size(204, 374);
            this.tabAnime365.TabIndex = 1;
            this.tabAnime365.Text = "Anime365";
            this.tabAnime365.UseVisualStyleBackColor = true;
            // 
            // lAnime365
            // 
            this.lAnime365.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lAnime365.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lAnime365.FormattingEnabled = true;
            this.lAnime365.Location = new System.Drawing.Point(3, 3);
            this.lAnime365.Name = "lAnime365";
            this.lAnime365.Size = new System.Drawing.Size(198, 368);
            this.lAnime365.TabIndex = 0;
            this.lAnime365.SelectedIndexChanged += new System.EventHandler(this.ShowInfo);
            this.lAnime365.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DelAnime);
            // 
            // tabSR
            // 
            this.tabSR.Controls.Add(this.lSovetRomantic);
            this.tabSR.Location = new System.Drawing.Point(4, 73);
            this.tabSR.Name = "tabSR";
            this.tabSR.Size = new System.Drawing.Size(204, 374);
            this.tabSR.TabIndex = 2;
            this.tabSR.Text = "SovetRomantic";
            this.tabSR.UseVisualStyleBackColor = true;
            // 
            // lSovetRomantic
            // 
            this.lSovetRomantic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lSovetRomantic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lSovetRomantic.FormattingEnabled = true;
            this.lSovetRomantic.Location = new System.Drawing.Point(0, 0);
            this.lSovetRomantic.Name = "lSovetRomantic";
            this.lSovetRomantic.Size = new System.Drawing.Size(204, 374);
            this.lSovetRomantic.TabIndex = 0;
            this.lSovetRomantic.SelectedIndexChanged += new System.EventHandler(this.ShowInfo);
            this.lSovetRomantic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DelAnime);
            // 
            // tabRutracker
            // 
            this.tabRutracker.Controls.Add(this.lRutracker);
            this.tabRutracker.Location = new System.Drawing.Point(4, 73);
            this.tabRutracker.Name = "tabRutracker";
            this.tabRutracker.Padding = new System.Windows.Forms.Padding(3);
            this.tabRutracker.Size = new System.Drawing.Size(204, 374);
            this.tabRutracker.TabIndex = 3;
            this.tabRutracker.Text = "RutrackerAnime";
            this.tabRutracker.UseVisualStyleBackColor = true;
            // 
            // lRutracker
            // 
            this.lRutracker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lRutracker.FormattingEnabled = true;
            this.lRutracker.Location = new System.Drawing.Point(3, 3);
            this.lRutracker.Name = "lRutracker";
            this.lRutracker.Size = new System.Drawing.Size(198, 368);
            this.lRutracker.TabIndex = 0;
            this.lRutracker.SelectedIndexChanged += new System.EventHandler(this.ShowInfo);
            this.lRutracker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DelAnime);
            // 
            // tabWOA
            // 
            this.tabWOA.Controls.Add(this.lWOA);
            this.tabWOA.Location = new System.Drawing.Point(4, 73);
            this.tabWOA.Name = "tabWOA";
            this.tabWOA.Padding = new System.Windows.Forms.Padding(3);
            this.tabWOA.Size = new System.Drawing.Size(204, 374);
            this.tabWOA.TabIndex = 4;
            this.tabWOA.Text = "WOA";
            this.tabWOA.UseVisualStyleBackColor = true;
            // 
            // lWOA
            // 
            this.lWOA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lWOA.FormattingEnabled = true;
            this.lWOA.Location = new System.Drawing.Point(3, 3);
            this.lWOA.Name = "lWOA";
            this.lWOA.Size = new System.Drawing.Size(198, 368);
            this.lWOA.TabIndex = 0;
            this.lWOA.SelectedIndexChanged += new System.EventHandler(this.ShowInfo);
            this.lWOA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DelAnime);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.pPoster);
            this.splitContainer4.Panel1.Controls.Add(this.linkAnimeUrl);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.rDescription);
            this.splitContainer4.Size = new System.Drawing.Size(397, 451);
            this.splitContainer4.SplitterDistance = 256;
            this.splitContainer4.TabIndex = 0;
            // 
            // pPoster
            // 
            this.pPoster.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pPoster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pPoster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPoster.Location = new System.Drawing.Point(0, 26);
            this.pPoster.Name = "pPoster";
            this.pPoster.Size = new System.Drawing.Size(397, 230);
            this.pPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pPoster.TabIndex = 0;
            this.pPoster.TabStop = false;
            // 
            // linkAnimeUrl
            // 
            this.linkAnimeUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkAnimeUrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkAnimeUrl.Location = new System.Drawing.Point(0, 0);
            this.linkAnimeUrl.Name = "linkAnimeUrl";
            this.linkAnimeUrl.Size = new System.Drawing.Size(397, 26);
            this.linkAnimeUrl.TabIndex = 1;
            this.linkAnimeUrl.TabStop = true;
            this.linkAnimeUrl.Text = "Url";
            this.linkAnimeUrl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkAnimeUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAnimeUrl_LinkClicked);
            // 
            // rDescription
            // 
            this.rDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rDescription.Location = new System.Drawing.Point(0, 0);
            this.rDescription.Name = "rDescription";
            this.rDescription.ReadOnly = true;
            this.rDescription.Size = new System.Drawing.Size(397, 191);
            this.rDescription.TabIndex = 0;
            this.rDescription.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.сервисToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(647, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.toolStripSeparator,
            this.сохранитьToolStripMenuItem,
            this.сохранитькакToolStripMenuItem,
            this.toolStripSeparator1,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "&Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.открытьToolStripMenuItem.Text = "&Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(150, 6);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.сохранитьToolStripMenuItem.Text = "&Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитькакToolStripMenuItem
            // 
            this.сохранитькакToolStripMenuItem.Name = "сохранитькакToolStripMenuItem";
            this.сохранитькакToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.сохранитькакToolStripMenuItem.Text = "Сохранить &как";
            this.сохранитькакToolStripMenuItem.Click += new System.EventHandler(this.сохранитькакToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.выходToolStripMenuItem.Text = "Вы&ход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // сервисToolStripMenuItem
            // 
            this.сервисToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem,
            this.отметитьToolStripMenuItem});
            this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
            this.сервисToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.сервисToolStripMenuItem.Text = "&Сервис";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.настройкиToolStripMenuItem.Text = "&Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // отметитьToolStripMenuItem
            // 
            this.отметитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.какУвиденоеToolStripMenuItem});
            this.отметитьToolStripMenuItem.Name = "отметитьToolStripMenuItem";
            this.отметитьToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.отметитьToolStripMenuItem.Text = "Отметить";
            // 
            // какУвиденоеToolStripMenuItem
            // 
            this.какУвиденоеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выбранноеToolStripMenuItem,
            this.активномСпискеToolStripMenuItem,
            this.всеToolStripMenuItem});
            this.какУвиденоеToolStripMenuItem.Name = "какУвиденоеToolStripMenuItem";
            this.какУвиденоеToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.какУвиденоеToolStripMenuItem.Text = "Как увиденое";
            // 
            // выбранноеToolStripMenuItem
            // 
            this.выбранноеToolStripMenuItem.Name = "выбранноеToolStripMenuItem";
            this.выбранноеToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.выбранноеToolStripMenuItem.Text = "Выбранное";
            this.выбранноеToolStripMenuItem.Click += new System.EventHandler(this.выбранноеToolStripMenuItem_Click);
            // 
            // активномСпискеToolStripMenuItem
            // 
            this.активномСпискеToolStripMenuItem.Name = "активномСпискеToolStripMenuItem";
            this.активномСпискеToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.активномСпискеToolStripMenuItem.Text = "Активном списке";
            this.активномСпискеToolStripMenuItem.Click += new System.EventHandler(this.активномСпискеToolStripMenuItem_Click);
            // 
            // всеToolStripMenuItem
            // 
            this.всеToolStripMenuItem.Name = "всеToolStripMenuItem";
            this.всеToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.всеToolStripMenuItem.Text = "Все";
            this.всеToolStripMenuItem.Click += new System.EventHandler(this.всеToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.содержаниеToolStripMenuItem,
            this.toolStripSeparator5,
            this.опрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Спра&вка";
            // 
            // содержаниеToolStripMenuItem
            // 
            this.содержаниеToolStripMenuItem.Name = "содержаниеToolStripMenuItem";
            this.содержаниеToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.содержаниеToolStripMenuItem.Text = "&Содержание";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(155, 6);
            // 
            // опрограммеToolStripMenuItem
            // 
            this.опрограммеToolStripMenuItem.Name = "опрограммеToolStripMenuItem";
            this.опрограммеToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.опрограммеToolStripMenuItem.Text = "&О программе...";
            // 
            // timerCheckVideo
            // 
            this.timerCheckVideo.Enabled = true;
            this.timerCheckVideo.Interval = 5000;
            this.timerCheckVideo.Tick += new System.EventHandler(this.timerCheckVideo_Tick);
            // 
            // notifyAnime
            // 
            this.notifyAnime.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyAnime.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyAnime.Icon")));
            this.notifyAnime.Visible = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(647, 485);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "АнимеМониторинг";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tabSite.ResumeLayout(false);
            this.tabAniplay.ResumeLayout(false);
            this.tabAnime365.ResumeLayout(false);
            this.tabSR.ResumeLayout(false);
            this.tabRutracker.ResumeLayout(false);
            this.tabWOA.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pPoster)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected override void Dispose(bool disposing)
        {
            bool flag = disposing && this.components != null;
            if (flag)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private NotifyIcon notifyAnime;
        private ToolStripMenuItem отметитьToolStripMenuItem;
        private ToolStripMenuItem какУвиденоеToolStripMenuItem;
        private ToolStripMenuItem выбранноеToolStripMenuItem;
        private ToolStripMenuItem активномСпискеToolStripMenuItem;
        private ToolStripMenuItem всеToolStripMenuItem;
    }
}
