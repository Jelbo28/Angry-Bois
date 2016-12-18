using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamager : MonoBehaviour
{
    [SerializeField]
    float health;
    [SerializeField]
    float immunity;
    private float collisonPower;

    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //if (coll.gameObject.tag == "Damager" || coll.gameObject.tag == "Player")
        if (coll.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            collisonPower = KineticEnergy(coll.gameObject.GetComponent<Rigidbody2D>());
            Debug.Log(this.gameObject.name + ", health = " + collisonPower);
            if (collisonPower > immunity)
            {
                health -= collisonPower;
                if (health <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    public static float KineticEnergy(Rigidbody2D rb)
    {
        // mass in kg, velocity in meters per second, result is joules
        return 0.5f * rb.mass * Mathf.Pow(rb.velocity.magnitude, 2);
    }
}
