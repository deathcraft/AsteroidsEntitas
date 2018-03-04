using UnityEngine;

public class InputManager : MonoBehaviour
{

    private bool changedInput;
    private float rotation;
    private float targetAcceleration;

   
    
    
    void Update()
    {
        rotation = 0;

        //forward and backward
        CheckMoveKeyPress(Vector3.up, PlayerConfiguration.INSTANCE.acceleration, KeyCode.UpArrow, KeyCode.W);
//        CheckMoveKeyPress(Vector3.down, -acceleration, KeyCode.DownArrow, KeyCode.S);

        CheckRotationKeyPress(PlayerConfiguration.INSTANCE.rotationSpeed, KeyCode.LeftArrow, KeyCode.A);
        CheckRotationKeyPress(-PlayerConfiguration.INSTANCE.rotationSpeed, KeyCode.RightArrow, KeyCode.D);

        if (changedInput)
        {
            CreateInputEntity();
        }
    }

    private void CheckMoveKeyPress(Vector3 input, float val, params KeyCode[] keyCodes)
    {
        foreach (var keyCode in keyCodes)
        {
            if (Input.GetKeyDown(keyCode))
            {
                targetAcceleration = val;
                changedInput = true;
            }
            
            if (Input.GetKeyUp(keyCode))
            {
                targetAcceleration = 0f;
                changedInput = true;
            }
        }
    }
    
    private void CheckRotationKeyPress(float angle, params KeyCode[] keyCodes)
    {
        foreach (var keyCode in keyCodes)
        {
            if (Input.GetKey(keyCode))
            {
                rotation += angle;
                changedInput = true;
            }
        }
    }

    private void CreateInputEntity()
    {
        var contexts = Contexts.sharedInstance;
        var inputEntity = contexts.input.CreateEntity();
        var playerEntity = Contexts.sharedInstance.game.playerEntity;
        inputEntity.AddInput(targetAcceleration, rotation, playerEntity);
    }
}