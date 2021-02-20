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
			this.buttonSaveChanges = new System.Windows.Forms.Button();
			this.buttonCloseManager = new System.Windows.Forms.Button();
			this.textBoxCommentary = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.linkLabelOpenFolder = new System.Windows.Forms.LinkLabel();
			this.buttonDeleteCase = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.labelLastModifyInfo = new System.Windows.Forms.Label();
			this.buttonShowChronology = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.comboBoxChooceWorker = new System.Windows.Forms.ComboBox();
			this.textBoxCaseTime = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(42, 54);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(146, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Имя ответственного:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(42, 109);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(219, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Дата рассмотрения дела в суде:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(42, 272);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(155, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Ссылка на папку дела:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(42, 191);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(92, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Статус дела:";
			// 
			// buttonChooseFolder
			// 
			this.buttonChooseFolder.Location = new System.Drawing.Point(293, 246);
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
            "Готово к показу",
            "В архиве",
            "Нет статуса"});
			this.comboBoxCaseStatus.Location = new System.Drawing.Point(293, 191);
			this.comboBoxCaseStatus.Name = "comboBoxCaseStatus";
			this.comboBoxCaseStatus.Size = new System.Drawing.Size(253, 21);
			this.comboBoxCaseStatus.TabIndex = 5;
			// 
			// dateTimePickerExpirationDate
			// 
			this.dateTimePickerExpirationDate.Location = new System.Drawing.Point(293, 109);
			this.dateTimePickerExpirationDate.Name = "dateTimePickerExpirationDate";
			this.dateTimePickerExpirationDate.Size = new System.Drawing.Size(253, 20);
			this.dateTimePickerExpirationDate.TabIndex = 6;
			this.dateTimePickerExpirationDate.Value = new System.DateTime(2021, 2, 3, 12, 20, 39, 0);
			// 
			// buttonSaveChanges
			// 
			this.buttonSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSaveChanges.Location = new System.Drawing.Point(240, 514);
			this.buttonSaveChanges.Name = "buttonSaveChanges";
			this.buttonSaveChanges.Size = new System.Drawing.Size(125, 23);
			this.buttonSaveChanges.TabIndex = 8;
			this.buttonSaveChanges.Text = "Сохранить";
			this.buttonSaveChanges.UseVisualStyleBackColor = true;
			this.buttonSaveChanges.Click += new System.EventHandler(this.buttonSaveChanges_Click);
			// 
			// buttonCloseManager
			// 
			this.buttonCloseManager.Location = new System.Drawing.Point(421, 514);
			this.buttonCloseManager.Name = "buttonCloseManager";
			this.buttonCloseManager.Size = new System.Drawing.Size(125, 23);
			this.buttonCloseManager.TabIndex = 9;
			this.buttonCloseManager.Text = "Закрыть";
			this.buttonCloseManager.UseVisualStyleBackColor = true;
			this.buttonCloseManager.Click += new System.EventHandler(this.buttonCloseManager_Click);
			// 
			// textBoxCommentary
			// 
			this.textBoxCommentary.Location = new System.Drawing.Point(293, 397);
			this.textBoxCommentary.Multiline = true;
			this.textBoxCommentary.Name = "textBoxCommentary";
			this.textBoxCommentary.Size = new System.Drawing.Size(253, 68);
			this.textBoxCommentary.TabIndex = 11;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.Location = new System.Drawing.Point(42, 397);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 16);
			this.label5.TabIndex = 10;
			this.label5.Text = "Комментарий:";
			// 
			// linkLabelOpenFolder
			// 
			this.linkLabelOpenFolder.AutoSize = true;
			this.linkLabelOpenFolder.Location = new System.Drawing.Point(375, 290);
			this.linkLabelOpenFolder.Name = "linkLabelOpenFolder";
			this.linkLabelOpenFolder.Size = new System.Drawing.Size(92, 13);
			this.linkLabelOpenFolder.TabIndex = 12;
			this.linkLabelOpenFolder.TabStop = true;
			this.linkLabelOpenFolder.Text = "Перейти к папке";
			this.linkLabelOpenFolder.Visible = false;
			this.linkLabelOpenFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelOpenFolder_LinkClicked);
			// 
			// buttonDeleteCase
			// 
			this.buttonDeleteCase.Location = new System.Drawing.Point(45, 514);
			this.buttonDeleteCase.Name = "buttonDeleteCase";
			this.buttonDeleteCase.Size = new System.Drawing.Size(125, 23);
			this.buttonDeleteCase.TabIndex = 13;
			this.buttonDeleteCase.Text = "Удалить запись";
			this.buttonDeleteCase.UseVisualStyleBackColor = true;
			this.buttonDeleteCase.Click += new System.EventHandler(this.buttonDeleteCase_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label7.Location = new System.Drawing.Point(42, 473);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(160, 16);
			this.label7.TabIndex = 15;
			this.label7.Text = "Последнее изменение:";
			// 
			// labelLastModifyInfo
			// 
			this.labelLastModifyInfo.AutoSize = true;
			this.labelLastModifyInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelLastModifyInfo.Location = new System.Drawing.Point(237, 473);
			this.labelLastModifyInfo.Name = "labelLastModifyInfo";
			this.labelLastModifyInfo.Size = new System.Drawing.Size(11, 16);
			this.labelLastModifyInfo.TabIndex = 16;
			this.labelLastModifyInfo.Text = "l";
			// 
			// buttonShowChronology
			// 
			this.buttonShowChronology.Location = new System.Drawing.Point(293, 339);
			this.buttonShowChronology.Name = "buttonShowChronology";
			this.buttonShowChronology.Size = new System.Drawing.Size(253, 23);
			this.buttonShowChronology.TabIndex = 18;
			this.buttonShowChronology.Text = "Посмотреть хронологию";
			this.buttonShowChronology.UseVisualStyleBackColor = true;
			this.buttonShowChronology.Click += new System.EventHandler(this.buttonShowChronology_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.Location = new System.Drawing.Point(42, 342);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(123, 16);
			this.label6.TabIndex = 17;
			this.label6.Text = "Хронология дела:";
			// 
			// comboBoxChooceWorker
			// 
			this.comboBoxChooceWorker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxChooceWorker.FormattingEnabled = true;
			this.comboBoxChooceWorker.Location = new System.Drawing.Point(293, 53);
			this.comboBoxChooceWorker.Name = "comboBoxChooceWorker";
			this.comboBoxChooceWorker.Size = new System.Drawing.Size(253, 21);
			this.comboBoxChooceWorker.TabIndex = 19;
			// 
			// textBoxCaseTime
			// 
			this.textBoxCaseTime.Location = new System.Drawing.Point(293, 154);
			this.textBoxCaseTime.MaxLength = 5;
			this.textBoxCaseTime.Multiline = true;
			this.textBoxCaseTime.Name = "textBoxCaseTime";
			this.textBoxCaseTime.Size = new System.Drawing.Size(253, 20);
			this.textBoxCaseTime.TabIndex = 21;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label8.Location = new System.Drawing.Point(42, 154);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(170, 16);
			this.label8.TabIndex = 20;
			this.label8.Text = "Время заседания(мм:чч):";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(293, 306);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(253, 23);
			this.button1.TabIndex = 22;
			this.button1.Text = "Выбрать папку";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// FormManagement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(603, 582);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBoxCaseTime);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.comboBoxChooceWorker);
			this.Controls.Add(this.buttonShowChronology);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.labelLastModifyInfo);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.buttonDeleteCase);
			this.Controls.Add(this.linkLabelOpenFolder);
			this.Controls.Add(this.textBoxCommentary);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.buttonCloseManager);
			this.Controls.Add(this.buttonSaveChanges);
			this.Controls.Add(this.dateTimePickerExpirationDate);
			this.Controls.Add(this.comboBoxCaseStatus);
			this.Controls.Add(this.buttonChooseFolder);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "FormManagement";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Управление записями";
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
		private System.Windows.Forms.Button buttonSaveChanges;
		private System.Windows.Forms.Button buttonCloseManager;
		private System.Windows.Forms.TextBox textBoxCommentary;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.LinkLabel linkLabelOpenFolder;
		private System.Windows.Forms.Button buttonDeleteCase;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label labelLastModifyInfo;
		private System.Windows.Forms.Button buttonShowChronology;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox comboBoxChooceWorker;
		private System.Windows.Forms.TextBox textBoxCaseTime;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button button1;
	}
}

