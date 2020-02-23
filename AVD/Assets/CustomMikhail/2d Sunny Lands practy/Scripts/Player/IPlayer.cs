using CustomMikhail._2d_Sunny_Lands_practy.Scripts.Auido;
using CustomMikhail._2d_Sunny_Lands_practy.Scripts.Player.Movement;
using UnityEngine;

namespace CustomMikhail._2d_Sunny_Lands_practy.Scripts.Player {
    public interface IPlayer {
        void changeMovement(MovementType type);
        Stats getStats();
        Rigidbody2D getRigidbody2D();
        IAnimatorFacade getAnimatorFacade();
        Transform getTransform();
        IMovement getMovement();
        Vector3 getVelocityToShow();
        IParticleManager getParticleManager();
        IAudioManager getAudioManager();
    }
}