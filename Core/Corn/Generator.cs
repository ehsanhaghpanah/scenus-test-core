/**
 * Copyright (C) scenüs, 2021.
 * All rights reserved.
 * Ehsan Haghpanah; haghpanah@scenus.com
 */

using System;
using System.Text;

namespace scenus.Test.Core
{
	/// <summary>
	/// 
	/// </summary>
	static public class Generator
	{
		private static readonly Random random = new Random((int) DateTime.Now.Ticks);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="size"></param>
		/// <returns></returns>
		public static string GetString(int size)
		{
			var sb = new StringBuilder();
			for (var i = 0; i < size; i++)
				sb.Append((char)random.Next('a', 'z' + 1));
			return sb.ToString();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="prefix"></param>
		/// <returns></returns>
		public static string GetMobileNumber(string prefix = "0917")
		{
			return prefix + random.Next(1000000, 9999999);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static string GetEmailAddress()
		{
			return GetString(16) + "@" + GetString(8) + "." + GetString(3);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static string GetNationalID()
		{
			var s = random.Next(123456789, 987654321).ToString();
			int sum = 0, check_digit;
			for (var i = 0; i < 9; i++)
				sum += (int.Parse(s.Substring(i, 1)) * (10 - i));
			var mod = sum % 11;
			if (mod < 2)
				check_digit = mod;
			else
				check_digit = (11 - mod);

			return s + check_digit;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static string GetPersianWord()
		{
			var result = ResourceObjects.String1;
			var list = result.Split(' ');
			var indx = random.Next(0, list.Length);
			return list[indx];
		}
	}
}

//public static class Generator
//{
//	public static string get_new_pan()
//	{
//		string pan = random.Next(11112222, 88889999).ToString();
//		for (int i = 10001000; i < 99999999; i++)
//		{
//			if (CardPANValidator.Validate(pan + i))
//			{
//				using (var client = new WS.ForeEnd.Gateway())
//				{
//					if (client.IsUniqueByPan(pan + i))
//						return pan + i;
//				}
//			}
//		}
//		throw new IndexOutOfRangeException();
//	}
//	public static string get_value(string path)
//	{
//		var reader = new StreamReader(path);
//		var result = reader.ReadToEnd();
//		var list = result.Split(new[] { '\n' });
//		var indx = random.Next(0, list.Length);
//		return list[indx];
//	}
//	public static string get_iban()
//	{
//		string a = get_new_national_id();
//		string b = get_new_national_id();
//		string c = get_new_national_id();
//		string d = a + b + c;
//		return "IR" + d.Substring(0, 24);
//	}
//}