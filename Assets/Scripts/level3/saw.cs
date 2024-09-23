using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saw : MonoBehaviour
{
    Vector3 direction;
    float speed = 2f;

    void Start()
    {
        
    }

    void Update()
    {
        if (gameObject.name.Equals("saw1"))
        {
            if (gameObject.transform.position.x <= 25f)
            {
                direction = Vector3.right;
                Flip();
            }
            else if (gameObject.transform.position.x >= 47f)
            {
                direction = Vector3.left;
                Flip();
            }
            transform.position += direction * speed * Time.deltaTime;

        } else if (gameObject.name.Equals("saw2") || gameObject.name.Equals("saw3"))
        {
            if (gameObject.transform.position.x <= 80f)
            {
                direction = Vector3.right;
                Flip();
            }
            else if (gameObject.transform.position.x >= 108f)
            {
                direction = Vector3.left;
                Flip();
            }
            transform.position += direction * speed * Time.deltaTime;
        } else if (gameObject.name.Equals("saw4"))
        {
            if (gameObject.transform.position.x <= 200f)
            {
                direction = Vector3.right;
                Flip();
            }
            else if (gameObject.transform.position.x >= 209f)
            {
                direction = Vector3.left;
                Flip();
            }
            transform.position += direction * speed * Time.deltaTime;

        }
    }

    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
