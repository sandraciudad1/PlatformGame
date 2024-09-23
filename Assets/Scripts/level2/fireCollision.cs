using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fireCollision : MonoBehaviour
{
    private Animator animator;
    [SerializeField] GameObject player;
    private Renderer playerRenderer;
    private BoxCollider2D boxCollider;
    [SerializeField] TextMeshProUGUI pointsText;
    int points;

    void Start()
    {
        playerRenderer = player.GetComponent<Renderer>();
        animator = GetComponentInParent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        points = PlayerPrefs.GetInt("points", 0);
        pointsText.text = points.ToString();
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ice")){
            animator.SetBool("iceHit", true);
            boxCollider.enabled = false;
            points = PlayerPrefs.GetInt("points", 0);
            points += 70;
            PlayerPrefs.SetInt("points", points);
            pointsText.text = points.ToString();
        }
    }

}
