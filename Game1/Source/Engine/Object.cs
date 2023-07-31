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
    public class Object
    {
        public float rotation;

        public Vector2 position, dimensions, frameSize;

        public Texture2D objectSprite;

        public Object(string Path, Vector2 Position, Vector2 Dimensions)
        {
            position = Position;
            dimensions = Dimensions;

            objectSprite = Globals.content.Load<Texture2D>(Path);
        }

        public Object()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {
            Globals.spriteBatch.Draw(objectSprite, new Rectangle((int)position.X, (int)position.Y, (int)dimensions.X, (int)dimensions.Y), null, Color.White, rotation, new Vector2(objectSprite.Width / 2f, objectSprite.Height / 2f), new SpriteEffects(), 0f);
        }
    }
}
