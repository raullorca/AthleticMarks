using AthleticMarks.App.Business;
using AthleticMarks.App.Models;
using AthleticMarks.Data.Entities.Domain;
using AthleticMarks.Data.Entities.Enums;
using AthleticMarks.Data.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AthleticMarks.App
{
    public partial class MarkForm : Form
    {
        private const string _Id = "Id";
        private const string _Year = "Date";
        private const string _Trial = "Trial";
        private const string _Town = "Town";
        private const string _Track = "Track";
        private const string _Mark = "Value";
        private const string _Comments = "Comments";
        private const string _Receipt = "Receipt";
        private const string _Athletes = "Athletes";
        private const string _Category = "Category";
        private const string _Saison = "Saison";

        private readonly RankingContext _context;
        private IMarkService _markService;

        public MarkForm(RankingContext context)
        {
            _context = context;
            _markService = new MarkService();
            InitializeComponent();
            ShowGrid(GetAllMarks());
        }

        private IList<MarkViewModel> GetAllMarks()
        {
            var items = new List<MarkViewModel>();

            foreach (var mark in _context.Marks.ToList())
            {
                items.Add(new MarkViewModel
                {
                    Id = mark.Id,
                    Athletes = _markService.GetNameAthletes(mark),
                    Category = _markService.GetNameCategory(mark),
                    Comments = mark.Comments,
                    Date = mark.Date,
                    Receipt = mark.Receipt,
                    Saison = _markService.GetSaison(mark.Date),
                    Town = mark.Town,
                    Track = Commons.Enums.GetDescription(mark.Track),
                    Trial = mark.Trial.Name,
                    Value = _markService.GetValueFormatted(mark)
                });
            }

            return items;
        }

        private int GetId()
        {
            return Convert.ToInt32(dataGrid.SelectedRows[0].Cells[_Id].Value);
        }

        private void InitializeDataGrid()
        {
            // Define general dataGrid
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.ReadOnly = true;
            dataGrid.MultiSelect = false;
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.AutoGenerateColumns = false;
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Headers
            dataGrid.Columns[_Track].HeaderText = "Pista";
            dataGrid.Columns[_Trial].HeaderText = "Prova";
            dataGrid.Columns[_Athletes].HeaderText = "Atletes";
            dataGrid.Columns[_Mark].HeaderText = "Marca";
            dataGrid.Columns[_Year].HeaderText = "Data";
            dataGrid.Columns[_Saison].HeaderText = "Temporada";
            dataGrid.Columns[_Category].HeaderText = "Categoria";
            dataGrid.Columns[_Town].HeaderText = "Lloc";
            dataGrid.Columns[_Comments].HeaderText = "Comentaris";
            dataGrid.Columns[_Receipt].HeaderText = "Comprobant";

            // special config
            dataGrid.Columns[_Athletes].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGrid.Columns[_Mark].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGrid.Columns[_Category].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGrid.Columns[_Year].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Ordered columns
            dataGrid.Columns[_Track].DisplayIndex = 0;
            dataGrid.Columns[_Trial].DisplayIndex = 1;
            dataGrid.Columns[_Athletes].DisplayIndex = 2;
            dataGrid.Columns[_Mark].DisplayIndex = 3;
            dataGrid.Columns[_Year].DisplayIndex = 4;
            dataGrid.Columns[_Saison].DisplayIndex = 5;
            dataGrid.Columns[_Category].DisplayIndex = 6;
            dataGrid.Columns[_Town].DisplayIndex = 7;
            dataGrid.Columns[_Comments].DisplayIndex = 8;
            dataGrid.Columns[_Receipt].DisplayIndex = 9;

            dataGrid.Columns[_Id].Visible = false;
        }

        private bool NothingSelected()
        {
            return dataGrid.SelectedRows.Count == 0;
        }

        private void ShowEditForm(int id)
        {
            this.Hide();
            var form = new MarkEditForm(_context, id);
            form.ShowDialog();
            this.Show();
        }

        private void ShowGrid(IList<MarkViewModel> list)
        {
            var dataBinding = new BindingSource();
            dataBinding.DataSource = list;

            dataGrid.DataSource = dataBinding;

            InitializeDataGrid();
        }

        #region Events

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (NothingSelected())
                return;
            var id = GetId();
            var item = _context.Marks.Find(id);
            if (item == null)
                Commons.Message.Error($"No he trobat la marca", "");

            var result = Commons.Message.Question($"Desitja esborrar la marca?", "Esborrar marca");
            if (result == DialogResult.Yes)
            {
                try
                {
                    _context.Marks.Remove(item);
                    _context.SaveChanges();

                    ShowGrid(GetAllMarks());
                    Commons.Message.Information("Marca esborrada !!", "");
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
            ShowGrid(GetAllMarks());
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            ShowEditForm(id);
            ShowGrid(GetAllMarks());
        }

        #endregion Events
    }
}