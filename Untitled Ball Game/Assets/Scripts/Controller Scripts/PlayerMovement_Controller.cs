using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Controller : MonoBehaviour {
    public Rigidbody player;
    public float speed;
    public float turningSpeed;
    public float jumpingSpeed;
    public float maxCount;
    float count;
    bool touchingFloor;
    

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Floor")
        {
            touchingFloor = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Floor")
        {
            touchingFloor = false;
        }
    }

    private void FixedUpdate()
    {
        ///Horizontal Movement
        if (Input.GetAxisRaw("Horizontal(Controller)") == 1)
        {
            if (player.velocity.x < 0)
            {
                player.AddForce(turningSpeed * Time.deltaTime, 0, 0);
            }
            else
            {
                player.AddForce(speed * Time.deltaTime, 0, 0);
            }
            Debug.Log("d");

        }
        else if (Input.GetAxisRaw("Horizontal(Controller)") == -1)
        {
            if (player.velocity.x > 0)
            {
                player.AddForce(-turningSpeed * Time.deltaTime, 0, 0);
            }
            else
            {
                player.AddForce(-speed * Time.deltaTime, 0, 0);
            }
        }
       
        ///Vertical Movement
        if (Input.GetAxisRaw("Vertical(Controller)") == 1 && count > 10)
        {
            Debug.Log(count);
            player.AddForce(0, jumpingSpeed, 0);
            count -= 1;
        }
        else if (!touchingFloor)
        {
            count -= 1;
        }
        else if (touchingFloor)
        {
            count = maxCount;
        }
        
    }
    /// Knock player back when firing gun
    public void Knockback (float knockbackForce)
    {
        var cube = player.transform.GetChild(0);
        var cubeRotation = cube.transform.localEulerAngles;
        player.AddForce(-(cube.right * knockbackForce), ForceMode.Impulse);
    }
}
