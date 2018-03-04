using System.Collections.Generic;
using Entitas;

namespace Sources.Systems
{
    public class PositioningSystem : ReactiveSystem<GameEntity>
    {
        public PositioningSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Position);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasPosition && entity.hasGameObject;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var newPosition = entity.position.value;
                
                entity.gameObject.instance.transform.position = newPosition;
            }
        }
    }
}