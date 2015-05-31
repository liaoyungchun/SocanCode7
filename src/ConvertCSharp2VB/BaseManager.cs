using System;
using System.Text;

namespace ConvertCSharp2VB
{
	public struct MappingToken
	{
		public string cOriginal;
		public string cToken;
	}

	public struct ElseBlockToken
	{
		public string ElseLine;
		public string ElseBlock;
	}

	public class BaseManager
	{
		public string BlankToken = "";

		protected string ExtractBlock(string tcBlock, string tcStartString, string tcEndString)
		{
			if(tcBlock.Trim().Length == 0)
				return "";

			int nStart = 0;
			int nEnd = 0;
			nStart = tcBlock.IndexOf(tcStartString);
			nEnd = tcBlock.LastIndexOf(tcEndString);

			if(nStart <0 || nEnd < 0)
				return tcBlock;
	
			return tcBlock.Substring(nStart + tcStartString.Length , nEnd -nStart-tcStartString.Length).TrimEnd();
		}

		public void GetBlankToken(string tcLine)
		{
			StringBuilder sb = new StringBuilder();
			for(int i=0; i<tcLine.Length; i++)
			{
				if(Char.IsWhiteSpace(tcLine[i]))
				{
					sb.Append(tcLine[i]);
				}
				else
				{
					break;
				}
			}
			this.BlankToken = sb.ToString();
		}	

		protected string GetCurrentBlock(string tcBlock)
		{
			if(tcBlock.IndexOf("{") >=0 && tcBlock.IndexOf("}") >=0)
			{
				return this.ExtractBlock(tcBlock, "{", "}");
			}
			else
			{
				string[] lcStr = tcBlock.Trim().Split('\n');
				StringBuilder sb = new StringBuilder();
				sb.Append(this.BlankToken);
				sb.Append("	");
				for(int i = 0; i < lcStr.Length; i++)
				{
					sb.Append(lcStr[i]);
				}

				return sb.ToString();
			}
		}
	}
}
