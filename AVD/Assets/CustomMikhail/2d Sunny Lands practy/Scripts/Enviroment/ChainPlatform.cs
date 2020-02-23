using CustomMikhail._2d_Sunny_Lands_practy.Scripts.Player;
using CustomMikhail._2d_Sunny_Lands_practy.Scripts.Player.Movement;
using UnityEngine;

namespace CustomMikhail._2d_Sunny_Lands_practy.Scripts.Enviroment {
    public class ChainPlatform : MonoBehaviour {
        [SerializeField] private HingeJoint2D hingeJoint2D;


        private void OnTriggerEnter2D(Collider2D other) {
            var player = other.GetComponent<IPlayer>();
            if (player?.getMovement() is EagleMovement) {
                hingeJoint2D.enabled = false;
                Destroy(gameObject);
            }
        }
    }
}