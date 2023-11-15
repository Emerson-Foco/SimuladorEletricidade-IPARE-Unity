using UnityEngine;
using UnityEngine.SceneManagement;

public class Iniciar : MonoBehaviour
{ 
    public void Exit()
    {
        Application.Quit();
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
