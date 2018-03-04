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

            var instantiatiedPlayer = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.GameObject));
            instantiatiedPlayer.OnEntityAdded += OnPlayerInstantiated;
        }

        private void OnPlayerInstantiated(IGroup<GameEntity> @group, GameEntity entity, int index, IComponent component)
        {
            entity.AddBoostEffect(entity.gameObject.instance.GetComponent<ShipEffects>());
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