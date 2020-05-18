using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kozyachaya_coursework
{
    public partial class Form1 : Form
    {
        private static int caloriesNorm;
        private static int waterNorm;

        public Form1()
        {
            InitializeComponent();
        }
        

        private void weightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string symbol = e.KeyChar.ToString();

            if (!Regex.Match(symbol, @"[0-9]").Success)
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Back)
                e.Handled = false;
        }

        

        private void heightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string symbol = e.KeyChar.ToString();

            if (!Regex.Match(symbol, @"[0-9]").Success)
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Back)
                e.Handled = false;
        }

        private void ageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string symbol = e.KeyChar.ToString();

            if (!Regex.Match(symbol, @"[0-9]").Success)
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Back)
                e.Handled = false;
        }

        private void genderComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string symbol = e.KeyChar.ToString();

            if (!Regex.Match(symbol, @"[а-яА-Я]").Success)
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Back)
                e.Handled = false;
        }

        private void resultComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string symbol = e.KeyChar.ToString();

            if (!Regex.Match(symbol, @"[а-яА-Я]").Success)
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Back)
                e.Handled = false;
        }

        private void checkAndApplyParameters(int caloriesNorm, int waterNorm)
        {
            if (caloriesNorm < 1200)
            {
                caloriesNorm = 1200;
            }
            else if (waterNorm > 3500)
            {
                waterNorm = 3500;
            }

            caloriesNormTextBox.Text = Convert.ToString(caloriesNorm);
            waterNormTextBox.Text = Convert.ToString(waterNorm);
        }

        private void countButton_Click(object sender, EventArgs e)
        {
            int weight = 0;
            int height = 0;
            int age = 0;
            String gender = genderComboBox.Text;
            String result = resultComboBox.Text;

            if (weightTextBox.Text == "" || heightTextBox.Text == "" || ageTextBox.Text == "")
            {
                MessageBox.Show("Заполните все поля!", "Ошибка!");
            }
            else
            {
                weight = Convert.ToInt32(weightTextBox.Text);
                height = Convert.ToInt32(heightTextBox.Text);
                age = Convert.ToInt32(ageTextBox.Text);
            }

            switch (result)
            {
                case "Снижение веса":
                    if (gender == "Мужской")
                    {
                        caloriesNorm = Convert.ToInt32((88.36 + (13.4 * weight) + (4.8 * height) - (5.7 * age)) * 0.9);
                        waterNorm = Convert.ToInt32(weight * 35);

                        checkAndApplyParameters(caloriesNorm, waterNorm);
                        calorieTrackingButton.Visible = true;
                    }
                    else
                    {
                        caloriesNorm = Convert.ToInt32((447.6 + (9.2 * weight) + (3.1 * height) - (4.3 * age)) * 0.9);
                        waterNorm = Convert.ToInt32(weight * 31);

                        checkAndApplyParameters(caloriesNorm, waterNorm);
                        calorieTrackingButton.Visible = true;
                    }
                    break;

                case "Поддержание веса":
                    if (gender == "Мужской")
                    {
                        caloriesNorm = Convert.ToInt32((88.36 + (13.4 * weight) + (4.8 * height) - (5.7 * age)));
                        waterNorm = Convert.ToInt32(weight * 35);

                        checkAndApplyParameters(caloriesNorm, waterNorm);
                        calorieTrackingButton.Visible = true;
                    }
                    else
                    {
                        caloriesNorm = Convert.ToInt32((447.6 + (9.2 * weight) + (3.1 * height) - (4.3 * age)));
                        waterNorm = Convert.ToInt32(weight * 31);

                        checkAndApplyParameters(caloriesNorm, waterNorm);
                        calorieTrackingButton.Visible = true;

                    }
                    break;

                case "Набор веса":
                    if (gender == "Мужской")
                    {
                        caloriesNorm = Convert.ToInt32((88.36 + (13.4 * weight) + (4.8 * height) - (5.7 * age)) * 1.1);
                        waterNorm = Convert.ToInt32(weight * 35);

                        checkAndApplyParameters(caloriesNorm, waterNorm);
                        calorieTrackingButton.Visible = true;
                    }
                    else
                    {
                        caloriesNorm = Convert.ToInt32((447.6 + (9.2 * weight) + (3.1 * height) - (4.3 * age)) * 1.1);
                        waterNorm = Convert.ToInt32(weight * 31);

                        checkAndApplyParameters(caloriesNorm, waterNorm);
                        calorieTrackingButton.Visible = true;
                    }
                    break;

                default:
                    MessageBox.Show("Выбран некорректный результат", "");
                    break;
            }
        }

        private void calorieTrackingButton_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }

        public static int CaloriesNorm
        {
            get
            {
                if (caloriesNorm < 1200)
                {
                    caloriesNorm = 1200;
                }
                return caloriesNorm;
            }
        }

        public static int WaterNorm
        {
            get
            {
                if (waterNorm > 3500)
                {
                    waterNorm = 3500;
                }
                return waterNorm;
            }
        }
    }
}
