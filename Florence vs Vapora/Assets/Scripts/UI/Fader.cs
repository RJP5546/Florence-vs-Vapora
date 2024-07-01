using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    //Time it takes to fade in and out
    [SerializeField] private float fadeTime;

    //the game objects canvas group local variable
    private CanvasGroup canvasGroup;
    private void Start()
    {
        //gets the canvas group component and assigns it as a local variable.
        canvasGroup = GetComponent<CanvasGroup>();
        
    }
    //Coroutines cannot be started from unity events, only stopped so these public methods will bridge the gap
    public void StartFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeIn()
    {
        while (canvasGroup.alpha > 0)
        {
            //sets the alpha to fade to 0 over the passed amount of time
            canvasGroup.alpha -= Time.deltaTime / fadeTime;
            yield return null;
        }
    }
    public IEnumerator FadeOut()
    {
        while (canvasGroup.alpha < 1)
        {
            //sets the alpha to fade to 1 over the passed amount of time
            canvasGroup.alpha += Time.deltaTime / fadeTime;
            yield return null;
        }
    }
}

