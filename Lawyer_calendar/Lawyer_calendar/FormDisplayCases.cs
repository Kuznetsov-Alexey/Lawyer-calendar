using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lawyer_calendar
{
	public partial class FormDisplayCases : Form
	{
		public FormDisplayCases()
		{
			InitializeComponent();
			SqlConnector.SqlConnect();
		}


		//список календарных дней
		private List<FlowLayoutPanel> listFlowDays = new List<FlowLayoutPanel>();
		private DateTime currentDate = DateTime.Today;

		private void FormDisplayCases_Load(object sender, EventArgs e)
		{
			GenerateDayPanel(42);
			DisplayCurrentDate();
		}

		private void AddNewCase(object sender, EventArgs e)
		{
			FlowLayoutPanel senderPanel = (FlowLayoutPanel)sender;

			if ((int)senderPanel.Tag != 0)
			{
				DateTime chosenDate = new DateTime(currentDate.Year, currentDate.Month, (int)senderPanel.Tag);

				using (FormManagement formM = new FormManagement(chosenDate))
				{
					formM.ShowDialog();
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
				DateTime ExpirationDate = (DateTime)dataRow["ExpDate"];
				
				LegalCase legalCase = new LegalCase(dataRow);
				
				string caseStatus = dataRow["Status"].ToString();

				using (FormManagement form = new FormManagement(ExpirationDate))
				{
					form.CaseId = (int)dataRow["ID"];
					form.SetFormValues(legalCase, caseStatus);
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

			string sqlRequestStr = $"SELECT * from lawyer_calendar_table WHERE ExpDate BETWEEN '{startDate.ToShortDateString()}' and '{endDate.ToShortDateString()}'";

			DataTable dataTable = SqlConnector.ConvertQueryToDataTable(sqlRequestStr);

			foreach(DataRow row in dataTable.Rows)
			{
				DateTime caseDay = DateTime.Parse(row["ExpDate"].ToString());

				if (caseDay.Month != currentDate.Month)
					continue;

				LinkLabel link = new LinkLabel();
				link.Name = $"link{row["ID"].ToString()}";
				link.Tag = row["ID"];
				link.Click += new System.EventHandler(this.ShowCaseDetails);

				link.Text = GetShortNameOfDir(row["FolderAddress"].ToString());

				listFlowDays[(caseDay.Day - 1) + (startDayInCalendar - 1)].Controls.Add(link);
			}
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
				FlowLayoutPanel flowPanel = new FlowLayoutPanel();
				flowPanel.Name = $"flDay{i}";
				flowPanel.Size = new Size(135, 98);
				flowPanel.BackColor = Color.White;
				flowPanel.BorderStyle = BorderStyle.FixedSingle;
				flowPanel.Cursor = Cursors.Hand;				
				flowPanel.Click += new System.EventHandler(this.AddNewCase);
				flowPanel.AutoScroll = true;

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
				label.AutoSize = false;
				label.TextAlign = ContentAlignment.MiddleRight;
				label.Size = new Size(126, 23);
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

		//обрезать строчку до имени каталога
		private string GetShortNameOfDir(string pathToFolder)
		{
			string shortName = pathToFolder.Substring(pathToFolder.LastIndexOf("\\") + 1);
			return shortName;
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
