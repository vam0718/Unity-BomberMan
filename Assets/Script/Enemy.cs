using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //public float speed = 100;
    public int hp;
    public float speed;
    public bool axisswitch;

    void Update ()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        Vector3 pos = transform.position;
        rigidbody.velocity = Vector3.zero;

        if (axisswitch)
        {
            rigidbody.AddForce(pos.x + speed, 0, 0);
        }
        else
        {
            rigidbody.AddForce(0, 0, pos.z + speed);
        }

        if(hp == 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Fire")
        {
            hp = hp - 1;

            if(hp <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision hit)
    {

        if (hit.gameObject.tag == "UnbreakBlock" || hit.gameObject.tag == "breakBlock" || hit.gameObject.tag == "Wall" || hit.gameObject.tag == "Bom")
        {
            speed *= -1;
        }
    }
}
