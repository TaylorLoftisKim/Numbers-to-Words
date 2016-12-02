using System.Collections.Generic;
using System;

namespace NumbersToWords.Objects
{
	public class NumberWord
	{
		List <string> NumberWords = new List <string> {};
		private static Dictionary <int, string> _numbers = new Dictionary <int, string> ()
		{
			[1]="One", [2]="Two", [3]="Three", [4]="Four", [5]="Five", [6]="Six", [7]="Seven", [8]="Eight", [9]="Nine",

			[11]="Eleven", [12]="Twelve", [13]="Thirteen", [14]="Fourteen", [15]="Fifteen", [16]="Sixteen", [17]="Seventeen", [18]="Eighteen", [19]="Nineteen",

			[10]="Ten", [20]="Twenty", [30]="Thirty", [40]="Forty", [50]="Fifty", [60]="Sixty", [70]="Seventy", [80]="Eighty", [90]="Ninety",

			[100]="Hundred",
		};

		private static Dictionary <int, string> _numberGroups = new Dictionary <int, string> ()
		{
			[2]="Thousand", [3]="Million", [4]="Billion", [5]="Trillion",
		};

		public static string GetWords(int userNumber)
		{
			List<string> wordList = new List<string>{};
			if (userNumber < 0)
			{
				wordList.Add("Negative");
				userNumber *= -1;
			}
			string userString = userNumber.ToString();

			int count = 0;
			List<string> numberList = new List<string>{};
			string numberBuilder = "";
			for (int stringIndex = userString.Length - 1; stringIndex >= 0; stringIndex--)
			{
				count++;
				numberBuilder += userString[stringIndex];
				if (count > 2)
				{
					char[] charArray = numberBuilder.ToCharArray();
			    Array.Reverse(charArray);
					numberList.Add(new string(charArray));
					numberBuilder = "";
					count = 0;
				}
				else if (stringIndex == 0)
				{
					char[] charArray = numberBuilder.ToCharArray();
			    Array.Reverse(charArray);
					numberList.Add(new string(charArray));
					numberBuilder = "";
					count = 0;
				}
			}

			numberList.Reverse();

			count = numberList.Count;
			bool notEmpty = false;
			for (int groupIndex = 0; groupIndex < numberList.Count; groupIndex++)
			{

				int groupNumber = int.Parse(numberList[groupIndex]);
				if (groupNumber >=100 && groupNumber < 1000)
				{
					notEmpty = true;
					wordList.Add(_numbers[Convert.ToInt32(Math.Floor(groupNumber / 100.0))]);
					wordList.Add(_numbers[100]);
					groupNumber = groupNumber % 100;
				}
				else if (groupNumber >= 20 && groupNumber < 100)
				{
					notEmpty = true;
					wordList.Add(_numbers[groupNumber - (groupNumber % 10)]);
					groupNumber = groupNumber % 10;
				}
				else if (groupNumber < 20 && groupNumber > 0)
				{
					notEmpty = true;
					wordList.Add(_numbers[groupNumber]);
					groupNumber = 0;
				}
				if (count > 1)
				{
					if (notEmpty)
					{
						wordList.Add(_numberGroups[count]);
						notEmpty = false;
					}
				}
				count--;
			}
			return string.Join(" ", wordList);
		}
	}
}
