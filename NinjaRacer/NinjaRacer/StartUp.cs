namespace NinjaRacer.MonoGame
{
    using System;

#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class StartUp
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            using (var game = new GameVisualization())
            {
                game.Run();
            }
        }
    }
#endif
}
