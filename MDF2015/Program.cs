using System;
//using System.IO;

namespace MDF2015
{
	class MainClass
	{
		public static void Main (string[] args)
		{
//			var problem = new Trivial ();
			var problem = new GenerateurDeSSequences ();
			problem.Solve ();
//			string filename = "problems/1_Trivial-Pursuit/input1.txt";
//			int arrivee = 0;
//			string[] resultat = new string[] {
//			using (FileStream fs = new FileStream (filename, FileMode.Open)) 
//			{
//				using (StreamReader sw = new StreamReader (fs)) {
//					while (!sw.EndOfStream) {
//							arrivee += (Int32)sw.ReadLine();
//					}
//				}
//			}
//			Console.WriteLine (resultat[arrivee]);
//			char c = 'Z';
//			string s = Convert.ToString ((int)c, 2);
//			Console.WriteLine (s);
//			var str = String.Trim.Start (s, '1');
//			Console.WriteLine (str);
			Console.ReadLine();
		}
	}
}
