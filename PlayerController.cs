using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
 // variable for players rigidbody
 private Rigidbody rb; 

 //count number of objects collected -> score
 private int count;

 // movement along x/y axis
 private float movementX;
 private float movementY;

 //players movement speed.
 public float speed = 0;

 //scoreboard textbox
 public TextMeshProUGUI countText;

 //end game msg
 public GameObject winTextObject;

 void Start()
    {
 // store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();
        count = 0;

 // update count display.
        SetCountText();

 // Initially set the win text to be inactive.
        winTextObject.SetActive(false);
    }
 
 //input detected.
 void OnMove(InputValue movementValue)
    {
 // convert value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

 // save x/y components of the movement.
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }

 // FixedUpdate is called once per fixed frame-rate frame.
 private void FixedUpdate() 
    {
 //3D movement vector using x/y
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);

 // add force based on speed
        rb.AddForce(movement * speed); 
    }

 
 void OnTriggerEnter(Collider other) 
    {
 // check for object collision
 if (other.gameObject.CompareTag("PickUp")) 
        {
 // eat objects
            other.gameObject.SetActive(false);

 // increment score when object is eaten
            count = count + 1;

 // update the count display
            SetCountText();
        }
    }

 // func to update the displayed count of "PickUp" objects collected.
 void SetCountText() 
    {
 // count text = current count
        countText.text = "Count: " + count.ToString();

 //if the count has reached win condition.
 if (count >= 12)
        {
 // end game, display win text.
            winTextObject.SetActive(true);
        }
    }
}
