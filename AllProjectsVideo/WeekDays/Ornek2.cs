namespace WeekDays;
public partial class Ornek2 : Form
{
    public Ornek2()
    {
        InitializeComponent();
    }

    private void Ornek2_Load(object sender, EventArgs e)
    {
        string[] days = {"Pazartesi", "Salý","Çarþamba", 
        "Perþembe", "Cuma", "Cumartesi","Pazar"};
        lstBoxWeekDays.Items.AddRange(days);
}
}