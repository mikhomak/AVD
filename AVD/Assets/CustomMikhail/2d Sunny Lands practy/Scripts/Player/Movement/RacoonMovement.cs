using CustomMikhail._2d_Sunny_Lands_practy.Scripts.Auido;
using UnityEngine;

namespace CustomMikhail._2d_Sunny_Lands_practy.Scripts.Player.Movement {
    public class RacoonMovement : AbstractMovement, IFallable, IJumpable{
        
        private IParticleManager particleManager;
        private int initialDirection;

        
        public RacoonMovement(IPlayer player) : base(player) {
            particleManager = player.getParticleManager();
        }

        
        public override void setUp() {
            base.setUp();
            animatorFacade.setOnGround(true);
            animatorFacade.setRacoon(true);
            initialDirection = (int) transform.localScale.x;
            FlipSprite();
            activateDustParticles(initialDirection);
            particleManager.emitRacoonTransform();
        }
        
        public override void cleanUp() {
            particleManager.activateDustParticles(false);
            animatorFacade.setRacoon(false);
        }
        
        public override void move(float direction) {
            if (isFalling()) {
                animatorFacade.setOnGround(false);
                changeMovement(MovementType.midair);
                return;
            }

            if (direction == 0) {
                changeMovement(MovementType.ground);
                return;
            }
            
            addVelocity(new Vector2(initialDirection * player.getStats().RacoonSpeed, rb2d.velocity.y));
        }


        private void activateDustParticles(float direction) {
            if(Mathf.Abs(direction)>0){
                particleManager.activateDustParticles(true);
                particleManager.rotateDustParticles(direction > 0);
                return;
            }
            particleManager.activateDustParticles(false);
        }

        
        public bool isFalling() {
            return !CommonMethods.onGround(rb2d.position, player.getStats().GroundDistanceCheck);
        }

        public void jump() {
            audioManager.playAudio(AudioEffects.jump);
            particleManager.emitJumpParticles(transform.position);
            rb2d.AddForce(Vector2.up * player.getStats().JumpForce);
        }
    }
}