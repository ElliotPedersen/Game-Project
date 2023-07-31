using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    public static class Globals
    {
        public static Object objects;
        public static int screenHeight, screenWidth;

        public static ContentManager content;
        public static SpriteBatch spriteBatch;
        public static GameTime gameTime;
        
        /// <summary>
        /// Returnerar vinklar i grader istället för radianer
        /// </summary>
        /// <param name="Rotation"></param>
        /// <returns></returns>
        public static float RotationLogic(float Rotation)
        {
            float angle = 0;

            if (Rotation == 90)
            {
                angle = (float)Math.PI / 2.0f;
            }

            else if (Rotation == 180)
            {
                angle = (float)Math.PI;
            }

            else if (Rotation == 270)
            {
                angle = (float)Math.PI * 3 / 2.0f;
            }

            else if (Rotation == 45)
            {
                angle = (float)Math.PI / 4.0f;
            }

            else if (Rotation == 135)
            {
                angle = (float)Math.PI * 3 / 4.0f;
            }

            else if (Rotation == 225)
            {
                angle = (float)Math.PI * 5 / 4.0f;
            }

            else if (Rotation == 315)
            {
                angle = (float)Math.PI * 7 / 4.0f;
            }

            return angle;
        }
    }
}