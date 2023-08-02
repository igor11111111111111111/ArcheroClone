namespace ArcheroClone
{

    public class GunmanMonoInstaller : UnitMonoInstaller
    {
        public override void InstallBindings()
        {
            base.InstallBindings();
            Controller();
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

        private void Controller()
        {
            var controller = new GunmanController();
            Container
                .Bind<IController>()
                .FromInstance(controller)
                .AsSingle();
            Container.QueueForInject(controller);
        }
    }
} 
