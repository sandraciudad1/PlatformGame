using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diamondPowerup : MonoBehaviour
{
    [SerializeField] GameObject player;
    public bool starEnabled = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            starEnabled = true;
            //StartCoroutine(colliderDisabled());
        }
    }


    IEnumerator colliderDisabled()
    {
        starEnabled = true;
        yield return new WaitForSeconds(3f);
        starEnabled = false;
    }
}
