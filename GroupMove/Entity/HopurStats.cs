using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupMove.Entity
{
	public class HopurStats
	{
		public int Submitted { get; set; }
		public int NotSubmitted { get; set; }

		public HopurStats()
		{
			Submitted = 0;
			NotSubmitted = 0;
		}
	}
}
