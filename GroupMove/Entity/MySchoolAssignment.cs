using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace GroupMove.Entity
{
	internal class MySchoolAssignment
	{
		private readonly string[][] _assignment;
		private Groups _groups;
		private MySchoolAssignment() {}  //make private, must be constructed with parameters
		public MySchoolAssignment(string[][] assignment)
		{			
			_groups = new Groups(assignment);
		}

		//counts columns containing strFindMe.
		//the first row is not counted, it should contain headings
		public int SearchCount(string strFindMe, int columnToSearch)
		{
			return _groups.SearchCount(strFindMe, columnToSearch);
		}

		//counts values excluding the first row which contains headings
		public int Count()
		{
			return _groups.Count();
		}

		public string[] GetUnique(int column)
		{
			return _groups.GetUnique(column);
		}

		public string[][] SplitAssignments(System.Windows.Forms.TextBox tb)
		{
			return _groups.SplitAssignments(tb);
		}
		
	}
}
