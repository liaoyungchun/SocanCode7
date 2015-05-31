

using System;

namespace ConvertCSharp2VB
{

	public class NameSpaceManager: BaseManager
	{
		public string GetNameSpaceBlock(string tcNameSpace, string tcBlock)
		{
			this.GetBlankToken(tcNameSpace);
			string lcRetVal;
			lcRetVal = this.BlankToken + tcNameSpace.Trim().Replace("namespace", "Namespace") + "\r\n";
			lcRetVal += this.ExtractBlock(tcBlock, "{", "}") ;
			lcRetVal += "\r\n" + this.BlankToken + "End Namespace" + "\r\n";
			return lcRetVal;
		}
	}
}
