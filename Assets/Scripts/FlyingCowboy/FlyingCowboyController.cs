using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace ArcheroClone
{
    public class FlyingCowboyController : IController
    {
        public Action<Vector3> OnMove { get; set; }
        private UnitData _data;
        private Transform _enemy;
        private NavMeshAgent _navMeshAgent;

        [Inject] 
        private void Init(UnitData data, AllUnitsInfo allUnits, NavMeshAgent agent)
        {
            var enemy = allUnits.GetPlayer();
            _data = data;
            _enemy = enemy.transform;
            _navMeshAgent = agent;

            Update();
        }

        private async void Update()
        {
            while (this != null && _data != null && _data.IsAlive)
            {
                await Task.Delay(200);

                if (_data.IsAlive == false && _navMeshAgent != null)
                    _navMeshAgent.isStopped = true;

                if (_enemy == null)
                    return;

                var target = _enemy.position;
                OnMove?.Invoke(Vector3.one);
                _navMeshAgent.destination = target;
            }
        }
    }
}
