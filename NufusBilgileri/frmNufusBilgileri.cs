using System.Globalization;

namespace NufusBilgileri
{
    internal enum MedeniHal { Evli, Bekar };
    /* Bir Ýsim Alaný (NameSpace) içinde kýsýtlayýcý olmadan tanýmlanan Class
     * (Sýnýf) veya Struct (Yapý) eriþim kýsýtlayýcýsý belirtilmedi ise varsayýlan
     * olarak Internal (Dahili) olurlar. Bu deðiþken ise "namespace NufusBilgileri"
     * isim alanýnda tanýmlandý varsayýlaný zaten internal.
     */
    enum Cinsiyet { Bay, Bayan };
    public partial class frmNufusBilgileri : Form
    {
        readonly string TarihBicimi = "dd/MM/yyyy";
        /* readonly (sadece okunabilir, veri atanamaz) string tipinde bir tarih
         * formatý tanýmladým. Bu format sabit, deðiþmeyecek. Baþka bir yazýlýmcý
         * veya ben unutarak, bu deðiþkene sonradan atama yapamayacaðým.
         */
        readonly string[] iller = { "Adana", "Adýyaman", "Afyon", "Aðrý",
        "Aksaray", "Amasya", "Ankara", "Antalya", "Ardahan", "Artvin", "Aydýn",
        "Balýkesir", "Bartýn", "Batman", "Bayburt", "Bilecik", "Bingöl",
        "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankýrý", "Çorum",
        "Denizli", "Diyarbakýr", "Düzce", "Edirne", "Elazýð", "Erzincan",
        "Erzurum", "Eskiþehir", "Gaziantep", "Giresun", "Gümüþhane", "Hakkâri",
        "Hatay", "Iðdýr", "Isparta", "Ýstanbul", "Ýzmir", "Kahramanmaraþ",
        "Karabük", "Karaman", "Kars", "Kastamonu", "Kayseri", "Kýrýkkale",
        "Kýrklareli", "Kýrþehir", "Kilis", "Kocaeli", "Konya", "Kütahya",
        "Malatya", "Manisa", "Mardin", "Mersin", "Muðla", "Muþ", "Nevþehir",
        "Niðde", "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun", "Siirt",
        "Sinop", "Sivas", "Þanlýurfa", "Þýrnak", "Tekirdað", "Tokat",
        "Trabzon", "Tunceli", "Uþak", "Van", "Yalova", "Yozgat", "Zonguldak" };
        /* readonly (sadece okunabilir, veri atanamaz) string dizisi tipinde illeri
         * içeren dizimiz var ve bu diziye bir atama yapýlamayacak, hiçbir ilimizin
         * hatýrý kalmasýn diye tümünü yazdým.  Bu illerden birini formdaki Doðum
         * Yeri alanýna rasgele yazacaðým.
         */
        readonly string[] basliklar = {"S.No", "Doðum Tarihi", "Ad Soyad",
            "Doðum Yeri", "Medeni Hali", "Cinsiyet"};
        /* readonly (sadece okunabilir, veri atanamaz) string dizisi  
         * tipindeki kontrolümüzde baþlýk olarak kullanýlacak. Deðer atamasý 
         * yapýlmayacaðý için readonly olarak tanýmladým. Baþka bir yazýlýmcý
         * veya ben unutarak, bu deðiþkene sonradan atama yapamayacaðým.
         */
        readonly string[] isimler = { "Ayþe BETÜL", "Amine OKUMUÞ",
            "Süleyman UZUNKÖPRÜ", "Muhammed FATÝH", "Ahmet YASÝN", "Berces MÝRDENLÝ",
            "Mustafa PARLAK", "Ömer ÖRENÇ", "Burak DERELÝ", "Oktay ÞENTÜRK",
            "Sabri BÝRADLI","Hamit GÜMÜÞ", "Ýlhan GÜMÜÞ", "Bekir UZUN",
            "Hamza OKUMUÞ" };

        /* readonly (sadece okunabilir, veri atanamaz). Nüfus bilgileri için Rasgele 
         * isimler tanýmlýyorum. Bu isimlerden birini formdaki ad alanýna rasgele 
         * yazacaðým.  Baþka bir yazýlýmcý veya ben unutarak, bu deðiþkene sonradan
         * atama yapamayacaðým.
         */
        ColumnSort columnSort;
        /* Bu isme sahip class (sýnýf) var. Bu class ColumnOrder isim alanýnda. 
         * ListViewColumnSort tipine sahip olacak deðiþkenimin adý: columnSort 
         * (Sütun Sýrala). Bu deðiþkeni Public bir alana yazdým, böylece bu class 
         * (sýnýf) içinden, baþka metotlardan da çaðýrýlabilir (Varsayýlan eriþim 
         * belirteci olan Internal eriþim belirtecine sahiptir).
         */
        public frmNufusBilgileri()
        {
            InitializeComponent();
            /* frmNufusBilgileri form projesinin kurucu metodudur.
             * InitializeComponent metodu ise forma manuel olarak çizilen
             * nesnelerin, özellikleri, olay metotlarý vb. arkaplanda yazar.
             */
            columnSort = new ColumnSort();
            lViKisi.ListViewItemSorter = columnSort;
            /* Sütun sýralama için yapýlan atama public (genel) bir alanda yapýlmalý 
             * ve ilk çalýþan metot olan kurucu metot içinden atanmalýdýr. Böylece 
             * ilk sýralama atamasý null olmamýþ olur.
             * Sütunlarýn sýralanabilmesi için ListView kontrolünün
             * ListViewItemSorter özelliðine deðer atamasý yapýyorum. ColumnSort
             * adýnda bir class (sýnýf) yazdým burasý o sýnýfýn bir örneðini
             * (instance) alýyor. Listeye yeni bir sýralama özelliði eklemiþ oldum.
             * ListView kontrolünde istediðimizi yapabilen bir sýralama tekniði
             * yoktu, eklemiþ oldum. Aslýnda ListView daha çok imaj nesneleri
             * listelemek için kullanýlýyor, bu örnekte ise veri listeleyeceðim.
             * Bir Class yardýmý ile sýralama nasýl yapýlýr onu anlatmak
             * niyetindeyim. Halbuki DataGridView kontrolünü kullanabilirdim,
             * sýralama otomatik yapýlýrdý. O zaman bu kadar çok þey anlatamazdým. 
             */
        }

