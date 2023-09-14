using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Diplom_v4
{
    public class Thermocouple
    {
        public class Type_R
        {
            public static int MinTemp, MaxTemp; // температура по цельсию
            public static double MinE, MaxE;    // ТЭДС мВ
            public static double Dt_abs, De_abs, de_dt, gt, ge;        
            static double[][] A = {

                // от - 50 ⁰С до 1064.18 ⁰С
                new double[] {
                    0,
                    5.28961729765 * Math.Pow(10, -3),
                    1.39166589782 * Math.Pow(10, -5),
                    -2.38855693017 * Math.Pow(10, -8),
                    3.56916001063 * Math.Pow(10, -11),
                    -4.62347666298 * Math.Pow(10, -14),
                    5.0077744103 * Math.Pow(10, -17),
                    -3.73105886191 * Math.Pow(10, -20),
                    1.57716482367 * Math.Pow(10, -23),
                    -2.81038625251 * Math.Pow(10, -27)
                },

                // от 1064,18°С до 1664,5°С
                new double[] {
                    2.95157925316,
                    -2.52061251332 * Math.Pow(10, -3),
                    1.59564501865 * Math.Pow(10, -5),
                    -7.64085947576 * Math.Pow(10, -9),
                    2.05305291024 * Math.Pow(10, -12),
                    -2.93359668173 * Math.Pow(10, -16)
                }
            };

            public static void GetRange()
            {
                // класы точности 1 и 2
                    // по цельсию 
                MinTemp = 0;
                MaxTemp = 1600;
                    // мВ
                MinE = 0;
                MaxE = 18.849;
            }

            public static double Forward(double T, double T0)
            {
                double E = 0; T -= T0;

                if (T <= 1064.18)
                {
                    for (int i = 0; i < A[0].Length; i++)
                    {
                        E += (A[0][i] * Math.Pow(T, (double)i));
                    }
                }
                else
                {
                    for (int i = 0; i < A[1].Length; i++)
                    {
                        E += A[1][i] * Math.Pow(T, i);
                    }
                } 
                
                return E;
            }

            public static void GetLimits(double T, double T0, int index)
            {
                // частная производная в точке
                de_dt = (Forward(T + 0.1, T0) - Forward(T, T0)) / (0.1);

                // пределы допустимых погрешностей
                // приведённые ко входу
                switch (index)
                {
                    case 0: // класс допуска 1
                        if (T <= 1100) Dt_abs = 1;
                        else Dt_abs = (1 + 0.003 * (T - 1100));
                            break;
                    case 1: // класс допуска 2
                        if (T <= 600) Dt_abs = 1.5;
                        else Dt_abs = 0.0025 * T;
                        break;
                }

                gt = Dt_abs / (MaxTemp - MinTemp) * 100;

                // пределы допустимых погрешностей
                // приведённые к выходу
                De_abs = Dt_abs * de_dt;

                ge = De_abs / (MaxE - MinE) * 100;
            }
        }

        public class Type_S
        {
            public static int MinTemp, MaxTemp; // температура по цельсию
            public static double MinE, MaxE;    // ТЭДС мВ
            public static double Dt_abs, De_abs, de_dt, gt, ge;
            static double[][] A = {

                // от - 50 ⁰С до 1064.18 ⁰С
                new double[] {
                    0,
                    5.40313308631 * Math.Pow(10, -3),
                    1.2593428974 * Math.Pow(10, -5),
                    -2.32477968689 * Math.Pow(10, -8),
                    3.22028823036 * Math.Pow(10, -11),
                    -3.31465196389 * Math.Pow(10, -14),
                    2.55744251786 * Math.Pow(10, -17),
                    -1.25068871393 * Math.Pow(10, -20),
                    2.71443176145 * Math.Pow(10, -24)
                },

                // от 1064,18°С до 1664,5°С
                new double[] {
                    1.32900444085,
                    3.34509311344 * Math.Pow(10, -3),
                    6.54805192818 * Math.Pow(10, -6),
                    -1.64856259209 * Math.Pow(10, -9),
                    1.29989605174 * Math.Pow(10, -14)
                }
            };

            public static void GetRange()
            {
                // класы точности 1 и 2
                // по цельсию 
                MinTemp = 0;
                MaxTemp = 1600;
                // мВ
                MinE = 0;
                MaxE = 16.777;
            }

            public static double Forward(double T, double T0)
            {
                double E = 0; T -= T0;

                if (T <= 1064.18)
                {
                    for (int i = 0; i < A[0].Length; i++)
                    {
                        E += (A[0][i] * Math.Pow(T, (double)i));
                    }
                }
                else
                {
                    for (int i = 0; i < A[1].Length; i++)
                    {
                        E += A[1][i] * Math.Pow(T, i);
                    }
                }

                return E;
            }

            public static void GetLimits(double T, double T0, int index)
            {
                // частная производная в точке
                de_dt = (Forward(T + 0.1, T0) - Forward(T, T0)) / (0.1);

                // пределы допустимых погрешностей
                // приведённые ко входу
                switch (index)
                {
                    case 0: // класс допуска 1
                        if (T <= 1100) Dt_abs = 1;
                        else Dt_abs = (1 + 0.003 * (T - 1100));
                        break;
                    case 1: // класс допуска 2
                        if (T <= 600) Dt_abs = 1.5;
                        else Dt_abs = 0.0025 * T;
                        break;
                }

                gt = Dt_abs / (MaxTemp - MinTemp) * 100;

                // пределы допустимых погрешностей
                // приведённые к выходу
                De_abs = Dt_abs * de_dt;

                ge = De_abs / (MaxE - MinE) * 100;
            }
        }

        public class Type_B
        {
            public static int MinTemp, MaxTemp; // температура по цельсию
            public static double MinE, MaxE;    // ТЭДС мВ
            public static double Dt_abs, De_abs, de_dt, gt, ge;
            static double[][] A = {

                // от 0°С до 630,615°С
                new double[] {
                    0,
                    -2.4650818346 * Math.Pow(10, -4),
                    5.9040421171 * Math.Pow(10, -6),
                    -1.3257931636 * Math.Pow(10, -9),
                    1.5668291901 * Math.Pow(10, -12),
                    -1.694452924 * Math.Pow(10, -15),
                    6.2990347094 * Math.Pow(10, -19)
                },

                // от 630,615°С до 1820°С
                new double[] {
                    -3.893816862,
                    2.857174747 * Math.Pow(10, -2),
                    -8.4885104785 * Math.Pow(10, -5),
                    1.5785280164 * Math.Pow(10, -7),
                    -1.6835344864 * Math.Pow(10, -10),
                    1.1109794013 * Math.Pow(10, -13),
                    -4.4515431033 * Math.Pow(10, -17),
                    9.8975640821 * Math.Pow(10, -21),
                    -9.3791330289 * Math.Pow(10, -25),
                }
            };

            public static void GetRange()
            {
                // класы точности 2 и 3
                // по цельсию 
                MinTemp = 600;
                MaxTemp = 1800;
                // мВ
                MinE = 1.792;
                MaxE = 13.591;
            }

            public static double Forward(double T, double T0)
            {
                double E = 0; T -= T0;

                if (T <= 630.615)
                {
                    for (int i = 0; i < A[0].Length; i++)
                    {
                        E += (A[0][i] * Math.Pow(T, (double)i));
                    }
                }
                else
                {
                    for (int i = 0; i < A[1].Length; i++)
                    {
                        E += A[1][i] * Math.Pow(T, i);
                    }
                }

                return E;
            }

            public static void GetLimits(double T, double T0, int index)
            {
                // частная производная в точке
                de_dt = (Forward(T + 0.1, T0) - Forward(T, T0)) / (0.1);

                // пределы допустимых погрешностей
                // приведённые ко входу
                switch (index)
                {
                    case 0: // класс допуска 2
                        Dt_abs = 0.0025 * T;
                        break;
                    case 1: // класс допуска 3
                        if (T <= 800) Dt_abs = 4;
                        else Dt_abs = 0.005 * T;
                        break;
                }

                gt = Dt_abs / (MaxTemp - MinTemp) * 100;

                // пределы допустимых погрешностей
                // приведённые к выходу
                De_abs = Dt_abs * de_dt;

                ge = De_abs / (MaxE - MinE) * 100;
            }
        }

        public class Type_J
        {
            public static int MinTemp, MaxTemp; // температура по цельсию
            public static double MinE, MaxE;    // ТЭДС мВ
            public static double Dt_abs, De_abs, de_dt, gt, ge;
            static double[][] A = {

                // от -210°С до 760°С
                new double[] {
                    0,
                    5.0381187815 * Math.Pow(10, -2),
                    3.047583693 * Math.Pow(10, -5),
                    -8.568106572 * Math.Pow(10, -8),
                    1.3228195295 * Math.Pow(10, -10),
                    -1.7052958337 * Math.Pow(10, -13),
                    2.0948090697 * Math.Pow(10,  -16),
                    -1.2538395336 * Math.Pow(10, -19),
                    1.5631725697 * Math.Pow(10, -23),

                },

                // от 760°С до 1200°С
                new double[] {
                    2.9645625681*Math.Pow(10, 2),
                    -1.4976127786,
                    3.1787103924*Math.Pow(10, -3),
                    -3.1847686701*Math.Pow(10, -6),
                    1.5720819004*Math.Pow(10, -9),
                    -3.0691369056*Math.Pow(10, -13)
                }
            };

            public static void GetRange(int index)
            {
                switch (index)
                {
                    case 0:
                        // класc точности 1
                            // по цельсию 
                        MinTemp = -40;
                        MaxTemp = 750;
                            // мВ
                        MinE = -1.961;
                        MaxE = 42.281;
                        break;
                    case 1:
                        // класc точности 2
                            // по цельсию 
                        MinTemp = 0;
                        MaxTemp = 900;
                            // мВ
                        MinE = 0;
                        MaxE = 51.877;
                        break;
                }
            }

            public static double Forward(double T, double T0)
            {
                double E = 0; T -= T0;

                if (T <= 760)
                {
                    for (int i = 0; i < A[0].Length; i++)
                    {
                        E += (A[0][i] * Math.Pow(T, (double)i));
                    }
                }
                else
                {
                    for (int i = 0; i < A[1].Length; i++)
                    {
                        E += A[1][i] * Math.Pow(T, i);
                    }
                }

                return E;
            }

            public static void GetLimits(double T, double T0, int index)
            {
                // частная производная в точке
                de_dt = (Forward(T + 0.1, T0) - Forward(T, T0)) / (0.1);

                // пределы допустимых погрешностей
                // приведённые ко входу
                switch (index)
                {
                    case 0: // класс допуска 1
                        if (T <= 375) Dt_abs = 1.5;
                        else Dt_abs = 0.004 * Math.Abs(T);
                        break;
                    case 1: // класс допуска 2
                        if (T <= 333) Dt_abs = 2.5;
                        else Dt_abs = 0.0075 * T;
                        break;
                }

                gt = Dt_abs / (MaxTemp - MinTemp) * 100;

                // пределы допустимых погрешностей
                // приведённые к выходу
                De_abs = Dt_abs * de_dt;

                ge = De_abs / (MaxE - MinE) * 100;
            }
        }
       
        public class Type_T
        {
            public static int MinTemp, MaxTemp; // температура по цельсию
            public static double MinE, MaxE;    // ТЭДС мВ
            public static double Dt_abs, De_abs, de_dt, gt, ge;
            static double[][] A = {

                // от -210°С до 0°С
                new double[] {
                    0,
                    3.8748106364* Math.Pow(10, -2),
                    4.4194434347* Math.Pow(10, -5),
                    1.1844323105* Math.Pow(10, -7),
                    2.0032973554* Math.Pow(10, -8),
                    9.0138019559* Math.Pow(10, -10),
                    2.2651156593* Math.Pow(10, -11),
                    3.6071154205* Math.Pow(10, -13),
                    3.8493939883* Math.Pow(10, -15),
                    2.8213521925* Math.Pow(10, -17),
                    1.4251594779* Math.Pow(10, -19),
                    4.8768662286* Math.Pow(10, -22),
                    1.079553927* Math.Pow(10, -24),
                    1.3945027062* Math.Pow(10, -27),
                    7.9795153927* Math.Pow(10, -31)
                },

                // от 0°С до 400°С
                new double[] {
                    0,
                    3.8748106364* Math.Pow(10, -2),
                    3.329222788* Math.Pow(10, -5),
                    2.0618243404* Math.Pow(10, -7),
                    -2.1882256846* Math.Pow(10, -9),
                    1.0996880928* Math.Pow(10, -11),
                    -3.0815758772* Math.Pow(10, -14),
                    4.547913529* Math.Pow(10, -17),
                    -2.7512901673* Math.Pow(10, -20)
                }
            };

            public static void GetRange(int index)
            {
                switch (index)
                {
                    case 0:
                        // класc точности 1
                        // по цельсию 
                        MinTemp = -40;
                        MaxTemp = 350;
                        // мВ
                        MinE = -1.475;
                        MaxE = 17.819;
                        break;
                    case 1:
                        // класc точности 2
                        // по цельсию 
                        MinTemp = -40;
                        MaxTemp = 400;
                        // мВ
                        MinE = -1.475;
                        MaxE = 20.872;
                        break;
                    case 2:
                        // класc точности 3
                        // по цельсию 
                        MinTemp = -200;
                        MaxTemp = 40;
                        // мВ
                        MinE = -5.603;
                        MaxE = 1.612;
                        break;
                }
            }

            public static double Forward(double T, double T0)
            {
                double E = 0; T -= T0;

                if (T <= 0)
                {
                    for (int i = 0; i < A[0].Length; i++)
                    {
                        E += (A[0][i] * Math.Pow(T, (double)i));
                    }
                }
                else
                {
                    for (int i = 0; i < A[1].Length; i++)
                    {
                        E += A[1][i] * Math.Pow(T, i);
                    }
                }

                return E;
            }

            public static void GetLimits(double T, double T0, int index)
            {
                // частная производная в точке
                de_dt = (Forward(T + 0.1, T0) - Forward(T, T0)) / (0.1);

                // пределы допустимых погрешностей
                // приведённые ко входу
                switch (index)
                {
                    case 0: // класс допуска 1
                        if (T <= 125) Dt_abs = 0.5;
                        else Dt_abs = 0.004 * Math.Abs(T);
                        break;
                    case 1: // класс допуска 2
                        if (T <= 135) Dt_abs = 1;
                        else Dt_abs = 0.0075 * Math.Abs(T);
                        break;
                    case 2: // класс допуска 3
                        if (T <= -66) Dt_abs = 0.015 * Math.Abs(T);
                        else Dt_abs = 1;
                        break;
                }

                gt = Dt_abs / (MaxTemp - MinTemp) * 100;

                // пределы допустимых погрешностей
                // приведённые к выходу
                De_abs = Dt_abs * de_dt;

                ge = De_abs / (MaxE - MinE) * 100;
            }
        }
       
        public class Type_E
        {
            public static int MinTemp, MaxTemp; // температура по цельсию
            public static double MinE, MaxE;    // ТЭДС мВ
            public static double Dt_abs, De_abs, de_dt, gt, ge;
            static double[][] A = {

                // от -270°С до 0°С
                new double[] {
                    0,
                    5.8665508708* Math.Pow(10, -2),
                    4.5410977124* Math.Pow(10, -5),
                    -7.7998048686* Math.Pow(10, -7),
                    -2.5800160843* Math.Pow(10, -8),
                    -5.9452583057* Math.Pow(10, -10),
                    -9.3214058667* Math.Pow(10, -12),
                    -1.0287605534* Math.Pow(10, -13),
                    -8.0370123621* Math.Pow(10, -16),
                    -4.3979497391* Math.Pow(10, -18),
                    -1.6414776355* Math.Pow(10, -20),
                    -3.9673619516* Math.Pow(10, -23),
                    -5.5827328721* Math.Pow(10, -26),
                    -3.4657842013* Math.Pow(10, -29)
                },

                // от 0°С до 1000°С
                new double[] {
                    0,
                    5.866550871* Math.Pow(10, -2),
                    4.5032275582* Math.Pow(10, -5),
                    2.8908407212* Math.Pow(10, -8),
                    -3.3056896652* Math.Pow(10, -10),
                    6.502440327* Math.Pow(10, -13),
                    -1.9197495504* Math.Pow(10, -16),
                    -1.2536600497* Math.Pow(10, -18),
                    2.1489217569* Math.Pow(10, -21),
                    -1.4388041782* Math.Pow(10, -24),
                    3.5960899481* Math.Pow(10, -28),
                }
            };

            public static void GetRange(int index)
            {
                switch (index)
                {
                    case 0:
                        // класc точности 1
                        // по цельсию 
                        MinTemp = -40;
                        MaxTemp = 800;
                        // мВ
                        MinE = -2.255;
                        MaxE = 61.017;
                        break;
                    case 1:
                        // класc точности 2
                        // по цельсию 
                        MinTemp = -40;
                        MaxTemp = 900;
                        // мВ
                        MinE = -2.255;
                        MaxE = 68.787;
                        break;
                    case 2:
                        // класc точности 3
                        // по цельсию 
                        MinTemp = -200;
                        MaxTemp = 40;
                        // мВ
                        MinE = -8.825;
                        MaxE = 2.42;
                        break;
                }
            }

            public static double Forward(double T, double T0)
            {
                double E = 0; T -= T0;

                if (T <= 0)
                {
                    for (int i = 0; i < A[0].Length; i++)
                    {
                        E += (A[0][i] * Math.Pow(T, (double)i));
                    }
                }
                else
                {
                    for (int i = 0; i < A[1].Length; i++)
                    {
                        E += A[1][i] * Math.Pow(T, i);
                    }
                }

                return E;
            }

            public static void GetLimits(double T, double T0, int index)
            {
                // частная производная в точке
                de_dt = (Forward(T + 0.1, T0) - Forward(T, T0)) / (0.1);

                // пределы допустимых погрешностей
                // приведённые ко входу
                switch (index)
                {
                    case 0: // класс допуска 1
                        if (T <= 375) Dt_abs = 1.5;
                        else Dt_abs = 0.004 * Math.Abs(T);
                        break;
                    case 1: // класс допуска 2
                        if (T <= 333) Dt_abs = 2.5;
                        else Dt_abs = 0.0075 * Math.Abs(T);
                        break;
                    case 2: // класс допуска 3
                        if (T <= -167) Dt_abs = 0.015 * Math.Abs(T);
                        else Dt_abs = 2.5;
                        break;
                }

                gt = Dt_abs / (MaxTemp - MinTemp) * 100;

                // пределы допустимых погрешностей
                // приведённые к выходу
                De_abs = Dt_abs * de_dt;

                ge = De_abs / (MaxE - MinE) * 100;
            }
        }
       
        public class Type_K
        {
            public static int MinTemp, MaxTemp; // температура по цельсию
            public static double MinE, MaxE;    // ТЭДС мВ
            public static double Dt_abs, De_abs, de_dt, gt, ge;
            static double 
                C0 = 1.185976 * Math.Pow(10, -1), 
                C1 = -1.183432 * Math.Pow(10, -4);
            static double[][] A = {

                // от -270°С до 0°С
                new double[] {
                    0,
                    3.9450128025* Math.Pow(10, -2),
                    2.3622373598* Math.Pow(10, -5),
                    -3.2858906784* Math.Pow(10, -7),
                    -4.9904828777* Math.Pow(10, -9),
                    -6.7509059173* Math.Pow(10, -11),
                    -5.7410327428* Math.Pow(10, -13),
                    -3.1088872894* Math.Pow(10, -15),
                    -1.0451609365* Math.Pow(10, -17),
                    -1.9889266878* Math.Pow(10, -20),
                    -1.6322697486* Math.Pow(10, -23)
                },

                // от 0°С до 1372°С
                new double[] {
                    -1.7600413686* Math.Pow(10, -2),
                    3.8921204975* Math.Pow(10, -2),
                    1.8558770032* Math.Pow(10, -5),
                    -9.9457592874* Math.Pow(10, -8),
                    3.1840945719* Math.Pow(10, -10),
                    -5.6072844889* Math.Pow(10, -13),
                    5.6075059059* Math.Pow(10, -16),
                    -3.2020720003* Math.Pow(10, -19),
                    9.7151147152* Math.Pow(10, -23),
                    -1.2104721275* Math.Pow(10, -26)
                }
            };

            public static void GetRange(int index)
            {
                switch (index)
                {
                    case 0:
                        // класc точности 1
                            // по цельсию 
                        MinTemp = -40;
                        MaxTemp = 1300;
                            // мВ
                        MinE = -1.527;
                        MaxE = 52.41;
                        break;
                    case 1:
                        // класc точности 2
                            // по цельсию 
                        MinTemp = -40;
                        MaxTemp = 1300;
                            // мВ
                        MinE = -1.527;
                        MaxE = 52.41;
                        break;
                    case 2:
                        // класc точности 3
                            // по цельсию 
                        MinTemp = -250;
                        MaxTemp = 40;
                            // мВ
                        MinE = -6.404;
                        MaxE = 1.612;
                        break;
                }
            }

            public static double Forward(double T, double T0)
            {
                double E = 0; T -= T0;

                if (T <= 0)
                {
                    for (int i = 0; i < A[0].Length; i++)
                    {
                        E += (A[0][i] * Math.Pow(T, (double)i));
                    }
                }
                else
                {
                    for (int i = 0; i < A[1].Length; i++)
                    {
                        E += A[1][i] * Math.Pow(T, i) + (C0 * Math.Exp(Math.Pow(C1 * (T - 126.9686), 2)));
                    }
                }

                return E;
            }

            public static void GetLimits(double T, double T0, int index)
            {
                // частная производная в точке
                de_dt = (Forward(T + 0.1, T0) - Forward(T, T0)) / (0.1);

                // пределы допустимых погрешностей
                // приведённые ко входу
                switch (index)
                {
                    case 0: // класс допуска 1
                        if (T <= 375) Dt_abs = 1.5;
                        else Dt_abs = 0.004 * Math.Abs(T);
                        break;
                    case 1: // класс допуска 2
                        if (T <= 333) Dt_abs = 2.5;
                        else Dt_abs = 0.0075 * Math.Abs(T);
                        break;
                    case 2: // класс допуска 3
                        if (T <= -167) Dt_abs = 0.015 * Math.Abs(T);
                        else Dt_abs = 2.5;
                        break;
                }

                gt = Dt_abs / (MaxTemp - MinTemp) * 100;

                // пределы допустимых погрешностей
                // приведённые к выходу
                De_abs = Dt_abs * de_dt;

                ge = De_abs / (MaxE - MinE) * 100;
            }
        }
        
        public class Type_N
        {
            public static int MinTemp, MaxTemp; // температура по цельсию
            public static double MinE, MaxE;    // ТЭДС мВ
            public static double Dt_abs, De_abs, de_dt, gt, ge;
            static double[][] A = {

                // от -270°С до 0°С

                new double[] {
                    0,
                    2.6159105962* Math.Pow(10, -2),
                    1.0957484228* Math.Pow(10, -5),
                    -9.3841111554* Math.Pow(10, -8),
                    -4.6412039759* Math.Pow(10, -11),
                    -2.6303357716* Math.Pow(10, -12),
                    -2.2653438003* Math.Pow(10, -14),
                    -7.6089300791* Math.Pow(10, -17),
                    -9.3419667835* Math.Pow(10, -20)
                },

                // от 0°С до 1300°С

                new double[] {
                    0,
                    2.5929394601* Math.Pow(10, -2),
                    1.571014188* Math.Pow(10, -5),
                    4.3825627237* Math.Pow(10, -8),
                    -2.5261169794* Math.Pow(10, -10),
                    6.4311819339* Math.Pow(10, -13),
                    -1.0063471519* Math.Pow(10, -15),
                    9.9745338992* Math.Pow(10, -19),
                    -6.0863245607* Math.Pow(10, -22),
                    2.0849229339* Math.Pow(10, -25),
                    -3.0682196151* Math.Pow(10, -29)
                }
            };

            public static void GetRange(int index)
            {
                switch (index)
                {
                    case 0:
                        // класc точности 1
                        // по цельсию 
                        MinTemp = -40;
                        MaxTemp = 1300;
                        // мВ
                        MinE = -1.023;
                        MaxE = 47.513;
                        break;
                    case 1:
                        // класc точности 2
                        // по цельсию 
                        MinTemp = -40;
                        MaxTemp = 1300;
                        // мВ
                        MinE = -1.023;
                        MaxE = 47.513;
                        break;
                    case 2:
                        // класc точности 3
                        // по цельсию 
                        MinTemp = -250;
                        MaxTemp = 40;
                        // мВ
                        MinE = -4.313;
                        MaxE = 1.065;
                        break;
                }
            }

            public static double Forward(double T, double T0)
            {
                double E = 0; T -= T0;

                if (T <= 0)
                {
                    for (int i = 0; i < A[0].Length; i++)
                    {
                        E += (A[0][i] * Math.Pow(T, (double)i));
                    }
                }
                else
                {
                    for (int i = 0; i < A[1].Length; i++)
                    {
                        E += A[1][i] * Math.Pow(T, i);
                    }
                }

                return E;
            }

            public static void GetLimits(double T, double T0, int index)
            {
                // частная производная в точке
                de_dt = (Forward(T + 0.1, T0) - Forward(T, T0)) / (0.1);

                // пределы допустимых погрешностей
                // приведённые ко входу
                switch (index)
                {
                    case 0: // класс допуска 1
                        if (T <= 375) Dt_abs = 1.5;
                        else Dt_abs = 0.004 * Math.Abs(T);
                        break;
                    case 1: // класс допуска 2
                        if (T <= 333) Dt_abs = 2.5;
                        else Dt_abs = 0.0075 * Math.Abs(T);
                        break;
                    case 2: // класс допуска 3
                        if (T <= -167) Dt_abs = 0.015 * Math.Abs(T);
                        else Dt_abs = 2.5;
                        break;
                }

                gt = Dt_abs / (MaxTemp - MinTemp) * 100;

                // пределы допустимых погрешностей
                // приведённые к выходу
                De_abs = Dt_abs * de_dt;

                ge = De_abs / (MaxE - MinE) * 100;
            }
        }
        
        public class Type_A1
        {
            public static int MinTemp, MaxTemp; // температура по цельсию
            public static double MinE, MaxE;    // ТЭДС мВ
            public static double Dt_abs, De_abs, de_dt, gt, ge;
            static double[] A = {
                 7.1564735* Math.Pow(10, -4),
                 1.1951905* Math.Pow(10, -2),
                 1.6672625* Math.Pow(10, -5),
                 -2.8287807* Math.Pow(10, -8),
                 2.8397839* Math.Pow(10, -11),
                 -1.8505007* Math.Pow(10, -14),
                 7.3632123* Math.Pow(10, -18),
                 -1.6148878* Math.Pow(10, -21),
                 1.4901679* Math.Pow(10, -25),
            };

            public static void GetRange()
            {
                // класы точности 2 и 3
                // по цельсию 
                MinTemp = 1000;
                MaxTemp = 2500;
                // мВ
                MinE = 16.128;
                MaxE = 33.64;
            }

            public static double Forward(double T, double T0)
            {
                double E = 0; T -= T0;

                for (int i = 0; i < A.Length; i++)
                {
                    E += (A[i] * Math.Pow(T, (double)i));
                }

                return E;
            }

            public static void GetLimits(double T, double T0, int index)
            {
                // частная производная в точке
                de_dt = (Forward(T + 0.1, T0) - Forward(T, T0)) / (0.1);

                // пределы допустимых погрешностей
                // приведённые ко входу
                switch (index)
                {
                    case 0: // класс допуска 2
                        Dt_abs = 0.005 * T;
                        break;
                    case 1: // класс допуска 3
                        Dt_abs = 0.007 * T;
                        break;
                }

                gt = Dt_abs / (MaxTemp - MinTemp) * 100;

                // пределы допустимых погрешностей
                // приведённые к выходу
                De_abs = Dt_abs * de_dt;

                ge = De_abs / (MaxE - MinE) * 100;
            }
        }
        
        public class Type_A2
        {
            public static int MinTemp, MaxTemp; // температура по цельсию
            public static double MinE, MaxE;    // ТЭДС мВ
            public static double Dt_abs, De_abs, de_dt, gt, ge;
            static double[] A = {
                 -1.0850558* Math.Pow(10, -4),
                 1.1642292* Math.Pow(10, -2),
                 2.1280289* Math.Pow(10, -5),
                 -4.4258402* Math.Pow(10, -8),
                 5.5652058* Math.Pow(10, -11),
                 -4.380131* Math.Pow(10, -14),
                 2.022839* Math.Pow(10, -17),
                 -4.9354041* Math.Pow(10, -21),
                 4.8119846* Math.Pow(10, -25)
            };

            public static void GetRange()
            {
                // класы точности 2 и 3
                // по цельсию 
                MinTemp = 0;
                MaxTemp = 1800;
                // мВ
                MinE = 0;
                MaxE = 27.232;
            }

            public static double Forward(double T, double T0)
            {
                double E = 0; T -= T0;

                for (int i = 0; i < A.Length; i++)
                {
                    E += (A[i] * Math.Pow(T, (double)i));
                }

                return E;
            }

            public static void GetLimits(double T, double T0, int index)
            {
                // частная производная в точке
                de_dt = (Forward(T + 0.1, T0) - Forward(T, T0)) / (0.1);

                // пределы допустимых погрешностей
                // приведённые ко входу
                switch (index)
                {
                    case 0: // класс допуска 2
                        Dt_abs = 0.005 * T;
                        break;
                    case 1: // класс допуска 3
                        Dt_abs = 0.007 * T;
                        break;
                }

                gt = Dt_abs / (MaxTemp - MinTemp) * 100;

                // пределы допустимых погрешностей
                // приведённые к выходу
                De_abs = Dt_abs * de_dt;

                ge = De_abs / (MaxE - MinE) * 100;
            }
        }
        
        public class Type_A3
        {
            public static int MinTemp, MaxTemp; // температура по цельсию
            public static double MinE, MaxE;    // ТЭДС мВ
            public static double Dt_abs, De_abs, de_dt, gt, ge;
            static double[] A = {
                -1.0649133* Math.Pow(10, -4),
                1.1686475* Math.Pow(10, -2),
                1.8022157* Math.Pow(10, -5),
                -3.3436998* Math.Pow(10, -8),
                3.7081688* Math.Pow(10, -11),
                -2.5748444* Math.Pow(10, -14),
                1.0301893* Math.Pow(10, -17),
                -2.0735944* Math.Pow(10, -21),
                1.467845* Math.Pow(10, -25)
            };

            public static void GetRange()
            {
                // класы точности 2 и 3
                // по цельсию 
                MinTemp = 0;
                MaxTemp = 1800;
                // мВ
                MinE = 0;
                MaxE = 26.773;
            }

            public static double Forward(double T, double T0)
            {
                double E = 0; T -= T0;

                for (int i = 0; i < A.Length; i++)
                {
                    E += (A[i] * Math.Pow(T, (double)i));
                }

                return E;
            }

            public static void GetLimits(double T, double T0, int index)
            {
                // частная производная в точке
                de_dt = (Forward(T + 0.1, T0) - Forward(T, T0)) / (0.1);

                // пределы допустимых погрешностей
                // приведённые ко входу
                switch (index)
                {
                    case 0: // класс допуска 2
                        Dt_abs = 0.005 * T;
                        break;
                    case 1: // класс допуска 3
                        Dt_abs = 0.007 * T;
                        break;
                }

                gt = Dt_abs / (MaxTemp - MinTemp) * 100;

                // пределы допустимых погрешностей
                // приведённые к выходу
                De_abs = Dt_abs * de_dt;

                ge = De_abs / (MaxE - MinE) * 100;
            }
        }
        
        public class Type_L
        {
            public static int MinTemp, MaxTemp; // температура по цельсию
            public static double MinE, MaxE;    // ТЭДС мВ
            public static double Dt_abs, De_abs, de_dt, gt, ge;
            static double[][] A = {

                // от -200°С до 0°С

                new double[] {
                    -5.8952244* Math.Pow(10, -5),
                    6.3391502* Math.Pow(10, -2),
                    6.7592964* Math.Pow(10, -5),
                    2.0672566* Math.Pow(10, -7),
                    5.5720884* Math.Pow(10, -9),
                    5.713386* Math.Pow(10, -11),
                    3.2995593* Math.Pow(10, -13),
                    9.923242* Math.Pow(10, -16),
                    1.2079584* Math.Pow(10, -18)
                },

                // от 0°С до 800°С

                new double[] {
                    -1.8656953* Math.Pow(10, -5),
                    6.3310975* Math.Pow(10, -2),
                    6.0153091* Math.Pow(10, -5),
                    -8.0073134* Math.Pow(10, -8),
                    9.6946071* Math.Pow(10, -11),
                    -3.6047289* Math.Pow(10, -14),
                    -2.4694775* Math.Pow(10, -16),
                    4.2880341* Math.Pow(10, -19),
                    -2.0725297* Math.Pow(10, -22)
                }
            };

            public static void GetRange(int index)
            {
                switch (index)
                {
                    case 0:
                        // класc точности 2
                        // по цельсию 
                        MinTemp = -40;
                        MaxTemp = 800;
                        // мВ
                        MinE = -2.431;
                        MaxE = 66.466;
                        break;
                    case 1:
                        // класc точности 3
                        // по цельсию 
                        MinTemp = -200;
                        MaxTemp = 100;
                        // мВ
                        MinE = -9.488;
                        MaxE = 6.862;
                        break;
                }
            }

            public static double Forward(double T, double T0)
            {
                double E = 0; T -= T0;

                if (T <= 0)
                {
                    for (int i = 0; i < A[0].Length; i++)
                    {
                        E += (A[0][i] * Math.Pow(T, (double)i));
                    }
                }
                else
                {
                    for (int i = 0; i < A[1].Length; i++)
                    {
                        E += A[1][i] * Math.Pow(T, i);
                    }
                }

                return E;
            }

            public static void GetLimits(double T, double T0, int index)
            {
                // частная производная в точке
                de_dt = (Forward(T + 0.1, T0) - Forward(T, T0)) / (0.1);

                // пределы допустимых погрешностей
                // приведённые ко входу
                switch (index)
                {
                    case 0: // класс допуска 2
                        if (T <= 360) Dt_abs = 2.5;
                        else Dt_abs = 0.7 + (0.005 * T);
                        break;
                    case 1: // класс допуска 3
                        if (T <= -100) Dt_abs = 1.5 + 0.01 * Math.Abs(T);
                        else Dt_abs = 2.5;
                        break;
                }

                gt = Dt_abs / (MaxTemp - MinTemp) * 100;

                // пределы допустимых погрешностей
                // приведённые к выходу
                De_abs = Dt_abs * de_dt;

                ge = De_abs / (MaxE - MinE) * 100;
            }
        }
        
        public class Type_M
        {
            public static int MinTemp, MaxTemp; // температура по цельсию
            public static double MinE, MaxE;    // ТЭДС мВ
            public static double Dt_abs, De_abs, de_dt, gt, ge;
            static double[] A = {
                 2.445556* Math.Pow(10, -6),
                 4.2638917* Math.Pow(10, -2),
                 5.0348392* Math.Pow(10, -5),
                 -4.4974485* Math.Pow(10, -8)
            };

            public static void GetRange()
            {
                // класс точности -
                // по цельсию 
                MinTemp = -200;
                MaxTemp = 100;
                // мВ
                MinE = -6.154;
                MaxE = 4.722;
            }

            public static double Forward(double T, double T0)
            {
                double E = 0; T -= T0;

                for (int i = 0; i < A.Length; i++)
                {
                    E += (A[i] * Math.Pow(T, (double)i));
                }

                return E;
            }

            public static void GetLimits(double T, double T0)
            {
                // частная производная в точке
                de_dt = (Forward(T + 0.1, T0) - Forward(T, T0)) / (0.1);

                // пределы допустимых погрешностей
                // приведённые ко входу
                if (T <= 0) Dt_abs = 1.3 + 0.001 * Math.Abs(T);
                else Dt_abs = 1;

                gt = Dt_abs / (MaxTemp - MinTemp) * 100;

                // пределы допустимых погрешностей
                // приведённые к выходу
                De_abs = Dt_abs * de_dt;

                ge = De_abs / (MaxE - MinE) * 100;
            }
        }
    }
}
