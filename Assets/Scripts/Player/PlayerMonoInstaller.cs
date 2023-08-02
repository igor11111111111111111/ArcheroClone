using UnityEngine;

namespace ArcheroClone
{
    public class PlayerMonoInstaller : UnitMonoInstaller
    {
        public override void InstallBindings()
        {
            base.InstallBindings();
        }

        protected override void ShootSystem()
        {
            var shootSystem = new AimShootSystem();
            Container
                .Bind<IShootSystem>()
                .FromInstance(shootSystem)
                .AsSingle();
            Container.QueueForInject(shootSystem);
        }

        protected override void MoveSystem()
        {
            var moveSystem = new PlayerMoveSystem();
            Container
                .Bind<IMoveSystem>()
                .FromInstance(moveSystem)
                .AsSingle();
            Container.QueueForInject(moveSystem);
        }
    }
}
