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

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            PlayerStatus.speed += 10;
            Destroy(gameObject);
        }
    }
}