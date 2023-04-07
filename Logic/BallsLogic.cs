﻿using System;
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
    public class BallsLogic : INotifyPropertyChanged
    {
        private Ball ball;
        public event PropertyChangedEventHandler PropertyChanged;

        public double Y
        {
            get { return ball.Y; }
            private set
            {
                if (ball.Y == value)
                    return;
                RaisePropertyChanged("Y");
            }
        }

        public double X
        {
            get { return ball.X; }
            private set
            {
                if (ball.X == value)
                    return;
                RaisePropertyChanged();
            }
        }

        public double Diameter { get; internal set; }

        public BallsLogic(Ball ball)
        {
            this.ball = ball;
            ball.PropertyChanged += Notify;
        }
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Notify(object source, PropertyChangedEventArgs ev)
        {
            RaisePropertyChanged(ev.PropertyName);
        }


    }
}