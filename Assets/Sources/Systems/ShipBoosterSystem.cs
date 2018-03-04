using System.Collections.Generic;
using Entitas;

namespace Sources.Systems
{
    public class ShipBoosterSystem : ReactiveSystem<GameEntity>
    {
        public ShipBoosterSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Acceleration);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPlayer && entity.hasAcceleration && entity.hasBoostEffect;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var accelerated = entity.acceleration.value != 0;
                entity.boostEffect.effects.booster.enabled = accelerated;
            }
        }
    }
}