using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;

    private void Awake()
    {
        if (instance == null)
        {
            // If no instance exists, set this as the instance
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this object
            Destroy(gameObject);
        }
    }

    // Add your player controller logic here
}
