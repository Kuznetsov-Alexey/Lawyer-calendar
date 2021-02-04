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
		}


		//список календарных дней
		private List<FlowLayoutPanel> listFlowDays = new List<FlowLayoutPanel>();
		private DateTime currentDate = DateTime.Today;

		private void FormDisplayCases_Load(object sender, EventArgs e)
		{
			
			GenerateDayPanel(42);
			DisplayCurrentDate();
		}

		private void DisplayCurrentDate()
		{
			labelMonthAndYear.Text = currentDate.ToString("MMMM, yyy");
			AddLabelDayToFlDay(GetFirstDayCurrentDate(), GetTotalDaysCurrentDate());
		}

		private int GetFirstDayCurrentDate()
		{
			int sundayNumber = 7;

			DateTime firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);

			if ((int)firstDayOfMonth.DayOfWeek == 0)
				return sundayNumber;
			
			else
				return (int)firstDayOfMonth.DayOfWeek;			
		}

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
				flowDays.Controls.Add(flowPanel);
				listFlowDays.Add(flowPanel);
			}
		}

		private void AddLabelDayToFlDay(int startDayAtFlow, int totalDaysInMonth)
		{
			foreach(FlowLayoutPanel panel in listFlowDays)
			{
				panel.Controls.Clear();
			}

			for (int index = 1; index <= totalDaysInMonth; index++)
			{
				Label label = new Label();
				label.Name = $"lblDay{index}";
				label.AutoSize = false;
				label.TextAlign = ContentAlignment.MiddleRight;
				label.Size = new Size(132, 23);
				label.Text = index.ToString();
				label.Font = new Font("Microsoft Sans Serif", 10);
				listFlowDays[(index - 1) + (startDayAtFlow - 1)].Controls.Clear();
				listFlowDays[(index - 1) + (startDayAtFlow - 1)].Controls.Add(label);				
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
