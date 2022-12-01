using static System.Console;
Bisiklet bisiklet = new();
WriteLine($"Bisiklet mi: {bisiklet is Bisiklet}");
Motor motor = new();
WriteLine($"Motor Bisiklet midir: {motor is Bisiklet}");
WriteLine($"Bisiklet null mı: {bisiklet is not null}"); //is not örneği
WriteLine($"Bisiklet null mı: {bisiklet == null}"); //is not alternatif
WriteLine($"Bisiklet null mı: {bisiklet == null}"); //is not alternatif
var i = 250;
WriteLine($"i={i} bir int ise y ataması yap, Y bas: {i is int y} => {y}");
ReadKey();
class Bisiklet { }
class Motor{ }
