namespace Lawyer_calendar
{
	partial class FormCaseChronology
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.buttonAddEvent = new System.Windows.Forms.Button();
			this.buttonSaveChanges = new System.Windows.Forms.Button();
			this.buttonDeleteEvent = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 12);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(654, 369);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.FormCaseChronology_CellValueChanged);
			// 
			// buttonAddEvent
			// 
			this.buttonAddEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonAddEvent.Location = new System.Drawing.Point(54, 407);
			this.buttonAddEvent.Name = "buttonAddEvent";
			this.buttonAddEvent.Size = new System.Drawing.Size(121, 39);
			this.buttonAddEvent.TabIndex = 1;
			this.buttonAddEvent.Text = "Добавить";
			this.buttonAddEvent.UseVisualStyleBackColor = true;
			this.buttonAddEvent.Click += new System.EventHandler(this.buttonAddEvent_Click);
			// 
			// buttonSaveChanges
			// 
			this.buttonSaveChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonSaveChanges.Location = new System.Drawing.Point(278, 407);
			this.buttonSaveChanges.Name = "buttonSaveChanges";
			this.buttonSaveChanges.Size = new System.Drawing.Size(121, 39);
			this.buttonSaveChanges.TabIndex = 2;
			this.buttonSaveChanges.Text = "Сохранить";
			this.buttonSaveChanges.UseVisualStyleBackColor = true;
			this.buttonSaveChanges.Click += new System.EventHandler(this.buttonSaveChanges_Click);
			// 
			// buttonDeleteEvent
			// 
			this.buttonDeleteEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonDeleteEvent.Location = new System.Drawing.Point(492, 407);
			this.buttonDeleteEvent.Name = "buttonDeleteEvent";
			this.buttonDeleteEvent.Size = new System.Drawing.Size(121, 39);
			this.buttonDeleteEvent.TabIndex = 3;
			this.buttonDeleteEvent.Text = "Удалить";
			this.buttonDeleteEvent.UseVisualStyleBackColor = true;
			this.buttonDeleteEvent.Click += new System.EventHandler(this.buttonDeleteEvent_Click);
			// 
			// FormCaseChronology
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(680, 474);
			this.Controls.Add(this.buttonDeleteEvent);
			this.Controls.Add(this.buttonSaveChanges);
			this.Controls.Add(this.buttonAddEvent);
			this.Controls.Add(this.dataGridView1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormCaseChronology";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FormCaseChronologyView";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCaseChronology_Closing);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button buttonAddEvent;
		private System.Windows.Forms.Button buttonSaveChanges;
		private System.Windows.Forms.Button buttonDeleteEvent;
	}
}