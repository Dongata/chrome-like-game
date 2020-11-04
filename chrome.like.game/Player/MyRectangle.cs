using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace try2_Game.Player
{
    class MyRectangle : Texture2D
    {
        private Color color;
        protected Vector2 pos;

        public MyRectangle(GraphicsDevice graphicsDevice, Color color, int width, int height) : base(graphicsDevice, width, height, false, SurfaceFormat.Color)
        {
            this.color = color;
            var data = new Color[this.Width * this.Height];

            for (var i = 0; i < data.Length; ++i)
                data[i] = color;

            this.SetData(data);
        }

        public Vector2 Pos => pos;

        internal bool Collides(MyRectangle enemy)
        {
            if (this.Pos.X < enemy.Pos.X + enemy.Width &&
               this.Pos.X + this.Width > enemy.Pos.X &&
               this.pos.Y < enemy.Pos.Y + enemy.Height &&
               this.Height + this.Pos.Y > enemy.Pos.Y)
            {
                return true;
            }

            return false;
        }

        public virtual void DrawMe(SpriteBatch spriteBatch)
        {
            var position = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
            spriteBatch.Draw(this, pos, null, Color.Wheat, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
