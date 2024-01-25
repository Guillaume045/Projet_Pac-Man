using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantôme : MonoBehaviour
{
    public Vector2[] manualPoints;
    public float speed = 5f;

    private int currentPointIndex = 0;

    void Start()
    {
        if (manualPoints.Length > 0)
        {
            MoveToNextPoint();
        }
        else
        {
            Debug.LogError("Aucun point défini pour le Fantôme.");
        }
    }

    void Update()
    {
        if (manualPoints.Length > 0)
        {
            // Vérifier si le fantôme est suffisamment proche du point actuel
            if (Vector2.Distance(transform.position, manualPoints[currentPointIndex]) < 0.1f)
            {
                // Passer au point suivant
                currentPointIndex = (currentPointIndex + 1) % manualPoints.Length;
                MoveToNextPoint();
            }
        }
    }

    void MoveToNextPoint()
    {
        // Déplacer le fantôme vers le point actuel avec une interpolation
        if (manualPoints.Length > 0)
        {
            Vector2 targetPosition = manualPoints[currentPointIndex];
            transform.position = Vector2.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
