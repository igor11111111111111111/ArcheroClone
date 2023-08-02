using System;

namespace ArcheroClone
{
    public class UnitData
    {
        public Action OnDeath;
        public bool IsAlive;
        public bool UnderImmune;
        public UnitMonobehaviour Target;

        public readonly int CollisionDamage;
        public readonly float MoveSpeed;
        public readonly float ShootCD;
        public readonly HealthData HealthData;
        public readonly float ImmuneTime;

        public UnitData(int collisionDamage, float moveSpeed, float shootCD, HealthData healthData) 
        {
            CollisionDamage = collisionDamage;
            MoveSpeed = moveSpeed;
            ShootCD = shootCD;
            HealthData = healthData;
            IsAlive = true;
            UnderImmune = false;
            ImmuneTime = 0.5f;

            HealthData.OnDeath += () =>
            {
                OnDeath?.Invoke();
                IsAlive = false;
            };
        }
    }
}