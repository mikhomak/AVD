using UnityEngine;

public interface IPlayer 
{
    void changeMovement(MovementType type);
    Stats getStats();
    Rigidbody2D getRigidbody2D();
    IAnimatorFacade getAnimatorFacade();
    Transform getTransform();
    IMovement getMovement();
}
