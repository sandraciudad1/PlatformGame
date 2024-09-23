using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

//Este script se encarga de los movimientos del jugador y la cámara
public class playerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    [SerializeField] GameObject player;
    [SerializeField] GameObject camera;
    
    float speed = 5f;
    float jumpForce = 7f;
    bool isGrounded = false;
    int jumpCounter = 0;
    int points;
    int lives;
    bool isfloor = false, isTrampoline = false;

    [SerializeField] GameObject pointsIcon;
    [SerializeField] GameObject livesIcon;
    [SerializeField] GameObject applesIcon;
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI applesText;

    [SerializeField] GameObject dead;

    bool addLife, loseLife;
    

    void Start()
    {
        activateCanvas();
        points = PlayerPrefs.GetInt("points", 0);
        pointsText.text = points.ToString();
        lives = PlayerPrefs.GetInt("lives", 5);
        livesText.text = lives.ToString();

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        camera.transform.position = new Vector3((transform.position.x + 6f), camera.transform.position.y, camera.transform.position.z);
    }

    void Update()
    {
        if (transform.position.y >= -5.4)
        {
            HandleMovement();
            HandleJump();
            UpdateAnimations();
        } else 
        {
            dead.SetActive(true);
            deadController deadcontroller = GameObject.Find("dead").GetComponent<deadController>();
            if (deadcontroller != null)
            {
                deadcontroller.dieAnim();
                transform.position = new Vector3(-3f, -2.85f, 0f);
                lives -= 1;
                PlayerPrefs.SetInt("lives", lives);
                livesText.text = lives.ToString();
                desactivateCanvas();
                StartCoroutine(waitUntilFinish());
            }
            
        }

        int pointsValue = int.Parse(pointsText.text);

        
        if (pointsValue >= 1000 && !addLife)
        {
            lives += 1;
            PlayerPrefs.SetInt("lives", lives);  
            livesText.text = lives.ToString();   
            points = 50;  
            PlayerPrefs.SetInt("points", points);  
            pointsText.text = points.ToString();   
            addLife = true;  
        }
        else if (pointsValue < 1000)  
        {
            addLife = false;
        }

        if (pointsValue <= 0 && !loseLife)
        {
            lives -= 1;
            PlayerPrefs.SetInt("lives", lives); 
            livesText.text = lives.ToString();   
            points = 950;  
            PlayerPrefs.SetInt("points", points);  
            pointsText.text = points.ToString();   

            loseLife = true;  
        }
        else if (pointsValue > 0)  
        {
            loseLife = false;
        }

    }

    IEnumerator waitUntilFinish()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.sceneLoaded += OnSceneLoaded; 
        SceneManager.LoadScene("menuScene");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void activateCanvas()
    {
        pointsIcon.SetActive(true);
        livesIcon.SetActive(true);
        applesIcon.SetActive(true);
    }

    void desactivateCanvas()
    {
        pointsIcon.SetActive(false);
        livesIcon.SetActive(false);
        applesIcon.SetActive(false);
    }

    void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector2 moveVelocity = new Vector2(moveInput * speed, rb.velocity.y);
        

        if (moveInput > 0 && transform.position.x < 270)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            camera.transform.position = new Vector3((transform.position.x+6f), camera.transform.position.y, camera.transform.position.z);
            rb.velocity = moveVelocity;
        }
        else if (moveInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            camera.transform.position = new Vector3((transform.position.x + 6f), camera.transform.position.y, camera.transform.position.z);
            rb.velocity = moveVelocity;
        }
        
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && jumpCounter == 0)
        {
            if (isTrampoline==true)
            {
                jumpForce = 10f;
            } else
            {
                jumpForce = 7f;
            }
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            jumpCounter++;
        }
    }

    void UpdateAnimations()
    {
        animator.SetBool("isRunning", Mathf.Abs(rb.velocity.x) > 0.1f);
        animator.SetBool("isJumping", !isGrounded);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            isGrounded = true;
            jumpCounter = 0;
            isTrampoline = false;

        } else if (collision.gameObject.CompareTag("trampoline"))
        {
            isGrounded = true;
            jumpCounter = 0;
            isTrampoline = true;
        } 
    }
    


}


