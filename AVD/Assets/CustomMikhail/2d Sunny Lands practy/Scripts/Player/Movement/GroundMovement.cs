using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : AbstractMovement, IFallable, IJumpable
{
    public GroundMovement(IPlayer player) : base(player) { }

    public bool isFalling()
    {
        throw new System.NotImplementedException();
    }

    public void jump()
    {
        rb2d.AddForce();
    }
}
