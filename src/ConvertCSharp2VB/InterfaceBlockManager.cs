
using System;

namespace ConvertCSharp2VB
{

	public class InterfaceBlockManager: ClassBlockManager
	{
		public string GetBlock(string tcDeclaration, string tcBlock)
		{
			return this.GetClassBlock(tcDeclaration, tcBlock);
		}

		protected override string Execute()
		{
			string lcRetVal;
			lcRetVal = this.BlankToken + this.ClassDeclarationToken + this.ImplementationDeclationToken;
			lcRetVal += this.ClassBlockToken + "\r\n" + this.BlankToken + "End Interface" + "\r\n";
			return lcRetVal;
		}

	}
}
