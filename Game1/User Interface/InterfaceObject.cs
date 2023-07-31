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
    public class InterfaceObject
    {
        float rotation;

        public Vector2 position, dimensions, frameSize;

        Texture2D interfaceSprite;
        public InterfaceObject(string Path, Vector2 Position, Vector2 Dimensions)
        {
            position = Position;
            dimensions = Dimensions;

            interfaceSprite = Globals.content.Load<Texture2D>(Path);
        }

        /// <summary>
        /// Ritar ut interface objektet
        /// </summary>

        public void Draw()
        {
            Globals.spriteBatch.Draw(interfaceSprite, new Rectangle((int)position.X, (int)position.Y, (int)dimensions.X, (int)dimensions.Y), null, Color.White, rotation, new Vector2(interfaceSprite.Width / 2f, interfaceSprite.Height / 2f), new SpriteEffects(), 0f);
        }
    }
}
