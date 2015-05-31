using System;

namespace ConvertCSharp2VB
{
	
    public class CaseManager:BaseManager
	{
		private string CaseExpressionToken = "";
		private string CaseBlock = "";
		
		public string GetBlock(string tcCaseLine, string tcCaseBlock)
		{
			this.GetBlankToken(tcCaseLine);
			this.CaseExpressionToken = ReplaceManager.HandleExpression(this.ExtractBlock(tcCaseLine, "case", ":"));

			if(tcCaseBlock.IndexOf("{") >=0)
			{
				this.CaseBlock = this.ExtractBlock(tcCaseBlock, "{", "}");
			}
			else
			{
				this.CaseBlock = this.ExtractBlock(tcCaseBlock, ":", ";");
			}

			return this.Execute();
		}

		private string Execute()
		{
			string lcRetVal = "";
			lcRetVal = this.BlankToken + "Case " + this.CaseExpressionToken + "\n";
			lcRetVal += this.CaseBlock + "\n";
			return lcRetVal;
		}

	}
}
