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
    public class World
    {
        public Player player;
        public Rooms room;

        public bool IsCompleted { get { return objectsRoomFive.Count == 0; } }

        private UserInterface userInterface;
        
        private List<Enemy> objectsRoomTwo = new List<Enemy>();
        private List<Enemy> objectsRoomThree = new List<Enemy>();
        private List<Enemy> objectsRoomFour = new List<Enemy>();
        private List<Enemy> objectsRoomFive = new List<Enemy>();

        public World()
        {
            player = new Player(
                new string[] { "playerSprites/player_walking_down_1", "playerSprites/player_walking_down_2" },
                new string[] { "playerSprites/player_walking_up_1", "playerSprites/player_walking_up_2" },
                new string[] { "playerSprites/walking_left_1", "playerSprites/walking_left_2" },
                new string[] { "playerSprites/walking_right_1", "playerSprites/walking_right_2" },
                new string[] { "playerSprites/player_dead"},
                new string[] { "playerSprites/attack_down_1", },
                new string[] { "playerSprites/attack_up", },
                new string[] { "playerSprites/attack_left", },
                new string[] { "playerSprites/attack_right", },
                new Vector2(125, 125),
                new Vector2(15, 16),
                this
            );

            room = new Rooms(
                new string[] {
                    "Environment/room_one", 
                    "Environment/room_two", 
                    "Environment/room_three", 
                    "Environment/room_four", 
                    "Environment/room_five"}, 
                new Vector2(133, 125), 
                new Vector2(267, 150),
                player
            );

            userInterface = new UserInterface(player);

            objectsRoomTwo.Add(new Octorock("Enemies/octorock", new Vector2(125, 75), new Vector2(16, 14), player));
            objectsRoomTwo.Add(new Octorock("Enemies/octorock", new Vector2(125, 125), new Vector2(16, 14), player));
            objectsRoomTwo.Add(new Octorock("Enemies/octorock", new Vector2(125, 175), new Vector2(16, 14), player));

            objectsRoomThree.Add(new Octorock("Enemies/octorock", new Vector2(125, 75), new Vector2(16, 14), player));
            objectsRoomThree.Add(new Octorock("Enemies/octorock", new Vector2(125, 125), new Vector2(16, 14), player));
            objectsRoomThree.Add(new Octorock("Enemies/octorock", new Vector2(125, 175), new Vector2(16, 14), player));

            objectsRoomFive.Add(new Boss("Enemies/boss", new Vector2(133, 100), new Vector2(15, 32), player));
        }

        public List<Enemy> Enemies()
        {
            switch (room.currentRoom)
            {
                case 1:
                    return objectsRoomTwo;

                case 2:
                    return objectsRoomThree;

                case 4:
                    return objectsRoomFive;

                default:
                    return new List<Enemy>();
            }
        }

        /// <summary>
        /// Uppdaterar alla object i en lista
        /// </summary>
        /// <param name="_objects">Lista med objekt som ska uppdateras</param>

        private void updateObjects(List<Enemy> _objects)
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                _objects[i].Update();

                if (_objects[i].dead)
                {
                    _objects.Remove(_objects[i]);
                    i--;
                }
            }
        }

        /// <summary>
        /// Ritar alla object i en lista
        /// </summary>
        /// <param name="_objects">Lista med objekt som ska ritas</param>

        private void drawObjects(List<Enemy> _objects)
        {
            foreach (var _object in _objects)
            {
                _object.Draw();
            }
        }

        public virtual void Update()
        {
            room.Update();

            switch (room.currentRoom)
            {
                case 1:
                    updateObjects(objectsRoomTwo);
                    break;

                case 2:
                    updateObjects(objectsRoomThree);
                    break;

                case 4:
                    updateObjects(objectsRoomFive);
                    break;
            }

            player.Update();
            userInterface.Update();
        }

        public virtual void Draw()
        {
            room.Draw();

            switch (room.currentRoom)
            {
                case 1:
                    drawObjects(objectsRoomTwo);
                    break;

                case 2:
                    drawObjects(objectsRoomThree);
                    break;

                case 4:
                    drawObjects(objectsRoomFive);
                    break;
            }

            player.Draw();
            userInterface.Draw();
        }
    }
}