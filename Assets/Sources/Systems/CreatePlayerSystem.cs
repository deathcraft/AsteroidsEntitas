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
            entity.AddHealth(PlayerConfiguration.INSTANCE.initialHealth);
            entity.AddGameAsset(PlayerConfiguration.INSTANCE.assetPath);
            entity.AddPosition(Vector3.zero);
            entity.AddGameSpeed(Vector3.zero, PlayerConfiguration.INSTANCE.maxSpeed);
            entity.AddRotation(0f);
            entity.AddAcceleration(0f);
            entity.isPlayer = true;
        }
    }
}