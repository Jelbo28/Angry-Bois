using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resetter : MonoBehaviour {

    [SerializeField]
    Rigidbody2D projectile;
    [SerializeField]
    float resetSpeed = 0.025f;

    private float resetSpeedSqr;
    private SpringJoint2D spring;

    void Start()
    {
        resetSpeedSqr = resetSpeed * resetSpeed;
        spring = projectile.GetComponent<SpringJoint2D>();
    }

	void Update ()
    {
        if (Input.GetKeyDown (KeyCode.R))
        {
            Reset();
        }
        if(spring == null && projectile.velocity.sqrMagnitude < resetSpeedSqr)
        {
            Reset();
        } 
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Rigidbody2D>() == projectile)
        {
            Reset();
        }
    }

    void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
