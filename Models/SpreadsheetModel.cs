using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LNTADSpreadsheets.Models
{
	public class SpreadsheetModel
	{
		public int ID { get; set; }

		[DisplayName("File Name")]
		public string FileName { get; set; }

		[DisplayName("Size (Kb)")]
		public string Size { get; set; }

		[DisplayName("Date Modified")]
		public DateTime DateCreated { get; set; }
		public string Controller { get; set; }

		[DisplayName("Locked?")]
		public string IsLocked { get; set; }

		[DisplayName("Modified By")]
		public string CreatedBy { get; set; }

		[DisplayName("Active")]
		public bool Active { get; set; }
	}
}
