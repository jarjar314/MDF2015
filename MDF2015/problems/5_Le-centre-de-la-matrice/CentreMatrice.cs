using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace MDF2015
{
	public class CentreMatrice
	{
		public void Solve()
		{
			for (int i = 1; i < 4; i++) {
				using (var fsi = new FileStream (@"problems/5_Le-centre-de-la-matrice/input" + i + ".txt", FileMode.Open)) {
					using (var fso = new FileStream (@"problems/5_Le-centre-de-la-matrice/output" + i + ".txt", FileMode.Open)) {
						Console.WriteLine ("{0} {1}correctly solved.", i, solve (fsi, fso)?"":"in");
					}
				}
			}
		}

		private bool solve(FileStream fsin, FileStream fsout)
		{
			int dimension;
			int min, max, mode;
			decimal median;
			List<int> listeEntier = new List<int> ();
			using (var sr = new StreamReader (fsin)) {
				dimension = Int32.Parse (sr.ReadLine ()); // dimension de la matrice
				int begin = dimension / 4;
				int end = dimension / 2 + begin;
				for (int i = 0; i < end; i++) {
					string ligne = sr.ReadLine();
					if (i < begin)
						continue;
					string[] ligneSplitte = ligne.Split (' ');
					for (int j = begin; j < end; j++) {
						listeEntier.Add (Int32.Parse (ligneSplitte [j]));
					}
				}
			}
			listeEntier.Sort ();
			min = listeEntier [0];
			max = listeEntier [listeEntier.Count-1];
			median = (listeEntier[listeEntier.Count/2-1] + listeEntier[listeEntier.Count/2])/2.0m;
			var resultGroupBy = listeEntier.GroupBy (x => x);
			int modeMax = 0;
			mode = max+1;
			foreach (var c in resultGroupBy) {
				if (c.Count () > modeMax || (c.Count() == modeMax && c.Key < mode)) {
					mode = c.Key;
					modeMax = c.Count ();
				}
			}
			string resultat = string.Format ("{0} {1} {2} {3}", min, max, median.ToString("F1").Replace(',','.'), mode);
			string output = string.Empty;
			using (var sr = new StreamReader (fsout)) {
				output = sr.ReadLine ();
			}
			Console.WriteLine (resultat);
			Console.WriteLine (output);
			return resultat == output;
		}

	}
}

