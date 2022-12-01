using static System.Console;
const string metin = "Süleyman UZUNKÖPRÜ";
WriteLine(metin is ['S', ..] ? metin : "S ile başlamıyor.");
WriteLine(KarsilastirRO("Süleyman UZUNKÖPRÜ"));
ReadLine();
static bool KarsilastirRO(ReadOnlySpan<char> chr)
    => chr is metin;
