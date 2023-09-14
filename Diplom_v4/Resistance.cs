using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diplom_v4
{
    public class Resistance
    {
        public class Platinum_pt // платиновый Pt
        {
            public static int MinTemp, MaxTemp;
            public static double MinRes, MaxRes;
            static double R;
            static double T;
            public static double dr_dt, Dt_abs, Dr_abs, gt, gr;
            static double A = 3.9083 * Math.Pow(10, -3);
            static double B = -5.775 * Math.Pow(10, -7);
            static double C = -4.183 * Math.Pow(10, -12);
            static double[] D = { 255.819, 9.1455, -2.92363, 1.7909 };

            public static void GetRange(int index)
            {
                // класы точности AA A B C

                switch (index)
                {
                    case 0: // AA
                            // по цельсию 
                        MinTemp = -50;
                        MaxTemp = 250;
                        // ом
                        MinRes = 80.31;
                        MaxRes = 194.1;
                        break;

                    case 1: // A
                            // по цельсию 
                        MinTemp = -100;
                        MaxTemp = 450;
                        // ом
                        MinRes = 60.26;
                        MaxRes = 264.18;
                        break;

                    case 2: // B
                            // по цельсию 
                        MinTemp = -196;
                        MaxTemp = 660;
                        // ом
                        MinRes = 20.246;
                        MaxRes = 332.79;
                        break;

                    case 3: // C
                            // по цельсию 
                        MinTemp = -196;
                        MaxTemp = 660;
                        // ом
                        MinRes = 20.246;
                        MaxRes = 332.79;
                        break;
                }
            }

            public static double Forward(double T, double R0)
            {
                if (T < 0) 
                {
                    R = R0 * (1 + A*T + B * Math.Pow(T, 2) + C*(T-100) * Math.Pow(T, 3));
                } 
                else
                {
                    R = R0 * (1 + A*T + B * Math.Pow(T, 2));
                }

                return R;
            }

            public static double Reverse(double R, double R0)
            {
                if (R / R0 < 1)
                {
                    for (int i = 0; i < D.Length; i++)
                    {
                        T += D[i] * Math.Pow( (R / R0 - 1), (i + 1));
                    }
                }
                else
                {
                    T = (Math.Sqrt(Math.Pow(A, 2) - 4*B*(1 - (R/R0))) - A) / (2*B);
                }

                return T;
            }

            public static void GetLimits(double T, double R0, int index)
            {
                // частная производная в точке
                dr_dt = (Forward(T + 0.1, R0) - Forward(T, R0)) / (0.1);

                // пределы допустимых погрешностей
                // приведённые ко входу
                switch (index)
                {
                    case 0: // класс допуска АA
                        Dt_abs = (0.1 + 0.0017 * Math.Abs(T));
                        break;
                    case 1: // класс допуска А
                        Dt_abs = (0.15 + 0.002 * Math.Abs(T));
                        break;
                    case 2: // класс допуска B
                        Dt_abs = (0.3 + 0.005 * Math.Abs(T));
                        break;
                    default: // класс допуска С
                        Dt_abs = (0.6 + 0.01 * Math.Abs(T));
                        break;
                }

                gt = Dt_abs / (MaxTemp - MinTemp) * 100;

                // пределы допустимых погрешностей
                // приведённые к выходу
                Dr_abs = Dt_abs * dr_dt;
                gr = Dr_abs / (MaxRes - MinRes) * 100;
            }
        }

        public class Platinum_p // платиновый П
        {
            public static int MinTemp, MaxTemp;
            public static double MinRes, MaxRes;
            static double R;
            static double T;
            public static double dr_dt, Dt_abs, Dr_abs, gt, gr;
            static double A = 3.969 * Math.Pow(10, -3);
            static double B = -5.841 * Math.Pow(10, -7);
            static double C = -4.33 * Math.Pow(10, -12);
            static double[] D = { 251.903, 8.80035, -2.91506, 1.67611 };

            public static void GetRange(int index)
            {
                // класы точности AA A B C

                switch (index)
                {
                    case 0: // AA
                            // по цельсию 
                        MinTemp = -50;
                        MaxTemp = 250;
                        // ом
                        MinRes = 80;
                        MaxRes = 195.57;
                        break;

                    case 1: // A
                            // по цельсию 
                        MinTemp = -100;
                        MaxTemp = 450;
                        // ом
                        MinRes = 59.64;
                        MaxRes = 266.78;
                        break;

                    case 2: // B
                            // по цельсию 
                        MinTemp = -196;
                        MaxTemp = 660;
                        // ом
                        MinRes = 18.832;
                        MaxRes = 336.51;
                        break;

                    case 3: // C
                            // по цельсию 
                        MinTemp = -196;
                        MaxTemp = 660;
                        // ом
                        MinRes = 18.832;
                        MaxRes = 336.51;
                        break;
                }
            }

            public static double Forward(double T, double R0)
            {
                if (T < 0)
                {
                    R = R0 * (1 + A*T + B * Math.Pow(T, 2) + C * (T - 100) * Math.Pow(T, 3));
                }
                else
                {
                    R = R0 * (1 + A*T + B * Math.Pow(T, 2));
                }

                return R;
            }

            public static double Reverse(double R, double R0)
            {
                if (R / R0 < 1)
                {
                    for (int i = 0; i < D.Length; i++)
                    {
                        T += D[i] * Math.Pow((R / R0 - 1), (i + 1));
                    }
                }
                else
                {
                    T = (Math.Sqrt(Math.Pow(A, 2) - 4 * B * (1 - (R / R0))) - A) / (2 * B);
                }

                return T;
            }

            public static void GetLimits(double T, double R0, int index)
            {
                // частная производная в точке
                dr_dt = (Forward(T + 0.1, R0) - Forward(T, R0)) / (0.1);

                // пределы допустимых погрешностей
                // приведённые ко входу
                switch (index)
                {
                    case 0: // класс допуска АA
                        Dt_abs = (0.1 + 0.0017 * Math.Abs(T));
                        break;
                    case 1: // класс допуска А
                        Dt_abs = (0.15 + 0.002 * Math.Abs(T));
                        break;
                    case 2: // класс допуска B
                        Dt_abs = (0.3 + 0.005 * Math.Abs(T));
                        break;
                    default: // класс допуска С
                        Dt_abs = (0.6 + 0.01 * Math.Abs(T));
                        break;
                }


                gt = Dt_abs / (MaxTemp - MinTemp) * 100;

                // пределы допустимых погрешностей
                // приведённые к выходу
                Dr_abs = Dt_abs * dr_dt;

                gr = Dr_abs / (MaxRes - MinRes) * 100;
            }
        }

        public class Copper // медный М
        {
            public static int MinTemp, MaxTemp;
            public static double MinRes, MaxRes;
            static double R;
            static double T;
            public static double dr_dt, Dt_abs, Dr_abs, gt, gr;
            static double A = 4.28 * Math.Pow(10, -3);
            static double B = -6.2032 * Math.Pow(10, -7);
            static double C = 8.5154 * Math.Pow(10, -10);
            static double[] D = { 233.87, 7.937, -2.0062, -0.3953 };

            public static void GetRange(int index)
            {
                // класы точности A B C

                switch (index)
                {
                    case 0: // A
                            // по цельсию 
                        MinTemp = -50;
                        MaxTemp = 120;
                        // ом
                        MinRes = 78.46;
                        MaxRes = 151.36;
                        break;

                    case 1: // B
                            // по цельсию 
                        MinTemp = -50;
                        MaxTemp = 200;
                        // ом
                        MinRes = 78.46;
                        MaxRes = 185.6;
                        break;

                    case 2: // C
                            // по цельсию 
                        MinTemp = -180;
                        MaxTemp = 200;
                        // ом
                        MinRes = 20.53;
                        MaxRes = 185.6;
                        break;
                }
            }

            public static double Forward(double T, double R0)
            {
                if (T < 0)
                {
                    R = R0 * (1 + A*T + B*T*(T+6.7) + C* Math.Pow(T, 3));
                }
                else
                {
                    R = R0 * (1 + A*T);
                }

                return R;
            }

            public static double Reverse(double R, double R0)
            {
                if (R / R0 < 1)
                {
                    for (int i = 0; i < D.Length; i++)
                    {
                        T += D[i] * Math.Pow((R / R0 - 1), (i + 1));
                    }
                }
                else
                {
                    T = (R / R0 - 1) / A;
                }

                return T;
            }

            public static void GetLimits(double T, double R0, int index)
            {
                // частная производная в точке
                dr_dt = (Forward(T + 0.1, R0) - Forward(T, R0)) / (0.1);

                // пределы допустимых погрешностей
                // приведённые ко входу
                switch (index)
                {
                    case 0: // класс допуска А
                        Dt_abs = (0.15 + 0.002 * Math.Abs(T));
                        break;
                    case 1: // класс допуска B
                        Dt_abs = (0.3 + 0.005 * Math.Abs(T));
                        break;
                    default: // класс допуска С
                        Dt_abs = (0.6 + 0.01 * Math.Abs(T));
                        break;
                }


                gt = Dt_abs / (MaxTemp - MinTemp) * 100;

                // пределы допустимых погрешностей
                // приведённые к выходу
                Dr_abs = Dt_abs * dr_dt;

                gr = Dr_abs / (MaxRes - MinRes) * 100;
            }
        }

        public class Nickel // никелевый Н
        {
            public static int MinTemp, MaxTemp; // по цельсию
            public static double MinRes, MaxRes; // ом
            static double R;
            static double T;
            public static double dr_dt, Dt_abs, Dr_abs, gt, gr;
            static double A = 5.4963 * Math.Pow(10, -3);
            static double B = 6.7556 * Math.Pow(10, -6);
            static double C = 9.2004 * Math.Pow(10, -9);
            static double[] D = { 144.096, -25.502, 4.4876 };

            public static void GetRange()
            {
                // класс точности только С

                // по цельсию 
                MinTemp = -60;
                MaxTemp = 180;
                // ом
                MinRes = 69.45;
                MaxRes = 223.21;
            }

            public static double Forward(double T, double R0)
            {
                if (T < 100)
                {
                    R = R0 * (1 + A * T + B * Math.Pow(T, 2));
                }
                else
                {
                    R = R0 * (1 + A * T + B * Math.Pow(T, 2) + C * (T - 100) * Math.Pow(T, 2));
                }

                return R;
            }

            public static double Reverse(double R, double R0)
            {
                if (R / R0 < 1.6172)
                {
                    T = (Math.Sqrt(Math.Pow(A, 2) - 4 * B * (1 - (R / R0))) - A) / (2 * B);
                }
                else
                {
                    T = 100;
                    for (int i = 0; i < D.Length; i++)
                    {
                        T += D[i] * Math.Pow((R / R0 - 1.6172), (i + 1));
                    }
                }

                return T;
            }

            public static void GetLimits(double T, double R0)
            {
                // частная производная в точке
                dr_dt = (Forward(T + 0.1, R0) - Forward(T, R0)) / (0.1);

                // пределы допустимых погрешностей
                // приведённые ко входу
                Dt_abs = (0.6 + 0.01 * Math.Abs(T));

                gt = Dt_abs / (MaxTemp - MinTemp) * 100;

                // пределы допустимых погрешностей
                // приведённые к выходу
                Dr_abs = Dt_abs * dr_dt;
 
                gr = Dr_abs / (MaxRes - MinRes) * 100;
            }
        }
    }
}


