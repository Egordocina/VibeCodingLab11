using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Методы расширения для полиморфного применения стилей к элементам управления.
    /// </summary>
    public static class ControlStyleExtensions
    {
        /// <summary>
        /// Применяет стиль Windows 11 Dark к элементу управления и всем его дочерним элементам.
        /// </summary>
        /// <param name="control">Элемент управления для стилизации.</param>
        public static void ApplyStyle(this Control control)
        {
            // Применяем стиль по типу элемента
            switch (control)
            {
                case Button button:
                    StyleHelper.ApplyButtonStyle(button);
                    break;
                case TextBox textBox:
                    StyleHelper.ApplyTextBoxStyle(textBox);
                    break;
                case Label label:
                    StyleHelper.ApplyLabelStyle(label);
                    break;
                case ComboBox comboBox:
                    StyleHelper.ApplyComboBoxStyle(comboBox);
                    break;
                case GroupBox groupBox:
                    StyleHelper.ApplyGroupBoxStyle(groupBox);
                    break;
                case RadioButton radioButton:
                    StyleHelper.ApplyRadioButtonStyle(radioButton);
                    break;
                case DataGridView dataGridView:
                    StyleHelper.ApplyDataGridViewStyle(dataGridView);
                    break;
                case ToolStrip toolStrip:
                    StyleHelper.ApplyToolStripStyle(toolStrip);
                    break;
            }

            // Рекурсивно применяем ко всем дочерним элементам
            foreach (Control child in control.Controls)
            {
                child.ApplyStyle();
            }
        }
    }
}
