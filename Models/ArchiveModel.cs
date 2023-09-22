using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LNTADSpreadsheets.Models
{
	public class ArchiveModel
	{
		public int ID { get; set; }

		[DisplayName("File Name")]
		public string FileName { get; set; }

		[DisplayName("Size (Kb)")]
		public string Size { get; set; }

		[DisplayName("Date Created")]
		public DateTime DateCreated { get; set; }

		[DisplayName("Locked?")]
		public string IsDeleted { get; set; }
		[DisplayName("Created By")]
		public string CreatedBy { get; set; }
	}
}
