using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    public class Enemy : Unit
    {
        private Player Target;
        protected bool doRotation;
        private float attackRadius = 0.6f;
        private SoundEffect hitTarget;

        public Enemy(string Path, Vector2 Position, Vector2 Dimensions, Player Target) 
            : base(Path, Position, Dimensions)
        {
            this.Target = Target;
        }

        public void AI()
        {
            //Jämför avstånd mellan targets x och y

            float diffX = Math.Abs(position.X - Target.position.X);
            float diffY = Math.Abs(position.Y - Target.position.Y);

            float newRotation = rotation;

            //Flyttar åt x led och roterar åt spelarens håll

            if (diffX > diffY)
            {
                if (Target.position.X < position.X)
                {
                    position.X -= speed;
                    newRotation = Globals.RotationLogic(90);
                }

                else if (Target.position.X > position.X)
                {
                    position.X += speed;
                    newRotation = Globals.RotationLogic(270);
                }
            }

            //Flyttar åt y led och roterar åt spelarens håll

            else if (diffX < diffY)
            {
                if (Target.position.Y < position.Y)
                {
                    position.Y -= speed;
                    newRotation = Globals.RotationLogic(180);
                }

                else if (Target.position.Y > position.Y)
                {
                    position.Y += speed;
                    newRotation = Globals.RotationLogic(0);
                }
            }

            if (doRotation)
            {
                rotation = newRotation;
            }

            //Skadar spelaren

            if (Vector2.Distance(Target.position, position) < attackRadius)
            {
                hitTarget = Globals.content.Load<SoundEffect>("Sounds/Misc/hurt");
                hitTarget.Play();

                Target.health--;
            }

            if (health == 0)
            {
                dead = true;
            }

            if (dead)
            {
                Target.enemiesDefeated++;
            }
        }
            
        public override void Update()
        {
            AI();
            base.Update();
        }

        

        public override void Draw()
        {
            base.Draw();
        }
    }
}