using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBoolSetter : MonoBehaviour
{
    [SerializeField]private Animator animator;
    [SerializeField]private PlayerMovement player;
    [SerializeField]private Projectile_weapon weapon;


    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        player = GameObject.Find("FirstPersonPlayer").GetComponent<PlayerMovement>();
        weapon = this.GetComponent<Projectile_weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.enabled = weapon.enabled;
        animator.SetBool("isWalking", player.isWalking);
        animator.SetBool("isRunning", player.isRunning);
        animator.SetBool("Shooting", weapon.shooting);
        animator.SetBool("Reloading", weapon.reloading);

    }
}
