using System;
/*Using SysTEm.F*/
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
            PB_vullen();
            Update_Lijnenvooraad();
            Loggerupdate();
            DrawLichsteSpelers();
            UniekeMoves();
        }
        public void DrawLichsteSpelers()
        {
            SP_lichstekleur.Children.Clear();
            foreach (Sporter sp in game._logger.getLichsteSporters())
            {
                Label lb = new Label();
                lb.Content = $"Sporter#{sp.SporterID}";
                lb.Foreground = new SolidColorBrush(Color.FromArgb(sp.KledingKleur.A, sp.KledingKleur.R, sp.KledingKleur.G, sp.KledingKleur.B));
                SP_lichstekleur.Children.Add(lb);
            }
        }

        public void UniekeMoves()
        {
            SP_uniekiemoves.Children.Clear();
            foreach(IMoves move in game._logger.Uniekemoves())
            {
                Label lb = new Label();
                lb.Content = $"{move}";
                lb.Foreground = new SolidColorBrush(Color.FromRgb(230, 230, 230));
                SP_uniekiemoves.Children.Add(lb);

            }
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
        public void PB_vullen() // Elke 1s = 10 bij value
        {
            if (game.ig.GetAlleSporters().Count > 0)
            {
                PB_Ig.Visibility = Visibility.Visible;
            } else
            {
                PB_Ig.Visibility = Visibility.Hidden;
            }
            if (game.ws.GetAlleSporters().Count > 0)
            {
                PB_Ws.Visibility = Visibility.Visible;
            } else
            {
                PB_Ws.Visibility = Visibility.Hidden;
            }

            if (PB_Wi.Value == 30)
            {
                PB_Wi.Value = 0;
            }
            if (PB_Ig.Value == 200)
            {
                PB_Ig.Value = 0;
            }
            if (PB_Ws.Value == 40)
            {
                PB_Ws.Value = 0;
            }
            PB_Wi.Value++;
            PB_Ig.Value++;
            PB_Ws.Value++;
        }

        public void Update_Lijnenvooraad()
        {
            LB_Lijnenvooraad.Content = game.wbaan.Lv.GetAantalLijnen();

        }


        public void Loggerupdate()
        {
            LB_bezoekers.Content = game._logger.AantalBezoekers();
            Sporter sp = game._logger.Highscore();
            if (sp != null && sp.BehaaldePunten != 0)
            {
                IMG_beker.Visibility = Visibility.Visible;
                LB_winaarsporter.Content = $"Sporter#{sp.SporterID}";
                LB_winaarsporter.Foreground = new SolidColorBrush(Color.FromArgb(sp.KledingKleur.A, sp.KledingKleur.R, sp.KledingKleur.G, sp.KledingKleur.B));
                LB_scorehighscore.Content = sp.BehaaldePunten;
            }
            LB_rodeshirts.Content = game._logger.Rodeshirts;
            LB_totrondes.Content = game._logger.TotaleRondes();


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
                    tb.Foreground = new SolidColorBrush(Colors.White);
                    CV_lijnen.Children.Add(tb);
                    Label sttb = new Label();
                    Canvas.SetLeft(sttb, CV_X2);
                    Canvas.SetTop(sttb, CV_Y2 - 13);
                    sttb.Content = $"#{lijn.Sp.SporterID}";
                    SPkabelInformatie(CV_X2, CV_Y2, CV_lijnen, lijn);
                    sttb.Foreground = new SolidColorBrush(Colors.White);
                    CV_lijnen.Children.Add(sttb);
                    CV_Y1 += 20;
                    CV_Y2 += 20;
                }
            }
        }

        public void SPkabelInformatie(int x2, int y2, Canvas cv, Lijn lijn)
        {
            Line Scheidingslein = new Line();
            Label st_score = new Label();
            Label st_move = new Label();
            Scheidingslein.Stroke = new SolidColorBrush(Color.FromRgb(150,150,150));
            Scheidingslein.X1 = x2 + 35;
            Scheidingslein.X2 = x2 + 35;
            Scheidingslein.Y1 = 0;
            Scheidingslein.Y2 = 205;
            Scheidingslein.StrokeThickness = 2;
            Canvas.SetLeft(st_score, x2+40);
            Canvas.SetTop(st_score, y2 - 13);
            Canvas.SetLeft(st_move, x2 + 70);
            Canvas.SetTop(st_move, y2 - 13);
            st_score.Content = lijn.Sp.BehaaldePunten;
            st_move.Content = lijn.Sp.HuidigeMove;
            st_score.Foreground = new SolidColorBrush(Colors.White);
            st_move.Foreground = new SolidColorBrush(Colors.White);
            if (lijn.Sp.BehaaldePunten > 0) { cv.Children.Add(st_score); }
            cv.Children.Add(st_move);
           // cv.Children.Add(Scheidingslein);
        }
        private void WI_Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
