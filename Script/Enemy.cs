using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public Transform player;
    private NavMeshAgent enemy;
    public float checkDistance = 10.0f;
    public float AttackDistance = 2.0f;
    public float health = 100f;
    public float walkCheckDistance = 0.5f;
    public float enemyEyesAngle = 45.0f;
    public bool Died = false;
    public AudioClip Atk;
    public AudioClip Idle;
    public AudioClip Run;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        enemy = GetComponent<NavMeshAgent>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);
        

if (health >= 1f)
{
    
if (Vector3.Distance(player.position, transform.position) > AttackDistance)
{
    

        if (Vector3.Distance(player.position, transform.position) < checkDistance)
        {
            direction.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            


            if(direction.magnitude > walkCheckDistance)
            {
                transform.Translate(0, 0, 0.04f);
                animator.SetBool("Run", true);
                animator.SetBool("Idle", false);   
                animator.SetBool("Die", false);     
                animator.SetBool("Attack", false);      
                GetComponent<AudioSource>().PlayOneShot(Run);      
            }
            
        }
       
        else
        {
            animator.SetBool("Run", false);
            animator.SetBool("Idle", true);
            animator.SetBool("Die", false);     
            animator.SetBool("Attack", false);  
            GetComponent<AudioSource>().PlayOneShot(Idle);   
            
        }
}
     else
     {
        animator.SetBool("Run", false);
        animator.SetBool("Idle", false);
        animator.SetBool("Die", false);     
        animator.SetBool("Attack", true); 
        GetComponent<AudioSource>().PlayOneShot(Atk);    
                   
            }

    }
    }
    
    
    public void TakeDamage (float amount)
    {
        
        health -= amount;
        if (health <= 9f)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Die", true);     
            animator.SetBool("Attack", false); 
            Died = true;
            Scoremanager.score++;
            Destroy(GetComponent<CapsuleCollider>());  
        }
       
            
        

        
    }

    
  
}
