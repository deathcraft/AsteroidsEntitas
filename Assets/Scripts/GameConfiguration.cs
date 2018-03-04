using UnityEngine;

public class GameConfiguration : MonoBehaviour
{
    public static GameConfiguration INSTANCE
    {
        get  {
            if (gameConfiguration == null)
            {
                gameConfiguration = FindObjectOfType<GameConfiguration>();
            }

            return gameConfiguration;
        }
    }
    
    private static GameConfiguration gameConfiguration;

    
    public string playerAssetPath = "Ship";
    public float playerMaxSpeed;
    public float playerAcceleration = 5f;
    public float playerRotationSpeed = 180f;
    public float playerInitialHealth = 100;
    
    public string asteroidAssetPath = "Asteroid";
    public float asteroidSpeedCoeff = 1;
    public int asteroidNum = 5;
    public float asteroidMinSize = 1f;
    public float asteroidMaxSize = 2f;
}