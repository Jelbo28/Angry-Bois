using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAttack : MonoBehaviour
{
    [SerializeField]
    Sprite joe;
    [SerializeField]
    Sprite bob;
    [SerializeField]
    PhysicsMaterial2D friction;

    private bool attack = false;
    private SpringJoint2D spring;

    void Start ()
    {
        spring = GetComponent<SpringJoint2D>();
    }

    void Update()
    {
        if (spring == null && Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Yey");
            attack = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = joe;
            gameObject.AddComponent<BoxCollider2D>();
            gameObject.GetComponent<BoxCollider2D>().sharedMaterial = friction;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 10;
           //Debug.Log("Hooray");
        }

        Vector2 moveDirection = gameObject.GetComponent<Rigidbody2D>().velocity;
        if (moveDirection != Vector2.zero && attack == false)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //GlitchCat
            //Vector2 dir = gameObject.GetComponent<Rigidbody2D>().velocity;
            //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            //gameObject.GetComponent<Rigidbody2D>().MoveRotation(angle);
        }
    }
}
