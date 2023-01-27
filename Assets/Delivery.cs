using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 hasNotPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] float destroyDelayTime = 0.5f;
    bool hasPackage;

    SpriteRenderer spriteRenderer; // Foundations for getting a component (bilesen) in the start method and storing
    //or caching that component in a variable and this variable called spriteRenderer. Now we can use 
    //spriteRenderer where ever we want from this point on.
    
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other)//kaza yaptiginda otomatik olarak devreye girer 
    {
        Debug.Log("Ouch!");
    }
    void OnTriggerEnter2D(Collider2D other)//Triggerladigimizda calisir
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            Destroy(other.gameObject, destroyDelayTime);
            spriteRenderer.color = hasPackageColor;
        }
        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package is delivered");
            hasPackage = false;
            spriteRenderer.color = hasNotPackageColor;
        }
    }
}
