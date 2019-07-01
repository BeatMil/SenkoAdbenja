using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenkoController : MonoBehaviour
{
    //config parameter
    SpriteRenderer sprite;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float walkSpeed = 10f;
    [SerializeField] float gravity;
    [SerializeField] float mimiShowTime = 0f;
    [SerializeField] float currentMimiShowTime;

    //ANIME TOR
    public Animator animator;

    //cache
    public AudioSource audioSource;
    Rigidbody2D rigid2D;

    //sound folder
    [SerializeField] AudioClip[] walkSounds;
    [SerializeField] AudioClip[] jumpSounds;
    [SerializeField] AudioClip mimiMoveSound;

    public bool isGrounded = false;
    bool mimiMoveBool = false;
    GameStatus gameStatus;

    
    private int keyJump = 0; //use in a jump2 function



    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        gameStatus = FindObjectOfType<GameStatus>();
        audioSource = GetComponent<AudioSource>();
        rigid2D = GetComponent<Rigidbody2D>();
        rigid2D.gravityScale = gravity;
        InvokeRepeating("playWalkSound", 0.0f, 0.5f);
        currentMimiShowTime = mimiShowTime;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetBool("mimiMove", mimiMoveBool);
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position = transform.position + movement * Time.deltaTime * walkSpeed;
        filpSenko(movement);
        Jump2();
    }

    private void FixedUpdate()
    {
        mimiMove();
    }

    private void mimiMove()
    {
        if (Input.GetKeyDown(KeyCode.E) && mimiShowTime > 0f)
        {
            Debug.Log("E YOO!");
            audioSource.PlayOneShot(mimiMoveSound);
            currentMimiShowTime = mimiShowTime;
            mimiMoveBool = true;
        }
        else if (currentMimiShowTime <= 0f)
        {
            mimiMoveBool = false;
            
        }
        if (mimiMoveBool)
        {
            currentMimiShowTime -= (Time.deltaTime);
        }
    }

    private void filpSenko(Vector3 movement)
    {
        if (movement.x > 0)
        {
            sprite.flipX = false;            
        }
        else if (movement.x < 0)
        {
            sprite.flipX = true;
        }
    }

    private void Jump2()
    {
        
        if (Input.GetButton("Jump") && isGrounded)
        {
            keyJump = 1;
            rigid2D.velocity = Vector2.zero;
            rigid2D.velocity += new Vector2(Input.GetAxis("Horizontal"), jumpForce);
        }
        else if (Input.GetButtonUp("Jump") && !isGrounded && rigid2D.velocity.y > 0)
        {
            rigid2D.velocity = Vector2.zero;
        }

        if (keyJump == 1 && !isGrounded)
        {
            PlayJumpSound();
            keyJump = 0;
        }
    }

    private void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSounds[UnityEngine.Random.Range(0, jumpSounds.Length)]);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(gameObject.CompareTag("Player"))
        {
            Debug.Log("Tag Player");
        }

        if (other.gameObject.CompareTag("Jumpable") && gameObject.CompareTag("Player"))
        {
            isGrounded = true;
        }
        else if (other.gameObject.CompareTag("Moving"))
        {
            isGrounded = true;
            transform.parent = other.gameObject.transform;
            Debug.Log("Moving platform");
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Jumpable"))
        {
            isGrounded = false;
        }
        else if (other.gameObject.CompareTag("Moving"))
        {
            transform.parent = null;
            isGrounded = false;
        }
    }

    void playWalkSound()
    {
        if (Input.GetButton("Horizontal"))
        {
            float randomNum = UnityEngine.Random.Range(0, 2);
            audioSource.PlayOneShot(walkSounds[UnityEngine.Random.Range(0,walkSounds.Length)]);
        }
    }
}
