using System;
using UnityEngine;
using UnityEngine.UI;

namespace PulseTD.Game
{
    public class HeartHpHUD : MonoBehaviour
    {
        private Heart? _heart;
        private Image? _heartHpImageBar;
        private const string HeartHpHudBarTagName = "HeartHpHudBar";

        private void Awake()
        {
            var heartGo = GameObject.FindGameObjectWithTag(Heart.TagName);
            if (heartGo == null)
            {
                Debug.LogError("No heart game object found");
                return;
            }

            _heart = heartGo.GetComponent<Heart>();
            if (_heart == null)
            {
                Debug.LogError("No heart component found");
                return;
            }

            var heartHpHudGo = GameObject.FindGameObjectWithTag(HeartHpHudBarTagName);
            _heartHpImageBar = heartHpHudGo.GetComponent<Image>();
        }

        private void Update()
        {
            if (_heart == null || _heartHpImageBar == null)
            {
                return;
            }

            var fill = Math.Min(_heart.currentHP / (float)_heart.initalHP, 1f);
            _heartHpImageBar.fillAmount = fill;
        }
    }
}