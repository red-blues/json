using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerSingleton : MonoBehaviour
{
    #region Singleton
    private static MusicPlayerSingleton _instance;
    public static MusicPlayerSingleton Instance => _instance; 

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    #region Sound Logic
    [SerializeField] private AudioSource _audioSource;
    public void SetVolume(float value)
    {
        _audioSource.volume = value;
        Saver.SaveVolume(value);
    }
    #endregion
}
