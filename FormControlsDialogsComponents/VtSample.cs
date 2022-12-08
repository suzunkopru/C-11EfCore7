using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Windows.Forms.DataVisualization.Charting;

namespace FormControlsDialogsComponents
{
    public partial class VtSample : Form
    {
        public VtSample()
        {   //Formun adý VTSample.
            InitializeComponent();
            //Burasý standart olarak oluþan kurucu metot.
        }
        /* Bu tanýmlarýn yapýldýðý yer Ýsim Alanýdýr (NameSpace Scope). Eðer hiçbir
         * Metot veya Özelliðin içinde deðilseniz Ýsim Alanýný (NameSpace Scope)
         * kullanýyorsunuz demektir. Genelde bu alanda tanýmlanan deðiþkenler tüm
         * isim alanýnda kullanýlmasý istenen deðiþkenlerdir. Burada tanýmladýðým
         * deðiþkenler bu kapsamda (scope) birden fazla metot içinde lazým oldular.
         * Baþka bir sýnýfta kullanmayý düþünmediðim için eriþim belirtecini
         * private olarak belirledim. Bu belirleme neticesinde artýk birer özellik
         * (property) deðil alan (field) olarak görev yapacaklar. Dýþarýdan bir
         * sýnýftan atama yapýlamayacak. C# zorunlu olmayan yazým kaideleri gereði
         * alanlar (fields) _deðiþkenAdi þeklinde adlandýrýlýrlar.
         */

        #region Burasý, sýnýf (class) için genel kullanýma açýk deðiþkenler
        private DataTable _dataTable;
        /* SQL Tablosundan veri çekip DataTable tipindeki _dataTable deðiþkeninde
         * saklayacaðým.
         */
        private BindingSource _bindingSource;
        /* SQL Tablosundan veri çekip DataTable tipindeki _dataTable deðiþkeninden
         * bindingSource deðiþkenine aktaracaðým.
         */
        private DataGridView _dataGridView;
        /* DataGridView: SQL Tablosundan çekilen verileri görüntülemek üzere
         * tasarlanmýþ bir kontroldür. Izgaralar içerisine yerleþtirilmiþ satýr
         * ve sütunlarý vardýr.
         */
        private NotifyIcon _notifyIcon;
        // Bilgi ikonu kontrolü tanýmladým.
        private ToolStripComboBox _toolStripComboFilter, _toolStripComboBox;
        /* ToolStripComboBox tipinde 2 deðiþkenim var. ToolStripComboBox bileþeni
         * (Component) bir ComboBox kontrolü deðildir, çok benziyor ancak tipleri
         * ayný deðil. ComboBox özellikleri gösteren bir bileþendir (Component).
         * ToolStripComboBox StatusStrip bileþenine (Component) eklemek amacý
         * ile kullanýlacaktýr
         */
        private ToolStripStatusLabel _toolStripStatusLabel, _toolStripLabel;
        /* ToolStripStatusLabel tipinde 2 deðiþkenim var. ToolStripStatusLabel
         * bileþeni (Component) bir Label kontrolü deðildir. Label özellikleri
         * gösteren bir bileþendir (Component). ToolStripStatusLabel StatusStrip
         * bileþenine (Component) eklemek amacý ile kullanýlacaktýr
         */

        private int _yukseklik;
        /* Form yüklenirken ileride gerekli olacak form yüksekliði bilgisini
         * saklýyoruz. Filtreli form yüksekliðini forma göre deðiþtirdikten
         * sonra, filtreleme iþleminden vazgeçilirse form eski yüksekliðine
         * dönebilecek. Formun ilk yüksekliðine dönmesi için bu deðeri
         * kullanacaðým.
         */
        private StatusStrip _statusStrip;
        private BindingNavigator _bindingNavigator;
        /* Bu iki kontrolün bu sýnýfýn her yerinde kullanýlabilmesi gerekmiyordu
         * ancak yine de bu sýnýf için global olan alanda tanýmladým. Formun 
         * yükseklik deðerine etki ettikleri için, filtrelenen verilere göre
         * yükseklik deðeri bulurken bu kontrollerin yükseklik deðerleri lazým
         * olacak.
         */

        //Not: Direk yazýlan (this. yazmadan) her özellik atamasý Forma yapýlýr.
        #endregion Burasý, sýnýf (class) için genel kullanýma açýk deðiþkenler

