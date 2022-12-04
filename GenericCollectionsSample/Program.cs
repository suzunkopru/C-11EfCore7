using static System.Console;
Queue<int> sira = new();
sira.Enqueue(1);
sira.Enqueue(2);
sira.Enqueue(3);
sira.Enqueue(3);
WriteLine("Queue<T>");
WriteLine(string.Join("\n", sira));

Stack<int> yigin = new();
yigin.Push(1);
yigin.Push(2);
yigin.Push(3);
yigin.Push(3);
WriteLine("Stack<T>");
WriteLine(string.Join("\n", yigin));

HashSet<int> kume = new();
kume.Add(3);
kume.Add(2);
kume.Add(1);
kume.Add(3);
WriteLine("HashSet<T>");
WriteLine(string.Join("\n", kume));

List<int> liste = new();
liste.Add(3);
liste.Add(2);
liste.Add(1);
liste.Add(3);
WriteLine("List<T>");
WriteLine(string.Join("\n", liste));

SortedSet<int> siraliListe = new();
siraliListe.Add(3);
siraliListe.Add(2);
siraliListe.Add(1);
siraliListe.Add(3);
WriteLine("SortedSet<T>");
WriteLine(string.Join("\n", siraliListe));

SortedList<int, string> siraliIkili = new();
siraliIkili.Add(3, "C");
siraliIkili.Add(2, "B");
siraliIkili.Add(1, "A");
WriteLine("SortedList<T>");
WriteLine(string.Join("\n", siraliIkili));

SortedDictionary<int, string> siraliSozluk = new();
siraliSozluk.Add(3, "C");
siraliSozluk.Add(2, "B");
siraliSozluk.Add(1, "A");
WriteLine("SortedDictionary<T>");
WriteLine(string.Join("\n", siraliSozluk));

Dictionary<int, string> sozluk = new();
sozluk.Add(3, "C");
sozluk.Add(2, "B");
sozluk.Add(1, "A");
WriteLine("Dictionary<T>");
WriteLine(string.Join("\n", sozluk));
ReadLine();

