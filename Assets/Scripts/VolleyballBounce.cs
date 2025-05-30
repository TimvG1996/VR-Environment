using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolleyballBounce : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Terrain")
        {
            FindObjectOfType<AudioManager>().Play("VolleyballBounce");
        }
    }
}
