using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;
using System.Globalization;

namespace Lawyer_calendar
{
	public partial class FormManagement : Form
	{
		public FormManagement()
		{
			InitializeComponent();
			this.comboBoxChooceWorker.Items.AddRange(GetLawyerNamesFromDB());
		}

		

		public FormManagement(DateTime chosenDate)
		{
			InitializeComponent();
			this.comboBoxChooceWorker.Items.AddRange(GetLawyerNamesFromDB());
			this.buttonShowChronology.Enabled = false;
			this.dateTimePickerExpirationDate.Value = chosenDate;
			this.Text = "Добавление новой записи";			
		}

		



		public int CaseID = 0;
		private string pathToDirectory = "";
		private LegalCase defaultLegalCase;

		private object[] GetLawyerNamesFromDB()
		{
			string sqlRequestStr = $"SELECT FIO from lawyer_names ";
			DataTable dataTable = SqlConnector.ConvertQueryToDataTable(sqlRequestStr);

			object[] namesArray = new object[dataTable.Rows.Count];

			for(int i = 0; i < dataTable.Rows.Count; i++)
			{
				namesArray[i] = dataTable.Rows[i].ItemArray[0];
			}

			return namesArray;
		}
		

		public void SetFormValues(LegalCase legalCase)
		{					
			this.CaseID = legalCase.CaseID;
			this.Text = LegalCase.GetShortDirName(legalCase.PathToDir);			
			this.dateTimePickerExpirationDate.Value = DateTime.Parse(legalCase.ExpirationDate.ToShortDateString());
			this.comboBoxCaseStatus.SelectedItem = legalCase.CaseStatusStr;
			this.comboBoxChooceWorker.SelectedItem = GetUserNameByID(legalCase.WorkerID);
			this.textBoxCaseTime.Text = ((DateTime)legalCase.ExpirationDate).ToString("hh:mm");
			this.pathToDirectory = legalCase.PathToDir;
			this.textBoxCommentary.Text = legalCase.Commentary;
			this.linkLabelOpenFolder.Visible = true;
			this.labelLastModifyInfo.Text = GetUserNameByID(legalCase.LastModifyID) + "    :    " + legalCase.LastModifyDate.ToShortDateString();
			this.defaultLegalCase = legalCase;
		}

		private DateTime GetTimeFromStr(string inputStr)
		{
			DateTime dateTime;


			inputStr = inputStr.Replace(" ", "").Replace(".", ":");

			if (inputStr.Length < 5)
				inputStr = "0" + inputStr;

			try
			{

				dateTime = DateTime.ParseExact(inputStr, "HH:mm", CultureInfo.InvariantCulture);				
				//dateTime = DateTime.Parse(inputStr);
			}
			catch(Exception ex)
			{
				MessageBox.Show($"Не получилось привести время к нужному типу\n {ex.Message}");
				return DateTime.Now;
			}

			return dateTime;
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

			if(comboBoxChooceWorker.SelectedItem == null)
			{
				MessageBox.Show("Работник не выбран", "Ошибка");
				return;
			}

			if (CaseID == 0)
			{
				if (IsConfirm("Хотите добавить новую запись?"))
				{
					string commandSqlString = $"insert into lawyer_calendar_table (WorkerID, FolderAddress, ExpDate, Commentary, Status, LastModifyDate, LastModifyID) " +
												$"VALUES ('{singleCase.WorkerID}', '{singleCase.PathToDir}', '{singleCase.ExpirationDateStr}', '{singleCase.Commentary}', " +
														$"'{singleCase.CaseStatusStr}', '{singleCase.LastModifyDateStr}','{singleCase.LastModifyID}' )";

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
					string commandSqlString = $"UPDATE lawyer_calendar_table SET  WorkerID = '{singleCase.WorkerID}',  FolderAddress = '{singleCase.PathToDir}', " +
																				$"ExpDate = '{singleCase.ExpirationDateStr}', Commentary ='{singleCase.Commentary}', " +
																				$"Status = '{singleCase.CaseStatusStr}', LastModifyDate = '{singleCase.LastModifyDateStr}'," +
																				$"LastModifyID = '{singleCase.LastModifyID}'" +
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

			if (first.WorkerID != second.WorkerID)
				fieldsEqual = false;

			if (first.PathToDir != second.PathToDir)
				fieldsEqual = false;

			if (first.Commentary != second.Commentary)
				fieldsEqual = false;

			return fieldsEqual;
		}

		//кнопка выбора папки
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

		//считать значения с формы 
		private LegalCase GetFormValues()
		{
			if (comboBoxCaseStatus.SelectedItem == null)
				comboBoxCaseStatus.SelectedIndex = 3;

			LegalCase singleCase = new LegalCase();
			singleCase.WorkerID = GetUserIDFromDB(comboBoxChooceWorker.SelectedItem.ToString());
			singleCase.ExpirationDate = dateTimePickerExpirationDate.Value.Add(GetTimeFromStr(textBoxCaseTime.Text).TimeOfDay);
			singleCase.CaseStatusStr = comboBoxCaseStatus.SelectedItem.ToString();
			singleCase.PathToDir = pathToDirectory.Replace("\\", "\\\\");
			singleCase.Commentary = textBoxCommentary.Text;
			singleCase.LastModifyDate = DateTime.Today;
			singleCase.LastModifyID = GetUserIDFromDB(System.Net.Dns.GetHostName());
			//singleCase.LastModifyName = GetUserNameFromDB(System.Net.Dns.GetHostName());		


			//singleCase.LastModifyName = Environment.UserName;
			//singleCase.LastModifyName = GetUserNameDict(Environment.UserName);

			return singleCase;
		}

		//получить id по полному имени или dns 
		private int GetUserIDFromDB(string searchStr)
		{
			int workerID = 0;
			string sqlRequestStr = $"SELECT ID from lawyer_names WHERE dnsName ='{searchStr}' OR FIO = '{searchStr}' ";
			DataTable dataTable = SqlConnector.ConvertQueryToDataTable(sqlRequestStr);

			if (dataTable.Rows.Count > 0)
			{
				workerID = (int)dataTable.Rows[0].ItemArray[0];
			}
			return workerID;
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
