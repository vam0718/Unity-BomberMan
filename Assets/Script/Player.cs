using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject BomPrefab;
    private CapsuleCollider playerCollider;
    public static bool colliderHit = false;
    public bool clearHit = false;

    void Start()
    {
        playerCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        if (colliderHit == false)
        {
            if (Input.GetKeyDown("z")) BomSet();
        }

        if (Input.GetKeyDown("y"))colliderHit = false;
    }

    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(clearHit == false)
        {
            rigidbody.AddForce(x * PlayerStatus.speed, 0, z * PlayerStatus.speed);
            rigidbody.velocity = Vector3.zero;
        }
        if(clearHit == true)
        {
            rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
            rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
            pos.y -= 0.5f;
        }
    }

    public void BomSet()
    {
        if (PlayerStatus.bomSetCount <= 0) return;

        Instantiate(BomPrefab, transform.position, transform.rotation);
        PlayerStatus.bomSetCount--;
    }

    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Bom")
        {
            colliderHit = true;
        }

        if (hit.gameObject.tag == "Fire")
        {
            //Destroy(gameObject);
        }

        if (hit.gameObject.tag == "ClearPlane")
        {
            playerCollider.isTrigger = true;
            clearHit = true;
        }
    }
}