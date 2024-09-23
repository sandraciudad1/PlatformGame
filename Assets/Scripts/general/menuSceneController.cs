using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class menuSceneController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] TextMeshProUGUI livesText;
    int level;
    int stars;
    [SerializeField] Button level1Btn;
    [SerializeField] Button level2Btn;
    [SerializeField] Button level3Btn;

    [SerializeField] GameObject star11;
    [SerializeField] GameObject star12;
    [SerializeField] GameObject star13;
    [SerializeField] GameObject star21;
    [SerializeField] GameObject star22;
    [SerializeField] GameObject star23;
    [SerializeField] GameObject star31;
    [SerializeField] GameObject star32;
    [SerializeField] GameObject star33;
    void Start()
    {
        /*PlayerPrefs.SetInt("level", 0);
        PlayerPrefs.SetInt("points", 500);
        PlayerPrefs.SetInt("lives", 5);*/
        int points = PlayerPrefs.GetInt("points", 0);
        pointsText.text = points.ToString();
        int lives = PlayerPrefs.GetInt("lives", 0);
        livesText.text = lives.ToString();
        
    }

    void Update()
    {
        level = PlayerPrefs.GetInt("level", 0);
        Debug.Log("level " + level);
        if (level == 0) //no jugo aun
        {
            level1Btn.interactable = true;
        } else if (level == 1) //jugo el primer nivel
        {
            level1Btn.interactable = true;
            level2Btn.interactable = true;
            
        } else if (level >= 2) //jugo los dos primeros niveles
        {
            level1Btn.interactable = true;
            level2Btn.interactable = true;
            level3Btn.interactable = true;
            
        } 
        //stars = PlayerPrefs.GetInt("stars", 0);
        activateStars(1);
        activateStars(2);
        activateStars(3);
    }

    void activateStars(int level)
    {
        int stars1 = PlayerPrefs.GetInt("stars1", 0);
        int stars2 = PlayerPrefs.GetInt("stars2", 0);
        int stars3 = PlayerPrefs.GetInt("stars3", 0);

        if (level == 1)
        {
            star11.SetActive(stars1 >= 1);
            star12.SetActive(stars1 >= 2);
            star13.SetActive(stars1 >= 3);
        }
        if (level == 2)
        {
            star21.SetActive(stars2 >= 1);
            star22.SetActive(stars2 >= 2);
            star23.SetActive(stars2 >= 3);
        }
        if (level == 3)
        {
            star31.SetActive(stars3 >= 1);
            star32.SetActive(stars3 >= 2);
            star33.SetActive(stars3 >= 3);
        }
        PlayerPrefs.SetInt("apples", 0);
    }

    public void level1()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("level1");
    }

    public void level2()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("level2");
    }

    public void level3()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("level3");
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
