using System;
using System.IO;
using System.Text;

namespace MDF2015
{
	public class Compression
	{
		public Compression ()
		{
			for (int i = 1; i < 4; i++) {
				using (var fsi = new FileStream (@"problems/3_Compression/input" + i + ".txt", FileMode.Open)) {
					using (var fso = new FileStream (@"problems/3_Compression/output" + i + ".txt", FileMode.Open)) {
						Console.WriteLine ("{0} {1}correctly solved.", i, solve (fsi, fso)?"":"in");
					}
				}
			}
		}

		private bool solve (FileStream fsin, FileStream fsout)
		{
			StringBuilder sb = new StringBuilder ();
			string input;
			using (StreamReader sr = new StreamReader (fsin)) {
				input = sr.ReadLine ();
				int start = 0;
				char lead = input [0];
				for (int i = 1; i < input.Length; i++) {
					char tmp = input [i];
					if (tmp == lead)
						continue;
					else {
						int count = i - start;
						if (count == 1)
							sb.Append (lead);
						else if (count == 2)
							sb.Append (lead.ToString() + lead); // if char + char -> on somme les ascii !!!
						else
							sb.Append(count + lead.ToString());
						start = i;
						lead = tmp;
					}
				}
				// Handle last chain
				int countend = input.Length - start;
				if (countend == 1)
					sb.Append (lead);
				else if (countend == 2)
					sb.Append (lead.ToString() + lead);
				else
					sb.Append(countend + lead.ToString());
			}

			string compresse = sb.ToString ();

			string output=string.Empty;
			using (StreamReader sr = new StreamReader (fsout)) {
				output = sr.ReadLine ();
			}

			Console.WriteLine ("{0}:{1}=>{2} == {3} ?", output == compresse ? "OK" : "KO", input, compresse, output);
			return compresse == output;
		}
	}
}

