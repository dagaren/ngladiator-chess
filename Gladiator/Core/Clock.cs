using Gladiator.Representation;
using Gladiator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Core
{
    class Clock : IClock
    {
        private ITimeControl timeControl;

        private TimeSpan[] times;

        private int[] numMoves;

        private DateTime startTime;

        private Colour turn;

        public Clock(ITimeControl timeControl)
        {
            Check.ArgumentNotNull(timeControl, "timeControl");

            this.timeControl = timeControl;
            this.times = new TimeSpan[2];
            this.numMoves = new int[2] { 0, 0 };
        }

        public void Start()
        {
            this.turn = Colour.White;
            this.numMoves[Colour.White.Value()] = 1;
            this.numMoves[Colour.Black.Value()] = 1;
            this.times[this.turn.Value()] = this.timeControl.PreMoveTime(
                this.numMoves[this.numMoves[this.turn.Value()]], 
                TimeSpan.FromSeconds(0));
            this.startTime = DateTime.Now;
        }

        public void Change()
        {
            DateTime finishTime = DateTime.Now;
            TimeSpan thinkingTime = finishTime - startTime;

            this.times[this.turn.Value()] -= thinkingTime;
            this.times[this.turn.Value()] = this.timeControl.PostMoveTime(
                this.numMoves[this.turn.Value()], 
                this.times[this.turn.Value()]);

            this.numMoves[this.turn.Value()]++;

            this.turn = this.turn.Opponent();
            this.times[this.turn.Value()] = this.timeControl.PreMoveTime(
                this.numMoves[this.turn.Value()], 
                this.times[this.turn.Value()]);

            //Console.WriteLine("White Time: {0:0.##} seconds, Black Time: {1:0.##} seconds", this.times[Colour.White.Value()].TotalSeconds, this.times[Colour.Black.Value()].TotalSeconds);

            startTime = DateTime.Now;
        }

        public TimeSpan GetRemainingTime(Colour colour)
        {
            TimeSpan time = this.times[colour.Value()];

            if(colour == turn)
            {
                time -= (DateTime.Now - startTime);
            }

            return time;
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Resume()
        {
            throw new NotImplementedException();
        }

        public int GetMovesToNextTimeControl(Colour colour)
        {
            return this.timeControl.GetMovesToNextControl(this.numMoves[colour.Value()]);
        }

        public TimeSpan IncrementPerMove(Colour colour)
        {
            return this.timeControl.GetIncrement(this.numMoves[colour.Value()]);
        }
    }
}
