using System.Collections.Generic;
using try2_Game.Player;

namespace try2_Game
{
    class CollisonHandler
    {
        private List<MyRectangle> enemies;
        private Dinosaur player;

        public CollisonHandler(Dinosaur player, List<MyRectangle> enemies)
        {
            this.player = player;
            this.enemies = enemies;
        }

        public bool IsAnyColisson()
        {
            foreach (var enemy in enemies)
            {
                if (player.Collides(enemy))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
