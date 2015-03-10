using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace MDF2015
{
	public class GenerateurDeSSequences
	{
		public void Solve()
		{
			for (int i = 1; i < 4; i++) {
				using (var fsi = new FileStream (@"problems/7_Generateur-de-S-Sequences/input" + i + ".txt", FileMode.Open)) {
					using (var fso = new FileStream (@"problems/7_Generateur-de-S-Sequences/output" + i + ".txt", FileMode.Open)) {
						Console.WriteLine ("{0} {1}correctly solved.", i, solve (fsi, fso)?"":"in");
					}
				}
			}
		}

		private bool solve(FileStream fsin, FileStream fsout)
		{
			string resultat;
			StringBuilder sb = new StringBuilder ();
			List<string> ls = new List<string> ();
			int debutDeBalise = 0;
			using (StreamReader sr = new StreamReader (fsin)) {
				string sequence = sr.ReadLine ();
				int l = sequence.Length;
				bool newBalise = false;
				bool BaliseFermante = false;
				string balise = string.Empty;
				for (int i = 0; i < l; i++) {
					char current = sequence [i];
					if (current == '<') {
						newBalise = true;
						balise = string.Empty;
						debutDeBalise = i;
						BaliseFermante = false;
					} else if (current == '/') {
						BaliseFermante = true;
					} else if (current == '>') {
						newBalise = false;
						if (!BaliseFermante) {
							ls.Add (balise);
							sb.Append ("(");
							sb.Append (balise);
						} else {
							if (ls [ls.Count - 1] != balise) {
								sb.Clear ();
								sb.AppendFormat ("E {0} {1} {2}", debutDeBalise, balise, ls [ls.Count - 1]);
								break;
							} else {
								sb.Append (")");
								ls.RemoveAt (ls.Count - 1);
							}
						}

					} else {
						balise += current;
					}

				}
			}
			resultat = sb.ToString ();
			Console.WriteLine (resultat);
			string output;
			using (StreamReader sr = new StreamReader (fsout)) {
				output = sr.ReadLine ();
			}
			Console.WriteLine (output);
			return output == resultat;
		}
	}
}

