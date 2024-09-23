using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class deadController : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dieAnim()
    {
        animator.SetBool("die", true);
    }

    
}
