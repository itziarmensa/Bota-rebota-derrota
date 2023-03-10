using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float startDelay = 1;
    public static GameManager instance;

    private int timeToWin = 60; // tiempo en segundos que el jugador debe aguantar para ganar
    private int timeCounter = 0; // contador de tiempo

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Iniciamos el contador de tiempo
        StartCoroutine(UpdateTime());
    }

    public IEnumerator UpdateTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeCounter++;

            // Si el contador de tiempo ha llegado al tiempo m?ximo, el jugador ha ganado
            /*if (timeCounter >= timeToWin)
            {
                AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("WinScene");
                while (!asyncLoad.isDone)
                {
                    yield return null;
                }
            }*/
        }
    }


    public IEnumerator GameOver()
    {

        if(timeCounter >= timeToWin)
        {
            yield return new WaitForSeconds(0.9f);
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GameOverScene");
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
        
    }

}
