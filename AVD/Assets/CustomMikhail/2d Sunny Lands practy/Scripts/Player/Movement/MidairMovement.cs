using UnityEngine;

namespace CustomMikhail._2d_Sunny_Lands_practy.Scripts.Player.Movement {
    public class MidairMovement : AbstractMovement, IFallable, IJumpable {
        public MidairMovement(IPlayer player) : base(player) {
        }

        public bool isFalling() {
            return !CommonMethods.onGround(rb2d.position, player.getStats().GroundDistanceCheck);
        }

        public override void setUp() {
            base.setUp();
            rb2d.gravityScale = 3f;
            animatorFacade.setOnGround(false);
        }

        public override void move(float direction) {
            base.move(direction);
            if (!isFalling()) {
                animatorFacade.setOnGround(true);
                changeMovement(MovementType.ground);
                return;
            }

            updateAnimations();
            addVelocity(new Vector2(direction * player.getStats().Speed, rb2d.velocity.y));
            addAditionalGravityWhenFalling();
            checkForMaximumDownVelocity();
        }


        private void updateAnimations() {
            animatorFacade.setVerticalSpeed(rb2d.velocity.y);
        }

        private void addAditionalGravityWhenFalling() {
            if (rb2d.velocity.y < 0) {
                rb2d.AddForce(Vector2.down * player.getStats().AdditionalGravity);
            }
        }

        private void checkForMaximumDownVelocity() {
            if (rb2d.velocity.y < player.getStats().MaximumDownSpeed * -1) {
                rb2d.velocity =
                    CommonMethods.createVectorWithoutLoosingXValue(rb2d.velocity, player.getStats().MaximumDownSpeed * -1);
            }
        }

        public override void cleanUp() {
            rb2d.gravityScale = 1f;
            animatorFacade.setVerticalSpeed(0);
        }

        public void jump() {
            changeMovement(MovementType.eagle);
        }
    }
}