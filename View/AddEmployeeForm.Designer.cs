using System.Drawing;

namespace View
{
    /// <summary>
    /// Часть формы AddEmployeeForm.
    /// </summary>
    partial class AddEmployeeForm
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
        /// Комбо-бокс для Разряд.
        /// </summary>
        private System.Windows.Forms.ComboBox positionComboBox;

        /// <summary>
        /// Лейбл для поля Страна.
        /// </summary>
        private System.Windows.Forms.Label countryLabel;

        /// <summary>
        /// Комбо-бокс для Страна.
        /// </summary>
        private System.Windows.Forms.ComboBox countryComboBox;

        /// <summary>
        /// Группа для выбора типа оплаты.
        /// </summary>
        private System.Windows.Forms.GroupBox typeGroupBox;

        /// <summary>
        /// Радио-кнопка для почасовой оплаты.
        /// </summary>
        private System.Windows.Forms.RadioButton hourlyRadioButton;

        /// <summary>
        /// Радио-кнопка для оплаты по окладу.
        /// </summary>
        private System.Windows.Forms.RadioButton salariedRadioButton;

        /// <summary>
        /// Радио-кнопка для оплаты с комиссией.
        /// </summary>
        private System.Windows.Forms.RadioButton commissionRadioButton;

        /// <summary>
        /// Группа для параметров.
        /// </summary>
        private System.Windows.Forms.GroupBox parametersGroupBox;

        /// <summary>
        /// Лейбл для первого параметра.
        /// </summary>
        private System.Windows.Forms.Label parameter1Label;

        /// <summary>
        /// Текстовое поле для первого параметра.
        /// </summary>
        private System.Windows.Forms.TextBox parameter1TextBox;

        /// <summary>
        /// Лейбл для второго параметра.
        /// </summary>
        private System.Windows.Forms.Label parameter2Label;

        /// <summary>
        /// Текстовое поле для второго параметра.
        /// </summary>
        private System.Windows.Forms.TextBox parameter2TextBox;

        /// <summary>
        /// Лейбл для третьего параметра.
        /// </summary>
        private System.Windows.Forms.Label parameter3Label;

        /// <summary>
        /// Текстовое поле для третьего параметра.
        /// </summary>
        private System.Windows.Forms.TextBox parameter3TextBox;

        /// <summary>
        /// Кнопка ОК.
        /// </summary>
        private System.Windows.Forms.Button okButton;

        /// <summary>
        /// Кнопка Отмена.
        /// </summary>
        private System.Windows.Forms.Button cancelButton;

