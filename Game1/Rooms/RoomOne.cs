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
    public class RoomOne
    {
        public Texture2D roomSprite;
        public Vector2 position, dimensions;
        public RoomOne(string Path, Vector2 Position, Vector2 Dimensions)
        {
            position = Position;
            dimensions = Dimensions;

            roomSprite = Globals.content.Load<Texture2D>(Path);
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {
            Globals.spriteBatch.Draw(roomSprite, new Rectangle((int)(position.X), (int)(position.Y), (int)dimensions.X, (int)dimensions.Y), null, Color.White, 0.0f, new Vector2(roomSprite.Bounds.Width / 2, roomSprite.Bounds.Height / 2), new SpriteEffects(), 0);
        }
    }
}
