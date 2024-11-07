using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class HitHurtSystem : MonoBehaviour
{
    List<string> hittableTags;   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hittableTags = new List<string>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("¡Se ha detectado un enemigo!");
        }
    }
    void HitCollider() 
    {
        //UnityEvent onHitDelivered(HitCollider,HurtCollider);
    }
    void HurtCollider() 
    {
    
    }
}
