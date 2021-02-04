namespace Lawyer_calendar
{
	partial class FormManagement
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.buttonChooseFolder = new System.Windows.Forms.Button();
			this.comboBoxCaseStatus = new System.Windows.Forms.ComboBox();
			this.dateTimePickerExpirationDate = new System.Windows.Forms.DateTimePicker();
			this.textBoxWorkerName = new System.Windows.Forms.TextBox();
			this.buttonSaveChanges = new System.Windows.Forms.Button();
			this.buttonCloseManager = new System.Windows.Forms.Button();
			this.textBoxCommentary = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.linkLabelOpenFolder = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(42, 87);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(146, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Имя ответственного:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(42, 127);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(219, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Дата рассмотрения дела в суде:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(42, 229);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(155, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Ссылка на папку дела:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(42, 173);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(92, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Статус дела:";
			// 
			// buttonChooseFolder
			// 
			this.buttonChooseFolder.Location = new System.Drawing.Point(293, 226);
			this.buttonChooseFolder.Name = "buttonChooseFolder";
			this.buttonChooseFolder.Size = new System.Drawing.Size(253, 23);
			this.buttonChooseFolder.TabIndex = 4;
			this.buttonChooseFolder.Text = "Выбрать папку";
			this.buttonChooseFolder.UseVisualStyleBackColor = true;
			this.buttonChooseFolder.Click += new System.EventHandler(this.buttonChooseFolder_Click);
			// 
			// comboBoxCaseStatus
			// 
			this.comboBoxCaseStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxCaseStatus.FormattingEnabled = true;
			this.comboBoxCaseStatus.Items.AddRange(new object[] {
            "В работе",
            "Готов к показу",
            "В архиве"});
			this.comboBoxCaseStatus.Location = new System.Drawing.Point(293, 173);
			this.comboBoxCaseStatus.Name = "comboBoxCaseStatus";
			this.comboBoxCaseStatus.Size = new System.Drawing.Size(253, 21);
			this.comboBoxCaseStatus.TabIndex = 5;
			// 
			// dateTimePickerExpirationDate
			// 
			this.dateTimePickerExpirationDate.Location = new System.Drawing.Point(293, 131);
			this.dateTimePickerExpirationDate.Name = "dateTimePickerExpirationDate";
			this.dateTimePickerExpirationDate.Size = new System.Drawing.Size(253, 20);
			this.dateTimePickerExpirationDate.TabIndex = 6;
			this.dateTimePickerExpirationDate.Value = new System.DateTime(2021, 2, 3, 12, 20, 39, 0);
			// 
			// textBoxWorkerName
			// 
			this.textBoxWorkerName.Location = new System.Drawing.Point(293, 87);
			this.textBoxWorkerName.Name = "textBoxWorkerName";
			this.textBoxWorkerName.Size = new System.Drawing.Size(253, 20);
			this.textBoxWorkerName.TabIndex = 7;
			// 
			// buttonSaveChanges
			// 
			this.buttonSaveChanges.Location = new System.Drawing.Point(120, 404);
			this.buttonSaveChanges.Name = "buttonSaveChanges";
			this.buttonSaveChanges.Size = new System.Drawing.Size(125, 23);
			this.buttonSaveChanges.TabIndex = 8;
			this.buttonSaveChanges.Text = "Сохранить";
			this.buttonSaveChanges.UseVisualStyleBackColor = true;
			this.buttonSaveChanges.Click += new System.EventHandler(this.buttonSaveChanges_Click);
			// 
			// buttonCloseManager
			// 
			this.buttonCloseManager.Location = new System.Drawing.Point(361, 404);
			this.buttonCloseManager.Name = "buttonCloseManager";
			this.buttonCloseManager.Size = new System.Drawing.Size(125, 23);
			this.buttonCloseManager.TabIndex = 9;
			this.buttonCloseManager.Text = "Закрыть";
			this.buttonCloseManager.UseVisualStyleBackColor = true;
			// 
			// textBoxCommentary
			// 
			this.textBoxCommentary.Location = new System.Drawing.Point(293, 307);
			this.textBoxCommentary.Multiline = true;
			this.textBoxCommentary.Name = "textBoxCommentary";
			this.textBoxCommentary.Size = new System.Drawing.Size(253, 68);
			this.textBoxCommentary.TabIndex = 11;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.Location = new System.Drawing.Point(42, 307);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 16);
			this.label5.TabIndex = 10;
			this.label5.Text = "Комментарий:";
			// 
			// linkLabelOpenFolder
			// 
			this.linkLabelOpenFolder.AutoSize = true;
			this.linkLabelOpenFolder.Location = new System.Drawing.Point(374, 252);
			this.linkLabelOpenFolder.Name = "linkLabelOpenFolder";
			this.linkLabelOpenFolder.Size = new System.Drawing.Size(92, 13);
			this.linkLabelOpenFolder.TabIndex = 12;
			this.linkLabelOpenFolder.TabStop = true;
			this.linkLabelOpenFolder.Text = "Перейти к папке";
			this.linkLabelOpenFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelOpenFolder_LinkClicked);
			// 
			// FormManagement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(603, 474);
			this.Controls.Add(this.linkLabelOpenFolder);
			this.Controls.Add(this.textBoxCommentary);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.buttonCloseManager);
			this.Controls.Add(this.buttonSaveChanges);
			this.Controls.Add(this.textBoxWorkerName);
			this.Controls.Add(this.dateTimePickerExpirationDate);
			this.Controls.Add(this.comboBoxCaseStatus);
			this.Controls.Add(this.buttonChooseFolder);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "FormManagement";
			this.Text = "Управление записями";
			this.Load += new System.EventHandler(this.FormManagement_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button buttonChooseFolder;
		private System.Windows.Forms.ComboBox comboBoxCaseStatus;
		private System.Windows.Forms.DateTimePicker dateTimePickerExpirationDate;
		private System.Windows.Forms.TextBox textBoxWorkerName;
		private System.Windows.Forms.Button buttonSaveChanges;
		private System.Windows.Forms.Button buttonCloseManager;
		private System.Windows.Forms.TextBox textBoxCommentary;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.LinkLabel linkLabelOpenFolder;
	}
}

