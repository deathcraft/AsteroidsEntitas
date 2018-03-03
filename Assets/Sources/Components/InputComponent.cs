using DefaultNamespace;
using Entitas;
using UnityEngine;

[Input]
public class InputComponent : IComponent
{
    public Vector3 direction;
    public GameEntity movedEntity;
}