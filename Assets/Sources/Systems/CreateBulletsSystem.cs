using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class CreateBulletsSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts contexts;
        private IGroup<GameEntity> players;

        public CreateBulletsSystem(Contexts contexts) : base(contexts.game)
        {
            this.contexts = contexts;
            players = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.GameObject, GameMatcher.Position));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Bullet.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isBullet;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var bullet in entities)
            {
                foreach (var player in players)
                {
                    var config = GameConfiguration.INSTANCE;
                    bullet.AddGameAsset(config.bulletPath);
                    var playerTransform = player.gameObject.instance.transform;
                    Vector3 playerDirection = playerTransform.TransformDirection(Vector3.up);
                    bullet.AddPosition(player.position.value + playerDirection / 2f);
                    bullet.AddGameSpeed(config.bulletSpeed * playerDirection, config.bulletSpeed);
                    var playerRotation = playerTransform.rotation.eulerAngles.z;
                    bullet.AddRotation(playerRotation);
                    bullet.AddAcceleration(0f);                    
                }
            }
        }
    }
}