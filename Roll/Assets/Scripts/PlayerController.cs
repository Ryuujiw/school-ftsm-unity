using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed; 
    private Rigidbody rb;
    private Animator anim;

    private float inputH;
    private float inputV;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    //Called before a frame is rendered
    void Update()
    {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);

        float moveX = inputH * speed * Time.deltaTime;
        float moveZ = inputV * speed * Time.deltaTime;

        rb.velocity = new Vector3(moveX, 0f, moveZ);

        transform.rotation = Quaternion.LookRotation(rb.velocity);

    }
    
    //Called before perfroming any Physics Calculation
    //We will move our ball 
    //By applying forces to the body
    //So our Physics code goes in here.



    /**void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //We need a Vector3 Object. Vector3 takes in (x,y,z).
        //In 3D space, we can use these x,y,z values.

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement *speed);
    }
    */

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
            other.gameObject.SetActive(false);
    }
}
