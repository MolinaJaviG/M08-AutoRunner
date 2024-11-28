using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using Unity.VisualScripting;

public class HitCollider : MonoBehaviour
{
    UnityEvent<HitCollider, HurtCollider> onHitDelivered;
    List<string> hittableTags;

    private void OnTriggerEnter(Collider other)
    {
        CheckCollider(other);
    }
    private void OnCollisionEnter(Collision collision)
    {
        CheckCollider(collision.collider);
    }

    private void CheckCollider(Collider other)
    {
        if (hittableTags.Contains(other.tag))
        {
            HurtCollider hurtCollider = other.GetComponent<HurtCollider>();
            if (hurtCollider)
            {
                hurtCollider.NotifyHit(this);
                onHitDelivered.Invoke(this, hurtCollider);
            }

        }
    }

}


