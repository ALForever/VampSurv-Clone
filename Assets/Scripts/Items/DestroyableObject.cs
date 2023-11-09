using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour, IDamageable {

    public void TakeDamage(int damage) {
        Destroy(gameObject);
    }
}