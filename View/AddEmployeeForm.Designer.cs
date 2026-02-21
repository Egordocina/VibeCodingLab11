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

			typeGroupBox.SuspendLayout();
			parametersGroupBox.SuspendLayout();
			SuspendLayout();

			//
			// nameLabel
			//
			nameLabel.Location = new Point(12, 12);
			nameLabel.Name = "nameLabel";
			nameLabel.Size = new Size(100, 23);
			nameLabel.TabIndex = 0;
			nameLabel.Text = "Имя:";

			//
			// nameTextBox
			//
			nameTextBox.Location = new Point(140, 12);
			nameTextBox.Name = "nameTextBox";
			nameTextBox.Size = new Size(300, 27);
			nameTextBox.TabIndex = 1;

			//
			// lastNameLabel
			//
			lastNameLabel.Location = new Point(12, 48);
			lastNameLabel.Name = "lastNameLabel";
			lastNameLabel.Size = new Size(100, 23);
			lastNameLabel.TabIndex = 2;
			lastNameLabel.Text = "Фамилия:";

			//
			// lastNameTextBox
			//
			lastNameTextBox.Location = new Point(140, 48);
			lastNameTextBox.Name = "lastNameTextBox";
			lastNameTextBox.Size = new Size(300, 27);
			lastNameTextBox.TabIndex = 3;

			//
			// positionLabel
			//
			positionLabel.Location = new Point(12, 84);
			positionLabel.Name = "positionLabel";
			positionLabel.Size = new Size(100, 23);
			positionLabel.TabIndex = 4;
			positionLabel.Text = "Разряд:";

			//
			// positionComboBox
			//
			positionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			positionComboBox.Location = new Point(140, 84);
			positionComboBox.Name = "positionComboBox";
			positionComboBox.Size = new Size(300, 28);
			positionComboBox.TabIndex = 5;

			//
			// countryLabel
			//
			countryLabel.Location = new Point(12, 120);
			countryLabel.Name = "countryLabel";
			countryLabel.Size = new Size(100, 23);
			countryLabel.TabIndex = 6;
			countryLabel.Text = "Страна:";

			//
			// countryComboBox
			//
			countryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			countryComboBox.Location = new Point(140, 120);
			countryComboBox.Name = "countryComboBox";
			countryComboBox.Size = new Size(300, 28);
			countryComboBox.TabIndex = 7;

			//
			// typeGroupBox
			//
			typeGroupBox.Controls.Add(commissionRadioButton);
			typeGroupBox.Controls.Add(hourlyRadioButton);
			typeGroupBox.Controls.Add(salariedRadioButton);
			typeGroupBox.Location = new Point(12, 156);
			typeGroupBox.Name = "typeGroupBox";
			typeGroupBox.Size = new Size(428, 56);
			typeGroupBox.TabIndex = 8;
			typeGroupBox.TabStop = false;
			typeGroupBox.Text = "Тип оплаты";

			//
			// commissionRadioButton
			//
			commissionRadioButton.Location = new Point(292, 22);
			commissionRadioButton.Name = "commissionRadioButton";
			commissionRadioButton.Size = new Size(120, 24);
			commissionRadioButton.TabIndex = 2;
			commissionRadioButton.Text = "С комиссией";

			//
			// hourlyRadioButton
			//
			hourlyRadioButton.Location = new Point(12, 22);
			hourlyRadioButton.Name = "hourlyRadioButton";
			hourlyRadioButton.Size = new Size(120, 24);
			hourlyRadioButton.TabIndex = 0;
			hourlyRadioButton.Text = "Почасовая";

			//
			// salariedRadioButton
			//
			salariedRadioButton.Checked = true;
			salariedRadioButton.Location = new Point(152, 22);
			salariedRadioButton.Name = "salariedRadioButton";
			salariedRadioButton.Size = new Size(120, 24);
			salariedRadioButton.TabIndex = 1;
			salariedRadioButton.TabStop = true;
			salariedRadioButton.Text = "По окладу";

			//
			// parametersGroupBox
			//
			parametersGroupBox.Controls.Add(parameter1Label);
			parametersGroupBox.Controls.Add(parameter1TextBox);
			parametersGroupBox.Controls.Add(parameter2Label);
			parametersGroupBox.Controls.Add(parameter2TextBox);
			parametersGroupBox.Controls.Add(parameter3Label);
			parametersGroupBox.Controls.Add(parameter3TextBox);
			parametersGroupBox.Location = new Point(12, 220);
			parametersGroupBox.Name = "parametersGroupBox";
			parametersGroupBox.Size = new Size(428, 140);
			parametersGroupBox.TabIndex = 9;
			parametersGroupBox.TabStop = false;
			parametersGroupBox.Text = "Параметры";

			//
			// parameter1Label
			//
			parameter1Label.Location = new Point(14, 23);
			parameter1Label.Name = "parameter1Label";
			parameter1Label.Size = new Size(204, 30);
			parameter1Label.TabIndex = 0;
			parameter1Label.Text = "Параметр 1:";

			//
			// parameter1TextBox
			//
			parameter1TextBox.Location = new Point(224, 26);
			parameter1TextBox.Name = "parameter1TextBox";
			parameter1TextBox.Size = new Size(176, 27);
			parameter1TextBox.TabIndex = 1;

			//
			// parameter2Label
			//
			parameter2Label.Location = new Point(12, 58);
			parameter2Label.Name = "parameter2Label";
			parameter2Label.Size = new Size(206, 23);
			parameter2Label.TabIndex = 2;
			parameter2Label.Text = "Параметр 2:";

			//
			// parameter2TextBox
			//
			parameter2TextBox.Location = new Point(224, 58);
			parameter2TextBox.Name = "parameter2TextBox";
			parameter2TextBox.Size = new Size(176, 27);
			parameter2TextBox.TabIndex = 3;

			//
			// parameter3Label
			//
			parameter3Label.Location = new Point(12, 92);
			parameter3Label.Name = "parameter3Label";
			parameter3Label.Size = new Size(206, 23);
			parameter3Label.TabIndex = 4;
			parameter3Label.Text = "Параметр 3:";

			//
			// parameter3TextBox
			//
			parameter3TextBox.Location = new Point(224, 92);
			parameter3TextBox.Name = "parameter3TextBox";
			parameter3TextBox.Size = new Size(176, 27);
			parameter3TextBox.TabIndex = 5;

			//
			// okButton
			//
			okButton.Location = new Point(13, 366);
			okButton.Name = "okButton";
			okButton.Size = new Size(74, 37);
			okButton.TabIndex = 10;
			okButton.Text = "ОК";
			okButton.Click += okButton_Click;

			//
			// cancelButton
			//
			cancelButton.Location = new Point(93, 366);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(90, 37);
			cancelButton.TabIndex = 11;
			cancelButton.Text = "Отмена";
			cancelButton.Click += cancelButton_Click;

			//
			// randomButton
			//
			randomButton.Location = new Point(189, 366);
			randomButton.Name = "randomButton";
			randomButton.Size = new Size(251, 37);
			randomButton.TabIndex = 12;
			randomButton.Text = "Создать случайного гонщика";
			randomButton.Click += randomButton_Click;

			//
			// AddEmployeeForm
			//
			ClientSize = new Size(452, 409);
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
			MaximizeBox = false;
			Name = "AddEmployeeForm";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Добавить гонщика";

			typeGroupBox.ResumeLayout(false);
			parametersGroupBox.ResumeLayout(false);
			parametersGroupBox.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}