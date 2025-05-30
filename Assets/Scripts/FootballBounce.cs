using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballBounce : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Terrain")
        {
            FindObjectOfType<AudioManager>().Play("FootballBounce");
        }
    }
}
