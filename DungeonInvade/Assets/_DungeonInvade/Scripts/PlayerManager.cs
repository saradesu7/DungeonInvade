using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerThirdPersonMovement playerMovement;
    [SerializeField] Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerThirdPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.isWalking)
        {
            playerAnimator.SetBool("walk", true);
        }
        else
        {
            playerAnimator.SetBool("walk", false);
        }
    }
}
