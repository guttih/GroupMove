using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupMove.Entity
{
	
	internal class Group
	{
		
		public List<string> AssignmentList = new List<string>();

		public int  Slots { get; set; }
		public string	Name { get; }

		private int MemberCount { get; }

		public int CourceMemberCount { get; }

		public int	AllAssignmentCount { get; }
		
		public int AssignmentCount => AssignmentList.Count;


		public Group(string name, int memberCount, int courceMemberCount, int allAssignmentCount)
		{
			Name				= name;
			MemberCount			= memberCount;
			AllAssignmentCount	= allAssignmentCount;
			CourceMemberCount	= courceMemberCount;
		}

		//returns true if there is a free slot in this group
		public bool AddAssignment(string assignmentGroupId)
		{
			if (SlotsLeft() > 0)
			{
				AssignmentList.Add(assignmentGroupId);
				return true;
			}

			return false;
		}
		public double Ratio()
		{
			double ret = MemberCount / (double) CourceMemberCount;
			return ret;
		}

		public double RatioOfSlotsLeft()
		{
			SlotsLeft();
			double ret = Slots * Ratio();
			return Slots;
		}

		public int SlotsLeft()
		{
			double slots = AllAssignmentCount * Ratio();
			slots -= AssignmentList.Count;
			slots = Math.Round(slots, 0); //todo: how to handle the rest
			int ret = Convert.ToInt32(slots);
			Slots = ret;
			return ret;
		}

		public String PrintAssignments()
		{
			String stringToReturn = " (Group : " + Name + ") (Members : " + MemberCount + ") (Slots: " + Slots + ") (Assigments : " + AssignmentCount + ") \r\n";
			foreach (var item in AssignmentList)
			{
				stringToReturn+= "    " + item + "\r\n";
			}
			return stringToReturn;
		}
	}
}
