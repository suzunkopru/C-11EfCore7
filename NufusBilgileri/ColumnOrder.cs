//ReSharper disable All
using System.Collections;
/* IComparer Arayüzü [Sınıf Şablonu, Kabiliyet] (interface), CaseInsensitiveComparer
 * sınıfı (class) için gerekli
 */
using System.Globalization;
//CultureInfo için gerekli. Türkçenin CultureInfo değeri 1055 veya ("tr-TR")
using System.Windows.Forms;
//SortOrder enum, ListViewItem kontrolü için gerekli

namespace NufusBilgileri
{
    public class ColumnSort : IComparer
    /* Sınıf (class) adı: ColumnSort. IComparer Arayüzünü [Sınıf Şablonu, 
     * Kabiliyet] uyguluyoruz (interface implement). Bir Arayüzün [Sınıf 
     * Şablonu, Kabiliyet] uygulanması (interface implement) içindeki gövdesiz
     * metot ve özelliklerin de (methods, properties) uygulanmasını zorunlu kılar. 
     * IComparer Arayüzü (interface [Sınıf Şablonu, Kabiliyet]) public int 
     * Compare(object x, object y) metodunu içeriyor. Bize bu metodu 
     * kendi sınıfımızda yeniden yazıyoruz. Çünkü, arayüz Arayüz [Sınıf Şablonu, 
     * Kabiliyet] içerisindeki gövdesiz metotların içi boştur.
     */
    {
        public int e;
        //Bu değişken ile tıklanan sütunun numarasını saklayacağım..
        public SortOrder sortStatus;
        //Bu değişken sıralama artan, azalan ve yok değerlerini tutacak.
        CaseInsensitiveComparer comparer;
        //Bu sınıfta büyük küçük harf duyarlı bir karşılaştırma yapacağız.
        public int Compare(object x, object y)
        /* IComparer Arayüzü [Sınıf Şablonu, Kabiliyet] (interface) içerisindeki
         * boş metodu dolduruyorum.
         */
        {
            ListViewItem lviSec, lviClone;
            //İki adet ListViewItem olacak. Bir seçilen, diğeri bu seçilenin klonu.
            lviSec = (ListViewItem)x;
            lviClone = (ListViewItem)y;
            /* Seçilen ListViewItem ve klonuna, parametrede sunulan object tipindeki
             * x ve y değişkenlerini gönderiyorum. x ve y değişkenlerinin tiplerini 
             * ListViewItem tipine çevirdim, çünkü x ve y object tipindeydi. Artık
             * object x ve y lviSec, lviClone içinde ve ListViewItem tipindeler.
             */
            comparer = new (new CultureInfo(1055));
            /* Sütunların satır değerlerinin karşılaştırılmasını sağlayan ve büyük, 
             * küçük harfe duyarlı olmayan karşılaştırma yapan
             * CaseInsensitiveComparer metodunun Türkçeye göre çalışabilmesi
             * için new CultureInfo(1055) kodunu yazdım.
             */
            int isBig = comparer.Compare
                (lviSec.SubItems[e].Text, lviClone.SubItems[e].Text);
            /* Artık karşılaştırma başladı ve sonuç int tipli isBig değişkenine
             * aktarılıyor. Burası x ve y değerlerinin, birbirleri ile 
             * karşılaştırılması neticesini döndürüyor. İlk liste sütunları
             * ile klonlanan liste sütun değerlerini karşılaştırıyoruz.
             * x eşit ise y değerine: 0, 
             * x küçük ise y değerinden: -1
             * x büyük ise y değerinden: +1 dönüyor.
             */
            return
                sortStatus == SortOrder.Ascending ? isBig :
                /* Artan sıralama için isBig 1 olarak kullanılıyor. Bu kod 
                 * bloğunda iki ayrı mevzu var. 1-) Sıralamanın artan/azalan olması.
                 * Bunu SortOrder ile kontrol ediyoruz. Bu satır Artan sıralama için.
                 * 2-) x ve y değerlerinin nispeten büyük olma durumu. Bunu isBig
                 * değişkeni ile kontrol ediyoruz.
                 * Böylece bu satır için üç durum var: 
                 * 1-) Sıralama SortOrder.Ascending artan (büyükten-küçüğe) olunca;
                 * 2-) x ve y değerlerinin nispeten büyük olma durumu;
                 * a-) x eşit ise y değerine ise isBig=0 olur. Artan sıralama sürer.
                 * b-) x küçük ise y değerinden isBig=-1 olur. x üste, y alta iner.
                 * c-) x büyük ise y değerinden isBig= 1 olur. y üste, x alta iner.
                 */
                sortStatus == SortOrder.Descending ? -isBig :
                /* Azalan sıralama için isBig -1 olarak kullanılıyor. Bu kod 
                 * bloğunda iki ayrı mevzu var. 1-) Sıralamanın artan/azalan olması.
                 * Bunu SortOrder ile kontrol ediyoruz. Bu satır Azalan sıralama için.
                 * 2-) x ve y değerlerinin nispeten büyük olma durumu. Bunu isBig
                 * değişkeni ile kontrol ediyoruz. Burada dikkat -isBig (eksi). Artı
                 * dönerse -isBig ile -1 olur, eksi dönerse -isBig ile +1 olur. 
                 * Böylece programın büyüklük küçüklük algısını tersine çeviriyoruz.
                 * Böylece bu satır için üç durum var: 
                 * 1-) Sıralama SortOrder.Descending artan (küçükten-büyüğe) olunca;
                 * 2-) x ve y değerlerinin nispeten büyük olma durumu;
                 * a-) x eşit ise y değerine ise -isBig=0 olur. Artan sıralama sürer.
                 * b-) x küçük ise y değerinden -isBig= 1 olur. x alta, y üste çıkar.
                 * c-) x büyük ise y değerinden -isBig=-1 olur. y alta, x üste çıkar.
                 */
                (int)SortOrder.None;
            /* Bu satırda ise sıralama yoksa Artan, Azalan veya Sıralama olmayacak 
             * şeklide bir değer döndürüyorum.
             */
        }
    }
}
