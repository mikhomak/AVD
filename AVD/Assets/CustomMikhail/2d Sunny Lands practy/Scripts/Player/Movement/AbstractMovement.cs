using CustomMikhail._2d_Sunny_Lands_practy.Scripts.Auido;
using UnityEngine;

namespace CustomMikhail._2d_Sunny_Lands_practy.Scripts.Player.Movement {
    public abstract class AbstractMovement : IMovement {
        protected IPlayer player;
        protected Rigidbody2D rb2d;
        protected IAnimatorFacade animatorFacade;
        protected Transform transform;
        protected IAudioManager audioManager;

        protected bool facingRight = true;


        protected AbstractMovement(IPlayer player) {
            this.player = player;
            rb2d = player.getRigidbody2D();
            animatorFacade = player.getAnimatorFacade();
            transform = player.getTransform();
            audioManager = player.getAudioManager();
        }

        public virtual void setUp() {
            facingRight = transform.localScale.x > 0;
        }

        public virtual void move(float direction) {
            checkFlip(direction);
        }

        public abstract void cleanUp();


        public void changeMovement(MovementType type) {
            player.changeMovement(type);
        }

        protected void FlipSprite() {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }


        protected void checkFlip(float direction) {
            if (direction > 0 && !facingRight) {
                FlipSprite();
            }else if (direction < 0 && facingRight) {
                FlipSprite();
            }
        }
        
        protected void addVelocity(Vector2 velocity) {
            rb2d.velocity = velocity;
        }
    }
}