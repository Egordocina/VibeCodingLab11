using System.Drawing;
using Model;
using System.Linq;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace View
{
    /// <summary>
    /// Часть формы SearchForm.
    /// </summary>
    partial class SearchForm
    {
        /// <summary>
        /// Контейнер компонентов.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Лейбл для поля Имя.
        /// </summary>
        private System.Windows.Forms.Label nameLabel;

        /// <summary>
        /// Текстовое поле для Имени.
        /// </summary>
        private System.Windows.Forms.TextBox nameTextBox;

        /// <summary>
        /// Лейбл для поля Фамилия.
        /// </summary>
        private System.Windows.Forms.Label lastNameLabel;

        /// <summary>
        /// Текстовое поле для Фамилии.
        /// </summary>
        private System.Windows.Forms.TextBox lastNameTextBox;

        /// <summary>
        /// Лейбл для поля Разряд.
        /// </summary>
        private System.Windows.Forms.Label positionLabel;

        /// <summary>
        /// Текстовое поле для Страны.
        /// </summary>
        private System.Windows.Forms.TextBox positionTextBox;

        /// <summary>
        /// Лейбл для поля Страна.
        /// </summary>
        private System.Windows.Forms.Label countryLabel;

        /// <summary>
        /// Текстовое поле для Страны.
        /// </summary>
        private System.Windows.Forms.TextBox countryTextBox;

        /// <summary>
        /// Кнопка Найти.
        /// </summary>
        private System.Windows.Forms.Button findButton;

        /// <summary>
        /// Кнопка Сброс.
        /// </summary>
        private System.Windows.Forms.Button resetButton;

        /// <summary>
        /// Кнопка Отмена.
        /// </summary>
        private System.Windows.Forms.Button cancelButton;

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
            nameLabel = new Label();
            nameTextBox = new TextBox();
            lastNameLabel = new Label();
            lastNameTextBox = new TextBox();
            positionLabel = new Label();
            positionTextBox = new TextBox();
            countryLabel = new Label();
            countryTextBox = new TextBox();
            findButton = new Button();
            resetButton = new Button();
            cancelButton = new Button();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.BackColor = Color.Transparent;
            nameLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            nameLabel.ForeColor = Color.FromArgb(255, 255, 255);
            nameLabel.Location = new Point(92, 14);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(42, 20);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Имя:";
            // 
            // nameTextBox
            // 
            nameTextBox.BackColor = Color.FromArgb(45, 45, 45);
            nameTextBox.BorderStyle = BorderStyle.FixedSingle;
            nameTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            nameTextBox.ForeColor = Color.FromArgb(255, 255, 255);
            nameTextBox.Location = new Point(140, 12);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(260, 27);
            nameTextBox.TabIndex = 1;
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.BackColor = Color.Transparent;
            lastNameLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            lastNameLabel.ForeColor = Color.FromArgb(255, 255, 255);
            lastNameLabel.Location = new Point(58, 50);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(76, 20);
            lastNameLabel.TabIndex = 2;
            lastNameLabel.Text = "Фамилия:";
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.BackColor = Color.FromArgb(45, 45, 45);
            lastNameTextBox.BorderStyle = BorderStyle.FixedSingle;
            lastNameTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            lastNameTextBox.ForeColor = Color.FromArgb(255, 255, 255);
            lastNameTextBox.Location = new Point(140, 48);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(260, 27);
            lastNameTextBox.TabIndex = 3;
            // 
            // positionLabel
            // 
            positionLabel.AutoSize = true;
            positionLabel.BackColor = Color.Transparent;
            positionLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            positionLabel.ForeColor = Color.FromArgb(255, 255, 255);
            positionLabel.Location = new Point(74, 86);
            positionLabel.Name = "positionLabel";
            positionLabel.Size = new Size(60, 20);
            positionLabel.TabIndex = 4;
            positionLabel.Text = "Разряд:";
            // 
            // positionTextBox
            // 
            positionTextBox.BackColor = Color.FromArgb(45, 45, 45);
            positionTextBox.BorderStyle = BorderStyle.FixedSingle;
            positionTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            positionTextBox.ForeColor = Color.FromArgb(255, 255, 255);
            positionTextBox.Location = new Point(140, 84);
            positionTextBox.Name = "positionTextBox";
            positionTextBox.Size = new Size(260, 27);
            positionTextBox.TabIndex = 5;
            // 
            // countryLabel
            // 
            countryLabel.AutoSize = true;
            countryLabel.BackColor = Color.Transparent;
            countryLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            countryLabel.ForeColor = Color.FromArgb(255, 255, 255);
            countryLabel.Location = new Point(73, 122);
            countryLabel.Name = "countryLabel";
            countryLabel.Size = new Size(61, 20);
            countryLabel.TabIndex = 6;
            countryLabel.Text = "Страна:";
            // 
            // countryTextBox
            // 
            countryTextBox.BackColor = Color.FromArgb(45, 45, 45);
            countryTextBox.BorderStyle = BorderStyle.FixedSingle;
            countryTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            countryTextBox.ForeColor = Color.FromArgb(255, 255, 255);
            countryTextBox.Location = new Point(140, 120);
            countryTextBox.Name = "countryTextBox";
            countryTextBox.Size = new Size(260, 27);
            countryTextBox.TabIndex = 7;
            // 
            // findButton
            //
            findButton.BackColor = Color.FromArgb(103, 58, 183);
            findButton.FlatAppearance.BorderSize = 0;
            findButton.FlatAppearance.MouseDownBackColor = 
                Color.FromArgb(77, 43, 137);
            findButton.FlatAppearance.MouseOverBackColor = 
                Color.FromArgb(129, 83, 207);
            findButton.FlatStyle = FlatStyle.Flat;
            findButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            findButton.ForeColor = Color.FromArgb(255, 255, 255);
            findButton.Location = new Point(12, 160);
            findButton.Name = "findButton";
            findButton.Size = new Size(100, 36);
            findButton.TabIndex = 0;
            findButton.Text = "Найти";
            findButton.UseVisualStyleBackColor = false;
            findButton.Click += findButton_Click;
            // 
            // resetButton
            //
            resetButton.BackColor = Color.FromArgb(103, 58, 183);
            resetButton.FlatAppearance.BorderSize = 0;
            resetButton.FlatAppearance.MouseDownBackColor = 
                Color.FromArgb(77, 43, 137);
            resetButton.FlatAppearance.MouseOverBackColor = 
                Color.FromArgb(129, 83, 207);
            resetButton.FlatStyle = FlatStyle.Flat;
            resetButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            resetButton.ForeColor = Color.FromArgb(255, 255, 255);
            resetButton.Location = new Point(118, 160);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(100, 36);
            resetButton.TabIndex = 1;
            resetButton.Text = "Сброс";
            resetButton.UseVisualStyleBackColor = false;
            resetButton.Click += resetButton_Click;
            // 
            // cancelButton
            //
            cancelButton.BackColor = Color.FromArgb(103, 58, 183);
            cancelButton.FlatAppearance.BorderSize = 0;
            cancelButton.FlatAppearance.MouseDownBackColor = 
                Color.FromArgb(77, 43, 137);
            cancelButton.FlatAppearance.MouseOverBackColor = 
                Color.FromArgb(129, 83, 207);
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            cancelButton.ForeColor = Color.FromArgb(255, 255, 255);
            cancelButton.Location = new Point(224, 160);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 36);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.globe;
            pictureBox4.Location = new Point(12, 120);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(31, 28);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 20;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.star;
            pictureBox3.Location = new Point(12, 84);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(31, 28);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 19;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.id_card;
            pictureBox2.Location = new Point(12, 48);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(31, 27);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 18;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.ski;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(31, 27);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // SearchForm
            // 
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(420, 220);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(nameLabel);
            Controls.Add(nameTextBox);
            Controls.Add(lastNameLabel);
            Controls.Add(lastNameTextBox);
            Controls.Add(positionLabel);
            Controls.Add(positionTextBox);
            Controls.Add(countryLabel);
            Controls.Add(countryTextBox);
            Controls.Add(findButton);
            Controls.Add(resetButton);
            Controls.Add(cancelButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "SearchForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Поиск гонщиков";
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
    }
}
