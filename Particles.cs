using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowLevelGraphicsGame
{
    public class Particle
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Pen LinePen { get; set; }
        public int Lifetime { get; set; } // Add a lifetime property in milliseconds
        public DateTime CreationTime { get; set; }

        public Particle(Point startPoint, Point endPoint, Pen linePen, int lifetime)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            LinePen = linePen;
            Lifetime = lifetime;
            CreationTime = DateTime.Now;
        }

        public void Update()
        {
            // Update the line position if needed
            StartPoint = new Point((int)(StartPoint.X - LinePen.Width), StartPoint.Y);
            EndPoint = new Point((int)(EndPoint.X - LinePen.Width), EndPoint.Y);
        }

        public bool IsExpired()
        {
            return (DateTime.Now - CreationTime).TotalMilliseconds >= Lifetime;
        }
    }

}
