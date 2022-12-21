using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealh : MonoBehaviour
{
    public int Health = 2;
    public int MaxHealh = 8;
    private bool _invulnerable = false;
    public HealthUI HealthUI;
    //public AudioSource TakeDamageSound;
    public AudioSource AddHealhSound;
    //public DamageScreen DamageScreen;
    //public Blink Blink;

    public UnityEvent EventOnTakeDamage;
    public GameObject HenPrefab;
    public UiService UiService;

    private void Start()
    {
        HealthUI.Setup(MaxHealh);
        HealthUI.DisplayHealth(Health);
    }

    public void TakeDamage(int damageValue)
    {
        if (_invulnerable == false)
        {
            Health -= damageValue;
            if (Health <= 0)
            {
                Health = 0;
                Die();
            }
            _invulnerable = true;
            Invoke(nameof(StopInvulnerable), 1);
            //TakeDamageSound.Play();
            HealthUI.DisplayHealth(Health);
            //DamageScreen.StartEffect();
            // Blink.StartBlink();

            
            
                EventOnTakeDamage.Invoke();
            
            
        }

    }

    void StopInvulnerable()
    {
        _invulnerable = false;
    }

    public void AddHealh(int healthValue)
    {
        Health += healthValue;
        if (Health > MaxHealh)
        {
            Health = MaxHealh;

        }
        AddHealhSound.Play();
        HealthUI.DisplayHealth(Health);
    }
    
    void Die()
    {
        
        SceneManager.LoadScene("SampleScene");
        //UiService.Death();


    }
   

}
