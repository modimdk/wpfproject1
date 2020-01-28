using System.Linq;
using System.Windows.Documents;

namespace WpfProject1
{
    public class MoadeleDoBodi
    {
        public string[] Moadelat;

        public static int[,] MatrisJavab = new int[1, 2];
        public static char[,] MatrisMajhool = new char[1, 2];
        public static int[,] MatrisMaloom = new int[2, 2];

        public static int[,] Copy1MatrisMaloom = new int[2, 2];
        public static int[,] Copy2MatrisMaloom = new int[2, 2];


        public MoadeleDoBodi(string[] moadelat)
        {
            this.Moadelat = moadelat;

            MatrisHa();
        }

        public static string write()
        {
            if (det(Copy2MatrisMaloom) != 0)
                return $" {MatrisMajhool[0, 0]}={det(JayGozari(1))/det(Copy2MatrisMaloom)}{MatrisMajhool[0, 1]}={det(JayGozari(2)) / det(Copy2MatrisMaloom)}";
            else
            if (det(Copy2MatrisMaloom) == 0)
                return Check();
            else return null;
        }

        private static string Check()
        {
            if (det(JayGozari(1)) != 0 || det(JayGozari(2)) != 0)
                return "No Solution";
            else return "No Unique Solution";
        }

        public static double det(int[,] matrisMaloom)
        {
            return (matrisMaloom[0, 0] * matrisMaloom[1, 1]) - (matrisMaloom[0, 1] * matrisMaloom[1, 0]);
        }

        public void MatrisHa()
        {
            for (int i = 0; i < 2; i++)
            {
                var MoadeleBedonAlamat = Moadelat[i].Split('+', '=').ToList();
                MatrisJavab[0, i] = int.Parse(MoadeleBedonAlamat[2]);
                MoadeleBedonAlamat.RemoveAt(2);

                foreach (var a in MoadeleBedonAlamat[i])
                {
                    if (char.IsLetter(a))
                    {
                        MatrisMajhool[0, i] = a;
                    }
                    else continue;
                }

                for (int j = 0; j < MoadeleBedonAlamat.Count; j++)
                {
                    foreach (var b in MoadeleBedonAlamat[j].ToCharArray())
                    {
                        if (char.IsLetter(b))
                        {
                            MatrisMaloom[i, j] = int.Parse(MoadeleBedonAlamat[j].Remove(MoadeleBedonAlamat[j].Length - 1));
                        }
                        else continue;
                    }
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Copy1MatrisMaloom[i, j] = MatrisMaloom[i, j];
                    Copy2MatrisMaloom[i, j] = MatrisMaloom[i, j];
                }
            }
        }

        public static int[,] JayGozari(int i)
        {
            if (i == 1)
            {
                MatrisMaloom[0, 0] = MatrisJavab[0, 0];
                MatrisMaloom[1, 0] = MatrisJavab[0, 1];
                return MatrisMaloom;
            }
            else if (i == 2)
            {
                Copy1MatrisMaloom[0, 1] = MatrisJavab[0, 0];
                Copy1MatrisMaloom[1, 1] = MatrisJavab[0, 1];
                return Copy1MatrisMaloom;
            }
            else return null;

        }
    }
}
