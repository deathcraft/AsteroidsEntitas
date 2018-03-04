using System;
using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class AccelerationSystem : IExecuteSystem
    {
        private IGroup<GameEntity> entities;

        public AccelerationSystem(Contexts contexts)
        {
            entities = contexts.game.GetGroup(GameMatcher.GameSpeed);
        }

        public void Execute()
        {
            foreach (var entity in entities)
            {
                Vector3 speed = entity.gameSpeed.value;
                var maxValue = entity.gameSpeed.maxValue;
                Vector3 localDirection = Vector3.up;
                Vector3 direction = entity.gameObject.instance.transform.TransformDirection(localDirection);
                Vector3 acceleration = direction * entity.acceleration.value; 
                Vector3 newSpeed = speed + acceleration * Time.deltaTime;
                newSpeed = Vector3.ClampMagnitude(newSpeed, maxValue);
                entity.ReplaceGameSpeed(newSpeed, maxValue);
            }
        }
    }
}