using System;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace ArcheroClone
{
    public abstract class UnitMonoInstaller : MonoInstaller
    {
        private UnitData _data;
        public void Init(UnitData data)
        {
            _data = data;
        }

        public override void InstallBindings()
        {
            MonoInstaller();
            Transform();
            Rigidbody();
            DefaultAnimator();
            NavMeshAgent();
            Data();
            MonoBehaviour();
            ShootSystem();
            MoveSystem();
            UnitAnimator();
        }

        private void MonoBehaviour()
        {
            var unit = GetComponent<UnitMonobehaviour>();
            Container
                .Bind<UnitMonobehaviour>()
                .FromInstance(unit)
                .AsSingle();
            Container.QueueForInject(unit);
        }

        private void MonoInstaller()
        {
            Container
                .Bind<UnitMonoInstaller>()
                .FromInstance(this)
                .AsSingle();
        }

        private void Transform()
        {
            Container
                .Bind<Transform>()
                .FromInstance(transform)
                .AsSingle();
        }

        private void Rigidbody()
        {
            Container
                .Bind<Rigidbody>()
                .FromInstance(GetComponent<Rigidbody>())
                .AsSingle();
        }

        private void DefaultAnimator()
        {
            Container
                .Bind<Animator>()
                .FromInstance(GetComponentInChildren<Animator>())
                .AsSingle();
        }

        private void NavMeshAgent()
        {
            Container
                .Bind<NavMeshAgent>()
                .FromInstance(GetComponent<NavMeshAgent>())
                .AsSingle();
        }

        private void Data()
        {
            Container
                .Bind<UnitData>()
                .FromInstance(_data)
                .AsSingle();
        }

        protected virtual void UnitAnimator()
        {
            var animator = new UnitAnimator();
            Container
                .Bind<IAnimator>()
                .FromInstance(animator)
                .AsSingle();
            Container.QueueForInject(animator);
        }

        protected virtual void ShootSystem()
        {

        }
        protected virtual void MoveSystem()
        {

        }
    }
}
