using Model;
using System;
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
		private System.Windows.Forms.Label departmentLabel;

		/// <summary>
		/// Текстовое поле для Страны.
		/// </summary>
		private System.Windows.Forms.TextBox departmentTextBox;

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
			components = new System.ComponentModel.Container();
			nameLabel = new System.Windows.Forms.Label();
			nameTextBox = new System.Windows.Forms.TextBox();
			lastNameLabel = new System.Windows.Forms.Label();
			lastNameTextBox = new System.Windows.Forms.TextBox();
			positionLabel = new System.Windows.Forms.Label();
			positionTextBox = new System.Windows.Forms.TextBox();
			departmentLabel = new System.Windows.Forms.Label();
			departmentTextBox = new System.Windows.Forms.TextBox();
			findButton = new System.Windows.Forms.Button();
			resetButton = new System.Windows.Forms.Button();
			cancelButton = new System.Windows.Forms.Button();
			SuspendLayout();

			ClientSize = new Size(420, 220);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			StartPosition = FormStartPosition.CenterParent;
			Text = "Поиск гонщиков";

			//
			// nameLabel
			//
			nameLabel.Text = "Имя:";
			nameLabel.Location = new Point(12, 12);
			nameLabel.Size = new Size(100, 23);

			//
			// nameTextBox
			//
			nameTextBox.Location = new Point(140, 12);
			nameTextBox.Size = new Size(260, 23);

			//
			// lastNameLabel
			//
			lastNameLabel.Text = "Фамилия:";
			lastNameLabel.Location = new Point(12, 48);
			lastNameLabel.Size = new Size(100, 23);

			//
			// lastNameTextBox
			//
			lastNameTextBox.Location = new Point(140, 48);
			lastNameTextBox.Size = new Size(260, 23);

			//
			// positionLabel
			//
			positionLabel.Text = "Разряд:";
			positionLabel.Location = new Point(12, 84);
			positionLabel.Size = new Size(100, 23);

			//
			// positionTextBox
			//
			positionTextBox.Location = new Point(140, 84);
			positionTextBox.Size = new Size(260, 23);

			//
			// departmentLabel
			//
			departmentLabel.Text = "Страна:";
			departmentLabel.Location = new Point(12, 120);
			departmentLabel.Size = new Size(100, 23);

			//
			// departmentTextBox
			//
			departmentTextBox.Location = new Point(140, 120);
			departmentTextBox.Size = new Size(260, 23);

			//
			// findButton
			//
			findButton.Location = new Point(12, 160);
			findButton.Size = new Size(100, 36);
			findButton.Text = "Найти";
			findButton.Click += new EventHandler(findButton_Click);

			//
			// resetButton
			//
			resetButton.Location = new Point(118, 160);
			resetButton.Size = new Size(100, 36);
			resetButton.Text = "Сброс";
			resetButton.Click += new EventHandler(resetButton_Click);

			//
			// cancelButton
			//
			cancelButton.Location = new Point(224, 160);
			cancelButton.Size = new Size(100, 36);
			cancelButton.Text = "Отмена";
			cancelButton.Click += new EventHandler(cancelButton_Click);

			Controls.AddRange(new Control[] {
				nameLabel,
				nameTextBox,
				lastNameLabel,
				lastNameTextBox,
				positionLabel,
				positionTextBox,
				departmentLabel,
				departmentTextBox,
				findButton,
				resetButton,
				cancelButton
			});

			ResumeLayout(false);
			PerformLayout();
		}
	}
}