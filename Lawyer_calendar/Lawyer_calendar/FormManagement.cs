using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;

namespace Lawyer_calendar
{
	public partial class FormManagement : Form
	{
		public FormManagement()
		{
			InitializeComponent();			
		}

		public FormManagement(DateTime chosenDate)
		{
			InitializeComponent();
			this.buttonShowChronology.Enabled = false;
			this.dateTimePickerExpirationDate.Value = chosenDate;
			this.Text = "Добавление новой записи";

		}

		public int CaseID = 0;
		private string pathToDirectory = "";
		private LegalCase defaultLegalCase;
		

		public void SetFormValues(LegalCase legalCase)
		{
					
			this.CaseID = legalCase.CaseID;
			this.Text = LegalCase.GetShortDirName(legalCase.PathToDir);
			this.textBoxWorkerName.Text = legalCase.WorkerName;
			this.dateTimePickerExpirationDate.Value = (DateTime)legalCase.ExpirationDate;
			this.comboBoxCaseStatus.SelectedItem = legalCase.CaseStatusStr;
			//this.comboBoxCaseStatus.SelectedItem = caseStatus;
			this.pathToDirectory = legalCase.PathToDir;
			this.textBoxCommentary.Text = legalCase.Commentary;
			this.linkLabelOpenFolder.Visible = true;
			this.labelLastModifyInfo.Text = legalCase.LastModifyName + "    :    " + legalCase.LastModifyDate.ToShortDateString();
			this.defaultLegalCase = legalCase;

		}

		private void buttonDeleteCase_Click(object sender, EventArgs e)
		{
			if (IsConfirm("Удалить выбранную запись"))
			{
				string commandSqlStringCalendar = $"DELETE from lawyer_calendar_table WHERE ID = '{CaseID}'";

				string commandSqlStringEvents = $"DELETE from lawyer_event_table WHERE caseID = '{CaseID}'";
				SqlConnector.SqlInsertUpdateDelete(commandSqlStringEvents);


				if (SqlConnector.SqlInsertUpdateDelete(commandSqlStringCalendar))
					MessageBox.Show("Запись удалена");

				else
					MessageBox.Show("Запись не удалена");
				this.Close();
			}
		}

