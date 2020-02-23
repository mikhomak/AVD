using System.Collections.Generic;
using CustomMikhail._2d_Sunny_Lands_practy.Scripts.Auido;
using CustomMikhail._2d_Sunny_Lands_practy.Scripts.Player.Movement;
using UnityEngine;

namespace CustomMikhail._2d_Sunny_Lands_practy.Scripts.Player {
    public class Player : MonoBehaviour, IPlayer {
        [SerializeField] private GameObject dustParticles;
        [SerializeField] private GameObject trailParticles;
        [SerializeField] private ParticleSystem transformationParticleSystem;
        [SerializeField] private GameObject jumpParticlesSystem;
        
        private Rigidbody2D rb2d;
        private Vector3 velocity;
        private readonly Dictionary<MovementType, IMovement> movements = new Dictionary<MovementType, IMovement>();
        private IAnimatorFacade animatorFacade;
        private IMovement movement;
        private  IParticleManager particleManager;
        private Stats stats;
        private IAudioManager audioManager;

        private void Start() {
            rb2d = GetComponent<Rigidbody2D>();
            animatorFacade = GetComponentInChildren<IAnimatorFacade>();
            stats = GetComponent<Stats>();
            audioManager = GetComponent<IAudioManager>();
            particleManager = new ParticleManager(dustParticles,trailParticles,transformationParticleSystem, jumpParticlesSystem);
            initMovemnts();
            movement = movements[MovementType.ground];
        }


        private void FixedUpdate() {
            movement.move(InputManager.getHorInput());
        }


        private void initMovemnts() {
            movements.Add(MovementType.ground, new GroundMovement(this));
            movements.Add(MovementType.midair, new MidairMovement(this));
            movements.Add(MovementType.eagle, new EagleMovement(this));
        }


        public Rigidbody2D getRigidbody2D() {
            return rb2d;
        }

        public Stats getStats() {
            return stats;
        }

        public void changeMovement(MovementType type) {
            movement.cleanUp();
            movement = movements[type];
            movement.setUp();
        }

        public Transform getTransform() {
            return transform;
        }

        public IAnimatorFacade getAnimatorFacade() {
            return animatorFacade;
        }

        public IMovement getMovement() {
            return movement;
        }

        public Vector3 getVelocityToShow() {
            return velocity;
        }

        public IParticleManager getParticleManager() {
            return particleManager;
        }

        public IAudioManager getAudioManager() {
            return  audioManager;
        }
    }
}