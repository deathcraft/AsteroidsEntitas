using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class LogHealthSystem : IExecuteSystem
    {
        private IGroup<GameEntity> entities;

        public LogHealthSystem(Contexts contexts)
        {
            entities = contexts.game.GetGroup(GameMatcher.Health);
        }

        public void Execute()
        {
            foreach (var entity in entities)
            {
                var healthValue = entity.health.value;
                Debug.Log("Health: " + healthValue);
            }
        }
    }
}