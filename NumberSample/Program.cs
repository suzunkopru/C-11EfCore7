using System.Numerics;
using static System.Console;
WriteLine($"Kitle Endeksi: {KitleEndeks(_boy: 1.68f, _kilo: 95.5f)}");
WriteLine($"Kitle Endeksi: {KitleEndeks(_boy: 1.78f, _kilo: 95.5d)}");
WriteLine($"Kitle Endeksi: {KitleEndeks(_boy: 1.88m, _kilo: 95.5m)}");
ReadLine();
T KitleEndeks<T>(T _boy, T _kilo) where T : struct, INumber<T>
                                  => _kilo / (_boy * _boy);