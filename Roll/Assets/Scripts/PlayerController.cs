using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed; 
    private Rigidbody rb;
    private Animator anim;

    private int count;

    public Text winText;
    public Text countText;

    private float inputH;
    private float inputV;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        count = 0;
        setCountText();
        winText.text = "";
    }

    //Called before a frame is rendered
    void Update()
    {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        
        if (Input.GetKey(KeyCode.Space))
        {
            anim.Play("FreeVoxelGirl-jump");
        }
        if (Input.GetKey(KeyCode.Q))
        {
            anim.Play("FreeVoxelGirl-death");
        }

        if (Input.GetKey(KeyCode.E))
        {
            anim.Play("FreeVoxelGirl-damage");
        }

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
        if (other.gameObject.CompareTag("Pick Up")) {
            other.gameObject.SetActive(false);
            count += 1;
            setCountText();
        }
            
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 8)
        {
            winText.text = "You Win!";
        }
    }
}
