using System;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lawyer_calendar
{
	public partial class FormManagement : Form
	{
		#region Dictionary Searching
		//private readonly Dictionary<string, string> userNamesDict = new Dictionary<string, string> 
		//{
		//	{"", ""},
		//	{"", ""},
		//	{"", ""},
		//	{"", ""}
		//};

		//private string GetUserNameDict(string dnsName)
		//{
		//	dnsName = dnsName.Trim();
		//	string fullName = "";
		//	foreach(KeyValuePair<string, string> pair in userNamesDict)
		//	{
		//		if(dnsName == pair.Key)
		//		{
		//			fullName = pair.Value;
		//		}
		//	}

		//	if (fullName == "")
		//		return dnsName;
		//	else
		//		return fullName;
		//}
		#endregion


		public FormManagement(DateTime chosenDate)
		{
			InitializeComponent();
			dateTimePickerExpirationDate.Value = chosenDate;
		}

		public int CaseId = 0;
		private string pathToDirectory = "";

		private void FormManagement_Load(object sender, EventArgs e)
		{
			
		}

		public void SetFormValues(LegalCase legalCase, string caseStatus)
		{
			this.Text = LegalCase.GetShortDirName(legalCase.PathToDir);
			this.textBoxWorkerName.Text = legalCase.WorkerName;
			this.dateTimePickerExpirationDate.Value = (DateTime)legalCase.ExpirationDate;
			this.comboBoxCaseStatus.SelectedItem = caseStatus;
			this.pathToDirectory = legalCase.PathToDir;
			this.textBoxCommentary.Text = legalCase.Commentary;
			this.linkLabelOpenFolder.Visible = true;
			this.labelLastModifyInfo.Text = legalCase.LastModifyName + "    :    " + legalCase.LastModifyDate.ToShortDateString();
		}

		private void buttonDeleteCase_Click(object sender, EventArgs e)
		{
			if (IsConfirm("Удалить выбранную запись"))
			{
				string commandSqlString = $"DELETE from lawyer_calendar_table WHERE ID = '{CaseId}'";

				if (SqlConnector.SqlInsertUpdateDelete(commandSqlString))
					MessageBox.Show("Запись удалена");

				else
					MessageBox.Show("Запись не удалена");
				this.Close();
			}
		}


		private void buttonSaveChanges_Click(object sender, EventArgs e)
		{
			LegalCase singleCase = GetCaseValues();

			if(string.IsNullOrEmpty(pathToDirectory))
			{
				MessageBox.Show("Папка не выбрана", "Ошибка");
				return;
			}

			if (CaseId == 0)
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
				if (IsConfirm("Хотите обновить текущую запись?"))
				{
					string commandSqlString = $"UPDATE lawyer_calendar_table SET  WorkerName = '{singleCase.WorkerName}',  FolderAddress = '{singleCase.PathToDir}', " +
																				$"ExpDate = '{singleCase.ExpirationDateStr}', Commentary ='{singleCase.Commentary}', " +
																				$"Status = '{singleCase.CaseStatusStr}', LastModifyDate = '{singleCase.LastModifyDateStr}'," +
																				$"LastModifyName = '{singleCase.LastModifyName}'" +
																	$" WHERE ID = '{CaseId}'";

					if (SqlConnector.SqlInsertUpdateDelete(commandSqlString))
						MessageBox.Show("Запись обновлена");

					else
						MessageBox.Show("Запись не обновлена");
					this.Close();

				}
			}
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

		private LegalCase GetCaseValues()
		{
			LegalCase singleCase = new LegalCase();
			singleCase.WorkerName = textBoxWorkerName.Text;
			singleCase.ExpirationDate = dateTimePickerExpirationDate.Value;
			singleCase.CaseStatusStr = comboBoxCaseStatus.SelectedItem.ToString();
			singleCase.PathToDir = pathToDirectory.Replace("\\", "\\\\");
			singleCase.Commentary = textBoxCommentary.Text;
			singleCase.LastModifyDate = DateTime.Today;
			singleCase.LastModifyName = Environment.UserName;
			//singleCase.LastModifyName = GetUserNameDict(Environment.UserName);

			return singleCase;
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
			using (FormCaseChronology form = new FormCaseChronology(CaseId, this.Text))
			{
				this.Visible = false;
				form.ShowDialog();
				this.Visible = true;
			}
		}
	}
}
