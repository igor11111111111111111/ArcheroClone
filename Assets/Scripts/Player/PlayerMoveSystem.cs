using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace ArcheroClone
{
    public class PlayerMoveSystem : IMoveSystem
    {
        private UnitData _data;
        private Transform _transform;
        private Vector3 _direction;

        [Inject]
        private void Init(IController controller, Rigidbody rigidbody, UnitData data, Transform transform)
        {
            _data = data;
            _transform = transform;

            controller.OnMove += (direction) =>
            {
                if(_data.IsAlive)
                {
                    _direction = direction;
                    Move(rigidbody);
                }
            };
        }

        private void Move(Rigidbody rigidbody)
        {
            if(_direction == Vector3.zero)
            {
                rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            }
            rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            _transform.LookAt(_transform.position + _direction);
            rigidbody.velocity = _direction * _data.MoveSpeed;
        }
    }
}
