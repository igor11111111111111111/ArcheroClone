namespace ArcheroClone
{
    public class TurrelmanMonoInstaller : UnitMonoInstaller
    { 
        public override void InstallBindings()
        {
            base.InstallBindings();
            Controller();
        }

        protected override void ShootSystem()
        {
            var shootSystem = new TurrelShootSystem();
            Container
                .Bind<IShootSystem>()
                .FromInstance(shootSystem)
                .AsSingle();
            Container.QueueForInject(shootSystem);
        }

        private void Controller()
        {
            var controller = new IdleController();
            Container
                .Bind<IController>()
                .FromInstance(controller)
                .AsSingle();
            Container.QueueForInject(controller);
        }
    }
} 
