using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour {

    [SerializeField] private GameObject dropObject;
    [SerializeField] [Range(0f, 1f)] private float chance = 1f;
    public void OnDestroy() {
        if (Random.value <= chance) {
            Instantiate(dropObject, gameObject.transform.position, Quaternion.identity, gameObject.transform.parent);
        }        
    }
}