        private struct KisiBilgi
        /* Yeni bir struct (yapý) tanýmlýyorum. Adý: KisiBilgi. Baþka bir sýnýfta
         * kullanýlmayacaðý için eriþim kýsýtlayýcýsý private.
         */
        {
            /* Bu Class için tanýmladýðým alanlar (fields) sadece bu sýnýfta
             * kullanýlacak, bu yüzden internal tanýmlamak istedim. Güvelik
             * düzeyleri: internal.
             */
            internal DateTime dTar;
            //Tip: string, Ad: dTar. Bu bir Field (Alan).
            internal string adSyd;
            //Tip: DateTime, Ad: adSyd. Bu bir Field (Alan).
            internal string dYer;
            //Tip: DateTime, Ad: dYer. Bu bir Field (Alan).
            internal MedeniHal medHal;
            /* Tip: MedeniHal enum listesi, Ad: medHal. Bu bir Field (Alan).
             * Böylece Evli, Bekar seçeneði listelenebilecek.*/
            internal Cinsiyet cnsy;
            /* Tip: Cinsiyet enum listesi, Ad: cnsy. Bu bir Field (Alan).
             * Böylece Bay, Bayan seçeneði listelenebilecek.*/
        }
        private void frmNufusBilgileri_Load(object sender, EventArgs e)
        /* frmNufusBilgileri formunun olay metodu olan Load olayý (event) form 
         * çaðrýldýðý anda bu scope (kapsam) kodlarý çalýþacak. Böylece form
         * yüklenirken çalýþtýrýlmasý gereken tüm kodlarý buraya yazýyorum.
         */
        {
            chkMedeniHal.Text =
                Enum.GetName(typeof(MedeniHal), (int)MedeniHal.Bekar);
            /* Bir enum deðerinin adýný alabilmek için Enum abstract class 
             * (numaralandýrýlmýþ soyut sýnýf) tipinin GetName metodu kullanýlabilir.
             * GetName metodu iki parametre alýr (1.Parametre: Type tipinde bir enum 
             * alýr, 2.Parametre: Enum listesinin int deðerini alýr).
             */
            btnSil.Enabled = false;
            /* Form yüklenirken, henüz nüfus bilgisi olmayacaðý için, bu butona 
             * basýlmasý hataya neden olur. Bu nedenle buton görünür ama
             * kullanýlabilir durumda olmasýn.
            */
            Text = "Nüfus Bilgileri";
            /* Aslýnda frmNufusBilgileri formunun Text özelliðine atama yapmýþ oldum. 
             * bulunduðumuz sýnýf, zaten frmNufusBilgileri sýnýfý olduðundan this 
             * yazmaya gerek yok. frmNufusBilgileri formunu tanýtan ifade olan 
             * this.Text ifadesi yazýlmasada olur. 
             */
            ContextMenuStrip menu = new();
            /* Þimdi sað týklama olayýnda açýlan bir menü tanýmlýyorum. Menünün 
             * tipi ContextMenuStrip, adý: menu. ContextMenuStrip sýnýfýndan yeni
             * bir instance (örnek) alýyorum. Böylece ihtiyacýmýz olan özellikleri ve
             * metotlarýný kullanabiliriz.
             */
            menu.Items.Add("Rasgele Kiþi Ekle");
            /* ContextMenuStrip tipindeki menümüze bir eleman ekliyoruz. Menü adý: 
             * Rasgele Kiþi Ekle. Fare sað týklanýnca açýldýðýnda bu metin görünür.
             */
            menu.ItemClicked += Menu_ItemClicked;
            /* menu item nesnesine bir olay metodu ekliyoruz. += operatörlerinden 
             * sonra Tab tuþuna bastýðýmýzda bir týklama olay metodu oluþuyor. 
             * menü elemaný (item) týklanýnca çalýþacak. Ancak metot, bu scope 
             * (kapsam) dýþýnda. Menu_ItemClicked olay metoduna indiðimizde 
             * açýklamasýný yazacaðým.
             */
            ContextMenuStrip = menu;
            /* Menü hazýr ama, daha forma eklenmedi. Formun ContextMenuStrip özelliði
             * var, bu özellik ContextMenuStrip tipinde bir deðiþken atandýðýnda, 
             * farenin sað týklanmasý ile açýlýr. Bu durumda ContextMenuStrip 
             * tipindeki menu deðiþkenini atadým.
             */
            mskDogTar.Mask = "00/00/0000";
            /* Tip: MaskedTextBox, Adý: mskDogTar. Þimdi bu, MaskedTextBox kontrolüne
             * bir giriþ maskesi tanýmlýyorum. Böylece 26.05.2020 þeklinde bir tarih
             * atamasý yapýlmalý. Ancak tarih olmayan 36.55.2020 gibi bir sayýda 
             * girilebilir. Bunu tarih atama iþlemi sýrasýnda engelleriz.
             */
            cmbDogYeri.Items.AddRange(iller);
            /* Tip: ComboBox, Adý: cmbDogYeri olan açýlan kutu kontrolüne eleman 
             * ekliyorum. AddRange metoduna object[] dizisi tipinde liste göndermemiz
             * gerekiyor. Bizim iller adlý bir listemiz var, onu bu metoda gönderdim.
             * Bizdeki listenin tipi  string[] dizisi.
             */
            lBoxIller.Items.AddRange(iller);
            /* Tip: ListBox, Adý: lBoxIller olan liste kutusu kontrolüne eleman 
             * ekliyorum. AddRange metoduna object[] dizisi tipinde liste göndermemiz
             * gerekiyor. Bizim iller adlý bir listemiz var, onu bu metoda gönderdim.
             */
            dteDogTarihi.CustomFormat = TarihBicimi;
            /* Tipi: DateTimePicker, Adý: dteDogTarihi olan kontrolümüz için, 
             * kullanýcý tanýmlý özel bir format tanýmladým.
             */
            /*Þimdi de ListView kontrolüm için gerekli ve istediðim biçimleri 
             * tanýmlayacaðým.*/
            lViKisi.View = View.Details;
            /* ListView kontrolü Görünüm Özelliði = Detaylar görüntülensin. Böylece
             * tüm sütunlar görünür hale gelecek. Eklenen veriler alt alta
             * görünecek. Aksi halde tek bir sütun görünür ve veriler eklendikçe
             * sola, sonra alta ve sonra yine sola tek sütun olarak eklenir.
             */
            lViKisi.GridLines = true;
            //ListView kontrolünde ýzgara çizgileri görüntülensin.
            lViKisi.HeaderStyle = ColumnHeaderStyle.Clickable;
            /* ListView kontrolü baþlýðý týklanabilir olsun.Çünkü týklanýnca
             * sýralama yapýlmasýný saðlayacaðým.
             */
            lViKisi.Sorting = SortOrder.Ascending;
            //ListView kontrolü sýralama artan olacak.
            lViKisi.FullRowSelect = true;
            //Bir satýr týklanýnca tüm satýrý seçilebilir durumda olacak.

            for (int i = 0; i < basliklar.Count(); i++)
            /* Listenin baþlýklarý için bir dizi tanýmlamýþtýk. O dizinin 
             * elemanlarýný sayýyorum ve döngümün son noktasýný tespit ediyorum.
             * Bu döngü ile Listeye baþlýklarýn yazýlmasýný saðlayacaðým.
             */
            {
                ColumnHeader columnHeader = new();
                //Tip: ColumnHeader, Adý: columnHeader, yeni bir örnek alýyorum.
                columnHeader.Text = basliklar[i];
                /* ColumnHeader tipindeki columnHeader adlý deðiþkenin Text 
                 * özelliðine baþlýklar dizisinin elemanlarýný gönderiyorum. Böylece
                 * baþlýk deðerleri oluþuyor.
                 */
                lViKisi.Columns.Add(columnHeader);
                /* columnHeader deðiþkenine sütun ekle, eklenen sütunun tipi 
                 * ColumnHeader olduðundan liste baþlýðý oluþur.
                 */
            }

            lViKisi.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            /* lViKisi listemin sütun geniþliklerini otomatik olarak ayarlýyorum.
             * geniþlik baþlýða göre otomatik ayarlanacak.
             */
            txtAdSoyad.Focus();
            /* Kullanýcý programý açtýðýnda ad ve soyad bilgisini hemen girebilsin.
             * Bir de metin kutusunu týklamasýn diye, imleci bu kontrole odakladým.
             */
        }
        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {/* Menünün tipi ContextMenuStrip, adý: menu olan menümüm item elemanýna 
          * bir týklama olayý atadým. Böylece menü item elemanýna týklandýðýnda 
          * bu olay metodu çalýþacak.
          */
            {
                /* Kiþilerin verilerini her seferinde manuel seçerek girmektense
                 * rasgele atamalar yapmak için bu kodlarý yazdým. Böylece algoritma 
                 * yeteneðinin ve analitik düþünebilme yetisinin geliþtirilmesini
                 * hedefliyorum.
                 */
                Random rnd = new();
                /* Random sýnýfýndan bir instance (örnek) alýyorum. Bu metot rasgele
                 * sayý üretecek. Henüz üretmeye baþlamadý. Sadece hazýr.
                 */
                int yil = DateTime.Today.Year;
                int yilRnd = rnd.Next(yil - 40, yil - 18 + 1);
                /* Doðum tarihlerinin yýl deðeri için bu yýl deðerinden 40
                 * çýkarýyorum. Bu deðer Random sýnýfýnýn Next metodunun ilk
                 * parametresine sunuluyor. 18 çýkarýyorum bu deðer de ikinci
                 * parametre.  Böylece 18 yaþýndan 40 yaþýna kadar doðum tarihleri
                 * üretilecek. Mesela 2020 yýlý için 2020-40=1980 ve
                 * 2020-18 + 1 = 2002 tarihleri arasýnda  deðer üretilecek son
                 * deðerin kendisi dahil edilmiyor.
                 */
                int ay = rnd.Next(1, 12 + 1);
                /* 12 ay için 1, ile 12 arasýnda deðer üretmek için +1 ekliyorum.
                 * Niye 13 yazmadým da 12 + 1 yazdým? Akýlda kalýcý olsun diye.
                 * Þimdi 2020-18 için 2002,12 gibi iki deðer oluþtu. Bu deðer yýl 
                 * ve ay bilgisidir.
                 */
                int ayinSonGunu = DateTime.DaysInMonth(yilRnd, ay);
                /* Gün bilgisi biraz daha karýþýk. Programýn aylarýn son günlerine 
                 * takýlmadan ilerlemesi lazým. Mesela 30/02 þeklinde bir tarih
                 * olmaz. Bu durumda önce ayýn kaç çektiðini bulmamýz lazým. Böylece
                 * rasgele üretilen deðer, ayýn son gün deðerine kadar üretilsin. 
                 */
                int gun = rnd.Next(1, ayinSonGunu + 1);
                /* Ay deðeri ayýn 1'i ile son günü arasýnda üretilsin. Böylece 
                 * 17.12.2002 gibi bir doðum tarihi oluþuyor. Her oluþan tarih 
                 * diðerinden farklý. Ayný gelme ihtimali de var tabi.
                 */
                int dogYer = rnd.Next(0, iller.Length);
            /* Doðum yeri de rasgele oluþsun. Tüm illeri yazdýðým bir dizi var. 
             * Dizinin adý iller. Dizinin ilk deðeri 0. deðerdir. Nedense C# (diðer
             * diller de böyle gördüm) ilk deðer 0. deðer oluyor. Ýller dizisinin
             * uzunluðu 81. Burada diðerleri gibi +1 yazmadým, neden? Çünkü, 0. 
             * eleman ile 80. eleman arasýnda deðer üretilirse 81 il için sýra 
             * numarasý üretilmiþ olacaktýr.
             */
            geri:
                /* Bu goto döngüsünün etiketi. goto döngüsü þarta göre bu satýra
                 * döner. Bu bloðu yeniden çalýþtýrýr. Tabii ki þart goto döngüsünde
                 * þart yoksa sürekli bu satýra döneceði için program bu adýmý
                 * geçemez. goto döngüsünde þart eklemeyi unutmamak gerekir. Burasý
                 * döngünün döneceði nokta, nereden ve hangi þartlar ile döneceði
                 * ileriki satýrlarda olacak.
                 */
                int isim = rnd.Next(0, isimler.Length);
                //Burasý da isimler dizisi için eleman sýra numarasý üretecek.
                foreach (ListViewItem item in lViKisi.Items)
                /* Bu döngünün yazýlma amacý, ayný isme sahip kiþilerin listeye
                 * yeniden eklenmesini engellemek. ListView kontrolünün liste
                 * elemanlarýnýn tipi ListViewItem, bu tip döngü deðiþkeninin tipi.
                 * Elemanlar ise lViKisi adlý ListView kontrolünün, items
                 * deðerlerinde. Böylece ListViewItem tipli bir deðiþken olan item,
                 * ListView satýrlarýnda dönecek ve her dönüþünde bir adet liste
                 * satýrýný içerecek. Ancak bu liste satýrlarý isim verisini
                 * içermeyen sütunlarý da kapsar.
                 */
                {
                    int adStn = Array.IndexOf(basliklar, "Ad Soyad");
                    /* ListView kontrolünde oluþturduðum "Ad Soyad" sütununu
                     * buluyorum. Sonra bu sütunda arama yapacaðým. Array sýnýfýnýn
                     * IndexOf metodu iki parametre alýr ve geriye int tipinde bir
                     * deðer döndürür.
                     * 1. Parametresi: Hangi dizide arama yapacak bunu ister.
                     * 2. Parametresi: Dizide aranacak elemaný ister. Bulunca,
                     * bulduðu elemanýn kaçýncý eleman olduðunu döndürür. "Ad Soyad"
                     * diziye göre 0.1.2. sütunda (normalde 3. sütunda). Aranan
                     * deðer yok ise -1 döner.
                    */
                    if (item.SubItems[adStn].Text == isimler[isim])
                    //1. if merdiveni
                    /* Eðer ad soyad yazan sütundaki metin eþit ise isimler dizisinin 
                     * isim elemanýna. Yani; veriyi bulduysan bu if bloðuna gir.
                     * Böylece ayný isim zaten kaydedilmiþ demektir.*/
                    {
                        if (lViKisi.Items.Count == isimler.Count())
                        //2. if merdiveni
                        /* ListView kontrolünde elemanlarý say, isimler dizisindeki 
                         * elemanlarý da da say, eþit ise. Eðer listedeki kiþi sayýsý 
                         * ile isimlerdeki kiþi sayýsý ayný ise bu if bloðuna gir. 
                         * Yukarýda da ayný isim var mý kontrol ediliyor. 
                         * Eðer bu kod bloðu olmasa sürekli isim eklenmeye çalýþýlýr.
                         * Çünkü, yukarýdaki if ayný isim var mý bakýyor, diyelim ki 
                         * ayný isim yok ekliyor. Dizideki isimler bitince ne olacak?
                         * Ýþte bu if bloðu da eklenen eleman sayýlarýna bakýyor ve 
                         * dizideki elemana ulaþýnca bu bloða giriyor. */
                        {
                            MessageBox.Show("Eklenebilecek isimlerin tümü bitti.");
                            return;
                            /* Eklenecek eleman kalmayýnca bundan sonraki kodlarý 
                             * çalýþtýrmamam gerektiði için return ile scope (kapsamý)
                             * sonlandýrdým.
                             */
                        }//2. if merdiveni kapsam (scope) bitiþi.
                        goto geri;
                        /* Burasý geri etiketine dönülmesini saðlayan bir döngü.
                         * 1. if merdiveni için çalýþýyor. Eklemeye çalýþýlan isim
                         * varsa geri etiketine dönülecek. Eklenecek satýr
                         * kalmadýðýnda ise 2. if merdiveni return ile kapsamý
                         * (scope) sonlandýrýyor.
                         */
                    } //1. if merdiveni kapsam (scope) bitiþi.
                }//foreach (ListViewItem item in lViKisi.Items) döngüsü bitti.

                KisiBilgi kisiBilgi = new();
                /* Hatýrlarsanýz KisiBilgi adýnda bir struct tanýmlamýþtýk. Þimdi bu 
                 * yapýya (struct) deðer atamasý yapacaðým. Sonra bu deðerleri
                 * ListView kontrolüne aktaracaðým.
                 */
                kisiBilgi.dTar = new DateTime(yilRnd, ay, gun);
                /* KisiBilgi struct tipindeki kisiBilgi deðiþkenimizin dTar
                 * özelliðine (bu özellik DateTime tipindeydi) bir doðum tarihi
                 * atamasý yapýyoruz. Buradaki new DateTime struct * (yapýsýnýn)
                 * bir örneði (instance). Yil, ay ve gün deðerleri ile yeni bir
                 * DateTime oluþuyor. Hatýrlatmak gerekirse, Yil, ay ve gün
                 * deðerleri rasgele (random) oluþuyordu.
                 */
                kisiBilgi.adSyd = isimler[isim];
                /* KisiBilgi struct tipindeki kisiBilgi deðiþkenimizin adSyd
                 * özelliðine (bu özellik string tipindeydi) bir isim atamasý
                 * yapýyoruz. Burada sadece örneðin zenginleþmesi için bir çok
                 * algoritmik örnek eklemek adýna böyle kodlar yazdým. Yoksa,
                 * zaten kullanýcý forma manuel girdiði veriyi ekle butonu ile
                 * ekleyebilir. Hatýrlatma: Bir dizimiz vardý adý: isimler,
                 * bu dizinin elemanlarýnda 1.2.3. gibi bir elemaný çaðýrabiliriz.
                 * Bende rasgele bir ismi kisiBilgi deðiþkenimizin adSyd 
                 * özelliðine atadým.
                 */
                kisiBilgi.dYer = lBoxIller.Text = iller[dogYer];
                /* Doðum yeri özelliðine ve Ýlleri listelediðimiz lBoxIller adlý 
                 * ListBox kontrolüne atama yapacaðým. Atama ayný veriyi
                 * içereceðinden bir kontrolün bir özelliðini diðerine eþitledim
                 * ve iller dizisinden doðum yeri olarak rasgele bir ili her iki
                 * özelliðe ayný anda atadým.
                 */
                mskDogTar.Text = dteDogTarihi.Text =
                    kisiBilgi.dTar.ToString(TarihBicimi);
                /* KisiBilgi struct tipindeki kisiBilgi deðiþkenimizin dTar
                 * özelliðine bir doðum tarihi atamasý yapmýþtýk. Þimdi de bu
                 * doðum tarihini her iki kontrolümüze birden gönderiyoruz.
                 * 1. kontol: MaskedTextBox tipinde mskDogTar ve 2. kontol:
                 * DateTimePicker tipinde dteDogTarihi nesneleridir. Bu iki
                 * kontrolün de Text özelliði mevcut, bu nedenle veriyi gönderirken
                 * string tipine çevirmem gerekli oldu. Peki ToString metodunun
                 * içindeki (TarihBiçimi) ne anlama geliyor? Kodlarýmýzýn en
                 * baþýnda public bir deðiþkenimiz vardý, deðer atamayacaðýz,
                 * sadece okuma iþlemi yapacaðýz (readonly) demiþtik, iþte o
                 * deðiþken. Peki deðeri ne idi? ("dd/MM/yyyy") 28.05.2020 
                 * gibi bir formatý ifade ediyor. Neden ToString("dd/MM/yyyy") 
                 * yazmadým da, bu deðeri bir deðiþkene alarak kullandým? Birden 
                 * fazla kullanacaðýnýz herhangi bir veriyi, bir deðiþken vasýtasý 
                 * ile kullanmanýzý öneririm. Böylece bir düzeltme/deðiþiklik 
                 * gerektiðinde sadece deðiþken atamasý yapýlan  satýrý
                 * düzeltirsiniz, tüm ToString(TarihBiçimi) formatlarý düzelir.
                */
                txtAdSoyad.Text = kisiBilgi.adSyd;
                //TextBox tipindeki txtAdSoyad kontrolüne adsoyad bilgisini yazýyoruz.
                cmbDogYeri.Text = kisiBilgi.dYer;
                //ComboBox tipinde cmbDogYeri kontrolüne Doðum yerini yazdýk.
                rdbBayan.Checked = isim <= 1;
                /* RadioButton tipindeki rdbBayan kontrolünün bool tipinde deðer alan 
                 * Checked özelliði true veya false olabilir. Bende þöyle yazdým isim 
                 * deðiþkeni küçük veya eþit mi 1'e (isimler dizisinin 0. ve 1. 
                 * elemanlarý bayan olduðu için) þart karþýlanýyor ise true döner, 
                 * isimler dizisinin 0. ve 1. elemanlarý için bayan RadioButton 
                 * kontrolü iþaretli olur.
                 */
                rdbBay.Checked = isim > 1;
                /*Eðer isimler dizisinin 0. ve 1. elemanlarý deðilse bay RadioButton
                 * kontrolü iþaretli olur. Þöyle de yazabilirdik: 
                 * rdbBay.Checked= !rdbBayan.Checked
                 * Önce bayan mý kontrolü yapýldýðý için bir sonuç çýkardý bayan ise
                 * true olurdu, bu kontrolde bayan için yapýlan kontrolün tam tersi
                 * false olurdu. false olsa idi, bu RadioButton kontrolü de
                 * true olurdu.
                 */
                btnEkle_Click(null, null);
                /* En sevmediðim kod yazým þekli buton altý kod yazmak. Yani; bir 
                 * kontrolün altýna kod yazýlmaz, sadece metot çaðrýlýr, bunu 
                 * özellikle yazdým. Tabii ki, iþlemler formun load olayýndaki gibi 
                 * deðilse. Zorunlu olmayan kural þudur: Bir kod bloðu metoda 
                 * çevrilebiliyorsa metot olarak yazýlýr ve ihtiyaç olan yerlerde 
                 * çaðrýlýr. Bir metottaki kod baþka bir metotta da yazýlýyor ise,
                 * ikinci kez yazýlan kod metoda çevrilir ve diðer iki metottan 
                 * çaðrýlýr. Sadece örnek olsun diye bir butonun altý kod bloðuna 
                 * ihtiyacýmýz olduðunda nasýl çaðrýlmalý bunu göstermiþ oldum. 
                 * Burada buton kontrolünün týklama olayýný çaðýrdým, sender ve
                 * e parametrelerine null gönderdim, sadece içindeki kod bloðunun
                 * çalýþmasý yeterli olacak.
                 */
            }
        }
        int adStn;
        //Ad sütunun hangisi olduðunu saklayan deðiþken bir kaç yerde kullanýlacak.
        private void btnEkle_Click(object sender, EventArgs e)
        {
            bool bosmu;
            /* Kullanýcýnýn doldurmasý gereken, boþ kontrol var mý bakacaðým için
             * bool tipinde bir deðiþken tanýmladým.
             */
            BosNesneKontrol(out bosmu);
            /* Bir metodum var, dolmasý gerektiði halde boþ býrakýlan bir nesne 
             * var mý kontrol ediyor. out parametresi ile dýþarý boþ olan nesne 
             * varsa true, yoksa false gönderiyor.
             */
            if (bosmu) return;
            /* Eðer dolmasý gerektiði halde boþ býrakýlan bir kontrol varsa olay 
             * metodu sonlandýrýlacak.
             * Olay metodu sonlanmaz ise alt satýrdan devam edilecek.
             */
            string cinsiyet = Cinsiyeti();
            /* rdbCinsiyet butonuna göre, cinsiyet bilgisini döndüren metodumuzu
             * çaðýrýyoruz
             */
            DateTime tarih;
            /* DateTime yapýsýnýn TryParse metodu ile, MaskedTextBox tipindeki
             * doðum tarihi kontrolünün Text özelliðini kontol edip sonuç true ise
             * deðeri bu deðiþkene atacaðým.
             */
            bool tarihMi = DateTime.TryParse(mskDogTar.Text, out tarih);
            /* MaskedTextBox tipindeki doðum tarihi kontrolüne, tarih girildi ise 
             * tarihMi deðiþkeni için true döner, true döner ise girilen tarih
             * deðeri dýþarý aktarýlýr.
             */
            if (!tarihMi)
            /* tarihMi deðiþkeni true deðilse, yani false ise ve tarih olarak 
             * girilmedi ise 35/18/2020 gibi ise;
             */
            {
                MessageBox.Show
                    ($"{mskDogTar.Text} geçerli deðil.",
                    "Doðru bir tarih biçimi girmelisiniz.");
                /* MaskedTextBox kontrolündeki deðeri )35/18/2020 gibi) ve
                 * mesajý görüntüle.
                 */
                return;
                //Olay metodunu sonlandýr. Sonlanmadý ise alt satýrdan devam edilir.
            }
            string[] lists =
                {string.Empty, tarih.ToString(TarihBicimi),  txtAdSoyad.Text.Trim(),
                cmbDogYeri.Text, chkMedeniHal.Text, cinsiyet};
            /* En sonunda veriyi aktarmak için gerekli kod satýrlarýna gelebildik. 
             * Her satýr hata kontrol kodlarý ile dolu. Daha bir bu kadar, hata 
             * kontrolü gerekiyor, ancak sadece en mühim olanlarýný yazdým. Bir
             * dizi hazýrlýyorum. aktarýlacak elemanlarý diziye aktardým. Her bir
             * sütun baþlýðýna göre olmasý gereken veri sýrasýnda. Ýlk deðer boþ,
             * oraya sýra numarasý eklemek için boþ býraktým. Sonra doðum tarihi
             * ad soyad, medeni hal ve cinsiyet bilgileri var.
             * Trim() metodu metnin sonundaki ve baþýndaki boþluklarý kýrpar.
             */
            ListViewItem lvItem = new(lists);
            txtAdSoyad.Text = txtAdSoyad.Text.Trim().Replace("  ", " ");
            /* ListView kontrolünün her bir satýrý ListViewItem tipindedir. lvItem
             * deðiþkenim için bir instance (örnek) alýyorum. Böylece bu deðiþkene 
             * string[] lists dizisini aktardým. Buraya dikkat ediniz. lists Dizisi
             * aktarýlýyor. Yani ListView verileri deðil. ListView satýrlarý henüz
             * dolmadý. Önce kontrol edelim, kullanýcý ayný ismi bir daha ekliyor 
             * mu? Eðer ayný ismi eklemiyor ise ise Liste kontrolüme aktarýlsýn.
             * Ad Soyad verisini aktarýrken, Trim metodu ile sað ve sol dýþtan
             * olabilecek boþluklarý kaldýrdým. En sonda da kullanýcý, gereksiz yere
             * iki boþluk eklemiþ ise tek boþluk ile deðiþtirdim. Bazý kullanýcýlar
             * bir metin yazar ve nedensiz yere iki defa space tuþuna basar. Sýrf
             * bu boþluk tuþu yüzünden aradýðýnýz metni, ayný veriyi aramanýza
             * raðmen bulamayabilirsiniz, çünkü; B,r aram komutunda Ali  Gel metni
             * ile Ali Gel metni ayný deðildir.
             */
            if (lViKisi.Items.Count > 0)
            {/* ListView kontrolü olan lViKisi nesnesindeki elemanlarýn sayýsý 
              * > 0'dan. Alt satýrdaki döngüye girilir.
              */
                foreach (ListViewItem item in lViKisi.Items)
                /* Bu döngü ile ListViewItem tipindeki döngü deðiþkenim olan item
                 * döngü deðiþkenine lViKisi adlý liste kontrolümün verilerini
                 * aktarýyorum. Böylece, eklenen isim daha önce
                 * eklenmiþ mi bakabilirim.
                 */
                {
                    adStn = Array.IndexOf(basliklar, "Ad Soyad");
                    /* ListViewItem tipindeki döngü deðiþkenim olan item liste 
                     * kontrolüne önceden eklenen bir satýr varsa o satýrýn tümünü
                     * içeriyor. Ancak, bize sadece ayný isim soyisim var mý o lazým. 
                     * Böylece basliklar adlý dizide ad soyad baþlýðýna sahip sütunu 
                     * buluyorum. Aslýnda sütunun 0.1.2. sütun olduðunu biliyorum. 
                     * Ancak, ileride sütunun yerini deðiþtirirsem, 2. sütundan 
                     * önceye bir sütun eklersem program çalýþmaya devam etsin 
                     * istediðim için IndexOf metodunun 2. parametresin sütun
                     * adýný "Ad Soyad" yazýyorum.
                     */
                    if (item.SubItems[adStn].Text == txtAdSoyad.Text)
                    /* Eðer döngü deðiþkeni Alt elemanlarýndan olan [adStn 
                     * deðiþkenindeki] deðer (þu anda 2 çýkýyor) metni eþit ise,
                     * liste kontrolündeki ad soyad metin kutusundaki metne þunlarý
                     * yap: (Yani; Eklenen isim var ise).
                     */
                    {
                        Color sakla = item.BackColor;
                        /* Satýrýn eski rengini sakla, çünkü bu satýrý 
                         * renklendireceðim, sonra yine eski rengine dönmesini 
                         * istiyorum.
                         */
                        item.BackColor = Color.Gold;
                        /* item deðiþkeninin arka plan rengini belirle = Bir metot 
                         * çaðýr adý: RgbRenkUret rengi o metot belirlesin. */
                        MessageBox.Show($"{txtAdSoyad.Text} zaten ekli");
                        //Eklemye çalýþýlan adý ve diðer mesajý göster.
                        item.BackColor = sakla;
                        /* item deðiþkeninin arka plan rengini sakladýðýn ilk hali
                         * olan sakla deðiþkenindeki renge döndür.*/
                        return;
                        //btnEkle olay metodunun tümünden çýk. Yani; ekleme yapma.
                    } //Eklenen ad soyad metni var ise çalýþan if bloðu sonu.
                } //foreach scope (kapsam) bitiþi.
            } //lViKisi.Items.Count > 0 yazýlan if scope (kapsam) bitiþi.
            /*if (lViKisi.Items.Cast<ListViewItem>().Where
                (x => x.SubItems[adStn].Text.Contains(txtAdSoyad.Text)).Count()> 0)*/
            /* Bu kadar satýr kod (foreach (ListViewItem item in lViKisi.Items) 
             * döngüsü) yerine LINQ, Lambda Expression ifadesinin kod  satýrýný 
             * yazmanýz yeterli olur. Yani; lViKisi kontrolü elemanlarýný 
             * Cast et <ListViewItem tipine çevir> (ve metot parantezlerini kapat)
             * .Where ile Koþul bildiriyorum (ListViewItem.SubItems[ad sütunu] 
             * deðerine bak) txtAdSoyad kontrolünde yazan metin, ListViewItem 
             * tipindeki x deðiþkeninde var mý? Sonra çýkan sonucu say > 0 
             * sýfýrdan büyük mü? Yani Ad soyad deðeri listede var mý? Var ise
             * .Count deðeri sýfýrdan büyük çýkar. if için true deðeri döner.
             * Deðilse false dönecektir. Kýsaltma derken arkaplan rengi kodlarý 
             * ve return ifadesini de eklemeniz gerekiyor. Ben her iki yazým
             * þeklini de anlatmýþ olayým.
             */
            lViKisi.Items.Add(lvItem);
            /* Eðer tüm return ifadelerinden geçerse veriyi eklesin. Veri lvItem
             * deðiþkeninde.
             */
            BackColor = RgbRenkUret();
            /* Sadece Forma bir arkaplan nasýl eklenir, bunu anlatmak için bir renk 
             * atamasý yapan metot kullandým.
             */
            foreach (Control item in pnlGrup.Controls)
            /* Bu döngüde form kontrollerinde nasýl dönülür buna örnek olsun. Sadece
             * kontrol etmek istediðim kontrolleri üzerinde rahatça dönebilmek için
             * forma bir panel ekleyip, boþ kontrolü yapmak istediðim nesneleri bu 
             * panele aldým. Böylece Control tipindeki item deðiþkenim, Panel 
             * kontrolünün içindeki kontrollerde dönecek. Eðer pnlGrup. olmasa idi 
             * tüm kontrollerde dönerdi ki, bu þu anki durumda iþimize yaramazdý.
             */
            {
                item.BackColor = RgbRenkUret();
                /* Kontrollere arkaplan rengi ata = Otomatik renk üreten metodu
                 * çaðýr.
                 */
            }//Formun arkaplaný ve panel kontrolündeki nesnelerin arkaplaný ayný renk.
            if (lViKisi.Items.Count % 2 != 0) lvItem.BackColor = RgbRenkUret();
            /* Burada da bir renk atamasý var, ancak bir satýr renksiz, bir satýr 
             * renkli olacak. Her tek satýr beyaz, çift satýr farklý renk olur.
             */
            btnSil.Enabled = lViKisi.Items.Count > 0;
            /* Listeden kiþi silmek için, ListView kontrolünde eleman olmasý gerekir.
             * Form yüklenirken, içinde eleman olmayacaðý için, Silme butonu pasif
             * olarak ayarlanýyor. Eklendikçe de aktif olmasýný saðlýyorum. Þöyle
             * ListView kontrolü olan lViKisi elemanlarýný say > büyük mü sýfýrdan,
             * eðer sýfýrdan büyük ise btnSil.Enabled = true olur, böylece butona
             * týklanabildiði için silme iþlemi yapan kod bloðu çalýþabilir.
             */
            if (lViKisi.Items.Count > 6)
            /* Listenin formdaki eleman adedi, 6. Eleman eklendikçe eleman adedi
             * aþýlýyorsa formun ve listenin yüksekliðini bir liste satýrý kadar
             * artýrmak istiyorum. 15 elemanýmýz var, ayný veriyi tekrar eklemeyen
             * bir kod yazdýðýmýzdan, liste ve form yüksekliði en fazla 9 eleman
             * kadar daha artar. Yani; From ve listemiz aþýrý büyümez.
             */
            {
                int rowH = lViKisi.Height / lViKisi.Items.Count;
                /* ListView kontrolünde satýr yüksekliði özelliði yok. Bende listenin
                 * yüksekliðini, içeriðindeki eleman sayýsýnda böldüm, yaklaþýk bir
                 * satýr yüksekliði elde ettim. 
                 */
                lViKisi.Height += rowH;
                //Liste yüksekliðini artýrdým.
                Height += rowH;
                //Formun yüksekliðini artýrdým.
            }
            SatirNo(lViKisi);
            /* lViKisi.Items.Add(lvItem) kodu ile elemanlarý listeye eklemiþtim. 
             * Hatýrlarsanýz ilk sütun string.empty olarak atanmýþtý, sütuna
             * numara atamasý yapan metot yazmýþtým, onu çaðýrdým. numara atamasý
             * yapan metodu alt satýrda inceleyeceðiz. Bu metot parametre
             * olarak ListView kontrolü alýyor.
             */
        }
        public Color RgbRenkUret(byte i = 230, byte j = 250)
        /* Bu metot geriye Color tipinde deðer döndürüyor. Adý: RgbRenkUret. 
         * Parametre olarak byte tipinde i ve j adlý iki deðiþken alýyor. Bu 
         * aralýklarda renk üretecek, RGB 230,250 arasýndaki renkler flu ve
         * hoþ duruyor, bu yüzden parametreye 230,250 deðerlerini gönderdim.
         * Eðer kullanýcý parametre göndermezse renkler bu aralýkta üretilecek.
         * Renk aralýklarý 0,255 arasýnda olduðu için byte tanýmladým.
         */
        {
            Random rnd = new();
            /* Random sýnýfýndan bir instance (örnek) alýyorum. Bu metot rasgele
             * sayý üretecek. Henüz üretmeye baþlamadý. Sadece hazýr.
             */
            return Color.FromArgb
                (rnd.Next(i, j + 1), rnd.Next(i, j + 1), rnd.Next(i, j + 1));
            /* Renklerin Kýrmýzý, Yeþil ve Mavi deðeri için renk kodu üreteceðim. 
             * Random sýnýfý tipindeki rnd deðiþkeninin Next metodu ile i ve j
             * deðerleri arasýnda bir renk kodu üretiliyor, bu kod; opsiyonel
             * parametreden dolayý 230,250 arasýnda olabilir. Tabii ki metoda 
             * parametre olarak farklý bir i ve/veya j deðeri gönderilmezse.
             * +1 niye yazdým? Random üretilen sayýlarda, parametreye sunulan 
             * ikinci sayýnýn kendi deðerine kadar üretildiði, dahil olmadýðý
             * konusuna dikkat çekmek istiyorum. Böylece tahminen þöyle bir deðer
             * oluþacak. Color color = Color.FromArgb(235, 240, 250)
             */
        }
        public void SatirNo(ListView lvi)
        /* Bu metot void (deðer döndürmez). Parametre olarak ListView tipinde bir
         * deðiþken alýyor.
         */
        {
            int sno = Array.IndexOf(basliklar, "S.No");
            /* int tipinde sno deðiþenine atama yapýyorum. Array sýnýfýnýn IndexOf 
             * metodu ile aradýðým veriyi içeren Dizi elemanýnýn numarasýný alacaðým.
             * Böyle Sýra No sütununa Sýra Numarasý yazabileceðim.
             */
            int sayac = 0;
            /* foreach döngüsünde, for döngüsündeki gibi döngü sayacý yoktur. Döngüde 
             * satýr numarasýný yazabilmek için bir sayaç lazým olacak, döngü içinde
             * ++sayac yazacaðým için, döngünün her dönüþünde 1,2,3 þeklinde artacak.
             * ++sayac yazdýðýmda sayac önce artacaðý için, ilk deðeri 1 olacak.
             * Bu konuyu Aritmetiksel Ýþlem Önceliði baþlýðýnda iþlemiþtim. Þöyle
             * yazmýþtým: Deðiþkene deðer atanmadan önce artýrým/azaltým iþlemi. 
             * Örnek: ++x , --x. Þimdi bu bilgi lazým oldu.
             */
            foreach (ListViewItem item in lvi.Items)
            /* ListViewItem tipindeki döngü deðiþkenimizin adý: item. item deðiþkeni
             * parametresine sunulan ListView kontrolü olan lvi deðiþkeninin 
             * elemanlarýnda (satýrlarýnda) dönecek.
             */
            {
                item.SubItems[sno].Text = (++sayac).ToString("00");
                /* ListViewItem tipindeki deðiþkenin SubItems özelliði sütunlarý
                 * ifade ediyor. [sno] ise sütunun Sýra Numarasý için atadýðýmýz
                 * veri olmasýný kesinleþtiriyor. Text özelliðine atama yapýyoruz.
                 * sayac deðiþkeni bizim için sýra numarasý üretecek, döngünün her 
                 * dönüþünde bir artacak. 
                 */
            }
        }
        private void dteDogTarihi_ValueChanged(object sender, EventArgs e)
        //DateTimePicker kontrolünün her deðiþiminde bu olay metodu çalýþýr.
        {
            mskDogTar.Text = dteDogTarihi.Value.ToString(TarihBicimi);
            /* Doðum tarihi için kullandýðýmýz MaskedTextBox kontrolüne deðer ata 
             * DateTimePicker kontrolü olan dteDogTarihi kontrolünün, içeriðini
             * TarihBicimi formatýna çevir ve MaskedTextBox kontrolüne gönder.
             * Doðum tarihi ile ilgili iki kontrol (controls) var: 1. control:
             * MaskedTextBox, Adý: mskDogTar. 2. conrol: DateTimePicker,
             * Adý: dteDogTarihi.
             */
        }
        private void lBoxIller_Click(object sender, EventArgs e)
        //ListBox kontrolünün týklanmasýnda çalýþan olay
        {
            cmbDogYeri.Text = lBoxIller.Text;
            /* Doðum yeri ile ilgili iki kontrol (controls) var: 1. control:
             * ComboBox, Adý: cmbDogYeri. 2. control: ListBox, Adý: lBoxIller.
             * lBoxIller_Click týklanmasý ile çalýþan olay metodunda þunlarý
             * yap. cmbDogYeri kontrolünün metin özelliðine atama yap =
             * lBoxIller kontrolünün metin özelliðindeki deðeri ata.
             */
        }
        private void chkMedeniHal_CheckedChanged(object sender, EventArgs e)
        /* chkMedeniHal_CheckedChanged olay metodu: CheckBox kontrolünün deðiþiminde
         * çalýþýr. Bu kontrolün iki durumu var: 
         * 1.durum Týklanmýþtýr: Checked=true olur.
         * 2.durum Týklanmamýþtýr: Checked=false olur.
         */
        {
            MedeniHalCheck(sender as CheckBox);
            /* MedeniHalCheck adlý bir metot bu kontrolün durumunu deðiþtirecek. 
             * Parametresine CheckBox tipinde bir kontrol olan chkMedeniHal 
             * kontrolünün object tipindeki sender parametresini gönderiyorum. Bu 
             * parametre ile týklanan nesnenin kendisini parametre olarak dýþarý
             * gönderebilirsiniz.
             */
        }
        private void MedeniHalCheck(CheckBox chkBox)
        /* Bu metot deðer döndürmüyor. Adý: MedeniHalCheck. Parametre olarak
         * CheckBox tipinde bir parametre alýyor.
         */
        {
            chkBox.Text = chkBox.Checked //Burasý sorgulanan kýsým
                ? //Burasý true ise çalýþan kýsým
                Enum.GetName(typeof(MedeniHal), (int)MedeniHal.Evli)
                : //Burasý false ise çalýþan kýsým
                Enum.GetName(typeof(MedeniHal), (int)MedeniHal.Bekar);
            /* CheckBox tipli chkBox deðiþkeninin metin özelliðine atama yap = 
             * týklanmýþ ise Evli, týklanmamýþ ise Bekar deðerini ata.
             */
        }
        private string Cinsiyeti()
        //string tipinde deðer döndüren Cinsiyeti adlý metot.
        {
            if (rdbBay.Checked)
            //Eðer RadioButton tipindeki rdbBay týklanmýþ ise
            {
                return Enum.GetName(typeof(Cinsiyet), (int)Cinsiyet.Bay);
                /* Enum adýný döndüren GetName metodunu çaðýrýyorum. Ýlk parametre
                 * Enum’un tipini, ikinci parametre deðerini istiyor. Cinsiyet adlý 
                 * enum listesinin, Bay elemanýnýn enum adýný döndür.
                 */
            }
            else if (rdbBayan.Checked)
            //Eðer RadioButton tipindeki rdbBayan týklanmýþ ise
            {
                return Enum.GetName(typeof(Cinsiyet), (int)Cinsiyet.Bayan);
                /* Enum adýný döndüren GetName metodunu çaðýrýyorum. Ýlk parametre
                 * Enum’un tipini, ikinci parametre deðerini istiyor. Cinsiyet adlý 
                 * enum listesinin, Bayan elemanýnýn, enum adýný döndür.
                 */
            }
            return string.Empty;
            //Ýkisi de týklanmamýþ ise Boþ deðer döndür.
            /* rdbBay ve rdbBayan adlý RadioButton bir GrupBox içindeler. Böylece 
             * sadece biri týklanabilir.*/
        }
        private void BosNesneKontrol(out bool bosVarmi)
        /* Bu metot void (deðer döndürmez). Deðer döndürmez ama, out kullanýrsanýz bir
         * deðeri dýþarý gönderebilirsiniz. bool tipinde bosVarmi deðiþkenini dýþarý
         * aktarmak üzere parametreye ekle.
         */
        {
            bosVarmi = false;
            //bool bosVarmi deðiþkeninin ilk deðeri boþ yok.
            string boslar = "Nüfus bilgileri eklenemiyor.\n";
            //Bu deðiþkeni, boþ olan nesneleri listelemek için tanýmladým.
            foreach (Control item in pnlGrup.Controls)
            /* Kontrol etmek istediðim kontrollerin üzerinde rahatça dönebilmek için
             * forma bir panel ekleyip, boþ kontrolü yapmak istediðim nesneleri bu 
             * panele aldým. Böylece Control tipindeki item deðiþkenim, Panel 
             * kontrolünün içindeki kontrollerde dönecek. Eðer pnlGrup. olmasa idi 
             * tüm kontrollerde dönerdi ki, bu þu anki durumda iþimize yaramazdý.
             */
            {
                if (item.Text == string.Empty)
                //Eðer kontrol metni boþ ise if bloðuna in.
                {
                    if (item is CheckBox) continue;
                    /* Eðer, item kontrolü CheckBox ise atla. Çünkü CheckBox false 
                     * ise boþ görünür. Hâlbuki false olmasý bizim kodumuza göre 
                     * Bekar seçimini ifade eder.
                     */
                    if (item is GroupBox)
                    /* Eðer item kontrolü GroupBox ise (Bay veya Bayan seçeneði için)
                     * bir kontrol yazýyorum. Bu RadioButton kontrollerinden biri 
                     * mutlaka seçili olmalýdýr
                     */
                    {
                        if (!rdbBay.Checked && !rdbBayan.Checked)
                        //rdbBay týklanmadý ise ve rdbBayan týklanmadý ise
                        {
                            boslar += "Cinsiyet Bilgisi Yok\n";
                            //boslar deðiþkenine þu metni ekle ve \n alt satýra in.
                            bosVarmi = true;
                            /* out olarak gönderilecek olan bosVarmi deðiþkenine true
                             * deðerini ata
                             */
                        }
                    }
                    else
                    /* if satýrýnda ne yazýyor? if (item is GroupBox), else ise þu 
                     * demek: if (item is GroupBox) olmayanlar
                     */
                    {
                        boslar += item.Name + "\n";
                        /* boþ olan item kontrolünün adýný yaz ve \n ile bir alt 
                         * satýra in*/
                        bosVarmi = true;
                        /*out olarak gönderilecek olan bosVarmi deðiþkenine true
                         * deðerini ata*/
                    }
                }
            }
            if (bosVarmi == true)
                //Eðer boþ nesne var ise bu bloða in
                MessageBox.Show(boslar, "Bazý Nesneler Boþ Býrakýlmýþ");
            //Tek satýrlý if bloklarýnda {} kullanmasanýz da olur.
        }
        private void txtAdSoyad_KeyPress(object sender, KeyPressEventArgs e)
        /* TextBox kontrolünün klavye tuþlarýna basýldýðýnda çalýþan olayý iki 
         * parametre alýr. 1. Parametre: object tipinde ve adý sender. Bu parametre
         * TextBox kontrolünü içerir, 2. Parametre: KeyPressEventArgs tipinde ve 
         * adý: e. Bu parametre TextBox kontrolünün basýlan tuþunu içerir.
         */
        {
            e.Handled = KlavyeTusÝzni(txtAdSoyad, e, false);
            /* Tüm KeyPressEventArgs döndüren olay metotlarýnýn, kontrolünde
             * klavye tuþ vuruþlarýný kontrol edebilen bu metodu kullanabilirsiniz.
             */
        }
        public char OndalikAyrac()
        //Bu metot char tipinde sistem ondalýk karakterini döndürecek.
        {
            return char.Parse(CultureInfo.CurrentCulture.
                NumberFormat.NumberDecimalSeparator);
            //Kullanýlan sistemin diline göre ondalýk ayraç bulunuyor.
        }

