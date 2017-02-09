using AthleticMarks.Data.Entities.Domain;
using AthleticMarks.Data.Entities.Enums;
using AthleticMarks.Data.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AthleticMarks.App
{
    public partial class TrialForm : Form
    {
        private const string _QtyAthletes = "QuantityAthletes";
        private const string _Measurement = "Measurement";
        private const string _Id = "Id";
        private const string _Marks = "Marks";
        private const string _Name = "Name";

        private readonly RankingContext _context;

        public TrialForm(RankingContext context)
        {
            _context = context;
            InitializeComponent();
            ShowGrid(GetAllTrials());
        }

        private IList<Trial> GetAllTrials()
        {
            return _context.Trials.OrderBy(x => x.Name).ToList();
        }

        private int GetId()
        {
            return Convert.ToInt32(dataGrid.SelectedRows[0].Cells[_Id].Value);
        }

        private void InitializeDataGrid()
        {
            // Headers
            dataGrid.Columns[_QtyAthletes].HeaderText = "Num.\nAtletes";
            dataGrid.Columns[_Measurement].HeaderText = "Mesura";
            dataGrid.Columns[_Name].HeaderText = "Nom";

            // Ordered columns
            dataGrid.Columns[_Id].Visible = false;
            dataGrid.Columns[_Name].DisplayIndex = 0;
            dataGrid.Columns[_Name].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGrid.Columns[_Measurement].DisplayIndex = 1;

            dataGrid.Columns[_QtyAthletes].DisplayIndex = 2;
            dataGrid.Columns[_QtyAthletes].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dataGrid.Columns[_Marks].Visible = false;

            // Define general dataGrid
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.ReadOnly = true;
            dataGrid.MultiSelect = false;
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private bool NothingSelected()
        {
            return dataGrid.SelectedRows.Count == 0;
        }

        private void ShowEditForm(int id)
        {
            this.Hide();
            var form = new TrialEditForm(_context, id);
            form.ShowDialog();
            this.Show();
        }

        private void ShowGrid(IList<Trial> list)
        {
            var dataBinding = new BindingSource();
            dataBinding.DataSource = list;

            dataGrid.DataSource = dataBinding;

            InitializeDataGrid();
        }

        #region Events

        private void dataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGrid.Columns[_Measurement].Index)
                {
                    e.Value = Commons.Enums.GetDescription((Measurement)e.Value);
                }
            }
            catch (Exception ex)
            {
                Commons.Message.Error(ex.Message, "Error");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (NothingSelected())
                return;

            var id = GetId();
            var item = _context.Trials.Find(id);

            if (item == null)
                Commons.Message.Error($"No he trobat la prova", "");

            if ((item.Marks?.Count ?? 0) > 0)
            {
                Commons.Message.Error($"Aquesta prova s'está fent servir a {item.Marks.Count} marques", "Esborrar prova");
                return;
            }

            var result = Commons.Message.Question($"Desitja esborrar la prova\n{item.Name}", "Esborrar prova");

            if (result == DialogResult.Yes)
            {
                try
                {
                    _context.Trials.Remove(item);
                    _context.SaveChanges();

                    ShowGrid(GetAllTrials());
                    Commons.Message.Information("Prova esborrada !!", "");
                }
                catch (Exception error)
                {
                    Commons.Message.Error(error.Message, "Error");
                }
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (NothingSelected())
                return;

            var id = GetId();
            ShowEditForm(id);
            ShowGrid(GetAllTrials());
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            var searchText = searchTextBox.Text;

            var data = _context
               .Trials
               .Where(x => x.Name.Contains(searchText))
               .OrderBy(x => x.Name)
               .ToList();

            ShowGrid(data);
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            ShowEditForm(id);
            ShowGrid(GetAllTrials());
        }

        #endregion Events
    }
}