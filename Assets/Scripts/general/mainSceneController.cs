using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainSceneController : MonoBehaviour
{

    void Start()
    {
        /*PlayerPrefs.SetInt("level", 0);
        PlayerPrefs.SetInt("points", 500);
        PlayerPrefs.SetInt("lives", 5);
        PlayerPrefs.SetInt("apples", 0);
        PlayerPrefs.SetInt("stars1", 0);
        PlayerPrefs.SetInt("stars2", 0);
        PlayerPrefs.SetInt("stars3", 0);*/
    }


    void Update()
    {
        
    }

    public void startBtn()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("menuScene");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
