using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public float health = 100;
    public GameObject self;
    public Material[] materials;
    Renderer player;
    Color defaultColor;
    private void Start()
    {
        player = GetComponent<Renderer>();
        player.sharedMaterial = materials[0];
        player.enabled = true;
    }
    public void takeDamage (BulletCollision_Controller other)
    {
        health = other.health;
        Debug.Log(health);
        if (health <= 0)
        {
            player.sharedMaterial = materials[1];
            player.sharedMaterial.SetFloat("Vector1_C649B6A2", Time.timeSinceLevelLoad);
            Destroy(self, .5f);
        }
    }
}
