using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Windows.Forms;

namespace Решение_СЛАУ_методом_итераций
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //создать текстовый файл для ведения лог журнала
        private static readonly string logFilePath = "log.txt";

        //список уравнений системы
        private readonly List<Equation> equations_list = new List<Equation>();

        //хранит все неизвестные в строке
        private string variables = "";


        //решить введенную СЛАУ
        private void ButtonSolve_Click(object sender, EventArgs e)
        {
            try
            {
                equations_list.Clear();
                answer.Text = String.Empty;
                solution.Text = String.Empty;
                int acc = 0;

                if (accuracy.Text != "")
                {
                    acc = Int16.Parse(accuracy.Text);
                    if (acc < 0 || acc > 10) throw new ArgumentException("The calculation accuracy is incorrect");
                }
                else
                    throw new ArgumentException("Specify the accuracy of the calculations");

                MakeSystem();

                bool correct = true;
                for (int i = 0; i < equations_list.Count; i++)
                    correct = correct && equations_list[i].Check();

                if (correct)
                {
                    List<Iteration> iterations = SolveSystem(acc);

                    for (int i = 0; i < variables.Length; i++)
                        answer.Text += variables[i] + " = " + Math.Round(iterations[iterations.Count - 1].unknown[i], acc) + "\n";

                    for (int i = 0; i < iterations.Count; i++)
                        solution.Text += OutputSolution(iterations[i], i);
                }
                else
                {
                    throw new ArgumentException("The solution method is not suitable for this system of equations");
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //добавляет текстовое уравнение в список
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (equation.Text != "" && Correct(equation.Text.Replace(" ", "")))
                {
                    system.Items.Add(equation.Text.Replace(" ", ""));
                    equation.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //очистить список уравнений
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            try
            {
                system.Items.Clear();
                answer.Text = string.Empty;
                solution.Text = string.Empty;
                equations_list.Clear();
                variables = string.Empty;
            }
            catch (Exception ex)
            {
                LogException(ex);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //удалить выделенное уравнение
        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (system.SelectedIndex == -1) throw new ArgumentException("Select the equation you want to delete");
                system.Items.RemoveAt(system.SelectedIndex);
                answer.Text = string.Empty;
                solution.Text = string.Empty;
                equations_list.Clear();
                variables = string.Empty;
            }
            catch (Exception ex)
            {
                LogException(ex);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //проверка корректности введенного уравнения
        private bool Correct(string text)
        {
            try
            {
                bool zpt = true;
                int equal_ind = text.IndexOf("="); 
                if (equal_ind == -1) throw new ArgumentException("The equation is entered incorrectly\nThe equal sign '=' is not found");
                else 
                {
                    for (int i = 0; i < equal_ind; i++)
                    {
                        if (Char.IsLetter(text[i]))
                        {
                            if (Char.IsLetter(text[i + 1]) || text[i + 1] == ',') throw new ArgumentException("The equation is entered incorrectly\nA combination of characters is not allowed:" + text[i] + "" + text[i + 1]);
                            if (i != 0 && (Char.IsLetter(text[i - 1]) || text[i - 1] == ',')) throw new ArgumentException("The equation is entered incorrectly\nA combination of characters is not allowed:" + text[i - 1] + "" + text[i]);
                        }
                        else if (Char.IsDigit(text[i]))
                        {
                            if (i != 0 && Char.IsLetter(text[i -1])) throw new ArgumentException("The equation is entered incorrectly\nThe equation is not given a general form");
                        }
                        else if (text[i] == '-' || text[i] == '+')
                        {
                            if (i != 0 && !Char.IsLetter(text[i - 1])) throw new ArgumentException("The equation is entered incorrectly");
                            if (!Char.IsLetter(text[i + 1]) && !Char.IsDigit(text[i + 1])) throw new ArgumentException("The equation is entered incorrectly\nA combination of characters is not allowed:" + text[i] + "" + text[i + 1]);
                            zpt = true;
                        }
                        else if (text[i] == ',')
                        {
                            if (!zpt || i == 0 || !Char.IsDigit(text[i + 1]) || !Char.IsDigit(text[i - 1])) throw new ArgumentException("The equation is entered incorrectly\nThe symol ',' can only be used in non-integer coefficient");
                            zpt = false;
                        }
                    }
                    zpt = true;
                    for (int i = equal_ind + 1; i < text.Length; i++)
                    {
                        if (Char.IsDigit(text[i]) || text[i] == '-' || text[i] == ',')
                        {
                            if (text[i] == '-' && i != equal_ind + 1) throw new ArgumentException("The equation is entered incorrectly\nThe equation is not given a general form");
                            if (text[i] == ',' && (i == equal_ind + 1 || i == text.Length - 1 || !zpt || (!Char.IsDigit(text[i - 1]) || !Char.IsDigit(text[i + 1]))))
                            {
                                zpt = false;
                                throw new ArgumentException("The equation is entered incorrectly\nThe symol ',' can only be used in non-integer coefficient");
                            }
                        }
                        else throw new ArgumentException("The equation is entered incorrectly\nThe expression '" + text.Substring(equal_ind + 1) + "' is not a number");
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        
        //заполняет список объектов класса Уравнение
        private void MakeSystem()
        {
            Variable();

            for (int i = 0; i < system.Items.Count; i++)
            {
                Equation new_equation = new Equation
                {
                    coef = ArrayCoefficients(system.Items[i].ToString()),
                    a_ii = i
                };
                new_equation.b = new_equation.coef[variables.Length];
                new_equation.NullIter();

                equations_list.Add(new_equation);
            }
            Permutations();

            for (int i = 0; i < system.Items.Count; i++) equations_list[i].NullIter();
        }

        //подготавливает систему уравнений к применению метода
        public void Permutations()
        {
            List<Equation> equations = equations_list;

            try
            {            
                int[] numbers = new int[equations_list.Count];
                for (int i = 0; i < equations_list.Count; i++)
                {
                    int a_ii = Position(equations_list[i]);
                    numbers[i] = a_ii;
                    equations_list[i].a_ii = a_ii;
                    for (int j = 0; j < i; j++)
                        if (a_ii == numbers[j])
                            throw new ArgumentException("The solution method is not suitable for this system of equations");
                }
                for (int i = 0; i < equations_list.Count; i++)
                {
                    Equation count = equations_list[i];
                    equations_list[i] = equations_list[equations_list[i].a_ii];
                    equations_list[count.a_ii] = count;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //определяет индекс уравнения в системе
        public int Position(Equation equation)
        {
            int count = equation.a_ii;

            for(int j = 0; j < variables.Length; j++)
            {
                equation.a_ii = j;
                if (equation.Check()) return j;
            }
            equation.a_ii = count;
            return 0;
        }

        //создает строку для вывода итерации
        private String OutputSolution(Iteration iteration, int iter_num)
        {
            String output = "Iteration №" + iter_num + "\n\n";
            for (int i = 0; i < variables.Length; i++)
            {
                output += variables[i] + "" + iter_num + " = " + Math.Round(iteration.unknown[i], 2) + "\n";
            }
            for (int i = 0; i < variables.Length; i++)
            {
                output += "e_" + variables[i] + iter_num + " = " + Math.Round(iteration.inaccuracy[i], 2) + "\n";
            }
            return output + "\n\n";
        }

        //возвращает список итераций 
        private List<Iteration> SolveSystem(int acc)
        {
            List<Iteration> iterations = new List<Iteration>();

            try
            {
                if (variables.Length != equations_list.Count)
                {
                    throw new ArgumentException("The system is not solved unambiguously");
                }
                else 
                {
                    Iteration iteration_0 = new Iteration();
                    double[] unknown_0 = new double[variables.Length];

                    for (int i = 0;i < variables.Length; i++)
                    {
                        unknown_0[i] = equations_list[i].x_0;
                    }
                    iteration_0.unknown = unknown_0;
                    iteration_0.inaccuracy = new double[variables.Length];
                    iterations.Add(iteration_0);
                    bool end;
                    do
                    {
                        Iteration iteration = new Iteration();
                        double[] unknown = new double[variables.Length];
                    
                        for (int i = 0; i < variables.Length; i++)
                        {
                            unknown[i] = equations_list[i].Iter(iterations[iterations.Count - 1].unknown);
                        }

                        iteration.unknown = unknown;
                        iteration.inaccuracy = iteration.Epsilon(iterations[iterations.Count - 1].unknown);
                        iterations.Add(iteration);
                        end = !iteration.IsEnd(Math.Pow(0.1,acc));
                    }
                    while (end);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return iterations;
        }

        //возвращает массив коэффициентов уравнения, заданного в виде строки 
        private double[] ArrayCoefficients(String srt_equation)
        {
            double[] coefficients = new double[variables.Length + 1];
            string count = "";

            for (int i = 0; i < srt_equation.Length; i++)
            {
                if (srt_equation[i] == '=')
                {
                    double b = ToDoubleCoef(srt_equation.Substring(i + 1));
                    coefficients[variables.Length] = b;
                }
                if (IsCoefficient(srt_equation[i]) == -1)
                    count += srt_equation[i];
                else
                {
                    coefficients[IsCoefficient(srt_equation[i])] += ToDoubleCoef(count);
                    count = "";
                }
            }
            return coefficients;
        }
       
        //конвертирует коэффициент, заданный в виде строки, в переменную типа double
        private double ToDoubleCoef(String str_coef)
        {
            int int_coef = 1;
            double double_coef = 1;

            if (str_coef == "")
            {
                return 1;
            }
            else if (str_coef == "-") return -1;
            else if (str_coef == "+") return 1;
            else
            {
                if (str_coef[0] == '-')
                {
                    if (str_coef.Length > 1)
                    {
                        if (double.TryParse(str_coef.Substring(1), out double_coef)) ;
                        else if (int.TryParse(str_coef.Substring(1), out int_coef)) double_coef = int_coef;
                        double_coef *= -1;
                    }
                    else return -1;
                }
                else if (str_coef[0] == '+')
                {
                    if (double.TryParse(str_coef.Substring(1), out double_coef)) ;
                    else if (int.TryParse(str_coef.Substring(1), out int_coef)) double_coef = int_coef;
                }
                else
                {
                    if (double.TryParse(str_coef, out double_coef)) ;
                    else if (int.TryParse(str_coef, out int_coef)) double_coef = int_coef;
                }
                return double_coef;
            }
        }
        
        //находит номер переменной, к которой относится коэффициент, и проверяет, является ли переменная новой
        private int IsCoefficient(char symb)
        {
            for (int i = 0; i < variables.Length; i++)
                if (symb == variables[i]) return i;
            return -1;
        }

        //определяет все встречающиетя в системе неизвестные
        private void Variable()
        {
            for (int i = 0; i < system.Items.Count; i++)
            {
                string equation_i = system.Items[i].ToString();
                for (int j = 1; j < equation_i.Length - 1; j++)
                {
                    if (Char.IsLetter(equation_i[j]) && !Char.IsLetter(equation_i[j - 1]) && !Char.IsLetter(equation_i[j + 1]))
                        variables += equation_i[j].ToString();
                }
            }

            string str = "";
            bool b = true;
            for (int i = 0; i < variables.Length; i++)
            {
                for (int j = 0; j < str.Length; j++)
                {
                    if (variables[i] != str[j])
                        b = true;
                    else
                    {
                        b = false;
                        break;
                    }
                }
                if (b)
                    str += variables[i];
            }
            variables = str;
        }


        //создает записи в лог журнал
        private void LogException(Exception ex)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine("\n----------------------------------------------------------------------\n");
                writer.WriteLine($"Дата и время: {DateTime.Now}");
                writer.WriteLine($"Исключение: {ex.GetType().FullName}");
                writer.WriteLine($"Сообщение: {ex.Message}");
                writer.WriteLine($"Метод: {ex.TargetSite}");
                writer.WriteLine($"Стек вызовов:");
                writer.WriteLine(ex.StackTrace);
            }
        }
    }
    public class Equation
    {
        public double[] coef;
        public double b;
        public int a_ii;
        public double x_0;

        //проверка применимости итерационного метода
        public bool Check()
        {
            double sum_coef = 0;
            for (int i = 0; i < coef.Length - 1; i++)
                if (a_ii != i)
                    sum_coef += Math.Abs(coef[i]);
            if(Math.Abs(coef[a_ii]) > sum_coef)
                return true;
            else return false;
        }

        //подсчет нулевой итерации
        public void NullIter()
        {
            x_0 = b/coef[a_ii];
        }

        //подсчет ненулевой итерации
        public double Iter(double[] x)
        {
            double x_i = b;
            for (int i = 0; i < x.Length; i++)
            {
                if (i != a_ii) x_i -= x[i] * coef[i];
            }
            return x_i / coef[a_ii];
        }
    }

    public class Iteration
    {
        public double[] unknown;
        public double[] inaccuracy;

        //подсчет погрешности
        public double[] Epsilon(double[] x)
        {
            double[] e = new double[x.Length];
            for (int i = 0; i < x.Length; i++)
                e[i] = Math.Abs(unknown[i] - x[i]) / Math.Abs(unknown[i]);
            return e;
        }

        //проверка, является ли итерация последней
        public bool IsEnd(double etalon)
        {
            bool end = true;
            for (int i = 0; i < inaccuracy.Length; i++)
                end = end && (inaccuracy[i] < etalon);
            return end;
        }
    }
}
