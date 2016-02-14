using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace GroupMove.Entity
{
	class Groups
	{
		List<Group> _groupList = new List<Group>();

		private readonly string[][] _assignment;
		private Groups() { }  //make private, must be constructed with parameters
		public Groups(string[][] assignment)
		{
			if (assignment == null) throw new ArgumentNullException(nameof(assignment));

			_assignment = assignment;

			var groupNames = GetUnique(3);
			var memberCount = GetUnique(1).Length;		//membersNames
			var assignmentCount = GetUnique(2).Length;	//assignmentIDs
			foreach (string item in groupNames)
			{
				var members = SearchCount(item, 3);
				_groupList.Add(new Group(item, members, memberCount, assignmentCount));
			}
		}


		//returns the index of the biggest value
		private int GetBiggestIndex(int[] arr, bool getOnlyTheBiggest)
		{
			int maxValue = arr.Max();
			int count = 0;
			int index = -1;
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i] == maxValue)
				{
					if (!getOnlyTheBiggest)
						return i; //we just want the biggest
					count++;
					index = i;
				}
			}

			//we just want a number bigger than all other numbers
			if (count == 1)
				return index;

			return -1;//the biggest number is not unique

		}

		private int[] groupSearchCount(String assignment)
		{
			int[] counts = new int[_groupList.Count];
			for (int i = 0; i < _groupList.Count; i++)
			{
				counts[i] = SearchCount(assignment, 2, _groupList[i].Name, 3);
			}

			return counts;

		} 


		
		public string[][] SplitAssignments(System.Windows.Forms.TextBox tbReport)
		{

			var assignmentsLeft = new List<string>(GetUnique(2));
			var assignmentsRemove = new List<string>();
			while (assignmentsLeft.Remove(""));
			String stringToReturn = "Splitting " + assignmentsLeft.Count + " assignments into " + _groupList.Count + " groups.\r\n\r\n";

			//find an assignment which has one group with more mmembers than others and has slots left
		
			foreach (var item in assignmentsLeft)
			{
				var counts = groupSearchCount(item);

				var biggestIndex = GetBiggestIndex(counts, true);
				if (biggestIndex > -1)
				{
					//moving this assignment to the group with them most members
					if (_groupList[biggestIndex].AddAssignment(item))
						assignmentsRemove.Add(item);
				}
			}

			assignmentsLeft = assignmentsLeft.Except(assignmentsRemove).ToList();
			assignmentsRemove.Clear();

			//done adding assignments having groupmemebers more than other groups

			//todo: hér fyrir neðan ætti að skoða aðferðina nánar..., lítur út fyrir að virki en þarf líklega að hugsa betur.

			

			//next add to groups that have groups
			foreach (var item in assignmentsLeft)
			{
				var counts = groupSearchCount(item);
				if (AddAssignmentToNextGroupIfFoundInGroup(item, counts))
					assignmentsRemove.Add(item);
			}

			assignmentsLeft = assignmentsLeft.Except(assignmentsRemove).ToList();
			assignmentsRemove.Clear();

			//Handle the remaining assignments
			
			
			foreach (var item in assignmentsLeft)
			{
				var counts = groupSearchCount(item);
				if (AddAssignmentToNextGroup(item))
					assignmentsRemove.Add(item);
			}

			assignmentsLeft = assignmentsLeft.Except(assignmentsRemove).ToList();
			assignmentsRemove.Clear();

			stringToReturn += PrintAssignmentGroups();
			stringToReturn += "\r\n( Not yet devided : " + assignmentsLeft.Count + " )\r\n";
		
			foreach (var item in assignmentsLeft)
			{
				stringToReturn +="    " + item +"\r\n";
			}

			if (tbReport != null)
				tbReport.AppendText(stringToReturn);

			return ToArray();
		}

		private int FindNextNoneZero(int [] array, int indexStartSearch)
		{

			if (!(indexStartSearch < array.Length))
				return -1;

			for (int i = indexStartSearch; i < array.Length; i++)
			{
				if (array[i] != 0)
					return i;
			}

			return -1;
		}

		private bool AddAssignmentToNextGroupIfFoundInGroup(String assignmentID, int [] searchCount)
		{
			double maxRatio = 0;
			int index = FindNextNoneZero(searchCount, 0);
			while (  (index < _groupList.Count )  &&  (index > -1 )  )
			{
				if (_groupList[index].AddAssignment(assignmentID) == true)
					return true;

				index = FindNextNoneZero(searchCount, index + 1);
			}

			return false;
		}

		private bool AddAssignmentToNextGroup(String assignmentID)
		{
			int index = 0;
			double maxRatio = 0;
			for (var i = 0; i < _groupList.Count; i++)
			{
				var thisRatio = _groupList[i].RatioOfSlotsLeft();
				if (thisRatio > maxRatio)
				{
					index = i;
					maxRatio = thisRatio;
				}
			}

			return _groupList[index].AddAssignment(assignmentID);
		}

		public String PrintAssignmentGroups()
		{
			String stringToReturn = "";
			int assignmentsInGroupsCount = 0;
			foreach (var item in _groupList)
			{
				stringToReturn += item.PrintAssignments() + "\r\n";
				assignmentsInGroupsCount += item.AssignmentCount;
			}

			stringToReturn += "\r\nThere are now " + assignmentsInGroupsCount + " assigments split up into groups.\r\n";
			return stringToReturn;

		}

		//counts columns containing strFindMe.
		//the first row is not counted, it should contain headings
		public int SearchCount(string strFindMe, int columnToSearch)
		{
			int ret = 0;

			if (!(columnToSearch < _assignment[0].Length) )
				throw new ArgumentOutOfRangeException();

			for (var i = 1; i < _assignment.Length; i++)
			{
				if (strFindMe.Equals(_assignment[i][columnToSearch]))
					ret++;
			}

			return ret;
		}

		//counts columns containing strFindMe1 and strFindMe2.
		//the first row is not counted, it should contain headings
		public int SearchCount(string strFindMe1, int columnToSearch1,
							   string strFindMe2, int columnToSearch2)
		{
			int ret = 0;

			if ((columnToSearch1 < _assignment[0].Length) &&
				(columnToSearch2 < _assignment[0].Length)){ 
				for (var i = 1; i < _assignment.Length; i++)
				{
					if (strFindMe1.Equals(_assignment[i][columnToSearch1]) &&
						strFindMe2.Equals(_assignment[i][columnToSearch2])) {
						ret++;
					}
				}
			}

			return ret;
		}

		//counts values excluding the first row which contains headings
		public int Count()
		{
			return _assignment.Length - 1;
		}

		public string[] GetUnique(int column)
		{
			return GetUnique(_assignment, column);
		}

		private static string[] GetUnique(string[][] arrayOfArray, int column)
		{
			if (arrayOfArray == null) throw new ArgumentNullException(nameof(arrayOfArray));

			if (!(column < arrayOfArray[0].Length))
				return null;//column out of index

			var list = new List<string>();
			for (var i = 1; i < arrayOfArray.Length; i++)
			{
				if (list.IndexOf(arrayOfArray[i][column]) == -1)
					list.Add(arrayOfArray[i][column]);
			}
			list.Sort();
			return list.ToArray();
		}

		//returns only those which have unique same two columns
		private static string[][] GetUnique(string[][] arrayOfArray, int column1, int column2)
		{
			if (arrayOfArray == null) throw new ArgumentNullException(nameof(arrayOfArray));

			if (!(column1 < arrayOfArray[0].Length) ||
				!(column2 < arrayOfArray[0].Length) )
				return null;//column out of index

			var listConcat = new List<string>();
			foreach (var line in arrayOfArray)
			{
				listConcat.Add("|" + line[column1] + "_" + line[column2] + "|");
			}
			var list = new List<string>();
			for (var i = 1; i < listConcat.Count; i++)
			{
				if (list.IndexOf(listConcat[i]) == -1)
					list.Add(listConcat[i]);
			}
			var listRet = new List<string[]>();
			for (int i = 0; i < list.Count; i++)
			{
				int sep = list[i].IndexOf('_', 1) - 1;
				var strID = list[i].Substring(1, sep);
				var strGr = list[i].Substring(sep + 2, list[i].Length - (sep + 3) );
				if (strID.Length > 0)
					listRet.Add(new string[2] { strID, strGr });
			}

			listRet.Sort((s, t) => String.Compare(s[0], t[0]));
			return listRet.ToArray();
		}

		public string[][] ToArray()
		{
			var lines = new List<string[]>();
			
			foreach (var group in _groupList)
			{
				foreach (var assignment in group.AssignmentList)
				{
					string[] line = new string[_assignment[0].Length];
					line[2] = assignment;
					line[3] = group.Name;
					lines.Add(line);
				}
			}

			return lines.ToArray();

		}

	}
}
