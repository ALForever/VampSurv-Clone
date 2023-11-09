using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public static Player Instance { get; private set; }

    public event EventHandler<OnHealthChangedEventArgs> OnHealthChanged;
    public class OnHealthChangedEventArgs : EventArgs {
        public float healthNormalized;
    }




    [SerializeField] private float speed;
    [SerializeField] private int maxHp = 100;
    [SerializeField] private int currentHp;



    private void Awake() {
        if (Instance != null) {
            Debug.LogError("There is more than one Player instance");
        }
        Instance = this;
    }
    private void Start() {
        if (currentHp > maxHp) {
            currentHp = maxHp;
        }        

        UpdateHpBar();
    }


    public float GetSpeedValue() {
        return speed;
    }
    public void TakeDamage(int damage) {
        currentHp -= damage;
        if (currentHp <= 0) {
            currentHp = 0;
            PlayerDeath();
        }
        UpdateHpBar();
    }
    private void PlayerDeath() {
        Debug.Log("PLAYER DIED!");
    }
    public void Heal(int healingPoint) {
        currentHp += healingPoint;
        if (currentHp > maxHp) {
            currentHp = maxHp;
        }
        UpdateHpBar();
    }

    private void UpdateHpBar() {
        OnHealthChanged?.Invoke(this, new OnHealthChangedEventArgs {
            healthNormalized = (float)currentHp / maxHp
        });
    }
}