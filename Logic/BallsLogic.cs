using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Data;
using Microsoft.VisualBasic;

namespace Logic
{
    public class BallsLogic: INotifyPropertyChanged

    {
        private Ball ball;

        public event PropertyChangedEventHandler? PropertyChanged;

        public double Y
        {
            get { return ball.Y; }
            private set
            {
                if (ball.Y == value)
                    return;
                ball.Y = value;
            }
        }

        public double X
        {
            get { return ball.X; }
            private set
            {
                if (ball.X == value)
                    return;
                    ball.X = value;
            }
        }


        public double Diameter {
            get
            {
                return ball.diameter;
            }
        }

        public BallsLogic(Ball ball)
        {
            this.ball = ball;
            ball.PropertyChanged += UpdateCoordinates;
        }

        private void UpdateCoordinates(object sender, EventArgs e)
        {

            X = ball.X;
            Y = ball.Y;
            borderColision(ball);
            RaisePropertyChanged("X");
            RaisePropertyChanged("Y");
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void borderColision(Ball ball)
        {


            if ((ball.X + ball.diameter) >= 395)
            {

                ball.X = 395 - ball.diameter;
            }
            if ((ball.X - ball.diameter) <= 0)
            {
                ball.X = ball.diameter;
            }
            if ((ball.Y + ball.diameter) >= 415)
            {
                ball.Y = 415 - ball.diameter;
            }
            if ((ball.Y - ball.diameter) <= 0)
            {
                ball.Y = ball.diameter;
            }

        }


    }
}
