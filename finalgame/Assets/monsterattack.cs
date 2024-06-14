using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class monsterattack : MonoBehaviour
{

    [SerializeField] private Animator anim; 
    [SerializeField] private float meleeSpeed;
    [SerializeField] private float damage;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip attacksound;
    //[SerializeField] private float nextAttackTime=10.0f;
   
    private void Update(){
       /*if (Time.time >= nextAttackTime)
        {
            anim.SetTrigger("angry");
            nextAttackTime += 10;
        }
        */
    }
    
    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Trigger entered");
            if(other.tag== "Player"){
                other.GetComponent<Player>().TakeDamage(damage);
                Debug.Log("player hit");
            }
    }

}
