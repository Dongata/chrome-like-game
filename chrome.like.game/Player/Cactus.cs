using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace try2_Game.Player
{
    class Cactus : MyRectangle
    {
        private bool reset = false;
        private int timeout = 0;
        private Random seeder;

        public Cactus(GraphicsDevice graphicsDevice, int timeout = 0) : base(graphicsDevice, Color.Green, 20, 100)
        {
            pos = InitialPosition();
            seeder = new Random();
            this.timeout = timeout;
            this.reset = timeout > 0;
        }

        public float SpeedX { get; set; }

        public void Update()
        {
            if (reset && timeout <= 0)
            {
                pos = InitialPosition();
                reset = false;
            }

            if (this.Pos.X < -this.Width && !reset)
            {
                reset = true;
                timeout = seeder.Next(40, 120);
            }

            if (reset)
            {
                timeout = timeout - 1;
            }

            if (!reset)
            {
                pos.X = pos.X - SpeedX;
            }
        }

        private Vector2 InitialPosition() => 
            new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height / 2);
    }
}
