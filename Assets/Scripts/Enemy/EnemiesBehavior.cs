using System.Collections;
using UnityEngine;

public class EnemiesBehavior : MonoBehaviour
{
    [HideInInspector] public PoolMono<Enemy> poolSnail;
    [SerializeField] int poolCountSnail = 5;
    [SerializeField] Enemy prefabSnail;
    [HideInInspector] public PoolMono<Enemy> poolTutle;
    [SerializeField] int poolCountTutle = 5;
    [SerializeField] Enemy prefabTutle;

    static public float waitTime = 2;
    static public int numActiveEnemy =0;
    static public bool isStopSpawn;

    Vector3 minPos;
    Vector3 maxPos;

    private void Awake()
    {
        poolSnail = new PoolMono<Enemy>(prefabSnail, poolCountSnail, this.transform);
        poolTutle = new PoolMono<Enemy>(prefabTutle, poolCountTutle, this.transform);
        minPos = Border.minPos;
        maxPos = Border.maxPos;
    }
    public void StartSpawn()
    {
        StartCoroutine(WaitAndSpawn());
    }
    public IEnumerator WaitAndSpawn()
    {
        while (true)
        {
            if (isStopSpawn)
                break;
            if (Random.Range(0, 2) == 0)
            {
                AppearEnemy(poolSnail);
            }
            else
            {
                AppearEnemy(poolTutle);
            }
            yield return new WaitForSeconds(Random.Range(waitTime, waitTime+1));
        }
    }
    void AppearEnemy(PoolMono<Enemy> pool)
    {
        numActiveEnemy++;
        if (numActiveEnemy>=10)
            GameManager.instance.LoseGame();
        Enemy enemy = pool.GetFreeElement();
        enemy.transform.position = new Vector3(Random.Range(minPos.x, maxPos.x), 0, Random.Range(minPos.z, maxPos.z));
        enemy.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }
    public static void DieLogicEnemy()
    {
        GameManager.instance.score++;
        numActiveEnemy--;
    }
    public static void DisppearEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
    }
    private void Update()
    {
        Debug.Log(waitTime);
    }
}
