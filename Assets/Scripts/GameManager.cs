using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameStarted = false;
    public GameObject os;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;

    public GameObject tapText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScore;

    int score = 0;
    int bestscore = 0;

    void Start()
    {
        // Charge le meilleur score depuis PlayerPrefs
        bestscore = PlayerPrefs.GetInt("bscore", 0);
        bestScore.text = "Meilleur score : " + bestscore.ToString();
    }

    void Update()
    {
        // Si le joueur appuie sur le bouton gauche de la souris et que le jeu n'a pas encore commencé
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            // Démarre l'apparition des objets
            StartSpawning();
            gameStarted = true;
            tapText.SetActive(false); // Cache le texte "Appuyez pour commencer"
        }
    }

    private void StartSpawning()
    {
        // Appelle la méthode Spawnos
        InvokeRepeating("Spawnos", 0.5f, spawnRate);
    }

    private void Spawnos()
    {
        // Calcule une position aléatoire
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);

        // Envoie l'objet à la position calculée
        Instantiate(os, spawnPos, Quaternion.identity);

        score++;
        scoreText.text = score.ToString();

        // Met à jour le meilleur score si nécessaire
        if (score > bestscore)
        {
            bestscore = score;
            bestScore.text = "Meilleur score : " + bestscore.ToString();

            // Enregistre le meilleur score dans PlayerPrefs
            PlayerPrefs.SetInt("bscore", bestscore);
        }
    }
}
