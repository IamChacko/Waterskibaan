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
using System.Windows.Threading;
using Waterskibaan;

namespace WaterskibaanWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Game game;
        int counter = 0;
        public MainWindow()
        {
            this.game = new Game();
            game._PrintStatus = true;
            DispatcherTimer timer = new DispatcherTimer();
            game.Initialize(timer);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            InitializeComponent();


        }
        void timer_Tick(object sender, EventArgs e)
        {
            counter++;
            
            WI_Listbox.Items.Add(game.ig.GetAlleSporters().Count);
            
        }


        

}
}
