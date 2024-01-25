using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        Dictionary<double, List<Values>> linguisticValues = new Dictionary<double, List<Values>>();
        List<Key> keys = new List<Key>
        {
            new Key {NumberGroup=1, Iterator = 3 },
            new Key {NumberGroup=2, Iterator = 3 },
            new Key {NumberGroup=3, Iterator = 5 },
            new Key {NumberGroup=4, Iterator = 4 },
            new Key {NumberGroup=5, Iterator = 3 },
        };
        List<double> tmpRes = new List<double>();
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
                group_three_function_membership = 2 * Math.Pow((group_three_max - group_three_amount) / (group_three_max - group_three_min), 2);
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
                group_four_function_membership = 2 * Math.Pow((group_four_max - group_four_amount) / (group_four_max - group_four_min), 2);
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
            linguisticValues.Clear();
            getLinguisticValues(1, group_one_function_membership, group_one_function_desired_membership);
            getLinguisticValues(2, group_two_function_membership, group_two_function_desired_membership);
            getLinguisticValues(3, group_three_function_membership, group_three_function_desired_membership);
            getLinguisticValues(4, group_four_function_membership, group_four_function_desired_membership);
            getLinguisticValues(5, group_five_function_membership, group_five_function_desired_membership);



            foreach (var item in linguisticValues)
            {
                List<Values> lingValue = item.Value;
                double a = 0, b = 0;

                for (int i = 0; i < lingValue.Count; i++)
                {
                    double keyA = 0, keyB = 0;
                    if (keys.Any(key => key.NumberGroup == item.Key && key.Iterator == lingValue[i].NumberFormula))
                    {
                        keyA = lingValue[i].Res;
                    }
                    else
                    {
                        keyA = 0;
                    }
                    if ((lingValue[i].NumberFormula == keys[i].Iterator + 1 && keys[Convert.ToInt32(lingValue[i].NumberGroup - 1)].NumberGroup == lingValue[i].NumberGroup) ||
                        (lingValue[i].NumberFormula == keys[i].Iterator - 1 && keys[Convert.ToInt32(lingValue[i].NumberGroup - 1)].NumberGroup == lingValue[i].NumberGroup))
                    {
                        keyB = lingValue[i].Res / 2;
                    }
                    else
                    {
                        keyB = 0;
                    }

                    if (a == 0)
                    {
                        a = Math.Max(keyA, keyB);
                    }
                    else
                    {
                        b = Math.Max(keyA, keyB);
                    }
                }
                tmpRes.Add(Math.Max(a, b));

            }


            double group_one_linguistic_variable = tmpRes[0];
            double group_two_linguistic_variable = tmpRes[1];
            double group_three_linguistic_variable = tmpRes[2];
            double group_four_linguistic_variable = tmpRes[3];
            double group_five_linguistic_variable = tmpRes[4];







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


            double a1 = group_one_linguistic_variable * group_one_normalized_weight;
            double a2 = group_two_linguistic_variable * group_two_normalized_weight;
            double a3 = group_three_linguistic_variable * group_three_normalized_weight;
            double a4 = group_four_linguistic_variable * group_four_normalized_weight;
            double a5 = group_five_linguistic_variable * group_five_normalized_weight;
            double mark = a1 + a2 + a3 + a4 + a5;

            //Вивід даних
            markForm.Text = Math.Round(mark, 3).ToString();
            if (mark > 0.67)
            {
                conclusion.Text = "оцінка ідеї висока";
            }
            else if (mark > 0.47 && mark <= 0.67)
            {
                conclusion.Text = "оцінка ідеї вище середнього";
            }
            else if (mark > 0.36 && mark <= 0.47)
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
        public void getLinguisticValues(int index, double x, double a)
        {
            List<Values> tmp = new List<Values>();
            for (int i = 0; i < 5; i++)
            {
                double u = getMU(i, x, a);

                if (u != 0)
                {
                    u = Math.Round(u, 2);
                    tmp.Add(new Values { NumberFormula = i, Res = u , NumberGroup = index});
                    //gLinguistic.push( key: `U_${ i + 1} _${ j}`, value: parseFloat(u));
                }
            }
            linguisticValues.Add(index, tmp);
        }

        public double getMU(int index, double x, double a)
        {
            switch (index)
            {
                case 1:
                    return mu1(x, a);
                case 2:
                    return mu2(x, a);
                case 3:
                    return mu3(x, a);
                case 4:
                    return mu4(x, a);
                case 5:
                    return mu5(x, a);
            }
            return 0;
        }

        public double mu1(double x, double a)
        {
            if (x <= (a - a / 2))
            {
                return 1;
            }
            else if ((a - a / 2) < x && x <= (a - a / 4))
            {
                return (3 * a - 4 * x) / a;
            }
            else { return 0; }
        }

        public double mu2(double x, double a)
        {
            if ((a - a / 2) < x && x <= (a - a / 4))
            {
                return (4 * x - 2 * a) / a;
            }
            else if (a - a / 4 < x && x <= a)
            {
                return (4 * a - 4 * x) / a;
            }
            else { return 0; }
        }

        public double mu3(double x, double a)
        {
            if (a - a / 4 < x && x <= a)
            {
                return (4 * x - 3 * a) / a;
            }
            else if (a < x && x <= a + a / 4)
            {
                return (5 * a - 4 * x) / a;
            }
            else { return 0; }
        }

        public double mu4(double x, double a)
        {
            if (a < x && x <= a + a / 4)
            {
                return (4 * x - 4 * a) / a;
            }
            else if (a + a / 4 < x && x <= a + a / 2)
            {
                return (6 * a - 4 * x) / a;
            }
            else { return 0; }
        }

        public double mu5(double x, double a)
        {
            if (a + a / 4 < x && x <= a + a / 2)
            {
                return (4 * x - 5 * a) / a;
            }
            else if (x >= a + a / 2)
            {
                return 1;
            }
            else { return 0; }
        }
        public class Key
        {
            public double NumberGroup { get; set; }
            public double Iterator { get; set; }
        }
        public class Values
        {
            public double NumberGroup { get; set; }
            public double NumberFormula { get; set; }
            public double Res { get; set; }
        }
    }
}

