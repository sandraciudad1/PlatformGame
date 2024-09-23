using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script controla el movimiento de los enemigos en el nivel 1
public class enemyMovement_Controller1 : MonoBehaviour
{
    private Animator animator;
    float speed = 2f;
    Vector3 direction = Vector3.right;

    bool isColliding = false;

    void Start()
    {
        animator = GetComponentInParent<Animator>();
        
    }


    void Update()
    {
        if (isColliding == false)
        {
            if (gameObject.name.Equals("angryPig1"))
            {
                movement(24f, 32f);
            }
            else if (gameObject.name.Equals("angryPig2"))
            {
                movement(51.5f, 53.3f);
            }
            else if (gameObject.name.Equals("angryPig3"))
            {
                movement(87f, 90.6f);
            }
            else if (gameObject.name.Equals("angryPig4"))
            {
                movement(91f, 93f);
            }
            else if (gameObject.name.Equals("angryPig5"))
            {
                movement(93.4f, 97f);
            }
            else if (gameObject.name.Equals("angryPig6"))
            {
                movement(184f, 186.4f);
            }
            else if (gameObject.name.Equals("angryPig7"))
            {
                movement(192.5f, 196.5f);
            }
            else if (gameObject.name.Equals("angryPig8"))
            {
                movement(202f, 204.8f);
            }
            else if (gameObject.name.Equals("angryPig9"))
            {
                movement(218f, 225f);
            }
            else if (gameObject.name.Equals("angryPig10"))
            {
                movement(250f, 256f);
            }
            else if (gameObject.name.Equals("turtle1"))
            {
                movement(26.7f, 29.4f);
            }
            else if (gameObject.name.Equals("turtle2"))
            {
                movement(114f, 115.8f);
            }
            else if (gameObject.name.Equals("turtle3"))
            {
                movement(191f, 195f);
            }
            else if (gameObject.name.Equals("turtle4"))
            {
                movement(209.8f, 210.2f);
            }
        }
        
    }

    void movement(float initPos, float finalPos)
    {
        transform.position += direction * speed * Time.deltaTime;

        if (transform.position.x >= finalPos && direction == Vector3.right)
        {
            direction = Vector3.left;
            Flip(); 
        }
        else if (transform.position.x <= initPos && direction == Vector3.left)
        {
            direction = Vector3.right;
            Flip(); 
        }
    }

    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1; 
        transform.localScale = localScale;
    }
}
