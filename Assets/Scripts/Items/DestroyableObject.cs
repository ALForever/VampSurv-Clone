using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour, IDamageable {

    [SerializeField] private GameObject lootObject;
    public void TakeDamage(int damage) {
        Instantiate(lootObject, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}