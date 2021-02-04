using System;


namespace Lawyer_calendar
{

	internal enum CaseStatus
	{
		InWork,
		Ready,
		InArchive,
		NoStatus
	}

	internal class LegalCase
	{
		public string LinkedWorker { get; set; }		

		public string AddressOfDir { get; set; }

		public string Commentary { get; set; }

		public CaseStatus caseStatus { private get; set; }

		public string CaseStatusStr
		{
			get
			{
				switch(caseStatus)
				{
					case CaseStatus.InWork:
						return "В работе";

					case CaseStatus.Ready:
						return "Выполнен";

					case CaseStatus.InArchive:
						return "В архиве";
						
				}
				return "Нет статуса";
			}
		}

		public DateTime ExpirationDate { private get; set; }

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
