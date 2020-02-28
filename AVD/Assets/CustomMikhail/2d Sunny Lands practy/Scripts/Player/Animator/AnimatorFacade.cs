using UnityEngine;

namespace CustomMikhail._2d_Sunny_Lands_practy.Scripts.Player.Animator {
    public class AnimatorFacade : MonoBehaviour, IAnimatorFacade {
        private UnityEngine.Animator animator;
        private static readonly int Speed = UnityEngine.Animator.StringToHash("Speed");
        private static readonly int VerVelocity = UnityEngine.Animator.StringToHash("verVelocity");
        private static readonly int Grounded = UnityEngine.Animator.StringToHash("grounded");
        private static readonly int Eagle = UnityEngine.Animator.StringToHash("eagle");
        private static readonly int Racoon = UnityEngine.Animator.StringToHash("racoon");

        void Start() {
            animator = GetComponent<UnityEngine.Animator>();
        }


        public void setSpeed(float speed) {
            animator.SetFloat(Speed, speed);
        }

        public void setVerticalSpeed(float speed) {
            animator.SetFloat(VerVelocity, speed);

        }

        public void setOnGround(bool onGround) {
            animator.SetBool(Grounded,onGround);
        }

        public void setCrouching(bool crouch) {
        }

        public void setEagle(bool eagle) {
            animator.SetBool(Eagle,eagle);
        }

        public void setRacoon(bool racoon) {
            animator.SetBool(Racoon, racoon);
        }
    }
}