using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SIEReadingFilesApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Welcome to the new practice app");
			Console.ResetColor();
			Console.WriteLine("Enter your file name with path:");

			// Take file name as a string
			string fileName = Console.ReadLine();
			StreamReader file = new StreamReader(fileName);

			// declaring variables
			int counter = 0;
			string line;
			//creating a list of array with double data type
			List<double> values = new List<double>();

			
			while ((line = file.ReadLine()) != null)
			{
				string pattern = @"#TRANS (\d{4}) {.*} (-?\d*)"; // Example: #TRANS 1630 {} 1.00
				var match = Regex.Match(line, pattern);
				if (match.Success)
				{
					double converted = Convert.ToDouble(match.Groups[2].Value);
					values.Add(converted);
					counter++;
				}
			}
			var sum = values.Sum();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"Total amount {0}", sum);
			Console.ResetColor();

			file.Close();
			Console.WriteLine("There were {0} lines.", counter);
			
			// Suspend the screen.  
			Console.ReadLine();

		}
	}
}
