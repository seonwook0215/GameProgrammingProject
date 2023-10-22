using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Unit: MonoBehaviour
{
    //public float speed; //unit speed
    public float distance; //unit attack range
    public float damage; // unit attack damage
    
   // public float hp; //unit HP

    GameObject obj;

    private void Start()
    {
        //this.GetComponent<P1UnitManager>().units.Add(this);
        P1UnitManager.instance.units.Add(this);
      //  this.GetComponent<ForwardMovement>().speed = speed;
        //this.GetComponent<Toward>().speed = speed;
        //this.GetComponent<Life>().amount = hp;
        this.GetComponent<overlapspere>().radius = distance;
    }
    private void FixedUpdate()
    {
        if (this.GetComponent<Animator>().GetBool("EnemyinRange") && this.GetComponent<overlapspere>().enemy_inrange == false) //공격 중 공격할 적이 없다
        {
            this.GetComponent<Animator>().SetBool("EnemyinRange", false);
            this.GetComponent<ForwardMovement>().forward = P1UnitManager.instance.enemy_pos;
        }
        else if (this.GetComponent<Animator>().GetBool("EnemyinRange") == false && this.GetComponent<overlapspere>().enemy_inrange) //공격 중이지 않지만 공격할 적이 있다.
        {
            this.GetComponent<Animator>().SetBool("EnemyinRange", true);
            this.GetComponent<ForwardMovement>().speed = 0;
            //this.GetComponent<Toward>().target = this.GetComponent<overlapspere>().target.transform;
            
            
        }
        else if(this.GetComponent<Animator>().GetBool("EnemyinRange") == false && this.GetComponent<overlapspere>().enemy_inrange == false) //공격중도 아니고 공격할 적도 없다.
        {
            this.GetComponent<ForwardMovement>().forward = P1UnitManager.instance.enemy_pos;
            //this.GetComponent<ForwardMovement>().speed = speed;
        }
        else // 공격중 공격할 적이 있다. 
        {
            this.GetComponent<ForwardMovement>().forward = this.GetComponent<overlapspere>().target.transform.position;
            StartCoroutine(Attack());
        }
    }
    private void Update()
    {
        //P1UnitManager.instance.pos.x += this.transform.position.x;
        //P1UnitManager.instance.pos.y += this.transform.position.y;
        //P1UnitManager.instance.pos.z += this.transform.position.z;
    }
    private void OnDestroy()
    {
        P1UnitManager.instance.units.Remove(this);
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1.0f);
            this.GetComponent<overlapspere>().target.GetComponent<Life>().amount -= damage;
        }
    }
}
