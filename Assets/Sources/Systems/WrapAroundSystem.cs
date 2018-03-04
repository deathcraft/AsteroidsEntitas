using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class WrapAroundSystem : ReactiveSystem<GameEntity>
    {
        public WrapAroundSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Position);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasPosition;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var mainCamera = Camera.main;
                
                Vector3 viewportPoint = mainCamera.WorldToViewportPoint(entity.position.value);

                if (viewportPoint.x < 0)
                {
                    viewportPoint.x = 1;
                } else if (viewportPoint.x > 1)
                {
                    viewportPoint.x = 0;
                } else if (viewportPoint.y < 0)
                {
                    viewportPoint.y = 1;
                } else if (viewportPoint.y > 1)
                {
                    viewportPoint.y = 0;
                }

                var newWorldPoint = mainCamera.ViewportToWorldPoint(viewportPoint);
                entity.ReplacePosition(newWorldPoint);
            }
        }
    }
}