using Entitas;
using UnityEngine;

[Input]
public class InputComponent : IComponent
{
    public float acceleration;
    public float angle;
    public GameEntity movedEntity;
}