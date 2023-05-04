using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody thisRigidbody;

    public float jumpPower = 10;

    public float jumpInterval = 0.2f;

    private float jumpCooldown = 0;

    public AudioSource audioSourceCollision;

    public AudioSource audioSourceJump;
    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        jumpCooldown -= Time.deltaTime;
        bool isGameActive = GameManager.Instance.IsGameActive();
        bool canJump = jumpCooldown <= 0 && isGameActive;

        if (canJump)
        {
            bool jumpInput = Input.GetKey(KeyCode.Space);

            if (jumpInput)
            {
                Jump();
                audioSourceJump.Play();

            }   
        }
        // Toggle gravity
        thisRigidbody.useGravity = isGameActive;
    }
    void OnCollisionEnter(Collision other)
    {
        OnCustomCollisionEnter(other.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        OnCustomCollisionEnter(other.gameObject);
    }

    private void OnCustomCollisionEnter(GameObject other)
    {
        bool isSensor = other.CompareTag("Sensor");
        if (isSensor)
        {
            // Score!
            GameManager.Instance.score++;
            Debug.Log("Score: " + GameManager.Instance.score);
            
        }
        else
        {
            // Game over =(
            GameManager.Instance.EndGame();
            audioSourceCollision.Play();
            Destroy(gameObject);
        }
    }
    private void Jump()
    {
        jumpCooldown = jumpInterval;

        thisRigidbody.velocity = Vector3.zero;
        thisRigidbody.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
    }

}
