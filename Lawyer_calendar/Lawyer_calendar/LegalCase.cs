using System;
using System.Data;


namespace Lawyer_calendar
{

	internal enum CaseStatus
	{
		InWork,
		Ready,
		InArchive,
		NoStatus
	}

	public class LegalCase
	{
		public LegalCase(DataRow dataRow)
		{
			//DateTime ExpirationDate = (DateTime)dataRow["ExpDate"];
			//DateTime LastModifyDate = (DateTime)dataRow["LastModifyDate"];


			this.PathToDir = dataRow["FolderAddress"].ToString();
			this.WorkerName = dataRow["WorkerName"].ToString();
			this.ExpirationDate = (DateTime)dataRow["ExpDate"];
			this.Commentary = dataRow["Commentary"].ToString();
			this.LastModifyName = dataRow["LastModifyName"].ToString();
			this.LastModifyDate = (DateTime)dataRow["LastModifyDate"];
		}

		public LegalCase() { }

		public string WorkerName { get; set; }		

		public string PathToDir { get; set; }

		public string Commentary { get; set; }

		public string LastModifyName { get; set; }

		public DateTime LastModifyDate { get; set; }

		public string LastModifyDateStr
		{
			get
			{
				string lastModifyString = LastModifyDate.Year + "." + LastModifyDate.Month + "." + LastModifyDate.Day;
				return lastModifyString;
			}
		}

		private CaseStatus caseStatus { get; set; }

		public string CaseStatusStr
		{
			get
			{
				switch(caseStatus)
				{
					case CaseStatus.InWork:
						return "В работе";

					case CaseStatus.Ready:
						return "Готово к показу";

					case CaseStatus.InArchive:
						return "В архиве";
						
				}
				return "Нет статуса";
			}
			set
			{
				switch (value)
				{
					case "В работе":
						caseStatus = CaseStatus.InWork;
						break;

					case "Готово к показу":
						caseStatus = CaseStatus.Ready;
						break;

					case "В архиве":
						caseStatus = CaseStatus.InArchive;
						break;

					default:
						caseStatus = CaseStatus.NoStatus;
						break;
				}
			}
		}

		public DateTime ExpirationDate { get; set; }

		public string ExpirationDateStr
		{
			get
			{				
				string expDateString = ExpirationDate.Year + "." + ExpirationDate.Month + "." + ExpirationDate.Day;
				return expDateString;
			}
		}
	}
}
