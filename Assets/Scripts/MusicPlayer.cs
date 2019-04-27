using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioSource audiosource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        //Invoke("PlaySound", 2f);
        Invoke("LoadLevel", 2f);
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(1);
        //audiosource.Play();
    }
}
