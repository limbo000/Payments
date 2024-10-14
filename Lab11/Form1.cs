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

                // Преобразуем годовую процентную ставку в квартальную
                double quarterlyInterestRate = annualInterestRate / 100 / 4;

                // Вычисляем количество кварталов
                int numberOfQuarters = years * 4;

                // Вычисляем ежеквартальный платеж по формуле аннуитета
                double quarterlyPayment = loanAmount * (quarterlyInterestRate * Math.Pow(1 + quarterlyInterestRate, numberOfQuarters)) /
                                          (Math.Pow(1 + quarterlyInterestRate, numberOfQuarters) - 1);

                // Отображаем результат в textBox5
                textBox5.Text = quarterlyPayment.ToString("F2");

                // Отображаем сообщение об успешном выполнении
                MessageBox.Show("Ежеквартальный платеж успешно рассчитан.", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Отображаем сообщение об ошибке
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

                // Очищаем предыдущие данные в DataGridView
                dataGridView1.Rows.Clear();

                // Получаем значения из текстовых полей
                double purchasePrice = double.Parse(textBox1.Text);
                double initialPayment = double.Parse(textBox2.Text);
                int years = int.Parse(textBox3.Text);
                double annualInterestRate = double.Parse(textBox4.Text);

                // Вычисляем сумму кредита
                double loanAmount = purchasePrice - initialPayment;

                // Преобразуем годовую процентную ставку в квартальную
                double quarterlyInterestRate = annualInterestRate / 100 / 4;

                // Вычисляем количество кварталов
                int numberOfQuarters = years * 4;

                // Вычисляем ежеквартальный платеж
                double quarterlyPayment = loanAmount * (quarterlyInterestRate * Math.Pow(1 + quarterlyInterestRate, numberOfQuarters)) /
                                          (Math.Pow(1 + quarterlyInterestRate, numberOfQuarters) - 1);

                // Переменная для оставшегося долга
                double remainingBalance = loanAmount;

                for (int quarter = 1; quarter <= numberOfQuarters; quarter++)
                {
                    // Ввод дополнительного платежа (например, из текстового поля или другого источника)
                    double extraPayment = 0; // Здесь можно предусмотреть ввод значения 
                    // Вычисляем платеж по процентам
                    double interestPayment = remainingBalance * quarterlyInterestRate;

                    // Вычисляем основной платеж
                    double principalPayment = quarterlyPayment - interestPayment + extraPayment;

                    // Уменьшаем оставшийся долг
                    remainingBalance -= principalPayment;

                    // Пересчитываем новый ежеквартальный платеж для оставшихся периодов
                    if (remainingBalance > 0 && quarter < numberOfQuarters)
                    {
                        quarterlyPayment = remainingBalance * (quarterlyInterestRate * Math.Pow(1 + quarterlyInterestRate, numberOfQuarters - quarter)) /
                                           (Math.Pow(1 + quarterlyInterestRate, numberOfQuarters - quarter) - 1);
                    }

                    // Добавляем строку в DataGridView
                    dataGridView1.Rows.Add(quarter, principalPayment.ToString("F2"), interestPayment.ToString("F2"), (quarterlyPayment + extraPayment).ToString("F2"));
                }

                // Отображаем сообщение об успешном выполнении
                MessageBox.Show("Схема платежей успешно построена.", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Отображаем сообщение об ошибке
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
