using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class RotationSystem : ReactiveSystem<GameEntity>
    {
        public RotationSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Rotation);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameObject && entity.hasRotation;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var transformRotation = entity.gameObject.instance.transform.rotation.eulerAngles;
                transformRotation.z = entity.rotation.angle;
                entity.gameObject.instance.transform.rotation = Quaternion.Euler(transformRotation);
            }
        }
    }
}