using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class ProcessInputSystem : ReactiveSystem<InputEntity>
    {
        public ProcessInputSystem(Contexts contexts) : base(contexts.input)
        {
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.Input.Added());
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasInput;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                var inputEntity = entities[i];
                var gameEntity = inputEntity.input.movedEntity;
                var pos = gameEntity.position.value;
                var speed = gameEntity.gameSpeed.value;
                var dir = inputEntity.input.direction;
                pos += dir * speed;

                gameEntity.ReplacePosition(pos);
                inputEntity.Destroy();
            }
        }
    }
}