using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace try2_Game.Player
{
    class Floor : MyRectangle
    {
        public Floor(GraphicsDevice graphicsDevice) 
            : base(graphicsDevice,  Color.Red, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height/3)
        {
            pos = new Vector2(0, graphicsDevice.Viewport.Height - this.Height);
        }
    }
}
