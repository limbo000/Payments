using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, что все поля заполнены
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    throw new Exception("Пожалуйста, заполните все поля.");
                }

                // Получаем значения из текстовых полей
                double purchasePrice = double.Parse(textBox1.Text);
                double initialPayment = double.Parse(textBox2.Text);
                int years = int.Parse(textBox3.Text);
                double annualInterestRate = double.Parse(textBox4.Text);

                // Вычисляем сумму кредита
                double loanAmount = purchasePrice - initialPayment;

                // Преобразуем годовую процентную ставку в месячную
                double monthlyInterestRate = annualInterestRate / 100 / 12;

                // Вычисляем количество месяцев
                int numberOfMonths = years * 12;

                // Вычисляем ежемесячный платеж по формуле аннуитета
                double monthlyPayment = loanAmount * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, numberOfMonths)) /
                                        (Math.Pow(1 + monthlyInterestRate, numberOfMonths) - 1);

                // Отображаем результат в textBox5
                textBox5.Text = monthlyPayment.ToString("F2");

                MessageBox.Show("Ежемесячный платеж успешно рассчитан.", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, что все поля заполнены
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    throw new Exception("Пожалуйста, заполните все поля.");
                }

                // Очищаем предыдущие данные в DataGridView dataGridView1.Rows.Clear();

                // Получаем значения из текстовых полей
                double purchasePrice = double.Parse(textBox1.Text);
                double initialPayment = double.Parse(textBox2.Text);
                int years = int.Parse(textBox3.Text);
                double annualInterestRate = double.Parse(textBox4.Text);

                // Вычисляем сумму кредита
                double loanAmount = purchasePrice - initialPayment;

                // Преобразуем годовую процентную ставку в месячную
                double monthlyInterestRate = annualInterestRate / 100 / 12;

                // Вычисляем количество месяцев
                int numberOfMonths = years * 12;

                // Вычисляем ежемесячный платеж
                double monthlyPayment = loanAmount * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, numberOfMonths)) /
                                        (Math.Pow(1 + monthlyInterestRate, numberOfMonths) - 1);

                // Переменная для оставшегося долга
                double remainingBalance = loanAmount;

                for (int month = 1; month <= numberOfMonths; month++)
                {
                    // Вычисляем платеж по процентам
                    double interestPayment = remainingBalance * monthlyInterestRate;

                    // Вычисляем основной платеж
                    double principalPayment = monthlyPayment - interestPayment;

                    // Уменьшаем оставшийся долг
                    remainingBalance -= principalPayment;

                    // Добавляем строку в DataGridView
                    dataGridView1.Rows.Add(month, principalPayment.ToString("F2"), interestPayment.ToString("F2"), monthlyPayment.ToString("F2"));
                }

                MessageBox.Show("Схема платежей успешно построена.", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
