using Sources.Systems;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private LogHealthReactiveSystem system;

    void Start()
    {
        var contexts = Contexts.sharedInstance;

        system = new LogHealthReactiveSystem(contexts);
        var playerSystem = new CreatePlayerSystem(contexts);
        playerSystem.Initialize();
    }


    void Update()
    {
        system.Execute();
    }
}