using UnityEngine;
using System.Collections;
public class Complicator : MonoBehaviour
{
    public float boost = 0.1f;
    [SerializeField] float spawnSpeedIncreased = 0.1f;
    [SerializeField] Enemy enemy;
    static public float increasedLife = 1;
    public void Complicate() {
        enemy._hp += increasedLife;
        EnemiesBehavior.waitTime -= spawnSpeedIncreased;
        StartCoroutine(ComplicateCorout());
    }
    private IEnumerator ComplicateCorout()
    {
        while (true)
        {
            increasedLife += 0.1f;
            yield return new WaitForSeconds(1);
            enemy.speed += boost;
        }
    }
}
