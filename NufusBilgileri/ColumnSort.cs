using System.Collections;
namespace NufusBilgileri;
public class ColumnSort : IComparer
{
    public int e;
    public SortOrder sortStatus;
    CaseInsensitiveComparer comparer;
    public int Compare(object x, object y)
    {
        ListViewItem lviSec, lviClone;
        lviSec = (ListViewItem)x;
        lviClone = (ListViewItem)y;
        comparer = new(new CultureInfo(1055));
        int isBig = comparer.Compare
            (lviSec.SubItems[e].Text, lviClone.SubItems[e].Text);
        return
            sortStatus == SortOrder.Ascending 
                ? isBig 
                : sortStatus == SortOrder.Descending 
                    ? -isBig 
                    : (int)SortOrder.None;
    }
}