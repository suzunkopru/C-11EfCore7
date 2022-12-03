string Mesaj = """
        Ben Süleyman UZUNKÖPRÜ
        17/11/1976 tarihinde
        İstanbul'da doğdum.
        Alt Satırdan devam ediyorum.
    """;
Console.WriteLine(Mesaj);

var xml = """<? xml version = "1.0" encoding="utf-8"?>""";
string Ad = "Süleyman";
string Soyad = "UZUNKÖPRÜ";
var jsonText =
    $$"""
      {
        "Adı": "{{Ad}} ",
        "Soyadı": "{{Soyad}} "
      }
      """;
Console.WriteLine(xml);
Console.WriteLine(jsonText);
Console.ReadKey();

