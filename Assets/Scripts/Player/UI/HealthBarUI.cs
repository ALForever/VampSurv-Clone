using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour{
    [SerializeField] private Image barImage;


    private void Start() {
        Show();
        Player.Instance.OnHealthChanged += Player_OnHealthChanged;
    }
    private void OnDestroy() {
        Player.Instance.OnHealthChanged -= Player_OnHealthChanged;
    }

    private void Player_OnHealthChanged(object sender, Player.OnHealthChangedEventArgs e) {
        barImage.fillAmount = e.healthNormalized;

        if (barImage.fillAmount <= 0 ) {
            Hide();
        }
    }

    private void Show() {
        gameObject.SetActive(true);
    }
    private void Hide() {
        gameObject.SetActive(false);
    }
}