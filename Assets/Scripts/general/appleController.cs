using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class appleController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI applesText;
    int apples;
    [SerializeField] TextMeshProUGUI pointsText;
    int points;

    void Start()
    {
        apples = PlayerPrefs.GetInt("apples", 0);
        applesText.text = apples.ToString();
        points = PlayerPrefs.GetInt("points", 0);
        pointsText.text = points.ToString();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            apples = PlayerPrefs.GetInt("apples", 0);
            apples += 1;
            PlayerPrefs.SetInt("apples", apples);
            applesText.text = apples.ToString();
            points = PlayerPrefs.GetInt("points", 0);
            points += 50;
            PlayerPrefs.SetInt("points", points);
            pointsText.text = points.ToString();
        }
    }
}
