﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using DEEP.Entities.Player;

namespace DEEP.Stage
{

    public class SecretTrigger : MonoBehaviour
    {

        [Tooltip("Audio that will be played when discovered.")]
        [SerializeField] protected AudioClip feedbackAudio = null;

        [Tooltip("Text to be logged when collected.")]
        [SerializeField] protected string logText = "Collected";

        [Tooltip("Icon to be presented in the log message when collected.")]
        [SerializeField] protected Sprite logIcon = null;

        [Tooltip("Color to be used in the log message when collected.")]
        [SerializeField] protected Color logColor = new Color( 0.6f, 0.6f, 0.6f, 0.8f);

        private void OnTriggerEnter(Collider other)
        {

            if(other.tag != "Player")
                return;

            // Logs that this secret has been found.
            Debug.Log("Secret found!");
            if(logText.Length > 0)
                PlayerController.Instance.HUD.Log.Message(logText, logIcon, logColor);

            // Count this secret as found.
            StageManager.Instance.CountSecretFound();
            // Plays the player feedback.
            PlayerController.Instance.FoundSecret(feedbackAudio);

            Destroy(this.gameObject);
            
        }
    }
}
