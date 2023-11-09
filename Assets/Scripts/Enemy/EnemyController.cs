using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable {
    private Rigidbody2D rb2d;

    [SerializeField] private int Hp;
    [SerializeField] private float speed;
    [SerializeField] private int attack;
    [SerializeField] private float maxAttackCooldown;
    [SerializeField] private float currentAttackCooldown;


    private Vector3 directionNormolized;

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        Vector3 direction = Player.Instance.transform.position - transform.position;
        directionNormolized = direction.normalized;
    }
    void FixedUpdate() {
        rb2d.MovePosition(rb2d.position + (Vector2)directionNormolized * speed * Time.fixedDeltaTime);
        currentAttackCooldown -= Time.fixedDeltaTime;

    }
    private void OnCollisionStay2D(Collision2D collision) {
        
        if (collision.gameObject == Player.Instance.gameObject && currentAttackCooldown <= 0f) {
            Attack();
        }
    }

    private void Attack() {
        currentAttackCooldown = maxAttackCooldown;
        Player.Instance.TakeDamage(attack);
    }

    public void TakeDamage(int attack) {
        Hp -= attack;
        if (Hp <= 0f) {
            EnemyDeath();
        }
    }

    private void EnemyDeath() {
        Destroy(gameObject);
    }
}