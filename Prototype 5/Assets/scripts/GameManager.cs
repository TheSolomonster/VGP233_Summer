using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private int score = 0;
    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restart;
    public bool gameover = false;
    // Start is called before the first frame update
    public GameObject titleScreen;
    IEnumerator SpawnTarget()
    {
        while(!gameover)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void updateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void gameOver()
    {
        gameover = true;
        gameOverText.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        titleScreen.SetActive(false);
    }
}
