using System;
using System.IO;

namespace MDF2015
{
	public class Monopoly
	{
		public Monopoly ()
		{
			for (int i = 1; i < 4; i++) {
				using (var fsi = new FileStream (@"problems/2_Monopoly/input" + i + ".txt", FileMode.Open)) {
					using (var fso = new FileStream (@"problems/2_Monopoly/output" + i + ".txt", FileMode.Open)) {
						solve (fsi, fso);
					}
				}
			}

		}

		private void solve (FileStream fsin, FileStream fsout)
		{
			int caseArrivee=0;
			using (var sr = new StreamReader (fsin)) {
				int startingMoney = Int32.Parse (sr.ReadLine ());
				string[] paiementCase = sr.ReadLine ().Split ();
				string[] jetDeDes = sr.ReadLine ().Split ();
				int nbJet = jetDeDes.Length / 2;
				for (int i = 0; i < nbJet; i++) {
					int des = Int32.Parse (jetDeDes [2 * i]) + Int32.Parse (jetDeDes [2 * i + 1]);
					caseArrivee += des;
					caseArrivee %= 40;
					startingMoney -= Int32.Parse(paiementCase[caseArrivee]);
					if (caseArrivee == 19)
						caseArrivee = 9;
					if (startingMoney < 0)
						break;
				}
			}
			int output=0;
			using (var sr = new StreamReader (fsout)) {
				output = Int32.Parse (sr.ReadLine ());
			}

			Console.WriteLine ("computed arrival is {0}, answer is {1}", caseArrivee +1, output);
		}

	}
}

