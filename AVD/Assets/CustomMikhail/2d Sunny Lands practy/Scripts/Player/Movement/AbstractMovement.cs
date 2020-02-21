using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractMovement : IMovement
{

    
    protected IPlayer player;
    protected Rigidbody2D rb2d;
    protected IAnimatorFacade animatorFacade;
    protected Transform transform;

    protected bool facingRight;


    public AbstractMovement(IPlayer player) {
        this.player = player;
        rb2d = player.getRigidbody2D();
        animatorFacade = player.getAnimatorFacade();
    }

    public virtual void setUp() { 
    
    }
    public virtual void move(float direction) { 
    
    }
    public virtual void cleanUp() { 
    
    
    }

    public void changeMovement(MovementType type) { 
    
    }

    protected void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
