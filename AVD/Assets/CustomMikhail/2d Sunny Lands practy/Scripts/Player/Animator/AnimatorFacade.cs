using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFacade : MonoBehaviour
{

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();    
    }


    void setSpeed(float speed) { }
    void setVerticalSpeed(float speed) { }
    void setOnGround(bool onGround) { }
    void setCrouching(bool crouch) { }


}
