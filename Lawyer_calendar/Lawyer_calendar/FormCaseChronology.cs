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
	public partial class FormCaseChronology : Form
	{
		public FormCaseChronology()
		{
			InitializeComponent();

			
		}

		private int caseId;
		private DataTable dataTable;

		public FormCaseChronology(int caseId)
		{
			InitializeComponent();

			this.caseId = caseId;

			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.AllowUserToAddRows = false;

			string sqlRequestStr = $"SELECT * from lawyer_event_table WHERE caseID ='{caseId}' ";
			dataTable = SqlConnector.ConvertQueryToDataTable(sqlRequestStr);


			dataGridView1.DataSource = dataTable;
			// делаем недоступным столбец id для изменения
			dataGridView1.Columns["caseID"].ReadOnly = true;
			dataGridView1.Columns["caseID"].Visible = false;


			dataGridView1.Columns["eventDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			
			//dataGridView1.Columns["eventDesc"].na = "Описание события";
		}


		


		private void FormCaseChronology_Load(object sender, EventArgs e)
		{
			
		}

		private void buttonAddEvent_Click(object sender, EventArgs e)
		{
			DataRow row = dataTable.NewRow(); // добавляем новую строку в DataTable
			row.SetField<int>(0, caseId);			
			dataTable.Rows.Add(row);
		}
	}
}
