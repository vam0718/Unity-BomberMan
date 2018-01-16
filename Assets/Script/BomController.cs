using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomController : MonoBehaviour {

    public float bomDelay;
    private SphereCollider BomCollider;

    public float exprosionDelay;
    public GameObject ExprosionPrefab;
    public GameObject ExprosionPrefab2;

    void Start()
    {
        BomCollider = GetComponent<SphereCollider>();
    }

    void Update()
    {
        bomDelay -= Time.deltaTime;
        if (bomDelay < 0)
        { 
            Destroy(this.gameObject);
            ExprosionSet();
            Player.colliderHit = false;
        }
    } 

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Bom")
        {
  
        }

        if (hit.gameObject.tag == "Fire")
        {
            Destroy(gameObject);
            ExprosionSet();
        }
    }

    public void ExprosionSet()
    {
        Instantiate(ExprosionPrefab2, transform.position, transform.rotation);
        PlayerStatus.bomSetCount++;
    }

    void OnTriggerExit(Collider other)
    {
        BomCollider.isTrigger = false;
        Player.colliderHit = false;
    }
}
