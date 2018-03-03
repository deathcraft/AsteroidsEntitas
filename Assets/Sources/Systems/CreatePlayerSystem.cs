using Entitas;

namespace Sources.Systems
{
    public class CreatePlayerSystem : IInitializeSystem
    {
        private Contexts contexts;

        public CreatePlayerSystem(Contexts contexts)
        {
            this.contexts = contexts;
        }

        public void Initialize()
        {
            var entity = contexts.game.CreateEntity();
///            entity.AddHealthUnit(100);
        }
    }
}