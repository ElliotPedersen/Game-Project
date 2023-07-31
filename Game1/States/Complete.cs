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
    public class Complete
    {
        private Text text;
        private Text credit;
        private Screens screens;
        
        public Complete()
        {
            text = new Text("Text/text", "Press 'Space' To Exit", new Vector2(45, 175), Color.White);
            credit = new Text("Text/text", "Music by fyoum", new Vector2(70, 85), Color.White);

            screens = new Screens(
                "Screens/victory_screen", 
                new Vector2(133, 100),
                new Vector2(267, 200)
                );
        }

        public virtual void Update()
        {
            screens.Update();
            text.Update();
            credit.Update();
        }

        public virtual void Draw()
        {
            screens.Draw();
            text.Draw();
            credit.Draw();
        }
    }
}
