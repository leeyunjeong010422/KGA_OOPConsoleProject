namespace OOPConsoleProject.Scenes
{
    public class MapData
    {
        public char[,] Maze { get; }
        public List<(int x, int y)> Monsters { get; set; }
        public List<(int x, int y)> Goals { get; set; }
        public List<(int x, int y)> Potions { get; set; }
        public string MapName { get; }

        public MapData(char[,] maze, List<(int x, int y)> monsters, List<(int x, int y)> goals, List<(int x, int y)> potions, string mapName)
        {
            Maze = maze;
            Monsters = monsters;
            Goals = goals;
            Potions = potions;
            MapName = mapName;
        }
    }
}
