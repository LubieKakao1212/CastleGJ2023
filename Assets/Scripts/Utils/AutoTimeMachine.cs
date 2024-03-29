﻿using System;

namespace Utils
{
    //One of my premade utilities
    public class AutoTimeMachine
    {
        public double Interval { get; set; }
        public Action Action { get; set; }
        
        private readonly TimeMachine machine;
        
        public AutoTimeMachine(Action action, double interval) 
        {
            Action = action;
            Interval = interval;
            machine = new TimeMachine();
        }

        /// <summary>
        /// Forwards the time by given amount, triggers assigned action relevant amount of times
        /// </summary>
        /// <param name="time">Amount of time to forward by</param>
        public void Forward(double time)
        {
            machine.Accumulate(time);
            int rolls = machine.RetrieveAll(Interval);
            for (int i = 0; i < rolls; i++)
            { 
                Action();
            }
        }

        /// <summary>
        /// Delays the next invocation of the assigned action by <paramref name="time"/>, resulting delay with never be larger than <see cref="Interval"/>
        /// </summary>
        /// <param name="time"></param>
        public void Delay(double time)
        {
            machine.Retrieve(time);
        }
    }
}
