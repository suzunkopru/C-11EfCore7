using LibFuncitons;
using static System.Console;

List<int> lst = new List<int>();
lst.Add(200); 
lst.AddRange(Enumerable.Range(201, 10));
lst.AddRange(Enumerable.Range(241, 10).Where(x=>x%2==0));
Voids.Ciz('-', 40); //Cizgi(40);
WriteLine(string.Join(Environment.NewLine, lst));
Voids.Ciz('-', 40); //Cizgi(40);
WriteLine($"lst.ToArray()[..4] baştan 4 eleman");
WriteLine(string.Join(Environment.NewLine, lst.ToArray()[..4]));
Voids.Ciz('-', 40); //Cizgi(40);
WriteLine($"[lst.Count-5]: { lst[lst.Count-5]}");
Voids.Ciz('-', 40); //Cizgi(40);
WriteLine($"lst[^5]: {lst[^5]}");
WriteLine($"Sum: {lst.Sum()}");
ReadKey();
/*void Cizgi(int kac)
    => WriteLine(string.Concat(Enumerable.Repeat("-", kac)));*/