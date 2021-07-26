using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MapLoader : MonoBehaviour
{

    string mainSceneName;
    public GameObject fadeCanvas;
    public GameObject loadingTxt;

    float timer = 1f;
    bool timerDone = false;



    // Start is called before the first frame update
    void Start()
    {
        mainSceneName = "_Main";
        PlayerPrefs.SetInt("pref-doorToLoad", 7); //7 is door to main, 7 is main door
       // StartCoroutine(LoadYourAsyncScene(mainSceneName));
    }

    IEnumerator LoadYourAsyncScene(string sn)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sn);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
            
        }
        
    }

    void Update()
    {
        if(!timerDone)
        {

            timer -= Time.deltaTime;
            if(timer < 0)
            {
                fadeCanvas.GetComponent<Fade>().FadeOut();
                loadingTxt.SetActive(false);
                timerDone = true;
            }
        }
       

    }
}
