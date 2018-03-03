namespace Sources.Systems
{
    public class CoreSystems : Feature
    {
        public CoreSystems(Contexts contexts)
        {
            Add(new CreatePlayerSystem(contexts));
            Add(new InstantiateAssetSystem(contexts));
            Add(new ProcessInputSystem(contexts));
            Add(new PositioningSystem(contexts.game));
        }
    }
}