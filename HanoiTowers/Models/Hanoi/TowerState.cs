using Newtonsoft.Json;

namespace HanoiTowers.Models.Hanoi
{
    public class TowerState
    {
        public const string tower1Name = "1";
        public const string tower2Name = "2";
        public const string tower3Name = "3";
        public TowerState(NamedTower tower1, NamedTower tower2, NamedTower tower3, Queue<SolveStep> solveSteps)
        {
            this.tower1 = tower1;
            this.tower2 = tower2;
            this.tower3 = tower3;
            this.solveSteps = solveSteps;
        }

        public NamedTower tower1 { get; set; } = new NamedTower(new Stack<Disk>(), tower1Name);
        public NamedTower tower2 { get; set; } = new NamedTower(new Stack<Disk>(), tower2Name);
        public NamedTower tower3 { get; set; } = new NamedTower(new Stack<Disk>(), tower3Name);
        public Queue<SolveStep> solveSteps { get; set; } = new Queue<SolveStep>();

        private const string fileName = "./HanoiTower.txt";
        public void WriteToFile()
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(this);
                writer = new StreamWriter(fileName, false);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public static TowerState ReadFromFile()
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(fileName);
                var fileContents = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<TowerState>(fileContents);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