        private void VTSample_Load(object sender, EventArgs e)
        {/* Burasý Formun yüklenmesi ile çalýþan bir olay metodu. Bu metot formun
          * yüklendiðini anlar ve Load olayý gerçekleþtiðinde otomatik olarak
          * çalýþýr.
          */
            #region Formun Özellikleri
            WindowState = FormWindowState.Normal;
            /* Form penceresinin nasýl görüntüleneceðini ifade eder. Form ekraný
             * kaplayabilir Maximized özelliði. Form simge durumuna küçültülebilir
             * Minimized özelliði. Form varsayýlan boyutta (Normal) görüntülenir.
             */
            FormBorderStyle = FormBorderStyle.FixedSingle;
            /* Formun kenarlýk stilini belirliyorum. Eðer FormBorderStyle enum
             * listesinden FixedSingle seçilirse, form yeniden boyutlandýrýlamaz.
             * Sizable seçilirse form boyutlandýrýlabilir.
             */
            Left = Top = 0;
            //Formun Windows'a göre Sol ve Üst kenardan uzaklýk deðeri 0 olsun.
            Size = Screen.PrimaryScreen.WorkingArea.Size;
            /* Formun boyutu = Screen sýnýfýnýn, birincil ekraný, çalýþma boyutu
             * ile ayný olsun. Bendeki size deðeri 1.920x1.040 çýkýyor, çünkü
             * Windows görev çubuðu boyutu 40, böylece 1920x1080 tamamlanmýþ
             * oluyor. Formumuz görev çubuðunu kapatmamýþ oluyor.
             */
            _yukseklik = Size.Height;
            /* Form yüklenirken ileride gerekli olacak form yüksekliði bilgisini
             * saklýyoruz. Böylece filtreli form yüksekliði forma göre deðiþtiðinde
             * eski boyutunu bu deðiþkenden alacaðým. Filtreleme iþlemi iptal
             * edilince de, bu deðiþkendeki deðer sayesinde form eski yüksekliðine
             * dönebilecek.
             */
            ShowInTaskbar = false;
            //Form, Görev Çubuðunda bir simge olarak görünmesin.
            AutoScroll = true;
            /* Formda, eðer gerekli oldu ise otomatik olarak kaydýrma çubuðu
             * görünsün. Nasýl gerekli olur? Formdaki bir kontrol, mesela bizdeki
             * DataGridView kontrolü gibi, formdan daha uzun ise dikey, daha geniþ
             * ise yatay kaydýrma çubuðu "AutoScroll = true;" kodu sayesinde
             * otomatik olarak görünür.
            */
            #endregion Formun Özellikleri Tanýmlandý

            #region SQL Server Baðlantýsý ve DataTable
            SqlConnectionStringBuilder builder = new();
            /* Henüz SQL Server konusuna sýra gelmedi ama, DataGridView kontrolü
             * en güzel, SQL Tablolarý ile anlatýlýyor. Ýhtiyaç kadarýný anlatayým.
             * SqlConnectionStringBuilder sýnýfýndan bir örnek alýyoruz. SQL Server
             * ile baðlantý saðlayacaðým. Atýk builder deðiþkeni
             * SqlConnectionStringBuilder sýnýfýnýn bir örneðini ifade ediyor.
             * Bu deðiþken vasýtasý ile server baðlantýsý için bir baðlantý cümlesi
             * oluþturacaðým.
             */
            string BilgisayarAdi = Environment.MachineName;
            /* Environment sýnýfý mevcut platform ile ilgili bilgiler içeren bir
             * sýnýftýr. Ben SQL baðlantýsý için makine adýný alýyorum.
             */
            builder.DataSource = BilgisayarAdi;
            /* Eðer sizde benim gibi kendi bilgisayarýnýza kurduðunuz bir SQL
             * Server ile baðlantý yapacaksanýz; localhost veya nokta (.)
             * ifadelerini de kullanabilirsiniz. Ben Bilgisayar Adýný nasýl
             * bulursunuz örnek yapmak istedim. DataSource özelliðine BilgisayarAdi
             * deðiþkenini atadým. Buraya geçerli bir IP deðeri de yazýlabilir.
             * Bende kurulu olan SQL Server yerel bilgisayarýmda. Sizde de böyle
             * ise, dileyen localhost, dileyen nokta (.), dileyen de bilgisayar
             * adýný yazabilir.
             */
            builder.InitialCatalog = "Northwind";
            //InitialCatalog özelliðine veritabanýnýn adýný atadým.
            builder.UserID = "sa";
            /* SQL Kullanýcýsý = "sa", bu ad "sa" SQL Server standardý. Bir SQL
             * kullanýcý adý. Server Administrator (Veritabaný Yöneticisi) anlamýna
             * geliyor. Tüm yetkilere sahip bir kullanýcý. Eðer SQL Server üzerinde
             * deðerli bilgileriniz var ise sa kulanýcýsý tümüne eriþebilir,
             * silebilir, deðiþtirebilir.
             */
            builder.Password = "123";
            //Bendeki SQL þifresi.
            //builder.IntegratedSecurity = true;
            /* SQL Server baðlantýsý yaparken, kullanýcý adý ve þifre  ile sisteme
             * giriþ yapabileceðiniz gibi, Windows kullanýcýsý ile de giriþ
             * yapabilirsiniz. Bunu saðlayan özellik IntegratedSecurity
             * özelliðidir. Madem Windows kullanýcýsý ile de giriþ yapýlýyor, niçin
             * SQL kullanýcý adý ve þifresi ile giriþ yapan kodu yazdým? Çünkü bir
             * server üzerinde iseniz ve Active Directory sistemi kurulu ise
             * yetkiniz de yok ise SQL Server eriþimi için kullanýcý adý ve þifreyi
             * yazmaktan baþka bir þansýnýz yok, bu örnek aklýnýzýn bir köþesinde
             * bulunsun.
             */
            using SqlConnection sqlConnection
                = new SqlConnection(builder.ToString());
            /* SqlConnection sýnýfýnýn 3 kurucu metodundan birini kullanarak örneðini
             * alýyorum. Bu metot doðrudan metinsel bir baðlantý cümlesini de kabul
             * eder. Ben örneði yaparken özelliklere deðer atamasý yaptým ki, farklý
             * bir örnek yapmýþ olayým. Genelde hep þöyle yazýlýyor:
             * "Data Source=.; Database=Northwind; User Id=sa; Password=123".
             * Böylece SqlConnection baðlantýsý hazýr. C# 8.0 ile gelen using
             * declarations sayesinde, SqlConnection Ram üzerinden otomatik olarak
             * kaldýrýlabilir (Dispose).
             */
            using SqlDataAdapter sqlDataAdapter = new
                ("Select * From Products", sqlConnection);
            /* Baðlantýyý yapabilmek için bir adaptöre ihtiyacýmýz var. SqlDataAdapter
             * sýnýfýndan bir örnek alýyorum. Bu örneði SqlDataAdapter sýnýfýnýn
             * 4 kurucu metodundan birini kullanarak aldým. Bu kurucunun,
             * 1. parametresi: SQL Select Komutu metni istiyor, onu yazdým.
             * 2. parametresi: SqlConnection tipinde bir deðiþken alýyor.
             * SqlConnection baðlantýsý içeren deðiþkeni bu parametreye sundum.
             * C# 8.0 ile gelen using declarations sayesinde, SqlDataAdapter
             * Ram üzerinden otomatik olarak kaldýrýlabilir (Dispose).
             */
            _dataTable = new();
            /* dataTable alanýným (field) için DataTable sýnýfýndan bir örnek
             * aldým. Böylece bir DataTable hazýrlandý. DataTable içerisindeki her
             * bir DataSet bir veri kümesini ifade edecek.
             */
            try
            /* Dene Yakala (try catch) bloðu yazýyorum. Neden? Eðer adaptörümüz
            * baðlantý saðlayamazsa kullanýcýya bunu bildireceðiz, birde try-catch
            * bloðunun yazýlmasý hakkýnda bir hatýrlatma yapmak istedim.
            */
            {
                DataSet dataSet = new();
                /* DataSet bir veri kümesini ifade eder. Yani; Bir çok tablo
                 * içerebilir. Eðer sadece bir tablo için, bir baðlantý yaptýysanýz
                 * DataSet kullanmadan doðrudan tabloyu (DataTable) kullanabilirsiniz
                 * DataSet bir tablo saklayýcý, DataTable ise Veritabanýndaki
                 * tablolar topluluðu olarak düþünülebilir. Ýleride DataSet
                 * kullanmanýz gerekebilir, birden fazla DataBase tablosu ile iþlem
                 * yaparsanýz, DataSet size nasýl yardýmcý olabilir bunu
                 * açýklýyorum. Asýl örnekler Ado.Net konusunda yapýlacaktýr. Burada
                 * amaç DataSet Component (Veri Kümesi Bileþeni) hakkýnda basit bir
                 * örnek yapmaktýr.
                 */
                _dataTable.TableName = "1.Tablom";
                //_dataTable tabloma bir ad verdim = "1.Tablom"
                dataSet.Tables.Add(_dataTable);
                /* DataSet Veri Kümesi Bileþenine (Component) tablo ekliyorum.
                 * Eklenen tablom _dataTable deðiþkenidir.
                 */
                sqlDataAdapter.Fill(dataSet.Tables["1.Tablom"]);
                //sqlDataAdapter.Fill(dataSet.Tables[0]); //þeklinde de yazýlabilir.
                /* SqlDataAdapter tipindeki adaptörümüzdeki veriyi doldur, nereye?
                 * (dataSet.Tables["1.Tablom"] olan tabloya). Böylece "Select * From
                 * Products" sorgusundan dönen SQL Tablosu, bu bileþene (component)
                 * doluyor. Eðer DataTable doðrudan kullanýlsa idi bu parametreye
                 * _dataTable sunulabilirdi. Yani;
                 * sqlDataAdapter.Fill(_dataTable); yazýlabilirdi.
                 */
            }
            catch (Exception ex)
            /*Hata varsa ve yakalandý ise (oluþan istisnayý ex deðiþkenine aktar.)*/
            {
                throw new Exception($"Server Adý: {builder["Server"]} veya \n" +
                    $"Database Adý: {builder["Database"]} ya da \n" +
                    $"Baðlantý Adaptörü: {typeof(SqlDataAdapter)} hatalý \n" +
                    $"veya olasý diðer hatalar {ex.Message}");
                /* Bir hata fýrlat. builder özelliðine atanan deðerlerden hataya
                 * neden olabilecek olanlarý {yazdým}. Bir de catch (Exception ex)
                 * satýrýnda bulunan ex deðiþkeninin deðerini de ekrana bastým.
                 */
            }
            #endregion SQL Server Baðlantýsý ve DataTable

            #region Formu Yatay Bölmek (SplitContainer ve Horizontal)

            SplitContainer splitContainer = new();
            /* SplitContainer kontrolünden bir örnek alýyorum. Bu kontrol ile formu
             * ikiye bölmeyi hedefliyorum.
             */
            splitContainer.Orientation = Orientation.Horizontal;
            //SplitContainer kontrolü yönü = Yatay olarak formu bölüyorum.
            splitContainer.Dock = DockStyle.Fill;
            /* Formu bölen kontrolün yuvalanma özelliði = Kullanýldýðý kontrolde
             * (biz formda kullanýyoruz) kontrolün kenarlarýna sabitlenir ve
             * kontrole uygun þekilde boyutlandýrýlýr. SplitContainer Formun
             * boyutu kadar olur. 
             */
            //splitContainer.FixedPanel = FixedPanel.Panel1;
            /* Bölme paneli formu ikiye böler ve varsayýlan olarak Panel1 ve Panel2
             * enum elemanlarý vardýr. Üst panel, Panel1 ve alt panel Panel2 olarak
             * kullanýlýr. Form ikiye bölündüðünde varsayýlan olarak, ortadan
             * bölünür. splitContainer.FixedPanel (ayný boyutta kalma özelliði)
             * uygula = Panel1 kapsayýcýsý (splitContainer) ile yeniden
             * boyutlandýrmaya tabi olmasýn. Böylece bu bölgede boyutlandýrma
             * yapýlmayacak, niyetim Panel1'in menü baþlýðý için kullanýlmasý.
             */
            Controls.Add(splitContainer);
            /* Forma kontrol ekle (SplitContainer kontrolünü ekle). Formu
             * yatay olarak bölen splitContainer.Panel1 ve splitContainer.Panel2
             * forma eklendi.
             */
            #endregion Formu Yatay Bölmek (SplitContainer ve Horizontal)

            #region Veriler Üzerinde Gezinme (BindingNavigator ve BindingSource)

            _bindingNavigator = new(true);
            /* BindingNavigator kontrolünün veri kaynaðýna (data source) bir
             * veri kümesi baðlamanýz halinde, baðladýðýnýz bu veri kaynaðýnda
             * gezinmenizi saðlar. Bir BindingNavigator örneði (instance) alýyorum.
             */
            _bindingSource = new();
            /* BindingNavigator kontrolünün gezintisini yapabilmesi için
             * BindingSource sýnýfýnýn bir örneðini (instance) alýyorum. Yani;
             * bu kontrol hangi veri kaynaðýnda gezecek bunu sunmamýz lazým.
             */
            _bindingSource.DataSource = _dataTable;
            /* BindingSource sýnýfýnýn veri kaynaðý özelliðine atama yapýyorum.
             * sqlDataAdapter.Fill(_dataTable); kod satýrý ile içeriði,
             * Veritabanýndaki Products tablosunun verileri ile dolan
             * (SqlDataAdapter için yazýlan sorgu: ("Select * From Products) bu kod
             * bloðunu hatýrlayýnýz) _dataTable alaný (field), bindingSource için
             * bir veri kaynaðý olarak kullanýlsýn. Artýk bir veri kaynaðý var.
             */
            _bindingNavigator.BindingSource = _bindingSource;
            /* BindingNavigator kontrolünün gezintisini yapabilmesi için kullanýlan
             * özelliði olan BindingSource özelliðine atama yapýyorum. BindingSource
             * tipindeki bindingSource deðiþkenini atadým. Bu deðiþken ise
             * DataSource olarak _dataTable alýyordu. DataTable ise, SqlDataAdapter
             * için yazýlan sorgudaki tabloyu içeriyordu. Sonuç: Products tablosunda
             * gezinme özelliði elde ettim.
             */
            _bindingNavigator.DeleteItem.Enabled = false;
            /* BindingNavigator kontrolünün silme özelliðine false atadým. Çünkü bu
             * baðlantý sonucunda bir veri silme iþlemi yapan kod yazmadým. Sadece
             * gezineceðim. Böylece veri silme yapýlamasýn. Aslýnda veriyi
             * silebilseniz ne olur? Silinmiþ gibi görünür, veri asýl kaynaðý olan
             * tablodan silinmez.
             */
            _bindingNavigator.AddNewItem.Enabled = false;
            /* BindingNavigator kontrolünün yeni kayýt ekleme özelliðine false
             * atadým. Çünkü bu baðlantý sonucunda bir veri ekleme iþlemi yapan kod
             * yazmadým. Sadece gezineceðim. Böylece veri ekleme yapýlamasýn. Veriyi
             * ekleseniz ne olur? Eklenmiþ gibi görünür, veri asýl kaynaðý olan
             * tabloya eklenmez.
             */
            splitContainer.SplitterDistance = _bindingNavigator.Height;
            /* SplitterDistance özelliði: ayýrýcýnýn sol veya üst kenarýndan piksel
             * cinsinden konumunu alýr veya ayarlar. Konu bir anda deðiþti, deðil mi?
             * splitContainer kontrolünün bölücünün uzaklýk ayarýna (Splitter
             * Distance) atama yap = Varsayýlan deðer olan 50 piksel iþime yaramadýðý
             * için _bindingNavigator kontrolünün yüksekliðini atadým.
             * _bindingNavigator kontrolü ile formdaki Products tablosu verilerinde
             * gezinti yapabiliyorduk.
             */
            splitContainer.Panel1.Controls.Add(_bindingNavigator);
            /* splitContainer kontrolünün 1. paneli  olan Panel1 özelliðine kontrol
             * ekle (_bindingNavigator yani gezinme kontrolünü ekle). Artýk form
             * üzerindeki Products tablosu verilerinde, oklar yardýmý ile ileri ve
             * geri olarak gezinebiliriz.
             */
            #endregion Veriler Üzerinde Gezinme (BindingNavigator ve DataSource)

            #region DataGridView Kontrolü ile Veri Görüntülemek
            _dataGridView = new();
            /* DataGridView kontrolünden bir örnek alýyorum. Amacým: Northwind
             * veritabanýndaki Products tablosunu görüntülemek.
             */
            _dataGridView.AllowDrop = _dataGridView.AllowUserToAddRows = false;
            /* DataGridView kontrolünde taþýma iþlemine izin verilmesin.
             * DataGridView kontrolüne kullanýcýnýn veri eklemesine izin
             * verilmesin.
             */
            _dataGridView.AllowUserToDeleteRows = false;
            //DataGridView kontrolüne kullanýcýnýn veri silmesine izin verilmesin.
            _dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Seçim Modu = Bir satýr seçilince, o satýrýn tümü seçili olsun.
            _dataGridView.AutoResizeColumns();
            /* Tüm sütunlar otomatik olarak, verinin geniþliðe göre ayarlanabilsin.
             * Böylece: Sütunlar üzerindeki, sütun ayýrýcý çizgilerine týklayýnca
             * sütun geniþliði otomatik olarak ayarlanabilir.
             */
            _dataGridView.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.DisplayedCells;
            /* Sütun geniþliði otomatik olarak ayarlanýrken modu þu olsun:
             * Sütun baþlýklarý dahil olmak üzere, görünen hücrelere göre
             * otomatik sýðdýrma iþlemi yapýlsýn.
             */
            _dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            /* Düzenleme modu: Düzenleme yapýlamasýn. Sadece BeginEdit(Boolean)
             * metodu kullanýlýrsa düzenleme yapýlabilir. Mesela, fareye týklanan
             * satýrda düzenleme yapýlmasýný isteyebilirsiniz. Düzenleme modunun
             * açýlmasý için: DataGridView.BeginEdit(true); olarak atanmalýdýr.
             */
            _dataGridView.DataSource = _bindingSource;
            /* _dataGridView kontrolünün kayýt kaynaðý = bindingSource olsun.
             * Ýki farklý kayýt kaynaðý kullanabilirim:
             * 1-) bindingSource, 2- _dataTable. Neden _dataTable kullanmadým?
             * Eðer bindingSource kullanmazsam _bindingNavigator butonlarý ile
             * ileri, geri hareket ettiðim satýr _dataGridView kontrolü
             * tarafýndan görüntülenmez, çünkü; kayýt kaynaðý farklý olmuþtur.
             */
            _dataGridView.Dock = DockStyle.Fill;
            /* _dataGridView kontrolü yuvalanma biçimine atama yap: üzerinde
             * bulunduðu kontrole tam olarak hizalansýn, doldurulsun. _dataGridView
             * bir konteyner paneli (splitContainer.Panel2) içerisine dahil edilecek.
             */
            _dataGridView.ColumnHeadersVisible = true;
            //Sütun baþlýklarý görünür olsun.
            splitContainer.Panel2.Controls.Add(_dataGridView);
            /* SplitContainer tipindeki bölme panelinin 2. bölmesine Kontrol
             * ekliyorum (_dataGridView) kontrolü. Böylece ilk bölme panelinde
             * _bindingNavigator, ikinci bölme panelinde _dataGridView var.
             */
            DataGridViewRowColor(_dataGridView);
            /*_dataGridView kontrolünün bir satýrýný bir renk, diðerini baþka bir
             * renk yapan yapan bir metot yazdým (parametre olarak satýrýný
             * renklendirmek istediðim _dataGridView kontrolünü sunuyorum).
             */
            _dataGridView.DataBindingComplete += DataGridView_DataBindingComplete;
            /* _dataGridView kontrolüne bir event method (olay metodu) tanýmlýyorum.
             * Amacým, kontrole veri yüklemesi tamamlandýðý (DataBindingComplete)
             * anda bir olay metodu ile bazý kodlarýn çalýþmasýný saðlamak.
             * Kontrole nokta ekliyorum ve Olay metodunu buluyorum. Sonra += iþareti
             * ekleyip Tab tuþuna iki defa basýyorum. Böylece otomatik olarak olay
             * metodu olan, DataGridView_DataBindingComplete olayý oluþuyor. Olay
             * metoduna geçerek kodlarýmý yazýyorum. Bu olay metodu ile LabelWriter
             * adlý bir metot ile ...ToolStripStatusLabel kontrollerine bazý
             * bilgiler yazdýrýp, kullanýcýya bilgi sunacaðým. */
            #endregion DataGridView Kontrolü ile Veri Görüntülemek
            _statusStrip = new();
            /* Yeni bir durum çubuðu (StatusStrip) kontrolü örneði alýyorum. Bu
             * kontrol formun altýna yerleþir ve kullanýcýya bilgi sunabileceðiniz
             * bir panel oluþur. Bu panele, Label, ComboBox, buton benzeri kontroller
             * ekleyebilirsiniz.
             */
            _toolStripStatusLabel = new();
            _toolStripLabel = new();
            /* Durum çubuðuna (StatusStrip) Label kontrolüne benzeyen
             * ToolStripStatusLabel kontrolü ekleyeceðim. Bir örneðini aldým.
             * Yalnýz dikkat edilmesi gereken nokta, ToolStripStatusLabel kontrolü,
             * adýndan da anlaþýlacaðý üzere StatusStrip kontrolüne eklenecek, forma
             * eklenmeyecek. StatusStrip kontrolü ise forma eklenecek. Ýki deðiþken
             * için de ayrý ayrý örnek aldým.
             */
            ToolStripButton toolStripButton = new();
            /* StatusStrip kontrolüne eklemek üzere, Button kontrolüne benzeyen
             * ToolStripButton kontrolünün bir örneðini aldým.
             */
            ToolStripSplitButton toolStripSplitButton = new();
            /* ToolStripSplitButton tipinde bir deðiþken tanýmladým ve örneðini
             * deðiþkene aktardým. Bu butona bir ikon ekleyeceðim. _dataGridView
             * kontrolünü bu buton ile Filtrelemeyi planlýyorum.
             */
            ToolStripSplitButton splitButtonPrint = new();
            /* Bu buton ile yazdýrma iþlemleri yapacaðým. Butona bir yazýcý ikonu
             * ekleyip, gerekirse kullanýcýnýn yazýcýdan çýktý almasýný saðlayacaðým.
             */

            _toolStripComboFilter = new();
            _toolStripComboBox = new();
            /* Birde ComboBox kontrolüne benzeyen bir kontrolümüz var. Bunlarda
             * Durum çubuðuna (StatusStrip) eklenecek. Birinde sütun baþlýklarýný
             * diðerinde bu baþlýklarýn verilerini görüntülemek üzere
             * ToolStripComboBox kontrolünden örnek aldým. Sütun baþlýklarý Products
             * tablosundaki sütunlar olacak. Veriler ise bu sütunlarý içeren açýlan
             * kutudan seçim yapýldýðýnda dolacak.
             */
            _statusStrip.Items.Add(_toolStripStatusLabel);
            /* Ýlk olarak Durum çubuðuna (StatusStrip) _toolStripStatusLabel
             * kontrolünü ekliyorum.
             */
            ToolStripSeparator toolStripSeparator = new();
            //ToolStripSeparator: StatusStrip üzerinde bir bölme çizgisidir.
            _statusStrip.Items.Add(toolStripSeparator);
            //StatusStrip kontrolüne, Bölme çizgisini ekledim. 
            _statusStrip.Items.Add(_toolStripLabel);
            //StatusStrip kontrolüne, _toolStripLabel ekledim.
            _statusStrip.Items.Add(_toolStripComboBox);
            //StatusStrip kontrolüne, _toolStripComboBox ekledim.
            ToolStripComboBoxFill(_toolStripComboBox, out int gridGenislik);
            /* Bir metodum var adý: ToolStripComboBoxFill. Bu metot parametresine
             * sunulan ToolStripComboBox_ tipindeki kontrole veri yüklemesi yapar.
             * Sonra bu veri ile dolan _dataGridView kontrolünün geniþlik deðeri
             * olarak kullanýlmak üzere int tipindeki bir deðiþkende oluþan deðeri
             * dýþarý atar. Peki dýþarý attýðý geniþlik neyin geniþliði? Þu kodu
             * inceleyiniz; "genislik += dataGridViewColumn.Width". 
             */
            _toolStripComboBox.SelectedIndexChanged +=
                ToolStripComboBox_SelectedIndexChanged;
            /* _toolStripComboBox kontrolünden bir seçim yapýldýðýnda çalýþacak bir
             * olay metodu (SelectedIndexChanged) tanýmlýyorum. _toolStripComboBox
             * yazdým, nokta ekledim += iþaretinden sonra iki kez tab tuþuna bastým.
             * Olay metodu otomatik olarak yazýldý. Ýçerik olarak þunu kodladým: 
             * _toolStripComboBox kontrolünde seçilen veriye göre (Products tablosu
             * sütunlarýndan biri seçiliyor) diðer kontrolü (_toolStripComboFilter)
             * doldurdum. Neyi doldurdum? Açýlan kutudan seçilen sütun adýna göre,
             * sütun içeriðindeki verileri doldurdum.
             */
            _statusStrip.Items.Add(_toolStripComboFilter);
            //StatusStrip kontrolüne, _toolStripComboFilter açýlan kutusunu ekledim. 
            _statusStrip.Items.Add(toolStripButton);
            //StatusStrip kontrolüne, toolStripButton butonunu ekledim. 
            toolStripButton.Click += ToolStripButton_Click;
            //StatusStrip kontrolüne eklenen butonuma, týklama olay metodu ekledim.
            toolStripButton.Text = "Filtrele";
            /* Butonda metin olarak = Filtrele yazdým. Butona bir kez týklanýnca,
             * _dataGridView kontrolü ComboBox verileri baz alýnarak filtrelenecek.
             */
            string directoryInfo =
                Directory.GetParent(Application.StartupPath).Parent?.FullName;
            /* Butonuma bir ikon eklemek istiyorum. Ýkonun bilgisayarýmdaki yolunu
             * tanýmlamak için metin tipinde bir deðiþken tanýmladým. Klasör
             * komutlarýný yöneten ve statik bir sýnýf olan Directory sýnýfýnýn
             * metot ve özelliklerinden yararlanacaðým. Fark ettiyseniz bu sýnýfta
             * new anahtar kelimesi ile sýnýfýn bir örneðini almadým, çünkü statik
             * bir sýnýf. Ben statik olduðunu nasýl anlarým derseniz; Class adý
             * üzerinde iken fareyi sað týklayýp Go To Definition komutuna
             * týklayýnýz. Sýnýf tanýmýnda static referansýný görebilirsiniz.
             * Ýkon resmini proje klasörüne ekledim. Bu resmi, C# programýnýn
             * görebilmesi için bir yol belirlemek gerekir. Statik sýnýflarda
             * veya statik olmayan sýnýflarýn statik olan metot ve özellikleri
             * örnek alýnmadan kullanýlabilir. Directory sýnýfýnýn GetParent
             * metoduna uygulamanýn yolunu bilen bir özellik olan
             * Application.StartupPath özelliðini sundum, StartupPath özelliði de
             * Application sýnýfý içinde statik olarak tanýmlanmýþ durumda.
             * Parent özelliði üst klasörü bulur. Soru iþareti ise null kontrolü
             * yapar. FullName özelliði, bulunan klasörün tüm yol bilgisini döndürür.
             * Son olarak da ikonumun adý ve uzantýsýný (\\Chart.png)
             * ekleyeceðim. Butonuma resim eklemek için yol tanýmý artýk hazýr.
             */
            toolStripSplitButton.Image =
                Image.FromFile(directoryInfo + "\\Chart.png");
            /* toolStripSplitButton kontrolüne imaj ekle = Image sýnýfý Drawing
             * isim alanýnýn abstract bir sýnýfýdýr. Drawing.Image sýnýfýnýn,
             * statik bir metodu olan FromFile metoduna resmin klasör yolu ve dosya
             * adý bilgisini içeren deðiþkenimi sundum. "\\Chart.png"
             * ve ikonunu ekledim.
             */
            toolStripSplitButton.Click += ToolStripSplitButton_Click;
            /* toolStripSplitButton nokta Click += tuþlarýna bastým. Click
             * olayý aktif hale geldi. Bu butona týkladýðýmda bir grafik (Chart)
             * oluþacak.
             */
            _statusStrip.Items.Add(toolStripSplitButton);
            /* StatusStrip kontrolüne, toolStripSplitButton butonunu ekledim.
             */
            splitButtonPrint.Image = Image.FromFile(directoryInfo + "//printer.png");
            //Butona bir printer ikonu ekledim.
            splitButtonPrint.Click += SplitButtonPrint_Click;
            _statusStrip.Items.Add(splitButtonPrint);
            /* Printer ikonu içeren butona týklanýnca yazdýrma iþlemi kodlarý
             * çalýþacak.
             */
            Controls.Add(_statusStrip);
            //En sonunda sýra StatusStrip kontrolünün kendisini de Forma ekledim.
            int col = _dataGridView.Columns.Count;
            //_dataGridView kontrolünde kaç sütun var bunun sonucunu deðiþkene aldým.
            Width = gridGenislik + 96;
            /* Formun geniþliðini ayarlýyorum. Formda geniþliðin en önemli olduðu
             * kontrol _dataGridView, formu da bu kontrolün geniþliðinden biraz
             * daha geniþ ayarladým, aksi halde son sütun hiç görünmüyor. Her
             * sütun için 8 birim ekleyince formun geniþliði tam olarak grid kadar
             * ayarlandý.
             */
            LabelWriter();
            /* Bu metot ile StatusStrip kontrolüne eklediðim ToolStripStatusLabel
             * kontrollerine ürün sayýsý, satýr sayýsý gibi verileri yazacaðým.
             */
            Icon sysIcon = SystemIcons.Information;
            Icon icon = new(sysIcon, 50, 50);
            /* Bilgi Logosunu ikon olarak ayarladým. Geniþliði logo kadar olacak.
             */
            _notifyIcon = new NotifyIcon
            {
                Icon = icon,
                BalloonTipTitle = (string)builder["Database"],
                BalloonTipIcon = ToolTipIcon.Info,
                Text = sqlDataAdapter.SelectCommand.CommandText,
                Visible = true
            };
            /* NotifyIcon Windows görev çubuðunun altýnda bir ikon olarak görünür
             * bir bilgi sunmak için kullanýlýr. NotifyIcon bileþeninden (Component)
             * bir örnek aldým. NotifyIcon Component için;
             * Icon özelliði = kod ile oluþturduðum ikonu atadým.
             * Açýlan balonun baþlýðý = (string)builder["Database"] kodu ile
             * baðlandýðým veritabaný adýný atadým. string tipine Cast ettim.
             * NotifyIcon için ikon bilgi ikonu idi, açýlan balon için de ayný.
             * NotifyIcon üzerine fare ile gidildiðinde sorgumuzu görüntülesin.
             * Görünüm = Görünür olarak ayarladým.
             */
            FormClosing += VtSample_FormClosing;
            //Form kapanýrken þu olay metodu çalýþsýn.
        }

