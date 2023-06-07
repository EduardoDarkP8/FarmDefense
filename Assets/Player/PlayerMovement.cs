using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rg;
    float x, z;
    float mouseX, mouseY, deltaX, deltaY;
    bool jump, isGrounded;
    public float speed;
    public float jumpForce;
    public float sensibility = 10;
    public Transform camera;
    public Animator anima;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        z = Input.GetAxisRaw("Vertical");
        x = Input.GetAxisRaw("Horizontal");
		if (Input.GetButton("Jump") && isGrounded) 
        {
            jump = true;
        }
        deltaX += Input.GetAxis("Mouse X")*sensibility;
        deltaY += Input.GetAxis("Mouse Y")*sensibility;
        deltaY = Mathf.Clamp(deltaY, -5f, 45f);
        transform.transform.localRotation = Quaternion.Euler(0,deltaX,0);
        camera.transform.localRotation = Quaternion.Euler(deltaY, 0, 0);
		
        
    }
	private void FixedUpdate()
	{
        Movement();
        Jump();
	}
	void Movement() 
    {
        rg.velocity = transform.right * x * speed + transform.forward * z * speed + transform.up * rg.velocity.y;
        if (x == 0 && z == 0)
        {
            rg.velocity = new Vector3(0, rg.velocity.y, 0);
        }
    }
    void Jump() 
    {
		if (jump) 
        {
            rg.AddForce(transform.up * jumpForce,ForceMode.Impulse);
            jump = false;
            isGrounded = false;
        }
    }
	private void OnCollisionEnter(Collision collision)
	{
        
        isGrounded = true;
	}
}
