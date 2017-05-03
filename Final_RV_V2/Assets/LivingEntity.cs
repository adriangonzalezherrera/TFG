using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivingEntity : MonoBehaviour, IDamageable {

    [SerializeField] private AudioClip danyao;
    public float startingHealth;
    public float health;
    protected bool dead;
    public RawImage damagescreen;
    Color damagedColor = new Color(1f, 0f, 0f, 0.8f);
    float smoothColor = 5f;
    public bool damaged = false;
    private AudioSource m_AudioSource2;
    public event System.Action OnDeath;
    public GameObject explosion;

    protected virtual void Start()
    {
        health = startingHealth;
        m_AudioSource2 = GetComponent<AudioSource>();
    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        TakeDamage(damage);
    }

    public void TakeDamage(float damage)
    {
        if (this == GameObject.FindGameObjectWithTag("MainCamera").transform.GetComponent<LivingEntity>())
        {
            damagescreen.color = damagedColor;
            m_AudioSource2.clip = danyao;
            m_AudioSource2.Play();
        }
        
        health -= damage;
        
        //health -= damage;
        if (health <= 0 && !dead)
        {
            Die();
        }
        damaged = false;
    }

    protected void Die()
    {
        dead = true;
        if (OnDeath != null)
        {
            OnDeath();
        }
        Destroy(Instantiate(explosion, transform.position, GameObject.FindGameObjectWithTag("MainCamera").transform.rotation) as GameObject, 5);
            GameObject.Destroy(gameObject);
        
    }

    
}
