using AthleticMarks.App.Commons.Extensions;
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
    public partial class AthleteEditForm : Form
    {
        private int _athleteId;
        private readonly RankingContext _context;

        public AthleteEditForm(RankingContext context, int athleteId)
        {
            InitializeComponent();
            _context = context;
            _athleteId = athleteId;

            InitializeCustomComponent();
            PopulateValuesControls();
        }

        private void PopulateValuesControls()
        {
            if (_athleteId != 0)
            {
                var athlete = _context.Athletes.Find(_athleteId);

                birthYearTextBox.Text = athlete.BirthYear.ToString();
                genreComboBox.SelectedValue = (Genre)athlete.Genre;
                nameTextBox.Text = athlete.Name;
            }
        }

        private void InitializeCustomComponent()
        {
            var title = _athleteId == 0 ? "Nou " : "Editar ";
            this.Text = title + "atleta";

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.birthYearTextBox.MaxLength = 4;

            genreComboBox.Populate<Genre>();

            this.CenterToScreen();
        }

        private bool SaveData()
        {
            var item = ScreenToClassMap();

            var athlete = _context.Athletes.Find(_athleteId);

            if (athlete == null)
                athlete = new Athlete();
            else
                athlete.Id = _athleteId;

            athlete.BirthYear = item.BirthYear;
            athlete.Genre = item.Genre;
            athlete.Name = item.Name;

            if (_athleteId == 0)
                _context.Athletes.Add(athlete);

            var regs = _context.SaveChanges();
            return regs > 0;
        }

        private Athlete ScreenToClassMap()
        {
            return new Athlete
            {
                Id = _athleteId,
                BirthYear = int.Parse(birthYearTextBox.Text),
                Genre = (Genre)genreComboBox.SelectedValue,
                Name = nameTextBox.Text
            };
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                Commons.Message.Information("Nom de l'atleta obligatori", "Nom atleta");
                nameTextBox.Select();
                return false;
            }

            if (genreComboBox.SelectedValue == null)
            {
                Commons.Message.Information("Gènere obligatori", "Nom atleta");
                genreComboBox.Select();
                return false;
            }

            var birthYearValue = birthYearTextBox.Text;
            if (string.IsNullOrWhiteSpace(birthYearValue))
            {
                Commons.Message.Information("Any de naixement obligatori", "Any naixament");
                birthYearTextBox.Select();
                return false;
            }

            int birthYearNumber;
            if (!int.TryParse(birthYearValue, out birthYearNumber))
            {
                Commons.Message.Information("L'any de naixement no es un numero", "Any naixament");
                birthYearTextBox.Select();
                return false;
            }

            if (!birthYearNumber.Between(1900, DateTime.Today.Year))
            {
                Commons.Message.Information($"L'any de naixement: {birthYearNumber}\nes inferior a 1900 o superior a l'any actual", "Any naixament");
                birthYearTextBox.Select();
                return false;
            }

            return true;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                if (SaveData())
                {
                    this.Close();
                    return;
                }
                else
                    Commons.Message.Error("No s'ha grabat bé !!", "Error");
            }

            this.DialogResult = DialogResult.None;
            return;
        }

        private void birthYearTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}