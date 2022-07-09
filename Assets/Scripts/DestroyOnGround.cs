using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnGround : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            // Destroys object if it touches the ground
            Destroy(gameObject);
            // Subtract a life
        }
    }
}
