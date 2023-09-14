using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diplom_v4
{
    public class Logic
    {
        public static int Selector1, Selector2, Selector3;
        public static bool Ff = true, VeriF;
        public static double df_dx = 0;
        public static double tab1, tab2, tab3, tab4, tab5, tab6;


        public static string[] ThermocouplesTypes = {
            "ТПП (R)",
            "ТПП (S)",
            "ТПР (B)",
            "ТЖК (J)",
            "ТМК (T)",
            "ТХКн (E)",
            "ТХА (K)",
            "ТНН (N)",
            "ТВР (A-1)",
            "ТВР (A-2)",
            "ТВР (A-3)",
            "ТХК (L)",
            "ТМК (M)"
        };

        public static string[] ResistanceTypes = {
            "Платиновый (Pt)",
            "Платиновый (П)",
            "Медный (М)",
            "Никелевый (Н)"
        };

        public static string[] GetCollectionOfKT(int Selector1, int Selector2) {

            string[][] collect = {
                new string[] { // ТС Pt, П
                    "AA",
                    "A",
                    "B",
                    "C"
                },
                new string[] { // ТС М
                    "A",
                    "B",
                    "C"
                },
                new string[] { // ТС Н
                    "C"
                },
                new string[] { // ТП T, E, K, N
                    "1",
                    "2",
                    "3"
                },
                new string[] { // ТП R, S, J
                    "1",
                    "2"
                },
                new string[] { // ТП B, L, A-1, A-2, A-3
                    "2",
                    "3"
                },
                new string[] { // ТП М
                    "--"
                },
             };

            if (Selector1 == 0)
            {
                switch (Selector2)
                {
                    case 2:
                        return collect[1];
                    case 3:
                        return collect[2];
                    default:
                        return collect[0];
                }
            }
            else
            {
                switch (Selector2)
                {
                    case 0:
                        return collect[4];
                    case 1:
                        return collect[4];
                    case 3:
                        return collect[4];
                    case 2:
                        return collect[5];
                    case 8:
                        return collect[5];
                    case 9:
                        return collect[5];
                    case 10:
                        return collect[5];
                    case 11:
                        return collect[5];
                    case 12:
                        return collect[6];
                    default:
                        return collect[3];
                }
            }  
        }

        public static void GetRange(ref string tx5, ref string tx6, ref string tx7, ref string tx8) {

            if (Selector1 == 0)
            {
                switch (Selector2)
                {
                    case 0:
                        Resistance.Platinum_pt.GetRange(Selector3);
                        tx5 = Convert.ToString(Resistance.Platinum_pt.MinTemp);
                        tx6 = Convert.ToString(Resistance.Platinum_pt.MaxTemp);
                        tx7 = Convert.ToString(Resistance.Platinum_pt.MinRes);
                        tx8 = Convert.ToString(Resistance.Platinum_pt.MaxRes);
                        break;
                    case 1:
                        Resistance.Platinum_p.GetRange(Selector3);
                        tx5 = Convert.ToString(Resistance.Platinum_p.MinTemp);
                        tx6 = Convert.ToString(Resistance.Platinum_p.MaxTemp);
                        tx7 = Convert.ToString(Resistance.Platinum_p.MinRes);
                        tx8 = Convert.ToString(Resistance.Platinum_p.MaxRes);
                        break;
                    case 2:
                        Resistance.Copper.GetRange(Selector3);
                        tx5 = Convert.ToString(Resistance.Copper.MinTemp);
                        tx6 = Convert.ToString(Resistance.Copper.MaxTemp);
                        tx7 = Convert.ToString(Resistance.Copper.MinRes);
                        tx8 = Convert.ToString(Resistance.Copper.MaxRes);
                        break;
                    case 3:
                        Resistance.Nickel.GetRange();
                        tx5 = Convert.ToString(Resistance.Nickel.MinTemp);
                        tx6 = Convert.ToString(Resistance.Nickel.MaxTemp);
                        tx7 = Convert.ToString(Resistance.Nickel.MinRes);
                        tx8 = Convert.ToString(Resistance.Nickel.MaxRes);
                        break;
                }
            }
            else
            {
                switch (Selector2)
                {
                    case 0:
                        Thermocouple.Type_R.GetRange();
                        tx5 = Convert.ToString(Thermocouple.Type_R.MinTemp);
                        tx6 = Convert.ToString(Thermocouple.Type_R.MaxTemp);
                        tx7 = Convert.ToString(Thermocouple.Type_R.MinE);
                        tx8 = Convert.ToString(Thermocouple.Type_R.MaxE);
                        break;
                    case 1:
                        Thermocouple.Type_S.GetRange();
                        tx5 = Convert.ToString(Thermocouple.Type_S.MinTemp);
                        tx6 = Convert.ToString(Thermocouple.Type_S.MaxTemp);
                        tx7 = Convert.ToString(Thermocouple.Type_S.MinE);
                        tx8 = Convert.ToString(Thermocouple.Type_S.MaxE);
                        break;
                    case 2:
                        Thermocouple.Type_B.GetRange();
                        tx5 = Convert.ToString(Thermocouple.Type_B.MinTemp);
                        tx6 = Convert.ToString(Thermocouple.Type_B.MaxTemp);
                        tx7 = Convert.ToString(Thermocouple.Type_B.MinE);
                        tx8 = Convert.ToString(Thermocouple.Type_B.MaxE);
                        break;
                    case 3:
                        Thermocouple.Type_J.GetRange(Selector3);
                        tx5 = Convert.ToString(Thermocouple.Type_J.MinTemp);
                        tx6 = Convert.ToString(Thermocouple.Type_J.MaxTemp);
                        tx7 = Convert.ToString(Thermocouple.Type_J.MinE);
                        tx8 = Convert.ToString(Thermocouple.Type_J.MaxE);
                        break;
                    case 4:
                        Thermocouple.Type_T.GetRange(Selector3);
                        tx5 = Convert.ToString(Thermocouple.Type_T.MinTemp);
                        tx6 = Convert.ToString(Thermocouple.Type_T.MaxTemp);
                        tx7 = Convert.ToString(Thermocouple.Type_T.MinE);
                        tx8 = Convert.ToString(Thermocouple.Type_T.MaxE);
                        break;
                    case 5:
                        Thermocouple.Type_E.GetRange(Selector3);
                        tx5 = Convert.ToString(Thermocouple.Type_E.MinTemp);
                        tx6 = Convert.ToString(Thermocouple.Type_E.MaxTemp);
                        tx7 = Convert.ToString(Thermocouple.Type_E.MinE);
                        tx8 = Convert.ToString(Thermocouple.Type_E.MaxE);
                        break;
                    case 6:
                        Thermocouple.Type_K.GetRange(Selector3);
                        tx5 = Convert.ToString(Thermocouple.Type_K.MinTemp);
                        tx6 = Convert.ToString(Thermocouple.Type_K.MaxTemp);
                        tx7 = Convert.ToString(Thermocouple.Type_K.MinE);
                        tx8 = Convert.ToString(Thermocouple.Type_K.MaxE);
                        break;
                    case 7:
                        Thermocouple.Type_N.GetRange(Selector3);
                        tx5 = Convert.ToString(Thermocouple.Type_N.MinTemp);
                        tx6 = Convert.ToString(Thermocouple.Type_N.MaxTemp);
                        tx7 = Convert.ToString(Thermocouple.Type_N.MinE);
                        tx8 = Convert.ToString(Thermocouple.Type_N.MaxE);
                        break;
                    case 8:
                        Thermocouple.Type_A1.GetRange();
                        tx5 = Convert.ToString(Thermocouple.Type_A1.MinTemp);
                        tx6 = Convert.ToString(Thermocouple.Type_A1.MaxTemp);
                        tx7 = Convert.ToString(Thermocouple.Type_A1.MinE);
                        tx8 = Convert.ToString(Thermocouple.Type_A1.MaxE);
                        break;
                    case 9:
                        Thermocouple.Type_A2.GetRange();
                        tx5 = Convert.ToString(Thermocouple.Type_A2.MinTemp);
                        tx6 = Convert.ToString(Thermocouple.Type_A2.MaxTemp);
                        tx7 = Convert.ToString(Thermocouple.Type_A2.MinE);
                        tx8 = Convert.ToString(Thermocouple.Type_A2.MaxE);
                        break;
                    case 10:
                        Thermocouple.Type_A3.GetRange();
                        tx5 = Convert.ToString(Thermocouple.Type_A3.MinTemp);
                        tx6 = Convert.ToString(Thermocouple.Type_A3.MaxTemp);
                        tx7 = Convert.ToString(Thermocouple.Type_A3.MinE);
                        tx8 = Convert.ToString(Thermocouple.Type_A3.MaxE);
                        break;
                    case 11:
                        Thermocouple.Type_L.GetRange(Selector3);
                        tx5 = Convert.ToString(Thermocouple.Type_L.MinTemp);
                        tx6 = Convert.ToString(Thermocouple.Type_L.MaxTemp);
                        tx7 = Convert.ToString(Thermocouple.Type_L.MinE);
                        tx8 = Convert.ToString(Thermocouple.Type_L.MaxE);
                        break;
                    case 12:
                        Thermocouple.Type_M.GetRange();
                        tx5 = Convert.ToString(Thermocouple.Type_M.MinTemp);
                        tx6 = Convert.ToString(Thermocouple.Type_M.MaxTemp);
                        tx7 = Convert.ToString(Thermocouple.Type_M.MinE);
                        tx8 = Convert.ToString(Thermocouple.Type_M.MaxE);
                        break;
                }
            }
        }

        public static double Solve(double x1, double x2)
        {
            double y = 0;

            if (Selector1 == 0)
            {
                switch (Selector2)
                {
                    case 0:
                        if (Ff)
                        {
                            y = Resistance.Platinum_pt.Forward(x1, x2);
                            Resistance.Platinum_pt.GetLimits(x1, x2, Selector3);
                            df_dx = Resistance.Platinum_pt.dr_dt;
                        }
                        else 
                        {
                            y = Resistance.Platinum_pt.Reverse(x1, x2);
                            Resistance.Platinum_pt.GetLimits(y, x2, Selector3);
                            df_dx = 0;
                        }

                        tab1 = Resistance.Platinum_pt.gt;
                        tab3 = Resistance.Platinum_pt.Dt_abs;
                        tab4 = Resistance.Platinum_pt.gr;
                        tab6 = Resistance.Platinum_pt.Dr_abs;

                        break;
                    case 1:
                        if (Ff) 
                        {
                            y = Resistance.Platinum_p.Forward(x1, x2);
                            Resistance.Platinum_p.GetLimits(x1, x2, Selector3);
                            df_dx = Resistance.Platinum_p.dr_dt;
                        }
                        else
                        {
                            y = Resistance.Platinum_p.Reverse(x1, x2);
                            Resistance.Platinum_p.GetLimits(y, x2, Selector3);
                            df_dx = 0;
                        }

                        tab1 = Resistance.Platinum_p.gt;
                        tab3 = Resistance.Platinum_p.Dt_abs;
                        tab4 = Resistance.Platinum_p.gr;
                        tab6 = Resistance.Platinum_p.Dr_abs;

                        break;
                    case 2:
                        if (Ff) 
                        {
                            y = Resistance.Copper.Forward(x1, x2);
                            Resistance.Copper.GetLimits(x1, x2, Selector3);
                            df_dx = Resistance.Copper.dr_dt;
                        }
                        else
                        {
                            y = Resistance.Copper.Reverse(x1, x2);
                            Resistance.Copper.GetLimits(y, x2, Selector3);
                            df_dx = 0;
                        }

                        tab1 = Resistance.Copper.gt;
                        tab3 = Resistance.Copper.Dt_abs;
                        tab4 = Resistance.Copper.gr;
                        tab6 = Resistance.Copper.Dr_abs;

                        break;
                    case 3:
                        if (Ff) 
                        {
                            y = Resistance.Nickel.Forward(x1, x2);
                            Resistance.Nickel.GetLimits(x1, x2);
                            df_dx = Resistance.Nickel.dr_dt;
                        }
                        else
                        {
                            y = Resistance.Nickel.Reverse(x1, x2);
                            Resistance.Nickel.GetLimits(y, x2);
                            df_dx = 0;
                        }

                        tab1 = Resistance.Nickel.gt;
                        tab3 = Resistance.Nickel.Dt_abs;
                        tab4 = Resistance.Nickel.gr;
                        tab6 = Resistance.Nickel.Dr_abs;

                        break;
                }
            }
            else
            {
                switch (Selector2)
                {
                    case 0:
                        y = Thermocouple.Type_R.Forward(x1, x2);
                        Thermocouple.Type_R.GetLimits(x1, x2, Selector3);
                        df_dx = Thermocouple.Type_R.de_dt;

                        tab1 = Thermocouple.Type_R.gt;
                        tab3 = Thermocouple.Type_R.Dt_abs;
                        tab4 = Thermocouple.Type_R.ge;
                        tab6 = Thermocouple.Type_R.De_abs;
                        break;
                    case 1:
                        y = Thermocouple.Type_S.Forward(x1, x2);
                        Thermocouple.Type_S.GetLimits(x1, x2, Selector3);
                        df_dx = Thermocouple.Type_S.de_dt;

                        tab1 = Thermocouple.Type_S.gt;
                        tab3 = Thermocouple.Type_S.Dt_abs;
                        tab4 = Thermocouple.Type_S.ge;
                        tab6 = Thermocouple.Type_S.De_abs;
                        break;
                    case 2:
                        y = Thermocouple.Type_B.Forward(x1, x2);
                        Thermocouple.Type_B.GetLimits(x1, x2, Selector3);
                        df_dx = Thermocouple.Type_B.de_dt;

                        tab1 = Thermocouple.Type_B.gt;
                        tab3 = Thermocouple.Type_B.Dt_abs;
                        tab4 = Thermocouple.Type_B.ge;
                        tab6 = Thermocouple.Type_B.De_abs;
                        break;
                    case 3:
                        y = Thermocouple.Type_J.Forward(x1, x2);
                        Thermocouple.Type_J.GetLimits(x1, x2, Selector3);
                        df_dx = Thermocouple.Type_J.de_dt;

                        tab1 = Thermocouple.Type_J.gt;
                        tab3 = Thermocouple.Type_J.Dt_abs;
                        tab4 = Thermocouple.Type_J.ge;
                        tab6 = Thermocouple.Type_J.De_abs;
                        break;
                    case 4:
                        y = Thermocouple.Type_T.Forward(x1, x2);
                        Thermocouple.Type_T.GetLimits(x1, x2, Selector3);
                        df_dx = Thermocouple.Type_T.de_dt;

                        tab1 = Thermocouple.Type_T.gt;
                        tab3 = Thermocouple.Type_T.Dt_abs;
                        tab4 = Thermocouple.Type_T.ge;
                        tab6 = Thermocouple.Type_T.De_abs;
                        break;
                    case 5:
                        y = Thermocouple.Type_E.Forward(x1, x2);
                        Thermocouple.Type_E.GetLimits(x1, x2, Selector3);
                        df_dx = Thermocouple.Type_E.de_dt;

                        tab1 = Thermocouple.Type_E.gt;
                        tab3 = Thermocouple.Type_E.Dt_abs;
                        tab4 = Thermocouple.Type_E.ge;
                        tab6 = Thermocouple.Type_E.De_abs;
                        break;
                    case 6:
                        y = Thermocouple.Type_K.Forward(x1, x2);
                        Thermocouple.Type_K.GetLimits(x1, x2, Selector3);
                        df_dx = Thermocouple.Type_K.de_dt;

                        tab1 = Thermocouple.Type_K.gt;
                        tab3 = Thermocouple.Type_K.Dt_abs;
                        tab4 = Thermocouple.Type_K.ge;
                        tab6 = Thermocouple.Type_K.De_abs;
                        break;
                    case 7:
                        y = Thermocouple.Type_N.Forward(x1, x2);
                        Thermocouple.Type_N.GetLimits(x1, x2, Selector3);
                        df_dx = Thermocouple.Type_N.de_dt;

                        tab1 = Thermocouple.Type_N.gt;
                        tab3 = Thermocouple.Type_N.Dt_abs;
                        tab4 = Thermocouple.Type_N.ge;
                        tab6 = Thermocouple.Type_N.De_abs;
                        break;
                    case 8:
                        y = Thermocouple.Type_A1.Forward(x1, x2);
                        Thermocouple.Type_A1.GetLimits(x1, x2, Selector3);
                        df_dx = Thermocouple.Type_A1.de_dt;

                        tab1 = Thermocouple.Type_A1.gt;
                        tab3 = Thermocouple.Type_A1.Dt_abs;
                        tab4 = Thermocouple.Type_A1.ge;
                        tab6 = Thermocouple.Type_A1.De_abs;
                        break;
                    case 9:
                        y = Thermocouple.Type_A2.Forward(x1, x2);
                        Thermocouple.Type_A2.GetLimits(x1, x2, Selector3);
                        df_dx = Thermocouple.Type_A2.de_dt;

                        tab1 = Thermocouple.Type_A2.gt;
                        tab3 = Thermocouple.Type_A2.Dt_abs;
                        tab4 = Thermocouple.Type_A2.ge;
                        tab6 = Thermocouple.Type_A2.De_abs;
                        break;
                    case 10:
                        y = Thermocouple.Type_A3.Forward(x1, x2);
                        Thermocouple.Type_A3.GetLimits(x1, x2, Selector3);
                        df_dx = Thermocouple.Type_A3.de_dt;

                        tab1 = Thermocouple.Type_A3.gt;
                        tab3 = Thermocouple.Type_A3.Dt_abs;
                        tab4 = Thermocouple.Type_A3.ge;
                        tab6 = Thermocouple.Type_A3.De_abs;
                        break;
                    case 11:
                        y = Thermocouple.Type_L.Forward(x1, x2);
                        Thermocouple.Type_L.GetLimits(x1, x2, Selector3);
                        df_dx = Thermocouple.Type_L.de_dt;

                        tab1 = Thermocouple.Type_L.gt;
                        tab3 = Thermocouple.Type_L.Dt_abs;
                        tab4 = Thermocouple.Type_L.ge;
                        tab6 = Thermocouple.Type_L.De_abs;
                        break;
                    case 12:
                        y = Thermocouple.Type_M.Forward(x1, x2);
                        Thermocouple.Type_M.GetLimits(x1, x2);
                        df_dx = Thermocouple.Type_M.de_dt;

                        tab1 = Thermocouple.Type_M.gt;
                        tab3 = Thermocouple.Type_M.Dt_abs;
                        tab4 = Thermocouple.Type_M.ge;
                        tab6 = Thermocouple.Type_M.De_abs;
                        break;
                }
            }

            return y;
        }

        public static void Verification(double x1, double x2, double x3) 
        {
            Ff = true;
            
            if (Math.Abs(x2 - Solve(x1, x3)) <= Math.Abs(tab6))
            {
                System.Windows.Forms.MessageBox.Show("С датчиком всё в порядке!");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Абсолютная погрешность датчика (" +  Convert.ToString(Math.Round(Math.Abs(x2 - Solve(x1, x3)), 3)) + ") превышает допустимое значение!");
            }
        }
    }
}
