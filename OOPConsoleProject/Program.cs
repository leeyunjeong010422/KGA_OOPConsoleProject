using OOPConsoleProject.Players;

namespace OOPConsoleProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Player player = new Player(game);
            game.Run();
        }
    }
}
