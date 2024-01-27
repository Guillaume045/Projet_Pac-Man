using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Deplace : MonoBehaviour
{
    public float seed = 10;
    public float score = 0;
    public float PacManger = 0;
    public Text Texte_Score;
    public Text Texte_Vie;

    public int vie = 3;
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
    {
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(movX, movY) * seed * Time.deltaTime);

        if (canEatGhosts && Time.time - superPacGommeStartTime >= superPacGommeDuration)
        {
            canEatGhosts = false;
            Debug.Log("temps dépassé");
        }

        if (PacManger >= 73)
        {
            ResetScene();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pac_Gomme"))
        {
            Destroy(other.gameObject);
            score += 10;
            PacManger += 1;
            Texte_Score.text = "Score : " + score.ToString();
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
        else if (other.CompareTag("Fantôme") && canEatGhosts)
        {
            //Destroy(collision.gameObject);
        }
        else if (other.CompareTag("Fantôme"))
        {
            ViePerdu();
        }
    }

    void ViePerdu()
    {
        vie --;
        Texte_Vie.text = "Vie : " + vie.ToString();

        if (vie <= 0)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            transform.position = spawnPoint;
        }
    }

    void ResetScene()
    {
        PlayerPrefs.SetInt("vie", vie);
        PlayerPrefs.SetFloat("score", score);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }
}
