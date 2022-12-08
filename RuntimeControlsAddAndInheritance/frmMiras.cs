using System.Diagnostics;

namespace RuntimeControlsAddAndInheritance;
public partial class frmMiras : Form
{
    public frmMiras() => InitializeComponent();
    private void frmMiras_Load(object sender, EventArgs e)
    {
        AutoSize = true;
        Button button = new();
        button.Location = new(260, 25);
        button.Text = nameof(button);
        button.Click += Button_Click;
        Controls.Add(button);
        for (int i = 1; i <= 5; i++)
        {
            button = new();
            button.Location = new Point(260, (25 * i) + 25);
            if (i == 1)
                Debug.WriteLine
                ($"Standart Buton Yüksekliği: {button.Height}");
            Controls.Add(button);
        }
        Control ctr;
        NewControlAdd(new TextBox(), out ctr);
        PublicProperties(ctr, 5, 25);
        for (int i = 1; i <= 5; i++)
        {
            Control ctrl;
            NewControlAdd<ComboBox>(out ctrl);
            PublicProperties(ctrl, ctrl.Width + 10, 25 * i);
        }
        Control cntrl;
        NewControlAdd<MonthCalendar>(out cntrl);
        PublicProperties(cntrl, 5, 150);
    }
    private void Button_Click(object sender, EventArgs e)
        => MessageBox.Show(DateTime.Now.ToString());

    void NewControlAdd(Control control, out Control eklenen)
    {
        eklenen = control;
        Controls.Add(eklenen);
    }
    void NewControlAdd<T>
                (out Control eklenen) where T : Control, new()
    {
        eklenen = new T();
        Controls.Add(eklenen);
    }
    private static void PublicProperties
                    (Control control, int x = 10, int y = 10)
    {
        RgbRnd(out int red, out int green, out int blue);
        control.Location = new Point(x, y);
        control.BackColor = Color.FromArgb(red, green, blue);
    }
    private static void RgbRnd
                (out int red, out int green, out int blue)
    {
        Random rnd = new();
        red = rnd.Next(230, 255);
        green = rnd.Next(230, 255);
        blue = rnd.Next(230, 255);
    }
}