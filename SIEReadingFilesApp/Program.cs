using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Globalization;

namespace SIEReadingFilesApp
{
	class Program
	{
		static void Main(string[] args)
		{
			GreetingMessage();
			
			Console.WriteLine("\nEnter your file name with path:\n");

			// Take file name as a string
			string FileName = Console.ReadLine();
			StreamReader file = new StreamReader(FileName);

			// declaring variables
			int counter = 0;
			string line;

			//creating a list of array with double data type
			List<double> values = new List<double>();
						
			while ((line = file.ReadLine()) != null)
			{
				string pattern = @"#TRANS (\d{4}) {.*} (-?\d*.\d*)"; // Example: #TRANS 1630 {} 1.00
				var match = Regex.Match(line, pattern);
			
				if (match.Success)
				{
					double converted = MatchingMethod(match);
					values.Add(converted);
					counter++;
				}
			}
			var sum = values.Sum();

			PrintColor (ConsoleColor.Red);
			Console.WriteLine($"\n\nTotal amount {0}\n", sum);
			Console.ResetColor();
			Console.WriteLine("There were {0} lines.", counter);
			Console.ReadLine();

		}

		private static double MatchingMethod(Match match)
		{
			return Convert.ToDouble(match.Groups[2].Value, provider: CultureInfo.InvariantCulture);
		}

		//Greetings
		static void GreetingMessage()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Welcome to SIE Reading Files App");
			Console.WriteLine("Date: 2017-10-23");
			Console.WriteLine("---------------------\n");
			Console.ResetColor();
		}
		//print color message
		static void PrintColor(ConsoleColor color)
		{
			Console.ForegroundColor = color;
		}
	}
}
