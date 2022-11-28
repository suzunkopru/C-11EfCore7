﻿using static System.Console;
DateTime dateSample = new DateTime(2022, 11, 27);
DateTime timeSample = new DateTime(2022, 11, 27, 18, 20, 55);
DateOnly dateOnlySample = new DateOnly(2022, 11, 27);
TimeOnly timeOnlySample = new TimeOnly(18, 20);
WriteLine(dateSample);
WriteLine(timeSample);
WriteLine(dateOnlySample);
WriteLine(timeOnlySample);
ReadLine();