using System;
using UnityEngine;
using TMPro;
using System.Collections;


public class PlayerHp : MonoBehaviour
{
    public int currentHealth = 100;
    public TextMeshProUGUI hp;
    private Animator animator;
  
    public bool isInvulnerable = false;
    public float invulnerabilityDuration = 2f;
    public GameObject deathPanel;
    public GameObject ui;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
  
    private void Start()
    {
        UpdateUI();
    }


    public void TakeDamage(int damageAmount)
    {
        if (isInvulnerable)
        {
            return;
        }


        currentHealth -= damageAmount;
        UpdateUI();
        animator.SetTrigger("GetDmg");
        SFXManager.instance.PlaySFX("HitSFX");
          
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(BecomeInvulnerable());
        }
    }
  
    void UpdateUI()
    {
        if (hp != null)
        {
            hp.text = "Hp: " + currentHealth;
        }
    }
  
    void Die()
    {
        Destroy(gameObject);
        deathPanel.SetActive(true);
        ui.SetActive(false);
        ButtonManager.isPaused = true;
    }
  
    private IEnumerator BecomeInvulnerable()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(invulnerabilityDuration);
      
        isInvulnerable = false;
    }
  
}