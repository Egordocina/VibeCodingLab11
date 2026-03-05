using System.Drawing;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Помощник для применения стиля Windows 11 Dark.
    /// </summary>
    public static class StyleHelper
    {
        // Цветовая палитра
        public static readonly Color BackgroundPrimary = 
            Color.FromArgb(32, 32, 32);
        public static readonly Color BackgroundSecondary = 
            Color.FromArgb(45, 45, 45);
        public static readonly Color BackgroundTertiary = 
            Color.FromArgb(52, 52, 52);
        public static readonly Color Surface = Color.FromArgb(38, 38, 38);
        public static readonly Color Accent = Color.FromArgb(103, 58, 183);
        public static readonly Color AccentLight = 
            Color.FromArgb(129, 83, 207);
        public static readonly Color AccentDark = 
            Color.FromArgb(77, 43, 137);
        public static readonly Color TextPrimary = 
            Color.FromArgb(255, 255, 255);
        public static readonly Color TextSecondary = 
            Color.FromArgb(200, 200, 200);
        public static readonly Color TextDisabled = 
            Color.FromArgb(150, 150, 150);
        public static readonly Color Border = Color.FromArgb(60, 60, 60);
        public static readonly Color GridBackground = 
            Color.FromArgb(40, 40, 45);
        public static readonly Color GridRowAlternate = 
            Color.FromArgb(50, 50, 58);
        public static readonly Color GridHeader = 
            Color.FromArgb(45, 45, 52);

        /// <summary>
        /// Применяет стиль Windows 11 Dark к форме.
        /// </summary>
        public static void ApplyFormStyle(Form form)
        {
            //TODO: duplication
            form.BackColor = BackgroundPrimary;
            form.ForeColor = TextPrimary;
            form.Font = new Font(
                "Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        }

        /// <summary>
        /// Применяет стиль Windows 11 Dark к кнопке.
        /// </summary>
        public static void ApplyButtonStyle(Button button)
        {
            button.BackColor = Accent;
            button.ForeColor = TextPrimary;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = AccentLight;
            button.FlatAppearance.MouseDownBackColor = AccentDark;
            button.Font = new Font(
                "Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Применяет стиль Windows 11 Dark к текстовому полю.
        /// </summary>
        public static void ApplyTextBoxStyle(TextBox textBox)
        {
            //TODO: duplication
            textBox.BackColor = BackgroundSecondary;
            textBox.ForeColor = TextPrimary;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Font = new Font(
                "Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        }

        /// <summary>
        /// Применяет стиль Windows 11 Dark к метке.
        /// </summary>
        public static void ApplyLabelStyle(Label label)
        {
            //TODO: duplication
            label.BackColor = Color.Transparent;
            label.ForeColor = TextPrimary;
            label.Font = new Font(
                "Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        }

        /// <summary>
        /// Применяет стиль Windows 11 Dark к ComboBox.
        /// </summary>
        public static void ApplyComboBoxStyle(ComboBox comboBox)
        {
            comboBox.BackColor = BackgroundSecondary;
            comboBox.ForeColor = TextPrimary;
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Font = new Font(
                "Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        }

        /// <summary>
        /// Применяет стиль Windows 11 Dark к GroupBox.
        /// </summary>
        public static void ApplyGroupBoxStyle(GroupBox groupBox)
        {
            //TODO: duplication
            groupBox.BackColor = Color.Transparent;
            groupBox.ForeColor = TextPrimary;
            groupBox.Font = new Font(
                "Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        }

        /// <summary>
        /// Применяет стиль Windows 11 Dark к RadioButton.
        /// </summary>
        public static void ApplyRadioButtonStyle(RadioButton radioButton)
        {
            //TODO: duplication
            radioButton.BackColor = Color.Transparent;
            radioButton.ForeColor = TextPrimary;
            radioButton.Font = new Font(
                "Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        }

        /// <summary>
        /// Применяет стиль Windows 11 Dark к DataGridView.
        /// </summary>
        public static void ApplyDataGridViewStyle(DataGridView dataGridView)
        {
            dataGridView.BackColor = GridBackground;
            dataGridView.ForeColor = TextPrimary;
            dataGridView.BackgroundColor = GridBackground;
            dataGridView.GridColor = Border;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.DefaultCellStyle.BackColor = GridBackground;
            dataGridView.DefaultCellStyle.ForeColor = TextPrimary;
            dataGridView.DefaultCellStyle.SelectionBackColor = Accent;
            dataGridView.DefaultCellStyle.SelectionForeColor = TextPrimary;
            dataGridView.DefaultCellStyle.Font = new Font(
                "Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = 
                GridRowAlternate;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = GridHeader;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = TextPrimary;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(
                "Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = 
                DataGridViewContentAlignment.MiddleLeft;
            dataGridView.ColumnHeadersHeight = 30;
            dataGridView.RowHeadersDefaultCellStyle.BackColor = GridHeader;
            dataGridView.RowHeadersDefaultCellStyle.ForeColor = TextPrimary;
            dataGridView.RowHeadersDefaultCellStyle.SelectionBackColor = Accent;
            dataGridView.RowHeadersDefaultCellStyle.SelectionForeColor = 
                TextPrimary;
            dataGridView.EnableHeadersVisualStyles = false;
        }
    }
}
