using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

		private bool dataWasUpdated = false;
		private bool dataWasSaved = false;

		private int caseID;
		private DataTable dataTable;

		public FormCaseChronology(int caseId, string caseName)
		{
			InitializeComponent();

			this.caseID = caseId;
			this.Text = caseName;

			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.AllowUserToAddRows = false;

			string sqlRequestStr = $"SELECT * from lawyer_event_table WHERE caseID ='{caseId}' ";
			dataTable = SqlConnector.ConvertQueryToDataTable(sqlRequestStr);


			dataGridView1.DataSource = dataTable;
			// делаем недоступным столбец id для изменения			
			dataGridView1.Columns["caseID"].Visible = false;

			dataGridView1.Columns["eventDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}

		private void buttonSaveChanges_Click(object sender, EventArgs e)
		{

			string commandSqlString = $"DELETE from lawyer_event_table WHERE caseID='{caseID}'";
			bool isSuccess = SqlConnector.SqlInsertUpdateDelete(commandSqlString);

			foreach (DataRow row in dataTable.Rows)
			{
				string addedEvent = row.Field<string>("eventDesc");
				commandSqlString = $"INSERT into lawyer_event_table (caseID, eventDesc) VALUES ('{caseID}', '{addedEvent}')";
				isSuccess = SqlConnector.SqlInsertUpdateDelete(commandSqlString);
			}
			if(isSuccess)
				MessageBox.Show("Данные обновлены");
			else
				MessageBox.Show("Данные не добавлены");

			dataWasSaved = true;
			this.Close();
		}

		private void buttonAddEvent_Click(object sender, EventArgs e)
		{
			DataRow row = dataTable.NewRow(); // добавляем новую строку в DataTable
			row.SetField<int>(0, caseID);
			dataTable.Rows.Add(row);
		}

		private void FormCaseChronology_Closing(object sender, FormClosingEventArgs e)
		{
			if(dataWasUpdated && !dataWasSaved)
			{
				if (MessageBox.Show("Хотите сохранить сделанные изменения?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
				{
					this.buttonSaveChanges_Click(this, null);
				}
			}
		}

		private void FormCaseChronology_CellValueChanged(object sender, EventArgs e)
		{
			this.dataWasUpdated = true;
		}


		private void buttonDeleteEvent_Click(object sender, EventArgs e)
		{
			// удаляем выделенные строки из dataGridView1
			foreach (DataGridViewRow row in dataGridView1.SelectedRows)
			{
				dataGridView1.Rows.Remove(row);
			}
		}
	}
}
