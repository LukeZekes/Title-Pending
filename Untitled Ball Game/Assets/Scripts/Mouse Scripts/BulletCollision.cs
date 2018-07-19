using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour {
    public float damage;
    public float health;
    public GameObject playerThatFired;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
           if (collision.collider.name != playerThatFired.name)
            {
                health = collision.collider.GetComponent<PlayerHealth_Controller>().health;
                health -= damage;
                collision.collider.GetComponent<PlayerHealth_Controller>().takeDamage(this);
            }
        }
        Destroy(this.gameObject);
    }
}
