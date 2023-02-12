using System.Numerics;
using static System.Console;
WriteLine("Vücut Kitle Endeks durumu");
WriteLine($"{KitleEndeks(1.78f, 99.5f)}");
WriteLine($"{KitleEndeks(1.78m, 99.5m)}");
WriteLine($"{KitleEndeks(1.78d, 99.5d)}");
ReadLine(); T KitleEndeks<T>(T _boy, T _kilo) where T : struct, INumber<T>
                                            => _kilo / (_boy * _boy);
