﻿using AthleticMarks.Data.Entities.Domain;
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
    public partial class TrialSearchForm : Form
    {
        private const string _NumberAthletes = "QuantityAthletes";
        private const string _MeasurementType = "Measurement";
        private const string _Id = "Id";
        private const string _Marks = "Marks";
        private const string _Name = "Name";

        private readonly RankingContext _context;

        public Trial Item { get; set; }

        public TrialSearchForm(RankingContext context)
        {
            _context = context;
            InitializeComponent();
            ShowGrid();
        }

        private void InitializeDataGrid()
        {
            // Headers
            dataGrid.Columns[_NumberAthletes].HeaderText = "Num.\nAtletes";
            dataGrid.Columns[_MeasurementType].HeaderText = "Mesura";
            dataGrid.Columns[_Name].HeaderText = "Nom";

            // Ordered columns
            dataGrid.Columns[_Id].Visible = false;
            dataGrid.Columns[_Name].DisplayIndex = 0;
            dataGrid.Columns[_Name].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGrid.Columns[_MeasurementType].DisplayIndex = 1;

            dataGrid.Columns[_NumberAthletes].DisplayIndex = 2;
            dataGrid.Columns[_NumberAthletes].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dataGrid.Columns[_Marks].Visible = false;

            // Define general dataGrid
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.ReadOnly = true;
            dataGrid.MultiSelect = false;
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ShowGrid(IList<Trial> list)
        {
            var dataBinding = new BindingSource();
            dataBinding.DataSource = list;

            dataGrid.DataSource = dataBinding;

            InitializeDataGrid();
        }

        private void ShowGrid()
        {
            var data = _context.Trials.ToList();
            ShowGrid(data);
        }

        private int GetId()
        {
            return Convert.ToInt32(dataGrid.SelectedRows[0].Cells[_Id].Value);
        }

        private bool NothingSelected()
        {
            return dataGrid.SelectedRows.Count == 0;
        }

        private void dataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGrid.Columns[_MeasurementType].Index)
                {
                    e.Value = Commons.Enums.GetDescription((Measurement)e.Value);
                }
            }
            catch (Exception ex)
            {
                Commons.Message.Error(ex.Message, "Error");
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (NothingSelected())
                return;

            Item = _context.Trials.Find(GetId());

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
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
    }
}