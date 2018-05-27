using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace try2_Game.Player
{
    class Cactus : MyRectangle
    {
        public Cactus(GraphicsDevice graphicsDevice) : base(graphicsDevice, Color.Green, 20, 100)
        {
            pos = InitialPosition();
        }

        public float SpeedX { get; set; }

        public void Update() {
            if (pos.X < 0)
                pos = InitialPosition();
            pos.X = pos.X - SpeedX;
        }

        private Vector2 InitialPosition() {
            return new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height / 2);
        }
    }
}
