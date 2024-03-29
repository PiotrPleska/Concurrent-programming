﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Logic;

namespace ModelTestSuit
{
    internal class TestLogic : LogicAbstractApi
    {
        private TestLogicBall LogicBall;
        internal static DataAbstractApi dataLayerr;

        private List<ILogicBall> Table = new List<ILogicBall>();
        internal TestLogic(DataAbstractApi dataLayer = null)
        {

            if (dataLayer != null) { dataLayerr = dataLayer; }
            else { dataLayerr = DataAbstractApi.CreateApi(); }

        }


        public override void Dispose()
        {
            foreach (ILogicBall b in Table)
            {
                b.Dispose();
            }
            dataLayerr.Dispose();
        }


        public override List<ILogicBall> GetBalls()
        {
            if (Table != null) Table.Clear();
            foreach (IBall b in dataLayerr.getBalls())
            {
                Table.Add(new TestLogicBall(b));
            }
            return Table;
        }

        public override void Start(int ballCount)
        {
            dataLayerr.Start(ballCount);
        }
    }
}
