using Sources.Systems;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private CoreSystems coreSystems;

    void Start()
    {
        var contexts = Contexts.sharedInstance;
        coreSystems = new CoreSystems(contexts);
        coreSystems.Initialize();
    }

    void Update()
    {
        coreSystems.Execute();
    }
}