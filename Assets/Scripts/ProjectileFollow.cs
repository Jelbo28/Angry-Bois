using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFollow : MonoBehaviour {

    [SerializeField]
    Transform projectile;
    [SerializeField]
    Transform farLeft;
    [SerializeField]
    Transform farRight;

    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = projectile.position.x;
        newPosition.x = Mathf.Clamp(newPosition.x, farLeft.position.x, farRight.position.x);
        transform.position = newPosition;
    }
}
