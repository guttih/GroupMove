using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupMove.Entity
{
	public class CommentFileInfo
	{
		public int FirstCommentLineIndex { get; set; }
		public int LastCommentLineIndex { get; set; }

		public CommentFileInfo()
		{
			FirstCommentLineIndex = LastCommentLineIndex = -1;
		}

		public bool HasComments()
		{
			return FirstCommentLineIndex < LastCommentLineIndex;
		}
		public bool IsValid()
		{
			return (FirstCommentLineIndex > -1 && LastCommentLineIndex > -1);
		}
	}
}
