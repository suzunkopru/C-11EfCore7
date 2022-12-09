using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Environment;
using static System.IO.Directory;
using static System.Windows.Forms.Application;
using static System.Windows.Forms.Screen;

namespace ControlsDialogsComponents;

public partial class VtSample : Form
{
    public VtSample() => InitializeComponent();
    private DataTable _dataTable;
    private BindingSource _bindingSource;
    private DataGridView _dataGridView;
    private NotifyIcon _notifyIcon;
    private ToolStripComboBox _toolStripComboFilter, _toolStripComboBox;
    private ToolStripStatusLabel _toolStripStatusLabel, _toolStripLabel;
    private int _yukseklik;
    private StatusStrip _statusStrip;
    private BindingNavigator _bindingNavigator;
    private void VTSample_Load(object sender, EventArgs e)
    {
        WindowState = FormWindowState.Normal;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Left = Top = 0;
        Size = PrimaryScreen.WorkingArea.Size;
        _yukseklik = Size.Height;
        ShowInTaskbar = false;
        AutoScroll = true;
        SqlConnectionStringBuilder builder = new();
        string BilgisayarAdi = MachineName;
        builder.DataSource = BilgisayarAdi;
        builder.InitialCatalog = "Northwind";
        builder.UserID = "sa";
        builder.Password = "123";
        using SqlConnection sqlConnection
            = new SqlConnection(builder.ToString());
        using SqlDataAdapter sqlDataAdapter = new
            ("Select * From Products", sqlConnection);
        _dataTable = new();
        try
        {
            DataSet dataSet = new();
            _dataTable.TableName = "1.Tablom";
            dataSet.Tables.Add(_dataTable);
            sqlDataAdapter.Fill(dataSet.Tables["1.Tablom"]);
        }
        catch (Exception ex)
        {
            throw new Exception(
                $"Server Adý: {builder["Server"]} veya \nDatabase Adý: {builder["Database"]} ya da \nBaðlantý Adaptörü: {typeof(SqlDataAdapter)} hatalý \nveya olasý diðer hatalar {ex.Message}");

        }
        SplitContainer splitContainer = new();
        splitContainer.Orientation = Orientation.Horizontal;
        splitContainer.Dock = DockStyle.Fill;
        Controls.Add(splitContainer);
        _bindingNavigator = new(true);
        _bindingSource = new();
        _bindingSource.DataSource = _dataTable;
        _bindingNavigator.BindingSource = _bindingSource;
        _bindingNavigator.DeleteItem.Enabled = false;
        _bindingNavigator.AddNewItem.Enabled = false;
        splitContainer.SplitterDistance = _bindingNavigator.Height;
        splitContainer.Panel1.Controls.Add(_bindingNavigator);
        _dataGridView = new();
        _dataGridView.AllowDrop = _dataGridView.AllowUserToAddRows = false;
        _dataGridView.AllowUserToDeleteRows = false;
        _dataGridView.SelectionMode =
                        DataGridViewSelectionMode.FullRowSelect;
        _dataGridView.AutoResizeColumns();
        _dataGridView.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.DisplayedCells;
        _dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        _dataGridView.DataSource = _bindingSource;
        _dataGridView.Dock = DockStyle.Fill;
        _dataGridView.ColumnHeadersVisible = true;
        splitContainer.Panel2.Controls.Add(_dataGridView);
        DataGridViewRowColor(_dataGridView);
        _dataGridView.DataBindingComplete +=
                            DataGridView_DataBindingComplete;
        _statusStrip = new();
        _toolStripStatusLabel = new();
        _toolStripLabel = new();
        ToolStripButton toolStripButton = new();
        ToolStripSplitButton toolStripSplitButton = new();
        ToolStripSplitButton splitButtonPrint = new();
        _toolStripComboFilter = new();
        _toolStripComboBox = new();
        _statusStrip.Items.Add(_toolStripStatusLabel);
        ToolStripSeparator toolStripSeparator = new();
        _statusStrip.Items.Add(toolStripSeparator);
        _statusStrip.Items.Add(_toolStripLabel);
        _statusStrip.Items.Add(_toolStripComboBox);
        ToolStripComboBoxFill(_toolStripComboBox, out int gridGenislik);
        _toolStripComboBox.SelectedIndexChanged +=
                        ToolStripComboBox_SelectedIndexChanged;
        _statusStrip.Items.Add(_toolStripComboFilter);
        _statusStrip.Items.Add(toolStripButton);
        toolStripButton.Click += ToolStripButton_Click;
        toolStripButton.Text = "Filtrele";
        string directoryInfo =
           GetParent(StartupPath).Parent.Parent.Parent.FullName;
        toolStripSplitButton.Image =
            Image.FromFile(directoryInfo + "\\Chart.png");
        toolStripSplitButton.Click += ToolStripSplitButton_Click;
        _statusStrip.Items.Add(toolStripSplitButton);
        splitButtonPrint.Image =
            Image.FromFile(directoryInfo + "//printer.png");
        splitButtonPrint.Click += SplitButtonPrint_Click;
        _statusStrip.Items.Add(splitButtonPrint);
        Controls.Add(_statusStrip);

        Width = gridGenislik + 96;
        LabelWriter();
        Icon sysIcon = SystemIcons.Information;
        Icon icon = new(sysIcon, 50, 50);
        _notifyIcon = new NotifyIcon
        {
            Icon = icon,
            BalloonTipTitle = (string)builder["Database"],
            BalloonTipIcon = ToolTipIcon.Info,
            Text = sqlDataAdapter.SelectCommand.CommandText,
            Visible = true
        };
        FormClosing += VtSample_FormClosing;
    }

