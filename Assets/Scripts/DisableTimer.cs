using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisableTimer : MonoBehaviour {
    private float disableTimeValue;

    private void LateUpdate() {
        disableTimeValue -= Time.deltaTime;
        if (disableTimeValue <= 0f ) {
            gameObject.SetActive(false);
        }
    }

    public void SetDisableTime(float disableTimeValue) {
        this.disableTimeValue = disableTimeValue;
    }
}