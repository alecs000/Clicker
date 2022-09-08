using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [HideInInspector] public float speed;
    [HideInInspector] public float HP;

    [SerializeField] Complicator complicator;
    [SerializeField] Animator animator;
    [SerializeField] SphereCollider sphereCollider;
    [SerializeField] AudioSource audioSource;

    public float _hp;
    public float _speed;

    float _boost;
    private void Start()
    {
        complicator.Complicate();
        Debug.Log(555);
    }
    void OnEnable()
    {
        speed = _speed;
        HP = _hp;
    }
    public void GetDamage(int value)
    {
        if (HP>value)
        {
            HP -= value;
            animator.SetBool("isGetDamage", true);
            return;
        }
        Die();
    }
    public void EndGetDamageCorut()
    {
        animator.SetBool("isGetDamage", false);
    }
    public void Die()
    {
        animator.SetBool("isDie", true);
        EnemiesBehavior.DieLogicEnemy();
        speed = 0;
        _boost = complicator.boost;
        complicator.boost = 0;
        sphereCollider.enabled = false;
        complicator.boost = 0;
    }
    public void EndDie()
    {
        sphereCollider.enabled = true;
        complicator.boost = _boost;
        animator.SetBool("isDie", false);
        EnemiesBehavior.DisppearEnemy(this.gameObject);
    }
    private void OnMouseDown()
    {
        Debug.Log(HP);
        GetDamage(1);
        audioSource.Play();
    }
}
