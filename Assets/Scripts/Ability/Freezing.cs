using System.Collections;
using UnityEngine;

class Freezing : MonoBehaviour, IAbility
{
    [SerializeField] GameObject spawnManager;
    [SerializeField] GameObject greyImage;
    [SerializeField] AudioSource audioSource;
    EnemiesBehavior enemiesBehavior;
    bool isStoped = false;
    void Start()
    {
        enemiesBehavior = spawnManager.GetComponent<EnemiesBehavior>();
    }
    public void UseAbility()
    {
        if (isStoped)
            return;
        greyImage.SetActive(true);
        isStoped = true;
        EnemiesBehavior.isStopSpawn = true;
        audioSource.Play();
        StartCoroutine(FreezeCorout());
    }
    private IEnumerator FreezeCorout()
    {
        yield return new WaitForSeconds(3);
        greyImage.SetActive(false);
        isStoped = false;
        EnemiesBehavior.isStopSpawn = false;
        enemiesBehavior.StartSpawn();
    }
}

