using System;

namespace XNA.Pong
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            //PongConfigurationSection configurationSection =
            //    (PongConfigurationSection)
            //    System.Configuration.ConfigurationManager.GetSection("pongConfigurationGroup/pageAppearance");
            using (PongGame game = new PongGame())
            {
                game.Run();
            }
        }
    }
}

