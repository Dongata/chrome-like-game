using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace try2_Game.Player
{
    class Bird : MyRectangle
    {
        private Random seeder;
        private int timeout;
        private bool reset;

        public Bird(GraphicsDevice graphicsDevice, int timeout = 0) : base(graphicsDevice, Color.Lavender, 40, 10)
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
            new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height / 2 + 50);
    }
}
