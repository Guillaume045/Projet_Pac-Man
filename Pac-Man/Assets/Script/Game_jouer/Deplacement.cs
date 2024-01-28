using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Deplace : MonoBehaviour
{
    public float seed = 10;

    public float score = 0;
    public Text Texte_Score;
    public float PacManger = 0;

    public Text Texte_Vie;
    public int vie = 3;

    private Vector3 spawnPoint;
    private bool canEatGhosts = false;
    private float superPacGommeStartTime = 0f;
    private float superPacGommeDuration = 5f;

    public UnityEvent<GameObject> Player;

    void Start()
    {
        if (!PlayerPrefs.HasKey("GameLaunched"))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("GameLaunched", 1);
        }
        LoadStats();
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
            Debug.Log("temps depasser");
        }

        if (PacManger == 73)
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
            Debug.Log(PacManger);
            Texte_Score.text = "Score : " + score.ToString();
        }
        else if (other.CompareTag("Super_Pac_Gomme"))
        {
            Destroy(other.gameObject);
            canEatGhosts = true;
            superPacGommeStartTime = Time.time;
        }
        else if (other.CompareTag("Evenement"))
        {
            Destroy(other.gameObject);
            score += 250;
            Texte_Score.text = "Score : " + score.ToString();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Super_Pac_Gomme"))
        {
            canEatGhosts = false;
        }
        else if (other.CompareTag("Fantome") && canEatGhosts)
        {
            //Destroy(collision.gameObject);
        }
        else if (other.CompareTag("Fantome"))
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
            PlayerPrefs.SetInt("Vie", vie);
            PlayerPrefs.SetFloat("Score", score);
            SceneManager.LoadScene(0);
        }
        else
        {
            transform.position = spawnPoint;
        }
    }

    void ResetScene()
    {
        PlayerPrefs.SetInt("Vie", vie);
        PlayerPrefs.SetFloat("Score", score);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }
    void LoadStats()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetFloat("Score");  
        }
        if (PlayerPrefs.HasKey("Vie"))
        {
            vie = PlayerPrefs.GetInt("Vie");  
        }
    }
    void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    void OnApplicationPause(bool isPaused)
    {
        if (isPaused)
        {
            ClearPlayerPrefs();
        }
    }

    void OnApplicationQuit()
    {
        ClearPlayerPrefs();
    }
}
    
