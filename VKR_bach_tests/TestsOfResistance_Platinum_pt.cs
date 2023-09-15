using Diplom_v4;
using System.Diagnostics;

namespace VKR_bach_tests
{
    [TestClass]
    public class TestsOfResistance_Platinum_pt
    {
        [TestMethod]
        public void TestGetRangeMethod()
        {
            for (int i = 0; i < 4; i++)
            {
                Resistance.Platinum_pt.GetRange(i);
                double[] expectedResult = new double[4];
                
                switch (i)
                {
                    case 0: expectedResult = new double[4] { -50, 250, 80.31, 194.1 }; break;
                    case 1: expectedResult = new double[4] { -100, 450, 60.26, 264.18 }; break;
                    case 2: expectedResult = new double[4] { -196, 660, 20.246, 332.79 }; break;
                    case 3: expectedResult = new double[4] { -196, 660, 20.246, 332.79 }; break;
                    default:
                        break;
                }
                
                    double[] result = new double[] {
                    Resistance.Platinum_pt.MinTemp,
                    Resistance.Platinum_pt.MaxTemp,
                    Math.Round(Resistance.Platinum_pt.MinRes, 3),
                    Math.Round(Resistance.Platinum_pt.MaxRes, 3) };

                

                for (int j = 0; j < result.Length ; j++)
                {
                    Assert.AreEqual(result[j], expectedResult[j]);
                }
            }
        }

        [TestMethod]
        public void TestForwardMethod()
        {
            double result = Math.Round(Resistance.Platinum_pt.Forward(10, 100), 3);
            Assert.AreEqual(result, 103.903);

        }

        [TestMethod]
        public void TestReverseMethod()
        {
            double result = Math.Round(Resistance.Platinum_pt.Reverse(150, 100), 3);
            Assert.AreEqual(result, 130.447);
        }
        [TestMethod]
        public void TestGetLimitsMethod()
        {
            for (int i = 0; i < 4; i++)
            {
                Resistance.Platinum_pt.GetLimits(100, 100, i);
                double[] expectedResult = new double[5];

                switch (i)
                {
                    case 0: expectedResult = new double[5] { 0.379, 0.27, 0.09, 0.102, 0.09 }; break;
                    case 1: expectedResult = new double[5] { 0.379, 0.35, 0.064, 0.133, 0.065 }; break;
                    case 2: expectedResult = new double[5] { 0.379, 0.8, 0.093, 0.303, 0.097 }; break;
                    case 3: expectedResult = new double[5] { 0.379, 1.6, 0.187, 0.607, 0.194 }; break;
                    default:
                        break;
                }

                double[] result = new double[] {
                    Math.Round(Resistance.Platinum_pt.dr_dt, 3),
                    Math.Round(Resistance.Platinum_pt.Dt_abs, 3),
                    Math.Round(Resistance.Platinum_pt.gt, 3),
                    Math.Round(Resistance.Platinum_pt.Dr_abs, 3),
                    Math.Round(Resistance.Platinum_pt.gr, 3)};

                for (int j = 0; j < result.Length; j++)
                {
                    Assert.AreEqual(result[j], expectedResult[j]);
                }


            }
        }
    }
}