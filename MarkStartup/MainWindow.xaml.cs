using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MarkStartup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            question1.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double group_one_quest_one = Convert.ToInt32(question1.Text);
            double group_one_quest_two = Convert.ToInt32(question2.Text);
            double group_one_quest_three = Convert.ToInt32(question3.Text);
            double group_one_quest_four = Convert.ToInt32(question4.Text);
            double group_two_quest_one = Convert.ToInt32(question5.Text);
            double group_two_quest_two = Convert.ToInt32(question6.Text);
            double group_two_quest_three = Convert.ToInt32(question7.Text);
            double group_three_quest_one = Convert.ToInt32(question8.Text);
            double group_three_quest_two = Convert.ToInt32(question9.Text);
            double group_four_quest_one = Convert.ToInt32(question10.Text);
            double group_four_quest_two = Convert.ToInt32(question11.Text);
            double group_four_quest_three = Convert.ToInt32(question12.Text);
            double group_four_quest_four = Convert.ToInt32(question13.Text);
            double group_four_quest_five = Convert.ToInt32(question14.Text);
            double group_four_quest_six = Convert.ToInt32(question15.Text);
            double group_four_quest_seven = Convert.ToInt32(question16.Text);
            double group_five_quest_one = Convert.ToInt32(question17.Text);
            double group_five_quest_two = Convert.ToInt32(question18.Text);
            double group_five_quest_three = Convert.ToInt32(question19.Text);
            double group_five_quest_four = Convert.ToInt32(question20.Text);
            double group_five_quest_five = Convert.ToInt32(question21.Text);
            //найгірнші відповіді
            double group_one_min = 20;
            double group_two_min = 15;
            double group_three_min = 10;
            double group_four_min = 50;
            double group_five_min = 25;
            //найкращі відповіді
            double group_one_max = 115;
            double group_two_max = 60;
            double group_three_max = 50;
            double group_four_max = 225;
            double group_five_max = 90;

            //Бажані значення
            double group_one_desired_value = Convert.ToInt32(group_one_desired_valueForm.Text);
            double group_two_desired_value = Convert.ToInt32(group_two_desired_valueForm.Text);
            double group_three_desired_value = Convert.ToInt32(group_three_desired_valueForm.Text);
            double group_four_desired_value = Convert.ToInt32(group_four_desired_valueForm.Text);
            double group_five_desired_value = Convert.ToInt32(group_five_desired_valueForm.Text);


            //Обчисення суми по групах
            double group_one_amount = group_one_quest_one + group_one_quest_two + group_one_quest_three + group_one_quest_four;
            double group_two_amount = group_two_quest_one + group_two_quest_two + group_two_quest_three;
            double group_three_amount = group_three_quest_one + group_three_quest_two;
            double group_four_amount = group_four_quest_one + group_four_quest_two + group_four_quest_three + group_four_quest_four + group_four_quest_five + group_four_quest_six + group_four_quest_seven;
            double group_five_amount = group_five_quest_one + group_five_quest_two + group_five_quest_three + group_five_quest_four + group_five_quest_five;


            //Обчислення функції належності
            double group_one_function_membership = 0;
            double group_two_function_membership = 0;
            double group_three_function_membership = 0;
            double group_four_function_membership = 0;
            double group_five_function_membership = 0;
            //1
            if (group_one_amount < group_one_min)
            {
                group_one_function_membership = 0;
            }
            else if (group_one_amount <= (group_one_min + group_one_max) / 2)
            {
                group_one_function_membership = 2 * Math.Pow((group_one_amount - group_one_min) / (group_one_max - group_one_min), 2);
            }
            else if (group_one_amount < group_one_max)
            {
                group_one_function_membership = 1 - 2 * Math.Pow((group_one_max - group_one_amount) / (group_one_max - group_one_min), 2);
            }
            else group_one_function_membership = 1;

            //2
            if (group_two_amount < group_two_min)
            {
                group_two_function_membership = 0;
            }
            else if (group_two_amount <= (group_two_min + group_two_max) / 2)
            {
                group_two_function_membership = 2 * Math.Pow((group_two_max - group_two_amount) / (group_two_max - group_two_min), 2);
            }
            else if (group_two_amount < group_two_max)
            {
                group_two_function_membership = 1 - 2 * Math.Pow((group_two_max - group_two_amount) / (group_two_max - group_two_min), 2);
            }
            else group_two_function_membership = 1;

            //3
            if (group_three_amount < group_three_min)
            {
                group_three_function_membership = 0;
            }
            else if (group_three_amount <= (group_three_min + group_three_max) / 2)
            {
                group_three_function_membership =  2 * Math.Pow((group_three_max - group_three_amount) / (group_three_max - group_three_min), 2);
            }
            else if (group_three_amount < group_three_max)
            {
                group_three_function_membership = 1 - 2 * Math.Pow((group_three_max - group_three_amount) / (group_three_max - group_three_min), 2);
            }
            else group_three_function_membership = 1;

            //4
            if (group_four_amount < group_four_min)
            {
                group_four_function_membership = 0;
            }
            else if (group_four_amount <= (group_four_min + group_four_max) / 2)
            {
                group_four_function_membership =  2 * Math.Pow((group_four_max - group_four_amount) / (group_four_max - group_four_min), 2);
            }
            else if (group_four_amount < group_four_max)
            {
                group_four_function_membership = 1 - 2 * Math.Pow((group_four_max - group_four_amount) / (group_four_max - group_four_min), 2);
            }
            else group_four_function_membership = 1;

            //5
            if (group_five_amount < group_five_min)
            {
                group_five_function_membership = 0;
            }
            else if (group_five_amount <= (group_five_min + group_five_max) / 2)
            {
                group_five_function_membership = 2 * Math.Pow((group_five_max - group_five_amount) / (group_five_max - group_five_min), 2);
            }
            else if (group_five_amount < group_five_max)
            {
                group_five_function_membership = 1 - 2 * Math.Pow((group_five_max - group_five_amount) / (group_five_max - group_five_min), 2);
            }
            else group_five_function_membership = 1;

            
             
             
             


            // Обчислення функції бажаної належності
            double group_one_function_desired_membership = 1 - 2 * Math.Pow((group_one_max - group_one_desired_value) / (group_one_max - group_one_min), 2);
            double group_two_function_desired_membership = 1 - 2 * Math.Pow((group_two_max - group_two_desired_value) / (group_two_max - group_two_min), 2);
            double group_three_function_desired_membership = 1 - 2 * Math.Pow((group_three_max - group_three_desired_value) / (group_three_max - group_three_min), 2);
            double group_four_function_desired_membership = 1 - 2 * Math.Pow((group_four_max - group_four_desired_value) / (group_four_max - group_four_min), 2);
            double group_five_function_desired_membership = 1 - 2 * Math.Pow((group_five_max - group_five_desired_value) / (group_five_max - group_five_min), 2);


            // Обчислення функції лінгвістиних змінних
            double group_one_linguistic_variable = Math.Abs((4 * group_one_function_membership - 4 * group_one_function_desired_membership) / group_one_function_desired_membership);
            double group_two_linguistic_variable = Math.Abs((4 * group_two_function_membership - 4 * group_two_function_desired_membership) / group_two_function_desired_membership);
            double group_three_linguistic_variable = Math.Abs((5 * group_three_function_desired_membership - 4 * group_three_function_membership) / group_three_function_desired_membership);
            double group_four_linguistic_variable = Math.Abs((4 * group_four_function_membership - 4 * group_four_function_desired_membership) / group_four_function_desired_membership);
            double group_five_linguistic_variable = 1;
            ///////


            //Обчислення наступної функції належності
            //double group_one_next_function_membership = 0;
            //double group_two_next_function_membership = 0;
            //double group_three_next_function_membership = 0;
            //double group_four_next_function_membership = 0;
            //double group_five_next_function_membership = 0;
            ////1

            //if (group_one_amount <= (group_one_min + group_one_max) / 2)
            //{
            //    if (group_one_linguistic_variable < 1 - group_one_linguistic_variable)
            //    {
            //        group_one_next_function_membership = group_one_linguistic_variable;
            //    }
            //    else group_one_next_function_membership = 1 - group_one_linguistic_variable;


            //}
            //else 
            //{
            //    if (group_one_linguistic_variable > 1 - group_one_linguistic_variable)
            //    {
            //        group_one_next_function_membership = group_one_linguistic_variable;
            //    }
            //    else group_one_next_function_membership = 1 - group_one_linguistic_variable;

            //}


            ////2

            // if (group_two_amount <= (group_two_min + group_two_max) / 2)
            //{
            //    if (group_two_linguistic_variable < 1 - group_two_linguistic_variable)
            //    {
            //        group_two_next_function_membership = group_two_linguistic_variable;
            //    }
            //    else group_two_next_function_membership = 1 - group_two_linguistic_variable;
            //}
            //else
            //{
            //    if (group_two_linguistic_variable > 1 - group_two_linguistic_variable)
            //    {
            //        group_two_next_function_membership = group_two_linguistic_variable;
            //    }
            //    else group_two_next_function_membership = 1 - group_two_linguistic_variable;
            //}


            ////3
            //if (group_three_amount <= (group_three_min + group_three_max) / 2)
            //{
            //    if (group_three_linguistic_variable < 1 - group_three_linguistic_variable)
            //    {
            //        group_three_next_function_membership = group_three_linguistic_variable;
            //    }
            //    else group_three_next_function_membership = 1 - group_three_linguistic_variable;
            //}
            //else 
            //{
            //    if (group_three_linguistic_variable > 1 - group_three_linguistic_variable)
            //    {
            //        group_three_next_function_membership = group_three_linguistic_variable;
            //    }
            //    else group_three_next_function_membership = 1 - group_three_linguistic_variable;
            //}


            ////4
            // if (group_four_amount <= (group_four_min + group_four_max) / 2)
            //{
            //    if (group_four_linguistic_variable < 1 - group_four_linguistic_variable)
            //    {
            //        group_four_next_function_membership = group_four_linguistic_variable;
            //    }
            //    else group_four_next_function_membership = 1 - group_four_linguistic_variable;
            //}
            //else 
            //{
            //    if (group_four_linguistic_variable > 1 - group_four_linguistic_variable)
            //    {
            //        group_four_next_function_membership = group_four_linguistic_variable;
            //    }
            //    else group_four_next_function_membership = 1 - group_four_linguistic_variable;
            //}


            ////5
            //group_five_next_function_membership = 0;


            double group_one_next_function_membership = group_one_linguistic_variable / 2;
            double group_two_next_function_membership = 1 - group_two_linguistic_variable;
            double bb = 1 - group_three_linguistic_variable;
            double group_three_next_function_membership = bb / 2;
            double aa = 1 - group_four_linguistic_variable;
            double group_four_next_function_membership = aa / 2;
            double group_five_next_function_membership = 0;

            //Вагові коефіціенти
            double group_one_weight_variable = Convert.ToInt32(group_one_weight_variableForm.Text);
            double group_two_weight_variable = Convert.ToInt32(group_two_weight_variableForm.Text);
            double group_three_weight_variable = Convert.ToInt32(group_three_weight_variableForm.Text);
            double group_four_weight_variable = Convert.ToInt32(group_four_weight_variableForm.Text);
            double group_five_weight_variable = Convert.ToInt32(group_five_weight_variableForm.Text);

            //Обчислення суми вагових коефіціентів
            double weight_amount = group_one_weight_variable + group_two_weight_variable + group_three_weight_variable + group_four_weight_variable + group_five_weight_variable;

            //Обчислення нормованих вагових коефіціентів
            double group_one_normalized_weight = group_one_weight_variable / weight_amount;
            double group_two_normalized_weight = group_two_weight_variable / weight_amount;
            double group_three_normalized_weight = group_three_weight_variable / weight_amount;
            double group_four_normalized_weight = group_four_weight_variable / weight_amount;
            double group_five_normalized_weight = group_five_weight_variable / weight_amount;


            //Обчислення агрегованої оцінки

            //double mark = group_one_next_function_membership * group_one_normalized_weight  + group_two_next_function_membership * group_two_normalized_weight + group_three_next_function_membership * group_three_normalized_weight  + group_four_next_function_membership * group_four_normalized_weight + group_five_next_function_membership * group_five_normalized_weight;
            //double mark = group_one_linguistic_variable * group_one_normalized_weight + group_two_linguistic_variable * group_two_normalized_weight + group_three_linguistic_variable * group_three_normalized_weight + group_four_linguistic_variable * group_four_normalized_weight + group_five_linguistic_variable * group_five_normalized_weight;


            double a1 = group_one_next_function_membership * group_one_normalized_weight;
            double a2 = group_two_next_function_membership * group_two_normalized_weight;
            double a3 = group_three_next_function_membership * group_three_normalized_weight;
            double a4 = group_four_next_function_membership * group_four_normalized_weight;
            double a5 = group_five_next_function_membership * group_five_normalized_weight;
            double mark = a1 + a2 + a3 + a4 + a5;

            //Вивід даних
            markForm.Text =Math.Round(mark,3).ToString();
            if (mark>0.67)
            {
                conclusion.Text = "оцінка ідеї висока";
            }
            else if (mark > 0.47 && mark <=0.67)
            {
                conclusion.Text = "оцінка ідеї вище середнього";
            }
            else if (mark >0.36 && mark <= 0.47)
            {
                conclusion.Text = "оцінка ідеї середня";
            }
            else if (mark > 0.21 && mark <= 0.36)
            {
                conclusion.Text = "оцінка ідеї низька";
            }
            else if (mark >= 0 && mark <= 0.21)
            {
                conclusion.Text = "оцінка ідеї дуже низька";
            }
            else conclusion.Text = "це точно стартап?";


            group_one_amountForm.Text = group_one_amount.ToString();
            group_two_amountForm.Text = group_two_amount.ToString();
            group_three_amountForm.Text = group_three_amount.ToString();
            group_four_amountForm.Text = group_four_amount.ToString();
            group_five_amountForm.Text = group_five_amount.ToString();
        }
    }
}
