using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            calculateTotal();
        }

        public void calculateTotal()
        {
            int vkupnoSuma = 0;
            int cena = 0;
            if (rbMala.Checked)
            {
                int.TryParse(tbMala.Text, out cena);
                vkupnoSuma += cena;
            }
            else if (rbSredna.Checked)
            {
                int.TryParse(tbSredna.Text, out cena);
                vkupnoSuma += cena;
            }
            else if (rbGolema.Checked)
            {
                int.TryParse(tbGolema.Text, out cena);
                vkupnoSuma += cena;
            }
            if (cbFeferonki.Checked)
            {
                int.TryParse(tbFeferonki.Text, out cena);
                vkupnoSuma += cena;
            }
            if (cbSirenje.Checked)
            {
                int.TryParse(tbSirenje.Text, out cena);
                vkupnoSuma += cena;
            }
            if (cbKecap.Checked)
            {
                int.TryParse(tbKecap.Text, out cena);
                vkupnoSuma += cena;
            }
            if (tbVkupnoSprajt.Text != "")
            {
                int.TryParse(tbVkupnoSprajt.Text, out cena);
                vkupnoSuma += cena;
            }
            if (tbVkupnoPortokal.Text != "")
            {
                int.TryParse(tbVkupnoPortokal.Text, out cena);
                vkupnoSuma += cena;
            }
            if (tbVkupnoPivo.Text != "")
            {
                int.TryParse(tbVkupnoPivo.Text, out cena);
                vkupnoSuma += cena;
            }
            if (tbDesert.Text != "")
            {
                int.TryParse(tbDesert.Text, out cena);
                vkupnoSuma += cena;
            }
            tbVkupnoNaplata.Text = vkupnoSuma.ToString();




        }

        private void buttonChange_CheckedChanged(object sender, EventArgs e)
        {
            calculateTotal();
        }
        private void textGoleminaDodatociChanged_TextChanged(object sender, EventArgs e)
        {
            calculateTotal();
        }

        private void tbSprajt_TextChanged(object sender, EventArgs e)
        {
            int kolicina = 0, cena;
            int.TryParse(tbSprajt.Text, out kolicina);
            int.TryParse(tbCenaSprajt.Text, out cena);
            tbVkupnoSprajt.Text = (kolicina * cena).ToString();
            calculateTotal();
        }

        private void tbPortokal_TextChanged(object sender, EventArgs e)
        {
            int kolicina = 0, cena;
            int.TryParse(tbPortokal.Text, out kolicina);
            int.TryParse(tbCenaPortokal.Text, out cena);
            tbVkupnoPortokal.Text = (kolicina * cena).ToString();
            calculateTotal();
        }

        private void tbPivo_TextChanged(object sender, EventArgs e)
        {
            int kolicina = 0, cena;
            int.TryParse(tbPivo.Text, out kolicina);
            int.TryParse(tbCenaPivo.Text, out cena);
            tbVkupnoPivo.Text = (kolicina * cena).ToString();
            calculateTotal();
        }

        private void lbDesert_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbDesert.SelectedIndex == 0)
                tbDesert.Text = "80";
            else if (lbDesert.SelectedIndex == 1)
                tbDesert.Text = "120";
            else if (lbDesert.SelectedIndex == 2)
                tbDesert.Text = "160";
            calculateTotal();
        }

        private void tbNaplateno_TextChanged(object sender, EventArgs e)
        {
            int naplateno = 0, vkupno = 0;
            int.TryParse(tbNaplateno.Text, out naplateno);
            int.TryParse(tbVkupnoNaplata.Text, out vkupno);
            tbZaVrakjanje.Text = (naplateno - vkupno).ToString();
        }

        private void btNaracaj_Click(object sender, EventArgs e)
        {
            StringBuilder s = new StringBuilder();
            if (rbMala.Checked)
                s.Append("Мала пица\n");
            else if (rbSredna.Checked)
                s.Append("Средна пица\n");
            else if (rbGolema.Checked)
                s.Append("Голема пица\n");
            if (cbFeferonki.Checked || cbSirenje.Checked || cbKecap.Checked)
            {
                s.Append("Додатоци:\n");
                if (cbFeferonki.Checked)
                    s.Append("Феферонки\n");
                if (cbSirenje.Checked)
                    s.Append("Сирење\n");
                if (cbKecap.Checked)
                    s.Append("Кечап\n");
            }

            if (tbSprajt.Text != "0" || tbPortokal.Text != "0" || tbPivo.Text != "0")
            {
                s.Append("Пијалок:\n");
                if (tbSprajt.Text != "0")
                    s.Append(tbSprajt.Text + " Кока кола / Фанта / Спрајт\n");
                if (tbPortokal.Text != "0")
                    s.Append(tbPortokal.Text + " Сок од Јаболко / Портокал\n");
                if (tbPivo.Text != "0")
                    s.Append(tbPivo.Text + " Пиво\n");
            }
            if (lbDesert.SelectedIndex != -1)
            {
                s.Append("Десерт:\n");
                if (lbDesert.SelectedIndex == 0)
                    s.Append("Овошна пита\n");
                else if (lbDesert.SelectedIndex == 1)
                    s.Append("Сладолед\n");
                else if (lbDesert.SelectedIndex == 2)
                    s.Append("Торта\n");
            }

            //DialogResult kurovMi = MessageBox.Show(s.ToString(), "ОВА Е НАСЛОВОТ", MessageBoxButtons.OK, MessageBoxIcon.None);

            DialogResult r = MessageBox.Show(s.ToString(), "Вашата нарачка", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void btOtkazi_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Дали сакате да ја откажете нарачката?", "Откажи нарачка?", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (r == DialogResult.Yes)
                Application.Exit();
        }
    }
}