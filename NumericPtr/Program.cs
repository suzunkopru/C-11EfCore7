﻿using static System.Console;

nint intPtrLook = nint.MaxValue;
string nintStr = intPtrLook.ToString("N0");
WriteLine(nintStr);
WriteLine($"{nintStr.Length} karakter içeriyor.");

nuint uintPtrLook = nuint.MaxValue;
string nuintStr = uintPtrLook.ToString("N0");
WriteLine(nuintStr);
WriteLine($"{nuintStr.Length} karakter içeriyor.");
ReadLine();
