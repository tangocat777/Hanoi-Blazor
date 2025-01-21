namespace HanoiTowers.Models.Hanoi
{
    public class NamedTower
    {
        public Stack<Disk> tower { get; set; } = new Stack<Disk>();
        public string towerName { get; set; } = TowerState.tower1Name;

        public NamedTower(Stack<Disk> tower, string towerName)
        {
            this.tower = tower;
            this.towerName = towerName;
        }

        public NamedTower()
        {

        }
    }
}
