namespace UIWinForms;
public static class GridFormat
{
    public static void DgwFormat(DataGridView dgw)
    {
        int satirNo = 1;
        foreach (DataGridViewRow item in dgw.Rows)
        {
            item.HeaderCell.Value = satirNo.ToString();
            satirNo++;
            if (satirNo > 500) break;
        }
        dgw.AutoResizeRowHeadersWidth
                (DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader);
        dgw.RowsDefaultCellStyle.BackColor = Color.White;
        dgw.AlternatingRowsDefaultCellStyle.BackColor = Color.GhostWhite;
        dgw.EditMode = DataGridViewEditMode.EditProgrammatically;
        dgw.AllowUserToDeleteRows = false;
        dgw.AllowUserToAddRows = false;
        dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgw.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        dgw.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }
}
