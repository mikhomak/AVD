using UnityEngine;

namespace CustomMikhail._2d_Sunny_Lands_practy.Scripts.Player {
    public interface IParticleManager {
        void activateDustParticles(bool activate);
        void rotateDustParticles(bool right);
        void activateFollowingTrail(bool activate);
        void emitTransformation();
        void emitJumpParticles(Vector3 position);
    }
}