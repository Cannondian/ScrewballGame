using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int nextScene = 0;
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(nextScene);
    }
}
