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
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace GameProject
{
    public class Dead
    {
        private Text text;
        public Song gameOver;

        public Dead()
        {
            text = new Text("Text/smaller_text", "Press 'Space' To Retry", new Vector2(0, 0), Color.White);
        }

        public void Update()
        {
            text.Update();
        }

        public void Draw()
        {
            text.Draw();
        }
    }
}
