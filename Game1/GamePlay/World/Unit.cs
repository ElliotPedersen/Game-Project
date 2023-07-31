using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    public class Unit : Object
    {
        private Stopwatch animationTimer;
        private float frameDuration = 250;
        private bool switchAnimation;
        private int currentFrame = 0;
        private string[] path;
        public string[] Path
        {
            get { return path; }
            set 
            { 
                path = value; 
                switchAnimation = true; 
            }
        }

        public bool playAnimation;
        public bool dead = false;
        public int health;
        public float speed;

        public Unit(string Path, Vector2 Position, Vector2 Dimensions)
            : base(Path, Position, Dimensions)
        {
        }

        public Unit(string[] Path, Vector2 Position, Vector2 Dimensions)
            : this(Path[0], Position, Dimensions)
        {
            this.Path = Path;

            animationTimer = new Stopwatch();
            animationTimer.Start();
        }

        public Unit()
        {

        }

        public override void Update()
        {
            if (animationTimer != null && playAnimation && (animationTimer.Elapsed.TotalMilliseconds > frameDuration || switchAnimation))
            {
                currentFrame++;

                if (currentFrame >= Path.Length)
                {
                    currentFrame = 0;
                }

                objectSprite = Globals.content.Load<Texture2D>(Path[currentFrame]);
                switchAnimation = false;
                animationTimer.Restart();
            }

            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}