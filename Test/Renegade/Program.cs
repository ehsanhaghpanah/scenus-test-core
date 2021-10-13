/**
 * Copyright (C) scenüs, 2010.
 * All rights reserved.
 * Ehsan Haghpanah; haghpanah@scenus.com
 */

using System;

namespace Renegade
{
	/// <summary>
	/// 
	/// </summary>
	static public class Program
	{
		[STAThread]
		static public void Main()
		{
			Console.WriteLine(scenus.Test.Core.Generator.GetEmailAddress());
			Console.WriteLine(scenus.Test.Core.Generator.GetMobileNumber());
			Console.WriteLine(scenus.Test.Core.Generator.GetPersianWord());
			Console.WriteLine(scenus.Test.Core.Generator.GetString(12));
		}
	}
}