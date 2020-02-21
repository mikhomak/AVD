using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField] private IPlayer player;

    void Update() {
        if (Input.GetKeyDown("Jump"))
        {
            if(player.getMovement() is IJumpable)
            {
                ((IJumpable)player.getMovement()).jump();
            }
        }
    }


    public static float getHorInput() {
        return Input.GetAxis("Horizontal");
    }
}
