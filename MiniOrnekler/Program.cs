using static System.Console;
Canli minikKus = new Kus();
//Canli sınıfı tipinde bir Kus sınıfı örneği aldım.
minikKus.SolunumYap();
/* Solunum her canlı için değişebilir. Bu minikKus değişkeni
   bir Canli sınıfı tipinde */
Kus.Uyu();
/* Uyuma metodu ortak sınıftan geldi. Metot statik ve direk
   çağrılabiliyor.*/
Balik minikBalik = new Balik();
WriteLine(nameof(Balik));
minikBalik.SolunumYap();
Balik.Uyu();
ReadLine();
abstract class Canli
{
    public abstract void SolunumYap();
    //Her canlı solunum yapar. Ancak oksijenli veya oksijensiz.
    public static void Uyu() => WriteLine("Uyudum");
    //Her canlı uyur. Bu ortak.
}
class Kus : Canli   //Inheritance (Miras Alma işlemi)
{
    public override void SolunumYap()  //Polymorphism (Çok biçimlilik) 
            => WriteLine("Oksijenli Solunum Yapıyorum.");
    //Kuş Oksijenli Solunum yapıyor.
    private string Gaga { get; set; }   //Encapsulation (Kapsülleme)
}
class Balik : Canli
{
    public override void SolunumYap()
        => WriteLine("Solungaçlı Solunum Yapıyorum.");
}