		private void buttonSaveChanges_Click(object sender, EventArgs e)
		{
			LegalCase singleCase = GetFormValues();

			if(string.IsNullOrEmpty(pathToDirectory))
			{
				MessageBox.Show("Папка не выбрана", "Ошибка");
				return;
			}

			if (CaseID == 0)
			{
				if (IsConfirm("Хотите добавить новую запись?"))
				{
					string commandSqlString = $"insert into lawyer_calendar_table (WorkerName, FolderAddress, ExpDate, Commentary, Status, LastModifyDate, LastModifyName) " +
												$"VALUES ('{singleCase.WorkerName}', '{singleCase.PathToDir}', '{singleCase.ExpirationDateStr}', '{singleCase.Commentary}', " +
														$"'{singleCase.CaseStatusStr}', '{singleCase.LastModifyDateStr}','{singleCase.LastModifyName}' )";

					if (SqlConnector.SqlInsertUpdateDelete(commandSqlString))
						MessageBox.Show("Запись добавлена");

					else
						MessageBox.Show("Запись не добавлена");
					this.Close();
				}
			}
			else
			{
				if (IsDataModified())
				{
					MessageBox.Show("Во время работы данные были изменены другим пользователем\nЗаново откройте запись", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close();
					return;
				}

				if (IsConfirm("Хотите обновить текущую запись?"))
				{
					string commandSqlString = $"UPDATE lawyer_calendar_table SET  WorkerName = '{singleCase.WorkerName}',  FolderAddress = '{singleCase.PathToDir}', " +
																				$"ExpDate = '{singleCase.ExpirationDateStr}', Commentary ='{singleCase.Commentary}', " +
																				$"Status = '{singleCase.CaseStatusStr}', LastModifyDate = '{singleCase.LastModifyDateStr}'," +
																				$"LastModifyName = '{singleCase.LastModifyName}'" +
																	$" WHERE ID = '{CaseID}'";

					if (SqlConnector.SqlInsertUpdateDelete(commandSqlString))
						MessageBox.Show("Запись обновлена");

					else
						MessageBox.Show("Запись не обновлена");
					this.Close();

				}
			}
		}

		//проверка базы данных на изменение записи
		private bool IsDataModified()
		{
			bool isModified = false;

			string sqlRequestStr = $"SELECT * from lawyer_calendar_table WHERE ID ='{CaseID}' ";
			DataTable dataTable = SqlConnector.ConvertQueryToDataTable(sqlRequestStr);
			DataRow dataRow = dataTable.Rows[0];
			LegalCase comparedLegalCase = new LegalCase(dataRow);

			if (!AreCaseFieldsEqual(comparedLegalCase, this.defaultLegalCase))
			{
				isModified = true;
			}
			return isModified;
		}

		//сравнение двух классов, заполенных данными их БД
		private bool AreCaseFieldsEqual(LegalCase first, LegalCase second)
		{
			bool fieldsEqual = true;

			if (first.CaseStatusStr != second.CaseStatusStr)
				fieldsEqual = false;

			if (first.WorkerName != second.WorkerName)
				fieldsEqual = false;

			if (first.PathToDir != second.PathToDir)
				fieldsEqual = false;

			if (first.Commentary != second.Commentary)
				fieldsEqual = false;

			return fieldsEqual;
		}

		private void buttonChooseFolder_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
			if(folderDialog.ShowDialog() == DialogResult.OK)
			{
				pathToDirectory = folderDialog.SelectedPath;
				linkLabelOpenFolder.Visible = true;
			}
			else
			{
				MessageBox.Show("Папка не выбрана", "Предупреждение");
			}
		}

		private LegalCase GetFormValues()
		{
			if (comboBoxCaseStatus.SelectedItem == null)
				comboBoxCaseStatus.SelectedIndex = 3;

			LegalCase singleCase = new LegalCase();
			singleCase.WorkerName = textBoxWorkerName.Text;
			singleCase.ExpirationDate = dateTimePickerExpirationDate.Value;
			singleCase.CaseStatusStr = comboBoxCaseStatus.SelectedItem.ToString();
			singleCase.PathToDir = pathToDirectory.Replace("\\", "\\\\");
			singleCase.Commentary = textBoxCommentary.Text;
			singleCase.LastModifyDate = DateTime.Today;
			singleCase.LastModifyName = GetUserNameFromDB(System.Net.Dns.GetHostName());
				
				
				
				
			//singleCase.LastModifyName = Environment.UserName;
			//singleCase.LastModifyName = GetUserNameDict(Environment.UserName);

			return singleCase;
		}

		private string GetUserNameFromDB(string hostName)
		{
			string realName = "";

			string sqlRequestStr = $"SELECT FIO from lawyer_names WHERE dnsName ='{hostName}' ";
			DataTable dataTable = SqlConnector.ConvertQueryToDataTable(sqlRequestStr);			

			if(dataTable.Rows.Count > 0)
			{
				realName = dataTable.Rows[0].Field<string>("FIO");
			}
			return realName;
		}

		private void linkLabelOpenFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if(pathToDirectory != "")
				Process.Start(pathToDirectory);
		}

		private bool IsConfirm(string message)
		{
			return MessageBox.Show(message, "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
		}

		private void buttonCloseManager_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void buttonShowChronology_Click(object sender, EventArgs e)
		{
			using (FormCaseChronology form = new FormCaseChronology(CaseID, this.Text))
			{
				this.Visible = false;
				DialogResult result =  form.ShowDialog();
				this.Visible = true;
			}
		}

	}
}
