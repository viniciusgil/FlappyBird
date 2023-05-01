using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody thisRigidbody;

    public float jumpPower = 10;

    private 
    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        bool jumInput = Input.GetKey(KeyCode.Space);
        if (jumpInput)
        {
            jumpPower();
        }
    }
}
