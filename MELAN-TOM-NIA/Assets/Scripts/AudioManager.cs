using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    
    [SerializeField] private AudioSource sfxSource;
    
    [SerializeField] private AudioClip enemyDeathSound;
    [SerializeField] private AudioClip enemyAttackSound;
    [SerializeField] private AudioClip playerDeathSound;
    [SerializeField] private AudioClip playerAttackSound;
    
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    
    public void PlayEnemyDeathSound()
    {
        if (enemyDeathSound != null)
        {
            sfxSource.PlayOneShot(enemyDeathSound);
        }
    }
    
    public void PlayEnemyAttackSound()
    {
        if (enemyAttackSound != null)
        {
            sfxSource.PlayOneShot(enemyAttackSound);
        }
    }
    
    public void PlayPlayerDeathSound()
    {
        if (playerDeathSound != null)
        {
            sfxSource.PlayOneShot(playerDeathSound);
        }
    }
    
    public void PlayPlayerAttackSound()
    {
        if (playerAttackSound != null)
        {
            sfxSource.PlayOneShot(playerAttackSound);
        }
    }
}

