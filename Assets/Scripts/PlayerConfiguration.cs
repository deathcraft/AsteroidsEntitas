using UnityEngine;

public class PlayerConfiguration : MonoBehaviour
{
    public static PlayerConfiguration INSTANCE
    {
        get  {
            if (playerConfiguration == null)
            {
                playerConfiguration = FindObjectOfType<PlayerConfiguration>();
            }

            return playerConfiguration;
        }
    }
    
    private static PlayerConfiguration playerConfiguration;

    
    public string assetPath = "Ship";
    public float maxSpeed;
    public float acceleration = 5f;
    public float rotationSpeed = 180f;
    public float initialHealth = 100;
}