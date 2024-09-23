using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class enemyCollision : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Renderer playerRenderer;
    [SerializeField] TextMeshProUGUI pointsText;
    int points;

    void Start()
    {
        points = PlayerPrefs.GetInt("points", 0);
        pointsText.text = points.ToString();
        playerRenderer = player.GetComponent<Renderer>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.attachedRigidbody;
            if (rb!=null)
            {
                float posXEnemy = gameObject.transform.position.x;
                if (rb.velocity.y < 0 && (collision.transform.position.x >= (posXEnemy - 0.45f) && collision.transform.position.x <= (posXEnemy + 0.45f)) && CompareTag("enemy"))
                {
                    gameObject.SetActive(false);
                    points = PlayerPrefs.GetInt("points", 0);
                    points += 150;
                    PlayerPrefs.SetInt("points", points);
                    pointsText.text = points.ToString();
                } else
                {
                    StartCoroutine(waitFireCollision());
                }
            }
        }
    }

    void SetTransparency(Material material, float alpha)
    {
        alpha = Mathf.Clamp01(alpha);
        Color color = material.color;
        color.a = alpha;
        material.color = color;
    }

    IEnumerator waitFireCollision()
    {
        points = PlayerPrefs.GetInt("points", 0);
        points -= 100;
        PlayerPrefs.SetInt("points", points);
        pointsText.text = points.ToString();
        Material playerMaterial = playerRenderer.material;
        SetTransparency(playerMaterial, 0.5f);
        yield return new WaitForSeconds(2f);
        SetTransparency(playerMaterial, 1f);
    }
}
