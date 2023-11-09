using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : MonoBehaviour
{
    [SerializeField] private int whipDamage = 1;

    [SerializeField] private float maxAttackCooldown = 4f;
    private float currentAttackCooldown;

    [SerializeField] private float attackTimerDuration = 0.3f;



    [SerializeField] private GameObject leftWhip;
    [SerializeField] private GameObject rightWhip;
    [SerializeField] private Vector2 leftWhipBoxSize = new Vector2 (2.6f, 1f);
    [SerializeField] private Vector2 rightWhipBoxSize = new Vector2(2.6f, 1f);

    private DisableTimer leftWhipDisableTimer;
    private DisableTimer rightWhipDisableTimer;

    private PlayerMovement playerMovement;

    private void Start() {
        currentAttackCooldown = maxAttackCooldown;
        playerMovement = Player.Instance.GetComponent<PlayerMovement>();
        leftWhipDisableTimer = leftWhip.GetComponent<DisableTimer>();
        rightWhipDisableTimer = rightWhip.GetComponent<DisableTimer>();

        leftWhipDisableTimer.gameObject.SetActive(false);
        rightWhipDisableTimer.gameObject.SetActive(false);
    }

    private void Update() {
        currentAttackCooldown -= Time.deltaTime;
        if (currentAttackCooldown <= 0f) {
            currentAttackCooldown = maxAttackCooldown;
            Attack();
        }
    }

    private void Attack() {
        if (playerMovement.GetDirection().x <= 0f) {
            LeftWhipAttack();
        } else if (playerMovement.GetDirection().x > 0f) {
            RightWhipAttack();
        }
    }

    private void LeftWhipAttack() {
        leftWhip.SetActive(true);
        leftWhipDisableTimer.SetDisableTime(attackTimerDuration);

        Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipDisableTimer.transform.position, leftWhipBoxSize, 0f);
        ApplayDamage(colliders);

    }
    private void RightWhipAttack() {
        rightWhip.SetActive(true);
        rightWhipDisableTimer.SetDisableTime(attackTimerDuration);

        Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipDisableTimer.transform.position, rightWhipBoxSize, 0f);
        ApplayDamage(colliders);
    }
    private void ApplayDamage(Collider2D[] colliders) {
        foreach (Collider2D collider in colliders) {
            IDamageable enemy = collider.GetComponent<IDamageable>();
            if (enemy != null) {
                enemy.TakeDamage(whipDamage);
            }
        }
    }

}