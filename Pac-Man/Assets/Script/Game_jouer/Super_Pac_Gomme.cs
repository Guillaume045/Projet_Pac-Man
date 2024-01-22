using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Super_Pac_Gomme : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision détectée");
        if (collision.collider.CompareTag("Player"))
        {
            //Debug.Log("Objet détruit");
            Destroy(gameObject);
        }
    }
}
