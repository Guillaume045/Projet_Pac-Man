using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passage : MonoBehaviour
{
    public Transform connection;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider other)
    {
        Vector3 possition = other.transform.position;
        possition.x = this.connection.position.x;
        possition.y = this.connection.position.y;
        other.transform.position = possition;
    }
}
