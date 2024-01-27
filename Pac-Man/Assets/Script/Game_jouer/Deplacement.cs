using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;   // event
using UnityEngine.UI;       // score
using UnityEngine.SceneManagement;

public class Deplace : MonoBehaviour
{
    public float seed = 10;
    public float score = 0;
    public Text Texte_Score;

    public int vie = 3;    // Nombre de vies
    public Text Texte_Vie;
    private Vector3 spawnPoint;

    private bool canEatGhosts = false;
    private float superPacGommeStartTime = 0f;
    private float superPacGommeDuration = 5f;

    void Start()
    {
        spawnPoint = transform.position;

        if (Texte_Vie != null)
        {
            Texte_Vie.text = "Vie : " + vie.ToString();
        }

        if (Texte_Score != null)
        {
            Texte_Score.text = "Score : " + score.ToString();
        }
    }

    void Update()
    {   // mouvement joueur
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(movX, movY) * seed * Time.deltaTime);

        if (canEatGhosts && Time.time - superPacGommeStartTime >= superPacGommeDuration)
        {
            canEatGhosts = false;
            Debug.Log("temps d�pass�");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pac_Gomme"))
        {
            Destroy(other.gameObject);
            score += 10;
            if (Texte_Score != null)
            {
                Texte_Score.text = "Score : " + score.ToString();
            }
        }
        else if (other.CompareTag("Super_Pac_Gomme"))
        {
            Destroy(other.gameObject);
            canEatGhosts = true;
            superPacGommeStartTime = Time.time;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Super_Pac_Gomme"))
        {
            canEatGhosts = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Fant�me") && canEatGhosts)
        {
            Destroy(collision.gameObject);
        }
        else if (collision.collider.CompareTag("Fant�me"))
        {
            LoseLife();
        }
    }

    void LoseLife()
    {
        vie--;
        if (Texte_Vie != null)
        {
            Texte_Vie.text = "Vie : " + vie.ToString();
        }
        if (vie <= 0)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            transform.position = spawnPoint;
        }
    }
}
