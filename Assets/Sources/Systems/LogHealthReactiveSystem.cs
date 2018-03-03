﻿using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class LogHealthReactiveSystem : ReactiveSystem<GameEntity>
    {
        public LogHealthReactiveSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Position);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasHealth;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                Debug.Log("Health: " + entity.health);
            }
        }
    }
}