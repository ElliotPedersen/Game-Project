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
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace GameProject
{
    public class Player : Unit
    {
        public int enemiesDefeated;
                        
        private string[] PathDown;
        private string[] PathUp;
        private string[] PathLeft;
        private string[] PathRight;
        private string[] PathDead;
        private string[] AttackDown;
        private string[] AttackUp;
        private string[] AttackLeft;
        private string[] AttackRight;
        private string currentAnimation;
        private float attackRadius = 10f;

        private World world;
        private SoundEffect attackSound;

        public Player(
            string[] PathDown,
            string[] PathUp,
            string[] PathLeft,
            string[] PathRight,
            string[] PathDead,
            string[] AttackDown,
            string[] AttackUp,
            string[] AttackLeft,
            string[] AttackRight,
            Vector2 Position,
            Vector2 Dimensions,
            World world
            )
            : base(PathDown, Position, Dimensions)
        {
            speed = 1.0f;
            health = 3;

            currentAnimation = "Down";

            this.PathDown = PathDown;
            this.PathUp = PathUp;
            this.PathLeft = PathLeft;
            this.PathRight = PathRight;
            this.PathDead = PathDead;
            this.AttackDown = AttackDown;
            this.AttackUp = AttackUp;
            this.AttackLeft = AttackLeft;
            this.AttackRight = AttackRight;
            this.world = world;
        }

        public class Keyboard
        {
            static KeyboardState currentKeyState;
            static KeyboardState previousKeyState;

            public static KeyboardState GetState()
            {
                previousKeyState = currentKeyState;
                currentKeyState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
                return currentKeyState;
            }

            public static bool IsPressed(Keys key)
            {
                return currentKeyState.IsKeyDown(key);
            }

            public static bool HasBeenPressed(Keys key)
            {
                return currentKeyState.IsKeyDown(key) && !previousKeyState.IsKeyDown(key);
            }
        }

        public void PlayerMovement()
        {
            var kbs = Keyboard.GetState();

            playAnimation = false;

            if (kbs.IsKeyDown(Keys.Up))
            {
                position.Y -= speed;
                playAnimation = true;

                if (currentAnimation != "Up")
                {
                    Path = PathUp;
                    currentAnimation = "Up";
                }
            }

            else if (kbs.IsKeyDown(Keys.Down))
            {
                position.Y += speed;
                playAnimation = true;

                if (currentAnimation != "Down")
                {
                    Path = PathDown;
                    currentAnimation = "Down";
                }
            }

            else if (kbs.IsKeyDown(Keys.Left))
            {
                position.X -= speed;
                playAnimation = true;

                if (currentAnimation != "Left")
                {
                    Path = PathLeft;
                    currentAnimation = "Left";
                }
            }

            else if (kbs.IsKeyDown(Keys.Right))
            {
                position.X += speed;
                playAnimation = true;

                if (currentAnimation != "Right")
                {
                    Path = PathRight;
                    currentAnimation = "Right";
                }
            }

            if (dead)
            {
                speed = 0;
                playAnimation = true;

                if (currentAnimation != "Dead")
                {
                    Path = PathDead;
                    currentAnimation = "Dead";
                }
            }

            if (Keyboard.IsPressed(Keys.Z) && currentAnimation == "Down")
            {
                playAnimation = true;

                if (currentAnimation != "AttackDown")
                {
                    Path = AttackDown;
                    currentAnimation = "AttackDown";
                }

            }

            else if (kbs.IsKeyUp(Keys.Z) && currentAnimation == "AttackDown")
            {
                playAnimation = true;
                PlayerAttack();

                if (currentAnimation != "Down")
                {
                    Path = PathDown;
                    currentAnimation = "Down";
                }
            }

            if (Keyboard.IsPressed(Keys.Z) && currentAnimation == "Up")
            {
                playAnimation = true;

                if (currentAnimation != "AttackUp")
                {
                    Path = AttackUp;
                    currentAnimation = "AttackUp";
                }
            }

            else if (kbs.IsKeyUp(Keys.Z) && currentAnimation == "AttackUp")
            {
                playAnimation = true;
                PlayerAttack();

                if (currentAnimation != "Up")
                {
                    Path = PathUp;
                    currentAnimation = "Up";
                }
            }

            if (Keyboard.IsPressed(Keys.Z) && currentAnimation == "Left")
            {
                playAnimation = true;

                if (currentAnimation != "AttackLeft")
                {
                    Path = AttackLeft;
                    currentAnimation = "AttackLeft";
                }
            }

            else if (kbs.IsKeyUp(Keys.Z) && currentAnimation == "AttackLeft")
            {
                playAnimation = true;
                PlayerAttack();

                if (currentAnimation != "Left")
                {
                    Path = PathLeft;
                    currentAnimation = "Left";
                }
            }

            if (Keyboard.IsPressed(Keys.Z) && currentAnimation == "Right")
            {
                playAnimation = true;

                if (currentAnimation != "AttackRight")
                {
                    Path = AttackRight;
                    currentAnimation = "AttackRight";
                }
            }

            else if (kbs.IsKeyUp(Keys.Z) && currentAnimation == "AttackRight")
            {
                playAnimation = true;
                PlayerAttack();

                if (currentAnimation != "Right")
                {
                    Path = PathRight;
                    currentAnimation = "Right";
                }
            }
        }

        private void PlayerAttack()
        {
            attackSound = Globals.content.Load<SoundEffect>("Sounds/Misc/playerAttack");
            attackSound.Play();

            foreach (Enemy Enemy in world.Enemies())
            {
                if (Vector2.Distance(Enemy.position, position) < attackRadius)
                {
                    Enemy.health--;
                }
            }
        }

        private void PlayerLogic()
        {
            if (health <= 0)
            {
                dead = true;
            }

            PlayerMovement();
        }

        public override void Update()
        {
            PlayerLogic();
            base.Update();
        }
        
        public override void Draw()
        {
            base.Draw();
        }
    }
}