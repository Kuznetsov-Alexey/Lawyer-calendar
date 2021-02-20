namespace Lawyer_calendar
{
	partial class FormDisplayCases
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.labelMonthAndYear = new System.Windows.Forms.Label();
			this.buttonCurrentMonth = new System.Windows.Forms.Button();
			this.buttonPreviousMonth = new System.Windows.Forms.Button();
			this.buttonNextMonth = new System.Windows.Forms.Button();
			this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
			this.labelMonday = new System.Windows.Forms.Label();
			this.labelTuesday = new System.Windows.Forms.Label();
			this.labelWednsday = new System.Windows.Forms.Label();
			this.labelThursday = new System.Windows.Forms.Label();
			this.labelFriday = new System.Windows.Forms.Label();
			this.labelSaturday = new System.Windows.Forms.Label();
			this.labelSunday = new System.Windows.Forms.Label();
			this.flowDays = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.label8 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			this.label10 = new System.Windows.Forms.Label();
			this.linkLabel6 = new System.Windows.Forms.LinkLabel();
			this.panel1.SuspendLayout();
			this.flowLayoutPanel5.SuspendLayout();
			this.flowDays.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.flowLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.buttonCurrentMonth);
			this.panel1.Controls.Add(this.labelMonthAndYear);
			this.panel1.Controls.Add(this.buttonNextMonth);
			this.panel1.Controls.Add(this.buttonPreviousMonth);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1234, 80);
			this.panel1.TabIndex = 0;
			// 
			// labelMonthAndYear
			// 
			this.labelMonthAndYear.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.labelMonthAndYear.AutoSize = true;
			this.labelMonthAndYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMonthAndYear.Location = new System.Drawing.Point(528, 28);
			this.labelMonthAndYear.Name = "labelMonthAndYear";
			this.labelMonthAndYear.Size = new System.Drawing.Size(228, 37);
			this.labelMonthAndYear.TabIndex = 0;
			this.labelMonthAndYear.Text = "Февраль, 2021";
			// 
			// buttonCurrentMonth
			// 
			this.buttonCurrentMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCurrentMonth.Location = new System.Drawing.Point(1065, 28);
			this.buttonCurrentMonth.Name = "buttonCurrentMonth";
			this.buttonCurrentMonth.Size = new System.Drawing.Size(166, 37);
			this.buttonCurrentMonth.TabIndex = 4;
			this.buttonCurrentMonth.Text = "Текущий месяц";
			this.buttonCurrentMonth.UseVisualStyleBackColor = true;
			this.buttonCurrentMonth.Click += new System.EventHandler(this.buttonCurrentMonth_Click);
			// 
			// buttonPreviousMonth
			// 
			this.buttonPreviousMonth.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.buttonPreviousMonth.Location = new System.Drawing.Point(432, 28);
			this.buttonPreviousMonth.Name = "buttonPreviousMonth";
			this.buttonPreviousMonth.Size = new System.Drawing.Size(63, 37);
			this.buttonPreviousMonth.TabIndex = 2;
			this.buttonPreviousMonth.Text = "<";
			this.buttonPreviousMonth.UseVisualStyleBackColor = true;
			this.buttonPreviousMonth.Click += new System.EventHandler(this.buttonPreviousMonth_Click);
			// 
			// buttonNextMonth
			// 
			this.buttonNextMonth.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.buttonNextMonth.Location = new System.Drawing.Point(780, 28);
			this.buttonNextMonth.Name = "buttonNextMonth";
			this.buttonNextMonth.Size = new System.Drawing.Size(63, 37);
			this.buttonNextMonth.TabIndex = 3;
			this.buttonNextMonth.Text = ">";
			this.buttonNextMonth.UseVisualStyleBackColor = true;
			this.buttonNextMonth.Click += new System.EventHandler(this.buttonNextMonth_Click);
			// 
			// flowLayoutPanel5
			// 
			this.flowLayoutPanel5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.flowLayoutPanel5.Controls.Add(this.labelMonday);
			this.flowLayoutPanel5.Controls.Add(this.labelTuesday);
			this.flowLayoutPanel5.Controls.Add(this.labelWednsday);
			this.flowLayoutPanel5.Controls.Add(this.labelThursday);
			this.flowLayoutPanel5.Controls.Add(this.labelFriday);
			this.flowLayoutPanel5.Controls.Add(this.labelSaturday);
			this.flowLayoutPanel5.Controls.Add(this.labelSunday);
			this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.flowLayoutPanel5.Location = new System.Drawing.Point(0, 80);
			this.flowLayoutPanel5.Name = "flowLayoutPanel5";
			this.flowLayoutPanel5.Size = new System.Drawing.Size(1234, 45);
			this.flowLayoutPanel5.TabIndex = 0;
			// 
			// labelMonday
			// 
			this.labelMonday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.labelMonday.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMonday.Location = new System.Drawing.Point(3, 3);
			this.labelMonday.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelMonday.Name = "labelMonday";
			this.labelMonday.Size = new System.Drawing.Size(170, 38);
			this.labelMonday.TabIndex = 18;
			this.labelMonday.Text = "Понедельник";
			this.labelMonday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelTuesday
			// 
			this.labelTuesday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.labelTuesday.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelTuesday.Location = new System.Drawing.Point(179, 3);
			this.labelTuesday.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelTuesday.Name = "labelTuesday";
			this.labelTuesday.Size = new System.Drawing.Size(170, 38);
			this.labelTuesday.TabIndex = 17;
			this.labelTuesday.Text = "Вторник";
			this.labelTuesday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelWednsday
			// 
			this.labelWednsday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.labelWednsday.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelWednsday.Location = new System.Drawing.Point(355, 3);
			this.labelWednsday.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelWednsday.Name = "labelWednsday";
			this.labelWednsday.Size = new System.Drawing.Size(170, 38);
			this.labelWednsday.TabIndex = 24;
			this.labelWednsday.Text = "Среда";
			this.labelWednsday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelThursday
			// 
			this.labelThursday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.labelThursday.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelThursday.Location = new System.Drawing.Point(531, 3);
			this.labelThursday.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelThursday.Name = "labelThursday";
			this.labelThursday.Size = new System.Drawing.Size(170, 38);
			this.labelThursday.TabIndex = 25;
			this.labelThursday.Text = "Четверг";
			this.labelThursday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelFriday
			// 
			this.labelFriday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.labelFriday.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelFriday.Location = new System.Drawing.Point(707, 3);
			this.labelFriday.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelFriday.Name = "labelFriday";
			this.labelFriday.Size = new System.Drawing.Size(170, 38);
			this.labelFriday.TabIndex = 29;
			this.labelFriday.Text = "Пятница";
			this.labelFriday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelSaturday
			// 
			this.labelSaturday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.labelSaturday.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelSaturday.Location = new System.Drawing.Point(883, 3);
			this.labelSaturday.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelSaturday.Name = "labelSaturday";
			this.labelSaturday.Size = new System.Drawing.Size(170, 38);
			this.labelSaturday.TabIndex = 34;
			this.labelSaturday.Text = "Суббота";
			this.labelSaturday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelSunday
			// 
			this.labelSunday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.labelSunday.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelSunday.Location = new System.Drawing.Point(1059, 3);
			this.labelSunday.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelSunday.Name = "labelSunday";
			this.labelSunday.Size = new System.Drawing.Size(170, 38);
			this.labelSunday.TabIndex = 35;
			this.labelSunday.Text = "Воскресенье";
			this.labelSunday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// flowDays
			// 
			this.flowDays.BackColor = System.Drawing.Color.White;
			this.flowDays.Controls.Add(this.flowLayoutPanel2);
			this.flowDays.Controls.Add(this.flowLayoutPanel3);
			this.flowDays.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowDays.Location = new System.Drawing.Point(0, 125);
			this.flowDays.Name = "flowDays";
			this.flowDays.Size = new System.Drawing.Size(1234, 760);
			this.flowDays.TabIndex = 4;
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel2.Controls.Add(this.label8);
			this.flowLayoutPanel2.Controls.Add(this.linkLabel1);
			this.flowLayoutPanel2.Controls.Add(this.linkLabel2);
			this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(260, 111);
			this.flowLayoutPanel2.TabIndex = 0;
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label8.Location = new System.Drawing.Point(3, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(132, 23);
			this.label8.TabIndex = 4;
			this.label8.Text = "1";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(141, 0);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(71, 13);
			this.linkLabel1.TabIndex = 4;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Single case 1";
			// 
			// linkLabel2
			// 
			this.linkLabel2.AutoSize = true;
			this.linkLabel2.Location = new System.Drawing.Point(3, 23);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(71, 13);
			this.linkLabel2.TabIndex = 5;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "Single case 2";
			// 
			// flowLayoutPanel3
			// 
			this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.flowLayoutPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel3.Controls.Add(this.label10);
			this.flowLayoutPanel3.Controls.Add(this.linkLabel6);
			this.flowLayoutPanel3.Location = new System.Drawing.Point(269, 3);
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			this.flowLayoutPanel3.Size = new System.Drawing.Size(260, 111);
			this.flowLayoutPanel3.TabIndex = 7;
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label10.Location = new System.Drawing.Point(3, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(132, 23);
			this.label10.TabIndex = 4;
			this.label10.Text = "1";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// linkLabel6
			// 
			this.linkLabel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.linkLabel6.Location = new System.Drawing.Point(3, 23);
			this.linkLabel6.Name = "linkLabel6";
			this.linkLabel6.Size = new System.Drawing.Size(256, 33);
			this.linkLabel6.TabIndex = 5;
			this.linkLabel6.TabStop = true;
			this.linkLabel6.Text = "Single case 2";
			// 
			// FormDisplayCases
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1234, 885);
			this.Controls.Add(this.flowDays);
			this.Controls.Add(this.flowLayoutPanel5);
			this.Controls.Add(this.panel1);
			this.Name = "FormDisplayCases";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Общий вид";
			this.Load += new System.EventHandler(this.FormDisplayCases_Load);
			this.Resize += new System.EventHandler(this.FormDisplayCases_Resize);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.flowLayoutPanel5.ResumeLayout(false);
			this.flowDays.ResumeLayout(false);
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.flowLayoutPanel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

	






		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label labelMonthAndYear;
		private System.Windows.Forms.Button buttonPreviousMonth;
		private System.Windows.Forms.Button buttonNextMonth;
		private System.Windows.Forms.Button buttonCurrentMonth;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
		private System.Windows.Forms.Label labelMonday;
		private System.Windows.Forms.Label labelTuesday;
		private System.Windows.Forms.Label labelWednsday;
		private System.Windows.Forms.Label labelThursday;
		private System.Windows.Forms.Label labelFriday;
		private System.Windows.Forms.Label labelSaturday;
		private System.Windows.Forms.Label labelSunday;
		private System.Windows.Forms.FlowLayoutPanel flowDays;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.LinkLabel linkLabel6;
	}
}