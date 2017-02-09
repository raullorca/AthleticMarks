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
    public partial class TrialEditForm : Form
    {
        private int _Id;
        private readonly RankingContext _context;

        public TrialEditForm(RankingContext context, int id)
        {
            InitializeComponent();
            _context = context;
            _Id = id;

            InitializeCustomComponent();
            PopulateValuesControls();
        }

        private void PopulateValuesControls()
        {
            if (_Id != 0)
            {
                var item = _context.Trials.Find(_Id);

                numberAthletesTextBox.Text = item.QuantityAthletes.ToString();
                measurementTypeComboBox.SelectedValue = (Measurement)item.Measurement;
                nameTextBox.Text = item.Name;
            }
        }

        private void InitializeCustomComponent()
        {
            var title = _Id == 0 ? "Nova " : "Editar ";
            this.Text = title + "prova";

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.numberAthletesTextBox.MaxLength = 1;

            measurementTypeComboBox.Populate<Measurement>();

            this.CenterToScreen();
        }

        private bool SaveData()
        {
            var item = ScreenToClassMap();

            var trial = _context.Trials.Find(_Id);

            if (trial == null)
                trial = new Trial();
            else
                trial.Id = _Id;

            trial.Measurement = item.Measurement;
            trial.Name = item.Name;
            trial.QuantityAthletes = item.QuantityAthletes;

            if (_Id == 0)
                _context.Trials.Add(trial);
            var regs = _context.SaveChanges();

            return regs > 0;
        }

        private Trial ScreenToClassMap()
        {
            return new Trial
            {
                Id = _Id,
                QuantityAthletes = int.Parse(numberAthletesTextBox.Text),
                Measurement = (Measurement)measurementTypeComboBox.SelectedValue,
                Name = nameTextBox.Text
            };
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                Commons.Message.Information("Nom de la prova obligatori", "Nom prova");
                nameTextBox.Select();
                return false;
            }

            if (measurementTypeComboBox.SelectedValue == null)
            {
                Commons.Message.Information("Mesura obligatoria", "Mesura prova");
                measurementTypeComboBox.Select();
                return false;
            }

            var numAthletesValue = numberAthletesTextBox.Text;
            if (string.IsNullOrWhiteSpace(numAthletesValue))
            {
                Commons.Message.Information("Numero d'atletes de la prova obligatori", "Numero d'atletes");
                numberAthletesTextBox.Select();
                return false;
            }

            int numAthletesNumber;
            if (!int.TryParse(numAthletesValue, out numAthletesNumber))
            {
                Commons.Message.Information("Numero d'atletes de la prova no es un numero", "Numero d'atletes");
                numberAthletesTextBox.Select();
                return false;
            }

            int[] athletes = { 1, 3, 4 };
            if (!athletes.Contains(numAthletesNumber))
            {
                Commons.Message.Information($"Numero d'atletes de la prova: {numAthletesNumber}\nNomés pot ser 1,3 o 4", "Numero d'atletes");
                numberAthletesTextBox.Select();
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