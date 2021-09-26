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

        AbstractShape[] shapes;

        TiEllipse[] tiEllipses = new TiEllipse[3];

        TiCircle[] tiCircles = new TiCircle[3];

        TiLine[] tiLines = new TiLine[5];

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

            for(int i = 0; i < tiLines.Length;i++)
            {
                brush = new SolidColorBrush(Color.FromArgb(255, (byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)));
                tPoint p = new tPoint(width / 2, height / 2, brush);
                tiLines[i] = new TiLine(p);
                canvas1.Children.Add(tiLines[i].line);
            }
            /*for (int i = 0; i < linesPoints.Length; i++)
            {
                SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(255, (byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)));
                tPoint[] p = new tPoint[2];
                p[0] = new tPoint(rnd.Next() % width, rnd.Next() % height, brush);
                p[1] = new tPoint(p[0].X + 50,p[0].Y + 50, brush);
                linesPoints[i] = new TiShape(brush, p);
            }*/
/*            for (int i = 0; i < linesPoints.Length; i++)
            {
                line[i] = CreateLine(linesPoints[i]);
                canvas1.Children.Add(line[i]);
            }*/

            for (int i = 0; i < ellipse.Length; i++)
            {
                ellipse[i] = CreatePoint(points[i]);
                canvas1.Children.Add(ellipse[i]);
            }

            for (int i = 0; i < tiEllipses.Length; i++)
            {
                 brush = new SolidColorBrush(Color.FromArgb(255, (byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)));
                tPoint p = new tPoint(width / 2, height / 2, brush);
                tiEllipses[i] = new TiEllipse(p);
                canvas1.Children.Add(tiEllipses[i].ellipse);
            }

            for (int i = 0; i < tiCircles.Length; i++)
            {
                brush = new SolidColorBrush(Color.FromArgb(255, (byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)));
                tPoint p = new tPoint(width / 2, height / 2, brush);
                tiCircles[i] = new TiCircle(p);
                canvas1.Children.Add(tiCircles[i].ellipse);
            }
/*
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
            }*/
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
                for (int i = 0; i < tiLines.Length; i++)
                {

                    tiLines[i].RandomMovement(width, height);
                }

                for (int i = 0; i < tiEllipses.Length; i++)
                {
                    tiEllipses[i].ellipse.RenderTransform = new RotateTransform(0);
                    Canvas.SetLeft(tiEllipses[i].ellipse, tiEllipses[i].X);
                    Canvas.SetTop(tiEllipses[i].ellipse, tiEllipses[i].Y);
                    tiEllipses[i].RandomMovement(width - (int)tiEllipses[i].ellipse.Width, height - (int)tiEllipses[i].ellipse.Height);

                    tiCircles[i].ellipse.RenderTransform = new RotateTransform(0);
                    Canvas.SetLeft(tiCircles[i].ellipse, tiCircles[i].X);
                    Canvas.SetTop(tiCircles[i].ellipse, tiCircles[i].Y);
                    tiCircles[i].RandomMovement(width - (int)tiCircles[i].ellipse.Width, height - (int)tiCircles[i].ellipse.Height);
                }
        /*        for (int i = 0; i < polygons.Length; i++)
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
                }*/
            }
            else
            {
                Angle++;
                /*   for (int i = 0; i < rectangls.Length; i++)
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
                   }*/
                for (int i = 0; i <tiCircles.Length; i++)
                {
                    int X = (int)tiCircles[i].ellipse.Width / 2;
                    int Y = (int)tiCircles[i].ellipse.Height / 2;
                    tiCircles[i].ellipse.RenderTransform = new RotateTransform(Angle, X, Y);
                }
                for (int i = 0; i < tiEllipses.Length; i++)
                {
                    int X = (int)tiEllipses[i].ellipse.Width/2;
                    int Y = (int)tiEllipses[i].ellipse.Height/2;
                    tiEllipses[i].ellipse.RenderTransform = new RotateTransform(Angle,X,Y);
                }
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
        /*        private Line CreateLine(TiShape line)
                {
                    Line l = new Line();
                    l.X1 = line.points[0].X;
                    l.X2 = line.points[1].X;
                    l.Y1 = line.points[0].Y;
                    l.Y2 = line.points[1].Y;
                    l.Stroke = line.brush;
                    return l;
                }*/


        /* private Polygon CreatePolygon(TiShape polygon)
          {
              Polygon polygon1 = new Polygon();
              polygon1.Fill = polygon.brush;
              foreach (var point in polygon.points)
              {
                  polygon1.Points.Add(new Point(point.X, point.Y));
              }
              return polygon1;
          }
  */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _movement_strategy = 1 - _movement_strategy;
        }
    }
}
