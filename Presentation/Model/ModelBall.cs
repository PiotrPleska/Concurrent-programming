﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Logic;
using Microsoft.VisualBasic;

namespace Model
{
    public class ModelBall : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private double diameter;

        public ModelBall(BallsLogic ball)
        {
            this.x = ball.X;
            this.y = ball.Y;
            this.diameter = ball.Diameter;
            ball.PropertyChanged += Notify;
        }

        private void Notify(object source, PropertyChangedEventArgs ev)
        {
            BallsLogic sourceOrb = (BallsLogic)source;
            RaisePropertyChanged(ev.PropertyName);
        }

        public double Y
        {
            get { return y; }
            private set
            {
                if (y == value)
                    return;
                RaisePropertyChanged("Y");
            }
        }

        public double X
        {
            get { return y; }
            private set
            {
                if (y == value)
                    return;
                RaisePropertyChanged();
            }
        }

        public double Diameter { get; internal set; }





        public event PropertyChangedEventHandler? PropertyChanged;


        protected void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}