using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLogger : MonoBehaviour
{
    public Transform CollisionTracker;

    private void OnCollisionEnter(Collision collision) {
        ContactPoint cp = collision.contacts[0];
        Vector3 point = cp.point;
        
        CollisionTracker.position = point;

        //Debug.Log("Hitpoint x: " + CollisionTracker.localPosition.x + ", z: " + CollisionTracker.localPosition.z);
    }
}
