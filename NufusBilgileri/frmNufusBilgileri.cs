using System.Globalization;

namespace NufusBilgileri
{
    internal enum MedeniHal { Evli, Bekar };
    /* Bir �sim Alan� (NameSpace) i�inde k�s�tlay�c� olmadan tan�mlanan Class
     * (S�n�f) veya Struct (Yap�) eri�im k�s�tlay�c�s� belirtilmedi ise varsay�lan
     * olarak Internal (Dahili) olurlar. Bu de�i�ken ise "namespace NufusBilgileri"
     * isim alan�nda tan�mland� varsay�lan� zaten internal.
     */
    enum Cinsiyet { Bay, Bayan };
    public partial class frmNufusBilgileri : Form
    {
        readonly string TarihBicimi = "dd/MM/yyyy";
        /* readonly (sadece okunabilir, veri atanamaz) string tipinde bir tarih
         * format� tan�mlad�m. Bu format sabit, de�i�meyecek. Ba�ka bir yaz�l�mc�
         * veya ben unutarak, bu de�i�kene sonradan atama yapamayaca��m.
         */
        readonly string[] iller = { "Adana", "Ad�yaman", "Afyon", "A�r�",
        "Aksaray", "Amasya", "Ankara", "Antalya", "Ardahan", "Artvin", "Ayd�n",
        "Bal�kesir", "Bart�n", "Batman", "Bayburt", "Bilecik", "Bing�l",
        "Bitlis", "Bolu", "Burdur", "Bursa", "�anakkale", "�ank�r�", "�orum",
        "Denizli", "Diyarbak�r", "D�zce", "Edirne", "Elaz��", "Erzincan",
        "Erzurum", "Eski�ehir", "Gaziantep", "Giresun", "G�m��hane", "Hakk�ri",
        "Hatay", "I�d�r", "Isparta", "�stanbul", "�zmir", "Kahramanmara�",
        "Karab�k", "Karaman", "Kars", "Kastamonu", "Kayseri", "K�r�kkale",
        "K�rklareli", "K�r�ehir", "Kilis", "Kocaeli", "Konya", "K�tahya",
        "Malatya", "Manisa", "Mardin", "Mersin", "Mu�la", "Mu�", "Nev�ehir",
        "Ni�de", "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun", "Siirt",
        "Sinop", "Sivas", "�anl�urfa", "��rnak", "Tekirda�", "Tokat",
        "Trabzon", "Tunceli", "U�ak", "Van", "Yalova", "Yozgat", "Zonguldak" };
        /* readonly (sadece okunabilir, veri atanamaz) string dizisi tipinde illeri
         * i�eren dizimiz var ve bu diziye bir atama yap�lamayacak, hi�bir ilimizin
         * hat�r� kalmas�n diye t�m�n� yazd�m.  Bu illerden birini formdaki Do�um
         * Yeri alan�na rasgele yazaca��m.
         */
        readonly string[] basliklar = {"S.No", "Do�um Tarihi", "Ad Soyad",
            "Do�um Yeri", "Medeni Hali", "Cinsiyet"};
        /* readonly (sadece okunabilir, veri atanamaz) string dizisi  
         * tipindeki kontrol�m�zde ba�l�k olarak kullan�lacak. De�er atamas� 
         * yap�lmayaca�� i�in readonly olarak tan�mlad�m. Ba�ka bir yaz�l�mc�
         * veya ben unutarak, bu de�i�kene sonradan atama yapamayaca��m.
         */
        readonly string[] isimler = { "Ay�e BET�L", "Amine OKUMU�",
            "S�leyman UZUNK�PR�", "Muhammed FAT�H", "Ahmet YAS�N", "Berces M�RDENL�",
            "Mustafa PARLAK", "�mer �REN�", "Burak DEREL�", "Oktay �ENT�RK",
            "Sabri B�RADLI","Hamit G�M��", "�lhan G�M��", "Bekir UZUN",
            "Hamza OKUMU�" };

        /* readonly (sadece okunabilir, veri atanamaz). N�fus bilgileri i�in Rasgele 
         * isimler tan�ml�yorum. Bu isimlerden birini formdaki ad alan�na rasgele 
         * yazaca��m.  Ba�ka bir yaz�l�mc� veya ben unutarak, bu de�i�kene sonradan
         * atama yapamayaca��m.
         */
        ColumnSort columnSort;
        /* Bu isme sahip class (s�n�f) var. Bu class ColumnOrder isim alan�nda. 
         * ListViewColumnSort tipine sahip olacak de�i�kenimin ad�: columnSort 
         * (S�tun S�rala). Bu de�i�keni Public bir alana yazd�m, b�ylece bu class 
         * (s�n�f) i�inden, ba�ka metotlardan da �a��r�labilir (Varsay�lan eri�im 
         * belirteci olan Internal eri�im belirtecine sahiptir).
         */
        public frmNufusBilgileri()
        {
            InitializeComponent();
            /* frmNufusBilgileri form projesinin kurucu metodudur.
             * InitializeComponent metodu ise forma manuel olarak �izilen
             * nesnelerin, �zellikleri, olay metotlar� vb. arkaplanda yazar.
             */
            columnSort = new ColumnSort();
            lViKisi.ListViewItemSorter = columnSort;
            /* S�tun s�ralama i�in yap�lan atama public (genel) bir alanda yap�lmal� 
             * ve ilk �al��an metot olan kurucu metot i�inden atanmal�d�r. B�ylece 
             * ilk s�ralama atamas� null olmam�� olur.
             * S�tunlar�n s�ralanabilmesi i�in ListView kontrol�n�n
             * ListViewItemSorter �zelli�ine de�er atamas� yap�yorum. ColumnSort
             * ad�nda bir class (s�n�f) yazd�m buras� o s�n�f�n bir �rne�ini
             * (instance) al�yor. Listeye yeni bir s�ralama �zelli�i eklemi� oldum.
             * ListView kontrol�nde istedi�imizi yapabilen bir s�ralama tekni�i
             * yoktu, eklemi� oldum. Asl�nda ListView daha �ok imaj nesneleri
             * listelemek i�in kullan�l�yor, bu �rnekte ise veri listeleyece�im.
             * Bir Class yard�m� ile s�ralama nas�l yap�l�r onu anlatmak
             * niyetindeyim. Halbuki DataGridView kontrol�n� kullanabilirdim,
             * s�ralama otomatik yap�l�rd�. O zaman bu kadar �ok �ey anlatamazd�m. 
             */
        }

