using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MDF2015
{
	public class LeMotLePlusCourant
	{
		public void Solve()
		{
			for (int i = 1; i < 4; i++) {
				using (var fsi = new FileStream (@"problems/6_Le-mot-le-plus-courant/input" + i + ".txt", FileMode.Open)) {
					using (var fso = new FileStream (@"problems/6_Le-mot-le-plus-courant/output" + i + ".txt", FileMode.Open)) {
						Console.WriteLine ("{0} {1}correctly solved.", i, solve (fsi, fso)?"":"in");
					}
				}
			}
		}

		private bool solve(FileStream fsin, FileStream fsout)
		{
			int nbText = 0;
			List<string> result = new List<string> ();
			using (StreamReader sr = new StreamReader (fsin)) {
				while (!sr.EndOfStream) {
					nbText++;
					List<string> tempList = sr.ReadLine ().ToLowerInvariant().Split (' ','\'','.',',').ToList();
					List<string> uniqueList = new List<string> ();
					foreach (var e in tempList) {
						if (string.IsNullOrWhiteSpace (e))
							continue;
						if (!uniqueList.Contains (e))
							uniqueList.Add (e);
					}
					result.AddRange (uniqueList);
				}
			}
			StringBuilder sb = new StringBuilder ();

//			var gr = result.GroupBy (x => x).Where(x => x.Count() < nbText).OrderBy(x=> x.Count());// (x => x.Count () < nbText);
//			int entryprinted = 3;
//			
//			while (entryprinted > 0 && nbText > 0) {
//				nbText--;
//				var gr2 = gr.Where (g => g.Count () == nbText).OrderBy (g => g);
//				foreach (var e in gr2) {
//					sb.AppendLine (nbText + " " + e);
//					entryprinted--;
//					if (entryprinted == 0)
//						break;
//				}
//
//			}
			Dictionary<string, int> dico = new Dictionary<string, int> ();
			foreach (var e in result) {
				if (dico.ContainsKey (e))
					dico [e]++;
				else
					dico [e] = 1;
			}
			nbText--;
			int entryToPrint = 3;
			while (entryToPrint > 0) {
				List<string> listNbText = new List<string> ();
				foreach (var p in dico) {
					if (p.Value == nbText)
						listNbText.Add (p.Key);
				}
				listNbText.Sort ();
				foreach (var s in listNbText) {
					sb.Append (nbText + " " + s + "\\n");
					entryToPrint--;
					if (entryToPrint == 0)
						break;
				}
				nbText--;
			}

			string sformsb = sb.ToString ();
			Console.WriteLine (sb);

			string output = string.Empty;
			using (StreamReader sr = new StreamReader (fsout)) {
				while (!sr.EndOfStream) {
					output += sr.ReadLine ()+ "\\n";
				}
			}
			Console.WriteLine (output);
			return output == sformsb;
		}
	}
}