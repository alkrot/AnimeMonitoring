using AnimeMonitoring.Models;
using System.Linq;
using System.Windows.Forms;

namespace AnimeMonitoring
{
    public static class Extenshion
    {
        /// <summary>
        /// Вернуть индекс нужной модели в списке
        /// </summary>
        /// <param name="list">Список - контрол</param>
        /// <param name="anime">Модел</param>
        /// <returns>Индекс от 0, если не найден то -1</returns>
        public static int GetIndex(this ListBox list, Model anime)
        {
            return list.Items.IndexOf(anime);
        }

        public static bool AnimeHasList(this ListBox list, Model anime)
        {
            return list.Items.Contains(anime);
        }

        /// <summary>
        /// Отметить/снять что есть новая серия в данной вкладке
        /// </summary>
        /// <param name="list">Список - котнтрол</param>
        public static void SetMarkTab(this ListBox list)
        {
            var isNewSeries = list.Items.Cast<Model>().Any(a => a.NewSeries == true);

            if (isNewSeries && list.Parent.Text[0] != '*')
                list.Parent.Text = '*' + list.Parent.Text;
            else if (!isNewSeries && list.Parent.Text[0] == '*')
                list.Parent.Text = list.Parent.Text.Substring(1);
        }

        /// <summary>
        /// Обновление модели в списке
        /// </summary>
        /// <param name="list">Список - контрол</param>
        /// <param name="anime">Модел</param>
        public static void ReplaceAnime(this ListBox list, Model anime)
        {
            int index = list.GetIndex(anime);
            list.Items.RemoveAt(index);
            list.Items.Insert(index, anime);
            list.SetMarkTab();
        }
    }
}
