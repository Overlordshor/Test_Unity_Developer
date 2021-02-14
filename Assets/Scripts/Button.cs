using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}