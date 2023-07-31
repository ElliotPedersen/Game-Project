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
    public class UserInterface
    {
        Player player;
        List<InterfaceObject> interfaceObjects = new List<InterfaceObject>();
        InterfaceObject[] hearts = new InterfaceObject[3];
        public UserInterface(Player player)
        {
            this.player = player;

            interfaceObjects.Add(new InterfaceObject("UserInterface/item_frame", new Vector2(190, 25), new Vector2(16, 24)));
            interfaceObjects.Add(new InterfaceObject("UserInterface/sword", new Vector2(190, 25), new Vector2(7, 18)));
        }

        public void Update()
        {

            if (player.health == 0)
            {
                hearts[0] = new InterfaceObject("UserInterface/empty_heart_container", new Vector2(215, 35), new Vector2(7, 6));
                hearts[1] = new InterfaceObject("UserInterface/empty_heart_container", new Vector2(225, 35), new Vector2(7, 6));
                hearts[2] = new InterfaceObject("UserInterface/empty_heart_container", new Vector2(235, 35), new Vector2(7, 6));
            }

            if (player.health == 1)
            {
                hearts[0] = new InterfaceObject("UserInterface/heart_container", new Vector2(215, 35), new Vector2(7, 6));
                hearts[1] = new InterfaceObject("UserInterface/empty_heart_container", new Vector2(225, 35), new Vector2(7, 6));
                hearts[2] = new InterfaceObject("UserInterface/empty_heart_container", new Vector2(235, 35), new Vector2(7, 6));     
            }

            if (player.health == 2)
            {
                hearts[0] = new InterfaceObject("UserInterface/heart_container", new Vector2(215, 35), new Vector2(7, 6));
                hearts[1] = new InterfaceObject("UserInterface/heart_container", new Vector2(225, 35), new Vector2(7, 6));
                hearts[2] = new InterfaceObject("UserInterface/empty_heart_container", new Vector2(235, 35), new Vector2(7, 6));
            }

            if (player.health == 3)
            {
                hearts[0] = new InterfaceObject("UserInterface/heart_container", new Vector2(215, 35), new Vector2(7, 6));
                hearts[1] = new InterfaceObject("UserInterface/heart_container", new Vector2(225, 35), new Vector2(7, 6));
                hearts[2] = new InterfaceObject("UserInterface/heart_container", new Vector2(235, 35), new Vector2(7, 6));
            }
        }

        /// <summary>
        /// Ritar ut alla interface objekt
        /// </summary>

        public void Draw()
        {
            foreach (var heart in hearts)
            {
                heart.Draw();
            }

            foreach (var interfaceObject in interfaceObjects)
            {
                interfaceObject.Draw();
            }
        }
    }
}