        private void VtSample_FormClosing(object sender, FormClosingEventArgs e)
        {
            _notifyIcon.Dispose();
            //Görev çubuðunda oluþturduðumuz bilgi ikonu kaldýrýlsýn.
        }

        private void DataGridView_DataBindingComplete
            (object sender, DataGridViewBindingCompleteEventArgs e) => LabelWriter();
        /* DataGridView_DataBindingComplete (grid tümüyle baðlandýðýnda) olayýnda
         * LabelWriter metodu çalýþacak. Bu metot tablo verileri hakkýnda bazý
         * bilgileri etiketlere yazar.
         */

        /* Buradaki deðiþkenler de  isim alanýnda (name space) tanýmlanmýþtýr.
         * Sadece bu metot içerisinde ilk kullanýmýna baþladýðým için buraya yazdým.
         */
        private int satir; //Burasý grid satýr sayýsý için.
        private double toplamStokFiltreli; //Filtrelenen verilerin toplamý için
        private void LabelWriter()
        /* Bu metot etiket kontrollerine veri yazdýrýyor. Hangi veriler olduðunu
         * metodun ilerleyen adýmlarýnda anlatacaðým.
         */
        {
            ControlsClear(_toolStripStatusLabel);
            var toplamStok = _dataTable.Compute("Sum(UnitsInStock)", "true");
            /* DataTable sýnýfýnýn bir metodu var Compute. Ýki parametre alýyor.
             * 1. Parametre, tabloyu sorgulayan ifadedir. UnitsInStock sütununun
             * toplamýný aldým. 2. Parametre filtredir. Ben tüm sütun verilerini
             * þartsýz toplamak istediðim için true gönderdim. Diðer
             * Compute fonksiyonlarý: AVG (Ortalama), COUNT (Toplam Sayý),
             * MAX (En büyük deðer), MIN (En küçük deðer), STDEV (Standart Sapma).
             * Tabii ki Lambda Expression da kullanabilirsiniz. Farklý bir metot
             * örneði sunmak Compute metodunu kullandým.
             */
            _toolStripStatusLabel.Text = $"Toplam Stok: {toplamStok:0,00} adet";
            //Bu etikette toplamStok deðiþkeninden dönen deðer görünecek.
            satir = _dataGridView.Rows.GetRowCount
                    (DataGridViewElementStates.Visible);
            /* Burasý _dataGridView.Satýrlarýnýn, Satýr sayýsýný döndüren (Get)
             * metodu kullanýlarak yazýldý. Sadece görünen satýrlarýn sayýsý, int,
             * tipli satir deðiþkenine aktarýldý. Bu deðiþken bu sýnýf için genel
             * kullanýma açýk.
             */
            _toolStripLabel.Text = $"{satir} satýr =>";
            //_toolStripLabel kontrolüne satir deðiþkeninde oluþan sayýyý aktardým.
            toplamStokFiltreli = _dataGridView.Rows.Cast<DataGridViewRow>().Sum
                (x =>
                    Convert.ToDouble(x.Cells["UnitsInStock"].Value));
            /* Þimdi de filtreye göre çalýþan toplam stok deðerini toplamStokFiltreli
             * deðiþkenine aktaralým. Bir Lambda Expression yazacaðým. _dataGridView
             * kontrolünün satýrlarýný "_dataGridView.Rows.Cast<DataGridViewRow>()"
             * DataGridViewRow tipine cast ettiðimizde, artýk Lambda metotlarýný
             * kullanabiliriz. Burada Sum metodunu kullandým. Parantez içerisinde
             * lambda deðiþkeni ismi olarak x kullanýyorum. Seçicim x => her x için
             * Hücrelerden (Cells) ["UnitsInStock" sütun deðerini] alýyoruz. Bu veri
             * Value özelliði ile alýnýyor, value özelliði ise object tipinde deðer
             * döndürdüðü için, bize lazým olan deðer double tipinde olduðundan
             * Convert.ToDouble metodu ile sonucu çeviriyoruz. Yani burada Stok
             * Adedi hesaplanmýþ oluyor.
             */
            _toolStripLabel.Text +=
                $"Filtreye Göre Toplam Stok: {toplamStokFiltreli} =>";
            /* _toolStripLabel kontrolüne metni yaz += (bir önceki kod satýrýnda
             * satýr deðeri vardý + olarak, lambda ile yazýlan)  toplamStokFiltreli
             * deðeri yazýlýyor.
             */
            double toplamSiparis = _dataGridView.Rows.Cast<DataGridViewRow>().Sum
                (x =>
                    Convert.ToDouble(x.Cells["UnitsOnOrder"].Value));
            _toolStripLabel.Text += $"ve Sipariþ Adedi: {toplamSiparis}";
            /* Toplam sipariþ içinde bir lambda ifadesi kullandým. Böylece
             * LabelWriter() metodu, satýr, toplam stok ve toplam sipariþ bilgisi
             * verilerini _toolStripLabel kontrolüne yazacak.
             */
        }
        private void ToolStripSplitButton_Click(object sender, EventArgs e)
        /* Üzerinde Grafik görüntülemek üzere hazýrlayacaðýmýz bir form olacak. Bu
         * form ToolStripSplitButton týklanýnca oluþacak. Yani þu anda böyle bir form
         * yok, buton týklanýnca runtime (çalýþma zamanýnda) oluþacak.
         */
        {
            using Form chartForm = new();
            /* C# 8.0 ile gelen yenilik using declaration kullandým. Form kullanýmý
             * bittiðinde kendiliðinde Dispose (kullanýmdan kaldýrýlýr) olur.
             * Form sýnýfýndan bir örnek aldým. Artýk chartForm deðiþkeni bir formu
             * ifade eder.
             */
            chartForm.AutoSize = true;
            //Form otomatik olarak boyutlandýrýlsýn.
            chartForm.WindowState = FormWindowState.Normal;
            /* Formun pencere görünüm durumu normal olsun. Diðer seçenekler: Ekraný
             * kaplamýþ (Maximized), simge durumuna küçültülmüþ (Minimized) olabilir.
             */
            chartForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            /* Formun kenarlýk stili yeniden boyutlandýrýlamasýn. Diðer seçeneklerden
             * en çok lazým olacaklar: Yeniden boyutlandýrýlabilir (Sizable),
             * Kenarlýk yok (None), üç boyutlu kenarlýk (Fixed3D)
             */
            chartForm.Left = chartForm.Top = 0;
            /* Formun Windows sistemine göre sol kenardan ve sað kenardan olan
             * uzaklýk deðeri = 0 olsun.
             */
            chartForm.Size = Screen.PrimaryScreen.WorkingArea.Size;
            /* Formun boyutu = Screen sýnýfýnýn, birincil ekraný, çalýþma boyutu
             * ile ayný olsun. Bendeki size deðeri 1.920x1.040 çýkýyor, çünkü Windows
             * görev çubuðu boyutu 40, böylece 1920x1080 tamamlanmýþ oluyor.
             * Formumuz görev çubuðunu kapatmamýþ oluyor.
             */
            chartForm.ShowInTaskbar = true;
            //Form, Görev Çubuðunda bir simge olarak görünmesin.
            chartForm.AutoScroll = true;
            /* Formda, eðer gerekli oldu ise otomatik olarak kaydýrma çubuðu
             * görünsün. Yani formun boyu içeriðindeki nesneleri görüntülemeye
             * yetiyorsa kaydýrma çubuðu görünmez.
             */
            Chart chart = new();
            /* Bu formun asýl amacý bir grafik görüntülemekti. Chart tipinde bir
             * deðiþken tanýmladým ve Chart sýnýfýndan bir örnek (instance) aldým.
             */
            chart.Size = chartForm.Size;
            //Grafiðin boyutu, grafik için hazýrlanan formun boyutu ile ayný olsun.
            Title title = new();
            /* Grafiðe bir baþlýk atamasý yapmak üzere Title sýnýfýndan bir
             * örnek aldým. Artýk title deðiþkeni Title tipinde.
             */
            title.Text = "Fiyat ve Stok Durumu";
            //Baþlýk metni olarak Text özelliðine atama yaptým.
            chart.Titles.Add(title);
            //Grafiðe baþlýðý ekledim.

            string axisX = _dataTable.Columns["ProductName"].Caption;
            string axisY = _dataTable.Columns["UnitPrice"].Caption;
            /* Grafiðin X ve Y ekseninde görüntülenecek metinleri yazdým. Doðrudan
             * metin olarak "ProductName" yazabilirdim. Ancak bu sütunun adýnýn
             * _dataTable üzerinden alýnmasýný saðladým. Böylece sütun adýnýn
             * doðruluðu kesinleþti. Burada indeks deðerleri de kullanabilirdim,
             * ancak bu seferde sütunun yerini sabitlemek gerekirdi, neden? Çünkü
             * sorgu Select * From gibi yazýlmaz da, sütun adlarý ile yazýlýr ve
             * varsayýlan sütun sýrasý ile yazýlmaz ise gelen sütunlarýn indeks
             * deðerleri de deðiþecektir. Sütun adýný yazmak daha kesin bir sonuç
             * almamýzý saðlar.
             */
            ChartArea chartArea = new();
            /* Þimdi de grafiðin, asýl grafik alaný olan ChartArea kýsmýna geldi.
             * ChartArea sýnýfý tipinde bir deðiþken ile sýnýfýn örneðini aldým.
             */
            chartArea.AxisX.Interval = 1;
            //AxisX (ProductName) ürün adlarý için aralýk 1'er olsun.
            chartArea.AxisY.Interval = 10;
            // AxisY (UnitPrice) ürün fiyatlarý için aralýk deðeri 10 olsun
            chartArea.AxisX.Title = axisX;
            //AxisX (ProductName) ürün adlarý için baþlýk axisX deðiþkeninden gelsin.
            chartArea.AxisY.Title = axisY;
            //AxisY (UnitPrice) ürün fiyatlarý için baþlýk axisY deðiþkeninden gelsin.
            Font font = new("Arial", 14, FontStyle.Bold);
            /*Bu formun grafiðinde kullanmak için bir font tanýmladým. Font
             * sýnýfýndan bir örnek aldým. Kurucu metodunda, font adý, büyüklüðü,
             * kalýn yazý tipli olmasýný ayarladým.
             */
            title.Font =
            chartArea.AxisX.TitleFont =
                chartArea.AxisY.TitleFont =
                    chartArea.AxisX.LabelStyle.Font =
                        chartArea.AxisY.LabelStyle.Font = font;
            //Yukarýdaki tüm nesnelere font olarak font deðiþkenini atadým.
            chartArea.Area3DStyle.Enable3D = true;
            //Grafik alaný 3D görünümünün etkinleþtirdim.
            chartArea.Area3DStyle.LightStyle = LightStyle.Simplistic;
            /* 3D Grafik için bir aydýnlatma stili atamasý yapar. 
             * Realistic: Renk tonunun dönüþ miktarýna baðlý olarak deðiþtiði
             * gerçekçi aydýnlatma seçeneðidir.
             * Simplistic: Renk tonunun sabit kaldýðý seçenektir.
             */
            chartArea.Area3DStyle.Rotation = 10;
            //3D Grafik döndürme açýsý = 10 olsun.
            chartArea.Area3DStyle.WallWidth = 25;
            //3D Grafik arkaplan geniþliði = 25 olsun (max:30 olabilir).
            chartArea.Area3DStyle.Inclination = 40;
            //3D Grafik eðimi = 40 olsun.
            chart.ChartAreas.Add(chartArea);
            /* Grafik nesnesine, bazý özelliklerini atadýðýmýz grafik alanýný ekle
             * Hatýrlayýnýz: ChartArea tipindeki chartArea deðiþkenimiz vardý.
             */
            Series series = new();
            //Grafiðin serilerini tanýmlamak üzere Series sýnýfýndan bir örnek aldým.
            series.ChartType = SeriesChartType.Column;
            /* Bir grafik tipi belirliyorum = Tipi (Column = Sütun)
             * Pie (Pasta), Doughnut (Donut), Pyramid (Piramit) grafik tipleri de
             * görünüm bakýmýnda kullanýlabilir.
             */
            series.SetCustomProperty("DrawingStyle", "Cylinder");
            //Diðer çizim stilleri: Cylinder, Emboss, LightToDark, Wedge, Default.
            /* Grafik serisine Özelleþtirilmiþ Özellikler eklenebiliyor. Ancak bu
             * özellikler her grafiðe uymuyor. Bu özellikler hangi grafiðe uyuyorsa
             * ona yazdýðýnýzda etkin oluyor. Hangi grafik ne demek? Column, Pie vb.
             * Konu hakkýnda detaylý bilgi þu linkte bulunmakta:
             * https://docs.microsoft.com/en-us/previous-versions/dd456764(v=vs.140)
             * ?redirectedfrom=MSDN 
             */
            series.SetCustomProperty("LabelStyle", "Top");
            /* Grafik serisine Özelleþtirilmiþ Özellik ekle (Etiket Stili, Etiket
             * grafiðin üzerinde olsun). Mesela bu özellik, grafik stiliniz: Point,
             * Column, Bubble, Line, Spline, Step Line, Area, Spline Area, Range,
             * Spline Range, Radar, Polar ise çalýþýyor. Zaten mantýk olarak da
             * uygun, mesela pie chart (pasta grafik) üzerinde çalýþmaz, yuvarlak
             * olacaðý için Top özelliði olmaz, olsa olsa grafiðin dýþýnda olabilir.
             */
            /* series.SetCustomProperty("LabelStyle", "Outside");
             * Grafik tipi Pie (Pasta iken Top yerine Outside kullanabilirsiniz).
             */
            series.IsValueShownAsLabel = true;
            //Serinin grafik üzerinde etiketleri gösterme durumu = gösterilsin.
            series.XValueMember = _dataGridView.Columns[axisX]?.DataPropertyName;
            /* Serinin X eksenine yaz = Izgara sütunlarýndan adý [axisX deðiþkeninde
             * yazan deðer olan sütun] boþ deðilse, verinin özellik adýný yaz.
             * Böylece kayýt kaynaðýnýz deðiþirse sadece axisX deðiþkenini
             * düzeltmeniz yeter. Aslýnda direk ProductName veya axisX
             * yazabilirsiniz, ben farklý bir kod örneði olmasý açýsýndan yazdým. 
             */
            series.YValueMembers = _dataGridView.Columns[axisY]?.DataPropertyName;
            //Burasýda UnitPrice yani axisY.
            chart.Series.Add(series);
            //Artýk grafiðimize grafik serisini ekleyelim.
            chart.SaveImage("Chart.bmp", ChartImageFormat.Bmp);
            //Grafiði bmp formatýnda bir resim olarak kaydet ve görüntüle.
            chart.AntiAliasing = AntiAliasingStyles.All;
            //Grafiðin köþe kýrýlmalarýnýn tümünü yumuþat.
            chart.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
            //Grafiðin köþe kýrýlmalarýnýn yumuþatma kalitesi yüksek kalite olsun.
            chart.DataSource = _dataGridView.DataSource;
            //Grafiðin veri kaynaðý = _dataGridView veri kaynaðý olsun.
            chartForm.Controls.Add(chart);
            //chartForm formuna grafiði ekle.

            ChartColorFormat(chart, series, chartArea);
            //Bu metot ile Chart, Series ve ChatArea renk ayarlarýný yapacaðým

            chartForm.ShowDialog();
            //Grafik formunu ekranda görüntülüyorum.
        }
        private static void ChartColorFormat
            (Chart chart, Series series, ChartArea chartArea)
        /* Bu metot parametreli olarak: Chart, Series ve ChartArea tipinde 3 
         * parametre alýyor. Bu nesnelerin biçimlerini ayarlýyor.
         */
        {
            chart.BackColor = chartArea.BackColor = Color.FloralWhite;
            //Grafik ve grafik alaný arkaplan rengi = Beyaz (FloralWhite).
            chartArea.AxisX.MajorGrid.LineColor =
            chartArea.AxisY.MajorGrid.LineColor = Color.Black;
            //Grafik çizgilerinin rengi = Siyah.

            chart.BackSecondaryColor =
                series.BackSecondaryColor =
                    chartArea.BackSecondaryColor = Color.LightGoldenrodYellow;

            chart.BackGradientStyle =
            chartArea.BackGradientStyle =
            series.BackGradientStyle = GradientStyle.VerticalCenter;
            //Renk geçiþ stili = Yatay Merkezli.

            series.Palette = ChartColorPalette.Pastel;
            //Serilerin renkleri pastel renkler olsun.
        }
        private void DataGridViewRowColor(DataGridView dataGridView)
        /* DataGridView satýrlarýndan birinin bir renk, diðerinin baþka renk
         * olmasýný saðlamak için bu metodu yazdým.
         */
        {
            dataGridView.RowsDefaultCellStyle.BackColor = Color.White;
            //Satýrlar varsayýlan arkaplan rengi stili = Beyaz (White)
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.GhostWhite;
            /* Alternatif renk stili = Beyaz (GhostWhite)
             * Böylelikle bir satýr bir renk, diðer satýr diðer renk olacak.
             */
        }
        private bool _tiklandi = false;
        //Bir deðiþkenim var adý _tiklandi ve bu sýnýfta kullanýma açýk.
        private void ToolStripButton_Click(object sender, EventArgs e)
        {/* Bir butonum var adý: ToolStripButton týklandýðýnda þunlar gerçekleþsin.
          * Bu buton bir kez týklanýnca veriler filtrelenir, diðer týklamada verilerin
          * tümü görüntülenir.
          */
            if (_toolStripComboFilter.Items.Count == 0 ||
                _toolStripComboFilter.Text == string.Empty) return;
            /* Eðer _toolStripComboFilter kontrolündeki eleman sayýsý 0 ise veya
             * açýlan kutuda yazýlý bir metin yok ise bu metottan geri dön, çýk.
             * Eðer metot return ile sona ermedi ise aþaðýdaki satýrlardan
             * devam edilir.
             */
            _notifyIcon.Visible = true;
            /* _notifyIcon kontrolü çift týklama olayý (_notifyIcon_DoubleClick) ile
             * gizleniyor, bu buton ile de görünür yapýlýyor. Böylece ToolStripButton
             * kontrolüne her týklamada _notifyIcon.Visible özelliði = true oluyor.
             */
            _tiklandi = !_tiklandi;
            /* _tiklandi deðiþkeni eþittir = _tiklandi deðiþkeninin deðiline. Bu da
             * demek oluyor? _tiklandi deðiþkeni = true ise false, false ise true
             * olsun demektir. Böylece bir týklamada true, diðerinde false olur.
             */
            if (!_tiklandi)
            //Eðer _tiklandi deðiþkeni _tiklandi = true deðilse (false ise)
            {
                ((ToolStripButton)sender).Text = "Filtrele";
                /* sender nesnesini ToolStripButton tipine Cast et ve Metin
                 * özelliðine = Filtrele yaz.
                 */
                _dataTable.DefaultView.RowFilter = null;
                /* _dataTable kontrolünün varsayýlan görünümünün filtreleme özelliði
                 * boþ olsun. Böylece Filtre kaldýrýlýr.
                 */
                //_toolStripComboBox.Text = _toolStripComboFilter.Text = string.Empty;
                /* Ýsterseniz toolStripComboBox ve _toolStripComboFilter kontrollerini
                 * temizleyip, filtrelemeyi iptal edebilirsiniz. Yani metin
                 * özelliklerinde hiç bir veri olmayacaðý için, verilerin tümü
                 * gösterilir.
                 */
                DataGridViewRowColor(_dataGridView);
                /* Bu metot parametre olarak _dataGridView alýr ve bir satýrýný bir
                 * renk diðerini baþka renk yapar.
                 */
                Height = _yukseklik;
                /* Burada filtreleme yapýlmadýðý için, formu ilk yüksekliðine
                 * döndürüyorum. Formun yüksekliði filtreleme sonucunda
                 * deðiþirse bu satýr tekrar eski haline getirir.
                 */
                return;
                /* Filtre verisi null olduðundan, bundan sonraki satýrlarda
                 * filtreleme iþlemi yaptýðý için return ile metodu sonlandýrdým.
                 */
            }
            else
            //Eðer _tiklandi deðiþkeni _tiklandi = true deðilsenin deðili, true ise
            {
                ((ToolStripButton)sender).Text = "Tümünü Göster";
                /* "ToolStripButton_Click(object sender" kodunu hatýrlayýnýz.
                 * Buradaki, object sender, ToolStripButton kontrolünü ifade eder,
                 * bu nedenle tipini ToolStripButton tipine çevirip metin deðeri
                 * olarak "Tümünü Göster" yazdým. Diðer týklamada Filtrele olacak. 
                 */
                DataGridViewRowColor(_dataGridView);
                /* Grid kontrolünün satýr renklerini ayarlayan metodu kullandým.
                 * Böylece filtre sonrasý satýrlar yeniden renklendirildi.
                 */
            }
            try
            //Dene, hata var mý?
            {
                _dataTable.DefaultView.RowFilter =
                $"{_toolStripComboBox.Text} LIKE " +
                $"'%{_toolStripComboFilter.Text}%'";
                /* _dataTable kontrolünün varsayýlan görünümü, satýr filtresi
                 * þöyledir: _toolStripComboBox boþ deðilse Metni al (Burada
                 * Product sütunlarýnýn adlarý var) LIKE yaz (benzer verileri
                 * filtrele komutu için yazdým). Bu iþaret baþta olursa "%"
                 * ile baþlayan demektir. Buradaki veri ile baþlayan ve biten
                 * verilere göre filtrele: [_toolStripComboFilter] Yani;
                 * Seçilen sütun verisinin içeriðindeki deðerlerden seçilen
                 * ile baþlayan ve biten (içeren) veriler demektir.
                 * Bu iþaret sonda olursa "%" ile biten demektir.
                 * % burada yazan veriyi içeren % anlamýna gelir.
                 */
            }
            catch (Exception)
            //Yakala, hata varsa hatayý yakala
            {
                if (_toolStripComboFilter.Text == string.Empty) return;
                /* Eðer filtre uygulayacaðýmýz verileri içermesi gereken
                 * _toolStripComboFilter boþ ise dönüþ yap, çýk
                 */
                string aranan =
                    _toolStripComboFilter.Text.Replace(',', '.');
                /* aranan adlý deðiþkene iki tip veri geliyor, sayý ve metin. Sayý
                 * deðerleri ise 100,25 gibi görünüyor, bu þekilde arama yapýnca
                 * bulamazsýnýz. Bende ondalýk ayracý , yerine . olarak deðiþtirdim.
                 * 100.25 gibi bir sayýya dönüþtü. Bu biraz hard code oldu, hard
                 * code yazmayý pek sevmem ama böyle kod yazamamanýz için göstermiþ
                 * olayým. Normalde sayýlarýn binlik ve ondalýk ayraçlarý,
                 * MethodsParametersVoidReturn projemize baktýðýnýzda
                 * SistemNumerikAyraci() adlý bir metot var, incelemenizi rica
                 * ederim. virgül, nokta ile deðiþsin gibi bir kod yazmak yerine
                 * sistem ondalýk ve binlik ayracýna baðlanan bir kod yazmanýz
                 * yerinde olur.
                 */
                _dataTable.DefaultView.RowFilter =
                string.Format($"{_toolStripComboBox?.Text} = {aranan}");
                /* Þimdi de filtrelemeyi atayalým. Filtreleme sadece filtre yapan
                 * _toolStripComboBox adlý açýlan kutudaki veriye göre olsun. Yani;
                 * içeren verileri deðil, sadece _toolStripComboBox verisini ara.
                 * Aslýnda try kýsmýndaki arama, metinsel verileri bulur, catch
                 * kýsmýndaki arama sayýlara göre arama yapar. Böylece sayý ise;
                 * þöyle ara, metin ise böyle ara diye kod yazmak en doðrusudur.
                 * Ben sadece try-catch örneðini hatýrlatmak için böyle yazdým.
                 * HesapMakinesiTryCatchFinally projemizi hatýrlayýnýz orada
                 * isNumeric metodu vardý. isNumeric metodu ile bakarsýnýz sayý
                 * ise aramayý bu satýrdaki gibi yaparsýnýz, metin ise
                 * Like % buradaki metni içeren veriler % kodlarý arasýnda
                 * arama yaparsýnýz.
                 */
            }
            _notifyIcon.BalloonTipText = $"{satir} adet satýr var." +
                    $"\n Stok Adedi: {toplamStokFiltreli}" +
                    $"\n Bilgi ikonuna iki kez týklayýp kaldýrabilirsiniz.";
            /* Sýra geldi görev çubuðu balonuna, balona metin olarak þunu yazacaðým:
             * satir deðiþkeninde ne vardý hatýrlayýnýz:
             * "_dataGridView.Rows.GetRowCount(DataGridViewElementStates.Visible)"
             * görünen satýrlarýn sayýsý. Ýþte bu sayýyý yaz.
             */
            Height = satir * (_dataGridView.RowTemplate.Height + 3)
                     + _bindingNavigator.Height + _statusStrip.Height +
                        (Height - ClientRectangle.Height);
            /* satir deðiþkeni kodu ne idi? "_dataGridView.Rows.GetRowCount
             * (DataGridViewElementStates.Visible);" Sadece görünen satýrlarýn
             * adet bilgisini alýyordu. Filtrelenen verilere göre yükseklik deðeri
             * bulurken bu kontrollerin yükseklik deðerleri lazým oldu.
             */
            _notifyIcon.ShowBalloonTip(3_000);
            //Bu bilgi 3.000/1.000 = 3 saniye görünsün.
            _notifyIcon.DoubleClick += _notifyIcon_DoubleClick;
            //Ýkon çift týklandýðýnda _notifyIcon gizlenecek.
        }
        private void _notifyIcon_DoubleClick(object sender, EventArgs e)
            => _notifyIcon.Visible = false;
        /* _notifyIcon_DoubleClick (iki kez týklandýðýnda) olayýnda
         * gizlenecek. => bu yazým þekli . Expression-bodied members
         * olarak adlandýrýlýyor C# 6.0 ile metotlar destekleniyordu C# 7.0 ile
         * Property, Constructor, Finalizer, Indexer desteði de geldi. Böylece
         * tek satýrlý bir sonucunuz var ise {} açmadan => ile metodu, özelliði,
         * kurucu metodu vs. doðrudan yazabiliyorsunuz.
         */
        private void ToolStripComboBoxFill(ToolStripComboBox toolStripComboBox,
                                                        out int gridGenislik)
        /* Bu metot ile ToolStripComboBox doldurulacak. Ýçeriðindeki verilerden
         * _dataGridView kontrolü için geniþlik hesaplanacak. 1. Parametre
         * ToolStripComboBox alýyor, 2. Parametre int tipinde gridGenislik adlý
         * deðiþkeni dýþarý aktarýyor.
         */
        {
            string _bicim = string.Empty;
            //Burasý metin biçimlendirme için kullanýlacak.
            int genislik = 0;
            //Grid geniþliði için tanýmladým.
            for (int j = 0; j < _dataGridView.Columns.Count; j++)
            /* Bu döngü; 0 ile _dataGridView kontrolünün sütun sayýsýndan 1 küçük
             * oluncaya kadar döner. Böylece sütun baþlýklarýnda dönmüþ olacaðým.
             */
            {
                DataGridViewColumn dataGridViewColumn = _dataGridView.Columns[j];
                /* Grid sütunu tipinde (DataGridViewColumn) bir deðiþkenim var. Grid
                 * Sütunlarýndan [j sütunlarý] bu deðiþkene aktarlýsýn. Böylece 0,1,
                 * 2... grid içeriðindeki sütun kadar sütunlar bu deðiþkene
                 * aktarýlýr. Burasý DataGridView Column (Grid sütunu)
                 */
                DataColumn dTblColumn = _dataTable.Columns[j];
                /* Veri sütunu tipinde (DataColumn) bir deðiþkenim var. Veri
                 * sütunlarýndan [j sütunlarý] bu deðiþkene aktarlýsýn. Böylece 0,1,
                 * 2... Data içeriðindeki sütun kadar sütunlar bu deðiþkene
                 * aktarýlýr. Burasý Data Column (Veri sütunu, Data Table sütunu)
                 */
                dataGridViewColumn.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
                /* dataGridViewColumn deðiþkenimizin varsayýlan hücre stilinin
                 * hizalama özelliði saða yaslý olsun. Böylece tüm sütunlar saða
                 * yaslandý. Sonra sola yaslanmasý gereken sütunlarý ayarlarýz.
                 */

                if (dTblColumn.DataType == typeof(short) ||
                    dTblColumn.DataType == typeof(double) ||
                    dTblColumn.DataType == typeof(decimal))
                /* dTblColumn deðiþkenindeki "_dataTable.Columns[j]" sütun
                 * short, double, decimal ise virgülden sonra 2 haneli olsun.
                 */
                {
                    _bicim = "N2"; //virgülden sonra 2 haneli olsun.
                }
                else if (dTblColumn.DataType == typeof(int))
                //Yukarýdaki if bloðunda belirtilen tip deðilse int tipinde ise
                {
                    _bicim = "N0"; //virgülden sonra 0 haneli olsun.
                }
                else
                //Hiçbiri deðilse
                {
                    dataGridViewColumn.DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleLeft;
                    /* dataGridViewColumn deðiþkenimizin varsayýlan hücre stilinin
                     * hizalama özelliði sola yaslý olsun. Böylece kalan tüm
                     * sütunlar sola yaslandý. Sayýlar saða yaslý, metinler
                     * sola yaslý oldular.
                     */
                }
                //Buradaki if bloðundan N2 veya N0 deðeri oluþur.
                dataGridViewColumn.DefaultCellStyle.Format = _bicim;
                /* Döngü hala sürdüðü için dataGridViewColumn deðiþkenimizin
                 * varsayýlan hücre stil biçimi = if bloðundan dönen
                 * _bicim deðiþkeni olur. Böylece N0 veya N2 olacaktýr.
                 */
                genislik += dataGridViewColumn.Width;
                /* genislik deðiþkeni "out int gridGenislik" deðeri için sürekli
                 * toplanýyor. Böylece grid süutlarý toplam geniþliði hesaplanacak.
                 */
                toolStripComboBox.Items.Add(
                    _dataTable.Columns[j].ColumnName);
                /* toolStripComboBox kontrolüne eleman ekle (_dataTable
                 * sütunlarýndan [j. sütununun (0,1,2... sütunlarýnýn)]) ad
                 * özelliðini bu açýlan kutuya ekle. Böylece sütun adlarý ve
                 * içeriðindeki verilere göre filtreleme yapabilmek için gerekli
                 * olan sütun adlarý hazýr.
                 */
            }
            gridGenislik = genislik;
            /* Dýþarý aktaracaðýmýz gridGenislik deðiþkeni deðeri, genislik
             * deðiþkeninin deðeri kadardýr.
             */
        }
        private void ToolStripComboBox_SelectedIndexChanged
        (object sender, EventArgs e)
        /* ToolStripComboBox kontrolünden bir veri seçilip indeks deðeri deðiþtiðinde
         * (SelectedIndexChanged) bu olay tetiklenir. ToolStripComboBox, Products
         * tablosunun sütün baþlýklarýný içeriyordu ve filtreleme için
         * kullanýlacaklardý.
         */
        {
            string columnName = ((ToolStripComboBox)sender).Text;
            /* string  tipindeki columnName deðiþkeni eþittir = açýlan kutunun
             * metnine. Aslýnda bu olaydan dönen object tipindeki sender deðiþkeni,
             * ToolStripComboBox olduðu için bir cast iþlemine tabi tutuldu ve metin
             * deðeri alýnabildi. (ToolStripComboBox, Products tablosunun sütün
             * baþlýklarýný içeriyordu).
             */
            DataColumn dataColumn = _dataTable.Columns[columnName];
            /* DataColumn tipindeki deðiþkenimiz ise = _dataTable kontrolünün
             * sütunlarýndan [columnName adýndaki sütun deðerine] eþittir.
             * Mesela; CategoryID sütunu, dataColumn deðiþkenine aktarýlýyor.
             */
            ControlsClear(_toolStripComboFilter);
            /* ControlsClear metodu parametresine sunulan kontrolü temizler.
             * Önce _toolStripComboFilter adlý kontrolü temizleyelim, böylece
             * ToolStripComboBox kontrolüne baðlý olarak sütun verilerini yeniden
             * bu kontrole doldurduðumuzda veriler, üst üste binmesinler, tekrarlý
             * veri olmasýn.
             */
            _toolStripComboFilter.Sorted = true;
            // _toolStripComboFilter kontrolü verileri sýralý olarak göstersin.
            foreach (DataRow item in _dataTable.Rows)
            /* Veri satýrlarýnda dönen bir döngü olan foreach döngümüzün deðiþkeni
             * olan item _dataTable (veri tablosunun) satýrlarýnda dönecektir.
             */
            {
                if (!_toolStripComboFilter.Items.Contains(item[dataColumn]))
                /* Eðer (Deðilini al, _toolStripComboFilter kontrolü içeriyor mu,
                 * neyi? Döngü deðiþkendeki [dataColumn deðiþkenindeki deðeri
                 * içeriyor mu "_dataTable.Columns[columnName]" ?
                 * Yani Filtrelemede kullanacaðýmýz ve satýrlardaki veriyi içeren
                 * açýlan kutuda, _dataTable.Rows içeriðindeki deðer var mý? Deðilini
                 * alacaktýk, o zaman var mý = Evet ise evetin deðili olan Hayýr ise
                 */
                {
                    _toolStripComboFilter.Items.Add(item[dataColumn]);
                    /* _toolStripComboFilter kontrolüne eleman ekle (Döngü
                     * deðiþkeni olan item [sütun adýný içeren sütundaki verileri
                     * ekle]). Böylece tekrarlý veri eklenmez ve görüntülenmez.
                     */
                }
            }
        }
        private void ControlsClear(params dynamic[] controls)
        /* Bu metot sadece params keyword (parametreler anahtar kelimesi) ve dynamic
         * veri tipine örnek olmasý açýsýndan yazýlmýþtýr. Bu metot Parametre olarak
         * dynamic tipinde birden fazla veriyi alabilir. Mesela; ComboBox tipli
         * birçok kontrolü bu metoda gönderip temizlenmesini saðlayabilirsiniz.
         * Farklý kontroller de olabilir, mesela: Üç TextBox, iki Label, beþ Button
         * gibi.
         */
        {
            if (controls == null) return;
            /* dynamic dizisi tipindeki controls deðiþkeni null ise temizlenecek veri
             * de olmayacaðý için return ile iþlemi bitiriyoruz.
             */
            try
            /* Dene hata var mý? Burada mutlaka try kullanmak gerekli oldu.
             * yazýldý.
             */
            {
                foreach (dynamic ctrl in controls)
                /* foreach döngüsü için deðiþkenimin tipi dynamic, adý ctrl. Bu
                 * deðiþken controls içeriðinde hareket eder. controls neydi?
                 * Hatýrlatma: "params dynamic[] controls", yani; kullanýcýnýn
                 * sunduðu dynamic tipli dizi. Kýsaca; temizlemek için parametreye
                 * gönderdiði kontroller.
                 */
                {
                    ctrl.Text = string.Empty;
                    //dynamic tipindeki ctrl deðiþkeni metin özelliðini boþalt.
                    ctrl.Items.Clear();
                    /* dynamic tipindeki ctrl deðiþkeni elemanlarýný temizle.
                     * Ýþte sorun burada baþlýyor. Her kontrolün items özelliði
                     * yok. Böylece hata oluþuyor. dynamic tipini kullanmak yerine
                     * her tipe uygun olan temizleme metodunu da yazabilirdim, ancak
                     * o zamanda dynamic veri tipini nerede kullanabileceðimize dair
                     * bir örnek yapamamýþ olacaktým.
                     */
                }
            }
            catch (Exception ex)
            //Hatayý yakalarsan bu kapsamdan devam et (hatayý ex deðiþkenine at)
            {
                Debug.WriteLine(ex.Message);
                /* Hatayý Debug modunda yaz. Kullanýcýya mesaj kutusu ile gösterip
                 * rahatsýz etmek istemedim. Boþ olmasýný da istemedim. Dileyenler
                 * projeyi debug mod ile çalýþtýrýp, output penceresinden
                 * hataya bakabilirler.
                 */
            }
        }
        PrintDocument printDocument;
        //Yazýcý çýktýsý alabilmek için bu deðiþkeni iki farklý metotta kullanacaðým.
        private Bitmap bitmap;
        //Bu deðiþken, yazýcýdan almak istediðim çýktýnýn resmini taþýyacak.
        private void SplitButtonPrint_Click(object sender, EventArgs e)
        {
            printDocument = new();
            // Yeni bir yazýcý dokümaný tanýmladým.
            printDocument.PrintPage += PrintDocument_PrintPage;
            /* PrintDocument tipindeki Component (bileþen)için, yazýcýdan sayfayý
             * çýktý olarak alýrken olayýný tanýmladým. PrintPageEventArgs e
             * deðiþkeni Graphics özelliði DrawImage metoduna yazýcýdan çýktýsý
             * alýnacak resmi de göndereceðim.
             */
            PrintDialog printDialog = new();
            /* Yazýcýdan çýktý alýrken kullanmak üzere bir PrintDialog tipindeki
             * deðiþkenimi tanýmladým.
             */
            printDialog.Document = printDocument;
            /* Yazýcý diyalog penceresinin doküman özelliðine printDocument
             * deðiþkenini atadým.
             */
            printDialog.UseEXDialog = true;
            //Kullanýlabilecek yazýcýlarýn listesi görüntülensin.
            bitmap = new Bitmap(_dataGridView.Width, _dataGridView.Height);
            /* Bitmap tipindeki deðiþkenim için bir örnek aldým. Resmin Geniþliði ve
             * yükseklik deðerini bildirdim.
             */
            _dataGridView.DrawToBitmap
            (bitmap, new Rectangle(20, 20,
                _dataGridView.Width, _dataGridView.Height));
            /* _dataGridView kontrolünün Bitmap çizen metodunu kullandým.
             * 1.Parametre: x apsisine olan uzaklýk:20. Yani: Sol kenardan boþluk.
             * 2.Parametre: y ordinatýna olan uzaklýk:20. Yani: Üst kenardan boþluk.
             * 3.Parametre: resmin geniþliði. 4.Parametre: resmin yüksekliði.
             */
            DialogResult result = printDialog.ShowDialog();
            /* Yazýcý diyalog penceresinden geriye dönen deðeri kullanabilmek için
             * DialogResult tipinde bir deðiþken tanýmladým. Böylece kullanýcý
             * yazdýrmayý istemediðinde iptal de edebilir.
             */
            if (result == DialogResult.OK)
            /* Eðer diyalog penceresinde iken OK butonuna basýldý ise, yani; belge
             * yazdýrýlacak ise
             */
            {
                printDocument.DocumentName = Environment.MachineName;
                //Yazýcý dokümanýna isim ver = Kullanýcýnýn bilgisayar adýný kullan.
                printDocument.DefaultPageSettings.Landscape = true;
                //Varsayýla yazýcý ayarlarýndan Yatay çýktý alýnma özelliði aktiftir.
                printDocument.Print();
                //Dokümaný yazdýr.
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
            /* PrintPageEventArgs tipindeki e deðiþkeninin Grafikler özelliðinin
             * DrawImage (Resim Çiz) metodu ile (bitmap deðiþkenindeki resmi çiz
             * x ve y eksenlerinden 0 birimi uzaklýk býrak).
             */
        }
    }
}
