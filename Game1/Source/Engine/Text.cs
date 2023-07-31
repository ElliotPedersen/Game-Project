using Microsoft.Xna.Framework;
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
    public class Text
    {
        public Vector2 Position;
        public string Content;
        public Color Color;
        SpriteFont spriteFont;

        public Text(string Path, string Content, Vector2 Position, Color Color)
        {
            this.Position = Position;
            this.Content = Content;
            this.Color = Color;

            spriteFont = Globals.content.Load<SpriteFont>(Path);
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {
            Globals.spriteBatch.DrawString(spriteFont, Content, Position, Color);

        }
    }
}
