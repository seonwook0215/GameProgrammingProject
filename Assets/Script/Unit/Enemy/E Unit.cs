using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EUnit: MonoBehaviour
{
  //  public float speed; //unit speed
    public float distance; //unit attack range
    public float damage; // unit attack damage
    public bool atk = true;
    public AudioSource attackaudioSource;
    public AudioSource hurtaudioSource;
    public AudioClip attack_clip;
    public AudioClip hurt_clip;
    //   public float hp; //unit HP

    GameObject obj;

    private void Start()
    {
        if (this.tag != "Building")
        {
            damage = damage * GameManager.instance.E_multi;
        }
        //this.GetComponent<P2UnitManager>().units.Add(this);
        EUnitManager.instance.units.Add(this);
     //   this.GetComponent<ForwardMovement>().speed = speed;
        //this.GetComponent<Toward>().speed = speed;
        //this.GetComponent<Life>().amount = hp;
        this.GetComponent<overlapspere>().radius = distance;
    }

    private void FixedUpdate()
    {
        if (this.tag != "Building")
        {
            if (this.GetComponent<Animator>().GetBool("EnemyinRange") && this.GetComponent<overlapspere>().enemy_inrange == false) //공격 중 공격할 적이 없다
            {
                this.GetComponent<Animator>().SetBool("EnemyinRange", false);
                atk = true;
                this.GetComponent<ForwardMovement>().forward = EUnitManager.instance.enemy_pos;
            }
            else if (this.GetComponent<Animator>().GetBool("EnemyinRange") == false && this.GetComponent<overlapspere>().enemy_inrange) //공격 중이지 않지만 공격할 적이 있다.
            {
                this.GetComponent<Animator>().SetBool("EnemyinRange", true);
                this.GetComponent<ForwardMovement>().speed = 0;
                //this.GetComponent<Toward>().target = this.GetComponent<overlapspere>().target.transform;


            }
            else if (this.GetComponent<Animator>().GetBool("EnemyinRange") == false && this.GetComponent<overlapspere>().enemy_inrange == false) //공격중도 아니고 공격할 적도 없다.
            {
                this.GetComponent<ForwardMovement>().forward = EUnitManager.instance.enemy_pos;
                //this.GetComponent<ForwardMovement>().speed = speed;
            }
            else // 공격중 공격할 적이 있다. 
            {
                this.GetComponent<ForwardMovement>().forward = this.GetComponent<overlapspere>().target.transform.position;
                if (atk)
                {
                    StartCoroutine(Attack());
                    atk = false;
                }
            }
        }
        else
        {
            if (this.GetComponent<overlapspere>().enemy_inrange)
            {
                if (atk)
                {
                    StartCoroutine(Attack());
                    atk = false;
                }
            }
            else
            {
                atk = true;
            }
        }
    }
    private void Update()
    {
        //EUnitManager.instance.pos.x += this.transform.position.x;
        //EUnitManager.instance.pos.y += this.transform.position.y;
        //EUnitManager.instance.pos.z += this.transform.position.z;


    }
    private void OnDestroy()
    {
        EUnitManager.instance.units.Remove(this);
    }
    IEnumerator Attack()
    {
        bool at = true;
        attackaudioSource.clip = attack_clip;
        attackaudioSource.Play();

        yield return new WaitForSecondsRealtime(1.0f);
        
        if (at)
        {
            //Debug.Log("hit");
            if (this.GetComponent<overlapspere>().target.tag != "Building")
            {
                hurtaudioSource.clip = hurt_clip;
                hurtaudioSource.Play();

                this.GetComponent<overlapspere>().target.GetComponent<Animator>().SetTrigger("IsHit");
            }

            this.GetComponent<overlapspere>().target.GetComponent<Life>().amount -= damage;
            StartCoroutine(Attack());
            at = false;
        }

    }
}
