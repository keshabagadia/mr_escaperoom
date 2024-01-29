using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float timeElapsed = 0f;
    public float timeConstraint;
    public bool gameWon = false;
    public AudioSource tickingTime;
    private void Update()
    {
        // Update the elapsed time
        timeElapsed += Time.deltaTime;

        // Check if 10 minutes have passed
        if (timeElapsed >= timeConstraint && !gameWon) // 600 seconds = 10 minutes
        {
            tickingTime.Play();
        }

        if (gameWon)
        {
            gameWon = false;
            GameOver();
        }
    }

    public void GameOver()
    {
        StartCoroutine(this.GetComponent<EnterNextScene>().GoToSceneRoutine(2));
    }
}
