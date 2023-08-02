using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace ArcheroClone
{
    public class UnitAnimator : IAnimator
    {
        protected Animator _animator;

        [Inject]
        private void Init(Animator animator, IController controller, UnitData data, IShootSystem shootSystem)
        {
            _animator = animator;

            controller.OnMove += Move;
            data.OnDeath += Death;
            shootSystem.OnShoot += Shoot;
        }

        protected virtual void Move(Vector3 direction)
        {
            if (_animator == null)
                return;

            if (direction == Vector3.zero)
            {
                _animator.SetBool("IsMove", false);
            }
            else
            {
                _animator.SetBool("IsMove", true);
            }
        }

        private void Shoot()
        {
            _animator.SetTrigger("OnShoot");
        }

        private void Death()
        {
            _animator.SetTrigger("OnDeath");
        }
    }
}
