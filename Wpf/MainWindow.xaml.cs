using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Threading;

namespace WpfProject1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
 //           Clock clock = new Clock(Hour, Minute, second);
 //           System.Threading.Thread thread = new Thread(() => MoveClock(clock));
 //           thread.Start();

        }
        /*       public void MoveClock(Clock obj)
               {
                   while (true)
                   {
                       this.Dispatcher.BeginInvoke(new Action(() =>
                       {
                           obj.Move();
                       }));
                       Thread.Sleep(1000);
                   }

               }
               public class Clock
               {
                   Line Hour;
                   Line Minute;
                   Line Seconds;
                   public Clock(Line hour, Line minute, Line seconds)
                   {
                       Hour = hour;
                       Minute = minute;
                       Seconds = seconds;
                   }
                   public void Move()
                   {

                       Hour.X2 = 90 + 40 * Math.Sin(DateTime.Now.Hour * Math.PI * 30 / 180);

                       Hour.Y2 = 90 - 40 * Math.Cos(DateTime.Now.Hour * Math.PI * 30 / 180);


                       Minute.X2 = 90 + 70 * Math.Sin(DateTime.Now.Minute * Math.PI / 30);

                       Minute.Y2 = 90 - 70 * Math.Cos(DateTime.Now.Minute * Math.PI / 30);



                       Seconds.X2 = Seconds.X1 + 55 * Math.Sin(DateTime.Now.Second * Math.PI / 30);

                       Seconds.Y2 = Seconds.Y1 - 55 * Math.Cos(DateTime.Now.Second * Math.PI / 30);

                   }

              }
              */

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            StreamReader stream = new StreamReader("test.txt");
            string FirstName = name.Text;
            string LastName = lastname.Text;
            string City = city.Text;
            int Age = int.Parse(age.Text);
            string Equation = equation.Text;
            //اگر یکی از ضرایب ما یک باشد حتما باید یک نوشته شود.
            //اگر منفی داشته باشیم باید به صورت -+ نوشته شود.

            var Moadelat = equation.Text.Split(',', '_');

            MoadeleDoBodi MoadeleDoBodi = new MoadeleDoBodi(Moadelat);
            string JavabNahaee = MoadeleDoBodi.write();
            Massage.Text = JavabNahaee;
            string information = $"{FirstName} {LastName} {City} {Age} {Equation} {JavabNahaee} ";
            string text = stream.ReadToEnd();
            stream.Close();
            string[] people = text.Split('\n');
            string save = null;

            for (int i = 0; i < people.Length-1; i++)
            {
                save += people[i]+"\n";
            }
            //برای اینکه آخری خط اضافه نکنه
            save += people[people.Length - 1];
            
            using (StreamWriter streamWriter = new StreamWriter("test.txt"))
            {
                    
                int flag = 0;
                for (int i = 0; i < people.Length; i++)
                {
                    if (information != people[i])
                    {
                        flag = 1;

                    }
                }

                if (flag == 1)
                {
                    save += information;
                    streamWriter.WriteLine(save);
                }
                else
                {
                    streamWriter.WriteLine(save);
                }
                streamWriter.Close();

            }
        }

        private void ok2_Click(object sender, RoutedEventArgs e)
        {
            StreamReader stream = new StreamReader("test.txt");
            string a = stream.ReadToEnd();
            List<string> text = a.Split('\n').ToList();
            if (older2.Text != "")
            {
                OlderThan(older2.Text,ref text);
            }
            if (younger2.Text != "")
            {
                youngerthan(younger2.Text,ref text);
            }
            if (born2.Text != "")
            {
                isborn(born2.Text,ref text);
            }
            if (answer2.Text != "")
            {
                answers(answer2.Text,ref text);
            }
            if (named2.Text != "")
            {
                 isnamed(named2.Text, ref text);
            }
            if (used2.Text != "")
            {
                isused(used2.Text,ref text);
            }
            string Finalinformation = null;
            for(int i = 0; i < text.Count(); i++)
            {
                Finalinformation += text[i] + "\n";
            }
            finalinformation.Text = Finalinformation;
        }

        private void isused(string str, ref List<string> text)
        {
            text = text.Where(b => b.Split(' ')[0] != "" && (((b.Split(' ')[4].ToString())) == (str))).ToList();
        }

        private void isnamed(string str,  ref List<string> text)
        {
            text = text.Where(b => b.Split(' ')[0] != "" && (((b.Split(' ')[0].ToString())) == (str))).ToList();
        }

        private void answers(string str,ref  List<string> text)
        {
            text = text.Where(b => b.Split(' ')[0] != "" && (((b.Split(' ')[5]))==(str))).ToList();
        }

        private void youngerthan(string str,ref List<string> text)
        {
      
            text = text.Where(b => b.Split(' ')[0]!=""  && ((int.Parse(b.Split(' ')[3])) < int.Parse(str))).ToList();
        }

        private void OlderThan(string str ,ref List<string> text)
        {
            
          text=text.Where( b => (b.Split(' ')[0] != ""&&((int.Parse(b.Split(' ')[3])) > int.Parse(str)))).ToList();
 
        }
        private void isborn(string str,ref List<string> text)
        {

            text = text.Where(b => b.Split(' ')[0]!=""&&(((b.Split(' ')[2]))==(str))).ToList();

        }

    }

}