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
    public class Pause
    {
        private Text text;
        private Screens screens;
        
        public Pause()
        {
            text = new Text("Text/text", "Press 'Space' To Continue", new Vector2(30, 175), Color.White);
            screens = new Screens(
                "Screens/paused_screen", 
                new Vector2(133, 100),
                new Vector2(267, 200)
                );
        }

        public virtual void Update()
        {
            screens.Update();
            text.Update();
        }

        public virtual void Draw()
        {
            screens.Draw();
            text.Draw();
        }
    }
}
