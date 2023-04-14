using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class loadingBarOperations : MonoBehaviour
{
    private int sceneSpecifier;
    [SerializeField] private Slider loadingBarObject;
    [SerializeField] protected GameObject objectOfAll, titleObject, barMessagesObject, loadingBarOperationObject;
    [SerializeField] private slideInTransition slideIn;
    /*[SerializeField] private Animation fadeOutTransition;*/
    public void Start()
    {/*
        fadeOutTransition = GetComponent<Animation>();
*/
        
        loadingBarObject.maxValue = 100;
        loadingBarObject.minValue = 1;
        if (slideIn!=null)
        {
            slideIn = FindObjectOfType<slideInTransition>().GetComponent<slideInTransition>();
        }
        StartCoroutine(loadAsync(SceneSpecifier = 2));
    }
    public int SceneSpecifier
    {
        set { this.sceneSpecifier = value; }
        get { return this.sceneSpecifier; }
    }
    IEnumerator loadAsync(int sceneIndex)
    {
        /*objectOfAllFadeOut = objectOfAll.GetComponent<Animator>();
        titleObjectFadeOut = titleObject.GetComponent<Animator>();*/
        /*barMessagesObjectFadeOut = barMessagesObject.GetComponent<Animator>();*/
        int barCurrentValue = 0;
        bool currentValueFinished = false;
        bool loadPlay = false;
        while (!loadPlay && !currentValueFinished)
        {
            Mathf.RoundToInt(Random.Range(2.0f, 10.0f));
            loadingBarOperationObject.SetActive(true);
            loadingBarObject.value += barCurrentValue;
            
             if (barCurrentValue >= loadingBarObject.maxValue - 27)
            {
                slideIn.SlideInTransition();
                AsyncOperation asyncOpera = SceneManager.LoadSceneAsync(sceneIndex);
                loadPlay = asyncOpera.isDone; 
            }
            else if (barCurrentValue >= loadingBarObject.maxValue)
            {
                currentValueFinished = true;
            }
            if (barCurrentValue>=90&&loadPlay==true)
            {
                yield return new WaitForSeconds(2f);
            }
            barCurrentValue += Random.Range(1, 30);
            yield return new WaitForSeconds(Random.Range(3.0f,5.0f));
        }
        
    }
    
}
