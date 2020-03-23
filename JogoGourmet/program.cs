using System;

namespace JogoGournet
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new Jogo().Iniciar();
        }
    }
}