    private void VtSample_FormClosing
        (object sender, FormClosingEventArgs e)
                        => _notifyIcon.Dispose();
    private void DataGridView_DataBindingComplete
        (object sender, DataGridViewBindingCompleteEventArgs e)
                                                => LabelWriter();
    private int satir;
    private double toplamStokFiltreli;
    private void LabelWriter()
    {
        ControlsClear(_toolStripStatusLabel);
        var toplamStok = _dataTable
            .Compute("Sum(UnitsInStock)", "true");
        _toolStripStatusLabel.Text =
                        $@"Toplam Stok: {toplamStok:0,00} adet";
        satir = _dataGridView.Rows.GetRowCount
            (DataGridViewElementStates.Visible);
        _toolStripLabel.Text = $@"{satir} satýr =>";
        toplamStokFiltreli = _dataGridView.Rows.Cast<DataGridViewRow>()
            .Sum(x =>
            Convert.ToDouble(x.Cells["UnitsInStock"].Value));
        _toolStripLabel.Text +=
        $@"Filtreye Göre Toplam Stok: {toplamStokFiltreli} =>";
        double toplamSiparis = _dataGridView.Rows.
                                Cast<DataGridViewRow>().Sum
        (x =>
            Convert.ToDouble(x.Cells["UnitsOnOrder"].Value));
        _toolStripLabel.Text += @$"ve Sipariþ Adedi: {toplamSiparis}";
    }
    private void ToolStripSplitButton_Click(object sender, EventArgs e)
    {
        using Form chartForm = new();
        chartForm.AutoSize = true;
        chartForm.WindowState = FormWindowState.Normal;
        chartForm.FormBorderStyle = FormBorderStyle.FixedSingle;
        chartForm.Left = chartForm.Top = 0;
        chartForm.Size = PrimaryScreen.WorkingArea.Size;
        chartForm.ShowInTaskbar = true;
        chartForm.AutoScroll = true;
        Chart chart = new();
        chart.Size = chartForm.Size;
        Title title = new();
        title.Text = "Fiyat ve Stok Durumu";
        chart.Titles.Add(title);
        string axisX = _dataTable.Columns["ProductName"]!.Caption;
        string axisY = _dataTable.Columns["UnitPrice"]!.Caption;
        ChartArea chartArea = new();
        chartArea.AxisX.Interval = 1;
        chartArea.AxisY.Interval = 10;
        chartArea.AxisX.Title = axisX;
        chartArea.AxisY.Title = axisY;
        Font font = new("Arial", 14, FontStyle.Bold);
        title.Font =
            chartArea.AxisX.TitleFont =
                chartArea.AxisY.TitleFont =
                    chartArea.AxisX.LabelStyle.Font =
                        chartArea.AxisY.LabelStyle.Font = font;
        chartArea.Area3DStyle.Enable3D = true;
        chartArea.Area3DStyle.LightStyle = LightStyle.Simplistic;
        chartArea.Area3DStyle.Rotation = 10;
        chartArea.Area3DStyle.WallWidth = 25;
        chartArea.Area3DStyle.Inclination = 40;
        chart.ChartAreas.Add(chartArea);
        Series series = new();
        series.ChartType = SeriesChartType.Column;
        series.SetCustomProperty
            ("DrawingStyle", "Cylinder");
        series.SetCustomProperty("LabelStyle", "Top");
        series.IsValueShownAsLabel = true;
        series.XValueMember = _dataGridView
            .Columns[axisX]?.DataPropertyName;
        series.YValueMembers = _dataGridView
            .Columns[axisY]?.DataPropertyName;
        chart.Series.Add(series);
        chart.SaveImage("Chart.bmp", ChartImageFormat.Bmp);
        chart.AntiAliasing = AntiAliasingStyles.All;
        chart.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
        chart.DataSource = _dataGridView.DataSource;
        chartForm.Controls.Add(chart);
        ChartColorFormat(chart, series, chartArea);
        chartForm.ShowDialog();
    }
    private static void ChartColorFormat
        (Chart chart, Series series, ChartArea chartArea)
    {
        chart.BackColor = chartArea.BackColor = Color.FloralWhite;
        chartArea.AxisX.MajorGrid.LineColor =
            chartArea.AxisY.MajorGrid.LineColor = Color.Black;
        chart.BackSecondaryColor =
            series.BackSecondaryColor =
                chartArea.BackSecondaryColor =
                                Color.LightGoldenrodYellow;
        chart.BackGradientStyle =
            chartArea.BackGradientStyle =
                series.BackGradientStyle = GradientStyle.VerticalCenter;
        series.Palette = ChartColorPalette.Pastel;
    }
    private void DataGridViewRowColor(DataGridView dataGridView)
    {
        dataGridView.RowsDefaultCellStyle.BackColor = Color.White;
        dataGridView.AlternatingRowsDefaultCellStyle.
                            BackColor = Color.GhostWhite;
    }
    private bool _tiklandi = false;
    private void ToolStripButton_Click(object sender, EventArgs e)
    {
        if (_toolStripComboFilter.Items.Count == 0 ||
            _toolStripComboFilter.Text == string.Empty) return;
        _notifyIcon.Visible = true;
        _tiklandi = !_tiklandi;
        if (!_tiklandi)
        {
            ((ToolStripButton)sender).Text = "Filtrele";
            _dataTable.DefaultView.RowFilter = null;
            DataGridViewRowColor(_dataGridView);
            Height = _yukseklik;
            return;
        }
        ((ToolStripButton)sender).Text = @"Tümünü Göster";
        DataGridViewRowColor(_dataGridView);
        try
        {
            _dataTable.DefaultView.RowFilter = _=
                $"{_toolStripComboBox.Text} LIKE " +
                $"'%{_toolStripComboFilter.Text}%'";
        }
        catch (Exception)
        {
            if (_toolStripComboFilter.Text == string.Empty) return;
            string aranan =
                _toolStripComboFilter.Text.Replace(',', '.');
            _dataTable.DefaultView.RowFilter =
                string.Format($"{_toolStripComboBox?.Text} = {aranan}");
        }

        string m = $$"""
            Toplam {{satir}}   adet satýr var.
            Stok Adedi: {{toplamStokFiltreli}}  
            Bilgi ikonuna iki kez týklayýp kaldýrabilirsiniz.
            """ ;
        _notifyIcon.BalloonTipText = m;
        _notifyIcon.ShowBalloonTip(3_000);
        _notifyIcon.DoubleClick += _notifyIcon_DoubleClick!;
    }
    private void _notifyIcon_DoubleClick(object sender, EventArgs e)
        => _notifyIcon.Visible = false;
    private void ToolStripComboBoxFill(ToolStripComboBox toolStripComboBox,
            out int gridGenislik)
    {
        string _bicim = string.Empty;
        int genislik = 0;
        for (int j = 0; j < _dataGridView.Columns.Count; j++)
        {
            var dataGridViewColumn = _dataGridView.Columns[j];
            var dTblColumn = _dataTable.Columns[j];
            dataGridViewColumn.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            if (dTblColumn.DataType == typeof(short) ||
                dTblColumn.DataType == typeof(double) ||
                dTblColumn.DataType == typeof(decimal))
            {
                _bicim = "N2";
            }
            else if (dTblColumn.DataType == typeof(int))
            {
                _bicim = "N0";
            }
            else
            {
                dataGridViewColumn.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;
            }
            dataGridViewColumn.DefaultCellStyle.Format = _bicim;
            genislik += dataGridViewColumn.Width;
            toolStripComboBox.Items.Add(
                _dataTable.Columns[j].ColumnName);
        }
        gridGenislik = genislik;
    }
    private void ToolStripComboBox_SelectedIndexChanged
        (object sender, EventArgs e)
    {
        var columnName = ((ToolStripComboBox)sender).Text;
        DataColumn dataColumn = _dataTable.Columns[columnName];
        ControlsClear(_toolStripComboFilter);
        _toolStripComboFilter.Sorted = true;
        foreach (DataRow item in _dataTable.Rows)
        {
            if (!_toolStripComboFilter.Items.Contains(item[dataColumn]))
            {
                _toolStripComboFilter.Items.Add(item[dataColumn]);
            }
        }
    }
    private void ControlsClear(params dynamic[]? controls)
    {
        if (controls == null) return;
        try
        {
            foreach (dynamic ctrl in controls)
            {
                ctrl.Text = string.Empty;
                ctrl.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
    PrintDocument printDocument;
    private Bitmap bitmap;
    private void SplitButtonPrint_Click(object sender, EventArgs e)
    {
        printDocument = new();
        printDocument.PrintPage += PrintDocument_PrintPage;
        PrintDialog printDialog = new();
        printDialog.Document = printDocument;
        printDialog.UseEXDialog = true;
        bitmap = new Bitmap(_dataGridView.Width, _dataGridView.Height);
        _dataGridView.DrawToBitmap
        (bitmap, new Rectangle(20, 20,
            _dataGridView.Width, _dataGridView.Height));
        DialogResult result = printDialog.ShowDialog();
        if (result == DialogResult.OK)
        {
            printDocument.DocumentName = MachineName;
            printDocument.DefaultPageSettings.Landscape = true;
            printDocument.Print();
        }
    }
    private void PrintDocument_PrintPage
                (object sender, PrintPageEventArgs e)
            => e.Graphics?.DrawImage(bitmap, 0, 0);
}