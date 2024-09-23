using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icePowerUp : MonoBehaviour
{
    [SerializeField] private GameObject icePrefab;
    [SerializeField] GameObject player;
    [SerializeField] private float speed = 10f;
    private List<GameObject> spawnedObjects = new List<GameObject>();
    GameObject newObject;
    bool updatePos = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (updatePos)
        {
            transform.position = new Vector3((player.transform.position.x + 0.566f), (player.transform.position.y - 0.359f), 0f);

            if (Input.GetKeyDown(KeyCode.X))
            {
                newObject = Instantiate(icePrefab, transform.position, transform.rotation);
                spawnedObjects.Add(newObject);
            }

            foreach (GameObject obj in spawnedObjects)
            {
                if (obj != null)
                {
                    obj.transform.Translate(Vector2.right * speed * Time.deltaTime);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(powerupTime());
        }
        if (collision.CompareTag("fire"))
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator powerupTime()
    {
        updatePos = true;
        yield return new WaitForSeconds(10f);

        foreach (GameObject obj in spawnedObjects)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
        updatePos = false;
        spawnedObjects.Clear();
        gameObject.SetActive(false);
    }

}
