using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimeMonitoring
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void addAutoStart_Click(object sender, EventArgs e)
        {
            CreateShortCut(Application.ExecutablePath, Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf('\\')), Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\AnimeMonitoring.lnk");
        }

        /// <summary>
        /// Добавление в автозагрзу
        /// </summary>
        /// <param name="FilePath">Путь к запускаемому файлу</param>
        /// <param name="WorkDir">Рабочая директория</param>
        /// <param name="SaveTo">Куда сохранить ярлык</param>
        private void CreateShortCut(string FilePath, string WorkDir, string SaveTo)
        {
            var WshShell = new IWshShell_Class();
            IWshShortcut MyShortcut;
            MyShortcut = (IWshShortcut)WshShell.CreateShortcut(SaveTo);
            //путь к exe
            MyShortcut.TargetPath = FilePath;
            MyShortcut.Description = "Запуск";
            //рабочая диреткория
            MyShortcut.WorkingDirectory = WorkDir;
            MyShortcut.Save();
        }
    }
}
