using System.Windows.Forms;

namespace View.Services
{
    /// <summary>
    /// Реализация сервиса управления выделением. 
    /// </summary>
    public class SelectionService<T> : ISelectionService<T>
    {
        /// <summary>
        /// Выделяет все строки в DataGridView.
        /// </summary>
        public void SelectAll(DataGridView grid)
        {
            grid.ClearSelection();
            foreach (DataGridViewRow row in grid.Rows)
            {
                //TODO: {}+
                if (!row.IsNewRow)
                {
				    row.Selected = true;
				}
            }
        }

        /// <summary>
        /// Снимает выделение со всех строк.
        /// </summary>
        public void DeselectAll(DataGridView grid)
            => grid.ClearSelection();

        /// <summary>
        /// Инвертирует выделение строк.
        /// </summary>
        public void InvertSelection(DataGridView grid)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                //TODO: {}+
                if (!row.IsNewRow)
                {
					row.Selected = !row.Selected;
				}
            }
        }

        /// <summary>
        /// Удаляет выбранные элементы из источника.
        /// </summary>
        public void DeleteSelected(List<T> source, DataGridView grid)
        {
            var indices = grid.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(r => r.Index)
                .OrderByDescending(i => i)
                .ToList();

            //TODO: {}+
            foreach (var index in indices)
            {
				source.RemoveAt(index);
			}
        }

        /// <summary>
        /// Возвращает количество выбранных строк.
        /// </summary>
        public int GetSelectedCount(DataGridView grid)
            => grid.SelectedRows.Count;
    }
}
