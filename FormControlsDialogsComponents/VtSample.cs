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
        {   //Formun ad� VTSample.
            InitializeComponent();
            //Buras� standart olarak olu�an kurucu metot.
        }
        /* Bu tan�mlar�n yap�ld��� yer �sim Alan�d�r (NameSpace Scope). E�er hi�bir
         * Metot veya �zelli�in i�inde de�ilseniz �sim Alan�n� (NameSpace Scope)
         * kullan�yorsunuz demektir. Genelde bu alanda tan�mlanan de�i�kenler t�m
         * isim alan�nda kullan�lmas� istenen de�i�kenlerdir. Burada tan�mlad���m
         * de�i�kenler bu kapsamda (scope) birden fazla metot i�inde laz�m oldular.
         * Ba�ka bir s�n�fta kullanmay� d���nmedi�im i�in eri�im belirtecini
         * private olarak belirledim. Bu belirleme neticesinde art�k birer �zellik
         * (property) de�il alan (field) olarak g�rev yapacaklar. D��ar�dan bir
         * s�n�ftan atama yap�lamayacak. C# zorunlu olmayan yaz�m kaideleri gere�i
         * alanlar (fields) _de�i�kenAdi �eklinde adland�r�l�rlar.
         */

        #region Buras�, s�n�f (class) i�in genel kullan�ma a��k de�i�kenler
        private DataTable _dataTable;
        /* SQL Tablosundan veri �ekip DataTable tipindeki _dataTable de�i�keninde
         * saklayaca��m.
         */
        private BindingSource _bindingSource;
        /* SQL Tablosundan veri �ekip DataTable tipindeki _dataTable de�i�keninden
         * bindingSource de�i�kenine aktaraca��m.
         */
        private DataGridView _dataGridView;
        /* DataGridView: SQL Tablosundan �ekilen verileri g�r�nt�lemek �zere
         * tasarlanm�� bir kontrold�r. Izgaralar i�erisine yerle�tirilmi� sat�r
         * ve s�tunlar� vard�r.
         */
        private NotifyIcon _notifyIcon;
        // Bilgi ikonu kontrol� tan�mlad�m.
        private ToolStripComboBox _toolStripComboFilter, _toolStripComboBox;
        /* ToolStripComboBox tipinde 2 de�i�kenim var. ToolStripComboBox bile�eni
         * (Component) bir ComboBox kontrol� de�ildir, �ok benziyor ancak tipleri
         * ayn� de�il. ComboBox �zellikleri g�steren bir bile�endir (Component).
         * ToolStripComboBox StatusStrip bile�enine (Component) eklemek amac�
         * ile kullan�lacakt�r
         */
        private ToolStripStatusLabel _toolStripStatusLabel, _toolStripLabel;
        /* ToolStripStatusLabel tipinde 2 de�i�kenim var. ToolStripStatusLabel
         * bile�eni (Component) bir Label kontrol� de�ildir. Label �zellikleri
         * g�steren bir bile�endir (Component). ToolStripStatusLabel StatusStrip
         * bile�enine (Component) eklemek amac� ile kullan�lacakt�r
         */

        private int _yukseklik;
        /* Form y�klenirken ileride gerekli olacak form y�ksekli�i bilgisini
         * sakl�yoruz. Filtreli form y�ksekli�ini forma g�re de�i�tirdikten
         * sonra, filtreleme i�leminden vazge�ilirse form eski y�ksekli�ine
         * d�nebilecek. Formun ilk y�ksekli�ine d�nmesi i�in bu de�eri
         * kullanaca��m.
         */
        private StatusStrip _statusStrip;
        private BindingNavigator _bindingNavigator;
        /* Bu iki kontrol�n bu s�n�f�n her yerinde kullan�labilmesi gerekmiyordu
         * ancak yine de bu s�n�f i�in global olan alanda tan�mlad�m. Formun 
         * y�kseklik de�erine etki ettikleri i�in, filtrelenen verilere g�re
         * y�kseklik de�eri bulurken bu kontrollerin y�kseklik de�erleri laz�m
         * olacak.
         */

        //Not: Direk yaz�lan (this. yazmadan) her �zellik atamas� Forma yap�l�r.
        #endregion Buras�, s�n�f (class) i�in genel kullan�ma a��k de�i�kenler

        private void VTSample_Load(object sender, EventArgs e)
        {/* Buras� Formun y�klenmesi ile �al��an bir olay metodu. Bu metot formun
          * y�klendi�ini anlar ve Load olay� ger�ekle�ti�inde otomatik olarak
          * �al���r.
          */
            #region Formun �zellikleri
            WindowState = FormWindowState.Normal;
            /* Form penceresinin nas�l g�r�nt�lenece�ini ifade eder. Form ekran�
             * kaplayabilir Maximized �zelli�i. Form simge durumuna k���lt�lebilir
             * Minimized �zelli�i. Form varsay�lan boyutta (Normal) g�r�nt�lenir.
             */
            FormBorderStyle = FormBorderStyle.FixedSingle;
            /* Formun kenarl�k stilini belirliyorum. E�er FormBorderStyle enum
             * listesinden FixedSingle se�ilirse, form yeniden boyutland�r�lamaz.
             * Sizable se�ilirse form boyutland�r�labilir.
             */
            Left = Top = 0;
            //Formun Windows'a g�re Sol ve �st kenardan uzakl�k de�eri 0 olsun.
            Size = Screen.PrimaryScreen.WorkingArea.Size;
            /* Formun boyutu = Screen s�n�f�n�n, birincil ekran�, �al��ma boyutu
             * ile ayn� olsun. Bendeki size de�eri 1.920x1.040 ��k�yor, ��nk�
             * Windows g�rev �ubu�u boyutu 40, b�ylece 1920x1080 tamamlanm��
             * oluyor. Formumuz g�rev �ubu�unu kapatmam�� oluyor.
             */
            _yukseklik = Size.Height;
            /* Form y�klenirken ileride gerekli olacak form y�ksekli�i bilgisini
             * sakl�yoruz. B�ylece filtreli form y�ksekli�i forma g�re de�i�ti�inde
             * eski boyutunu bu de�i�kenden alaca��m. Filtreleme i�lemi iptal
             * edilince de, bu de�i�kendeki de�er sayesinde form eski y�ksekli�ine
             * d�nebilecek.
             */
            ShowInTaskbar = false;
            //Form, G�rev �ubu�unda bir simge olarak g�r�nmesin.
            AutoScroll = true;
            /* Formda, e�er gerekli oldu ise otomatik olarak kayd�rma �ubu�u
             * g�r�ns�n. Nas�l gerekli olur? Formdaki bir kontrol, mesela bizdeki
             * DataGridView kontrol� gibi, formdan daha uzun ise dikey, daha geni�
             * ise yatay kayd�rma �ubu�u "AutoScroll = true;" kodu sayesinde
             * otomatik olarak g�r�n�r.
            */
            #endregion Formun �zellikleri Tan�mland�

            #region SQL Server Ba�lant�s� ve DataTable
            SqlConnectionStringBuilder builder = new();
            /* Hen�z SQL Server konusuna s�ra gelmedi ama, DataGridView kontrol�
             * en g�zel, SQL Tablolar� ile anlat�l�yor. �htiya� kadar�n� anlatay�m.
             * SqlConnectionStringBuilder s�n�f�ndan bir �rnek al�yoruz. SQL Server
             * ile ba�lant� sa�layaca��m. At�k builder de�i�keni
             * SqlConnectionStringBuilder s�n�f�n�n bir �rne�ini ifade ediyor.
             * Bu de�i�ken vas�tas� ile server ba�lant�s� i�in bir ba�lant� c�mlesi
             * olu�turaca��m.
             */
            string BilgisayarAdi = Environment.MachineName;
            /* Environment s�n�f� mevcut platform ile ilgili bilgiler i�eren bir
             * s�n�ft�r. Ben SQL ba�lant�s� i�in makine ad�n� al�yorum.
             */
            builder.DataSource = BilgisayarAdi;
            /* E�er sizde benim gibi kendi bilgisayar�n�za kurdu�unuz bir SQL
             * Server ile ba�lant� yapacaksan�z; localhost veya nokta (.)
             * ifadelerini de kullanabilirsiniz. Ben Bilgisayar Ad�n� nas�l
             * bulursunuz �rnek yapmak istedim. DataSource �zelli�ine BilgisayarAdi
             * de�i�kenini atad�m. Buraya ge�erli bir IP de�eri de yaz�labilir.
             * Bende kurulu olan SQL Server yerel bilgisayar�mda. Sizde de b�yle
             * ise, dileyen localhost, dileyen nokta (.), dileyen de bilgisayar
             * ad�n� yazabilir.
             */
            builder.InitialCatalog = "Northwind";
            //InitialCatalog �zelli�ine veritaban�n�n ad�n� atad�m.
            builder.UserID = "sa";
            /* SQL Kullan�c�s� = "sa", bu ad "sa" SQL Server standard�. Bir SQL
             * kullan�c� ad�. Server Administrator (Veritaban� Y�neticisi) anlam�na
             * geliyor. T�m yetkilere sahip bir kullan�c�. E�er SQL Server �zerinde
             * de�erli bilgileriniz var ise sa kulan�c�s� t�m�ne eri�ebilir,
             * silebilir, de�i�tirebilir.
             */
            builder.Password = "123";
            //Bendeki SQL �ifresi.
            //builder.IntegratedSecurity = true;
            /* SQL Server ba�lant�s� yaparken, kullan�c� ad� ve �ifre  ile sisteme
             * giri� yapabilece�iniz gibi, Windows kullan�c�s� ile de giri�
             * yapabilirsiniz. Bunu sa�layan �zellik IntegratedSecurity
             * �zelli�idir. Madem Windows kullan�c�s� ile de giri� yap�l�yor, ni�in
             * SQL kullan�c� ad� ve �ifresi ile giri� yapan kodu yazd�m? ��nk� bir
             * server �zerinde iseniz ve Active Directory sistemi kurulu ise
             * yetkiniz de yok ise SQL Server eri�imi i�in kullan�c� ad� ve �ifreyi
             * yazmaktan ba�ka bir �ans�n�z yok, bu �rnek akl�n�z�n bir k��esinde
             * bulunsun.
             */
            using SqlConnection sqlConnection
                = new SqlConnection(builder.ToString());
            /* SqlConnection s�n�f�n�n 3 kurucu metodundan birini kullanarak �rne�ini
             * al�yorum. Bu metot do�rudan metinsel bir ba�lant� c�mlesini de kabul
             * eder. Ben �rne�i yaparken �zelliklere de�er atamas� yapt�m ki, farkl�
             * bir �rnek yapm�� olay�m. Genelde hep ��yle yaz�l�yor:
             * "Data Source=.; Database=Northwind; User Id=sa; Password=123".
             * B�ylece SqlConnection ba�lant�s� haz�r. C# 8.0 ile gelen using
             * declarations sayesinde, SqlConnection Ram �zerinden otomatik olarak
             * kald�r�labilir (Dispose).
             */
            using SqlDataAdapter sqlDataAdapter = new
                ("Select * From Products", sqlConnection);
            /* Ba�lant�y� yapabilmek i�in bir adapt�re ihtiyac�m�z var. SqlDataAdapter
             * s�n�f�ndan bir �rnek al�yorum. Bu �rne�i SqlDataAdapter s�n�f�n�n
             * 4 kurucu metodundan birini kullanarak ald�m. Bu kurucunun,
             * 1. parametresi: SQL Select Komutu metni istiyor, onu yazd�m.
             * 2. parametresi: SqlConnection tipinde bir de�i�ken al�yor.
             * SqlConnection ba�lant�s� i�eren de�i�keni bu parametreye sundum.
             * C# 8.0 ile gelen using declarations sayesinde, SqlDataAdapter
             * Ram �zerinden otomatik olarak kald�r�labilir (Dispose).
             */
            _dataTable = new();
            /* dataTable alan�n�m (field) i�in DataTable s�n�f�ndan bir �rnek
             * ald�m. B�ylece bir DataTable haz�rland�. DataTable i�erisindeki her
             * bir DataSet bir veri k�mesini ifade edecek.
             */
            try
            /* Dene Yakala (try catch) blo�u yaz�yorum. Neden? E�er adapt�r�m�z
            * ba�lant� sa�layamazsa kullan�c�ya bunu bildirece�iz, birde try-catch
            * blo�unun yaz�lmas� hakk�nda bir hat�rlatma yapmak istedim.
            */
            {
                DataSet dataSet = new();
                /* DataSet bir veri k�mesini ifade eder. Yani; Bir �ok tablo
                 * i�erebilir. E�er sadece bir tablo i�in, bir ba�lant� yapt�ysan�z
                 * DataSet kullanmadan do�rudan tabloyu (DataTable) kullanabilirsiniz
                 * DataSet bir tablo saklay�c�, DataTable ise Veritaban�ndaki
                 * tablolar toplulu�u olarak d���n�lebilir. �leride DataSet
                 * kullanman�z gerekebilir, birden fazla DataBase tablosu ile i�lem
                 * yaparsan�z, DataSet size nas�l yard�mc� olabilir bunu
                 * a��kl�yorum. As�l �rnekler Ado.Net konusunda yap�lacakt�r. Burada
                 * ama� DataSet Component (Veri K�mesi Bile�eni) hakk�nda basit bir
                 * �rnek yapmakt�r.
                 */
                _dataTable.TableName = "1.Tablom";
                //_dataTable tabloma bir ad verdim = "1.Tablom"
                dataSet.Tables.Add(_dataTable);
                /* DataSet Veri K�mesi Bile�enine (Component) tablo ekliyorum.
                 * Eklenen tablom _dataTable de�i�kenidir.
                 */
                sqlDataAdapter.Fill(dataSet.Tables["1.Tablom"]);
                //sqlDataAdapter.Fill(dataSet.Tables[0]); //�eklinde de yaz�labilir.
                /* SqlDataAdapter tipindeki adapt�r�m�zdeki veriyi doldur, nereye?
                 * (dataSet.Tables["1.Tablom"] olan tabloya). B�ylece "Select * From
                 * Products" sorgusundan d�nen SQL Tablosu, bu bile�ene (component)
                 * doluyor. E�er DataTable do�rudan kullan�lsa idi bu parametreye
                 * _dataTable sunulabilirdi. Yani;
                 * sqlDataAdapter.Fill(_dataTable); yaz�labilirdi.
                 */
            }
            catch (Exception ex)
            /*Hata varsa ve yakaland� ise (olu�an istisnay� ex de�i�kenine aktar.)*/
            {
                throw new Exception($"Server Ad�: {builder["Server"]} veya \n" +
                    $"Database Ad�: {builder["Database"]} ya da \n" +
                    $"Ba�lant� Adapt�r�: {typeof(SqlDataAdapter)} hatal� \n" +
                    $"veya olas� di�er hatalar {ex.Message}");
                /* Bir hata f�rlat. builder �zelli�ine atanan de�erlerden hataya
                 * neden olabilecek olanlar� {yazd�m}. Bir de catch (Exception ex)
                 * sat�r�nda bulunan ex de�i�keninin de�erini de ekrana bast�m.
                 */
            }
            #endregion SQL Server Ba�lant�s� ve DataTable

            #region Formu Yatay B�lmek (SplitContainer ve Horizontal)

            SplitContainer splitContainer = new();
            /* SplitContainer kontrol�nden bir �rnek al�yorum. Bu kontrol ile formu
             * ikiye b�lmeyi hedefliyorum.
             */
            splitContainer.Orientation = Orientation.Horizontal;
            //SplitContainer kontrol� y�n� = Yatay olarak formu b�l�yorum.
            splitContainer.Dock = DockStyle.Fill;
            /* Formu b�len kontrol�n yuvalanma �zelli�i = Kullan�ld��� kontrolde
             * (biz formda kullan�yoruz) kontrol�n kenarlar�na sabitlenir ve
             * kontrole uygun �ekilde boyutland�r�l�r. SplitContainer Formun
             * boyutu kadar olur. 
             */
            //splitContainer.FixedPanel = FixedPanel.Panel1;
            /* B�lme paneli formu ikiye b�ler ve varsay�lan olarak Panel1 ve Panel2
             * enum elemanlar� vard�r. �st panel, Panel1 ve alt panel Panel2 olarak
             * kullan�l�r. Form ikiye b�l�nd���nde varsay�lan olarak, ortadan
             * b�l�n�r. splitContainer.FixedPanel (ayn� boyutta kalma �zelli�i)
             * uygula = Panel1 kapsay�c�s� (splitContainer) ile yeniden
             * boyutland�rmaya tabi olmas�n. B�ylece bu b�lgede boyutland�rma
             * yap�lmayacak, niyetim Panel1'in men� ba�l��� i�in kullan�lmas�.
             */
            Controls.Add(splitContainer);
            /* Forma kontrol ekle (SplitContainer kontrol�n� ekle). Formu
             * yatay olarak b�len splitContainer.Panel1 ve splitContainer.Panel2
             * forma eklendi.
             */
            #endregion Formu Yatay B�lmek (SplitContainer ve Horizontal)

            #region Veriler �zerinde Gezinme (BindingNavigator ve BindingSource)

            _bindingNavigator = new(true);
            /* BindingNavigator kontrol�n�n veri kayna��na (data source) bir
             * veri k�mesi ba�laman�z halinde, ba�lad���n�z bu veri kayna��nda
             * gezinmenizi sa�lar. Bir BindingNavigator �rne�i (instance) al�yorum.
             */
            _bindingSource = new();
            /* BindingNavigator kontrol�n�n gezintisini yapabilmesi i�in
             * BindingSource s�n�f�n�n bir �rne�ini (instance) al�yorum. Yani;
             * bu kontrol hangi veri kayna��nda gezecek bunu sunmam�z laz�m.
             */
            _bindingSource.DataSource = _dataTable;
            /* BindingSource s�n�f�n�n veri kayna�� �zelli�ine atama yap�yorum.
             * sqlDataAdapter.Fill(_dataTable); kod sat�r� ile i�eri�i,
             * Veritaban�ndaki Products tablosunun verileri ile dolan
             * (SqlDataAdapter i�in yaz�lan sorgu: ("Select * From Products) bu kod
             * blo�unu hat�rlay�n�z) _dataTable alan� (field), bindingSource i�in
             * bir veri kayna�� olarak kullan�ls�n. Art�k bir veri kayna�� var.
             */
            _bindingNavigator.BindingSource = _bindingSource;
            /* BindingNavigator kontrol�n�n gezintisini yapabilmesi i�in kullan�lan
             * �zelli�i olan BindingSource �zelli�ine atama yap�yorum. BindingSource
             * tipindeki bindingSource de�i�kenini atad�m. Bu de�i�ken ise
             * DataSource olarak _dataTable al�yordu. DataTable ise, SqlDataAdapter
             * i�in yaz�lan sorgudaki tabloyu i�eriyordu. Sonu�: Products tablosunda
             * gezinme �zelli�i elde ettim.
             */
            _bindingNavigator.DeleteItem.Enabled = false;
            /* BindingNavigator kontrol�n�n silme �zelli�ine false atad�m. ��nk� bu
             * ba�lant� sonucunda bir veri silme i�lemi yapan kod yazmad�m. Sadece
             * gezinece�im. B�ylece veri silme yap�lamas�n. Asl�nda veriyi
             * silebilseniz ne olur? Silinmi� gibi g�r�n�r, veri as�l kayna�� olan
             * tablodan silinmez.
             */
            _bindingNavigator.AddNewItem.Enabled = false;
            /* BindingNavigator kontrol�n�n yeni kay�t ekleme �zelli�ine false
             * atad�m. ��nk� bu ba�lant� sonucunda bir veri ekleme i�lemi yapan kod
             * yazmad�m. Sadece gezinece�im. B�ylece veri ekleme yap�lamas�n. Veriyi
             * ekleseniz ne olur? Eklenmi� gibi g�r�n�r, veri as�l kayna�� olan
             * tabloya eklenmez.
             */
            splitContainer.SplitterDistance = _bindingNavigator.Height;
            /* SplitterDistance �zelli�i: ay�r�c�n�n sol veya �st kenar�ndan piksel
             * cinsinden konumunu al�r veya ayarlar. Konu bir anda de�i�ti, de�il mi?
             * splitContainer kontrol�n�n b�l�c�n�n uzakl�k ayar�na (Splitter
             * Distance) atama yap = Varsay�lan de�er olan 50 piksel i�ime yaramad���
             * i�in _bindingNavigator kontrol�n�n y�ksekli�ini atad�m.
             * _bindingNavigator kontrol� ile formdaki Products tablosu verilerinde
             * gezinti yapabiliyorduk.
             */
            splitContainer.Panel1.Controls.Add(_bindingNavigator);
            /* splitContainer kontrol�n�n 1. paneli  olan Panel1 �zelli�ine kontrol
             * ekle (_bindingNavigator yani gezinme kontrol�n� ekle). Art�k form
             * �zerindeki Products tablosu verilerinde, oklar yard�m� ile ileri ve
             * geri olarak gezinebiliriz.
             */
            #endregion Veriler �zerinde Gezinme (BindingNavigator ve DataSource)

            #region DataGridView Kontrol� ile Veri G�r�nt�lemek
            _dataGridView = new();
            /* DataGridView kontrol�nden bir �rnek al�yorum. Amac�m: Northwind
             * veritaban�ndaki Products tablosunu g�r�nt�lemek.
             */
            _dataGridView.AllowDrop = _dataGridView.AllowUserToAddRows = false;
            /* DataGridView kontrol�nde ta��ma i�lemine izin verilmesin.
             * DataGridView kontrol�ne kullan�c�n�n veri eklemesine izin
             * verilmesin.
             */
            _dataGridView.AllowUserToDeleteRows = false;
            //DataGridView kontrol�ne kullan�c�n�n veri silmesine izin verilmesin.
            _dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Se�im Modu = Bir sat�r se�ilince, o sat�r�n t�m� se�ili olsun.
            _dataGridView.AutoResizeColumns();
            /* T�m s�tunlar otomatik olarak, verinin geni�li�e g�re ayarlanabilsin.
             * B�ylece: S�tunlar �zerindeki, s�tun ay�r�c� �izgilerine t�klay�nca
             * s�tun geni�li�i otomatik olarak ayarlanabilir.
             */
            _dataGridView.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.DisplayedCells;
            /* S�tun geni�li�i otomatik olarak ayarlan�rken modu �u olsun:
             * S�tun ba�l�klar� dahil olmak �zere, g�r�nen h�crelere g�re
             * otomatik s��d�rma i�lemi yap�ls�n.
             */
            _dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            /* D�zenleme modu: D�zenleme yap�lamas�n. Sadece BeginEdit(Boolean)
             * metodu kullan�l�rsa d�zenleme yap�labilir. Mesela, fareye t�klanan
             * sat�rda d�zenleme yap�lmas�n� isteyebilirsiniz. D�zenleme modunun
             * a��lmas� i�in: DataGridView.BeginEdit(true); olarak atanmal�d�r.
             */
            _dataGridView.DataSource = _bindingSource;
            /* _dataGridView kontrol�n�n kay�t kayna�� = bindingSource olsun.
             * �ki farkl� kay�t kayna�� kullanabilirim:
             * 1-) bindingSource, 2- _dataTable. Neden _dataTable kullanmad�m?
             * E�er bindingSource kullanmazsam _bindingNavigator butonlar� ile
             * ileri, geri hareket etti�im sat�r _dataGridView kontrol�
             * taraf�ndan g�r�nt�lenmez, ��nk�; kay�t kayna�� farkl� olmu�tur.
             */
            _dataGridView.Dock = DockStyle.Fill;
            /* _dataGridView kontrol� yuvalanma bi�imine atama yap: �zerinde
             * bulundu�u kontrole tam olarak hizalans�n, doldurulsun. _dataGridView
             * bir konteyner paneli (splitContainer.Panel2) i�erisine dahil edilecek.
             */
            _dataGridView.ColumnHeadersVisible = true;
            //S�tun ba�l�klar� g�r�n�r olsun.
            splitContainer.Panel2.Controls.Add(_dataGridView);
            /* SplitContainer tipindeki b�lme panelinin 2. b�lmesine Kontrol
             * ekliyorum (_dataGridView) kontrol�. B�ylece ilk b�lme panelinde
             * _bindingNavigator, ikinci b�lme panelinde _dataGridView var.
             */
            DataGridViewRowColor(_dataGridView);
            /*_dataGridView kontrol�n�n bir sat�r�n� bir renk, di�erini ba�ka bir
             * renk yapan yapan bir metot yazd�m (parametre olarak sat�r�n�
             * renklendirmek istedi�im _dataGridView kontrol�n� sunuyorum).
             */
            _dataGridView.DataBindingComplete += DataGridView_DataBindingComplete;
            /* _dataGridView kontrol�ne bir event method (olay metodu) tan�ml�yorum.
             * Amac�m, kontrole veri y�klemesi tamamland��� (DataBindingComplete)
             * anda bir olay metodu ile baz� kodlar�n �al��mas�n� sa�lamak.
             * Kontrole nokta ekliyorum ve Olay metodunu buluyorum. Sonra += i�areti
             * ekleyip Tab tu�una iki defa bas�yorum. B�ylece otomatik olarak olay
             * metodu olan, DataGridView_DataBindingComplete olay� olu�uyor. Olay
             * metoduna ge�erek kodlar�m� yaz�yorum. Bu olay metodu ile LabelWriter
             * adl� bir metot ile ...ToolStripStatusLabel kontrollerine baz�
             * bilgiler yazd�r�p, kullan�c�ya bilgi sunaca��m. */
            #endregion DataGridView Kontrol� ile Veri G�r�nt�lemek
            _statusStrip = new();
            /* Yeni bir durum �ubu�u (StatusStrip) kontrol� �rne�i al�yorum. Bu
             * kontrol formun alt�na yerle�ir ve kullan�c�ya bilgi sunabilece�iniz
             * bir panel olu�ur. Bu panele, Label, ComboBox, buton benzeri kontroller
             * ekleyebilirsiniz.
             */
            _toolStripStatusLabel = new();
            _toolStripLabel = new();
            /* Durum �ubu�una (StatusStrip) Label kontrol�ne benzeyen
             * ToolStripStatusLabel kontrol� ekleyece�im. Bir �rne�ini ald�m.
             * Yaln�z dikkat edilmesi gereken nokta, ToolStripStatusLabel kontrol�,
             * ad�ndan da anla��laca�� �zere StatusStrip kontrol�ne eklenecek, forma
             * eklenmeyecek. StatusStrip kontrol� ise forma eklenecek. �ki de�i�ken
             * i�in de ayr� ayr� �rnek ald�m.
             */
            ToolStripButton toolStripButton = new();
            /* StatusStrip kontrol�ne eklemek �zere, Button kontrol�ne benzeyen
             * ToolStripButton kontrol�n�n bir �rne�ini ald�m.
             */
            ToolStripSplitButton toolStripSplitButton = new();
            /* ToolStripSplitButton tipinde bir de�i�ken tan�mlad�m ve �rne�ini
             * de�i�kene aktard�m. Bu butona bir ikon ekleyece�im. _dataGridView
             * kontrol�n� bu buton ile Filtrelemeyi planl�yorum.
             */
            ToolStripSplitButton splitButtonPrint = new();
            /* Bu buton ile yazd�rma i�lemleri yapaca��m. Butona bir yaz�c� ikonu
             * ekleyip, gerekirse kullan�c�n�n yaz�c�dan ��kt� almas�n� sa�layaca��m.
             */

            _toolStripComboFilter = new();
            _toolStripComboBox = new();
            /* Birde ComboBox kontrol�ne benzeyen bir kontrol�m�z var. Bunlarda
             * Durum �ubu�una (StatusStrip) eklenecek. Birinde s�tun ba�l�klar�n�
             * di�erinde bu ba�l�klar�n verilerini g�r�nt�lemek �zere
             * ToolStripComboBox kontrol�nden �rnek ald�m. S�tun ba�l�klar� Products
             * tablosundaki s�tunlar olacak. Veriler ise bu s�tunlar� i�eren a��lan
             * kutudan se�im yap�ld���nda dolacak.
             */
            _statusStrip.Items.Add(_toolStripStatusLabel);
            /* �lk olarak Durum �ubu�una (StatusStrip) _toolStripStatusLabel
             * kontrol�n� ekliyorum.
             */
            ToolStripSeparator toolStripSeparator = new();
            //ToolStripSeparator: StatusStrip �zerinde bir b�lme �izgisidir.
            _statusStrip.Items.Add(toolStripSeparator);
            //StatusStrip kontrol�ne, B�lme �izgisini ekledim. 
            _statusStrip.Items.Add(_toolStripLabel);
            //StatusStrip kontrol�ne, _toolStripLabel ekledim.
            _statusStrip.Items.Add(_toolStripComboBox);
            //StatusStrip kontrol�ne, _toolStripComboBox ekledim.
            ToolStripComboBoxFill(_toolStripComboBox, out int gridGenislik);
            /* Bir metodum var ad�: ToolStripComboBoxFill. Bu metot parametresine
             * sunulan ToolStripComboBox_ tipindeki kontrole veri y�klemesi yapar.
             * Sonra bu veri ile dolan _dataGridView kontrol�n�n geni�lik de�eri
             * olarak kullan�lmak �zere int tipindeki bir de�i�kende olu�an de�eri
             * d��ar� atar. Peki d��ar� att��� geni�lik neyin geni�li�i? �u kodu
             * inceleyiniz; "genislik += dataGridViewColumn.Width". 
             */
            _toolStripComboBox.SelectedIndexChanged +=
                ToolStripComboBox_SelectedIndexChanged;
            /* _toolStripComboBox kontrol�nden bir se�im yap�ld���nda �al��acak bir
             * olay metodu (SelectedIndexChanged) tan�ml�yorum. _toolStripComboBox
             * yazd�m, nokta ekledim += i�aretinden sonra iki kez tab tu�una bast�m.
             * Olay metodu otomatik olarak yaz�ld�. ��erik olarak �unu kodlad�m: 
             * _toolStripComboBox kontrol�nde se�ilen veriye g�re (Products tablosu
             * s�tunlar�ndan biri se�iliyor) di�er kontrol� (_toolStripComboFilter)
             * doldurdum. Neyi doldurdum? A��lan kutudan se�ilen s�tun ad�na g�re,
             * s�tun i�eri�indeki verileri doldurdum.
             */
            _statusStrip.Items.Add(_toolStripComboFilter);
            //StatusStrip kontrol�ne, _toolStripComboFilter a��lan kutusunu ekledim. 
            _statusStrip.Items.Add(toolStripButton);
            //StatusStrip kontrol�ne, toolStripButton butonunu ekledim. 
            toolStripButton.Click += ToolStripButton_Click;
            //StatusStrip kontrol�ne eklenen butonuma, t�klama olay metodu ekledim.
            toolStripButton.Text = "Filtrele";
            /* Butonda metin olarak = Filtrele yazd�m. Butona bir kez t�klan�nca,
             * _dataGridView kontrol� ComboBox verileri baz al�narak filtrelenecek.
             */
            string directoryInfo =
                Directory.GetParent(Application.StartupPath).Parent?.FullName;
            /* Butonuma bir ikon eklemek istiyorum. �konun bilgisayar�mdaki yolunu
             * tan�mlamak i�in metin tipinde bir de�i�ken tan�mlad�m. Klas�r
             * komutlar�n� y�neten ve statik bir s�n�f olan Directory s�n�f�n�n
             * metot ve �zelliklerinden yararlanaca��m. Fark ettiyseniz bu s�n�fta
             * new anahtar kelimesi ile s�n�f�n bir �rne�ini almad�m, ��nk� statik
             * bir s�n�f. Ben statik oldu�unu nas�l anlar�m derseniz; Class ad�
             * �zerinde iken fareyi sa� t�klay�p Go To Definition komutuna
             * t�klay�n�z. S�n�f tan�m�nda static referans�n� g�rebilirsiniz.
             * �kon resmini proje klas�r�ne ekledim. Bu resmi, C# program�n�n
             * g�rebilmesi i�in bir yol belirlemek gerekir. Statik s�n�flarda
             * veya statik olmayan s�n�flar�n statik olan metot ve �zellikleri
             * �rnek al�nmadan kullan�labilir. Directory s�n�f�n�n GetParent
             * metoduna uygulaman�n yolunu bilen bir �zellik olan
             * Application.StartupPath �zelli�ini sundum, StartupPath �zelli�i de
             * Application s�n�f� i�inde statik olarak tan�mlanm�� durumda.
             * Parent �zelli�i �st klas�r� bulur. Soru i�areti ise null kontrol�
             * yapar. FullName �zelli�i, bulunan klas�r�n t�m yol bilgisini d�nd�r�r.
             * Son olarak da ikonumun ad� ve uzant�s�n� (\\Chart.png)
             * ekleyece�im. Butonuma resim eklemek i�in yol tan�m� art�k haz�r.
             */
            toolStripSplitButton.Image =
                Image.FromFile(directoryInfo + "\\Chart.png");
            /* toolStripSplitButton kontrol�ne imaj ekle = Image s�n�f� Drawing
             * isim alan�n�n abstract bir s�n�f�d�r. Drawing.Image s�n�f�n�n,
             * statik bir metodu olan FromFile metoduna resmin klas�r yolu ve dosya
             * ad� bilgisini i�eren de�i�kenimi sundum. "\\Chart.png"
             * ve ikonunu ekledim.
             */
            toolStripSplitButton.Click += ToolStripSplitButton_Click;
            /* toolStripSplitButton nokta Click += tu�lar�na bast�m. Click
             * olay� aktif hale geldi. Bu butona t�klad���mda bir grafik (Chart)
             * olu�acak.
             */
            _statusStrip.Items.Add(toolStripSplitButton);
            /* StatusStrip kontrol�ne, toolStripSplitButton butonunu ekledim.
             */
            splitButtonPrint.Image = Image.FromFile(directoryInfo + "//printer.png");
            //Butona bir printer ikonu ekledim.
            splitButtonPrint.Click += SplitButtonPrint_Click;
            _statusStrip.Items.Add(splitButtonPrint);
            /* Printer ikonu i�eren butona t�klan�nca yazd�rma i�lemi kodlar�
             * �al��acak.
             */
            Controls.Add(_statusStrip);
            //En sonunda s�ra StatusStrip kontrol�n�n kendisini de Forma ekledim.
            int col = _dataGridView.Columns.Count;
            //_dataGridView kontrol�nde ka� s�tun var bunun sonucunu de�i�kene ald�m.
            Width = gridGenislik + 96;
            /* Formun geni�li�ini ayarl�yorum. Formda geni�li�in en �nemli oldu�u
             * kontrol _dataGridView, formu da bu kontrol�n geni�li�inden biraz
             * daha geni� ayarlad�m, aksi halde son s�tun hi� g�r�nm�yor. Her
             * s�tun i�in 8 birim ekleyince formun geni�li�i tam olarak grid kadar
             * ayarland�.
             */
            LabelWriter();
            /* Bu metot ile StatusStrip kontrol�ne ekledi�im ToolStripStatusLabel
             * kontrollerine �r�n say�s�, sat�r say�s� gibi verileri yazaca��m.
             */
            Icon sysIcon = SystemIcons.Information;
            Icon icon = new(sysIcon, 50, 50);
            /* Bilgi Logosunu ikon olarak ayarlad�m. Geni�li�i logo kadar olacak.
             */
            _notifyIcon = new NotifyIcon
            {
                Icon = icon,
                BalloonTipTitle = (string)builder["Database"],
                BalloonTipIcon = ToolTipIcon.Info,
                Text = sqlDataAdapter.SelectCommand.CommandText,
                Visible = true
            };
            /* NotifyIcon Windows g�rev �ubu�unun alt�nda bir ikon olarak g�r�n�r
             * bir bilgi sunmak i�in kullan�l�r. NotifyIcon bile�eninden (Component)
             * bir �rnek ald�m. NotifyIcon Component i�in;
             * Icon �zelli�i = kod ile olu�turdu�um ikonu atad�m.
             * A��lan balonun ba�l��� = (string)builder["Database"] kodu ile
             * ba�land���m veritaban� ad�n� atad�m. string tipine Cast ettim.
             * NotifyIcon i�in ikon bilgi ikonu idi, a��lan balon i�in de ayn�.
             * NotifyIcon �zerine fare ile gidildi�inde sorgumuzu g�r�nt�lesin.
             * G�r�n�m = G�r�n�r olarak ayarlad�m.
             */
            FormClosing += VtSample_FormClosing;
            //Form kapan�rken �u olay metodu �al��s�n.
        }

        private void VtSample_FormClosing(object sender, FormClosingEventArgs e)
        {
            _notifyIcon.Dispose();
            //G�rev �ubu�unda olu�turdu�umuz bilgi ikonu kald�r�ls�n.
        }

        private void DataGridView_DataBindingComplete
            (object sender, DataGridViewBindingCompleteEventArgs e) => LabelWriter();
        /* DataGridView_DataBindingComplete (grid t�m�yle ba�land���nda) olay�nda
         * LabelWriter metodu �al��acak. Bu metot tablo verileri hakk�nda baz�
         * bilgileri etiketlere yazar.
         */

        /* Buradaki de�i�kenler de  isim alan�nda (name space) tan�mlanm��t�r.
         * Sadece bu metot i�erisinde ilk kullan�m�na ba�lad���m i�in buraya yazd�m.
         */
        private int satir; //Buras� grid sat�r say�s� i�in.
        private double toplamStokFiltreli; //Filtrelenen verilerin toplam� i�in
        private void LabelWriter()
        /* Bu metot etiket kontrollerine veri yazd�r�yor. Hangi veriler oldu�unu
         * metodun ilerleyen ad�mlar�nda anlataca��m.
         */
        {
            ControlsClear(_toolStripStatusLabel);
            var toplamStok = _dataTable.Compute("Sum(UnitsInStock)", "true");
            /* DataTable s�n�f�n�n bir metodu var Compute. �ki parametre al�yor.
             * 1. Parametre, tabloyu sorgulayan ifadedir. UnitsInStock s�tununun
             * toplam�n� ald�m. 2. Parametre filtredir. Ben t�m s�tun verilerini
             * �arts�z toplamak istedi�im i�in true g�nderdim. Di�er
             * Compute fonksiyonlar�: AVG (Ortalama), COUNT (Toplam Say�),
             * MAX (En b�y�k de�er), MIN (En k���k de�er), STDEV (Standart Sapma).
             * Tabii ki Lambda Expression da kullanabilirsiniz. Farkl� bir metot
             * �rne�i sunmak Compute metodunu kulland�m.
             */
            _toolStripStatusLabel.Text = $"Toplam Stok: {toplamStok:0,00} adet";
            //Bu etikette toplamStok de�i�keninden d�nen de�er g�r�necek.
            satir = _dataGridView.Rows.GetRowCount
                    (DataGridViewElementStates.Visible);
            /* Buras� _dataGridView.Sat�rlar�n�n, Sat�r say�s�n� d�nd�ren (Get)
             * metodu kullan�larak yaz�ld�. Sadece g�r�nen sat�rlar�n say�s�, int,
             * tipli satir de�i�kenine aktar�ld�. Bu de�i�ken bu s�n�f i�in genel
             * kullan�ma a��k.
             */
            _toolStripLabel.Text = $"{satir} sat�r =>";
            //_toolStripLabel kontrol�ne satir de�i�keninde olu�an say�y� aktard�m.
            toplamStokFiltreli = _dataGridView.Rows.Cast<DataGridViewRow>().Sum
                (x =>
                    Convert.ToDouble(x.Cells["UnitsInStock"].Value));
            /* �imdi de filtreye g�re �al��an toplam stok de�erini toplamStokFiltreli
             * de�i�kenine aktaral�m. Bir Lambda Expression yazaca��m. _dataGridView
             * kontrol�n�n sat�rlar�n� "_dataGridView.Rows.Cast<DataGridViewRow>()"
             * DataGridViewRow tipine cast etti�imizde, art�k Lambda metotlar�n�
             * kullanabiliriz. Burada Sum metodunu kulland�m. Parantez i�erisinde
             * lambda de�i�keni ismi olarak x kullan�yorum. Se�icim x => her x i�in
             * H�crelerden (Cells) ["UnitsInStock" s�tun de�erini] al�yoruz. Bu veri
             * Value �zelli�i ile al�n�yor, value �zelli�i ise object tipinde de�er
             * d�nd�rd��� i�in, bize laz�m olan de�er double tipinde oldu�undan
             * Convert.ToDouble metodu ile sonucu �eviriyoruz. Yani burada Stok
             * Adedi hesaplanm�� oluyor.
             */
            _toolStripLabel.Text +=
                $"Filtreye G�re Toplam Stok: {toplamStokFiltreli} =>";
            /* _toolStripLabel kontrol�ne metni yaz += (bir �nceki kod sat�r�nda
             * sat�r de�eri vard� + olarak, lambda ile yaz�lan)  toplamStokFiltreli
             * de�eri yaz�l�yor.
             */
            double toplamSiparis = _dataGridView.Rows.Cast<DataGridViewRow>().Sum
                (x =>
                    Convert.ToDouble(x.Cells["UnitsOnOrder"].Value));
            _toolStripLabel.Text += $"ve Sipari� Adedi: {toplamSiparis}";
            /* Toplam sipari� i�inde bir lambda ifadesi kulland�m. B�ylece
             * LabelWriter() metodu, sat�r, toplam stok ve toplam sipari� bilgisi
             * verilerini _toolStripLabel kontrol�ne yazacak.
             */
        }
        private void ToolStripSplitButton_Click(object sender, EventArgs e)
        /* �zerinde Grafik g�r�nt�lemek �zere haz�rlayaca��m�z bir form olacak. Bu
         * form ToolStripSplitButton t�klan�nca olu�acak. Yani �u anda b�yle bir form
         * yok, buton t�klan�nca runtime (�al��ma zaman�nda) olu�acak.
         */
        {
            using Form chartForm = new();
            /* C# 8.0 ile gelen yenilik using declaration kulland�m. Form kullan�m�
             * bitti�inde kendili�inde Dispose (kullan�mdan kald�r�l�r) olur.
             * Form s�n�f�ndan bir �rnek ald�m. Art�k chartForm de�i�keni bir formu
             * ifade eder.
             */
            chartForm.AutoSize = true;
            //Form otomatik olarak boyutland�r�ls�n.
            chartForm.WindowState = FormWindowState.Normal;
            /* Formun pencere g�r�n�m durumu normal olsun. Di�er se�enekler: Ekran�
             * kaplam�� (Maximized), simge durumuna k���lt�lm�� (Minimized) olabilir.
             */
            chartForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            /* Formun kenarl�k stili yeniden boyutland�r�lamas�n. Di�er se�eneklerden
             * en �ok laz�m olacaklar: Yeniden boyutland�r�labilir (Sizable),
             * Kenarl�k yok (None), �� boyutlu kenarl�k (Fixed3D)
             */
            chartForm.Left = chartForm.Top = 0;
            /* Formun Windows sistemine g�re sol kenardan ve sa� kenardan olan
             * uzakl�k de�eri = 0 olsun.
             */
            chartForm.Size = Screen.PrimaryScreen.WorkingArea.Size;
            /* Formun boyutu = Screen s�n�f�n�n, birincil ekran�, �al��ma boyutu
             * ile ayn� olsun. Bendeki size de�eri 1.920x1.040 ��k�yor, ��nk� Windows
             * g�rev �ubu�u boyutu 40, b�ylece 1920x1080 tamamlanm�� oluyor.
             * Formumuz g�rev �ubu�unu kapatmam�� oluyor.
             */
            chartForm.ShowInTaskbar = true;
            //Form, G�rev �ubu�unda bir simge olarak g�r�nmesin.
            chartForm.AutoScroll = true;
            /* Formda, e�er gerekli oldu ise otomatik olarak kayd�rma �ubu�u
             * g�r�ns�n. Yani formun boyu i�eri�indeki nesneleri g�r�nt�lemeye
             * yetiyorsa kayd�rma �ubu�u g�r�nmez.
             */
            Chart chart = new();
            /* Bu formun as�l amac� bir grafik g�r�nt�lemekti. Chart tipinde bir
             * de�i�ken tan�mlad�m ve Chart s�n�f�ndan bir �rnek (instance) ald�m.
             */
            chart.Size = chartForm.Size;
            //Grafi�in boyutu, grafik i�in haz�rlanan formun boyutu ile ayn� olsun.
            Title title = new();
            /* Grafi�e bir ba�l�k atamas� yapmak �zere Title s�n�f�ndan bir
             * �rnek ald�m. Art�k title de�i�keni Title tipinde.
             */
            title.Text = "Fiyat ve Stok Durumu";
            //Ba�l�k metni olarak Text �zelli�ine atama yapt�m.
            chart.Titles.Add(title);
            //Grafi�e ba�l��� ekledim.

            string axisX = _dataTable.Columns["ProductName"].Caption;
            string axisY = _dataTable.Columns["UnitPrice"].Caption;
            /* Grafi�in X ve Y ekseninde g�r�nt�lenecek metinleri yazd�m. Do�rudan
             * metin olarak "ProductName" yazabilirdim. Ancak bu s�tunun ad�n�n
             * _dataTable �zerinden al�nmas�n� sa�lad�m. B�ylece s�tun ad�n�n
             * do�rulu�u kesinle�ti. Burada indeks de�erleri de kullanabilirdim,
             * ancak bu seferde s�tunun yerini sabitlemek gerekirdi, neden? ��nk�
             * sorgu Select * From gibi yaz�lmaz da, s�tun adlar� ile yaz�l�r ve
             * varsay�lan s�tun s�ras� ile yaz�lmaz ise gelen s�tunlar�n indeks
             * de�erleri de de�i�ecektir. S�tun ad�n� yazmak daha kesin bir sonu�
             * almam�z� sa�lar.
             */
            ChartArea chartArea = new();
            /* �imdi de grafi�in, as�l grafik alan� olan ChartArea k�sm�na geldi.
             * ChartArea s�n�f� tipinde bir de�i�ken ile s�n�f�n �rne�ini ald�m.
             */
            chartArea.AxisX.Interval = 1;
            //AxisX (ProductName) �r�n adlar� i�in aral�k 1'er olsun.
            chartArea.AxisY.Interval = 10;
            // AxisY (UnitPrice) �r�n fiyatlar� i�in aral�k de�eri 10 olsun
            chartArea.AxisX.Title = axisX;
            //AxisX (ProductName) �r�n adlar� i�in ba�l�k axisX de�i�keninden gelsin.
            chartArea.AxisY.Title = axisY;
            //AxisY (UnitPrice) �r�n fiyatlar� i�in ba�l�k axisY de�i�keninden gelsin.
            Font font = new("Arial", 14, FontStyle.Bold);
            /*Bu formun grafi�inde kullanmak i�in bir font tan�mlad�m. Font
             * s�n�f�ndan bir �rnek ald�m. Kurucu metodunda, font ad�, b�y�kl���,
             * kal�n yaz� tipli olmas�n� ayarlad�m.
             */
            title.Font =
            chartArea.AxisX.TitleFont =
                chartArea.AxisY.TitleFont =
                    chartArea.AxisX.LabelStyle.Font =
                        chartArea.AxisY.LabelStyle.Font = font;
            //Yukar�daki t�m nesnelere font olarak font de�i�kenini atad�m.
            chartArea.Area3DStyle.Enable3D = true;
            //Grafik alan� 3D g�r�n�m�n�n etkinle�tirdim.
            chartArea.Area3DStyle.LightStyle = LightStyle.Simplistic;
            /* 3D Grafik i�in bir ayd�nlatma stili atamas� yapar. 
             * Realistic: Renk tonunun d�n�� miktar�na ba�l� olarak de�i�ti�i
             * ger�ek�i ayd�nlatma se�ene�idir.
             * Simplistic: Renk tonunun sabit kald��� se�enektir.
             */
            chartArea.Area3DStyle.Rotation = 10;
            //3D Grafik d�nd�rme a��s� = 10 olsun.
            chartArea.Area3DStyle.WallWidth = 25;
            //3D Grafik arkaplan geni�li�i = 25 olsun (max:30 olabilir).
            chartArea.Area3DStyle.Inclination = 40;
            //3D Grafik e�imi = 40 olsun.
            chart.ChartAreas.Add(chartArea);
            /* Grafik nesnesine, baz� �zelliklerini atad���m�z grafik alan�n� ekle
             * Hat�rlay�n�z: ChartArea tipindeki chartArea de�i�kenimiz vard�.
             */
            Series series = new();
            //Grafi�in serilerini tan�mlamak �zere Series s�n�f�ndan bir �rnek ald�m.
            series.ChartType = SeriesChartType.Column;
            /* Bir grafik tipi belirliyorum = Tipi (Column = S�tun)
             * Pie (Pasta), Doughnut (Donut), Pyramid (Piramit) grafik tipleri de
             * g�r�n�m bak�m�nda kullan�labilir.
             */
            series.SetCustomProperty("DrawingStyle", "Cylinder");
            //Di�er �izim stilleri: Cylinder, Emboss, LightToDark, Wedge, Default.
            /* Grafik serisine �zelle�tirilmi� �zellikler eklenebiliyor. Ancak bu
             * �zellikler her grafi�e uymuyor. Bu �zellikler hangi grafi�e uyuyorsa
             * ona yazd���n�zda etkin oluyor. Hangi grafik ne demek? Column, Pie vb.
             * Konu hakk�nda detayl� bilgi �u linkte bulunmakta:
             * https://docs.microsoft.com/en-us/previous-versions/dd456764(v=vs.140)
             * ?redirectedfrom=MSDN 
             */
            series.SetCustomProperty("LabelStyle", "Top");
            /* Grafik serisine �zelle�tirilmi� �zellik ekle (Etiket Stili, Etiket
             * grafi�in �zerinde olsun). Mesela bu �zellik, grafik stiliniz: Point,
             * Column, Bubble, Line, Spline, Step Line, Area, Spline Area, Range,
             * Spline Range, Radar, Polar ise �al���yor. Zaten mant�k olarak da
             * uygun, mesela pie chart (pasta grafik) �zerinde �al��maz, yuvarlak
             * olaca�� i�in Top �zelli�i olmaz, olsa olsa grafi�in d���nda olabilir.
             */
            /* series.SetCustomProperty("LabelStyle", "Outside");
             * Grafik tipi Pie (Pasta iken Top yerine Outside kullanabilirsiniz).
             */
            series.IsValueShownAsLabel = true;
            //Serinin grafik �zerinde etiketleri g�sterme durumu = g�sterilsin.
            series.XValueMember = _dataGridView.Columns[axisX]?.DataPropertyName;
            /* Serinin X eksenine yaz = Izgara s�tunlar�ndan ad� [axisX de�i�keninde
             * yazan de�er olan s�tun] bo� de�ilse, verinin �zellik ad�n� yaz.
             * B�ylece kay�t kayna��n�z de�i�irse sadece axisX de�i�kenini
             * d�zeltmeniz yeter. Asl�nda direk ProductName veya axisX
             * yazabilirsiniz, ben farkl� bir kod �rne�i olmas� a��s�ndan yazd�m. 
             */
            series.YValueMembers = _dataGridView.Columns[axisY]?.DataPropertyName;
            //Buras�da UnitPrice yani axisY.
            chart.Series.Add(series);
            //Art�k grafi�imize grafik serisini ekleyelim.
            chart.SaveImage("Chart.bmp", ChartImageFormat.Bmp);
            //Grafi�i bmp format�nda bir resim olarak kaydet ve g�r�nt�le.
            chart.AntiAliasing = AntiAliasingStyles.All;
            //Grafi�in k��e k�r�lmalar�n�n t�m�n� yumu�at.
            chart.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
            //Grafi�in k��e k�r�lmalar�n�n yumu�atma kalitesi y�ksek kalite olsun.
            chart.DataSource = _dataGridView.DataSource;
            //Grafi�in veri kayna�� = _dataGridView veri kayna�� olsun.
            chartForm.Controls.Add(chart);
            //chartForm formuna grafi�i ekle.

            ChartColorFormat(chart, series, chartArea);
            //Bu metot ile Chart, Series ve ChatArea renk ayarlar�n� yapaca��m

            chartForm.ShowDialog();
            //Grafik formunu ekranda g�r�nt�l�yorum.
        }
        private static void ChartColorFormat
            (Chart chart, Series series, ChartArea chartArea)
        /* Bu metot parametreli olarak: Chart, Series ve ChartArea tipinde 3 
         * parametre al�yor. Bu nesnelerin bi�imlerini ayarl�yor.
         */
        {
            chart.BackColor = chartArea.BackColor = Color.FloralWhite;
            //Grafik ve grafik alan� arkaplan rengi = Beyaz (FloralWhite).
            chartArea.AxisX.MajorGrid.LineColor =
            chartArea.AxisY.MajorGrid.LineColor = Color.Black;
            //Grafik �izgilerinin rengi = Siyah.

            chart.BackSecondaryColor =
                series.BackSecondaryColor =
                    chartArea.BackSecondaryColor = Color.LightGoldenrodYellow;

            chart.BackGradientStyle =
            chartArea.BackGradientStyle =
            series.BackGradientStyle = GradientStyle.VerticalCenter;
            //Renk ge�i� stili = Yatay Merkezli.

            series.Palette = ChartColorPalette.Pastel;
            //Serilerin renkleri pastel renkler olsun.
        }
        private void DataGridViewRowColor(DataGridView dataGridView)
        /* DataGridView sat�rlar�ndan birinin bir renk, di�erinin ba�ka renk
         * olmas�n� sa�lamak i�in bu metodu yazd�m.
         */
        {
            dataGridView.RowsDefaultCellStyle.BackColor = Color.White;
            //Sat�rlar varsay�lan arkaplan rengi stili = Beyaz (White)
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.GhostWhite;
            /* Alternatif renk stili = Beyaz (GhostWhite)
             * B�ylelikle bir sat�r bir renk, di�er sat�r di�er renk olacak.
             */
        }
        private bool _tiklandi = false;
        //Bir de�i�kenim var ad� _tiklandi ve bu s�n�fta kullan�ma a��k.
        private void ToolStripButton_Click(object sender, EventArgs e)
        {/* Bir butonum var ad�: ToolStripButton t�kland���nda �unlar ger�ekle�sin.
          * Bu buton bir kez t�klan�nca veriler filtrelenir, di�er t�klamada verilerin
          * t�m� g�r�nt�lenir.
          */
            if (_toolStripComboFilter.Items.Count == 0 ||
                _toolStripComboFilter.Text == string.Empty) return;
            /* E�er _toolStripComboFilter kontrol�ndeki eleman say�s� 0 ise veya
             * a��lan kutuda yaz�l� bir metin yok ise bu metottan geri d�n, ��k.
             * E�er metot return ile sona ermedi ise a�a��daki sat�rlardan
             * devam edilir.
             */
            _notifyIcon.Visible = true;
            /* _notifyIcon kontrol� �ift t�klama olay� (_notifyIcon_DoubleClick) ile
             * gizleniyor, bu buton ile de g�r�n�r yap�l�yor. B�ylece ToolStripButton
             * kontrol�ne her t�klamada _notifyIcon.Visible �zelli�i = true oluyor.
             */
            _tiklandi = !_tiklandi;
            /* _tiklandi de�i�keni e�ittir = _tiklandi de�i�keninin de�iline. Bu da
             * demek oluyor? _tiklandi de�i�keni = true ise false, false ise true
             * olsun demektir. B�ylece bir t�klamada true, di�erinde false olur.
             */
            if (!_tiklandi)
            //E�er _tiklandi de�i�keni _tiklandi = true de�ilse (false ise)
            {
                ((ToolStripButton)sender).Text = "Filtrele";
                /* sender nesnesini ToolStripButton tipine Cast et ve Metin
                 * �zelli�ine = Filtrele yaz.
                 */
                _dataTable.DefaultView.RowFilter = null;
                /* _dataTable kontrol�n�n varsay�lan g�r�n�m�n�n filtreleme �zelli�i
                 * bo� olsun. B�ylece Filtre kald�r�l�r.
                 */
                //_toolStripComboBox.Text = _toolStripComboFilter.Text = string.Empty;
                /* �sterseniz toolStripComboBox ve _toolStripComboFilter kontrollerini
                 * temizleyip, filtrelemeyi iptal edebilirsiniz. Yani metin
                 * �zelliklerinde hi� bir veri olmayaca�� i�in, verilerin t�m�
                 * g�sterilir.
                 */
                DataGridViewRowColor(_dataGridView);
                /* Bu metot parametre olarak _dataGridView al�r ve bir sat�r�n� bir
                 * renk di�erini ba�ka renk yapar.
                 */
                Height = _yukseklik;
                /* Burada filtreleme yap�lmad��� i�in, formu ilk y�ksekli�ine
                 * d�nd�r�yorum. Formun y�ksekli�i filtreleme sonucunda
                 * de�i�irse bu sat�r tekrar eski haline getirir.
                 */
                return;
                /* Filtre verisi null oldu�undan, bundan sonraki sat�rlarda
                 * filtreleme i�lemi yapt��� i�in return ile metodu sonland�rd�m.
                 */
            }
            else
            //E�er _tiklandi de�i�keni _tiklandi = true de�ilsenin de�ili, true ise
            {
                ((ToolStripButton)sender).Text = "T�m�n� G�ster";
                /* "ToolStripButton_Click(object sender" kodunu hat�rlay�n�z.
                 * Buradaki, object sender, ToolStripButton kontrol�n� ifade eder,
                 * bu nedenle tipini ToolStripButton tipine �evirip metin de�eri
                 * olarak "T�m�n� G�ster" yazd�m. Di�er t�klamada Filtrele olacak. 
                 */
                DataGridViewRowColor(_dataGridView);
                /* Grid kontrol�n�n sat�r renklerini ayarlayan metodu kulland�m.
                 * B�ylece filtre sonras� sat�rlar yeniden renklendirildi.
                 */
            }
            try
            //Dene, hata var m�?
            {
                _dataTable.DefaultView.RowFilter =
                $"{_toolStripComboBox.Text} LIKE " +
                $"'%{_toolStripComboFilter.Text}%'";
                /* _dataTable kontrol�n�n varsay�lan g�r�n�m�, sat�r filtresi
                 * ��yledir: _toolStripComboBox bo� de�ilse Metni al (Burada
                 * Product s�tunlar�n�n adlar� var) LIKE yaz (benzer verileri
                 * filtrele komutu i�in yazd�m). Bu i�aret ba�ta olursa "%"
                 * ile ba�layan demektir. Buradaki veri ile ba�layan ve biten
                 * verilere g�re filtrele: [_toolStripComboFilter] Yani;
                 * Se�ilen s�tun verisinin i�eri�indeki de�erlerden se�ilen
                 * ile ba�layan ve biten (i�eren) veriler demektir.
                 * Bu i�aret sonda olursa "%" ile biten demektir.
                 * % burada yazan veriyi i�eren % anlam�na gelir.
                 */
            }
            catch (Exception)
            //Yakala, hata varsa hatay� yakala
            {
                if (_toolStripComboFilter.Text == string.Empty) return;
                /* E�er filtre uygulayaca��m�z verileri i�ermesi gereken
                 * _toolStripComboFilter bo� ise d�n�� yap, ��k
                 */
                string aranan =
                    _toolStripComboFilter.Text.Replace(',', '.');
                /* aranan adl� de�i�kene iki tip veri geliyor, say� ve metin. Say�
                 * de�erleri ise 100,25 gibi g�r�n�yor, bu �ekilde arama yap�nca
                 * bulamazs�n�z. Bende ondal�k ayrac� , yerine . olarak de�i�tirdim.
                 * 100.25 gibi bir say�ya d�n��t�. Bu biraz hard code oldu, hard
                 * code yazmay� pek sevmem ama b�yle kod yazamaman�z i�in g�stermi�
                 * olay�m. Normalde say�lar�n binlik ve ondal�k ayra�lar�,
                 * MethodsParametersVoidReturn projemize bakt���n�zda
                 * SistemNumerikAyraci() adl� bir metot var, incelemenizi rica
                 * ederim. virg�l, nokta ile de�i�sin gibi bir kod yazmak yerine
                 * sistem ondal�k ve binlik ayrac�na ba�lanan bir kod yazman�z
                 * yerinde olur.
                 */
                _dataTable.DefaultView.RowFilter =
                string.Format($"{_toolStripComboBox?.Text} = {aranan}");
                /* �imdi de filtrelemeyi atayal�m. Filtreleme sadece filtre yapan
                 * _toolStripComboBox adl� a��lan kutudaki veriye g�re olsun. Yani;
                 * i�eren verileri de�il, sadece _toolStripComboBox verisini ara.
                 * Asl�nda try k�sm�ndaki arama, metinsel verileri bulur, catch
                 * k�sm�ndaki arama say�lara g�re arama yapar. B�ylece say� ise;
                 * ��yle ara, metin ise b�yle ara diye kod yazmak en do�rusudur.
                 * Ben sadece try-catch �rne�ini hat�rlatmak i�in b�yle yazd�m.
                 * HesapMakinesiTryCatchFinally projemizi hat�rlay�n�z orada
                 * isNumeric metodu vard�. isNumeric metodu ile bakars�n�z say�
                 * ise aramay� bu sat�rdaki gibi yapars�n�z, metin ise
                 * Like % buradaki metni i�eren veriler % kodlar� aras�nda
                 * arama yapars�n�z.
                 */
            }
            _notifyIcon.BalloonTipText = $"{satir} adet sat�r var." +
                    $"\n Stok Adedi: {toplamStokFiltreli}" +
                    $"\n Bilgi ikonuna iki kez t�klay�p kald�rabilirsiniz.";
            /* S�ra geldi g�rev �ubu�u balonuna, balona metin olarak �unu yazaca��m:
             * satir de�i�keninde ne vard� hat�rlay�n�z:
             * "_dataGridView.Rows.GetRowCount(DataGridViewElementStates.Visible)"
             * g�r�nen sat�rlar�n say�s�. ��te bu say�y� yaz.
             */
            Height = satir * (_dataGridView.RowTemplate.Height + 3)
                     + _bindingNavigator.Height + _statusStrip.Height +
                        (Height - ClientRectangle.Height);
            /* satir de�i�keni kodu ne idi? "_dataGridView.Rows.GetRowCount
             * (DataGridViewElementStates.Visible);" Sadece g�r�nen sat�rlar�n
             * adet bilgisini al�yordu. Filtrelenen verilere g�re y�kseklik de�eri
             * bulurken bu kontrollerin y�kseklik de�erleri laz�m oldu.
             */
            _notifyIcon.ShowBalloonTip(3_000);
            //Bu bilgi 3.000/1.000 = 3 saniye g�r�ns�n.
            _notifyIcon.DoubleClick += _notifyIcon_DoubleClick;
            //�kon �ift t�kland���nda _notifyIcon gizlenecek.
        }
        private void _notifyIcon_DoubleClick(object sender, EventArgs e)
            => _notifyIcon.Visible = false;
        /* _notifyIcon_DoubleClick (iki kez t�kland���nda) olay�nda
         * gizlenecek. => bu yaz�m �ekli . Expression-bodied members
         * olarak adland�r�l�yor C# 6.0 ile metotlar destekleniyordu C# 7.0 ile
         * Property, Constructor, Finalizer, Indexer deste�i de geldi. B�ylece
         * tek sat�rl� bir sonucunuz var ise {} a�madan => ile metodu, �zelli�i,
         * kurucu metodu vs. do�rudan yazabiliyorsunuz.
         */
        private void ToolStripComboBoxFill(ToolStripComboBox toolStripComboBox,
                                                        out int gridGenislik)
        /* Bu metot ile ToolStripComboBox doldurulacak. ��eri�indeki verilerden
         * _dataGridView kontrol� i�in geni�lik hesaplanacak. 1. Parametre
         * ToolStripComboBox al�yor, 2. Parametre int tipinde gridGenislik adl�
         * de�i�keni d��ar� aktar�yor.
         */
        {
            string _bicim = string.Empty;
            //Buras� metin bi�imlendirme i�in kullan�lacak.
            int genislik = 0;
            //Grid geni�li�i i�in tan�mlad�m.
            for (int j = 0; j < _dataGridView.Columns.Count; j++)
            /* Bu d�ng�; 0 ile _dataGridView kontrol�n�n s�tun say�s�ndan 1 k���k
             * oluncaya kadar d�ner. B�ylece s�tun ba�l�klar�nda d�nm�� olaca��m.
             */
            {
                DataGridViewColumn dataGridViewColumn = _dataGridView.Columns[j];
                /* Grid s�tunu tipinde (DataGridViewColumn) bir de�i�kenim var. Grid
                 * S�tunlar�ndan [j s�tunlar�] bu de�i�kene aktarl�s�n. B�ylece 0,1,
                 * 2... grid i�eri�indeki s�tun kadar s�tunlar bu de�i�kene
                 * aktar�l�r. Buras� DataGridView Column (Grid s�tunu)
                 */
                DataColumn dTblColumn = _dataTable.Columns[j];
                /* Veri s�tunu tipinde (DataColumn) bir de�i�kenim var. Veri
                 * s�tunlar�ndan [j s�tunlar�] bu de�i�kene aktarl�s�n. B�ylece 0,1,
                 * 2... Data i�eri�indeki s�tun kadar s�tunlar bu de�i�kene
                 * aktar�l�r. Buras� Data Column (Veri s�tunu, Data Table s�tunu)
                 */
                dataGridViewColumn.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
                /* dataGridViewColumn de�i�kenimizin varsay�lan h�cre stilinin
                 * hizalama �zelli�i sa�a yasl� olsun. B�ylece t�m s�tunlar sa�a
                 * yasland�. Sonra sola yaslanmas� gereken s�tunlar� ayarlar�z.
                 */

                if (dTblColumn.DataType == typeof(short) ||
                    dTblColumn.DataType == typeof(double) ||
                    dTblColumn.DataType == typeof(decimal))
                /* dTblColumn de�i�kenindeki "_dataTable.Columns[j]" s�tun
                 * short, double, decimal ise virg�lden sonra 2 haneli olsun.
                 */
                {
                    _bicim = "N2"; //virg�lden sonra 2 haneli olsun.
                }
                else if (dTblColumn.DataType == typeof(int))
                //Yukar�daki if blo�unda belirtilen tip de�ilse int tipinde ise
                {
                    _bicim = "N0"; //virg�lden sonra 0 haneli olsun.
                }
                else
                //Hi�biri de�ilse
                {
                    dataGridViewColumn.DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleLeft;
                    /* dataGridViewColumn de�i�kenimizin varsay�lan h�cre stilinin
                     * hizalama �zelli�i sola yasl� olsun. B�ylece kalan t�m
                     * s�tunlar sola yasland�. Say�lar sa�a yasl�, metinler
                     * sola yasl� oldular.
                     */
                }
                //Buradaki if blo�undan N2 veya N0 de�eri olu�ur.
                dataGridViewColumn.DefaultCellStyle.Format = _bicim;
                /* D�ng� hala s�rd��� i�in dataGridViewColumn de�i�kenimizin
                 * varsay�lan h�cre stil bi�imi = if blo�undan d�nen
                 * _bicim de�i�keni olur. B�ylece N0 veya N2 olacakt�r.
                 */
                genislik += dataGridViewColumn.Width;
                /* genislik de�i�keni "out int gridGenislik" de�eri i�in s�rekli
                 * toplan�yor. B�ylece grid s�utlar� toplam geni�li�i hesaplanacak.
                 */
                toolStripComboBox.Items.Add(
                    _dataTable.Columns[j].ColumnName);
                /* toolStripComboBox kontrol�ne eleman ekle (_dataTable
                 * s�tunlar�ndan [j. s�tununun (0,1,2... s�tunlar�n�n)]) ad
                 * �zelli�ini bu a��lan kutuya ekle. B�ylece s�tun adlar� ve
                 * i�eri�indeki verilere g�re filtreleme yapabilmek i�in gerekli
                 * olan s�tun adlar� haz�r.
                 */
            }
            gridGenislik = genislik;
            /* D��ar� aktaraca��m�z gridGenislik de�i�keni de�eri, genislik
             * de�i�keninin de�eri kadard�r.
             */
        }
        private void ToolStripComboBox_SelectedIndexChanged
        (object sender, EventArgs e)
        /* ToolStripComboBox kontrol�nden bir veri se�ilip indeks de�eri de�i�ti�inde
         * (SelectedIndexChanged) bu olay tetiklenir. ToolStripComboBox, Products
         * tablosunun s�t�n ba�l�klar�n� i�eriyordu ve filtreleme i�in
         * kullan�lacaklard�.
         */
        {
            string columnName = ((ToolStripComboBox)sender).Text;
            /* string  tipindeki columnName de�i�keni e�ittir = a��lan kutunun
             * metnine. Asl�nda bu olaydan d�nen object tipindeki sender de�i�keni,
             * ToolStripComboBox oldu�u i�in bir cast i�lemine tabi tutuldu ve metin
             * de�eri al�nabildi. (ToolStripComboBox, Products tablosunun s�t�n
             * ba�l�klar�n� i�eriyordu).
             */
            DataColumn dataColumn = _dataTable.Columns[columnName];
            /* DataColumn tipindeki de�i�kenimiz ise = _dataTable kontrol�n�n
             * s�tunlar�ndan [columnName ad�ndaki s�tun de�erine] e�ittir.
             * Mesela; CategoryID s�tunu, dataColumn de�i�kenine aktar�l�yor.
             */
            ControlsClear(_toolStripComboFilter);
            /* ControlsClear metodu parametresine sunulan kontrol� temizler.
             * �nce _toolStripComboFilter adl� kontrol� temizleyelim, b�ylece
             * ToolStripComboBox kontrol�ne ba�l� olarak s�tun verilerini yeniden
             * bu kontrole doldurdu�umuzda veriler, �st �ste binmesinler, tekrarl�
             * veri olmas�n.
             */
            _toolStripComboFilter.Sorted = true;
            // _toolStripComboFilter kontrol� verileri s�ral� olarak g�stersin.
            foreach (DataRow item in _dataTable.Rows)
            /* Veri sat�rlar�nda d�nen bir d�ng� olan foreach d�ng�m�z�n de�i�keni
             * olan item _dataTable (veri tablosunun) sat�rlar�nda d�necektir.
             */
            {
                if (!_toolStripComboFilter.Items.Contains(item[dataColumn]))
                /* E�er (De�ilini al, _toolStripComboFilter kontrol� i�eriyor mu,
                 * neyi? D�ng� de�i�kendeki [dataColumn de�i�kenindeki de�eri
                 * i�eriyor mu "_dataTable.Columns[columnName]" ?
                 * Yani Filtrelemede kullanaca��m�z ve sat�rlardaki veriyi i�eren
                 * a��lan kutuda, _dataTable.Rows i�eri�indeki de�er var m�? De�ilini
                 * alacakt�k, o zaman var m� = Evet ise evetin de�ili olan Hay�r ise
                 */
                {
                    _toolStripComboFilter.Items.Add(item[dataColumn]);
                    /* _toolStripComboFilter kontrol�ne eleman ekle (D�ng�
                     * de�i�keni olan item [s�tun ad�n� i�eren s�tundaki verileri
                     * ekle]). B�ylece tekrarl� veri eklenmez ve g�r�nt�lenmez.
                     */
                }
            }
        }
        private void ControlsClear(params dynamic[] controls)
        /* Bu metot sadece params keyword (parametreler anahtar kelimesi) ve dynamic
         * veri tipine �rnek olmas� a��s�ndan yaz�lm��t�r. Bu metot Parametre olarak
         * dynamic tipinde birden fazla veriyi alabilir. Mesela; ComboBox tipli
         * bir�ok kontrol� bu metoda g�nderip temizlenmesini sa�layabilirsiniz.
         * Farkl� kontroller de olabilir, mesela: �� TextBox, iki Label, be� Button
         * gibi.
         */
        {
            if (controls == null) return;
            /* dynamic dizisi tipindeki controls de�i�keni null ise temizlenecek veri
             * de olmayaca�� i�in return ile i�lemi bitiriyoruz.
             */
            try
            /* Dene hata var m�? Burada mutlaka try kullanmak gerekli oldu.
             * yaz�ld�.
             */
            {
                foreach (dynamic ctrl in controls)
                /* foreach d�ng�s� i�in de�i�kenimin tipi dynamic, ad� ctrl. Bu
                 * de�i�ken controls i�eri�inde hareket eder. controls neydi?
                 * Hat�rlatma: "params dynamic[] controls", yani; kullan�c�n�n
                 * sundu�u dynamic tipli dizi. K�saca; temizlemek i�in parametreye
                 * g�nderdi�i kontroller.
                 */
                {
                    ctrl.Text = string.Empty;
                    //dynamic tipindeki ctrl de�i�keni metin �zelli�ini bo�alt.
                    ctrl.Items.Clear();
                    /* dynamic tipindeki ctrl de�i�keni elemanlar�n� temizle.
                     * ��te sorun burada ba�l�yor. Her kontrol�n items �zelli�i
                     * yok. B�ylece hata olu�uyor. dynamic tipini kullanmak yerine
                     * her tipe uygun olan temizleme metodunu da yazabilirdim, ancak
                     * o zamanda dynamic veri tipini nerede kullanabilece�imize dair
                     * bir �rnek yapamam�� olacakt�m.
                     */
                }
            }
            catch (Exception ex)
            //Hatay� yakalarsan bu kapsamdan devam et (hatay� ex de�i�kenine at)
            {
                Debug.WriteLine(ex.Message);
                /* Hatay� Debug modunda yaz. Kullan�c�ya mesaj kutusu ile g�sterip
                 * rahats�z etmek istemedim. Bo� olmas�n� da istemedim. Dileyenler
                 * projeyi debug mod ile �al��t�r�p, output penceresinden
                 * hataya bakabilirler.
                 */
            }
        }
        PrintDocument printDocument;
        //Yaz�c� ��kt�s� alabilmek i�in bu de�i�keni iki farkl� metotta kullanaca��m.
        private Bitmap bitmap;
        //Bu de�i�ken, yaz�c�dan almak istedi�im ��kt�n�n resmini ta��yacak.
        private void SplitButtonPrint_Click(object sender, EventArgs e)
        {
            printDocument = new();
            // Yeni bir yaz�c� dok�man� tan�mlad�m.
            printDocument.PrintPage += PrintDocument_PrintPage;
            /* PrintDocument tipindeki Component (bile�en)i�in, yaz�c�dan sayfay�
             * ��kt� olarak al�rken olay�n� tan�mlad�m. PrintPageEventArgs e
             * de�i�keni Graphics �zelli�i DrawImage metoduna yaz�c�dan ��kt�s�
             * al�nacak resmi de g�nderece�im.
             */
            PrintDialog printDialog = new();
            /* Yaz�c�dan ��kt� al�rken kullanmak �zere bir PrintDialog tipindeki
             * de�i�kenimi tan�mlad�m.
             */
            printDialog.Document = printDocument;
            /* Yaz�c� diyalog penceresinin dok�man �zelli�ine printDocument
             * de�i�kenini atad�m.
             */
            printDialog.UseEXDialog = true;
            //Kullan�labilecek yaz�c�lar�n listesi g�r�nt�lensin.
            bitmap = new Bitmap(_dataGridView.Width, _dataGridView.Height);
            /* Bitmap tipindeki de�i�kenim i�in bir �rnek ald�m. Resmin Geni�li�i ve
             * y�kseklik de�erini bildirdim.
             */
            _dataGridView.DrawToBitmap
            (bitmap, new Rectangle(20, 20,
                _dataGridView.Width, _dataGridView.Height));
            /* _dataGridView kontrol�n�n Bitmap �izen metodunu kulland�m.
             * 1.Parametre: x apsisine olan uzakl�k:20. Yani: Sol kenardan bo�luk.
             * 2.Parametre: y ordinat�na olan uzakl�k:20. Yani: �st kenardan bo�luk.
             * 3.Parametre: resmin geni�li�i. 4.Parametre: resmin y�ksekli�i.
             */
            DialogResult result = printDialog.ShowDialog();
            /* Yaz�c� diyalog penceresinden geriye d�nen de�eri kullanabilmek i�in
             * DialogResult tipinde bir de�i�ken tan�mlad�m. B�ylece kullan�c�
             * yazd�rmay� istemedi�inde iptal de edebilir.
             */
            if (result == DialogResult.OK)
            /* E�er diyalog penceresinde iken OK butonuna bas�ld� ise, yani; belge
             * yazd�r�lacak ise
             */
            {
                printDocument.DocumentName = Environment.MachineName;
                //Yaz�c� dok�man�na isim ver = Kullan�c�n�n bilgisayar ad�n� kullan.
                printDocument.DefaultPageSettings.Landscape = true;
                //Varsay�la yaz�c� ayarlar�ndan Yatay ��kt� al�nma �zelli�i aktiftir.
                printDocument.Print();
                //Dok�man� yazd�r.
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
            /* PrintPageEventArgs tipindeki e de�i�keninin Grafikler �zelli�inin
             * DrawImage (Resim �iz) metodu ile (bitmap de�i�kenindeki resmi �iz
             * x ve y eksenlerinden 0 birimi uzakl�k b�rak).
             */
        }
    }
}
