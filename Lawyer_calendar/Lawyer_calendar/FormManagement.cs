using System;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace Lawyer_calendar
{
	public partial class FormManagement : Form
	{
		public FormManagement()
		{
			InitializeComponent();
			dateTimePickerExpirationDate.Value = DateTime.Today;
		}

		private string pathToDirectory = "";

		private void FormManagement_Load(object sender, EventArgs e)
		{
			try
			{
				SqlConnector.SqlConnect();
			}
			catch(Exception ex)
			{
				MessageBox.Show("Connect error\n" + ex.Message);
			}
		}

		private void buttonSaveChanges_Click(object sender, EventArgs e)
		{
			LegalCase singleCase = SetCaseValues();

			if(string.IsNullOrEmpty(pathToDirectory))
			{
				MessageBox.Show("Каталог не выбран", "Ошибка");
				return;
			}

			if(dateTimePickerExpirationDate.Value == DateTime.Today)
			{
				MessageBox.Show("Выбрана сегодняшняя дата", "Ошибка");
				return;
			}
			if(IsConfirm("Хотите добавить новую запись?"))
			{
				string commandSqlString = $"insert into lawyer_calendar_table (WorkerName, FolderAddress, ExpDate, Commentary, Status) " +
				$"VALUES ('{singleCase.LinkedWorker}', '{singleCase.AddressOfDir}', '{singleCase.ExpirationDateStr}', '{singleCase.Commentary}', '{singleCase.CaseStatusStr}' )";

				if (SqlConnector.SqlOperation(commandSqlString))
				{
					MessageBox.Show("Запись добавлена");
				}
				else
				{
					MessageBox.Show("Запись не добавлена");
				}
			}
		}

		private bool IsConfirm(string message)
		{
			return MessageBox.Show(message, "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
		}
	

		private void buttonChooseFolder_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
			if(folderDialog.ShowDialog() == DialogResult.OK)
			{
				pathToDirectory = folderDialog.SelectedPath;

			}
			else
			{
				MessageBox.Show("Папка не выбрана", "Предупреждение");
			}
		}

		private LegalCase SetCaseValues()
		{
			LegalCase singleCase = new LegalCase();
			singleCase.LinkedWorker = textBoxWorkerName.Text;
			singleCase.ExpirationDate = dateTimePickerExpirationDate.Value;
			singleCase.caseStatus = IntToCaseStatus(comboBoxCaseStatus.SelectedIndex);
			singleCase.AddressOfDir = pathToDirectory.Replace("\\", "\\\\");
			singleCase.Commentary = textBoxCommentary.Text;

			return singleCase;
		}

		private static CaseStatus IntToCaseStatus(int index)
		{
			CaseStatus caseStatus;

			switch (index)
			{
				case 0:
					caseStatus = CaseStatus.InWork;
					break;

				case 1:
					caseStatus = CaseStatus.Ready;
					break;

				case 2:
					caseStatus = CaseStatus.InArchive;
					break;

				default:
					caseStatus = CaseStatus.NoStatus;
					break;
			}

			return caseStatus;
		}

		private void linkLabelOpenFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if(pathToDirectory != "")
				Process.Start(pathToDirectory);
		}
	}
}
