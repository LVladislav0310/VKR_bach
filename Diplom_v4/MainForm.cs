using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Diplom_v4
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TypeSelector1.SelectedIndex = 0;
            TypeSelector2.SelectedIndex = 0;
            TypeSelector3.SelectedIndex = 0;
            VpSignalSelector.SelectedIndex = 0;
        }

        private void ButtonOf_Forward_Click(object sender, EventArgs e)
        {
            Logic.Ff = true;
            Logic.VeriF = false;

            textBox1.Enabled = true;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox9.Enabled = false;
            ButtonOf_Verification.BackColor = Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            ButtonOf_Reverse.BackColor = Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            ButtonOf_Forward.BackColor = Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(233)))), ((int)(((byte)(148)))));
        }

        private void ButtonOf_Reverse_Click(object sender, EventArgs e)
        {
            Logic.Ff = false;
            Logic.VeriF = false;

            textBox2.Enabled = true;
            textBox1.Enabled = false;
            textBox4.Enabled = false;
            textBox9.Enabled = false;
            ButtonOf_Verification.BackColor = Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            ButtonOf_Forward.BackColor = Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            ButtonOf_Reverse.BackColor = Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(233)))), ((int)(((byte)(148))))); 
        }

        private void TypeSelector1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Logic.Selector1 = TypeSelector1.SelectedIndex;
            
            if (TypeSelector1.SelectedIndex == 0)
            {
                pictureBox.Image = global::Diplom_v4.Properties.Resources.pt;
                label2.Text = "R, Ом";
                label6.Text = "R0, Ом";
                textBox3.Text = "100";
                label9.Text = "Диапазон сопротивления, Ом";
                label13.Text = "dR/dT, Ом/°C";
                label28.Text = "Δ, Ом";
                toolTip3.SetToolTip(textBox3, "номинальное сопротивление ТС, при температуре 0°С");

                TypeSelector2.Items.Clear();
                TypeSelector2.Items.AddRange(Logic.ResistanceTypes);

                ButtonOf_Reverse.Enabled = true;
            }
            else
            {
                pictureBox.Image = global::Diplom_v4.Properties.Resources.r;
                label2.Text = "E, мВ";
                label6.Text = "Т0, °C";
                textBox3.Text = "0";
                label9.Text = "Диапазон ТЭДС, мВ";
                label13.Text = "dE/dT, мВ/°C";
                label28.Text = "Δ, мВ";
                toolTip3.SetToolTip(textBox3, "температура свободного спая ТП");

                TypeSelector2.Items.Clear();
                TypeSelector2.Items.AddRange(Logic.ThermocouplesTypes);

                Logic.Ff = true;
                Logic.VeriF = false;

                textBox1.Enabled = true;
                textBox2.Enabled = false;
                textBox1.Text = "0";
                textBox2.Text = "0";
                ButtonOf_Reverse.BackColor = Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
                ButtonOf_Forward.BackColor = Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(233)))), ((int)(((byte)(148)))));
                ButtonOf_Verification.BackColor = Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));

                ButtonOf_Reverse.Enabled = false;
            };

            TypeSelector2.SelectedIndex = 0;
        }

        private void TypeSelector2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Logic.Selector2 = TypeSelector2.SelectedIndex;

            TypeSelector3.Items.Clear();
            TypeSelector3.Items.AddRange(Logic.GetCollectionOfKT(Logic.Selector1, Logic.Selector2));

            if (TypeSelector1.SelectedIndex == 0)
                switch (TypeSelector2.SelectedIndex)
                {
                    case 0:
                        pictureBox.Image = global::Diplom_v4.Properties.Resources.pt;
                        break;
                    case 1:
                        pictureBox.Image = global::Diplom_v4.Properties.Resources.p;
                        break;
                    case 2:
                        pictureBox.Image = global::Diplom_v4.Properties.Resources.m_tc;
                        break;
                    case 3:
                        pictureBox.Image = global::Diplom_v4.Properties.Resources.n_tc;
                        break;
                }
            else
                switch (TypeSelector2.SelectedIndex)
                {
                    case 0:
                        pictureBox.Image = global::Diplom_v4.Properties.Resources.r;
                        break;
                    case 1:
                        pictureBox.Image = global::Diplom_v4.Properties.Resources.s;
                        break;
                    case 2:
                        pictureBox.Image = global::Diplom_v4.Properties.Resources.b;
                        break;
                    case 3:
                        pictureBox.Image = global::Diplom_v4.Properties.Resources.j;
                        break;
                    case 4:
                        pictureBox.Image = global::Diplom_v4.Properties.Resources.t;
                        break;
                    case 5:
                        pictureBox.Image = global::Diplom_v4.Properties.Resources.e;
                        break;
                    case 6:
                        pictureBox.Image = global::Diplom_v4.Properties.Resources.k;
                        break;
                    case 7:
                        pictureBox.Image = global::Diplom_v4.Properties.Resources.n_tp;
                        break;
                    case 8:
                        pictureBox.Image = global::Diplom_v4.Properties.Resources.a1;
                        break;
                    case 9:
                        pictureBox.Image = global::Diplom_v4.Properties.Resources.a2;
                        break;
                    case 10:
                        pictureBox.Image = global::Diplom_v4.Properties.Resources.a3;
                        break;
                    case 11:
                        pictureBox.Image = global::Diplom_v4.Properties.Resources.l;
                        break;
                    case 12:
                        pictureBox.Image = global::Diplom_v4.Properties.Resources.m_pt;
                        break;
                }

            TypeSelector3.SelectedIndex = 0;
        }

        private void TypeSelector3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Logic.Selector3 = TypeSelector3.SelectedIndex;

            string str5 = "", str6 = "", str7 = "", str8 = "";
            Logic.GetRange(ref str5, ref str6, ref str7, ref str8);

            textBox5.Text = str5;
            textBox6.Text = str6;
            textBox7.Text = str7;
            textBox8.Text = str8;
        }

        private void ButtonOf_Verification_Click(object sender, EventArgs e)
        {

            textBox2.Enabled = true;
            textBox1.Enabled = true;
            textBox4.Enabled = false;
            textBox9.Enabled = false;
            toolTip1.SetToolTip(textBox2, "показания датчика");
            toolTip2.SetToolTip(textBox1, "достоверно известное значение температуры");
            ButtonOf_Verification.BackColor = Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(233)))), ((int)(((byte)(148)))));
            ButtonOf_Reverse.BackColor = Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            ButtonOf_Forward.BackColor = Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));

            Logic.VeriF = true;
        }

        private void ButtonOf_Reset_Click(object sender, EventArgs e)
        {
            TypeSelector1.SelectedIndex = 0;
            ButtonOf_Verification.BackColor = Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            ButtonOf_Reverse.BackColor = Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            ButtonOf_Forward.BackColor = Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(233)))), ((int)(((byte)(148)))));
            ButtonOf_Forward.Enabled = true;
            ButtonOf_Reverse.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox9.Enabled = false;
            label2.Text = "R, Ом";
            label6.Text = "R0, Ом";
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "100";
            textBox4.Text = "";
            textBox9.Text = "";
            toolTip1.RemoveAll();
            toolTip2.RemoveAll();
            label20.Text = "";
            label22.Text = "";
            label23.Text = "";
            label25.Text = "";

            Logic.Ff = true;
            Logic.VeriF = false;
        }

        private void ButtonOf_Go_Click(object sender, EventArgs e)
        {
            double x1, x2, x3;
            bool AllisGood = true;

            if (Logic.VeriF)
            {
                try
                {
                    x1 = Convert.ToDouble(textBox1.Text);
                    x2 = Convert.ToDouble(textBox2.Text);
                    x3 = Convert.ToDouble(textBox3.Text);

                    if (Convert.ToDouble(textBox1.Text) < Convert.ToDouble(textBox5.Text) || Convert.ToDouble(textBox1.Text) > Convert.ToDouble(textBox6.Text))
                    {
                        MessageBox.Show("Введенное значение температуры находится за пределами диапазона применения данного типа датчика.");
                        AllisGood = false;
                    }

                    if (AllisGood)
                    {
                        Logic.Verification(x1, x2, x3);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Был указан неверный формат числа.\nДля отделения дробной части используйте запятую (,).");
                    AllisGood = false;
                }
            }
            else
            {
                try
                {
                    x1 = 0;
                    x2 = Convert.ToDouble(textBox3.Text);

                    if (Logic.Ff)
                    {
                        if (Convert.ToDouble(textBox1.Text) < Convert.ToDouble(textBox5.Text) || Convert.ToDouble(textBox1.Text) > Convert.ToDouble(textBox6.Text))
                        {
                            MessageBox.Show("Введенное значение температуры находится за пределами диапазона применения данного типа датчика.");
                            AllisGood = false;
                        }
                        else x1 = Convert.ToDouble(textBox1.Text);
                    }
                    else
                    {
                        if (Convert.ToDouble(textBox2.Text) < Convert.ToDouble(textBox7.Text) || Convert.ToDouble(textBox2.Text) > Convert.ToDouble(textBox8.Text))
                        {
                            MessageBox.Show("Данный тип датчика не может генерировать таких значений.");
                            AllisGood = false;
                        }
                        else x1 = Convert.ToDouble(textBox2.Text);
                    }

                    if (AllisGood)
                    {
                        if (Logic.Ff) textBox2.Text = Convert.ToString(Math.Round(Logic.Solve(x1, x2), 3));
                        else textBox1.Text = Convert.ToString(Math.Round(Logic.Solve(x1, x2), 3));
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Был указан неверный формат числа.\nДля отделения дробной части используйте запятую (,).");
                    AllisGood = false;
                }
            }

            if (AllisGood)
            {
                label20.Text = Convert.ToString(Math.Round(Logic.tab1, 3));
                label22.Text = Convert.ToString(Math.Round(Logic.tab3, 3));
                label23.Text = Convert.ToString(Math.Round(Logic.tab4, 3));
                label25.Text = Convert.ToString(Math.Round(Logic.tab6, 3));

                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                if (Logic.Ff) textBox9.Enabled = true;

                textBox9.Text = Convert.ToString(Math.Round(Logic.df_dx, 3));

                // сигнал на входе вторичного прибора
                double min, max, real;
                min = Convert.ToDouble(textBox7.Text);
                max = Convert.ToDouble(textBox8.Text);
                real = Convert.ToDouble(textBox2.Text);

                switch (VpSignalSelector.SelectedIndex)
                {
                    case 1:
                        textBox4.Text = Convert.ToString(Math.Round((real - min) / (max - min) * 5, 3));
                        break;
                    case 2:
                        textBox4.Text = Convert.ToString(Math.Round((real - min) / (max - min) * 20, 3));
                        break;
                    case 3:
                        textBox4.Text = Convert.ToString(Math.Round((real - min) / (max - min) * 10, 3));
                        break;
                    default:
                        textBox4.Text = Convert.ToString(Math.Round((real - min) / (max - min) * 16 + 4, 3));
                        break;
                }
            }
        }
    }
}
