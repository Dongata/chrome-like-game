namespace try2_Game
{
    public static class GameConfig
    {
        public static class WorldStatics
        {
            private static float gameSpeed = 2;
            private static float gravity = 0.5f;

            public static float GameSpeed => gameSpeed;
            public static float Gravity => gravity;

            public static void SetGameSpeed(float newGameSpeed) {
                gameSpeed = newGameSpeed;
            }
        }
    }
}
