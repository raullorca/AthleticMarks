using AthleticMarks.Data.Entities.Domain;
using AthleticMarks.Data.Entities.Enums;
using AthleticMarks.Data.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace AthleticMarks.App
{
    public partial class AtletheForm : Form
    {
        private const string _BirthYear = "BirthYear";
        private const string _Genre = "Genre";
        private const string _Id = "Id";
        private const string _Marks = "Marks";
        private const string _Name = "Name";

        private readonly RankingContext _context;

        public AtletheForm(RankingContext context)
        {
            _context = context;
            InitializeComponent();
            ShowGrid(GetAllAthletes());
        }

        private List<Athlete> GetAllAthletes()
        {
            return _context.Athletes.OrderBy(x => x.Name).ToList();
        }

        private int GetAthleteId()
        {
            return Convert.ToInt32(dataGrid.SelectedRows[0].Cells[_Id].Value);
        }

        private void InitializeDataGrid()
        {
            // Headers
            dataGrid.Columns[_BirthYear].HeaderText = "Any\nnaixement";
            dataGrid.Columns[_Genre].HeaderText = "Gènere";
            dataGrid.Columns[_Name].HeaderText = "Nom";

            // Ordered columns
            dataGrid.Columns[_Id].Visible = false;
            dataGrid.Columns[_Name].DisplayIndex = 0;
            dataGrid.Columns[_Name].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGrid.Columns[_Genre].DisplayIndex = 1;
            dataGrid.Columns[_BirthYear].DisplayIndex = 2;

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

        private void ShowAthleticEditForm(int athleteId)
        {
            this.Hide();
            var form = new AthleteEditForm(_context, athleteId);
            form.ShowDialog();
            this.Show();
        }

        private void ShowGrid(IList<Athlete> athleteList)
        {
            var dataBinding = new BindingSource();
            dataBinding.DataSource = athleteList;

            dataGrid.DataSource = dataBinding;

            InitializeDataGrid();
        }

        #region Events

        private void dataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGrid.Columns[_Genre].Index)
                {
                    e.Value = e.Value = Commons.Enums.GetDescription((Genre)e.Value);
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
            var athleteId = GetAthleteId();
            var athlete = _context.Athletes.Find(athleteId);
            if (athlete == null)
                Commons.Message.Error($"No he trobat l'atleta", "");

            var result = Commons.Message.Question($"Desitja esborrar l'atleta\n{athlete.Name}", "Esborrar atleta");
            if (result == DialogResult.Yes)
            {
                try
                {
                    _context.Athletes.Remove(athlete);
                    _context.SaveChanges();

                    ShowGrid(GetAllAthletes());
                    Commons.Message.Information("Atleta esborrat !!", "");
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

            var athleteId = GetAthleteId();
            ShowAthleticEditForm(athleteId);
            ShowGrid(GetAllAthletes());
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            var searchText = searchTextBox.Text;

            var data = _context
                .Athletes
                .Where(x => x.Name.Contains(searchText))
                .OrderBy(x => x.Name)
                .ToList();

            ShowGrid(data);
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            int athleteId = 0;
            ShowAthleticEditForm(athleteId);
            ShowGrid(GetAllAthletes());
        }

        #endregion Events
    }
}