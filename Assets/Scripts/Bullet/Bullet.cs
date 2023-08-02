using UnityEngine;

namespace ArcheroClone
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody _rigidbody;
        [SerializeField]
        private BulletTrigger _trigger;
        private BulletData _data;
        private ParticlePool _particlePool;

        public void CreateInit(BulletData data)
        {
            _data = data;
            _trigger.OnFindObstacle += Destroy;
        }

        public void ShootInit(Transform parent, Vector3 direction, ParticlePool particlePool, UnitMonobehaviour unit)
        {
            _particlePool = particlePool;
            _trigger.Init(unit);
            transform.SetPositionAndRotation(parent.position, parent.rotation);
            transform.position += new Vector3(0, 1, 0);
            _rigidbody.AddForce((direction - parent.transform.position).normalized * _data.MoveSpeed, ForceMode.Impulse);
            Invoke(nameof(Destroy), _data.LiveTime);
        }

        private void Destroy(IObstacle obstacle)
        {
            if(obstacle is IUnit)
            {
                (obstacle as IUnit).TakeDamage(_data.Damage);
            }
            CancelInvoke(nameof(Destroy));
            _rigidbody.velocity = Vector3.zero;
            gameObject.SetActive(false);
            _particlePool.Play(transform);
        }
    }
}
