using AthleticMarks.App.Business;
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
    public partial class MarkEditForm : Form
    {
        private readonly RankingContext _context;
        private IMarkService _markService;
        private Mark currentMark;

        public MarkEditForm(RankingContext context, int id)
        {
            _context = context;

            currentMark = _context.Marks.Find(id);
            if (currentMark == null)
                currentMark = new Mark();

            _markService = new MarkService();
            InitializeComponent();
            PopulateControls();
        }

        private string AthleteName(int index)
        {
            if (currentMark.Athletes == null)
                return string.Empty;

            if (!currentMark.Athletes.Any())
                return string.Empty;

            if (currentMark.Athletes.Count < index)
                return string.Empty;

            return currentMark.Athletes.ToList()[index - 1].Name;
        }

        private string GetMarkValue(bool isTrialNotDefined)
        {
            if (isTrialNotDefined || currentMark.Value == 0)
                return string.Empty;

            return _markService.GetValueFormatted(currentMark);
        }

        private bool IsAthleteDefined(int position)
        {
            if (currentMark?.Athletes == null)
                return false;

            if (currentMark.Athletes.Count < position)
                return false;

            return currentMark.Athletes.ToList()[--position].Id != 0;
        }

        private bool IsAthleteSeleccionable(bool isTrialNotDefined, int athleteNumber)
        {
            if (isTrialNotDefined)
                return false;

            return athleteNumber <= currentMark.Trial.QuantityAthletes;
        }

        private void PopulateControls()
        {
            var isTrialNotDefined = currentMark.Trial == null;

            trackIndoor.Checked = currentMark.Track == Track.Indoor;
            trackOutdoor.Checked = currentMark.Track == Track.Outdoor;

            trialTextbox.Text = isTrialNotDefined ? string.Empty : currentMark.Trial.Name;

            athlete1Textbox.Text = AthleteName(1);
            searchAthlete1Button.Visible = IsAthleteSeleccionable(isTrialNotDefined, 1);
            removeAthlete1Button.Visible = IsAthleteDefined(1);

            athlete2Textbox.Text = AthleteName(2);
            searchAthlete2Button.Visible = IsAthleteSeleccionable(isTrialNotDefined, 2);
            removeAthlete2Button.Visible = IsAthleteDefined(2);

            athlete3Textbox.Text = AthleteName(3);
            searchAthlete3Button.Visible = IsAthleteSeleccionable(isTrialNotDefined, 3);
            removeAthlete3Button.Visible = IsAthleteDefined(3);

            athlete4Textbox.Text = AthleteName(4);
            searchAthlete4Button.Visible = IsAthleteSeleccionable(isTrialNotDefined, 4);
            removeAthlete4Button.Visible = IsAthleteDefined(4);

            dateMarkDateTimePicker.Value = currentMark.Date < dateMarkDateTimePicker.MinDate ? DateTime.Today : currentMark.Date;
            markValueTextbox.Text = GetMarkValue(isTrialNotDefined);
            markValueTextbox.ReadOnly = isTrialNotDefined;

            measurementTypeName.Text = isTrialNotDefined ? string.Empty : Commons.Enums.GetDescription(currentMark.Trial.Measurement);
            categoryTextbox.Text = _markService.GetNameCategory(currentMark);
            saisonTextbox.Text = _markService.GetSaison(currentMark.Date);
            townTextbox.Text = currentMark.Town;
            commentsTextbox.Text = currentMark.Comments;
            receiptTextbox.Text = currentMark.Receipt;
        }

        private void RemoveAthleteToItem(int pos)
        {
            pos--;
            var value = currentMark.Athletes.ToList()[pos];
            currentMark.Athletes.Remove(value);
        }

        private void ResultSearchAthlete(int pos)
        {
            pos--;

            Hide();

            using (var form = new AthleteSearchForm(_context))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (currentMark.Athletes == null)
                        currentMark.Athletes = new List<Athlete>();

                    if (currentMark.Athletes.Count >= pos + 1 && currentMark.Athletes.ToList()[pos].Id != form.Item.Id)
                    {
                        var athleteToRemove = currentMark.Athletes.ToList()[pos];
                        currentMark.Athletes.Remove(athleteToRemove);
                    }

                    var athlete = _context.Athletes.Find(form.Item.Id);
                    currentMark.Athletes.Add(athlete);
                }
            }
            Show();
            PopulateControls();
        }

        private bool SaveData()
        {
            if (currentMark.Id == 0)
            {
                _context.Marks.Add(currentMark);
            }
            else
            {
                _context.Entry(currentMark).State = System.Data.Entity.EntityState.Modified;
            }

            _context.SaveChanges();
            return true;
        }

        private bool ValidateForm()
        {
            // Pista
            if (!trackIndoor.Checked && !trackOutdoor.Checked)
            {
                Commons.Message.Error("Manca definir una pista", "Error");
                return false;
            }

            // Proba
            if (currentMark.Trial?.Id == null)
            {
                Commons.Message.Error("Manca definir la prova", "Error");
                return false;
            }

            // Athletes
            var qty = currentMark.Trial.QuantityAthletes;
            if (currentMark.Athletes == null || currentMark.Athletes.Count != qty)
            {
                var plural = qty == 1 ? "atleta" : "atletes";
                Commons.Message.Error($"Es obligatori que aquesta prova tingui {qty} {plural}", "Error");
                return false;
            }

            var isDuplicated = currentMark.Athletes
                                .GroupBy(x => x.Id)
                                .Count(g => g.Count() > 1) != 0;
            if (isDuplicated)
            {
                Commons.Message.Error($"Repasa els atletes, alguns estàn repetits", "Error");
                return false;
            }

            // Fecha marca
            if (currentMark.Date.Year < 1950)
            {
                Commons.Message.Error($"No s'acepta marques inferiors a 1950", "Error");
                return false;
            }
            if (currentMark.Date > DateTime.Today)
            {
                Commons.Message.Error($"No s'acepten marques posteriors a avui", "Error");
                return false;
            }

            // Marca

            if (string.IsNullOrEmpty(markValueTextbox.Text))
            {
                Commons.Message.Error($"Es obligatori introduïr una marca", "Error");
                return false;
            }

            if (currentMark.Value == 0m)
            {
                Commons.Message.Error($"Es obligatori introduïr una marca", "Error");
                return false;
            }

            if (string.IsNullOrEmpty(townTextbox.Text))
            {
                Commons.Message.Error($"Es obligatori introduïr una ciutat", "Error");
                return false;
            }

            return true;
        }

        private bool ValidateMarkValue(string text, Measurement measurement)
        {
            switch (measurement)
            {
                case Measurement.Distance:
                    if (!IsNumeric(text.Replace('.', ',')))
                    {
                        Commons.Message.Error($"El valor introduït NO son una distancia vàlida", "Error");
                        return false;
                    }
                    break;

                case Measurement.Time:
                    if (!IsTime(text))
                    {
                        Commons.Message.Error($"El valor introduït NO es un temps valid.\n(el format correcte es 00h 00' 00\" 000)", "Error");
                        return false;
                    }
                    break;

                case Measurement.Points:
                    if (!IsNumericNotDecimals(text))
                    {
                        Commons.Message.Error($"El valor introduït NO son punts valids.\n(no s'acepten decimals)", "Error");
                        return false;
                    }
                    break;

                default:
                    throw new NotImplementedException();
            }
            return true;
        }

        private bool IsNumeric(string s)
        {
            decimal output;
            return decimal.TryParse(s, out output);
        }

        private bool IsNumericNotDecimals(string text)
        {
            var chars = text.ToCharArray();
            foreach (var item in chars)
            {
                if (!char.IsDigit(item))
                    return false;
            }
            return true;
        }

        private bool IsTime(string value)
        {
            try
            {
                _markService.SetValueFormatted(value, Measurement.Time);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #region Events

        private void commentsTextbox_Leave(object sender, EventArgs e)
        {
            currentMark.Comments = commentsTextbox.Text;
        }

        private void dateMarkDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            currentMark.Date = dateMarkDateTimePicker.Value.Date;
            PopulateControls();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void markValueTextbox_Leave(object sender, EventArgs e)
        {
            if (ValidateMarkValue(markValueTextbox.Text, currentMark.Trial.Measurement))
            {
                var value = _markService.SetValueFormatted(markValueTextbox.Text, currentMark.Trial.Measurement);
                currentMark.Value = value;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm() && SaveData())
            {
                this.Close();
                return;
            }

            Commons.Message.Error("No s'ha grabat bé !!", "Error");

            this.DialogResult = DialogResult.None;
            return;
        }

        private void receiptTextbox_Leave(object sender, EventArgs e)
        {
            currentMark.Receipt = receiptTextbox.Text;
        }

        private void removeAthlete1Button_Click(object sender, EventArgs e)
        {
            RemoveAthleteToItem(1);

            PopulateControls();
        }

        private void searchAthlete1Button_Click(object sender, EventArgs e)
        {
            ResultSearchAthlete(1);
        }

        private void searchAthlete2Button_Click(object sender, EventArgs e)
        {
            ResultSearchAthlete(2);
        }

        private void searchAthlete3Button_Click(object sender, EventArgs e)
        {
            ResultSearchAthlete(3);
        }

        private void searchAthlete4Button_Click(object sender, EventArgs e)
        {
            ResultSearchAthlete(4);
        }

        private void searchTrialButton_Click(object sender, EventArgs e)
        {
            Hide();

            using (var form = new TrialSearchForm(_context))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    currentMark.Trial = form.Item;
                }
            }
            Show();
            PopulateControls();
        }

        private void townTextbox_Leave(object sender, EventArgs e)
        {
            currentMark.Town = townTextbox.Text;
        }

        #endregion Events
    }
}