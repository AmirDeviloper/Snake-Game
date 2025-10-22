namespace Snake
{
    public enum Direction
    {
        U,
        D,
        L,
        R
    };

    public class Settings
    {
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static int Points { get; set; }
        public static bool GameOver { get; set; }
        public static bool Pause { get; set; }
        public static bool PowerUp { get; set; }
        public static bool PowerDown { get; set; }

        public Settings()
        {
            PowerDown = PowerUp = false;
            Width = 16;
            Height = 16;
            Points = 12;
            GameOver = Pause = false;
        }
    }


}
