using System;
using CustomMikhail._2d_Sunny_Lands_practy.Scripts.Player;
using CustomMikhail._2d_Sunny_Lands_practy.Scripts.Player.Movement;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace CustomMikhail._2d_Sunny_Lands_practy.Scripts.Boss {
    public class Racoon : MonoBehaviour, IRacoon {

        [SerializeField] private float health = 100f;
        [SerializeField] private GameObject playerGo;
        [SerializeField] private GameObject wallCheck;
        [SerializeField] private float speed= 5f;
        private IPlayer player;
        private Rigidbody2D rb2d;

        private void Start() {
            player = playerGo.GetComponent<IPlayer>();
            rb2d = GetComponent<Rigidbody2D>();
        }


        private void FixedUpdate() {
            if (Physics2D.OverlapCircle(wallCheck.transform.position, 0.1f)) {
                var localScale= rb2d.transform.localScale;
                localScale.x *= -1;
                rb2d.transform.localScale = localScale;
            }
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.transform.localScale.x * -1)* speed, rb2d.velocity.y);
        }

        public void takeDamage(float damage) {
            if (health - damage <= 0) {
                health = 0;
                die();
            }
            else {
                health -= damage;
            }
        }

        public void die() {
            player.addRacoon();
            Destroy(gameObject);
        }
    }
}