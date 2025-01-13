public Form1()
{
    InitializeComponent();
    dataGridView1.CellFormatting += DataGridView1_CellFormatting;
}

private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
{
    if (dataGridView1.Columns[e.ColumnIndex].Name == "SuaColunaID")
    {
        if (e.Value != null)
        {
            e.Value = e.Value.ToString().PadLeft(6, '0');  // Adiciona zeros à esquerda para um total de 6 caracteres
            e.FormattingApplied = true;
        }
    }
}
