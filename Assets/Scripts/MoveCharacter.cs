using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public float moveSpeed = 5;
    public float jumpForce = 10;
    Rigidbody rb;
    bool isJumpable;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = new Vector3(x, 0, z) * moveSpeed * Time.deltaTime;

        transform.Translate(move, Space.Self);

        if(Input.GetKeyDown(KeyCode.Space) && isJumpable)
        {
            Jump();
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Jumpable"))
        {
            isJumpable = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Jumpable"))
        {
            isJumpable = false;
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public bool GetIsJumpable()
    {
        return isJumpable;
    }
}
