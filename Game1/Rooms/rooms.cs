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
    public class Rooms : Object
    {
        public Texture2D roomSprite;
        public Vector2 Position, Dimensions;

        private Player Player;
        public Octorock Octorock;

        public string[] RoomSprite;
        public int currentRoom = 0;

        public Rooms(string[] RoomSprite, Vector2 Position, Vector2 Dimensions, Player Player): 
            base(RoomSprite[0], Position, Dimensions)
        {
            this.Player = Player;

            this.Position = Position;
            this.Dimensions = Dimensions;

            this.RoomSprite = RoomSprite;
        }

        public Rooms()
        {

        }

        /// <summary>
        /// Byter rum.
        /// </summary>
        /// <param name="newRoom">Index för nytt rum som ska laddas.</param>
        /// <param name="newPosition">Position för spelaren när den går in i ett rum.</param>
        private void changeRoom(int newRoom, Vector2 newPosition)
        {
            currentRoom = newRoom;
            objectSprite = Globals.content.Load<Texture2D>(RoomSprite[currentRoom]);
            Player.position = newPosition;
        }

        public override void Update()
        {
            switch (currentRoom)
            {
                case 0:
                    if (Player.position.X > 267)
                        changeRoom(1, new Vector2(0, Player.position.Y));

                    if (Player.position.X < 0)
                        changeRoom(2, new Vector2(267, Player.position.Y));

                    if (Player.position.X > 79 && Player.position.X < 96 && Player.position.Y > 75 && Player.position.Y < 85)
                        changeRoom(3, new Vector2(133, 185));

                    if (Player.position.Y < 50)
                        changeRoom(4, new Vector2(Player.position.X, 150));

                    if (Player.position.X > 170 && Player.position.X < 267 && Player.position.Y > 50 && Player.position.Y < 110)
                    {
                        Player.position.X -= 1;
                        Player.position.Y += 1;
                    }

                    if (Player.position.X > 170 && Player.position.X < 267 && Player.position.Y > 138 && Player.position.Y < 200)
                    {
                        Player.position.X -= 1;
                        Player.position.Y -= 1;
                    }

                    if (Player.position.X > 79 && Player.position.X < 171 && Player.position.Y > 158 && Player.position.Y < 200)
                    {
                        Player.position.X += 1;
                        Player.position.Y -= 1;
                    }

                    if (Player.position.X > 0 && Player.position.X < 80 && Player.position.Y > 123 && Player.position.Y < 200)
                    {
                        Player.position.X += 1;
                        Player.position.Y -= 1;
                    }
                    
                    if (Player.position.X > 0 && Player.position.X < 80 && Player.position.Y > 50 && Player.position.Y < 100)
                    {
                        Player.position.X += 1;
                        Player.position.Y += 1;
                    }
                    
                    if (Player.position.X > 95 && Player.position.X < 125 && Player.position.Y > 50 && Player.position.Y < 85)
                    {
                        Player.position.X += 1;
                        Player.position.Y += 1;
                    }

                    if (Player.position.X > 0 && Player.position.X < 125 && Player.position.Y > 50 && Player.position.Y < 75)
                    {
                        Player.position.X += 1;
                        Player.position.Y += 1;
                    }

                    break;

                case 1:
                    if (Player.position.X < 0)
                        changeRoom(0, new Vector2(267, Player.position.Y));

                    if (Player.position.X > 245 && Player.position.X < 267 && Player.position.Y > 50 && Player.position.Y < 200)
                    {
                        Player.position.X -= 1;
                        Player.position.Y += 1;
                    }

                    if (Player.position.X > 0 && Player.position.X < 267 && Player.position.Y > 50 && Player.position.Y < 60)
                    {
                        Player.position.X -= 1;
                        Player.position.Y += 1;
                    }

                    if (Player.position.X > 0 && Player.position.X < 267 && Player.position.Y > 170 && Player.position.Y < 200)
                    {
                        Player.position.X -= 1;
                        Player.position.Y -= 1;
                    }

                    if (Player.position.X > 0 && Player.position.X < 20 && Player.position.Y > 140 && Player.position.Y < 200)
                    {
                        Player.position.X += 1;
                        Player.position.Y -= 1;
                    }

                    if (Player.position.X > 0 && Player.position.X < 20 && Player.position.Y > 50 && Player.position.Y < 90)
                    {
                        Player.position.X += 1;
                        Player.position.Y += 1;
                    }

                    break;

                case 2:
                    if (Player.position.X > 267)
                        changeRoom(0, new Vector2(0, Player.position.Y));

                    if (Player.position.X > 0 && Player.position.X < 20 && Player.position.Y > 50 && Player.position.Y < 200)
                    {
                        Player.position.X += 1;
                        Player.position.Y += 1;
                    }

                    if (Player.position.X > 0 && Player.position.X < 267 && Player.position.Y > 50 && Player.position.Y < 60)
                    {
                        Player.position.X += 1;
                        Player.position.Y += 1;
                    }

                    if (Player.position.X > 0 && Player.position.X < 267 && Player.position.Y > 170 && Player.position.Y < 200)
                    {
                        Player.position.X += 1;
                        Player.position.Y -= 1;
                    }

                    if (Player.position.X > 245 && Player.position.X < 267 && Player.position.Y > 140 && Player.position.Y < 200)
                    {
                        Player.position.X -= 1;
                        Player.position.Y -= 1;
                    }

                    if (Player.position.X > 245 && Player.position.X < 267 && Player.position.Y > 50 && Player.position.Y < 90)
                    {
                        Player.position.X -= 1;
                        Player.position.Y += 1;
                    }

                    break;

                case 3:
                    if (Player.position.Y > 185)
                        changeRoom(0, new Vector2(90, 85));

                    if (Player.position.X > 0 && Player.position.X < 267 && Player.position.Y > 50 && Player.position.Y < 65)
                    {
                        Player.position.X -= 1;
                        Player.position.Y += 1;
                    }

                    if (Player.position.X > 0 && Player.position.X < 20 && Player.position.Y > 50 && Player.position.Y < 200)
                    {
                        Player.position.X += 1;
                        Player.position.Y += 1;
                    }

                    if (Player.position.X > 247 && Player.position.X < 267 && Player.position.Y > 49 && Player.position.Y < 200)
                    {
                        Player.position.X -= 1;
                        Player.position.Y -= 1;
                    }

                    if (Player.position.X > 0 && Player.position.X < 100 && Player.position.Y > 180 && Player.position.Y < 200)
                    {
                        Player.position.X += 1;
                        Player.position.Y -= 1;
                    }

                    if (Player.position.X > 167 && Player.position.X < 267 && Player.position.Y > 180 && Player.position.Y < 200)
                    {
                        Player.position.X -= 1;
                        Player.position.Y -= 1;
                    }

                    break;

                case 4:
                    if (Player.position.Y > 190)
                        changeRoom(0, new Vector2(Player.position.X, 50));

                    if (Player.position.X > 0 && Player.position.X < 267 && Player.position.Y > 50 && Player.position.Y < 65)
                    {
                        Player.position.X -= 1;
                        Player.position.Y += 1;
                    }

                    if (Player.position.X > 0 && Player.position.X < 20 && Player.position.Y > 50 && Player.position.Y < 200)
                    {
                        Player.position.X += 1;
                        Player.position.Y += 1;
                    }

                    if (Player.position.X > 255 && Player.position.X < 267 && Player.position.Y > 49 && Player.position.Y < 200)
                    {
                        Player.position.X -= 1;
                        Player.position.Y -= 1;
                    }

                    if (Player.position.X > 0 && Player.position.X < 85 && Player.position.Y > 175 && Player.position.Y < 200)
                    {
                        Player.position.X += 1;
                        Player.position.Y -= 1;
                    }

                    if (Player.position.X > 190 && Player.position.X < 267 && Player.position.Y > 175 && Player.position.Y < 200)
                    {
                        Player.position.X -= 1;
                        Player.position.Y -= 1;
                    }

                    break;
            }
            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}