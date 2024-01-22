using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantôme : MonoBehaviour
{
    public Vector3 nouvellePosition = new Vector3(0, 0, 0);

    private Vector3 positionDepart;

    void Start()
    {
        positionDepart = transform.position; 
    }

    void Update()
    {

    }

    public void DetruireFantome()
    {
        Debug.Log("Bonjour");
        transform.position = nouvellePosition;
        gameObject.SetActive(true);
    }
}
