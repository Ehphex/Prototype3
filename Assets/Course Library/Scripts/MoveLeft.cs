using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float moveSpeed = 15f;
    private float leftBound = -15f;

    private PlayerController playerControllerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }   

        if (transform.position.x < leftBound && gameObject.CompareTag("obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
