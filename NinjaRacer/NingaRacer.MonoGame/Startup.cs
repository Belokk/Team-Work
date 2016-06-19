﻿namespace NingaRacer.MonoGame
{
    using System;

#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            using (var game = new GameLoop())
            {
                game.Run();
            }
        }
    }
#endif
}
