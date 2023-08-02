namespace ArcheroClone
{
    public class FlyingCowboyMonoInstaller : UnitMonoInstaller
    {
        public override void InstallBindings()
        {
            base.InstallBindings();
            Controller();
        }

        protected override void ShootSystem()
        {
            var shootSystem = new DontUseShootSystem();
            Container
                .Bind<IShootSystem>()
                .FromInstance(shootSystem)
                .AsSingle();
            Container.QueueForInject(shootSystem);
        }

        private void Controller()
        {
            var controller = new FlyingCowboyController();
            Container
                .Bind<IController>()
                .FromInstance(controller)
                .AsSingle();
            Container.QueueForInject(controller);
        }

        protected override void UnitAnimator()
        {
            var animator = new DontUseAnimator();
            Container
                .Bind<IAnimator>()
                .FromInstance(animator)
                .AsSingle();
            Container.QueueForInject(animator);
        }
    }
} 
