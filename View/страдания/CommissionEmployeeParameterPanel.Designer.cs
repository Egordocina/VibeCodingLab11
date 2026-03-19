namespace View.страдания
{
	partial class CommissionEmployeeParameterPanel
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Лейбл для базовой зарплаты.
		/// </summary>
		private Label baseSalaryLabel;

		/// <summary>
		/// Текстовое поле для базовой зарплаты.
		/// </summary>
		private TextBox baseSalaryTextBox;

		/// <summary>
		/// Лейбл для ставки премии.
		/// </summary>
		private Label commissionRateLabel;

		/// <summary>
		/// Текстовое поле для ставки премии.
		/// </summary>
		private TextBox commissionRateTextBox;

		/// <summary>
		/// Лейбл для суммы премии.
		/// </summary>
		private Label bonusAmountLabel;

		/// <summary>
		/// Текстовое поле для суммы премии.
		/// </summary>
		private TextBox bonusAmountTextBox;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
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
			baseSalaryLabel = new Label();
			baseSalaryTextBox = new TextBox();
			commissionRateLabel = new Label();
			commissionRateTextBox = new TextBox();
			bonusAmountLabel = new Label();
			bonusAmountTextBox = new TextBox();
			SuspendLayout();
			// 
			// baseSalaryLabel
			// 
			baseSalaryLabel.AutoSize = true;
			baseSalaryLabel.BackColor = Color.Transparent;
			baseSalaryLabel.Font = new Font("Segoe UI", 9F);
			baseSalaryLabel.ForeColor = Color.FromArgb(255, 255, 255);
			baseSalaryLabel.Location = new Point(10, 15);
			baseSalaryLabel.Name = "baseSalaryLabel";
			baseSalaryLabel.Size = new Size(105, 15);
			baseSalaryLabel.TabIndex = 0;
			baseSalaryLabel.Text = "Базовая зарплата:";
			// 
			// baseSalaryTextBox
			// 
			baseSalaryTextBox.BackColor = Color.FromArgb(45, 45, 45);
			baseSalaryTextBox.BorderStyle = BorderStyle.FixedSingle;
			baseSalaryTextBox.Font = new Font("Segoe UI", 9F);
			baseSalaryTextBox.ForeColor = Color.FromArgb(255, 255, 255);
			baseSalaryTextBox.Location = new Point(180, 12);
			baseSalaryTextBox.Name = "baseSalaryTextBox";
			baseSalaryTextBox.Size = new Size(180, 23);
			baseSalaryTextBox.TabIndex = 1;
			// 
			// commissionRateLabel
			// 
			commissionRateLabel.AutoSize = true;
			commissionRateLabel.BackColor = Color.Transparent;
			commissionRateLabel.Font = new Font("Segoe UI", 9F);
			commissionRateLabel.ForeColor = Color.FromArgb(255, 255, 255);
			commissionRateLabel.Location = new Point(10, 45);
			commissionRateLabel.Name = "commissionRateLabel";
			commissionRateLabel.Size = new Size(114, 15);
			commissionRateLabel.TabIndex = 2;
			commissionRateLabel.Text = "Ставка премии (%):";
			// 
			// commissionRateTextBox
			// 
			commissionRateTextBox.BackColor = Color.FromArgb(45, 45, 45);
			commissionRateTextBox.BorderStyle = BorderStyle.FixedSingle;
			commissionRateTextBox.Font = new Font("Segoe UI", 9F);
			commissionRateTextBox.ForeColor = Color.FromArgb(255, 255, 255);
			commissionRateTextBox.Location = new Point(180, 42);
			commissionRateTextBox.Name = "commissionRateTextBox";
			commissionRateTextBox.Size = new Size(180, 23);
			commissionRateTextBox.TabIndex = 3;
			// 
			// bonusAmountLabel
			// 
			bonusAmountLabel.AutoSize = true;
			bonusAmountLabel.BackColor = Color.Transparent;
			bonusAmountLabel.Font = new Font("Segoe UI", 9F);
			bonusAmountLabel.ForeColor = Color.FromArgb(255, 255, 255);
			bonusAmountLabel.Location = new Point(10, 75);
			bonusAmountLabel.Name = "bonusAmountLabel";
			bonusAmountLabel.Size = new Size(94, 15);
			bonusAmountLabel.TabIndex = 4;
			bonusAmountLabel.Text = "Сумма премии:";
			// 
			// bonusAmountTextBox
			// 
			bonusAmountTextBox.BackColor = Color.FromArgb(45, 45, 45);
			bonusAmountTextBox.BorderStyle = BorderStyle.FixedSingle;
			bonusAmountTextBox.Font = new Font("Segoe UI", 9F);
			bonusAmountTextBox.ForeColor = Color.FromArgb(255, 255, 255);
			bonusAmountTextBox.Location = new Point(180, 72);
			bonusAmountTextBox.Name = "bonusAmountTextBox";
			bonusAmountTextBox.Size = new Size(180, 23);
			bonusAmountTextBox.TabIndex = 5;
			// 
			// CommissionEmployeeParameterPanel
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(32, 32, 32);
			Controls.Add(bonusAmountTextBox);
			Controls.Add(bonusAmountLabel);
			Controls.Add(commissionRateTextBox);
			Controls.Add(commissionRateLabel);
			Controls.Add(baseSalaryTextBox);
			Controls.Add(baseSalaryLabel);
			Name = "CommissionEmployeeParameterPanel";
			Size = new Size(370, 104);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
