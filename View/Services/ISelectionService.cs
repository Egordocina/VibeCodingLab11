using System.Windows.Forms;

namespace View.Services
{
    /// <summary>
    /// Сервис управления выделением элементов в DataGridView.
    /// </summary>
    public interface ISelectionService<T>
    {
        /// <summary>
        /// Выделяет все строки.
        /// </summary>
        void SelectAll(DataGridView grid);

        /// <summary>
        /// Снимает выделение со всех строк.
        /// </summary>
        void DeselectAll(DataGridView grid);

        /// <summary>
        /// Инвертирует выделение строк.
        /// </summary>
        void InvertSelection(DataGridView grid);

        /// <summary>
        /// Удаляет выбранные элементы из источника.
        /// </summary>
        void DeleteSelected(List<T> source, DataGridView grid);

        /// <summary>
        /// Возвращает количество выбранных строк.
        /// </summary>
        int GetSelectedCount(DataGridView grid);
    }
}
