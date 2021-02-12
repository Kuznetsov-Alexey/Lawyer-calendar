using System;
using System.Data;
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
		private DataTable shownDataTable;
		private DataTable comparedDataTable;

		public FormCaseChronology(int caseID, string caseName)
		{
			InitializeComponent();

			this.caseID = caseID;
			this.Text = caseName;

			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.AllowUserToAddRows = false;

			string sqlRequestStr = $"SELECT * from lawyer_event_table WHERE caseID ='{this.caseID}' ";
			shownDataTable = SqlConnector.ConvertQueryToDataTable(sqlRequestStr);
			comparedDataTable = SqlConnector.ConvertQueryToDataTable(sqlRequestStr);

			dataGridView1.DataSource = shownDataTable;
			shownDataTable.Columns["eventDesc"].ColumnName = "Описание события";

			dataGridView1.Columns["caseID"].Visible = false;
			dataGridView1.Columns["Описание события"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;			
		}

		private bool IsDataModified()
		{
			bool isModified = false;

			string sqlRequestStr = $"SELECT * from lawyer_event_table WHERE caseID ='{caseID}' ";
			DataTable dataTable = SqlConnector.ConvertQueryToDataTable(sqlRequestStr);

			if (dataTable != this.comparedDataTable)
			{
				isModified = true;
			}
			return isModified;
		}

		private void buttonSaveChanges_Click(object sender, EventArgs e)
		{

			//if (IsDataModified())
			//{
			//	MessageBox.Show("Во время работы данные были изменены другим пользователем\nЗаново откройте данное окно", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
			//	this.dataWasUpdated = false;
			//	this.Close();
			//	return;
			//}

			shownDataTable.Columns["Описание события"].ColumnName = "eventDesc";

			string commandSqlString = $"DELETE from lawyer_event_table WHERE caseID='{caseID}'";
			bool isSuccess = SqlConnector.SqlInsertUpdateDelete(commandSqlString);							

			foreach (DataRow row in shownDataTable.Rows)
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
			DataRow row = shownDataTable.NewRow(); // добавляем новую строку в DataTable
			row.SetField<int>(0, caseID);
			shownDataTable.Rows.Add(row);
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
