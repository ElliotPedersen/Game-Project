﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    public class Timer
    {
        public bool goodToGo;
        protected int mSec;
        protected TimeSpan timer = new TimeSpan();


        public Timer(int m)
        {
            goodToGo = false;
            mSec = m;
        }
        public Timer(int m, bool StartLoaded)
        {
            goodToGo = StartLoaded;
            mSec = m;
        }

        public int MSec
        {
            get { return mSec; }
            set { mSec = value; }
        }
        public int MTimer
        {
            get { return (int)timer.TotalMilliseconds; }
        }



        public void UpdateTimer()
        {
            timer += Globals.gameTime.ElapsedGameTime;
        }

        public void UpdateTimer(float Speed)
        {
            timer += TimeSpan.FromTicks((long)(Globals.gameTime.ElapsedGameTime.Ticks * Speed));
        }

        public virtual void AddToTimer(int MSec)
        {
            timer += TimeSpan.FromMilliseconds((long)(MSec));
        }

        public bool Test()
        {
            if (timer.TotalMilliseconds >= mSec || goodToGo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            timer = timer.Subtract(new TimeSpan(0, 0, mSec / 60000, mSec / 1000, mSec % 1000));
            if (timer.TotalMilliseconds < 0)
            {
                timer = TimeSpan.Zero;
            }
            goodToGo = false;
        }

        public void Reset(int NewTimer)
        {
            timer = TimeSpan.Zero;
            MSec = NewTimer;
            goodToGo = false;
        }

        public void ResetToZero()
        {
            timer = TimeSpan.Zero;
            goodToGo = false;
        }

        public virtual XElement ReturnXML()
        {
            XElement xml = new XElement("Timer",
                                    new XElement("mSec", mSec),
                                    new XElement("timer", timer));



            return xml;
        }

        public void SetTimer(TimeSpan Time)
        {
            timer = Time;
        }

        public virtual void SetTimer(int MSec)
        {
            timer = TimeSpan.FromMilliseconds((long)(MSec));
        }
    }
}
