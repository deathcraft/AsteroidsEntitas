using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private GameObject deathDext;
    
    private bool changedInput;
    private float rotation;
    private float targetAcceleration;
    
    void Update()
    {
        Respawn();
        ProcessPlayerInput();
    }

    private void ProcessPlayerInput()
    {
        var contexts = Contexts.sharedInstance;
        if (contexts.game.playerEntity == null)
        {
            return;
        }

        CheckMoveKeyPress(Vector3.up, GameConfiguration.INSTANCE.playerAcceleration, KeyCode.UpArrow, KeyCode.W);
        CheckRotationKeyPress(GameConfiguration.INSTANCE.playerRotationSpeed, KeyCode.LeftArrow, KeyCode.A);
        CheckRotationKeyPress(-GameConfiguration.INSTANCE.playerRotationSpeed, KeyCode.RightArrow, KeyCode.D);

        if (changedInput)
        {
            CreateInputEntity();
        }

        Shoot();
    }

    private void Respawn()
    {
        var contexts = Contexts.sharedInstance;
        deathDext.SetActive(contexts.game.playerEntity == null);

        if (contexts.game.playerEntity == null && Input.GetKeyDown(KeyCode.Space))
        {
            var newPlayer = contexts.game.CreateEntity();
            newPlayer.isPlayer = true;
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var contexts = Contexts.sharedInstance;
            var bulletEntity = contexts.game.CreateEntity();
            bulletEntity.isBullet = true;
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
                var playerEntity = Contexts.sharedInstance.game.playerEntity;
                var currentRotation = playerEntity.rotation.angle;
                currentRotation += angle * Time.deltaTime;
                rotation = currentRotation;
                changedInput = true;
            }
        }
    }

    private void CreateInputEntity()
    {
        var contexts = Contexts.sharedInstance;
        var inputEntity = contexts.input.CreateEntity();
        var playerEntity = contexts.game.playerEntity;
        if (playerEntity != null)
        {
            inputEntity.AddInput(targetAcceleration, rotation, playerEntity);
        }
    }
}