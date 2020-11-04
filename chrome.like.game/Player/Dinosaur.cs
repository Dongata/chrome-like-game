using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace try2_Game.Player
{
    class Dinosaur: IDisposable
    {
        private float speedY;
        private float speedX;
        private float initialHeight;
        private Vector2 position;
        private Vector2 duckingPosition;

        private bool isJumping;
        private bool isDucking;

        private GraphicsDevice GraphicsDevice;
        private Texture2D duckingTexture;
        private Texture2D walkingTexture;
        private Color color;

        public Dinosaur(GraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;
            position = InitialPosition;
            duckingPosition = InitialPosition;
            duckingPosition.Y += 70;

            initialHeight = 100;
            isJumping = false;
            SpeedY = 0;

            duckingTexture = new Texture2D(graphicsDevice, 50, 40);
            duckingTexture.SetData(DinosaurSprites.DuckingTextureData());

            walkingTexture = new Texture2D(graphicsDevice, 30, 100);
            walkingTexture.SetData(DinosaurSprites.WalkingTextureData());

            color = Color.Black;
        }

        public float SpeedX
        {
            get => speedX;
            set => speedX = value;
        }

        public float SpeedY
        {
            get => speedY;
            set => speedY = value;
        }

        public Vector2 InitialPosition => new Vector2(GraphicsDevice.Viewport.Width /4, GraphicsDevice.Viewport.Height / 2);

        public float Width => isDucking ? duckingTexture.Width : walkingTexture.Width;
        public float Height => isDucking ? duckingTexture.Height : walkingTexture.Height;
        public Vector2 Pos => position;

        public void HandleKeyboard(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                isDucking = true;
            }
            else
            {
                isDucking = false;
            }

            if (keyboardState.IsKeyDown(Keys.Space))
            {
                if (!isJumping)
                {
                    SpeedY = 20;
                    isJumping = true;
                }
            }
        }

        public void Update()
        {
            if (isJumping)
            {
                SpeedY -= GameConfig.WorldStatics.Gravity;
                position.Y -= SpeedY;
            }

            if (position.Y >= InitialPosition.Y)
            {
                this.position = InitialPosition;
                isJumping = false;
            }
        }

        public void DrawMe(SpriteBatch spriteBatch)
        {
            if (isDucking)
            {
                spriteBatch.Draw(duckingTexture, duckingPosition, color);
            }
            else
            {
                spriteBatch.Draw(walkingTexture, position, color);
            }
        }

        internal bool Collides(MyRectangle enemy)
        {
            if (this.Pos.X < enemy.Pos.X + enemy.Width &&
               this.Pos.X + this.Width > enemy.Pos.X &&
               this.position.Y < enemy.Pos.Y + enemy.Height &&
               this.Height + this.Pos.Y > enemy.Pos.Y)
            {
                return true;
            }

            return false;
        }

        public void Dispose()
        {
            duckingTexture.Dispose();
            walkingTexture.Dispose();
        }
    }
}
