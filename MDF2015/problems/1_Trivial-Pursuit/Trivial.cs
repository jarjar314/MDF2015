using System;
using System.IO;

namespace MDF2015
{
	public class Trivial
	{
		string[] cases = {"violet", "orange", "jaune", "vert", "rose", "bleu"};

		public Trivial ()
		{
			for (int i = 1; i < 4; i++) {
				using (FileStream fsi = new FileStream (@"problems/1_Trivial-Pursuit/input" + i + ".txt", FileMode.Open)) {
					using (FileStream fso = new FileStream (@"problems/1_Trivial-Pursuit/output" + i + ".txt", FileMode.Open)) {
						solve (fsi, fso);
					}
				}
			}
		}

		private void solve (FileStream fsin, FileStream fsout)
		{
			int road = 0;
			using (StreamReader sr = new StreamReader (fsin)) {
				while (!sr.EndOfStream) {
					road = (road + Int32.Parse (sr.ReadLine ())) % 6;
				}
			}
			string caseArrivee = cases [road];
			string output;
			using (StreamReader sr = new StreamReader (fsout)) {
				output = sr.ReadLine ();
			}

			Console.WriteLine ("computed is {0}, solution is {1}", caseArrivee, output);
		}
	}
}