        private struct KisiBilgi
        /* Yeni bir struct (yap�) tan�ml�yorum. Ad�: KisiBilgi. Ba�ka bir s�n�fta
         * kullan�lmayaca�� i�in eri�im k�s�tlay�c�s� private.
         */
        {
            /* Bu Class i�in tan�mlad���m alanlar (fields) sadece bu s�n�fta
             * kullan�lacak, bu y�zden internal tan�mlamak istedim. G�velik
             * d�zeyleri: internal.
             */
            internal DateTime dTar;
            //Tip: string, Ad: dTar. Bu bir Field (Alan).
            internal string adSyd;
            //Tip: DateTime, Ad: adSyd. Bu bir Field (Alan).
            internal string dYer;
            //Tip: DateTime, Ad: dYer. Bu bir Field (Alan).
            internal MedeniHal medHal;
            /* Tip: MedeniHal enum listesi, Ad: medHal. Bu bir Field (Alan).
             * B�ylece Evli, Bekar se�ene�i listelenebilecek.*/
            internal Cinsiyet cnsy;
            /* Tip: Cinsiyet enum listesi, Ad: cnsy. Bu bir Field (Alan).
             * B�ylece Bay, Bayan se�ene�i listelenebilecek.*/
        }
        private void frmNufusBilgileri_Load(object sender, EventArgs e)
        /* frmNufusBilgileri formunun olay metodu olan Load olay� (event) form 
         * �a�r�ld��� anda bu scope (kapsam) kodlar� �al��acak. B�ylece form
         * y�klenirken �al��t�r�lmas� gereken t�m kodlar� buraya yaz�yorum.
         */
        {
            chkMedeniHal.Text =
                Enum.GetName(typeof(MedeniHal), (int)MedeniHal.Bekar);
            /* Bir enum de�erinin ad�n� alabilmek i�in Enum abstract class 
             * (numaraland�r�lm�� soyut s�n�f) tipinin GetName metodu kullan�labilir.
             * GetName metodu iki parametre al�r (1.Parametre: Type tipinde bir enum 
             * al�r, 2.Parametre: Enum listesinin int de�erini al�r).
             */
            btnSil.Enabled = false;
            /* Form y�klenirken, hen�z n�fus bilgisi olmayaca�� i�in, bu butona 
             * bas�lmas� hataya neden olur. Bu nedenle buton g�r�n�r ama
             * kullan�labilir durumda olmas�n.
            */
            Text = "N�fus Bilgileri";
            /* Asl�nda frmNufusBilgileri formunun Text �zelli�ine atama yapm�� oldum. 
             * bulundu�umuz s�n�f, zaten frmNufusBilgileri s�n�f� oldu�undan this 
             * yazmaya gerek yok. frmNufusBilgileri formunu tan�tan ifade olan 
             * this.Text ifadesi yaz�lmasada olur. 
             */
            ContextMenuStrip menu = new();
            /* �imdi sa� t�klama olay�nda a��lan bir men� tan�ml�yorum. Men�n�n 
             * tipi ContextMenuStrip, ad�: menu. ContextMenuStrip s�n�f�ndan yeni
             * bir instance (�rnek) al�yorum. B�ylece ihtiyac�m�z olan �zellikleri ve
             * metotlar�n� kullanabiliriz.
             */
            menu.Items.Add("Rasgele Ki�i Ekle");
            /* ContextMenuStrip tipindeki men�m�ze bir eleman ekliyoruz. Men� ad�: 
             * Rasgele Ki�i Ekle. Fare sa� t�klan�nca a��ld���nda bu metin g�r�n�r.
             */
            menu.ItemClicked += Menu_ItemClicked;
            /* menu item nesnesine bir olay metodu ekliyoruz. += operat�rlerinden 
             * sonra Tab tu�una bast���m�zda bir t�klama olay metodu olu�uyor. 
             * men� eleman� (item) t�klan�nca �al��acak. Ancak metot, bu scope 
             * (kapsam) d���nda. Menu_ItemClicked olay metoduna indi�imizde 
             * a��klamas�n� yazaca��m.
             */
            ContextMenuStrip = menu;
            /* Men� haz�r ama, daha forma eklenmedi. Formun ContextMenuStrip �zelli�i
             * var, bu �zellik ContextMenuStrip tipinde bir de�i�ken atand���nda, 
             * farenin sa� t�klanmas� ile a��l�r. Bu durumda ContextMenuStrip 
             * tipindeki menu de�i�kenini atad�m.
             */
            mskDogTar.Mask = "00/00/0000";
            /* Tip: MaskedTextBox, Ad�: mskDogTar. �imdi bu, MaskedTextBox kontrol�ne
             * bir giri� maskesi tan�ml�yorum. B�ylece 26.05.2020 �eklinde bir tarih
             * atamas� yap�lmal�. Ancak tarih olmayan 36.55.2020 gibi bir say�da 
             * girilebilir. Bunu tarih atama i�lemi s�ras�nda engelleriz.
             */
            cmbDogYeri.Items.AddRange(iller);
            /* Tip: ComboBox, Ad�: cmbDogYeri olan a��lan kutu kontrol�ne eleman 
             * ekliyorum. AddRange metoduna object[] dizisi tipinde liste g�ndermemiz
             * gerekiyor. Bizim iller adl� bir listemiz var, onu bu metoda g�nderdim.
             * Bizdeki listenin tipi  string[] dizisi.
             */
            lBoxIller.Items.AddRange(iller);
            /* Tip: ListBox, Ad�: lBoxIller olan liste kutusu kontrol�ne eleman 
             * ekliyorum. AddRange metoduna object[] dizisi tipinde liste g�ndermemiz
             * gerekiyor. Bizim iller adl� bir listemiz var, onu bu metoda g�nderdim.
             */
            dteDogTarihi.CustomFormat = TarihBicimi;
            /* Tipi: DateTimePicker, Ad�: dteDogTarihi olan kontrol�m�z i�in, 
             * kullan�c� tan�ml� �zel bir format tan�mlad�m.
             */
            /*�imdi de ListView kontrol�m i�in gerekli ve istedi�im bi�imleri 
             * tan�mlayaca��m.*/
            lViKisi.View = View.Details;
            /* ListView kontrol� G�r�n�m �zelli�i = Detaylar g�r�nt�lensin. B�ylece
             * t�m s�tunlar g�r�n�r hale gelecek. Eklenen veriler alt alta
             * g�r�necek. Aksi halde tek bir s�tun g�r�n�r ve veriler eklendik�e
             * sola, sonra alta ve sonra yine sola tek s�tun olarak eklenir.
             */
            lViKisi.GridLines = true;
            //ListView kontrol�nde �zgara �izgileri g�r�nt�lensin.
            lViKisi.HeaderStyle = ColumnHeaderStyle.Clickable;
            /* ListView kontrol� ba�l��� t�klanabilir olsun.��nk� t�klan�nca
             * s�ralama yap�lmas�n� sa�layaca��m.
             */
            lViKisi.Sorting = SortOrder.Ascending;
            //ListView kontrol� s�ralama artan olacak.
            lViKisi.FullRowSelect = true;
            //Bir sat�r t�klan�nca t�m sat�r� se�ilebilir durumda olacak.

            for (int i = 0; i < basliklar.Count(); i++)
            /* Listenin ba�l�klar� i�in bir dizi tan�mlam��t�k. O dizinin 
             * elemanlar�n� say�yorum ve d�ng�m�n son noktas�n� tespit ediyorum.
             * Bu d�ng� ile Listeye ba�l�klar�n yaz�lmas�n� sa�layaca��m.
             */
            {
                ColumnHeader columnHeader = new();
                //Tip: ColumnHeader, Ad�: columnHeader, yeni bir �rnek al�yorum.
                columnHeader.Text = basliklar[i];
                /* ColumnHeader tipindeki columnHeader adl� de�i�kenin Text 
                 * �zelli�ine ba�l�klar dizisinin elemanlar�n� g�nderiyorum. B�ylece
                 * ba�l�k de�erleri olu�uyor.
                 */
                lViKisi.Columns.Add(columnHeader);
                /* columnHeader de�i�kenine s�tun ekle, eklenen s�tunun tipi 
                 * ColumnHeader oldu�undan liste ba�l��� olu�ur.
                 */
            }

            lViKisi.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            /* lViKisi listemin s�tun geni�liklerini otomatik olarak ayarl�yorum.
             * geni�lik ba�l��a g�re otomatik ayarlanacak.
             */
            txtAdSoyad.Focus();
            /* Kullan�c� program� a�t���nda ad ve soyad bilgisini hemen girebilsin.
             * Bir de metin kutusunu t�klamas�n diye, imleci bu kontrole odaklad�m.
             */
        }
        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {/* Men�n�n tipi ContextMenuStrip, ad�: menu olan men�m�m item eleman�na 
          * bir t�klama olay� atad�m. B�ylece men� item eleman�na t�kland���nda 
          * bu olay metodu �al��acak.
          */
            {
                /* Ki�ilerin verilerini her seferinde manuel se�erek girmektense
                 * rasgele atamalar yapmak i�in bu kodlar� yazd�m. B�ylece algoritma 
                 * yetene�inin ve analitik d���nebilme yetisinin geli�tirilmesini
                 * hedefliyorum.
                 */
                Random rnd = new();
                /* Random s�n�f�ndan bir instance (�rnek) al�yorum. Bu metot rasgele
                 * say� �retecek. Hen�z �retmeye ba�lamad�. Sadece haz�r.
                 */
                int yil = DateTime.Today.Year;
                int yilRnd = rnd.Next(yil - 40, yil - 18 + 1);
                /* Do�um tarihlerinin y�l de�eri i�in bu y�l de�erinden 40
                 * ��kar�yorum. Bu de�er Random s�n�f�n�n Next metodunun ilk
                 * parametresine sunuluyor. 18 ��kar�yorum bu de�er de ikinci
                 * parametre.  B�ylece 18 ya��ndan 40 ya��na kadar do�um tarihleri
                 * �retilecek. Mesela 2020 y�l� i�in 2020-40=1980 ve
                 * 2020-18 + 1 = 2002 tarihleri aras�nda  de�er �retilecek son
                 * de�erin kendisi dahil edilmiyor.
                 */
                int ay = rnd.Next(1, 12 + 1);
                /* 12 ay i�in 1, ile 12 aras�nda de�er �retmek i�in +1 ekliyorum.
                 * Niye 13 yazmad�m da 12 + 1 yazd�m? Ak�lda kal�c� olsun diye.
                 * �imdi 2020-18 i�in 2002,12 gibi iki de�er olu�tu. Bu de�er y�l 
                 * ve ay bilgisidir.
                 */
                int ayinSonGunu = DateTime.DaysInMonth(yilRnd, ay);
                /* G�n bilgisi biraz daha kar���k. Program�n aylar�n son g�nlerine 
                 * tak�lmadan ilerlemesi laz�m. Mesela 30/02 �eklinde bir tarih
                 * olmaz. Bu durumda �nce ay�n ka� �ekti�ini bulmam�z laz�m. B�ylece
                 * rasgele �retilen de�er, ay�n son g�n de�erine kadar �retilsin. 
                 */
                int gun = rnd.Next(1, ayinSonGunu + 1);
                /* Ay de�eri ay�n 1'i ile son g�n� aras�nda �retilsin. B�ylece 
                 * 17.12.2002 gibi bir do�um tarihi olu�uyor. Her olu�an tarih 
                 * di�erinden farkl�. Ayn� gelme ihtimali de var tabi.
                 */
                int dogYer = rnd.Next(0, iller.Length);
            /* Do�um yeri de rasgele olu�sun. T�m illeri yazd���m bir dizi var. 
             * Dizinin ad� iller. Dizinin ilk de�eri 0. de�erdir. Nedense C# (di�er
             * diller de b�yle g�rd�m) ilk de�er 0. de�er oluyor. �ller dizisinin
             * uzunlu�u 81. Burada di�erleri gibi +1 yazmad�m, neden? ��nk�, 0. 
             * eleman ile 80. eleman aras�nda de�er �retilirse 81 il i�in s�ra 
             * numaras� �retilmi� olacakt�r.
             */
            geri:
                /* Bu goto d�ng�s�n�n etiketi. goto d�ng�s� �arta g�re bu sat�ra
                 * d�ner. Bu blo�u yeniden �al��t�r�r. Tabii ki �art goto d�ng�s�nde
                 * �art yoksa s�rekli bu sat�ra d�nece�i i�in program bu ad�m�
                 * ge�emez. goto d�ng�s�nde �art eklemeyi unutmamak gerekir. Buras�
                 * d�ng�n�n d�nece�i nokta, nereden ve hangi �artlar ile d�nece�i
                 * ileriki sat�rlarda olacak.
                 */
                int isim = rnd.Next(0, isimler.Length);
                //Buras� da isimler dizisi i�in eleman s�ra numaras� �retecek.
                foreach (ListViewItem item in lViKisi.Items)
                /* Bu d�ng�n�n yaz�lma amac�, ayn� isme sahip ki�ilerin listeye
                 * yeniden eklenmesini engellemek. ListView kontrol�n�n liste
                 * elemanlar�n�n tipi ListViewItem, bu tip d�ng� de�i�keninin tipi.
                 * Elemanlar ise lViKisi adl� ListView kontrol�n�n, items
                 * de�erlerinde. B�ylece ListViewItem tipli bir de�i�ken olan item,
                 * ListView sat�rlar�nda d�necek ve her d�n���nde bir adet liste
                 * sat�r�n� i�erecek. Ancak bu liste sat�rlar� isim verisini
                 * i�ermeyen s�tunlar� da kapsar.
                 */
                {
                    int adStn = Array.IndexOf(basliklar, "Ad Soyad");
                    /* ListView kontrol�nde olu�turdu�um "Ad Soyad" s�tununu
                     * buluyorum. Sonra bu s�tunda arama yapaca��m. Array s�n�f�n�n
                     * IndexOf metodu iki parametre al�r ve geriye int tipinde bir
                     * de�er d�nd�r�r.
                     * 1. Parametresi: Hangi dizide arama yapacak bunu ister.
                     * 2. Parametresi: Dizide aranacak eleman� ister. Bulunca,
                     * buldu�u eleman�n ka��nc� eleman oldu�unu d�nd�r�r. "Ad Soyad"
                     * diziye g�re 0.1.2. s�tunda (normalde 3. s�tunda). Aranan
                     * de�er yok ise -1 d�ner.
                    */
                    if (item.SubItems[adStn].Text == isimler[isim])
                    //1. if merdiveni
                    /* E�er ad soyad yazan s�tundaki metin e�it ise isimler dizisinin 
                     * isim eleman�na. Yani; veriyi bulduysan bu if blo�una gir.
                     * B�ylece ayn� isim zaten kaydedilmi� demektir.*/
                    {
                        if (lViKisi.Items.Count == isimler.Count())
                        //2. if merdiveni
                        /* ListView kontrol�nde elemanlar� say, isimler dizisindeki 
                         * elemanlar� da da say, e�it ise. E�er listedeki ki�i say�s� 
                         * ile isimlerdeki ki�i say�s� ayn� ise bu if blo�una gir. 
                         * Yukar�da da ayn� isim var m� kontrol ediliyor. 
                         * E�er bu kod blo�u olmasa s�rekli isim eklenmeye �al���l�r.
                         * ��nk�, yukar�daki if ayn� isim var m� bak�yor, diyelim ki 
                         * ayn� isim yok ekliyor. Dizideki isimler bitince ne olacak?
                         * ��te bu if blo�u da eklenen eleman say�lar�na bak�yor ve 
                         * dizideki elemana ula��nca bu blo�a giriyor. */
                        {
                            MessageBox.Show("Eklenebilecek isimlerin t�m� bitti.");
                            return;
                            /* Eklenecek eleman kalmay�nca bundan sonraki kodlar� 
                             * �al��t�rmamam gerekti�i i�in return ile scope (kapsam�)
                             * sonland�rd�m.
                             */
                        }//2. if merdiveni kapsam (scope) biti�i.
                        goto geri;
                        /* Buras� geri etiketine d�n�lmesini sa�layan bir d�ng�.
                         * 1. if merdiveni i�in �al���yor. Eklemeye �al���lan isim
                         * varsa geri etiketine d�n�lecek. Eklenecek sat�r
                         * kalmad���nda ise 2. if merdiveni return ile kapsam�
                         * (scope) sonland�r�yor.
                         */
                    } //1. if merdiveni kapsam (scope) biti�i.
                }//foreach (ListViewItem item in lViKisi.Items) d�ng�s� bitti.

                KisiBilgi kisiBilgi = new();
                /* Hat�rlarsan�z KisiBilgi ad�nda bir struct tan�mlam��t�k. �imdi bu 
                 * yap�ya (struct) de�er atamas� yapaca��m. Sonra bu de�erleri
                 * ListView kontrol�ne aktaraca��m.
                 */
                kisiBilgi.dTar = new DateTime(yilRnd, ay, gun);
                /* KisiBilgi struct tipindeki kisiBilgi de�i�kenimizin dTar
                 * �zelli�ine (bu �zellik DateTime tipindeydi) bir do�um tarihi
                 * atamas� yap�yoruz. Buradaki new DateTime struct * (yap�s�n�n)
                 * bir �rne�i (instance). Yil, ay ve g�n de�erleri ile yeni bir
                 * DateTime olu�uyor. Hat�rlatmak gerekirse, Yil, ay ve g�n
                 * de�erleri rasgele (random) olu�uyordu.
                 */
                kisiBilgi.adSyd = isimler[isim];
                /* KisiBilgi struct tipindeki kisiBilgi de�i�kenimizin adSyd
                 * �zelli�ine (bu �zellik string tipindeydi) bir isim atamas�
                 * yap�yoruz. Burada sadece �rne�in zenginle�mesi i�in bir �ok
                 * algoritmik �rnek eklemek ad�na b�yle kodlar yazd�m. Yoksa,
                 * zaten kullan�c� forma manuel girdi�i veriyi ekle butonu ile
                 * ekleyebilir. Hat�rlatma: Bir dizimiz vard� ad�: isimler,
                 * bu dizinin elemanlar�nda 1.2.3. gibi bir eleman� �a��rabiliriz.
                 * Bende rasgele bir ismi kisiBilgi de�i�kenimizin adSyd 
                 * �zelli�ine atad�m.
                 */
                kisiBilgi.dYer = lBoxIller.Text = iller[dogYer];
                /* Do�um yeri �zelli�ine ve �lleri listeledi�imiz lBoxIller adl� 
                 * ListBox kontrol�ne atama yapaca��m. Atama ayn� veriyi
                 * i�erece�inden bir kontrol�n bir �zelli�ini di�erine e�itledim
                 * ve iller dizisinden do�um yeri olarak rasgele bir ili her iki
                 * �zelli�e ayn� anda atad�m.
                 */
                mskDogTar.Text = dteDogTarihi.Text =
                    kisiBilgi.dTar.ToString(TarihBicimi);
                /* KisiBilgi struct tipindeki kisiBilgi de�i�kenimizin dTar
                 * �zelli�ine bir do�um tarihi atamas� yapm��t�k. �imdi de bu
                 * do�um tarihini her iki kontrol�m�ze birden g�nderiyoruz.
                 * 1. kontol: MaskedTextBox tipinde mskDogTar ve 2. kontol:
                 * DateTimePicker tipinde dteDogTarihi nesneleridir. Bu iki
                 * kontrol�n de Text �zelli�i mevcut, bu nedenle veriyi g�nderirken
                 * string tipine �evirmem gerekli oldu. Peki ToString metodunun
                 * i�indeki (TarihBi�imi) ne anlama geliyor? Kodlar�m�z�n en
                 * ba��nda public bir de�i�kenimiz vard�, de�er atamayaca��z,
                 * sadece okuma i�lemi yapaca��z (readonly) demi�tik, i�te o
                 * de�i�ken. Peki de�eri ne idi? ("dd/MM/yyyy") 28.05.2020 
                 * gibi bir format� ifade ediyor. Neden ToString("dd/MM/yyyy") 
                 * yazmad�m da, bu de�eri bir de�i�kene alarak kulland�m? Birden 
                 * fazla kullanaca��n�z herhangi bir veriyi, bir de�i�ken vas�tas� 
                 * ile kullanman�z� �neririm. B�ylece bir d�zeltme/de�i�iklik 
                 * gerekti�inde sadece de�i�ken atamas� yap�lan  sat�r�
                 * d�zeltirsiniz, t�m ToString(TarihBi�imi) formatlar� d�zelir.
                */
                txtAdSoyad.Text = kisiBilgi.adSyd;
                //TextBox tipindeki txtAdSoyad kontrol�ne adsoyad bilgisini yaz�yoruz.
                cmbDogYeri.Text = kisiBilgi.dYer;
                //ComboBox tipinde cmbDogYeri kontrol�ne Do�um yerini yazd�k.
                rdbBayan.Checked = isim <= 1;
                /* RadioButton tipindeki rdbBayan kontrol�n�n bool tipinde de�er alan 
                 * Checked �zelli�i true veya false olabilir. Bende ��yle yazd�m isim 
                 * de�i�keni k���k veya e�it mi 1'e (isimler dizisinin 0. ve 1. 
                 * elemanlar� bayan oldu�u i�in) �art kar��lan�yor ise true d�ner, 
                 * isimler dizisinin 0. ve 1. elemanlar� i�in bayan RadioButton 
                 * kontrol� i�aretli olur.
                 */
                rdbBay.Checked = isim > 1;
                /*E�er isimler dizisinin 0. ve 1. elemanlar� de�ilse bay RadioButton
                 * kontrol� i�aretli olur. ��yle de yazabilirdik: 
                 * rdbBay.Checked= !rdbBayan.Checked
                 * �nce bayan m� kontrol� yap�ld��� i�in bir sonu� ��kard� bayan ise
                 * true olurdu, bu kontrolde bayan i�in yap�lan kontrol�n tam tersi
                 * false olurdu. false olsa idi, bu RadioButton kontrol� de
                 * true olurdu.
                 */
                btnEkle_Click(null, null);
                /* En sevmedi�im kod yaz�m �ekli buton alt� kod yazmak. Yani; bir 
                 * kontrol�n alt�na kod yaz�lmaz, sadece metot �a�r�l�r, bunu 
                 * �zellikle yazd�m. Tabii ki, i�lemler formun load olay�ndaki gibi 
                 * de�ilse. Zorunlu olmayan kural �udur: Bir kod blo�u metoda 
                 * �evrilebiliyorsa metot olarak yaz�l�r ve ihtiya� olan yerlerde 
                 * �a�r�l�r. Bir metottaki kod ba�ka bir metotta da yaz�l�yor ise,
                 * ikinci kez yaz�lan kod metoda �evrilir ve di�er iki metottan 
                 * �a�r�l�r. Sadece �rnek olsun diye bir butonun alt� kod blo�una 
                 * ihtiyac�m�z oldu�unda nas�l �a�r�lmal� bunu g�stermi� oldum. 
                 * Burada buton kontrol�n�n t�klama olay�n� �a��rd�m, sender ve
                 * e parametrelerine null g�nderdim, sadece i�indeki kod blo�unun
                 * �al��mas� yeterli olacak.
                 */
            }
        }
        int adStn;
        //Ad s�tunun hangisi oldu�unu saklayan de�i�ken bir ka� yerde kullan�lacak.
        private void btnEkle_Click(object sender, EventArgs e)
        {
            bool bosmu;
            /* Kullan�c�n�n doldurmas� gereken, bo� kontrol var m� bakaca��m i�in
             * bool tipinde bir de�i�ken tan�mlad�m.
             */
            BosNesneKontrol(out bosmu);
            /* Bir metodum var, dolmas� gerekti�i halde bo� b�rak�lan bir nesne 
             * var m� kontrol ediyor. out parametresi ile d��ar� bo� olan nesne 
             * varsa true, yoksa false g�nderiyor.
             */
            if (bosmu) return;
            /* E�er dolmas� gerekti�i halde bo� b�rak�lan bir kontrol varsa olay 
             * metodu sonland�r�lacak.
             * Olay metodu sonlanmaz ise alt sat�rdan devam edilecek.
             */
            string cinsiyet = Cinsiyeti();
            /* rdbCinsiyet butonuna g�re, cinsiyet bilgisini d�nd�ren metodumuzu
             * �a��r�yoruz
             */
            DateTime tarih;
            /* DateTime yap�s�n�n TryParse metodu ile, MaskedTextBox tipindeki
             * do�um tarihi kontrol�n�n Text �zelli�ini kontol edip sonu� true ise
             * de�eri bu de�i�kene ataca��m.
             */
            bool tarihMi = DateTime.TryParse(mskDogTar.Text, out tarih);
            /* MaskedTextBox tipindeki do�um tarihi kontrol�ne, tarih girildi ise 
             * tarihMi de�i�keni i�in true d�ner, true d�ner ise girilen tarih
             * de�eri d��ar� aktar�l�r.
             */
            if (!tarihMi)
            /* tarihMi de�i�keni true de�ilse, yani false ise ve tarih olarak 
             * girilmedi ise 35/18/2020 gibi ise;
             */
            {
                MessageBox.Show
                    ($"{mskDogTar.Text} ge�erli de�il.",
                    "Do�ru bir tarih bi�imi girmelisiniz.");
                /* MaskedTextBox kontrol�ndeki de�eri )35/18/2020 gibi) ve
                 * mesaj� g�r�nt�le.
                 */
                return;
                //Olay metodunu sonland�r. Sonlanmad� ise alt sat�rdan devam edilir.
            }
            string[] lists =
                {string.Empty, tarih.ToString(TarihBicimi),  txtAdSoyad.Text.Trim(),
                cmbDogYeri.Text, chkMedeniHal.Text, cinsiyet};
            /* En sonunda veriyi aktarmak i�in gerekli kod sat�rlar�na gelebildik. 
             * Her sat�r hata kontrol kodlar� ile dolu. Daha bir bu kadar, hata 
             * kontrol� gerekiyor, ancak sadece en m�him olanlar�n� yazd�m. Bir
             * dizi haz�rl�yorum. aktar�lacak elemanlar� diziye aktard�m. Her bir
             * s�tun ba�l���na g�re olmas� gereken veri s�ras�nda. �lk de�er bo�,
             * oraya s�ra numaras� eklemek i�in bo� b�rakt�m. Sonra do�um tarihi
             * ad soyad, medeni hal ve cinsiyet bilgileri var.
             * Trim() metodu metnin sonundaki ve ba��ndaki bo�luklar� k�rpar.
             */
            ListViewItem lvItem = new(lists);
            txtAdSoyad.Text = txtAdSoyad.Text.Trim().Replace("  ", " ");
            /* ListView kontrol�n�n her bir sat�r� ListViewItem tipindedir. lvItem
             * de�i�kenim i�in bir instance (�rnek) al�yorum. B�ylece bu de�i�kene 
             * string[] lists dizisini aktard�m. Buraya dikkat ediniz. lists Dizisi
             * aktar�l�yor. Yani ListView verileri de�il. ListView sat�rlar� hen�z
             * dolmad�. �nce kontrol edelim, kullan�c� ayn� ismi bir daha ekliyor 
             * mu? E�er ayn� ismi eklemiyor ise ise Liste kontrol�me aktar�ls�n.
             * Ad Soyad verisini aktar�rken, Trim metodu ile sa� ve sol d��tan
             * olabilecek bo�luklar� kald�rd�m. En sonda da kullan�c�, gereksiz yere
             * iki bo�luk eklemi� ise tek bo�luk ile de�i�tirdim. Baz� kullan�c�lar
             * bir metin yazar ve nedensiz yere iki defa space tu�una basar. S�rf
             * bu bo�luk tu�u y�z�nden arad���n�z metni, ayn� veriyi araman�za
             * ra�men bulamayabilirsiniz, ��nk�; B,r aram komutunda Ali  Gel metni
             * ile Ali Gel metni ayn� de�ildir.
             */
            if (lViKisi.Items.Count > 0)
            {/* ListView kontrol� olan lViKisi nesnesindeki elemanlar�n say�s� 
              * > 0'dan. Alt sat�rdaki d�ng�ye girilir.
              */
                foreach (ListViewItem item in lViKisi.Items)
                /* Bu d�ng� ile ListViewItem tipindeki d�ng� de�i�kenim olan item
                 * d�ng� de�i�kenine lViKisi adl� liste kontrol�m�n verilerini
                 * aktar�yorum. B�ylece, eklenen isim daha �nce
                 * eklenmi� mi bakabilirim.
                 */
                {
                    adStn = Array.IndexOf(basliklar, "Ad Soyad");
                    /* ListViewItem tipindeki d�ng� de�i�kenim olan item liste 
                     * kontrol�ne �nceden eklenen bir sat�r varsa o sat�r�n t�m�n�
                     * i�eriyor. Ancak, bize sadece ayn� isim soyisim var m� o laz�m. 
                     * B�ylece basliklar adl� dizide ad soyad ba�l���na sahip s�tunu 
                     * buluyorum. Asl�nda s�tunun 0.1.2. s�tun oldu�unu biliyorum. 
                     * Ancak, ileride s�tunun yerini de�i�tirirsem, 2. s�tundan 
                     * �nceye bir s�tun eklersem program �al��maya devam etsin 
                     * istedi�im i�in IndexOf metodunun 2. parametresin s�tun
                     * ad�n� "Ad Soyad" yaz�yorum.
                     */
                    if (item.SubItems[adStn].Text == txtAdSoyad.Text)
                    /* E�er d�ng� de�i�keni Alt elemanlar�ndan olan [adStn 
                     * de�i�kenindeki] de�er (�u anda 2 ��k�yor) metni e�it ise,
                     * liste kontrol�ndeki ad soyad metin kutusundaki metne �unlar�
                     * yap: (Yani; Eklenen isim var ise).
                     */
                    {
                        Color sakla = item.BackColor;
                        /* Sat�r�n eski rengini sakla, ��nk� bu sat�r� 
                         * renklendirece�im, sonra yine eski rengine d�nmesini 
                         * istiyorum.
                         */
                        item.BackColor = Color.Gold;
                        /* item de�i�keninin arka plan rengini belirle = Bir metot 
                         * �a��r ad�: RgbRenkUret rengi o metot belirlesin. */
                        MessageBox.Show($"{txtAdSoyad.Text} zaten ekli");
                        //Eklemye �al���lan ad� ve di�er mesaj� g�ster.
                        item.BackColor = sakla;
                        /* item de�i�keninin arka plan rengini saklad���n ilk hali
                         * olan sakla de�i�kenindeki renge d�nd�r.*/
                        return;
                        //btnEkle olay metodunun t�m�nden ��k. Yani; ekleme yapma.
                    } //Eklenen ad soyad metni var ise �al��an if blo�u sonu.
                } //foreach scope (kapsam) biti�i.
            } //lViKisi.Items.Count > 0 yaz�lan if scope (kapsam) biti�i.
            /*if (lViKisi.Items.Cast<ListViewItem>().Where
                (x => x.SubItems[adStn].Text.Contains(txtAdSoyad.Text)).Count()> 0)*/
            /* Bu kadar sat�r kod (foreach (ListViewItem item in lViKisi.Items) 
             * d�ng�s�) yerine LINQ, Lambda Expression ifadesinin kod  sat�r�n� 
             * yazman�z yeterli olur. Yani; lViKisi kontrol� elemanlar�n� 
             * Cast et <ListViewItem tipine �evir> (ve metot parantezlerini kapat)
             * .Where ile Ko�ul bildiriyorum (ListViewItem.SubItems[ad s�tunu] 
             * de�erine bak) txtAdSoyad kontrol�nde yazan metin, ListViewItem 
             * tipindeki x de�i�keninde var m�? Sonra ��kan sonucu say > 0 
             * s�f�rdan b�y�k m�? Yani Ad soyad de�eri listede var m�? Var ise
             * .Count de�eri s�f�rdan b�y�k ��kar. if i�in true de�eri d�ner.
             * De�ilse false d�necektir. K�saltma derken arkaplan rengi kodlar� 
             * ve return ifadesini de eklemeniz gerekiyor. Ben her iki yaz�m
             * �eklini de anlatm�� olay�m.
             */
            lViKisi.Items.Add(lvItem);
            /* E�er t�m return ifadelerinden ge�erse veriyi eklesin. Veri lvItem
             * de�i�keninde.
             */
            BackColor = RgbRenkUret();
            /* Sadece Forma bir arkaplan nas�l eklenir, bunu anlatmak i�in bir renk 
             * atamas� yapan metot kulland�m.
             */
            foreach (Control item in pnlGrup.Controls)
            /* Bu d�ng�de form kontrollerinde nas�l d�n�l�r buna �rnek olsun. Sadece
             * kontrol etmek istedi�im kontrolleri �zerinde rahat�a d�nebilmek i�in
             * forma bir panel ekleyip, bo� kontrol� yapmak istedi�im nesneleri bu 
             * panele ald�m. B�ylece Control tipindeki item de�i�kenim, Panel 
             * kontrol�n�n i�indeki kontrollerde d�necek. E�er pnlGrup. olmasa idi 
             * t�m kontrollerde d�nerdi ki, bu �u anki durumda i�imize yaramazd�.
             */
            {
                item.BackColor = RgbRenkUret();
                /* Kontrollere arkaplan rengi ata = Otomatik renk �reten metodu
                 * �a��r.
                 */
            }//Formun arkaplan� ve panel kontrol�ndeki nesnelerin arkaplan� ayn� renk.
            if (lViKisi.Items.Count % 2 != 0) lvItem.BackColor = RgbRenkUret();
            /* Burada da bir renk atamas� var, ancak bir sat�r renksiz, bir sat�r 
             * renkli olacak. Her tek sat�r beyaz, �ift sat�r farkl� renk olur.
             */
            btnSil.Enabled = lViKisi.Items.Count > 0;
            /* Listeden ki�i silmek i�in, ListView kontrol�nde eleman olmas� gerekir.
             * Form y�klenirken, i�inde eleman olmayaca�� i�in, Silme butonu pasif
             * olarak ayarlan�yor. Eklendik�e de aktif olmas�n� sa�l�yorum. ��yle
             * ListView kontrol� olan lViKisi elemanlar�n� say > b�y�k m� s�f�rdan,
             * e�er s�f�rdan b�y�k ise btnSil.Enabled = true olur, b�ylece butona
             * t�klanabildi�i i�in silme i�lemi yapan kod blo�u �al��abilir.
             */
            if (lViKisi.Items.Count > 6)
            /* Listenin formdaki eleman adedi, 6. Eleman eklendik�e eleman adedi
             * a��l�yorsa formun ve listenin y�ksekli�ini bir liste sat�r� kadar
             * art�rmak istiyorum. 15 eleman�m�z var, ayn� veriyi tekrar eklemeyen
             * bir kod yazd���m�zdan, liste ve form y�ksekli�i en fazla 9 eleman
             * kadar daha artar. Yani; From ve listemiz a��r� b�y�mez.
             */
            {
                int rowH = lViKisi.Height / lViKisi.Items.Count;
                /* ListView kontrol�nde sat�r y�ksekli�i �zelli�i yok. Bende listenin
                 * y�ksekli�ini, i�eri�indeki eleman say�s�nda b�ld�m, yakla��k bir
                 * sat�r y�ksekli�i elde ettim. 
                 */
                lViKisi.Height += rowH;
                //Liste y�ksekli�ini art�rd�m.
                Height += rowH;
                //Formun y�ksekli�ini art�rd�m.
            }
            SatirNo(lViKisi);
            /* lViKisi.Items.Add(lvItem) kodu ile elemanlar� listeye eklemi�tim. 
             * Hat�rlarsan�z ilk s�tun string.empty olarak atanm��t�, s�tuna
             * numara atamas� yapan metot yazm��t�m, onu �a��rd�m. numara atamas�
             * yapan metodu alt sat�rda inceleyece�iz. Bu metot parametre
             * olarak ListView kontrol� al�yor.
             */
        }
        public Color RgbRenkUret(byte i = 230, byte j = 250)
        /* Bu metot geriye Color tipinde de�er d�nd�r�yor. Ad�: RgbRenkUret. 
         * Parametre olarak byte tipinde i ve j adl� iki de�i�ken al�yor. Bu 
         * aral�klarda renk �retecek, RGB 230,250 aras�ndaki renkler flu ve
         * ho� duruyor, bu y�zden parametreye 230,250 de�erlerini g�nderdim.
         * E�er kullan�c� parametre g�ndermezse renkler bu aral�kta �retilecek.
         * Renk aral�klar� 0,255 aras�nda oldu�u i�in byte tan�mlad�m.
         */
        {
            Random rnd = new();
            /* Random s�n�f�ndan bir instance (�rnek) al�yorum. Bu metot rasgele
             * say� �retecek. Hen�z �retmeye ba�lamad�. Sadece haz�r.
             */
            return Color.FromArgb
                (rnd.Next(i, j + 1), rnd.Next(i, j + 1), rnd.Next(i, j + 1));
            /* Renklerin K�rm�z�, Ye�il ve Mavi de�eri i�in renk kodu �retece�im. 
             * Random s�n�f� tipindeki rnd de�i�keninin Next metodu ile i ve j
             * de�erleri aras�nda bir renk kodu �retiliyor, bu kod; opsiyonel
             * parametreden dolay� 230,250 aras�nda olabilir. Tabii ki metoda 
             * parametre olarak farkl� bir i ve/veya j de�eri g�nderilmezse.
             * +1 niye yazd�m? Random �retilen say�larda, parametreye sunulan 
             * ikinci say�n�n kendi de�erine kadar �retildi�i, dahil olmad���
             * konusuna dikkat �ekmek istiyorum. B�ylece tahminen ��yle bir de�er
             * olu�acak. Color color = Color.FromArgb(235, 240, 250)
             */
        }
        public void SatirNo(ListView lvi)
        /* Bu metot void (de�er d�nd�rmez). Parametre olarak ListView tipinde bir
         * de�i�ken al�yor.
         */
        {
            int sno = Array.IndexOf(basliklar, "S.No");
            /* int tipinde sno de�i�enine atama yap�yorum. Array s�n�f�n�n IndexOf 
             * metodu ile arad���m veriyi i�eren Dizi eleman�n�n numaras�n� alaca��m.
             * B�yle S�ra No s�tununa S�ra Numaras� yazabilece�im.
             */
            int sayac = 0;
            /* foreach d�ng�s�nde, for d�ng�s�ndeki gibi d�ng� sayac� yoktur. D�ng�de 
             * sat�r numaras�n� yazabilmek i�in bir saya� laz�m olacak, d�ng� i�inde
             * ++sayac yazaca��m i�in, d�ng�n�n her d�n���nde 1,2,3 �eklinde artacak.
             * ++sayac yazd���mda sayac �nce artaca�� i�in, ilk de�eri 1 olacak.
             * Bu konuyu Aritmetiksel ��lem �nceli�i ba�l���nda i�lemi�tim. ��yle
             * yazm��t�m: De�i�kene de�er atanmadan �nce art�r�m/azalt�m i�lemi. 
             * �rnek: ++x , --x. �imdi bu bilgi laz�m oldu.
             */
            foreach (ListViewItem item in lvi.Items)
            /* ListViewItem tipindeki d�ng� de�i�kenimizin ad�: item. item de�i�keni
             * parametresine sunulan ListView kontrol� olan lvi de�i�keninin 
             * elemanlar�nda (sat�rlar�nda) d�necek.
             */
            {
                item.SubItems[sno].Text = (++sayac).ToString("00");
                /* ListViewItem tipindeki de�i�kenin SubItems �zelli�i s�tunlar�
                 * ifade ediyor. [sno] ise s�tunun S�ra Numaras� i�in atad���m�z
                 * veri olmas�n� kesinle�tiriyor. Text �zelli�ine atama yap�yoruz.
                 * sayac de�i�keni bizim i�in s�ra numaras� �retecek, d�ng�n�n her 
                 * d�n���nde bir artacak. 
                 */
            }
        }
        private void dteDogTarihi_ValueChanged(object sender, EventArgs e)
        //DateTimePicker kontrol�n�n her de�i�iminde bu olay metodu �al���r.
        {
            mskDogTar.Text = dteDogTarihi.Value.ToString(TarihBicimi);
            /* Do�um tarihi i�in kulland���m�z MaskedTextBox kontrol�ne de�er ata 
             * DateTimePicker kontrol� olan dteDogTarihi kontrol�n�n, i�eri�ini
             * TarihBicimi format�na �evir ve MaskedTextBox kontrol�ne g�nder.
             * Do�um tarihi ile ilgili iki kontrol (controls) var: 1. control:
             * MaskedTextBox, Ad�: mskDogTar. 2. conrol: DateTimePicker,
             * Ad�: dteDogTarihi.
             */
        }
        private void lBoxIller_Click(object sender, EventArgs e)
        //ListBox kontrol�n�n t�klanmas�nda �al��an olay
        {
            cmbDogYeri.Text = lBoxIller.Text;
            /* Do�um yeri ile ilgili iki kontrol (controls) var: 1. control:
             * ComboBox, Ad�: cmbDogYeri. 2. control: ListBox, Ad�: lBoxIller.
             * lBoxIller_Click t�klanmas� ile �al��an olay metodunda �unlar�
             * yap. cmbDogYeri kontrol�n�n metin �zelli�ine atama yap =
             * lBoxIller kontrol�n�n metin �zelli�indeki de�eri ata.
             */
        }
        private void chkMedeniHal_CheckedChanged(object sender, EventArgs e)
        /* chkMedeniHal_CheckedChanged olay metodu: CheckBox kontrol�n�n de�i�iminde
         * �al���r. Bu kontrol�n iki durumu var: 
         * 1.durum T�klanm��t�r: Checked=true olur.
         * 2.durum T�klanmam��t�r: Checked=false olur.
         */
        {
            MedeniHalCheck(sender as CheckBox);
            /* MedeniHalCheck adl� bir metot bu kontrol�n durumunu de�i�tirecek. 
             * Parametresine CheckBox tipinde bir kontrol olan chkMedeniHal 
             * kontrol�n�n object tipindeki sender parametresini g�nderiyorum. Bu 
             * parametre ile t�klanan nesnenin kendisini parametre olarak d��ar�
             * g�nderebilirsiniz.
             */
        }
        private void MedeniHalCheck(CheckBox chkBox)
        /* Bu metot de�er d�nd�rm�yor. Ad�: MedeniHalCheck. Parametre olarak
         * CheckBox tipinde bir parametre al�yor.
         */
        {
            chkBox.Text = chkBox.Checked //Buras� sorgulanan k�s�m
                ? //Buras� true ise �al��an k�s�m
                Enum.GetName(typeof(MedeniHal), (int)MedeniHal.Evli)
                : //Buras� false ise �al��an k�s�m
                Enum.GetName(typeof(MedeniHal), (int)MedeniHal.Bekar);
            /* CheckBox tipli chkBox de�i�keninin metin �zelli�ine atama yap = 
             * t�klanm�� ise Evli, t�klanmam�� ise Bekar de�erini ata.
             */
        }
        private string Cinsiyeti()
        //string tipinde de�er d�nd�ren Cinsiyeti adl� metot.
        {
            if (rdbBay.Checked)
            //E�er RadioButton tipindeki rdbBay t�klanm�� ise
            {
                return Enum.GetName(typeof(Cinsiyet), (int)Cinsiyet.Bay);
                /* Enum ad�n� d�nd�ren GetName metodunu �a��r�yorum. �lk parametre
                 * Enum�un tipini, ikinci parametre de�erini istiyor. Cinsiyet adl� 
                 * enum listesinin, Bay eleman�n�n enum ad�n� d�nd�r.
                 */
            }
            else if (rdbBayan.Checked)
            //E�er RadioButton tipindeki rdbBayan t�klanm�� ise
            {
                return Enum.GetName(typeof(Cinsiyet), (int)Cinsiyet.Bayan);
                /* Enum ad�n� d�nd�ren GetName metodunu �a��r�yorum. �lk parametre
                 * Enum�un tipini, ikinci parametre de�erini istiyor. Cinsiyet adl� 
                 * enum listesinin, Bayan eleman�n�n, enum ad�n� d�nd�r.
                 */
            }
            return string.Empty;
            //�kisi de t�klanmam�� ise Bo� de�er d�nd�r.
            /* rdbBay ve rdbBayan adl� RadioButton bir GrupBox i�indeler. B�ylece 
             * sadece biri t�klanabilir.*/
        }
        private void BosNesneKontrol(out bool bosVarmi)
        /* Bu metot void (de�er d�nd�rmez). De�er d�nd�rmez ama, out kullan�rsan�z bir
         * de�eri d��ar� g�nderebilirsiniz. bool tipinde bosVarmi de�i�kenini d��ar�
         * aktarmak �zere parametreye ekle.
         */
        {
            bosVarmi = false;
            //bool bosVarmi de�i�keninin ilk de�eri bo� yok.
            string boslar = "N�fus bilgileri eklenemiyor.\n";
            //Bu de�i�keni, bo� olan nesneleri listelemek i�in tan�mlad�m.
            foreach (Control item in pnlGrup.Controls)
            /* Kontrol etmek istedi�im kontrollerin �zerinde rahat�a d�nebilmek i�in
             * forma bir panel ekleyip, bo� kontrol� yapmak istedi�im nesneleri bu 
             * panele ald�m. B�ylece Control tipindeki item de�i�kenim, Panel 
             * kontrol�n�n i�indeki kontrollerde d�necek. E�er pnlGrup. olmasa idi 
             * t�m kontrollerde d�nerdi ki, bu �u anki durumda i�imize yaramazd�.
             */
            {
                if (item.Text == string.Empty)
                //E�er kontrol metni bo� ise if blo�una in.
                {
                    if (item is CheckBox) continue;
                    /* E�er, item kontrol� CheckBox ise atla. ��nk� CheckBox false 
                     * ise bo� g�r�n�r. H�lbuki false olmas� bizim kodumuza g�re 
                     * Bekar se�imini ifade eder.
                     */
                    if (item is GroupBox)
                    /* E�er item kontrol� GroupBox ise (Bay veya Bayan se�ene�i i�in)
                     * bir kontrol yaz�yorum. Bu RadioButton kontrollerinden biri 
                     * mutlaka se�ili olmal�d�r
                     */
                    {
                        if (!rdbBay.Checked && !rdbBayan.Checked)
                        //rdbBay t�klanmad� ise ve rdbBayan t�klanmad� ise
                        {
                            boslar += "Cinsiyet Bilgisi Yok\n";
                            //boslar de�i�kenine �u metni ekle ve \n alt sat�ra in.
                            bosVarmi = true;
                            /* out olarak g�nderilecek olan bosVarmi de�i�kenine true
                             * de�erini ata
                             */
                        }
                    }
                    else
                    /* if sat�r�nda ne yaz�yor? if (item is GroupBox), else ise �u 
                     * demek: if (item is GroupBox) olmayanlar
                     */
                    {
                        boslar += item.Name + "\n";
                        /* bo� olan item kontrol�n�n ad�n� yaz ve \n ile bir alt 
                         * sat�ra in*/
                        bosVarmi = true;
                        /*out olarak g�nderilecek olan bosVarmi de�i�kenine true
                         * de�erini ata*/
                    }
                }
            }
            if (bosVarmi == true)
                //E�er bo� nesne var ise bu blo�a in
                MessageBox.Show(boslar, "Baz� Nesneler Bo� B�rak�lm��");
            //Tek sat�rl� if bloklar�nda {} kullanmasan�z da olur.
        }
        private void txtAdSoyad_KeyPress(object sender, KeyPressEventArgs e)
        /* TextBox kontrol�n�n klavye tu�lar�na bas�ld���nda �al��an olay� iki 
         * parametre al�r. 1. Parametre: object tipinde ve ad� sender. Bu parametre
         * TextBox kontrol�n� i�erir, 2. Parametre: KeyPressEventArgs tipinde ve 
         * ad�: e. Bu parametre TextBox kontrol�n�n bas�lan tu�unu i�erir.
         */
        {
            e.Handled = KlavyeTus�zni(txtAdSoyad, e, false);
            /* T�m KeyPressEventArgs d�nd�ren olay metotlar�n�n, kontrol�nde
             * klavye tu� vuru�lar�n� kontrol edebilen bu metodu kullanabilirsiniz.
             */
        }
        public char OndalikAyrac()
        //Bu metot char tipinde sistem ondal�k karakterini d�nd�recek.
        {
            return char.Parse(CultureInfo.CurrentCulture.
                NumberFormat.NumberDecimalSeparator);
            //Kullan�lan sistemin diline g�re ondal�k ayra� bulunuyor.
        }

