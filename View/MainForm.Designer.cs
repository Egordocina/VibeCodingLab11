using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace View
{
	/// <summary>
	/// Часть формы MainForm.
	/// </summary>
	partial class MainForm
	{
		/// <summary>
		/// Контейнер компонентов.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Таблица для отображения гонщиков.
		/// </summary>
		private System.Windows.Forms.DataGridView employeesDataGridView;

		/// <summary>
		/// Кнопка добавления гонщика.
		/// </summary>
		private System.Windows.Forms.Button addButton;

		/// <summary>
		/// Кнопка удаления гонщика.
		/// </summary>
		private System.Windows.Forms.Button removeButton;

		/// <summary>
		/// Кнопка поиска гонщиков.
		/// </summary>
		private System.Windows.Forms.Button searchButton;

		/// <summary>
		/// Кнопка сохранения данных.
		/// </summary>
		private System.Windows.Forms.Button saveButton;

		/// <summary>
		/// Кнопка загрузки данных.
		/// </summary>
		private System.Windows.Forms.Button loadButton;

		/// <summary>
		/// Освобождает ресурсы, используемые формой.
		/// </summary>
		/// <param name="disposing">
		/// true, если вызван управляемый ресурс; иначе false.
		/// </param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}

			base.Dispose(disposing);
		}

        /// <summary>
        /// Требуемый метод для поддержки конструктора.
        /// </summary>
        private void InitializeComponent()
        {
            employeesDataGridView = new DataGridView();
            addButton = new Button();
            removeButton = new Button();
            searchButton = new Button();
            saveButton = new Button();
            loadButton = new Button();
            ((System.ComponentModel.ISupportInitialize)employeesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // employeesDataGridView
            // 
            employeesDataGridView.AccessibleRole = AccessibleRole.IpAddress;
            employeesDataGridView.AllowUserToDeleteRows = false;
            employeesDataGridView.AllowUserToResizeRows = false;
            employeesDataGridView.Anchor = AnchorStyles.Top;
            employeesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            employeesDataGridView.BackgroundColor = Color.DarkSlateBlue;
            employeesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            employeesDataGridView.Location = new Point(14, 16);
            employeesDataGridView.Margin = new Padding(3, 4, 3, 4);
            employeesDataGridView.MultiSelect = false;
            employeesDataGridView.Name = "employeesDataGridView";
            employeesDataGridView.ReadOnly = true;
            employeesDataGridView.RowHeadersWidth = 51;
            employeesDataGridView.RowTemplate.Height = 25;
            employeesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            employeesDataGridView.Size = new Size(983, 533);
            employeesDataGridView.TabIndex = 0;
            employeesDataGridView.CellContentClick += employeesDataGridView_CellContentClick;
            // 
            // addButton
            // 
            addButton.BackColor = Color.DarkMagenta;
            addButton.ForeColor = SystemColors.ButtonHighlight;
            addButton.Location = new Point(14, 573);
            addButton.Margin = new Padding(3, 4, 3, 4);
            addButton.Name = "addButton";
            addButton.Size = new Size(184, 48);
            addButton.TabIndex = 1;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += addButton_Click;
            // 
            // removeButton
            // 
            removeButton.BackColor = Color.DarkMagenta;
            removeButton.ForeColor = SystemColors.ControlLightLight;
            removeButton.Location = new Point(213, 573);
            removeButton.Margin = new Padding(3, 4, 3, 4);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(184, 48);
            removeButton.TabIndex = 2;
            removeButton.Text = "Удалить";
            removeButton.UseVisualStyleBackColor = false;
            removeButton.Click += removeButton_Click;
            // 
            // searchButton
            // 
            searchButton.Anchor = AnchorStyles.None;
            searchButton.BackColor = Color.DarkMagenta;
            searchButton.ForeColor = SystemColors.ControlLightLight;
            searchButton.Location = new Point(412, 573);
            searchButton.Margin = new Padding(3, 4, 3, 4);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(184, 48);
            searchButton.TabIndex = 3;
            searchButton.Text = "Поиск";
            searchButton.UseVisualStyleBackColor = false;
            searchButton.Click += searchButton_Click;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.DarkMagenta;
            saveButton.ForeColor = SystemColors.ControlLightLight;
            saveButton.Location = new Point(611, 573);
            saveButton.Margin = new Padding(3, 4, 3, 4);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(184, 48);
            saveButton.TabIndex = 4;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // loadButton
            // 
            loadButton.BackColor = Color.DarkMagenta;
            loadButton.ForeColor = SystemColors.ControlLightLight;
            loadButton.Location = new Point(812, 573);
            loadButton.Margin = new Padding(3, 4, 3, 4);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(184, 48);
            loadButton.TabIndex = 5;
            loadButton.Text = "Загрузить";
            loadButton.UseVisualStyleBackColor = false;
            loadButton.Click += loadButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateBlue;
            ClientSize = new Size(1010, 641);
            Controls.Add(employeesDataGridView);
            Controls.Add(addButton);
            Controls.Add(removeButton);
            Controls.Add(searchButton);
            Controls.Add(saveButton);
            Controls.Add(loadButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Список гонщиков в лыжной команде \"Сутутлые псы\"";
            ((System.ComponentModel.ISupportInitialize)employeesDataGridView).EndInit();
            ResumeLayout(false);
        }
    }
}