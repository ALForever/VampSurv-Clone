using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {
    [SerializeField] private int healingPoints = 20;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject == Player.Instance.gameObject) {
            Player.Instance.Heal(healingPoints);
            Destroy(gameObject);
        }
    }
}