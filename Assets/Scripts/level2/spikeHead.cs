using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeHead : MonoBehaviour
{
    private Animator animator;
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] spikeHeads;
    private Renderer playerRenderer;

    Vector3 downDirection = Vector3.down;
    Vector3 upDirection = Vector3.up;
    [SerializeField] float speed = 0.5f;
    bool[] isFalling; 
    bool[] isRising;  

    void Start()
    {
        animator = GetComponentInParent<Animator>();
        isFalling = new bool[spikeHeads.Length];
        isRising = new bool[spikeHeads.Length];
        playerRenderer = player.GetComponent<Renderer>();
    }

    void Update()
    {
        float posX = player.transform.position.x;
        float posY = player.transform.position.y;

        for (int i = 0; i < spikeHeads.Length; i++)
        {
            // Si el spikehead no está cayendo ni subiendo y el jugador está justo debajo, inicia la caída
            if (!isFalling[i] && !isRising[i] && posX >= spikeHeads[i].transform.position.x - 0.5f && posX <= spikeHeads[i].transform.position.x + 0.5f && posY < 0)
            {
                isFalling[i] = true;
                spikeHeadDown(spikeHeads[i], i);
            }

            // Si está cayendo, sigue cayendo
            if (isFalling[i])
            {
                spikeHeadDown(spikeHeads[i], i);
            }

            // Si está subiendo, sigue subiendo
            if (isRising[i])
            {
                spikeHeadUp(spikeHeads[i], i);
            }
        }
    }

    void spikeHeadDown(GameObject spikeHead, int index)
    {
        spikeHead.transform.position += downDirection * speed * Time.deltaTime;
        if (spikeHead.transform.position.y <= -4.17f)
        {
            spikeHead.transform.position = new Vector3(spikeHead.transform.position.x, -4.18f, 0f);
            animator.SetBool("bottom", true);
            isFalling[index] = false;
            if(player.transform.position.x < 198f )
            {
                StartCoroutine(waitUntilUp(index));
            }
        }
    }

    void spikeHeadUp(GameObject spikeHead, int index)
    {
        spikeHead.transform.position += upDirection * speed * Time.deltaTime;
        if (spikeHead.transform.position.y >= -0.82f)
        {
            spikeHead.transform.position = new Vector3(spikeHead.transform.position.x, -0.808f, 0f);
            animator.SetBool("top", true);
            isRising[index] = false;
            StartCoroutine(waitUntilBlink(index));
        }
    }

    IEnumerator waitUntilUp(int index)
    {
        yield return new WaitForSeconds(1f);
        isRising[index] = true;
    }

    IEnumerator waitUntilBlink(int index)
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("blink", true);
    }

}
