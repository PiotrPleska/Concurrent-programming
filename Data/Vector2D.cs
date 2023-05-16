using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Vector2D
    {
            private double X;
            private double Y;

            public double GetX() => X;
            public double GetY() => Y;

        internal void AddAssign(Vector2D other)
            {
                X += other.X;
                Y += other.Y;
            }
        public static bool CheckCollision(Vector2D ball, Vector2D b)
        {
            double result = (ball.X - b.X) * (ball.X - b.X) + (ball.Y - b.Y) * (ball.Y - b.Y);
            return result >= 0;
        }
    
    public Vector2D Subtract(Vector2D vector2D) { return new Vector2D(X-vector2D.X,Y-vector2D.Y); }
            public double Multiply() { return (X * X) + (Y * Y); }

            public Vector2D Add(double number1, double number2) { return new Vector2D(X+number1,Y+number2); }
        public Vector2D SubractScalar(double number1, double number2) { return new Vector2D(X - number1, Y - number2); }

        public static bool operator >= (Vector2D vector1, Vector2D vector2)
            {
            return (vector1.X >= vector2.X) || (vector1.Y >= vector2.Y);
            }

        public static bool operator <=(Vector2D vector1, Vector2D vector2)
        {
            return (vector1.X <= vector2.X) || (vector1.Y <= vector2.Y);
        }

        public static Vector2D operator -(Vector2D vector1)
        {
            return new Vector2D(-vector1.X, -vector1.Y);
        }

        public Vector2D(double x, double y)
            {
                X = x;
                Y = y;
            }
        }
}
