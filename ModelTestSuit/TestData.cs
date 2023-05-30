using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using ModelTestSuit;
using Newtonsoft.Json;

namespace ModelTestSuit
{

    internal class TestData : DataAbstractApi
    {
        private List<IBall> ballList = new List<IBall>();
        Stopwatch stopWatch = new Stopwatch();
        private static ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
        private bool stop = false;


        public override IBall generateBall()
        {
            Random random = new Random();
            TestBall newBall = new TestBall(random.Next(100, 400 - 100), random.Next(100, 400 - 100));
            return newBall;
        }

        public override void Dispose()
        {
            stop = true;
            string data = "}}";
            queue.Enqueue(data);
            using (StreamWriter sw = File.AppendText("../../../../../output.json"))
            {
                while (queue.TryDequeue(out string line))
                {
                    sw.WriteLine(line);
                };
            }
        }


        public override void Start(int ballCount)
        {
            HeaderToWrite(ballCount);
            if (ballList != null) ballList.Clear();
            for (int i = 0; i < ballCount; i++)
            {
                IBall newBall;
                do
                {
                    newBall = generateBall();
                }
                while (CheckCollisions(ballList, newBall));
                ballList.Add(newBall);
            }
            stopWatch.Start();
            WriteToFile();
        }

        private bool Overlap(IBall b1, IBall b2)
        {
            double xDiff = b1.X - b1.X;
            double yDiff = b1.Y - b1.Y;
            double distance = Math.Sqrt((xDiff * xDiff) + (yDiff * yDiff));
            if (distance <= (b1.Diamiter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckCollisions(List<IBall> balls, IBall b1)
        {
            for (int i = 0; i < balls.Count; i++)
            {
                if (balls[i] != b1) continue;
                if (Overlap(balls[i], b1))
                {
                    return true;
                }
            }
            return false;
        }

        public override List<IBall> getBalls()
        {
            return ballList;
        }

        public override void PosToWrite(IBall ball, double x, double y)
        {
            stopWatch.Stop();
            TimeSpan timeSpan = stopWatch.Elapsed;
            stopWatch.Start();
            string time = timeSpan.ToString();
            string id = ball.GetHashCode().ToString();

            var data = new Dictionary<string, string>
            {
                { "X", x.ToString() },
                { "Y", y.ToString() },
                { "Time", time.ToString() }
            };

            var json = new Dictionary<string, object>
            {
                { id, data }
            };

            string jsonString = JsonConvert.SerializeObject(json);

            queue.Enqueue(jsonString);
        }

        private void HeaderToWrite(int ballCount)
        {
            FileStream file = File.Create("../../../../../output.json");
            StreamWriter sw = new StreamWriter(file);
            string data = "{TableWidth: 400, TableHeight: 420, BallsCount: \"" + ballCount + ", BallsDiameter: 20, balls: {";
            sw.WriteLine(data);
            sw.Flush();
            sw.Close();
        }

        public void WriteToFile()
        {
            Thread t = new Thread(() =>
            {
                while (!stop)
                {
                    using (StreamWriter sw = File.AppendText("../../../../../output.json"))
                    {
                        while (queue.TryDequeue(out string line))
                        {
                            sw.WriteLine(line);
                        }
                        sw.Flush();
                        sw.Close();
                        Thread.Sleep(100);

                    }
                }
            });
            t.Start();

        }
    }
}
