using System;
using System.Threading;

namespace Rgr_v2
{
    class Program
    {
        static bool IsNumber(string str, ref int index)//-435432.234
        {
            byte count = 0;
            if (str.Length == 0) return false;
            if (str.IndexOf('-') == 0) index++;
            while (str.Length > index)
            {
                if (str[index] == '.' || str[index] == ',')
                {
                    count++;
                    if (count > 1) return false;
                    index++;
                    continue;
                }
                if (Char.IsDigit(str[index]) == false) return false;
                index++;
            }
            return true;
        }
        static void typr(char number, ref double minvalue, ref double maxvalue, ref byte byyte)
        {
            if (number == '1')//float - 1
            {
                minvalue = float.MinValue;
                maxvalue = float.MaxValue;
                byyte = 4;
            }
            else //double - 2
            {
                minvalue = double.MinValue;
                maxvalue = double.MaxValue;
                byyte = 8;
            }
            Console.WriteLine("||========================================================================||");
            Console.WriteLine("||                                    |                                   ||");
            Console.WriteLine("||" + "      Длина(байт)" + "                   " + "=" + "\t\t\t" + byyte + "\t\t  ||");
            Console.WriteLine("||" + "      Диапазон значений" + "             " + "=" + "\t  " + "От " + minvalue + "\t  ||");
            Console.WriteLine("||\t\t\t\t      =   До  "+ maxvalue + "\t  ||");
            Console.WriteLine("||                                    |                                   ||");
            Console.WriteLine("||========================================================================||\n\n");
        }
        static void ChangeSep(ref string number)//345,45
                                                //45
        {
            if (number.IndexOf('.') != -1)
            {
                string[] StrArr = number.Split('.');
                string sep = ",";
                number = StrArr[0] + sep + StrArr[1];
            }
        }
        static void Main(string[] args)
        {
            string str = "single real double";
            string[] ss = str.Split(' ');
            double minvalue = 0;
            double maxvalue = 0;
            byte byyte = 0;
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Раздел №3 «Внутренние форматы данных»\nТипы Object Pascal с плавующей точкой");
                Console.WriteLine("Текст задания:");
                Console.WriteLine("Спроектируйте и реализуйте приложение, выполняющее вывод на экран\nвнутреннего побитового представления заданных типов данных\n");
                Console.WriteLine();
                Console.WriteLine("Типы Object Pascal с плавующей точкой:");
                Console.WriteLine();
                Console.WriteLine("||================================================================||");
                Console.WriteLine("||" + '1' + " - - - - - - - - - - - - - " + "sinlge" + " - - - - - - - - - - - - - - -" + "||");
                Thread.Sleep(100);
                Console.WriteLine("||" + '2' + " - - - - - - - - - - - - - " + "real" + " - - - - - - - - - - - - - - - -" + "||");
                Thread.Sleep(100);
                Console.WriteLine("||" + '3' + " - - - - - - - - - - - - - " + "double" + " - - - - - - - - - - - - - - -" + "||");
                Console.WriteLine("||================================================================||\n\n");
                Thread.Sleep(200);
                Console.WriteLine("||================================================================||");
                Console.Write("||    Выберете номер типа, который вы хотите использовать:  ");
                char NumberOfType;
                while (true)
                {
                    string symvol = Console.ReadLine();
                    Console.WriteLine("||================================================================||\n\n");
                    Thread.Sleep(200);
                    if (char.TryParse(symvol, out NumberOfType) == false)
                    {
                        Console.WriteLine("||================================================================||");
                        Console.Write("||                   Ошибка, введите номер еще раз:  ");
                        continue;
                    }

                    if (NumberOfType >= '1' && NumberOfType <= '3')
                    {
                        Console.WriteLine("||========================================================================||");
                        Console.Write("||\t\tВыбран тип: {0}. Информация о типе {0}", ss[NumberOfType - '1']);
                        Console.WriteLine("\t\t  ||");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("||================================================================||");
                        Console.Write("||                   Ошибка, введите номер еще:  ");
                    }
                }
                Thread.Sleep(100);
                typr(NumberOfType, ref minvalue, ref maxvalue, ref byyte);
                Thread.Sleep(100);
                Console.WriteLine("||================================================================||");
                Console.Write("||    Введите значение попадающее в данный диапазон:  ");
                double userinput;
                string userinputv1;
                while (true)
                {
                    while (true)
                    {
                        int index = 0;
                        userinputv1 = Console.ReadLine();
                        Console.WriteLine("||================================================================||\n\n");
                        Thread.Sleep(100);
                        if (IsNumber(userinputv1, ref index) == true)
                        {
                            ChangeSep(ref userinputv1);
                            try
                            {
                                userinput = double.Parse(userinputv1);
                            }
                            catch (Exception)
                            {
                                Console.Write("Что-то пошло не так, попробуйте еще:   ");
                                continue;
                            }
                            break;
                        }
                        Console.WriteLine("||================================================================||");
                        Console.Write("\tЭто не число, ошибка в {0} символе, попробуйте еще раз: ", index + 1);
                    }
                    if (userinput > maxvalue)
                    {
                        Console.WriteLine("||================================================================||");
                        Console.Write("Число больше допустимого значения,попробуйте еще раз: ");
                        continue;
                    }
                    else if (userinput < minvalue)
                    {
                        Console.WriteLine("||================================================================||");
                        Console.Write("Число меньше допустимого значения,попробуйте еще раз: ");
                        continue;
                    }
                    break;
                }

                string[] number = userinputv1.Split(',');
                string znak;
                string strceloe;
                double celoe;
                if (userinput >= 0)
                {
                    celoe = double.Parse(number[0]);
                    strceloe = Convert.ToString((int)celoe, 2);//перевод целой части
                    znak = "0";
                }else {
                    celoe = double.Parse(number[0].Substring(1,number[0].Length-1));
                    strceloe = Convert.ToString((int)celoe, 2);//перевод целой части
                    znak = "1";
                }
                double ostatoc = Math.Abs(userinput) - celoe;//|333,333| - 333 = 0,333
                string strost = "";
                while (strost.Length < 15 && ostatoc != 0)//перевод вещественной части
                {
                    ostatoc *= 2;
                    if (ostatoc >= 1)// 0
                    {
                        strost += "1";
                        
                        ostatoc -= 1;
                    }
                    else strost += "0";
                }
                int k = strceloe.Length - 1;//  -11111
                                            //  012345 6

                int e;
                if (byyte == 4) e = 127 + k;
                else e = 1023 + k;
                string stre = Convert.ToString(e, 2);
                string m = strceloe.Substring(1, strceloe.Length - 1) + strost;
                string InternalFormat = znak + " " + stre + " " + m;
                string FullInternalFormat = InternalFormat.PadRight((byyte * 8) + 2, '0');
                Console.WriteLine("||========================================================================||");
                Console.WriteLine("||Число {0,10} во внутреннем формате, выглядит так:\t\t\t  ||\n||{1,72}||", userinput, FullInternalFormat);
                Console.WriteLine("||========================================================================||");
                Thread.Sleep(1000);
                Console.WriteLine("\n\n");
                Console.Write("Чтобы повторить, нажмите любую клавишу:   ");
                Console.ReadKey(true);
            }
        }
        
    }
}

