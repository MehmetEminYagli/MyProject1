using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    //public float moveSpeed = 5f;
    //public float jumpForce = 7f;
    //private bool isGrounded = false;

    //private Rigidbody rb;

    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}

    //void Update()
    //{
    //    Move();
    //    Jump();
    //}

    //void Move()
    //{

    //    float horizontal = Input.GetAxis("Horizontal");
    //    float vertical = Input.GetAxis("Vertical");


    //    Vector3 move = transform.right * horizontal + transform.forward * vertical;
    //    rb.velocity = new Vector3(move.x * moveSpeed, rb.velocity.y, move.z * moveSpeed);
    //    Debug.Log(move);
    //}

    //void Jump()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    //    {
    //        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    //        isGrounded = false;
    //    }
    //}

  


    public float moveSpeed = 5f; // Hareket hýzý
    public float jumpForce = 10f; // Zýplama kuvveti
    public Transform playerCamera; // Kamera referansý
    public float lookSpeed = 2f; // Fare duyarlýlýðý
    private Rigidbody rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        


        // Hareket kontrolleri
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(moveDirection);

        // Fareyi kullanarak oyuncuyu döndürme
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        transform.Rotate(Vector3.up * mouseX);
        
        //yukarý aþaðýya bakmasýný da yapabilirsin istersen(bir ara yapcam :D )



        // Zýplama kontrolü
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }


}

