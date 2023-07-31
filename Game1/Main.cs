using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;

namespace GameProject
{
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        public string currentState;
        
        private Text stopWatch;
        private Text enemiesDefeated;

        public float time = 0;

        World world;
        Pause pause;
        Menu menu;
        Complete complete;
        Dead dead;
        Song song;
        Song gameOver;
                
        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Window.Title = "The Legend of A Real G";
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();
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

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.content = this.Content;
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

            currentState = "Titlescreen";

            world = new World();
            pause = new Pause();
            menu = new Menu();
            complete = new Complete();
            dead = new Dead();

            song = Globals.content.Load<Song>("Sounds/Music/music");
            gameOver = Globals.content.Load<Song>("Sounds/Music/gameOver");

            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);

            AliveMusic();
        }

        protected override void UnloadContent()
        {
        }

        private void States(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Globals.gameTime = gameTime;

            if (currentState == "Playing")
            {
                time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            
            if (currentState == "Playing" && Keyboard.IsPressed(Keys.P))
            {
                currentState = "Paused";
            }
            
            if (currentState == "Paused" && Keyboard.IsPressed(Keys.Space))
            {
                currentState = "Playing";
            }

            if (currentState == "Titlescreen" && Keyboard.IsPressed(Keys.Space))
            {
                currentState = "Playing";
            }

            if (currentState == "Playing" && world.player != null && world.player.dead)
            {
                currentState = "Dead";
                DeadMusic();
            }

            if (currentState == "Dead" && Keyboard.IsPressed(Keys.Space))
            {
                world = new World();
                currentState = "Playing";
                time = 0;
                AliveMusic();
            }

            if (currentState == "Playing" && world.IsCompleted)
            {
                currentState = "Complete";

                if ((IO.ReadTime() > time || IO.ReadTime() == 0) && IO.ReadDefeated() <= world.player.enemiesDefeated)
                {
                    IO.WriteTime((int)time);
                    IO.WriteDefeated(world.player.enemiesDefeated);
                }
            }

            if (currentState == "Complete" && Keyboard.IsPressed(Keys.Space))
            {
                Exit();
            }
        }

        private void AliveMusic()
        {
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.15f;
        }

        private void DeadMusic()
        {
            MediaPlayer.Play(gameOver);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.15f;
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            States(gameTime);

            if (currentState == "Titlescreen")
            {
                menu.Update();
            }

            if (currentState == "Dead")
            {
                dead.Update();
            }

            if (currentState == "Playing")
            {
                world.Update();
            }

            if (currentState == "Paused")
            {
                pause.Update();
            }

            if (currentState == "Complete")
            {
                complete.Update();
            }
                        
            stopWatch = new Text("Text/smaller_text", $"Elapsed Time: {time.ToString("0")}", new Vector2(0, 35), Color.White);
            enemiesDefeated = new Text("Text/smaller_text", $"Enemies Defeated: {world.player.enemiesDefeated}", new Vector2(0, 25), Color.White);
            
            base.Update(gameTime);
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            Globals.spriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointClamp, null, null, null, Matrix.CreateScale(3f));

            if (currentState == "Titlescreen")
            {
                menu.Draw();
            }
            
            if (currentState == "Playing")
            {
                world.Draw();
                stopWatch.Draw();
                enemiesDefeated.Draw();
            }

            if (currentState == "Dead")
            {
                world.Draw();
                stopWatch.Draw();
                enemiesDefeated.Draw();
                dead.Draw();
            }

            if (currentState == "Paused")
            {
                pause.Draw();
            }

            if (currentState == "Complete")
            {
                world.Draw();
                stopWatch.Draw();
                enemiesDefeated.Draw();
                complete.Draw();
            }
                        
            Globals.spriteBatch.End();
            base.Draw(gameTime);
        }
    }

#if WINDOWS || LINUX
    public static class Program
    {
        static void Main()
        {
            using (var game = new Main())
                game.Run();
        }
    }
#endif
}