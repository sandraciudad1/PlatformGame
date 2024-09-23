using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script controla el movimiento de las plataformas en el nivel 1
public class platformsMovement1 : MonoBehaviour
{
    [SerializeField] GameObject greyPlatform2;
    [SerializeField] GameObject redPlatform1;

    public float speed = 2f; 
    private Vector3 horizontalDirection = Vector3.right;
    private Vector3 verticalDirection = Vector3.up; 


    void Start()
    {
        
    }


    void Update()
    {
        horizontalMovement(153f, 176f);
        verticalMovement();
    }

    void horizontalMovement(float leftLimit, float rightLimit)
    {
        greyPlatform2.transform.position += horizontalDirection * speed * Time.deltaTime;

        if (greyPlatform2.transform.position.x >= rightLimit)
        {
            horizontalDirection = Vector3.left; 
        }
        else if (greyPlatform2.transform.position.x <= leftLimit)
        {
            horizontalDirection = Vector3.right; 
        }
    }

    void verticalMovement()
    {
        redPlatform1.transform.position += verticalDirection * speed * Time.deltaTime;

        if (redPlatform1.transform.position.y >= 2)
        {
            verticalDirection = Vector3.down;
        }
        else if (redPlatform1.transform.position.y <= -4)
        {
            verticalDirection = Vector3.up;
        }
    }
}
