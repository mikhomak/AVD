using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Player : MonoBehaviour, IPlayer
{ 
    private Rigidbody2D rb2d;
    private Dictionary<MovementType, IMovement> movements;
    private IMovement movement;

    private void Start()

    {

    }



    private void FixedUpdate()
    {
        movement.move(InputManager.getHorInput());
    }




    private void intMovemnts() {
        movements.Add(MovementType.ground, new GroundMovement(this) );
    }


    public Rigidbody2D getRigidbody2D() { return null; }
    public Stats getStats() { return null; }
    public void changeMovement(MovementType type) {
        movement.cleanUp();
        movement = movements[type];
        movement.setUp();
    }

    public Transform getTransform() {
        return transform;
    }

    public IAnimatorFacade getAnimatorFacade()
    {
        throw new System.NotImplementedException();
    }

    public IMovement getMovement()
    {
        throw new System.NotImplementedException();
    }
}