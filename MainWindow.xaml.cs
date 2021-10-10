using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private int _movement_strategy = 1;

        tPoint[] points = new tPoint[20];
        Ellipse[] ellipse = new Ellipse[20];

        AbstractShape[] shapes = new AbstractShape[6];

        int Angle = 2;
        private void Canvas1_Loaded(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int height = (int)((Canvas)this.Content).RenderSize.Height;
            int width = (int)((Canvas)this.Content).RenderSize.Width;
            SolidColorBrush brush;

            for (int i = 0; i < points.Length; i++)
            {
                brush = new SolidColorBrush(Color.FromArgb(255, (byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)));
                points[i] = new tPoint(rnd.Next() % width, rnd.Next() % height, brush);
            }
            brush = new SolidColorBrush(Color.FromArgb(255, (byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)));
            tPoint p = new tPoint(width / 2, height / 2, brush);
            shapes[0] = new TiRectangle(p);
            p.brush = Brushes.HotPink;
            shapes[1] = new TiCircle(p);
            p.brush = Brushes.Chartreuse;
            shapes[2] = new TiLine(p);
            p.brush = Brushes.Red;
            shapes[3] = new TiEllipse(p);
            p.brush = Brushes.LightSkyBlue;
            shapes[4] = new TiPolygon(p);
            p.brush = Brushes.White;
            shapes[5] = new TiCircle(p, 400);



            for (int i = 0; i < ellipse.Length; i++)
            {
                ellipse[i] = CreatePoint(points[i]);
                canvas1.Children.Add(ellipse[i]);
            }
          
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += timer_Tick;

            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            int height = (int)((Canvas)this.Content).RenderSize.Height;
            int width = (int)((Canvas)this.Content).RenderSize.Width;

            if (_movement_strategy == 1)
            {
                for (int i = 0; i < shapes.Length; i++)
                {

                }
                foreach (var item in shapes)
                {
                    item.RandomMovement(width, height);
                }
                for (int i = 0; i < ellipse.Length; i++)
                {
                    Canvas.SetLeft(ellipse[i], (double)points[i].X);
                    Canvas.SetTop(ellipse[i], (double)points[i].Y);
                    points[i].RandomMovement(width, height);
                }
               
            }
            else
            {
                Angle++;
                
            }
        }

        private Ellipse CreatePoint(tPoint point)
        {
            Ellipse el = new Ellipse();
            el.Width = 4;
            el.Height = 4;
            el.Fill = point.brush;
            return el;
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _movement_strategy = 1 - _movement_strategy;
        }
    }
}
