using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class MovementSystem : ReactiveSystem<GameEntity>
    {
        public MovementSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameSpeed);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameObject && entity.hasRotation && entity.hasPosition && entity.hasGameSpeed;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var pos = entity.position.value;
                var speed = entity.gameSpeed.value;
                pos += speed * Time.deltaTime;
                entity.ReplacePosition(pos);
            }
        }
    }
}