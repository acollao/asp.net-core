using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LNTADSpreadsheets.Models
{
    public class ReportModel
    {
		public int ID { get; set; }

		[DisplayName("File Name")]
		public string FileName { get; set; }

		[DisplayName("Size (Kb)")]
		public string Size { get; set; }

		[DisplayName("Date Created")]
		public DateTime DateCreated { get; set; }

		[DisplayName("Locked?")]
		public bool IsDeleted { get; set; }
		[DisplayName("Created By")]
		public string CreatedBy { get; set; }

		[DisplayName("Pub Type")]
		public string PubType { get; set; }
		
		[DisplayName("Category")]
		public string Category { get; set; }
	}
}
