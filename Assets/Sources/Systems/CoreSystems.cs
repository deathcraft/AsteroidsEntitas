namespace Sources.Systems
{
    public class CoreSystems : Feature
    {
        public CoreSystems(Contexts contexts)
        {
            Add(new CreatePlayerSystem(contexts));
            Add(new CreateAsteroidsSystem(contexts));
            Add(new CreateBulletsSystem(contexts));
            Add(new InstantiateAssetSystem(contexts));
            Add(new ProcessInputSystem(contexts));
            Add(new AccelerationSystem(contexts));
            Add(new PositioningSystem(contexts.game));
            Add(new WrapAroundSystem(contexts.game));
            Add(new RotationSystem(contexts.game));
            Add(new MovementSystem(contexts.game));
            Add(new ShipBoosterSystem(contexts.game));
            Add(new BulletCollisionSystem(contexts));
            Add(new PlayerDeathSystem(contexts));
            Add(new DestroySystem(contexts.game));
        }
    }
}