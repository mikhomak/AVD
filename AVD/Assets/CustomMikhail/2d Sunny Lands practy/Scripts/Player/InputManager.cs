using System;
using UnityEngine;

namespace CustomMikhail._2d_Sunny_Lands_practy.Scripts.Player {
    public class InputManager : MonoBehaviour {
        [SerializeField] private GameObject playerGo;
        private IPlayer player;
        
        private void Start() {
            player = playerGo.GetComponent<IPlayer>();
        }

        void Update() {
            if (Input.GetButtonDown("Jump")) {
                if (player.getMovement() is IJumpable) {
                    ((IJumpable) player.getMovement()).jump();
                }
            }
        }


        public static float getHorInput() {
            return Input.GetAxis("Horizontal");
        }
    }
}