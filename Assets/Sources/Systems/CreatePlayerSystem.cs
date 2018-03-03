using Entitas;
using Entitas.Unity;
using UnityEngine;

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
            entity.AddHealth(100);
            entity.AddGameAsset("Ship");
            entity.AddPosition(Vector3.zero);
            entity.AddGameSpeed(0.025f);
            entity.isPlayer = true;
        }
    }
}