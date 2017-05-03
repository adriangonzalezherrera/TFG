using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(GunController))]
public class Player : LivingEntity
{
    public float stamina = 0;
    public float maxstamina = 100;
    float overcharge;
    public bool overo;
    private AudioSource m_AudioSource;
    [SerializeField] private AudioClip sobrecarga;


    GunController gunController;
    protected override void Start()
    {
        base.Start();
        gunController = GetComponent<GunController>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > overcharge)
        {
            overo = false;
        }
        else
        {

            overo = true;
        }

        if (Input.GetKey(KeyCode.LeftShift) && overo == false)
        {
            stamina += Time.deltaTime * 10;
        }
        if (Input.GetMouseButton(0) && stamina < 100 && overo == false)
        {
            gunController.Shoot();
            stamina += Time.deltaTime*9;
        }
        else if (stamina >= 100 && overo == false)
        {
            overcharge = Time.time + 3;
            stamina -= Time.deltaTime*10;
            m_AudioSource.clip = sobrecarga;
            m_AudioSource.Play();

        }
        else if (stamina > 0 && overo == false && !Input.GetKey(KeyCode.LeftShift))
        {
            stamina -= Time.deltaTime*11;
        }

       
          this.GetComponent<LivingEntity>().damagescreen.color = Color.Lerp(this.GetComponent<LivingEntity>().damagescreen.color, Color.clear, 0.8f * Time.deltaTime);
        
    }

    
        
}
