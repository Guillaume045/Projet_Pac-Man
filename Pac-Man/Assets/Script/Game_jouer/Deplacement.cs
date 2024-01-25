using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;   // event
using UnityEngine.UI;       // score

public class Deplace : MonoBehaviour
{
    public float seed = 10;
    public float score = 0;
    public Text Texte_Score;
    public UnityEvent<GameObject> Player;

    private bool canEatGhosts = false;
    private float superPacGommeStartTime = 0f;
    private float superPacGommeDuration = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        // mouvement joueur
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(movX, movY) * seed * Time.deltaTime);

        if (canEatGhosts && Time.time - superPacGommeStartTime >= superPacGommeDuration)
        {
            canEatGhosts = false;
            Debug.Log("temps depasser");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision avec : " + collision.gameObject.name);
        if (collision.collider.CompareTag("Pac_Gomme"))
        {
            //Debug.Log("Score + 10");
            score += 10;

            if (Texte_Score != null)
            {
                Texte_Score.text = "Score : " + score.ToString();
            }
        }
        if (collision.collider.CompareTag("Super_Pac_Gomme"))
        {
            //Debug.Log("Super_Pac_Gomme manger");
            canEatGhosts = true;
            superPacGommeStartTime = Time.time;
        }
        else if (collision.collider.CompareTag("Fantôme") && canEatGhosts)
        {
            //Debug.Log("Fantôme mangé");
            Destroy(collision.gameObject);
        }
        else if (collision.collider.CompareTag("Fantôme"))
        {
            Destroy(gameObject);
        }
    }
}