        /// <summary>
        /// Кнопка создания случайного гонщика.
        /// </summary>
        private System.Windows.Forms.Button randomButton;

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
		/// Требуемый метод для поддержки конструктора — не изменяйте
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			nameLabel = new Label();
			nameTextBox = new TextBox();
			lastNameLabel = new Label();
			lastNameTextBox = new TextBox();
			positionLabel = new Label();
			positionComboBox = new ComboBox();
			countryLabel = new Label();
			countryComboBox = new ComboBox();
			typeGroupBox = new GroupBox();
			commissionRadioButton = new RadioButton();
			hourlyRadioButton = new RadioButton();
			salariedRadioButton = new RadioButton();
			parametersGroupBox = new GroupBox();
			parameter1Label = new Label();
			parameter1TextBox = new TextBox();
			parameter2Label = new Label();
			parameter2TextBox = new TextBox();
			parameter3Label = new Label();
			parameter3TextBox = new TextBox();
			okButton = new Button();
			cancelButton = new Button();
			randomButton = new Button();
			pictureBox1 = new PictureBox();
			pictureBox2 = new PictureBox();
			pictureBox3 = new PictureBox();
			pictureBox4 = new PictureBox();
			typeGroupBox.SuspendLayout();
			parametersGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
			SuspendLayout();
			// 
			// nameLabel
			// 
			nameLabel.AutoSize = true;
			nameLabel.BackColor = Color.Transparent;
			nameLabel.Font = new Font("Segoe UI", 9F);
			nameLabel.ForeColor = Color.FromArgb(255, 255, 255);
			nameLabel.Location = new Point(81, 10);
			nameLabel.Name = "nameLabel";
			nameLabel.Size = new Size(34, 15);
			nameLabel.TabIndex = 0;
			nameLabel.Text = "Имя:";
			// 
			// nameTextBox
			// 
			nameTextBox.BackColor = Color.FromArgb(45, 45, 45);
			nameTextBox.BorderStyle = BorderStyle.FixedSingle;
			nameTextBox.Font = new Font("Segoe UI", 9F);
			nameTextBox.ForeColor = Color.FromArgb(255, 255, 255);
			nameTextBox.Location = new Point(122, 9);
			nameTextBox.Margin = new Padding(3, 2, 3, 2);
			nameTextBox.Name = "nameTextBox";
			nameTextBox.Size = new Size(263, 23);
			nameTextBox.TabIndex = 1;
			// 
			// lastNameLabel
			// 
			lastNameLabel.AutoSize = true;
			lastNameLabel.BackColor = Color.Transparent;
			lastNameLabel.Font = new Font("Segoe UI", 9F);
			lastNameLabel.ForeColor = Color.FromArgb(255, 255, 255);
			lastNameLabel.Location = new Point(52, 38);
			lastNameLabel.Name = "lastNameLabel";
			lastNameLabel.Size = new Size(61, 15);
			lastNameLabel.TabIndex = 2;
			lastNameLabel.Text = "Фамилия:";
			// 
			// lastNameTextBox
			// 
			lastNameTextBox.BackColor = Color.FromArgb(45, 45, 45);
			lastNameTextBox.BorderStyle = BorderStyle.FixedSingle;
			lastNameTextBox.Font = new Font("Segoe UI", 9F);
			lastNameTextBox.ForeColor = Color.FromArgb(255, 255, 255);
			lastNameTextBox.Location = new Point(122, 36);
			lastNameTextBox.Margin = new Padding(3, 2, 3, 2);
			lastNameTextBox.Name = "lastNameTextBox";
			lastNameTextBox.Size = new Size(263, 23);
			lastNameTextBox.TabIndex = 3;
			// 
			// positionLabel
			// 
			positionLabel.AutoSize = true;
			positionLabel.BackColor = Color.Transparent;
			positionLabel.Font = new Font("Segoe UI", 9F);
			positionLabel.ForeColor = Color.FromArgb(255, 255, 255);
			positionLabel.Location = new Point(65, 65);
			positionLabel.Name = "positionLabel";
			positionLabel.Size = new Size(47, 15);
			positionLabel.TabIndex = 4;
			positionLabel.Text = "Разряд:";
			// 
			// positionComboBox
			// 
			positionComboBox.BackColor = Color.FromArgb(45, 45, 45);
			positionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			positionComboBox.FlatStyle = FlatStyle.Flat;
			positionComboBox.Font = new Font("Segoe UI", 9F);
			positionComboBox.ForeColor = Color.FromArgb(255, 255, 255);
			positionComboBox.Location = new Point(122, 63);
			positionComboBox.Margin = new Padding(3, 2, 3, 2);
			positionComboBox.Name = "positionComboBox";
			positionComboBox.Size = new Size(263, 23);
			positionComboBox.TabIndex = 5;
			// 
			// countryLabel
			// 
			countryLabel.AutoSize = true;
			countryLabel.BackColor = Color.Transparent;
			countryLabel.Font = new Font("Segoe UI", 9F);
			countryLabel.ForeColor = Color.FromArgb(255, 255, 255);
			countryLabel.Location = new Point(64, 92);
			countryLabel.Name = "countryLabel";
			countryLabel.Size = new Size(49, 15);
			countryLabel.TabIndex = 6;
			countryLabel.Text = "Страна:";
			// 
			// countryComboBox
			// 
			countryComboBox.BackColor = Color.FromArgb(45, 45, 45);
			countryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			countryComboBox.FlatStyle = FlatStyle.Flat;
			countryComboBox.Font = new Font("Segoe UI", 9F);
			countryComboBox.ForeColor = Color.FromArgb(255, 255, 255);
			countryComboBox.Location = new Point(122, 90);
			countryComboBox.Margin = new Padding(3, 2, 3, 2);
			countryComboBox.Name = "countryComboBox";
			countryComboBox.Size = new Size(263, 23);
			countryComboBox.TabIndex = 7;
			// 
			// typeGroupBox
			// 
			typeGroupBox.Controls.Add(commissionRadioButton);
			typeGroupBox.Controls.Add(hourlyRadioButton);
			typeGroupBox.Controls.Add(salariedRadioButton);
			typeGroupBox.Font = new Font("Segoe UI", 9F);
			typeGroupBox.ForeColor = Color.FromArgb(255, 255, 255);
			typeGroupBox.Location = new Point(10, 117);
			typeGroupBox.Margin = new Padding(3, 2, 3, 2);
			typeGroupBox.Name = "typeGroupBox";
			typeGroupBox.Padding = new Padding(3, 2, 3, 2);
			typeGroupBox.Size = new Size(374, 42);
			typeGroupBox.TabIndex = 8;
			typeGroupBox.TabStop = false;
			typeGroupBox.Text = "Тип оплаты";
			// 
			// commissionRadioButton
			// 
			commissionRadioButton.AutoSize = true;
			commissionRadioButton.BackColor = Color.Transparent;
			commissionRadioButton.Font = new Font("Segoe UI", 9F);
			commissionRadioButton.ForeColor = Color.FromArgb(255, 255, 255);
			commissionRadioButton.Location = new Point(256, 16);
			commissionRadioButton.Margin = new Padding(3, 2, 3, 2);
			commissionRadioButton.Name = "commissionRadioButton";
			commissionRadioButton.Size = new Size(97, 19);
			commissionRadioButton.TabIndex = 2;
			commissionRadioButton.Text = "С комиссией";
			commissionRadioButton.UseVisualStyleBackColor = false;
			// 
			// hourlyRadioButton
			// 
			hourlyRadioButton.AutoSize = true;
			hourlyRadioButton.BackColor = Color.Transparent;
			hourlyRadioButton.Font = new Font("Segoe UI", 9F);
			hourlyRadioButton.ForeColor = Color.FromArgb(255, 255, 255);
			hourlyRadioButton.Location = new Point(10, 16);
			hourlyRadioButton.Margin = new Padding(3, 2, 3, 2);
			hourlyRadioButton.Name = "hourlyRadioButton";
			hourlyRadioButton.Size = new Size(85, 19);
			hourlyRadioButton.TabIndex = 0;
			hourlyRadioButton.Text = "Почасовая";
			hourlyRadioButton.UseVisualStyleBackColor = false;
			// 
			// salariedRadioButton
			// 
			salariedRadioButton.AutoSize = true;
			salariedRadioButton.BackColor = Color.Transparent;
			salariedRadioButton.Checked = true;
			salariedRadioButton.Font = new Font("Segoe UI", 9F);
			salariedRadioButton.ForeColor = Color.FromArgb(255, 255, 255);
			salariedRadioButton.Location = new Point(133, 16);
			salariedRadioButton.Margin = new Padding(3, 2, 3, 2);
			salariedRadioButton.Name = "salariedRadioButton";
			salariedRadioButton.Size = new Size(82, 19);
			salariedRadioButton.TabIndex = 1;
			salariedRadioButton.TabStop = true;
			salariedRadioButton.Text = "По окладу";
			salariedRadioButton.UseVisualStyleBackColor = false;
			// 
			// parametersGroupBox
			// 
			parametersGroupBox.Controls.Add(parameter1Label);
			parametersGroupBox.Controls.Add(parameter1TextBox);
			parametersGroupBox.Controls.Add(parameter2Label);
			parametersGroupBox.Controls.Add(parameter2TextBox);
			parametersGroupBox.Controls.Add(parameter3Label);
			parametersGroupBox.Controls.Add(parameter3TextBox);
			parametersGroupBox.Font = new Font("Segoe UI", 9F);
			parametersGroupBox.ForeColor = Color.FromArgb(255, 255, 255);
			parametersGroupBox.Location = new Point(10, 165);
			parametersGroupBox.Margin = new Padding(3, 2, 3, 2);
			parametersGroupBox.Name = "parametersGroupBox";
			parametersGroupBox.Padding = new Padding(3, 2, 3, 2);
			parametersGroupBox.Size = new Size(374, 105);
			parametersGroupBox.TabIndex = 9;
			parametersGroupBox.TabStop = false;
			parametersGroupBox.Text = "Параметры";
			// 
			// parameter1Label
			// 
			parameter1Label.AutoSize = true;
			parameter1Label.BackColor = Color.Transparent;
			parameter1Label.Font = new Font("Segoe UI", 9F);
			parameter1Label.ForeColor = Color.FromArgb(255, 255, 255);
			parameter1Label.Location = new Point(10, 22);
			parameter1Label.Name = "parameter1Label";
			parameter1Label.Size = new Size(74, 15);
			parameter1Label.TabIndex = 0;
			parameter1Label.Text = "Параметр 1:";
			// 
			// parameter1TextBox
			// 
			parameter1TextBox.BackColor = Color.FromArgb(45, 45, 45);
			parameter1TextBox.BorderStyle = BorderStyle.FixedSingle;
			parameter1TextBox.Font = new Font("Segoe UI", 9F);
			parameter1TextBox.ForeColor = Color.FromArgb(255, 255, 255);
			parameter1TextBox.Location = new Point(196, 20);
			parameter1TextBox.Margin = new Padding(3, 2, 3, 2);
			parameter1TextBox.Name = "parameter1TextBox";
			parameter1TextBox.Size = new Size(154, 23);
			parameter1TextBox.TabIndex = 1;
			// 
			// parameter2Label
			// 
			parameter2Label.AutoSize = true;
			parameter2Label.BackColor = Color.Transparent;
			parameter2Label.Font = new Font("Segoe UI", 9F);
			parameter2Label.ForeColor = Color.FromArgb(255, 255, 255);
			parameter2Label.Location = new Point(10, 46);
			parameter2Label.Name = "parameter2Label";
			parameter2Label.Size = new Size(74, 15);
			parameter2Label.TabIndex = 2;
			parameter2Label.Text = "Параметр 2:";
			// 
			// parameter2TextBox
			// 
			parameter2TextBox.BackColor = Color.FromArgb(45, 45, 45);
			parameter2TextBox.BorderStyle = BorderStyle.FixedSingle;
			parameter2TextBox.Font = new Font("Segoe UI", 9F);
			parameter2TextBox.ForeColor = Color.FromArgb(255, 255, 255);
			parameter2TextBox.Location = new Point(196, 44);
			parameter2TextBox.Margin = new Padding(3, 2, 3, 2);
			parameter2TextBox.Name = "parameter2TextBox";
			parameter2TextBox.Size = new Size(154, 23);
			parameter2TextBox.TabIndex = 3;
			// 
			// parameter3Label
			// 
			parameter3Label.AutoSize = true;
			parameter3Label.BackColor = Color.Transparent;
			parameter3Label.Font = new Font("Segoe UI", 9F);
			parameter3Label.ForeColor = Color.FromArgb(255, 255, 255);
			parameter3Label.Location = new Point(10, 71);
			parameter3Label.Name = "parameter3Label";
			parameter3Label.Size = new Size(74, 15);
			parameter3Label.TabIndex = 4;
			parameter3Label.Text = "Параметр 3:";
			// 
			// parameter3TextBox
			// 
			parameter3TextBox.BackColor = Color.FromArgb(45, 45, 45);
			parameter3TextBox.BorderStyle = BorderStyle.FixedSingle;
			parameter3TextBox.Font = new Font("Segoe UI", 9F);
			parameter3TextBox.ForeColor = Color.FromArgb(255, 255, 255);
			parameter3TextBox.Location = new Point(196, 69);
			parameter3TextBox.Margin = new Padding(3, 2, 3, 2);
			parameter3TextBox.Name = "parameter3TextBox";
			parameter3TextBox.Size = new Size(154, 23);
			parameter3TextBox.TabIndex = 5;
			// 
			// okButton
			//
			okButton.BackColor = Color.FromArgb(103, 58, 183);
			okButton.FlatAppearance.BorderSize = 0;
			okButton.FlatAppearance.MouseDownBackColor = 
				Color.FromArgb(77, 43, 137);
			okButton.FlatAppearance.MouseOverBackColor = 
				Color.FromArgb(129, 83, 207);
			okButton.FlatStyle = FlatStyle.Flat;
			okButton.Font = new Font("Segoe UI", 9F);
			okButton.ForeColor = Color.FromArgb(255, 255, 255);
			okButton.Location = new Point(11, 274);
			okButton.Margin = new Padding(3, 2, 3, 2);
			okButton.Name = "okButton";
			okButton.Size = new Size(65, 28);
			okButton.TabIndex = 10;
			okButton.Text = "ОК";
			okButton.UseVisualStyleBackColor = false;
			okButton.Click += OkButton_Click;
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
			cancelButton.Font = new Font("Segoe UI", 9F);
			cancelButton.ForeColor = Color.FromArgb(255, 255, 255);
			cancelButton.Location = new Point(81, 274);
			cancelButton.Margin = new Padding(3, 2, 3, 2);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(79, 28);
			cancelButton.TabIndex = 11;
			cancelButton.Text = "Отмена";
			cancelButton.UseVisualStyleBackColor = false;
			cancelButton.Click += CancelButton_Click;
			// 
			// randomButton
			//
			randomButton.BackColor = Color.FromArgb(103, 58, 183);
			randomButton.FlatAppearance.BorderSize = 0;
			randomButton.FlatAppearance.MouseDownBackColor = 
				Color.FromArgb(77, 43, 137);
			randomButton.FlatAppearance.MouseOverBackColor = 
				Color.FromArgb(129, 83, 207);
			randomButton.FlatStyle = FlatStyle.Flat;
			randomButton.Font = new Font("Segoe UI", 9F);
			randomButton.ForeColor = Color.FromArgb(255, 255, 255);
			randomButton.Location = new Point(165, 274);
			randomButton.Margin = new Padding(3, 2, 3, 2);
			randomButton.Name = "randomButton";
			randomButton.Size = new Size(220, 28);
			randomButton.TabIndex = 12;
			randomButton.Text = "Создать случайного гонщика";
			randomButton.UseVisualStyleBackColor = false;
			randomButton.Click += RandomButton_Click;
			// 
			// pictureBox1
			// 
			pictureBox1.Image = Properties.Resources.ski;
			pictureBox1.Location = new Point(10, 9);
			pictureBox1.Margin = new Padding(3, 2, 3, 2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(27, 20);
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 13;
			pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			pictureBox2.Image = Properties.Resources.id_card;
			pictureBox2.Location = new Point(10, 36);
			pictureBox2.Margin = new Padding(3, 2, 3, 2);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(27, 20);
			pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 14;
			pictureBox2.TabStop = false;
			pictureBox2.Click += PictureBox2_Click;
			// 
			// pictureBox3
			// 
			pictureBox3.Image = Properties.Resources.star;
			pictureBox3.Location = new Point(10, 63);
			pictureBox3.Margin = new Padding(3, 2, 3, 2);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new Size(27, 21);
			pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox3.TabIndex = 15;
			pictureBox3.TabStop = false;
			// 
			// pictureBox4
			// 
			pictureBox4.Image = Properties.Resources.globe;
			pictureBox4.Location = new Point(10, 90);
			pictureBox4.Margin = new Padding(3, 2, 3, 2);
			pictureBox4.Name = "pictureBox4";
			pictureBox4.Size = new Size(27, 21);
			pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox4.TabIndex = 16;
			pictureBox4.TabStop = false;
			// 
			// AddEmployeeForm
			//
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(32, 32, 32);
			ClientSize = new Size(396, 307);
			Controls.Add(pictureBox4);
			Controls.Add(pictureBox3);
			Controls.Add(pictureBox2);
			Controls.Add(pictureBox1);
			Controls.Add(nameLabel);
			Controls.Add(nameTextBox);
			Controls.Add(lastNameLabel);
			Controls.Add(lastNameTextBox);
			Controls.Add(positionLabel);
			Controls.Add(positionComboBox);
			Controls.Add(countryLabel);
			Controls.Add(countryComboBox);
			Controls.Add(typeGroupBox);
			Controls.Add(parametersGroupBox);
			Controls.Add(okButton);
			Controls.Add(cancelButton);
			Controls.Add(randomButton);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			Margin = new Padding(3, 2, 3, 2);
			MaximizeBox = false;
			Name = "AddEmployeeForm";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Добавить гонщика";
			typeGroupBox.ResumeLayout(false);
			typeGroupBox.PerformLayout();
			parametersGroupBox.ResumeLayout(false);
			parametersGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
    }
}
