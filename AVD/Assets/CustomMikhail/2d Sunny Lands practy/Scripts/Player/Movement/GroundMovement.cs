using CustomMikhail._2d_Sunny_Lands_practy.Scripts.Auido;
using UnityEngine;

namespace CustomMikhail._2d_Sunny_Lands_practy.Scripts.Player.Movement {
    public class GroundMovement : AbstractMovement, IFallable, IJumpable {

        private IParticleManager particleManager;
        
        public GroundMovement(IPlayer player) : base(player) {
            particleManager = player.getParticleManager();
        }


        public override void setUp() {
            base.setUp();
            animatorFacade.setOnGround(true);

        }

        public override void move(float direction) {
            base.move(direction);
            if (isFalling()) {
                animatorFacade.setOnGround(false);
                changeMovement(MovementType.midair);
                return;
            }

            activateDustParticles(direction);
            updateAnimations(direction);
            addVelocity(new Vector2(direction * player.getStats().Speed, rb2d.velocity.y));
        }

        private void updateAnimations(float speed) {
            animatorFacade.setSpeed(Mathf.Abs(speed));
        }

        private void activateDustParticles(float direction) {
            if(Mathf.Abs(direction)>0){
                particleManager.activateDustParticles(true);
                particleManager.rotateDustParticles(direction > 0);
                return;
            }
            particleManager.activateDustParticles(false);
        }
        
        public override void cleanUp() {
            animatorFacade.setSpeed(0);
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