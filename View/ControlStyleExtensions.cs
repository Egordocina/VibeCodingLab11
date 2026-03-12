using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Методы расширения для полиморфного применения стилей к элементам управления.
    /// </summary>
    public static class ControlStyleExtensions
    {
		private static readonly Dictionary<Type, Action<Control>> StyleActions =
			new Dictionary<Type, Action<Control>>
			{
				{ typeof(Button), 
					c => StyleHelper.ApplyButtonStyle((Button)c) },
	
				{ typeof(TextBox), 
			
					c => StyleHelper.ApplyTextBoxStyle((TextBox)c) },
			
				{ typeof(Label), 
			
					c => StyleHelper.ApplyLabelStyle((Label)c) },
			
				{ typeof(ComboBox), 
			
					c => StyleHelper.ApplyComboBoxStyle((ComboBox)c) },
			
				{ typeof(GroupBox), 
			
					c => StyleHelper.ApplyGroupBoxStyle((GroupBox)c) },
			
				{ typeof(RadioButton), 
			
					c => StyleHelper.ApplyRadioButtonStyle((RadioButton)c) },
			
				{ typeof(DataGridView), 
			
					c => StyleHelper.ApplyDataGridViewStyle((DataGridView)c) },
			
				{ typeof(ToolStrip), 
			
					c => StyleHelper.ApplyToolStripStyle((ToolStrip)c) },
			};
		/// <summary>
		/// Применяет стиль Windows 11 Dark к элементу управления и всем его дочерним элементам.
		/// </summary>
		/// <param name="control">Элемент управления для стилизации.</param>
		public static void ApplyStyle(this Control control)
        {
			// Применяем стиль по типу элемента
			//TODO: {}+ зарефакторил  со списком
			if (StyleActions.TryGetValue(control.GetType(), out var action))
			{
				action(control);
			}

			// Рекурсивно применяем ко всем дочерним элементам
			foreach (Control child in control.Controls)
            {
                child.ApplyStyle();
            }
        }
    }
}
