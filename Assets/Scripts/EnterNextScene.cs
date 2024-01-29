using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterNextScene : MonoBehaviour
{
    public int sceneIndex;
    public FadeScreen fadeScreen;
    public AudioSource suckedInPortal;
    public bool functionCalledOnce = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + " entered");
        // Check if the entering collider is the player
        if ((other.CompareTag("Player")||other.CompareTag("MainCamera"))&&!functionCalledOnce)
        {
            functionCalledOnce = true;
            Debug.Log("player entered");
            // Change the scene
            StartCoroutine(GoToSceneRoutine(sceneIndex));
 
        }
    }

    public IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        fadeScreen.FadeOut();
        suckedInPortal.Play();
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(sceneIndex);
    }
}
