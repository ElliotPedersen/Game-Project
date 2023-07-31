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
using System.IO;

namespace GameProject
{
    public class Menu
    {
        private Text text;
        private Text highscore;
        public Text enemiesDefeated;
        public Text completionTime;
        private Screens screens;
        public Menu()
        {
            

            text = new Text("Text/text", "Press 'Space' To Start", new Vector2(50, 175), Color.Black);
            highscore = new Text("Text/smaller_text", "Current High-Score", new Vector2(80, 75), Color.Black);

            enemiesDefeated = new Text("Text/smaller_text", $"Enemies Defeated: {IO.ReadDefeated()}", new Vector2(75, 85), Color.Black);

            completionTime = new Text("Text/smaller_text", $"Completion Time: {IO.ReadTime()} seconds", new Vector2(45, 95), Color.Black);

            screens = new Screens(
                "Screens/title_screen", 
                new Vector2(133, 100), 
                new Vector2(267, 200)
                );
        }

        public virtual void Update()
        {
            screens.Update();
            highscore.Update();
            enemiesDefeated.Update();
            completionTime.Update();
            text.Update();
        }

        public virtual void Draw()
        {
            screens.Draw();
            highscore.Draw();
            enemiesDefeated.Draw();
            completionTime.Draw();
            text.Draw();
        }
    }
}
