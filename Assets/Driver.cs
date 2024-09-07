using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float boostSpeed = 25f;
    void Start()
    {

    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        moveSpeed=slowSpeed;    
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boost")
        {
            Debug.Log("Speed Increased!!");
            moveSpeed = boostSpeed;
        }
    }
    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Customer" || other.tag == "Packages")
        {
            moveSpeed = 15f;
        }      
    }

}
