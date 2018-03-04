using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Sources.Systems
{
    public class DestroySystem : ReactiveSystem<GameEntity>
    {
        public DestroySystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Destroyed.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isDestroyed && entity.hasGameObject;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.gameObject.instance.Unlink();
                GameObject.Destroy(entity.gameObject.instance);
                entity.Destroy();
            }
        }
    }
}