using UnityEngine;

public class Killing : MonoBehaviour, IAbility
{
    [SerializeField] GameObject spawnManager;
    public void UseAbility()
    {
        foreach (Transform child in spawnManager.transform)
        {
            if (child.gameObject.activeInHierarchy)
            {
                child.GetComponent<Enemy>().Die();
            }
        }
    }
}
