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
    public class Boss : Enemy
    {
        public Boss(string Path, Vector2 Position, Vector2 Dimensions, Player Target)
            : base(Path, Position, Dimensions, Target)
        {
            speed = 0.5f;
            doRotation = false;
            health = 5;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}