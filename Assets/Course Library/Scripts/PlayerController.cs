using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public InputAction jumpAction;
    public float jumpForce = 10f;

    public float gravityModifier = 1.5f;

    public bool isOnGround = false;
    public bool gameOver = false;

    private Animator playerAnim;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    private AudioSource playerAudio;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody>();
        jumpAction.Enable();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpAction.triggered && isOnGround && !gameOver)
        {
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }

        else if (collision.gameObject.CompareTag("obstacle"))
        {
            gameOver = true;
            playerAudio.PlayOneShot(crashSound, 1.0f);
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
        }
    }
}
