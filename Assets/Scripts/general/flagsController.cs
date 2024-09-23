using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class flagsController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] GameObject firework;
    int points;
    // Start is called before the first frame update
    void Start()
    {
        points = PlayerPrefs.GetInt("points", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            points += 350;
            PlayerPrefs.SetInt("points", points);
            pointsText.text = points.ToString();
            if (CompareTag("flag1"))
            {
                PlayerPrefs.SetInt("level", 1);
                PlayerPrefs.SetInt("stars1", countApples());
            } else if (CompareTag("flag2"))
            {
                PlayerPrefs.SetInt("level", 2);
                PlayerPrefs.SetInt("stars2", countApples());
            } else if (CompareTag("flag3"))
            {
                PlayerPrefs.SetInt("level", 3);
                PlayerPrefs.SetInt("stars3", countApples());
            }
            //countApples();
            firework.SetActive(true);
            StartCoroutine(waitUntilFinish());
        }
    }

    int countApples()
    {
        int apples = PlayerPrefs.GetInt("apples", 0);
        int stars=0;
        if (apples >= 4)
        {
            stars = 3;
        } else if(apples < 4 && apples > 2)
        {
            stars = 2;
        } else
        {
            stars = 1;
        }
        return stars;
    }

    IEnumerator waitUntilFinish()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("menuScene");
        firework.SetActive(false);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
