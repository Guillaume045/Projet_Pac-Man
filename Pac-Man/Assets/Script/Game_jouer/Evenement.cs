using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evenement : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision d�tect�e");
        if (collision.collider.CompareTag("Player"))
        {
            //Debug.Log("Objet d�truit");
            Destroy(gameObject);
        }
    }

}
