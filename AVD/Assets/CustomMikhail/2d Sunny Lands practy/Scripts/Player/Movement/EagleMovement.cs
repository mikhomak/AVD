using CustomMikhail._2d_Sunny_Lands_practy.Scripts.Auido;
using UnityEngine;

namespace CustomMikhail._2d_Sunny_Lands_practy.Scripts.Player.Movement {
    public class EagleMovement : AbstractMovement, IJumpable {
        private int initialDirection;
        private readonly IParticleManager particleManager;

        public EagleMovement(IPlayer player) : base(player) {
            particleManager = player.getParticleManager();
        }

        public override void setUp() {
            base.setUp();
            initialDirection = (int) transform.localScale.x;
            FlipSprite();
            rb2d.gravityScale = 0;
            animatorFacade.setEagle(true);
            particleManager.activateFollowingTrail(true);
            particleManager.emitTransformation();
            audioManager.playAudio(AudioEffects.transformToEagle);
        }

        public override void cleanUp() {
            rb2d.gravityScale = 1;
            animatorFacade.setEagle(false);
            FlipSprite();
            particleManager.activateFollowingTrail(false);
        }

        public override void move(float direction) {
            addVelocity(new Vector2(initialDirection * player.getStats().EagleSpeed, 0));
        }

        public void jump() {
            rb2d.AddForce(Vector2.up * player.getStats().EagleJumpForce );
            changeMovement(MovementType.midair);
        }
    }
}