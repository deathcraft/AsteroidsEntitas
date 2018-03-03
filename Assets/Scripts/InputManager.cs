using Entitas;
using UnityEngine;

namespace DefaultNamespace
{
    public class InputManager : MonoBehaviour
    {
        private Vector3 direction;

        void Update()
        {
            direction = Vector3.zero;
            
            CheckKeyPress(Vector3.up, KeyCode.UpArrow, KeyCode.W);
            CheckKeyPress(Vector3.left, KeyCode.LeftArrow, KeyCode.A);
            CheckKeyPress(Vector3.down, KeyCode.DownArrow, KeyCode.S);
            CheckKeyPress(Vector3.right, KeyCode.RightArrow, KeyCode.D);

            if (direction != Vector3.zero)
            {
                CreateInputEntity();
            }
        }

        private void CheckKeyPress(Vector3 input, params KeyCode[] keyCodes)
        {
            foreach (var keyCode in keyCodes)
            {
                if (Input.GetKey(keyCode))
                {
                    direction += input;
                }
            }
        }

        private void CreateInputEntity()
        {
            var contexts = Contexts.sharedInstance;
            var inputEntity = contexts.input.CreateEntity();
            var playerEntity = Contexts.sharedInstance.game.playerEntity;
            inputEntity.AddInput(direction, playerEntity);
        }            
    }
}