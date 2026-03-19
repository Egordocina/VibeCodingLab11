namespace View.страдания
{
	partial class HourlyEmployeeParameterPanel
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Лейбл для почасовой ставки.
		/// </summary>
		private Label hourlyRateLabel;

		/// <summary>
		/// Текстовое поле для почасовой ставки.
		/// </summary>
		private TextBox hourlyRateTextBox;

		/// <summary>
		/// Лейбл для отработанных часов.
		/// </summary>
		private Label hoursWorkedLabel;

		/// <summary>
		/// Текстовое поле для отработанных часов.
		/// </summary>
		private TextBox hoursWorkedTextBox;

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
			this.hourlyRateLabel = new Label();
			this.hourlyRateTextBox = new TextBox();
			this.hoursWorkedLabel = new Label();
			this.hoursWorkedTextBox = new TextBox();
			this.SuspendLayout();
			// 
			// hourlyRateLabel
			// 
			this.hourlyRateLabel.AutoSize = true;
			this.hourlyRateLabel.BackColor = Color.Transparent;
			this.hourlyRateLabel.Font = new Font("Segoe UI", 9F);
			this.hourlyRateLabel.ForeColor = Color.FromArgb(255, 255, 255);
			this.hourlyRateLabel.Location = new Point(10, 15);
			this.hourlyRateLabel.Name = "hourlyRateLabel";
			this.hourlyRateLabel.Size = new Size(100, 15);
			this.hourlyRateLabel.TabIndex = 0;
			this.hourlyRateLabel.Text = "Почасовая ставка:";
			// 
			// hourlyRateTextBox
			// 
			this.hourlyRateTextBox.BackColor = Color.FromArgb(45, 45, 45);
			this.hourlyRateTextBox.BorderStyle = BorderStyle.FixedSingle;
			this.hourlyRateTextBox.Font = new Font("Segoe UI", 9F);
			this.hourlyRateTextBox.ForeColor = Color.FromArgb(255, 255, 255);
			this.hourlyRateTextBox.Location = new Point(180, 12);
			this.hourlyRateTextBox.Name = "hourlyRateTextBox";
			this.hourlyRateTextBox.Size = new Size(180, 23);
			this.hourlyRateTextBox.TabIndex = 1;
			// 
			// hoursWorkedLabel
			// 
			this.hoursWorkedLabel.AutoSize = true;
			this.hoursWorkedLabel.BackColor = Color.Transparent;
			this.hoursWorkedLabel.Font = new Font("Segoe UI", 9F);
			this.hoursWorkedLabel.ForeColor = Color.FromArgb(255, 255, 255);
			this.hoursWorkedLabel.Location = new Point(10, 45);
			this.hoursWorkedLabel.Name = "hoursWorkedLabel";
			this.hoursWorkedLabel.Size = new Size(110, 15);
			this.hoursWorkedLabel.TabIndex = 2;
			this.hoursWorkedLabel.Text = "Отработанные часы:";
			// 
			// hoursWorkedTextBox
			// 
			this.hoursWorkedTextBox.BackColor = Color.FromArgb(45, 45, 45);
			this.hoursWorkedTextBox.BorderStyle = BorderStyle.FixedSingle;
			this.hoursWorkedTextBox.Font = new Font("Segoe UI", 9F);
			this.hoursWorkedTextBox.ForeColor = Color.FromArgb(255, 255, 255);
			this.hoursWorkedTextBox.Location = new Point(180, 42);
			this.hoursWorkedTextBox.Name = "hoursWorkedTextBox";
			this.hoursWorkedTextBox.Size = new Size(180, 23);
			this.hoursWorkedTextBox.TabIndex = 3;
			// 
			// HourlyEmployeeParameterPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = Color.FromArgb(32, 32, 32);
			this.Controls.Add(this.hoursWorkedTextBox);
			this.Controls.Add(this.hoursWorkedLabel);
			this.Controls.Add(this.hourlyRateTextBox);
			this.Controls.Add(this.hourlyRateLabel);
			this.Name = "HourlyEmployeeParameterPanel";
			this.Size = new System.Drawing.Size(370, 80);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
	}
}
