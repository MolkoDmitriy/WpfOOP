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

        TiShape[] linesPoints = new TiShape[5];
        Line[] line = new Line[5];

        TiEllipse[] ell_points = new TiEllipse[3];
        Ellipse[] ell = new Ellipse[3];

        TiCircle[] circle_points = new TiCircle[3];
        Ellipse[] circles = new Ellipse[3];

        TiShape[] polygon_points = new TiShape[5];
        Polygon[] polygons= new Polygon[5];

        TiShape[] rectangle_points = new TiShape[5];
        Polygon[] rectangls = new Polygon[5];

        int Angle = 2;
        private void Canvas1_Loaded(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int height = (int)((Canvas)this.Content).RenderSize.Height;
            int width = (int)((Canvas)this.Content).RenderSize.Width;


            for (int i = 0; i < points.Length; i++)
            {
                SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(255, (byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)));
                points[i] = new tPoint(rnd.Next() % width, rnd.Next() % height, brush);

            }
            for (int i = 0; i < linesPoints.Length; i++)
            {
                SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(255, (byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)));
                tPoint[] p = new tPoint[2];
                p[0] = new tPoint(rnd.Next() % width, rnd.Next() % height, brush);
                p[1] = new tPoint(p[0].X + 50,p[0].Y + 50, brush);
                linesPoints[i] = new TiShape(brush, p);
            }
            for (int i = 0; i < linesPoints.Length; i++)
            {
                line[i] = CreateLine(linesPoints[i]);
                canvas1.Children.Add(line[i]);
            }

            for (int i = 0; i < ellipse.Length; i++)
            {
                ellipse[i] = CreatePoint(points[i]);
                canvas1.Children.Add(ellipse[i]);
            }

            for (int i = 0; i < ell.Length; i++)
            {
                SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(255, (byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)));
                tPoint p = new tPoint(width/2,height/2, brush);
                ell_points[i] = new TiEllipse(p);
                ell[i] = CreateEllips(ell_points[i]);
                canvas1.Children.Add(ell[i]);


                tPoint d = new tPoint(width / 2, height / 2, brush);
                circle_points[i] = new TiCircle(d);
                circles[i] = new Ellipse();
                circles[i].Width = circle_points[i].rad;
                circles[i].Height = circle_points[i].rad;
                circles[i].Fill = circle_points[i].center.brush;
                canvas1.Children.Add(circles[i]);
            }

            for (int i = 0; i < polygon_points.Length; i++)
            {
                SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(255, (byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)));
                tPoint[] p = new tPoint[3];
                p[0] = new tPoint(width / 2, height / 2, brush);
                p[1] = new tPoint(p[0].X, p[0].Y + 100);
                p[2] = new tPoint(p[1].X + 100, p[1].Y);
                polygon_points[i] = new TiShape(brush, p);
                polygons[i] = CreatePolygon(polygon_points[i]);
                canvas1.Children.Add(polygons[i]);
            }

            for (int i = 0; i < rectangle_points.Length; i++)
            {
                SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(255, (byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)));
                tPoint[] r = new tPoint[4];
                r[0] = new tPoint(width / 2, height / 2,brush);
                r[1] = new tPoint(r[0].X, r[0].Y + 100, brush);
                r[2] = new tPoint(r[0].X - 100, r[0].Y+100, brush);
                r[3] = new tPoint(r[0].X - 100, r[0].Y, brush);

                rectangle_points[i] = new TiShape(brush, r);
                rectangls[i] = CreatePolygon(rectangle_points[i]);
                canvas1.Children.Add(rectangls[i]);
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
                for (int i = 0; i < ellipse.Length; i++)
                {
                    Canvas.SetLeft(ellipse[i], (double)points[i].X);
                    Canvas.SetTop(ellipse[i], (double)points[i].Y);
                    points[i].RandomMovement(width, height);
                }
                for (int i = 0; i < line.Length; i++)
                {
                    linesPoints[i].RandomMovement(width, height);
                    line[i].X1 = linesPoints[i].points[0].X;
                    line[i].X2 = linesPoints[i].points[1].X;
                    line[i].Y1 = linesPoints[i].points[0].Y;
                    line[i].Y2 = linesPoints[i].points[1].Y;
                }

                for (int i = 0; i < ell.Length; i++)
                {
                    Canvas.SetLeft(ell[i], ell_points[i].X);
                    Canvas.SetTop(ell[i], ell_points[i].Y);
                    ell_points[i].RandomMovement(width - ell_points[i].rad_x, height - ell_points[i].rad_y);

                    Canvas.SetLeft(circles[i], circle_points[i].center.X);
                    Canvas.SetTop(circles[i], circle_points[i].center.Y);
                    circle_points[i].center.RandomMovement(width - circle_points[i].rad, height - circle_points[i].rad);
                }
                for (int i = 0; i < polygons.Length; i++)
                {
                    polygons[i].RenderTransform = new RotateTransform(0);
                    polygons[i].Points.Clear();
                    polygon_points[i].RandomMovement(width, height);
                    foreach (var point in polygon_points[i].points)
                    {
                        polygons[i].Points.Add(new Point(point.X, point.Y));
                    }
                }
                for (int i = 0; i < rectangls.Length; i++)
                {
                    rectangls[i].RenderTransform = new RotateTransform(0);
                    rectangls[i].Points.Clear();
                    rectangle_points[i].RandomMovement(width, height);
                    foreach (tPoint point in rectangle_points[i].points)
                    {
                        rectangls[i].Points.Add(new Point(point.X, point.Y));
                    }
                }
            }
            else
            {
                Angle++;
                for (int i = 0; i < rectangls.Length; i++)
                {
                    int X = rectangle_points[i].points[0].X - 50;
                    int Y = rectangle_points[i].points[0].Y + 50;
                    rectangls[i].RenderTransform = new RotateTransform(Angle,X,Y);
                }
                for (int i = 0; i < polygons.Length; i++)
                {
                    int X = polygon_points[i].points[0].X+50;
                    int Y = polygon_points[i].points[0].Y+50;
                    polygons[i].RenderTransform = new RotateTransform(Angle,X,Y);
                }
                for (int i = 0; i < ell.Length; i++)
                {
                    int X = ell_points[i].X + ell_points[i].rad_x / 2;
                    int Y = ell_points[i].Y + ell_points[i].rad_y / 2;
                    ell[i].RenderTransform = new RotateTransform(Angle,X,Y);
                }
            }
        }
        private Line CreateLine(TiShape line)
        {
            Line l = new Line();
            l.X1 = line.points[0].X;
            l.X2 = line.points[1].X;
            l.Y1 = line.points[0].Y;
            l.Y2 = line.points[1].Y;
            l.Stroke = line.brush;
            return l;
        }
        private Ellipse CreatePoint(tPoint point)
        {
            Ellipse el = new Ellipse();
            el.Width = 4;
            el.Height = 4;
            el.Fill = point.brush;
            return el;
        }

        private Ellipse CreateEllips(TiEllipse ellipse)
        {
            Ellipse el = new Ellipse();
            el.Width = ellipse.rad_x;
            el.Height = ellipse.rad_y;
            el.Fill = ellipse.brush;
            return el;
        }
       private Polygon CreatePolygon(TiShape polygon)
        {
            Polygon polygon1 = new Polygon();
            polygon1.Fill = polygon.brush;
            foreach (var point in polygon.points)
            {
                polygon1.Points.Add(new Point(point.X, point.Y));
            }
            return polygon1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _movement_strategy = 1 - _movement_strategy;
        }
    }
}
