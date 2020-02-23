using System;
using System.Collections.Generic;
using UnityEngine;

namespace CustomMikhail._2d_Sunny_Lands_practy.Scripts.Auido {
    public class AudioManager : MonoBehaviour, IAudioManager {
        private AudioSource audioSource;
        [SerializeField] private List<Audio> audios;

        [Serializable]
        private struct Audio {
            public AudioEffects audioEffect;
            public AudioClip audioClip;
            
        }

        private void Start() {
            audioSource = GetComponent<AudioSource>();
        }

        public void playAudio(AudioEffects audioEffect) {
            var audioClip = audios.Find(audio => Equals(audio.audioEffect, audioEffect)).audioClip;
            if (audioClip != null) {
                audioSource.PlayOneShot(audioClip);
            }
        }
    }
}