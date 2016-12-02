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

namespace HouseSupportSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            var init = new AHP();
            init.Initialize(3, 7, 5);
            var score = init.startCounting();
            this.score.Text = ConvertArrayToString(score);
            init.CalculateConsistency();

            /*
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = "1";
            textColumn.Binding = new Binding("1");
            dataGrid.Columns.Add(textColumn);

            this.dataGrid.Items.Add(new TextBox().Text = "");
            */
            generate_columns();

        }

        string ConvertArrayToString(double[] s)
        {
            string output = "";
            foreach (var s1 in s)
            {
                output += s1.ToString() + " ";
            }
            return output;
        }
        public class Item
        {
            public int Num { get; set; }
            public string Start { get; set; }
            public string Finich { get; set; }
        }
        private void generate_columns()
        {
            DataGridTextColumn c1 = new DataGridTextColumn();
            c1.Header = "Num";
            c1.Binding = new Binding("Num");
            c1.Width = 110;
            this.dataGrid.Columns.Add(c1);
            DataGridTextColumn c2 = new DataGridTextColumn();
            c2.Header = "Start";
            c2.Width = 110;
            c2.Binding = new Binding("Start");
            this.dataGrid.Columns.Add(c2);
            DataGridTextColumn c3 = new DataGridTextColumn();
            c3.Header = "Finich";
            c3.Width = 110;
            c3.Binding = new Binding("Finich");
            this.dataGrid.Columns.Add(c3);

            this.dataGrid.Items.Add(new Item() { Num = 1, Start = "2012, 8, 15", Finich = "2012, 9, 15" });
            this.dataGrid.Items.Add(new Item() { Num = 2, Start = "2012, 12, 15", Finich = "2013, 2, 1" });
            this.dataGrid.Items.Add(new Item() { Num = 3, Start = "2012, 8, 1", Finich = "2012, 11, 15" });
            
        }
    }
}
