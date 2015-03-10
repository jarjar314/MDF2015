using System;
using System.IO;


namespace MDF2015
{
	public class GeometriePlane
	{
		public void Solve()
		{
			for (int i = 1; i < 4; i++) {
				using (var fsi = new FileStream (@"problems/4_Geometrie-plane/input" + i + ".txt", FileMode.Open)) {
					using (var fso = new FileStream (@"problems/4_Geometrie-plane/output" + i + ".txt", FileMode.Open)) {
						Console.WriteLine ("{0} {1}correctly solved.", i, solve (fsi, fso)?"":"in");
					}
				}
			}
		}

		private bool solve(FileStream fsin, FileStream fsout)
		{
			int xMin = Int32.MaxValue, xMax=Int32.MinValue, yMin=Int32.MaxValue, yMax=Int32.MinValue;

			using (var sr = new StreamReader (fsin)) {
				int nbRect = Int32.Parse (sr.ReadLine ());
				for (int i = 0; i < nbRect; i++) {
					string[] rectangle = sr.ReadLine ().Split(' ');
					int x1 = Int32.Parse (rectangle [0]);
					int x2 = Int32.Parse (rectangle [2]);
					int y1 = Int32.Parse (rectangle [1]);
					int y2 = Int32.Parse (rectangle [3]);

					int xi = x1 > x2 ? x2 : x1;	// min x1/x2
					int yi = y1 > y2 ? y2 : y1;	// min y1/y2
					int xa = x1 - xi + x2;		// max x1/x2
					int ya = y1 - yi + y2;		// max y1/y2

					xMin = xMin > xi ? xi : xMin;
					xMax = xMax < xa ? xa : xMax;
					yMin = yMin > yi ? yi : yMin;
					yMax = yMax < ya ? ya : yMax;
				}
			}

			string resultat = string.Format ("{0} {2} {0} {3} {1} {2} {1} {3}", xMin, xMax, yMin, yMax);
			string output = string.Empty;
			using (var sr = new StreamReader (fsout)) {
				output = sr.ReadLine ();
			}
			Console.WriteLine (resultat);
			Console.WriteLine (output);
			return output == resultat;
		}
	}
}

