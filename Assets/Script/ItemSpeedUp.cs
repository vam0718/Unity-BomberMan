using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpeedUp : MonoBehaviour
{
	void Update()
    {
        float z = 4;
        this.transform.Rotate(0.0f, 0.0f, z);
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Fire" || hit.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Debug.Log("Fire HIT");

        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            PlayerStatus.speed += 5;
            Destroy(gameObject);
        }

        if(hit.gameObject.tag == "Fire" || hit.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Debug.Log("Fire HIT");

        }
    }
}