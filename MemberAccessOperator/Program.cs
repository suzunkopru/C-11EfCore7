using static System.Console;
string[] ulkeler = new string[5];
ulkeler[0] = "Türkiye";
ulkeler[1] = "Libya";
ulkeler[2] = "Azerbaycan";
ulkeler[3] = "Bulgaristan";
ulkeler[4] = "Amerika";
WriteLine($"4.elemanı: {ulkeler[4]}");
string[] iller =
    { "İstanbul", "Ankara", "İzmir", "Bursa", "Rize", "Malatya" };
WriteLine($"0.elemanı: {iller[0]}, 1.elemanı: {iller[1]}, ");
//C# 8.0 Index From End
WriteLine($"iller dizisinin sondan ikinci elemanı: {iller[^2]}");
//C# 8.0 Ranges
WriteLine($"iller dizisinden [..3] eleman:");
WriteLine(string.Join(Environment.NewLine, iller[..3]));
WriteLine($"iller dizisinden [3..] eleman:");
WriteLine(string.Join(Environment.NewLine, iller[3..]));
WriteLine($"iller dizisinden [..] eleman:");
WriteLine(string.Join(Environment.NewLine, iller[..]));
ReadLine();