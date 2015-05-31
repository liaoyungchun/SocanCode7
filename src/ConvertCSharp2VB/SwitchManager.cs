
using System;

namespace ConvertCSharp2VB
{

	public class SwitchManager:BaseManager
	{
		private string SwitchExpressionToken = "";
		private string SwitchBlock = "";
		
		public string GetBlock(string tcSwitchLine, string tcSwitchBlock)
		{
			this.GetBlankToken(tcSwitchLine);
			this.SwitchExpressionToken = this.ExtractBlock(tcSwitchLine, "(", ")");

			//Pass the switchblock as is back 
			this.SwitchBlock = this.ExtractBlock(tcSwitchBlock, "{", "}").Replace("default", "case Else");

			return this.Execute();
		}

		private string Execute()
		{
			string lcRetVal = "";
			lcRetVal = this.BlankToken + "Select Case " + this.SwitchExpressionToken + "\n";
			lcRetVal += this.SwitchBlock + "\n";
			lcRetVal += this.BlankToken + "End Select" + "\n";
			return lcRetVal;
		}
	}
}
