using UnityEngine;

public class Fire : MonoBehaviour {
    public float bulletDespawnTimer;
    public float maxShootTimer;
    float shootTimer = 10;
    public float speed;
    public Rigidbody bullet;
    public Transform sphere;
    Vector3 originalSphereScale = new Vector3(0.15f, 1.5f, 1.5f);
    float chargingCounter = 0;
    public float damageMultiplier; ///Multiply bullet damage by this IF held down for more than 10 frames
    public float baseKnockbackForce;
    float knockbackForce;
    GameObject playerThatFired;
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1(mouse)") && shootTimer <= 0)
        {
            if (chargingCounter < 100)
            {
                knockbackForce += .5f;
                chargingCounter++;
                sphere.localScale += new Vector3(.003f, .03f, .03f);
            }
        }
        if (Input.GetButtonUp("Fire1(mouse)"))
        {
            damageMultiplier = chargingCounter / 10;
            var clone = Instantiate(bullet, transform.position, transform.rotation);
            if (chargingCounter > 10)
            {
                var scaleX = sphere.localScale.x * 2; ///These 3 lines account for change from local to world scale
                var scaleY = sphere.localScale.y * 0.2f;
                var scaleZ = sphere.localScale.z * 0.2f;
                clone.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
                FindObjectOfType<BulletCollision>().damage = FindObjectOfType<BulletCollision>().damage * damageMultiplier;
                clone.velocity = transform.TransformDirection(((speed * chargingCounter) / 10) + 9, 0, 0); ///Until chargingCounter = 20, this speed is lower than just rapid fire
                this.transform.GetComponentInParent<PlayerMovement>().Knockback(knockbackForce);
            }
            else
            {
                this.transform.GetComponentInParent<PlayerMovement>().Knockback(baseKnockbackForce);
                clone.velocity = transform.TransformDirection(speed * 2, 0, 0); ///20 
            }
            sphere.localScale = originalSphereScale;
            chargingCounter = 0;
            clone.GetComponent<BulletCollision>().playerThatFired = this.transform.parent.parent.gameObject;
            shootTimer = maxShootTimer;
            Destroy(clone.gameObject, 1);
        }
        shootTimer -= 1;
    }
}