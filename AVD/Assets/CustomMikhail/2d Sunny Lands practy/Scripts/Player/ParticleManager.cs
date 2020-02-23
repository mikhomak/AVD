using UnityEngine;

namespace CustomMikhail._2d_Sunny_Lands_practy.Scripts.Player {
    public class ParticleManager : IParticleManager {

        private readonly GameObject dustParticle;
        private readonly GameObject trailParticle;
        private readonly ParticleSystem transformationParticles;
        private readonly GameObject jumpParticlesGO;
        private readonly ParticleSystem jumpParticles;
        
        
        
        public ParticleManager(GameObject dustParticle, GameObject trailParticle, ParticleSystem transformationPs, GameObject jumpParticles) {
            this.dustParticle = dustParticle;
            this.trailParticle = trailParticle;
            transformationParticles = transformationPs;
            jumpParticlesGO = jumpParticles;
            this.jumpParticles = jumpParticlesGO.GetComponent<ParticleSystem>();
        }

        public void activateDustParticles(bool activate) {
            dustParticle.SetActive(activate);
        }

        


        public void rotateDustParticles(bool right) {
            var direction = right ? -90 : 90;
            dustParticle.transform.eulerAngles = Vector3.up * direction;
        }

        public void activateFollowingTrail(bool activate) {
            trailParticle.SetActive(activate);
        }

        public void emitTransformation() {
            transformationParticles.Emit(50);
        }

        public void emitJumpParticles(Vector3 position) {
            jumpParticlesGO.transform.position = position;
            jumpParticles.Emit(10);
        }
    }
}