namespace Lab3.TehPrelucrareDb
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        private AdventureWorksDataAccess _dataAccess;
        private BindingSource _bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            PopulateTableNames();
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }

        private void PopulateTableNames()
        {
            var tableNames = AdventureWorksDataAccess.GetTableNames();
            comboBox1.Items.AddRange(tableNames);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                string selectedTable = comboBox1.SelectedItem.ToString();
                _dataAccess = new AdventureWorksDataAccess(selectedTable);

                ClearDataBindings(dataFieldsPanel);
                dataFieldsPanel.Controls.Clear();

                _bindingSource.DataSource = null;
                _bindingSource.DataSource = _dataAccess.DataTable;
                
                CreateDynamicUI(_dataAccess.DataTable);

                UpdateCurrentRecordCount();
            }
        }


        private void ClearDataBindings(Control control)
        {
            foreach (Control childControl in control.Controls)
            {
                childControl.DataBindings.Clear();
                ClearDataBindings(childControl);
            }
        }



        private void UpdateCurrentRecordCount()
        {
            currentRecordCount.Text = $"{_bindingSource.Position + 1} of {_bindingSource.Count}";
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            _bindingSource.MoveNext();
            UpdateCurrentRecordCount();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            _bindingSource.MovePrevious();
            UpdateCurrentRecordCount();
        }
            private void CreateDynamicUI(DataTable table)
    {
        dataFieldsPanel.Controls.Clear();

        foreach (DataColumn column in table.Columns)
        {
            Label label = new Label
            {
                Text = column.ColumnName,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.BottomLeft
            };

            Control inputControl;


                inputControl = new TextBox { Dock = DockStyle.Top };
                inputControl.DataBindings.Add(new Binding("Text", _bindingSource, column.ColumnName, true, DataSourceUpdateMode.OnPropertyChanged));


                inputControl.Name = "input" + column.ColumnName;
            dataFieldsPanel.Controls.Add(label);
            dataFieldsPanel.Controls.Add(inputControl);
        }
    }


        private void updateBtn_Click(object sender, EventArgs e)
        {
            _bindingSource.EndEdit();

            _dataAccess.CommitChanges();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current != null)
            {
                var result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    _bindingSource.RemoveCurrent();

                    try
                    {
                        _dataAccess.CommitChanges();
                        MessageBox.Show("Record deleted successfully.");
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 547)
                        {
                            MessageBox.Show("This record cannot be deleted because it is referenced by other data.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            throw;
                        }
                    }

                    _bindingSource.DataSource = _dataAccess.DataTable;

                    UpdateCurrentRecordCount();
                }
            }
        }

        private void firstPageButton_Click(object sender, EventArgs e)
        {
            _bindingSource.Position = 0;
            UpdateCurrentRecordCount();
        }

        private void lastPageButton_Click(object sender, EventArgs e)
        {
            _bindingSource.Position = _bindingSource.Count - 1;
            UpdateCurrentRecordCount();
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please correct the input fields.");
                return;
            }

            DataRowView newRow = (DataRowView)_bindingSource.AddNew();
            
            foreach (Control control in dataFieldsPanel.Controls)
            {
                if (control is TextBox textBox)
                {
                    string columnName = textBox.Name.Replace("input", "");
                    DataColumn column = _dataAccess.DataTable.Columns[columnName];
                    if (column != null && !column.AutoIncrement && !column.ReadOnly)
                    {
                        try
                        {
                            MessageBox.Show(textBox.BindingContext.ToString());

                            newRow[columnName] = ConvertToColumnType(textBox.Text, column.DataType);
                        }
                        catch (FormatException ex)
                        {
                            MessageBox.Show($"The value for {columnName} is not in the correct format: {textBox.Text}");
                            _bindingSource.CancelEdit();
                            return;
                        }
                    }
                }
            }

            _bindingSource.EndEdit();

            try
            {
                _dataAccess.CommitChanges();
                MessageBox.Show("Record inserted successfully.");

                _bindingSource.DataSource = _dataAccess.DataTable;

                UpdateCurrentRecordCount();

                _bindingSource.Position = _bindingSource.IndexOf(newRow);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting new record: " + ex.Message);
                _bindingSource.RemoveCurrent();
            }
        }

        private object ConvertToColumnType(string text, Type dataType)
        {
            if (string.IsNullOrEmpty(text))
                return DBNull.Value;

            if (dataType == typeof(int))
            {
                if (int.TryParse(text, out int result))
                    return result;
                else
                    throw new FormatException("Input string is not in a correct format for integer.");
            }

            return text;
        }
    }
}