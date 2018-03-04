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

            var player = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player));
            player.OnEntityAdded += InitializePlayer;
            var instantiatiedPlayer = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.GameObject));
            instantiatiedPlayer.OnEntityAdded += OnPlayerInstantiated;
        }

        private void InitializePlayer(IGroup<GameEntity> @group, GameEntity entity, int index, IComponent component)
        {
            entity.AddHealth(GameConfiguration.INSTANCE.playerInitialHealth);
            entity.AddGameAsset(GameConfiguration.INSTANCE.playerAssetPath);
            entity.AddPosition(Vector3.zero);
            entity.AddGameSpeed(Vector3.zero, GameConfiguration.INSTANCE.playerMaxSpeed);
            entity.AddRotation(0f);
            entity.AddAcceleration(0f);
        }

        private void OnPlayerInstantiated(IGroup<GameEntity> @group, GameEntity entity, int index, IComponent component)
        {
            entity.AddBoostEffect(entity.gameObject.instance.GetComponent<ShipEffects>());
        }

        public void Initialize()
        {
//            var entity = contexts.game.CreateEntity();
//            entity.isPlayer = true;
        }
    }
}