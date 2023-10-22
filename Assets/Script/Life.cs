using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    //public static Life instance;
    public float amount;
    public UnityEvent onDeath;

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("enter");
    //    if (other.gameObject.tag == "Sword")
    //    {
    //        Debug.Log("Sword");
    //        amount -= 1;
    //    }
    //    else if (other.gameObject.tag == "Bow")
    //    {
    //        Debug.Log("Bow");
    //        amount -= 2;
    //    }
    //    else if (other.gameObject.tag == "Lance")
    //    {
    //        Debug.Log("Lance");
    //        amount -= 3;
    //    }
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    Debug.Log("Stay");
    //    if (other.gameObject.tag == "Sword")
    //    {
    //        Debug.Log("Sword");
    //        amount -= 1;
    //    }
    //    else if (other.gameObject.tag == "Bow")
    //    {
    //        Debug.Log("Bow");
    //        amount -= 2;
    //    }
    //    else if (other.gameObject.tag == "Lance")
    //    {
    //        Debug.Log("Lance");
    //        amount -= 3;
    //    }
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("enter");
    //    if (collision.gameObject.tag == "Sword")
    //    {
    //        Debug.Log("Sword");
    //        amount -= 1;
    //    }
    //    else if (collision.gameObject.tag == "Bow")
    //    {
    //        Debug.Log("Bow");
    //        amount -= 2;
    //    }
    //    else if (collision.gameObject.tag == "Lance")
    //    {
    //        Debug.Log("Lance");
    //        amount -= 3;
    //    }
    //}

    //private void OnCollisionStay(Collision collision)
    //{
    //    Debug.Log("Stay");
    //    if (collision.gameObject.tag == "Sword")
    //    {
    //        Debug.Log("Sword");
    //        amount -= 1;
    //    }
    //    else if (collision.gameObject.tag == "Bow")
    //    {
    //        Debug.Log("Bow");
    //        amount -= 2;
    //    }
    //    else if (collision.gameObject.tag == "Lance")
    //    {
    //        Debug.Log("Lance");
    //        amount -= 3;
    //    }
    //}
    private void Update()
    {
        //Debug.Log(amount);
        if (amount <= 0)
        {
            onDeath.Invoke();
            Destroy(gameObject);
        }
    }
}
