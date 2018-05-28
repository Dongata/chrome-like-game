using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using try2_Game.Player;

namespace try2_Game
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class try2 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Dinosaur dinosaur;
        Floor floor;
        Cactus cactus;
        Cactus cactus2;
        private Bird bird;
        CollisonHandler collisonHandler;
        SpriteFont gameOverText;

        bool recentlyUpdated = false;
        bool gameOver = false;

        public try2()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            dinosaur = new Dinosaur(GraphicsDevice);
            floor = new Floor(GraphicsDevice);
            cactus = new Cactus(GraphicsDevice);
            cactus2 = new Cactus(GraphicsDevice, 300);
            bird = new Bird(GraphicsDevice, 5000);
            collisonHandler = new CollisonHandler(dinosaur, new List<MyRectangle>() { cactus, cactus2 });
            gameOverText = Content.Load<SpriteFont>("GameOverFont");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            base.UnloadContent();
            spriteBatch.Dispose();
            // If you are creating your texture (instead of loading it with
            // Content.Load) then you must Dispose of it
            dinosaur.Dispose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (!gameOver)
            {
                if (collisonHandler.IsAnyColisson())
                {
                    gameOver = true;
                }

                dinosaur.HandleKeyboard(Keyboard.GetState());

                cactus.SpeedX = GameConfig.WorldStatics.GameSpeed;
                cactus2.SpeedX = GameConfig.WorldStatics.GameSpeed;
                bird.SpeedX = GameConfig.WorldStatics.GameSpeed;
                cactus.Update();
                cactus2.Update();
                dinosaur.Update();
                bird.Update();
                Console.WriteLine(cactus2.Pos.X);

                if (((int)gameTime.TotalGameTime.TotalSeconds) % 10 == 0)
                {
                    GameConfig.WorldStatics.SetGameSpeed(GameConfig.WorldStatics.GameSpeed + 0.05f);
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            if (!gameOver)
            {
                floor.DrawMe(spriteBatch);
                dinosaur.DrawMe(spriteBatch);
                cactus.DrawMe(spriteBatch);
                cactus2.DrawMe(spriteBatch);
                bird.DrawMe(spriteBatch);
            }
            else
            {
                spriteBatch.DrawString(
                    gameOverText, 
                    "GameOver", 
                    new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), 
                    Color.Black);
            }

            //drawrect(_dinosaur);
            spriteBatch.End();
        }        
    }
}
