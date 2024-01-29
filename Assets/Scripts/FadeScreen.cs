using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public float fadeDuration = 2;
    public bool fadeOnStart = true;
    public Color fadeColor;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        if (fadeOnStart) FadeIn();
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        Debug.Log("fade function");
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    public void FadeIn()
    {
        Debug.Log("fade in function");
        Fade(1, 0);
    }

    public void FadeOut()
    {
        Fade(0, 1);
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        Debug.Log("fade coroutine");
        float timer = 0;
        while (timer < fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer/fadeDuration);

            rend.material.SetColor("_BaseColor", newColor);
            timer += Time.deltaTime;
            yield return null;
        }

        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;
        rend.material.SetColor("_BaseColor", newColor2);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
