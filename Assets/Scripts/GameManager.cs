using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public int[] scoreArray = new int[10];
    public int score;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }
    public void LoseGame()
    {
        for(int i = 0; i<scoreArray.Length; i++)
        {
            if (scoreArray[i]==0)
            {
                scoreArray[i] = score;
                break;
            }
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        EnemiesBehavior.waitTime = 2;
        EnemiesBehavior.numActiveEnemy = 0;
        Complicator.increasedLife = 1;
        score = 0;
    }
}
