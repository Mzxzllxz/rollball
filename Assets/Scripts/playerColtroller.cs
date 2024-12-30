using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;



public class playerColtroller : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    
    private Rigidbody rb;
    
    private int count;
    private float movementX;
    private float movementY;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        
        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

   void FixedUpdate()
   {
       Vector3 movement = new Vector3(movementX, 0.0f, movementY);
       
       rb.AddForce(movement * speed);
   }

   private void OnTriggerEnter(Collider other)
   {
       if (other.gameObject.CompareTag("PickUp")) 
       { 
           other.gameObject.SetActive(false); 
           count = count + 1;
           SetCountText();
       }
       
   }

   void SetCountText()
   {
       countText.text = "Count : " + count.ToString();

       if (count >= 12)
       {
           winTextObject.SetActive(true);
       }
   } 
   
    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
