using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private Animator anim;

    public Image healthBar; 

    public void TakeDamage(float damage){
        anim.SetTrigger("hit");  
        health -= damage;   
        healthBar.fillAmount = health / 100f;

        if(health <=0f){
            Destroy(gameObject);
            Debug.Log("player died");
        }
         
    }
}