        private bool KlavyeTusÝzni
            (Control sender, KeyPressEventArgs e, bool StrNum = true)
        /* Bu metot KeyPressEventArgs tipinde ve e adýnda bir parametre alýyor.
         * Birde numerik bir deðer mi yoksa metinsel bir deðer mi gireceksiniz?
         * Bunu parametreye sunmanýz gerekiyor. Eðer sayýsal ise true alýyor.
         * Opsiyonel olan bu parametre varsayýlan olarak true deðer içeriyor.
         * Yani; Parametreye deðer gönderilmezse, metodu kullanan kontrole
         * sadece sayý ve virgül girilebilir.
         */
        {
            if (StrNum)
            //Eðer StrNum true ise bu if bloðuna in.
            {
                bool araVirgul = !sender.Text.Contains(OndalikAyrac());
                /* Sayýsal bir veri grubunda virgül bir defa geçer. Neden ondalýk 
                 * ayracýn virgül olduðunu bildiðim halde birde OndalikAyrac metodunu
                 * yazdým? Çünkü; Ýngilizce Windows kullanalar olabilir, onlarda 
                 * ondalýk ayraç nokta, binlik ayraç virgül olur.
                 */
                e.Handled =
                !(char.IsDigit(e.KeyChar) ||
                e.KeyChar == (char)Keys.Back || e.KeyChar == OndalikAyrac() &&
                araVirgul);
                /* e.Handled false olduðunda veri girilebilir.
                 * Sadece numerik veriler, BackSpace tuþu, ondalýk ayraç
                 * girilebilir. Virgül sadece bir kez girilebilir.
                 */
            }
            else
            {
                e.Handled =
                char.IsDigit(e.KeyChar) ||
                !char.IsUpper(e.KeyChar) && !char.IsLower(e.KeyChar) &&
                !char.IsWhiteSpace(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back;
                /* Sadece, büyük harfler, küçük harfler, boþluk tuþu ve
                 * BackSpace tuþu kullanýlabilir.*/
            }
            return e.Handled;
            /* Sonuç true veya false olarak geri döner. Böylece izin verilir
             * izin veya verilmez.
             */
        }
        private void txtAdSoyad_Click(object sender, EventArgs e)
        {//TextBox týklama olayý.
            txtAdSoyad.SelectAll();
            //Kontrole týklandýðý anda tüm metni seç.
        }

        private void mskDogTar_Click(object sender, EventArgs e)
        {//MaskedTextBox týklama olayý.
            mskDogTar.SelectAll();
            //Kontrole týklandýðý anda tüm metni seç.
        }

        bool tikla;
        /* Bu deðiþken ile butona týklama olayýný deðiþtireceðiz. Yani
         * týklandý ise týklanmadý, týklanmadý ise týklandý gibi iþlem yapacaðýz.
         */
        private void btnSutun_Click(object sender, EventArgs e)
        //Sütun geniþliklerini bu buton ile ayarlayacaðýz.
        {
            tikla = !tikla;
            /* Eðer tikla true ise tersi olan false, false ise tersi olan true
             * oluyor. Yani; Her týklamada ya true olur, ya da false.
             */
            lViKisi.AutoResizeColumns(tikla ?
                ColumnHeaderAutoResizeStyle.HeaderSize :
                ColumnHeaderAutoResizeStyle.ColumnContent);
            /* Eðer tikla deðiþkeni true ise, verileri baþlýk deðerlerine göre 
             * (HeaderSize), false ise sütundaki verilere (ColumnContent) göre
             * geniþlik ayarlanacak. Böylece bir kez týklanýnca HeaderSize, diðerinde
             * ColumnContent kullanýlacak. Önceki derslerimizde, deðiþkenlerin 
             * varsayýlan deðerlerinden bahsetmiþtim. Default bool: False þeklinde
             * bir çýktý sunan bir konsol projemiz vardý ve belki bu ne iþime yarar 
             * ki demiþsinizdir? Ýþte cevabý: Sütun geniþliði butonuna ilk kez 
             * týklanýnca, sütun geniþlikleri: HeaderSize deðerine göre mi yoksa 
             * ColumnContent deðerine göre mi yapýlýr? Cevap: Default bool: false
             * olduðundan tikla deðiþkeninin ilk deðeri false olur böylece:
             * tikla = !tikla; tikla = !false, true olur. Þu ana kadar anlattýðým
             * her kod parçasý proje yaparken mutlaka lazým olacaktýr, boþ bilgi 
             * olarak görmemek gerekir, bu gün lazým olmaz, yarýn gerekebilir.
             */
        }
        private void btnSil_Click(object sender, EventArgs e)
        //Satýr silme butonu týklama olayý.
        {
            if (lViKisi.SelectedIndices.Count <= 0)
            /* Seçili öðenin indeks (dizin) deðeri küçük veya eþit ise 0'a. Veri 
             * seçimi yapýlmamýþ ise
             */
            {
                MessageBox.Show("Listeden neyi silmemi istiyorsanýz seçmelisiniz.");
                //Mesaj kutusunu göster
                return;
                //Metodun tümünde çýk.
            }
            if (lViKisi.Items.Count > 0 && lViKisi.SelectedIndices.Count > 0)
            /* Eðer liste elemanlarýnýn adedi 0'dan büyükse ve seçili elemanlarýn 
             * adedi 0'dan büyükse bu if bloðuna in. liste elemanlarýnýn adedi 0'dan
             * büyük olduðunda, listede eleman olduðu anlaþýlýr, ama bu silinecek
             * elemanýn seçildiði anlamýna gelmemektedir. bu nedenle SelectedIndices
             * ile seçili eleman olup olmadýðýna bakýyoruz.
            */
            {
                //Bu döngüde amaç seçili olan satýrlarýn silinmesi.
                for (int i = lViKisi.Items.Count - 1; i >= 0; i--)
                /* for döngüsü yazýyorum. Döngü deðiþkeni olan i int tipindedir.
                 * Döngü, i deðeri liste eleman sayýsýndan baþlayýp (1 çýkarýyoruz) 
                 * 0'dan büyük veya eþit olduðu sürece dönüyor. Bu döngü küçükten
                 * büyüðe doðru deðil, büyükten küçüðe doðru çalýþýyor, neden? Çünkü;
                 * satýr silindikçe i deðiþkeni deðeri azalýyor, ya döngüyü küçükten
                 * büyüðe doðru doðru yazýp, eksilen satýr için i-- yazarsýnýz ya da
                 * döngüyü tersten çalýþtýrýp silinen en büyük satýr deðerinden 
                 * geriye doðru gittiðiniz için i-- yazmanýza gerek kalmaz. 
                 */
                {
                    if (lViKisi.Items[i].Selected) lViKisi.Items[i].Remove();
                    /* Eðer lViKisi elemanlarýndan [i] dizin/indeks deðerine sahip 
                     * eleman seçili ise þunu yap: lViKisi elemanlarýndan [i] 
                     * dizin/indeks deðerine sahip elemaný kaldýr.
                     */
                }
                for (int i = 0; i < lViKisi.Items.Count; i++)
                /* Yukardaki döngünün aynýsý, tek farký alýþtýðýmýz gibi yazýlmýþ 
                 * olmasý, küçükten büyüðe doðru çalýþýyor.
                 */
                {
                    if (lViKisi.Items[i].Selected)
                    {
                        lViKisi.Items[i].Remove();
                        i--;
                        /* Silme iþleminden sonra silinen satýrý aradan çýkarmak 
                         * adýna artmýþ olan i deðerini azaltýyorum. Yani þöyle: 5 
                         * satýr olsun ve sadece örnek anlaþýlsýn diye ilk satýrýn 
                         * deðeri 1. satýr ile ifade edilsin. Þimdi 5,3,2 
                         * satýrlarýný silersem; (1 ve 4 kalacak.)
                         * 1. Satýr: Dur: i++ ile i=1
                         * 2. Satýr: Sil: i++ ile i=2. 
                         * Burada i silinince satýr sayýsý da otomatik olarak 1 
                         * azalýyor, ama döngü i deðeri artýyor. Bu durumda i--
                         * yazýp, döngü i deðerini azalttýðým için, satýr sayýsý 
                         * da azalýyor. 
                         * 2. Satýr: i-- ile i=1
                         * 3. Satýr: Sil: i++ ile i=2. 
                         * Burada i deðeri 2'ye düþüyor. Böylece 2. satýr artýk 
                         * olmadýðý için 3. satýrý, 2. satýr olarak siliyorum.
                         * tekrar i-- çalýþýyor.
                         * 3. Satýr: Sil: i-- ile i=1.  
                         * 4. Satýr: Dur: i++ ile i=2 oldu. Burada silme 
                         * olmadýðý için i-- yok. i=2 olarak kaldý.
                         * 5. Satýr: Sil: i++ ile i=3 oldu ancak bu satýrý sildiðim
                         * için i-- ile i deðeri tekrar 2 oldu ve sadece 1. ve 4. 
                         * satýr kaldý.
                         */
                    }
                }

                if (lViKisi.Items.Count > 0)
                    lViKisi.Items[lViKisi.Items.Count - 1].Selected = true;
                /* Tek satýrlý bir iþlem yaptýrmak istediðiniz if bloðunun 
                 * {parantezlerini} eklemeseniz de olur. Eðer silme iþleminden sonra
                 * hala bir satýr kalmýþ ise. Liste elemanlarý 0'dan büyük ise;
                 * Liste elemanlarýndan [Liste elemanlarýný say -1 çýkar ve bu 
                 * indeks deðerine sahip satýrý] seç. Yani son eleman seçili olsun.
                 */
                btnSil.Enabled = lViKisi.Items.Count > 0;
                /* Silme iþlemi yapan butonun etkin olma durumuna atama yap (true 
                 * veya false olabilir). Eðer liste elamanlarýnýn sayýsý sýfýrdan 
                 * büyük ise > 0 true döner, deðilse false döner. Böylece eleman
                 * kalmadý ise, silinecek eleman da olamayacaðýndan etkin deðil
                 * olarak ayarlanmýþ olur, böylece týklanamaz.
                 */
            }
        }
        private void lViKisi_ColumnClick(object sender, ColumnClickEventArgs e)
        /* Listenin, sütun týklanma olayýna kod yazýyorum. Bu olay metodu, sütun
         * baþlýklarýna týklandýðýnda çalýþýr. týklanan sütunun hangisi olduðunu
         * lViKisi_ColumnClick olay metodunun, ColumnClickEventArgs parametresi
         * e adlý deðiþkende tutar.
         */
        {
            if (e.Column == columnSort.e)
            //Eðer týklanan sütun ile, sýralanacak sütun ayný ise bu bloða in
            {
                columnSort.sortStatus = columnSort.sortStatus == SortOrder.Ascending
                    ?
                    columnSort.sortStatus = SortOrder.Descending
                    :
                    columnSort.sortStatus = SortOrder.Ascending;
                //Sýralama her týklamada bir artan, diðer týklamada azalan olsun.
            }
            else
            {
                columnSort.e = e.Column;
                columnSort.sortStatus = SortOrder.Ascending;
                /* Ýlk sýralamada sýralanan sütun ile týklanan sütun ayný olur ve bu
                 * else bloðuna inilir. Varsayýlan bir sonraki ilk sýralama deðeri 
                 * için Ascending atadým.
                 */
            }
            lViKisi.Sort();
            /* Artýk listeyi sýralayabiliriz. Þimdi de Sýralama yapan ColumnSort 
             * sýnýfýný açýklamak gerekiyor.*/
        }
    }
}