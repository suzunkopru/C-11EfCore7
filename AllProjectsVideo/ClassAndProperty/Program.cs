﻿IMotor motor = new Motor();
Write("Özelliklere henüz değer atanmadığı için varsayılan");
WriteLine(" değerler görüntülenir.");
WriteLine("Renk Özelliği: " + motor.Renk);
WriteLine("Vites Sayısı Özelliği: " + motor.VitesSayisi);
WriteLine("Yakıt Cinsi Özelliği: " + motor.YakitCinsi);
Write("Özelliklere değer atandıktan sonra: ");
motor.Renk = Color.DarkCyan;
WriteLine("Renk Özelliği: " + motor.Renk);
motor.VitesSayisi = 6;
WriteLine("Vites Sayısı Özelliği: " + motor.VitesSayisi);
motor.YakitCinsi = "Elektrikli Motor";
WriteLine("Yakıt Cinsi Özelliği: " + motor.YakitCinsi);
motor.Git();
motor.FarYak();
motor.VitesDegis();
motor.Dur();
ReadLine();

