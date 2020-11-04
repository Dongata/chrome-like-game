using Microsoft.Xna.Framework;

namespace try2_Game.Player
{
    public static class DinosaurSprites
    {
        public static Color[] WalkingTextureData() {
            var color = new Color[100 * 30];
            for (var i = 0; i < color.Length; i++)
            {
                color[i] = Color.Black;
            }

            return color;
        }

        public static Color[] DuckingTextureData()
        {
            var color = new Color[40 * 50];
            for (var i = 0; i < color.Length; i++)
            {
                color[i] = Color.Black;
            }

            return color;
        }
    }
}
