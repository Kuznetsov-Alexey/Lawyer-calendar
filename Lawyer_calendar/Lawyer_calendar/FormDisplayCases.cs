using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lawyer_calendar
{
	public partial class FormDisplayCases : Form
	{
		public FormDisplayCases()
		{
			InitializeComponent();
		}

		private FormWindowState LastWindowState = FormWindowState.Minimized;

		//список календарных дней
		private List<FlowLayoutPanel> listFlowDays = new List<FlowLayoutPanel>();
		private DateTime currentDate = DateTime.Today;

		private bool sevenDaysMode = false;

		private void FormDisplayCases_Load(object sender, EventArgs e)
		{
			try
			{
				SqlConnector.SqlConnect();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка подключения к базе данных\n" + ex.Message);
				this.Close();
				return;
			}

			GenerateDayPanel(42);
			DisplayCurrentDate();
		}

		//расширение формы на весь экран
		private void FormDisplayCases_Resize(object sender, System.EventArgs e)
		{

			Label[] weekDayLabels = GetWeekdaysLabels();

			Size panelSize = this.flowDays.Size;
			int width = (panelSize.Width - 15 * weekDayLabels[0].Margin.Left) / 7;
			int height = (panelSize.Height - 10 * weekDayLabels[0].Margin.Top) / 6;

			//увеличить размеры панелей
			foreach (FlowLayoutPanel panel in listFlowDays)
			{
				panel.Size = new Size(width, height);
			}

			foreach (Label label in weekDayLabels)
			{
				label.Size = new Size(width, label.Size.Height);
			}

			//buttonCurrentMonth.Size = new Size(width, buttonCurrentMonth.Size.Height);

			#region oldDesign

			//if (WindowState != LastWindowState)
			//{
			//	LastWindowState = WindowState;



			//	if (WindowState == FormWindowState.Maximized)
			//	{
			//		//Label[] weekDayLabels = GetWeekdaysLabels();

			//		//Size panelSize = this.flowDays.Size;
			//		//int width = (panelSize.Width - 13 * weekDayLabels[0].Margin.Left) / 7;
			//		//int height = (panelSize.Height - 10 * weekDayLabels[0].Margin.Top) / 6;

			//		//увеличить размеры панелей
			//		foreach (FlowLayoutPanel panel in listFlowDays)
			//		{
			//			panel.Size = new Size(width, height);
			//		}

			//		foreach(Label label in weekDayLabels)
			//		{
			//			label.Size = new Size(width, label.Size.Height);
			//		}

			//	}
			//	if (WindowState == FormWindowState.Normal)
			//	{
			//		// Normal

			//		//Label[] weekDayLabels = GetWeekdaysLabels();

			//		//Size panelSize = this.flowDays.Size;
			//		//int width = (panelSize.Width - 15 * weekDayLabels[0].Margin.Left) / 7;
			//		//int height = (panelSize.Height - 10 * weekDayLabels[0].Margin.Top) / 6;

			//		//увеличить размеры панелей
			//		foreach (FlowLayoutPanel panel in listFlowDays)
			//		{
			//			panel.Size = new Size(width, height);
			//		}

			//		foreach (Label label in weekDayLabels)
			//		{
			//			label.Size = new Size(width, label.Size.Height);
			//		}
			//	}
			//}
			#endregion
		}

		private Label[] GetWeekdaysLabels()
		{
			Label[] array = { this.labelMonday, this.labelTuesday, this.labelWednsday, this.labelThursday, this.labelFriday, this.labelSaturday, this.labelSunday };
			return array;
		}



		private void AddNewCase(object sender, EventArgs e)
		{
			FlowLayoutPanel senderPanel = (FlowLayoutPanel)sender;

			if ((int)senderPanel.Tag != 0)
			{
				DateTime chosenDate = new DateTime(currentDate.Year, currentDate.Month, (int)senderPanel.Tag);

				using (FormManagement form = new FormManagement(chosenDate))
				{					
					form.ShowDialog();
				}
				DisplayCurrentDate();
			}
		}

		private void ShowCaseDetails(object sender, EventArgs e)
		{
			LinkLabel senderLabel = (LinkLabel)sender;
			int caseID = (int)senderLabel.Tag;
			string sqlRequestStr = $"SELECT * from lawyer_calendar_table WHERE ID ='{caseID}' ";
			DataTable dataTable = SqlConnector.ConvertQueryToDataTable(sqlRequestStr);

			if(dataTable.Rows.Count > 0)
			{
				DataRow dataRow = dataTable.Rows[0];				
				LegalCase legalCase = new LegalCase(dataRow);

				using (FormManagement form = new FormManagement())
				{
					form.SetFormValues(legalCase);					
					form.ShowDialog();
				}
			}
			DisplayCurrentDate();
		}


		//считать данные из БД и заполнить календарь
		private void AddCasesToFlowObject(int startDayInCalendar)
		{
			DateTime startDate = new DateTime(currentDate.Year, currentDate.Month, 1);
			DateTime endDate = startDate.AddMonths(1).AddDays(-1);

			string sqlRequestStr = $"SELECT * from lawyer_calendar_table WHERE ExpDate BETWEEN '{startDate.ToShortDateString()}' and '{endDate.ToShortDateString()}' ORDER BY ExpDate";

			DataTable dataTable = SqlConnector.ConvertQueryToDataTable(sqlRequestStr);

			foreach (DataRow dataRow in dataTable.Rows)
			{
				DateTime caseDay = DateTime.Parse(dataRow["ExpDate"].ToString());

				if (caseDay.Month != currentDate.Month)
					continue;

				LinkLabel link = new LinkLabel();
				link.Name = $"link{dataRow["ID"].ToString()}";				
				link.AutoSize = false;				
				link.BorderStyle = BorderStyle.FixedSingle;
				link.LinkBehavior = LinkBehavior.NeverUnderline;
				link.LinkColor = Color.Black;
				link.Margin = new Padding(3, 3, 0, 0);
				link.Size = new Size(listFlowDays[0].Size.Width - link.Margin.Left * 8, link.Size.Height);
				link.Tag = dataRow["ID"];
				link.Click += new System.EventHandler(this.ShowCaseDetails);


				link.BackColor = GetColorByCaseStatus(dataRow["Status"].ToString());
				link.Text = caseDay.ToString("hh:mm ") +  
							LegalCase.GetShortDirName(dataRow["FolderAddress"].ToString()) + " " + 
							GetUserNameByID((int)dataRow["WorkerID"]); 

				listFlowDays[(caseDay.Day - 1) + (startDayInCalendar - 1)].Controls.Add(link);
				
			}
		}

		private string GetUserNameByID(int ID)
		{
			string realName = "";

			string sqlRequestStr = $"SELECT FIO from lawyer_names WHERE ID ='{ID}' ";
			DataTable dataTable = SqlConnector.ConvertQueryToDataTable(sqlRequestStr);

			if (dataTable.Rows.Count > 0)
			{
				realName = dataTable.Rows[0].ItemArray[0].ToString();
				//realName = dataTable.Rows[0].Field<string>("FIO");
			}
			return realName;
		}

		private Color GetColorByCaseStatus(string status)
		{

			Color color;

			LegalCase legalCase = new LegalCase();
			legalCase.CaseStatusStr = status;

			switch(legalCase.caseStatus)
			{
				case CaseStatus.InWork:
					color = Color.PeachPuff;
					break;
				case CaseStatus.Ready:
					color = Color.MediumSeaGreen;
					break;
				case CaseStatus.InArchive:
					color = Color.White;
					break;
				case CaseStatus.NoStatus:
					color = Color.Silver;
					break;

				default:
					color = Color.Gray;
					break;
			}

			return color;
		}


		//отобразить дату и все события выбранного месяца
		private void DisplayCurrentDate()
		{
			int firstDayAtFlNumber = GetFirstDayCurrentDate();
			int totalDay = GetTotalDaysCurrentDate();

			labelMonthAndYear.Text = currentDate.ToString("MMMM, yyy");
			AddLabelDayToFlDay(firstDayAtFlNumber, totalDay);
			AddCasesToFlowObject(firstDayAtFlNumber);
		}

		//получить номер дня недели первого числа выбранного месяца
		private int GetFirstDayCurrentDate()
		{
			int sundayNumber = 7;

			DateTime firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);

			if ((int)firstDayOfMonth.DayOfWeek == 0)
				return sundayNumber;
			
			else
				return (int)firstDayOfMonth.DayOfWeek;			
		}

		//получить количество дней в месяце
		private int GetTotalDaysCurrentDate()
		{
			DateTime firstDayOfNextMonth;

			if (currentDate.Month == 12)
			{
				firstDayOfNextMonth = new DateTime(currentDate.Year + 1, 1, 1);
			}
			else 
			{
				firstDayOfNextMonth = new DateTime(currentDate.Year, currentDate.Month + 1, 1);
			}

			DateTime lastDayOfCurrentMonth = firstDayOfNextMonth.AddDays(-1);
			return (int)lastDayOfCurrentMonth.Day;
		}

		//создать панель с днями
		private void GenerateDayPanel(int totalDays)
		{
			flowDays.Controls.Clear();
			listFlowDays.Clear();

			for (int i = 1; i <= totalDays; i++)
			{
				Size size = this.Size;
				FlowLayoutPanel flowPanel = new FlowLayoutPanel();
				flowPanel.Name = $"flDay{i}";
				flowPanel.Size = new Size(170, 120);
				flowPanel.BackColor = Color.White;
				flowPanel.BorderStyle = BorderStyle.FixedSingle;
				flowPanel.Cursor = Cursors.Hand;				
				flowPanel.Click += new System.EventHandler(this.AddNewCase);
				flowPanel.AutoScroll = true;
				flowPanel.Anchor = AnchorStyles.Left;

				//flowPanel.Anchor = AnchorStyles.Left | AnchorStyles.Right;

				//if(i % 7 == 0 || (i + 1) % 7 == 0)
				//{
				//	flowPanel.BackColor = Color.Gainsboro;
				//}


				flowDays.Controls.Add(flowPanel);
				listFlowDays.Add(flowPanel);
			}
		}

		//добавить объекты дней в календаре
		private void AddLabelDayToFlDay(int startDayAtFlow, int totalDaysInMonth)
		{
			foreach(FlowLayoutPanel panel in listFlowDays)
			{
				panel.BackColor = Color.White;// Color.FromArgb(192, 255, 192);
				panel.Controls.Clear();
				panel.Tag = 0;
			}

			for (int index = 1; index <= totalDaysInMonth; index++)
			{
				FlowLayoutPanel currentPanel = listFlowDays[(index - 1) + (startDayAtFlow - 1)];

				Label label = new Label();
				label.Name = $"lblDay{index}";
				//label.AutoSize = false;
				label.TextAlign = ContentAlignment.MiddleLeft;
				//label.Size = new Size(currentPanel.Size.Width - 30, 23);
				label.Size = new Size(currentPanel.Size.Width / 3, 23);
				label.Text = index.ToString();
				label.Font = new Font("Microsoft Sans Serif", 10);

				if(new DateTime(currentDate.Year, currentDate.Month, index) == DateTime.Today)
				{
					currentPanel.BackColor = Color.FromArgb(192, 255, 255);
				}

				currentPanel.Enabled = true;
				currentPanel.BorderStyle = BorderStyle.FixedSingle;
				currentPanel.Tag = index;				
				currentPanel.Controls.Add(label);				
			}

			foreach (FlowLayoutPanel panel in listFlowDays)
			{
				if ((int)panel.Tag == 0)
				{
					panel.BorderStyle = BorderStyle.None;
					panel.Enabled = false;
				}
			}
		}

		

		private void buttonPreviousMonth_Click(object sender, EventArgs e)
		{
			PickPreviousMonth();
		}

		private void buttonNextMonth_Click(object sender, EventArgs e)
		{
			PickNextMonth();
		}

		private void buttonCurrentMonth_Click(object sender, EventArgs e)
		{
			PickToday();
		}

		private void PickPreviousMonth()
		{
			currentDate = currentDate.AddMonths(-1);

			DisplayCurrentDate();
		}

		private void PickNextMonth()
		{
			currentDate = currentDate.AddMonths(+1);
			DisplayCurrentDate();
		}

		private void PickToday()
		{
			currentDate = DateTime.Today;
			DisplayCurrentDate();
		}
	}
}
