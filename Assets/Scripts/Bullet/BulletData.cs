namespace ArcheroClone
{
    public class BulletData
    {
        public float MoveSpeed;
        public float LiveTime;
        public int Damage;

        public BulletData(float moveSpeed, float liveTime, int damage)
        {
            MoveSpeed = moveSpeed;
            LiveTime = liveTime;
            Damage = damage;
        }
    }
}
