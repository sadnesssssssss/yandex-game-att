using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class PlayerCollision : MonoBehaviour
{
    public static event Action<string, int> OnPortalEnter;

    private void OnTriggerEnter(Collider other)
    {
        print(1);
        if (other.TryGetComponent(out ScorePortal portal))
        {
            OnPortalEnter?.Invoke(portal.GetOperation(), portal.GetValue());
        }
    }
}