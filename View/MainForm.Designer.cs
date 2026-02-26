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
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)
                employeesDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // employeesDataGridView
            //
            employeesDataGridView.AccessibleRole = AccessibleRole.IpAddress;
            employeesDataGridView.AllowUserToDeleteRows = false;
            employeesDataGridView.AllowUserToResizeRows = false;
            employeesDataGridView.Anchor = AnchorStyles.Top;
            employeesDataGridView.AutoSizeColumnsMode = 
                DataGridViewAutoSizeColumnsMode.Fill;
            employeesDataGridView.BackgroundColor = Color.FromArgb(40, 40, 45);
            employeesDataGridView.ColumnHeadersHeightSizeMode = 
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            employeesDataGridView.Location = new Point(14, 16);
            employeesDataGridView.Margin = new Padding(3, 4, 3, 4);
            employeesDataGridView.MultiSelect = false;
            employeesDataGridView.Name = "employeesDataGridView";
            employeesDataGridView.ReadOnly = true;
            employeesDataGridView.RowHeadersWidth = 51;
            employeesDataGridView.RowTemplate.Height = 25;
            employeesDataGridView.SelectionMode = 
                DataGridViewSelectionMode.FullRowSelect;
            employeesDataGridView.Size = new Size(983, 533);
            employeesDataGridView.TabIndex = 0;
            employeesDataGridView.CellContentClick += 
                employeesDataGridView_CellContentClick;
            // 
            // addButton
            //
            addButton.BackColor = Color.FromArgb(103, 58, 183);
            addButton.FlatAppearance.BorderSize = 0;
            addButton.FlatAppearance.MouseDownBackColor = 
                Color.FromArgb(77, 43, 137);
            addButton.FlatAppearance.MouseOverBackColor = 
                Color.FromArgb(129, 83, 207);
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            addButton.ForeColor = Color.FromArgb(255, 255, 255);
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
            removeButton.BackColor = Color.FromArgb(103, 58, 183);
            removeButton.FlatAppearance.BorderSize = 0;
            removeButton.FlatAppearance.MouseDownBackColor = 
                Color.FromArgb(77, 43, 137);
            removeButton.FlatAppearance.MouseOverBackColor = 
                Color.FromArgb(129, 83, 207);
            removeButton.FlatStyle = FlatStyle.Flat;
            removeButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            removeButton.ForeColor = Color.FromArgb(255, 255, 255);
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
            searchButton.BackColor = Color.FromArgb(103, 58, 183);
            searchButton.FlatAppearance.BorderSize = 0;
            searchButton.FlatAppearance.MouseDownBackColor = 
                Color.FromArgb(77, 43, 137);
            searchButton.FlatAppearance.MouseOverBackColor = 
                Color.FromArgb(129, 83, 207);
            searchButton.FlatStyle = FlatStyle.Flat;
            searchButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            searchButton.ForeColor = Color.FromArgb(255, 255, 255);
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
            saveButton.BackColor = Color.FromArgb(103, 58, 183);
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.FlatAppearance.MouseDownBackColor = 
                Color.FromArgb(77, 43, 137);
            saveButton.FlatAppearance.MouseOverBackColor = 
                Color.FromArgb(129, 83, 207);
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            saveButton.ForeColor = Color.FromArgb(255, 255, 255);
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
            loadButton.BackColor = Color.FromArgb(103, 58, 183);
            loadButton.FlatAppearance.BorderSize = 0;
            loadButton.FlatAppearance.MouseDownBackColor = 
                Color.FromArgb(77, 43, 137);
            loadButton.FlatAppearance.MouseOverBackColor = 
                Color.FromArgb(129, 83, 207);
            loadButton.FlatStyle = FlatStyle.Flat;
            loadButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            loadButton.ForeColor = Color.FromArgb(255, 255, 255);
            loadButton.Location = new Point(812, 573);
            loadButton.Margin = new Padding(3, 4, 3, 4);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(184, 48);
            loadButton.TabIndex = 5;
            loadButton.Text = "Загрузить";
            loadButton.UseVisualStyleBackColor = false;
            loadButton.Click += loadButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(103, 58, 183);
            pictureBox1.Image = Properties.Resources.add_button;
            pictureBox1.Location = new Point(20, 580);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 35);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(103, 58, 183);
            pictureBox2.Image = Properties.Resources.delete;
            pictureBox2.Location = new Point(223, 580);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(35, 35);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(103, 58, 183);
            pictureBox3.Image = Properties.Resources.website;
            pictureBox3.Location = new Point(422, 580);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(35, 35);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.FromArgb(103, 58, 183);
            pictureBox4.Image = Properties.Resources.save;
            pictureBox4.Location = new Point(620, 580);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(35, 35);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 9;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.FromArgb(103, 58, 183);
            pictureBox5.Image = Properties.Resources.refresh;
            pictureBox5.Location = new Point(822, 580);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(35, 35);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 10;
            pictureBox5.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(1010, 641);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
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
            Text = "Список гонщиков в лыжной команде " +
                   "\"Сутулые псы\"";
            ((System.ComponentModel.ISupportInitialize)
                employeesDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
        }

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
    }
}