        private bool KlavyeTus�zni
            (Control sender, KeyPressEventArgs e, bool StrNum = true)
        /* Bu metot KeyPressEventArgs tipinde ve e ad�nda bir parametre al�yor.
         * Birde numerik bir de�er mi yoksa metinsel bir de�er mi gireceksiniz?
         * Bunu parametreye sunman�z gerekiyor. E�er say�sal ise true al�yor.
         * Opsiyonel olan bu parametre varsay�lan olarak true de�er i�eriyor.
         * Yani; Parametreye de�er g�nderilmezse, metodu kullanan kontrole
         * sadece say� ve virg�l girilebilir.
         */
        {
            if (StrNum)
            //E�er StrNum true ise bu if blo�una in.
            {
                bool araVirgul = !sender.Text.Contains(OndalikAyrac());
                /* Say�sal bir veri grubunda virg�l bir defa ge�er. Neden ondal�k 
                 * ayrac�n virg�l oldu�unu bildi�im halde birde OndalikAyrac metodunu
                 * yazd�m? ��nk�; �ngilizce Windows kullanalar olabilir, onlarda 
                 * ondal�k ayra� nokta, binlik ayra� virg�l olur.
                 */
                e.Handled =
                !(char.IsDigit(e.KeyChar) ||
                e.KeyChar == (char)Keys.Back || e.KeyChar == OndalikAyrac() &&
                araVirgul);
                /* e.Handled false oldu�unda veri girilebilir.
                 * Sadece numerik veriler, BackSpace tu�u, ondal�k ayra�
                 * girilebilir. Virg�l sadece bir kez girilebilir.
                 */
            }
            else
            {
                e.Handled =
                char.IsDigit(e.KeyChar) ||
                !char.IsUpper(e.KeyChar) && !char.IsLower(e.KeyChar) &&
                !char.IsWhiteSpace(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back;
                /* Sadece, b�y�k harfler, k���k harfler, bo�luk tu�u ve
                 * BackSpace tu�u kullan�labilir.*/
            }
            return e.Handled;
            /* Sonu� true veya false olarak geri d�ner. B�ylece izin verilir
             * izin veya verilmez.
             */
        }
        private void txtAdSoyad_Click(object sender, EventArgs e)
        {//TextBox t�klama olay�.
            txtAdSoyad.SelectAll();
            //Kontrole t�kland��� anda t�m metni se�.
        }

        private void mskDogTar_Click(object sender, EventArgs e)
        {//MaskedTextBox t�klama olay�.
            mskDogTar.SelectAll();
            //Kontrole t�kland��� anda t�m metni se�.
        }

        bool tikla;
        /* Bu de�i�ken ile butona t�klama olay�n� de�i�tirece�iz. Yani
         * t�kland� ise t�klanmad�, t�klanmad� ise t�kland� gibi i�lem yapaca��z.
         */
        private void btnSutun_Click(object sender, EventArgs e)
        //S�tun geni�liklerini bu buton ile ayarlayaca��z.
        {
            tikla = !tikla;
            /* E�er tikla true ise tersi olan false, false ise tersi olan true
             * oluyor. Yani; Her t�klamada ya true olur, ya da false.
             */
            lViKisi.AutoResizeColumns(tikla ?
                ColumnHeaderAutoResizeStyle.HeaderSize :
                ColumnHeaderAutoResizeStyle.ColumnContent);
            /* E�er tikla de�i�keni true ise, verileri ba�l�k de�erlerine g�re 
             * (HeaderSize), false ise s�tundaki verilere (ColumnContent) g�re
             * geni�lik ayarlanacak. B�ylece bir kez t�klan�nca HeaderSize, di�erinde
             * ColumnContent kullan�lacak. �nceki derslerimizde, de�i�kenlerin 
             * varsay�lan de�erlerinden bahsetmi�tim. Default bool: False �eklinde
             * bir ��kt� sunan bir konsol projemiz vard� ve belki bu ne i�ime yarar 
             * ki demi�sinizdir? ��te cevab�: S�tun geni�li�i butonuna ilk kez 
             * t�klan�nca, s�tun geni�likleri: HeaderSize de�erine g�re mi yoksa 
             * ColumnContent de�erine g�re mi yap�l�r? Cevap: Default bool: false
             * oldu�undan tikla de�i�keninin ilk de�eri false olur b�ylece:
             * tikla = !tikla; tikla = !false, true olur. �u ana kadar anlatt���m
             * her kod par�as� proje yaparken mutlaka laz�m olacakt�r, bo� bilgi 
             * olarak g�rmemek gerekir, bu g�n laz�m olmaz, yar�n gerekebilir.
             */
        }
        private void btnSil_Click(object sender, EventArgs e)
        //Sat�r silme butonu t�klama olay�.
        {
            if (lViKisi.SelectedIndices.Count <= 0)
            /* Se�ili ��enin indeks (dizin) de�eri k���k veya e�it ise 0'a. Veri 
             * se�imi yap�lmam�� ise
             */
            {
                MessageBox.Show("Listeden neyi silmemi istiyorsan�z se�melisiniz.");
                //Mesaj kutusunu g�ster
                return;
                //Metodun t�m�nde ��k.
            }
            if (lViKisi.Items.Count > 0 && lViKisi.SelectedIndices.Count > 0)
            /* E�er liste elemanlar�n�n adedi 0'dan b�y�kse ve se�ili elemanlar�n 
             * adedi 0'dan b�y�kse bu if blo�una in. liste elemanlar�n�n adedi 0'dan
             * b�y�k oldu�unda, listede eleman oldu�u anla��l�r, ama bu silinecek
             * eleman�n se�ildi�i anlam�na gelmemektedir. bu nedenle SelectedIndices
             * ile se�ili eleman olup olmad���na bak�yoruz.
            */
            {
                //Bu d�ng�de ama� se�ili olan sat�rlar�n silinmesi.
                for (int i = lViKisi.Items.Count - 1; i >= 0; i--)
                /* for d�ng�s� yaz�yorum. D�ng� de�i�keni olan i int tipindedir.
                 * D�ng�, i de�eri liste eleman say�s�ndan ba�lay�p (1 ��kar�yoruz) 
                 * 0'dan b�y�k veya e�it oldu�u s�rece d�n�yor. Bu d�ng� k���kten
                 * b�y��e do�ru de�il, b�y�kten k����e do�ru �al���yor, neden? ��nk�;
                 * sat�r silindik�e i de�i�keni de�eri azal�yor, ya d�ng�y� k���kten
                 * b�y��e do�ru do�ru yaz�p, eksilen sat�r i�in i-- yazars�n�z ya da
                 * d�ng�y� tersten �al��t�r�p silinen en b�y�k sat�r de�erinden 
                 * geriye do�ru gitti�iniz i�in i-- yazman�za gerek kalmaz. 
                 */
                {
                    if (lViKisi.Items[i].Selected) lViKisi.Items[i].Remove();
                    /* E�er lViKisi elemanlar�ndan [i] dizin/indeks de�erine sahip 
                     * eleman se�ili ise �unu yap: lViKisi elemanlar�ndan [i] 
                     * dizin/indeks de�erine sahip eleman� kald�r.
                     */
                }
                for (int i = 0; i < lViKisi.Items.Count; i++)
                /* Yukardaki d�ng�n�n ayn�s�, tek fark� al��t���m�z gibi yaz�lm�� 
                 * olmas�, k���kten b�y��e do�ru �al���yor.
                 */
                {
                    if (lViKisi.Items[i].Selected)
                    {
                        lViKisi.Items[i].Remove();
                        i--;
                        /* Silme i�leminden sonra silinen sat�r� aradan ��karmak 
                         * ad�na artm�� olan i de�erini azalt�yorum. Yani ��yle: 5 
                         * sat�r olsun ve sadece �rnek anla��ls�n diye ilk sat�r�n 
                         * de�eri 1. sat�r ile ifade edilsin. �imdi 5,3,2 
                         * sat�rlar�n� silersem; (1 ve 4 kalacak.)
                         * 1. Sat�r: Dur: i++ ile i=1
                         * 2. Sat�r: Sil: i++ ile i=2. 
                         * Burada i silinince sat�r say�s� da otomatik olarak 1 
                         * azal�yor, ama d�ng� i de�eri art�yor. Bu durumda i--
                         * yaz�p, d�ng� i de�erini azaltt���m i�in, sat�r say�s� 
                         * da azal�yor. 
                         * 2. Sat�r: i-- ile i=1
                         * 3. Sat�r: Sil: i++ ile i=2. 
                         * Burada i de�eri 2'ye d���yor. B�ylece 2. sat�r art�k 
                         * olmad��� i�in 3. sat�r�, 2. sat�r olarak siliyorum.
                         * tekrar i-- �al���yor.
                         * 3. Sat�r: Sil: i-- ile i=1.  
                         * 4. Sat�r: Dur: i++ ile i=2 oldu. Burada silme 
                         * olmad��� i�in i-- yok. i=2 olarak kald�.
                         * 5. Sat�r: Sil: i++ ile i=3 oldu ancak bu sat�r� sildi�im
                         * i�in i-- ile i de�eri tekrar 2 oldu ve sadece 1. ve 4. 
                         * sat�r kald�.
                         */
                    }
                }

                if (lViKisi.Items.Count > 0)
                    lViKisi.Items[lViKisi.Items.Count - 1].Selected = true;
                /* Tek sat�rl� bir i�lem yapt�rmak istedi�iniz if blo�unun 
                 * {parantezlerini} eklemeseniz de olur. E�er silme i�leminden sonra
                 * hala bir sat�r kalm�� ise. Liste elemanlar� 0'dan b�y�k ise;
                 * Liste elemanlar�ndan [Liste elemanlar�n� say -1 ��kar ve bu 
                 * indeks de�erine sahip sat�r�] se�. Yani son eleman se�ili olsun.
                 */
                btnSil.Enabled = lViKisi.Items.Count > 0;
                /* Silme i�lemi yapan butonun etkin olma durumuna atama yap (true 
                 * veya false olabilir). E�er liste elamanlar�n�n say�s� s�f�rdan 
                 * b�y�k ise > 0 true d�ner, de�ilse false d�ner. B�ylece eleman
                 * kalmad� ise, silinecek eleman da olamayaca��ndan etkin de�il
                 * olarak ayarlanm�� olur, b�ylece t�klanamaz.
                 */
            }
        }
        private void lViKisi_ColumnClick(object sender, ColumnClickEventArgs e)
        /* Listenin, s�tun t�klanma olay�na kod yaz�yorum. Bu olay metodu, s�tun
         * ba�l�klar�na t�kland���nda �al���r. t�klanan s�tunun hangisi oldu�unu
         * lViKisi_ColumnClick olay metodunun, ColumnClickEventArgs parametresi
         * e adl� de�i�kende tutar.
         */
        {
            if (e.Column == columnSort.e)
            //E�er t�klanan s�tun ile, s�ralanacak s�tun ayn� ise bu blo�a in
            {
                columnSort.sortStatus = columnSort.sortStatus == SortOrder.Ascending
                    ?
                    columnSort.sortStatus = SortOrder.Descending
                    :
                    columnSort.sortStatus = SortOrder.Ascending;
                //S�ralama her t�klamada bir artan, di�er t�klamada azalan olsun.
            }
            else
            {
                columnSort.e = e.Column;
                columnSort.sortStatus = SortOrder.Ascending;
                /* �lk s�ralamada s�ralanan s�tun ile t�klanan s�tun ayn� olur ve bu
                 * else blo�una inilir. Varsay�lan bir sonraki ilk s�ralama de�eri 
                 * i�in Ascending atad�m.
                 */
            }
            lViKisi.Sort();
            /* Art�k listeyi s�ralayabiliriz. �imdi de S�ralama yapan ColumnSort 
             * s�n�f�n� a��klamak gerekiyor.*/
        }
    }
}