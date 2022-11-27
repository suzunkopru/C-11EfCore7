using StaticKeyword;
using static System.Console;

Person.Name = "Ahmet";
WriteLine("Ad Alanı: " + Person.Name);
WriteLine("Maaş Alanı: " + (Person.Salary + 500));
WriteLine("İnsan Kaynakları için " +
    "Kuruluş Alanı: " + Person.Enterprise);
ReadKey();
