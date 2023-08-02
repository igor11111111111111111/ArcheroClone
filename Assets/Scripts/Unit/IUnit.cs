namespace ArcheroClone
{
    public interface IUnit : IObstacle
    {
        public UnitData UnitData { get;}
        public void TakeDamage(int damage);
    }
}
