using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamager : MonoBehaviour
{
    [SerializeField]
    float health;
    [SerializeField]
    float immunity;
    public float collisonPower;
    public float collisonPower2;

    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //if (coll.gameObject.tag == "Damager" || coll.gameObject.tag == "Player")
        if (coll.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            collisonPower2 = KineticEnergy(gameObject.GetComponent<Rigidbody2D>());
            Debug.Log(collisonPower2);
            //coll.gameObject.GetComponent<CollisionDamager>().collisonPower = collisonPower2;
            if (gameObject.tag != "Ground")
            {
                collisonPower = KineticEnergy(coll.gameObject.GetComponent<Rigidbody2D>());
                if (collisonPower + collisonPower2 > immunity)
                {
                    health -= collisonPower + collisonPower2;
                    Debug.Log(gameObject.name + ", health = " + health);
                    if (health <= 0)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
        //collisonPower = 0f;
    }

    public static float KineticEnergy(Rigidbody2D rb)
    {
        // mass in kg, velocity in meters per second, result is joules
        return 0.5f * rb.mass * Mathf.Pow(rb.velocity.magnitude, 2);
    }
}
