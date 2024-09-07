using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32 (1,1,0,1);
    [SerializeField] float destroyDelay = 0.3f;
    bool hasPackage;
    SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Mai to thuk gaya!");       
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Package" && hasPackage == false)
        {
            Debug.Log("Package Picked!");
            hasPackage = true; 
            spriteRenderer.color=hasPackageColor; 
            Destroy(other.gameObject,destroyDelay);
        }
        else if(other.tag == "Customer" && hasPackage == true)
        {
            Debug.Log("Package Delivered!");
            hasPackage = false;
            spriteRenderer.color=noPackageColor;
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Package")
        {
            Debug.Log("Package Out For Delivery");
        }
        else if(other.tag == "Customer")
        {
            Debug.Log("Moving to Next Package");
            
        }
    }
}
