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
using System.Drawing;
using Brush = System.Windows.Media.Brush;
using Brushes = System.Windows.Media.Brushes;
using Color = System.Windows.Media.Color;

namespace WaterskibaanWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Game game;
        public System.Drawing.Graphics CreateGraphics;
        int counter = 0;
        public MainWindow()
        {
            this.game = new Game();
            game._PrintStatus = true;
            DispatcherTimer timer = new DispatcherTimer();
            game.Initialize(timer);
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += timer_Tick;
            timer.Start();
            InitializeComponent();


        }
        void timer_Tick(object sender, EventArgs e)
        {
            counter++;
            DrawWachtrijInstructie();
            DrawInstructieGroep();
            DrawWachtrijStarten();
            DrawLijnen();
        }

        public void DrawWachtrijInstructie()
        {
            WI_Listbox.Items.Clear();
            foreach (Sporter sp in game.wi.GetAlleSporters())
            {
                WI_Listbox.Items.Add($"Sporter #{sp.SporterID}");
                    }
        }
        public void DrawInstructieGroep()
        {
            IG_Listbox.Items.Clear();
            foreach (Sporter sp in game.ig.GetAlleSporters())
            {
                IG_Listbox.Items.Add($"Sporter #{sp.SporterID}");
            }
        }
        public void DrawWachtrijStarten()
        {
            WS_Listbox.Items.Clear();
            foreach (Sporter sp in game.ws.GetAlleSporters())
            {
               WS_Listbox.Items.Add($"Sporter #{sp.SporterID}");
            }
        }

        public void DrawLijnen()
        {
            CV_lijnen.Children.Clear();
            int CV_X1 = 20;// Fixed
            int CV_Y1 = 10;
            int CV_X2 = 290;// Fixed
            int CV_Y2 = 10;
            if (game.wbaan.kabel._lijnen.Count > 0)
            {
                foreach (Lijn lijn in game.wbaan.kabel._lijnen)
                {
                    Line DrawLijn = new Line();
                    var brush = new SolidColorBrush(Color.FromArgb(lijn.Sp.KledingKleur.A, lijn.Sp.KledingKleur.R, lijn.Sp.KledingKleur.G, lijn.Sp.KledingKleur.B));
                    DrawLijn.Stroke = brush;
                    DrawLijn.X1 = CV_X1;
                    DrawLijn.X2 = CV_X2;
                    DrawLijn.Y1 = CV_Y1;
                    DrawLijn.Y2 = CV_Y2;
                    DrawLijn.StrokeThickness = 2;
                    CV_lijnen.Children.Add(DrawLijn);
                    Label tb = new Label();
                    tb.Content = $"{lijn.Sp.AantalRondenNogTeGaan}";
                    Canvas.SetLeft(tb, CV_X1-20);
                    Canvas.SetTop(tb, CV_Y2-13);
                    CV_lijnen.Children.Add(tb);
                    CV_Y1 += 20;
                    CV_Y2 += 20;
                }
            }
        }
    }
}
