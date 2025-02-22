using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    [SerializeField] private AudioSource sfxSource;
    
    [SerializeField] private AudioClip enemyDeathSound;
    
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
}

