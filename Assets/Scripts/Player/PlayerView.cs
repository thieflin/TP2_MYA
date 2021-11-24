using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour 
{ 
    private Animator playerAnim;
    [SerializeField] private PlayerController _controller;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
        _controller.OnMove += AnimationHandler;
    }

   
    private void AnimationHandler(float horizontalMove)
    {
        if(horizontalMove < 0)
        {
            playerAnim.SetBool("IsGoingLeft", true);
            playerAnim.SetBool("IsGoingRight", false);
        }
        else if (horizontalMove > 0)
        {
            playerAnim.SetBool("IsGoingLeft", false);
            playerAnim.SetBool("IsGoingRight", true);
        }
        else if (horizontalMove == 0)
        {
            playerAnim.SetBool("IsGoingLeft", false);
            playerAnim.SetBool("IsGoingRight", false);
        }
    }

}
 