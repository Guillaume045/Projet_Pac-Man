using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantôme : MonoBehaviour
{
    public float speed = 5f;

    private Vector2 direction;

    void Start()
    {
        // Initialiser la direction vers le haut au début
        direction = Vector2.up;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        // Déplacer le Fantôme dans la direction actuelle
        transform.Translate(direction * speed * Time.deltaTime);

        // Vérifier s'il y a une collision avec un mur
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0.5f);
        if (hit.collider != null)
        {
            // Changer la direction en fonction de la collision
            AdjustDirection(hit.normal);
        }
    }

    void AdjustDirection(Vector2 collisionNormal)
    {
        // Changer la direction en fonction de la collision
        if (collisionNormal == Vector2.right || collisionNormal == -Vector2.right)
        {
            // Collision avec un mur sur le côté droit ou gauche
            direction = Vector2.up; // Aller vers le haut
        }
        else if (collisionNormal == Vector2.up || collisionNormal == -Vector2.up)
        {
            // Collision avec un mur en haut ou en bas
            direction = Vector2.right; // Aller vers la droite
        }
        else
        {
            // Collision avec un coin, reculer
            direction = -direction;
        }
    }
}