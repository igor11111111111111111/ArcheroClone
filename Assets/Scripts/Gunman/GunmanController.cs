using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace ArcheroClone
{
    public class GunmanController : IController
    {
        public Action<Vector3> OnMove { get; set; }
        private UnitData _data;
        private Transform _enemy;
        private NavMeshAgent _navMeshAgent;
        private float _moveTime;
        private float _shootTime;

        [Inject]
        private void Init(UnitData data, AllUnitsInfo allUnits, NavMeshAgent agent)
        {
            var enemy = allUnits.GetPlayer();
            _data = data;
            _enemy = enemy.transform;
            _navMeshAgent = agent;
            _shootTime = 1.5f;
            _moveTime = 0.8f;

            Update();
        }

        private async void Update()
        {
            while (this != null && _data != null && _data.IsAlive)
            {
                OnMove?.Invoke(Vector3.zero);

                await Task.Delay((int)(_shootTime * 1000));

                if (_enemy == null)
                    return;
                var target = _enemy.position;
                OnMove?.Invoke(Vector3.one);
                _navMeshAgent.isStopped = false;
                _navMeshAgent.destination = target;

                await Task.Delay((int)(_moveTime * 1000));

                if (_navMeshAgent == null)
                    return;
                _navMeshAgent.isStopped = true;

                await Task.Delay(100);
            }
        }
    }
}
