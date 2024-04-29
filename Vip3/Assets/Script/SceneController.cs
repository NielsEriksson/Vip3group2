using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] string sceneToLoadName;

    //public void LoadScene(int scene)
    //{
    //    SceneManager.LoadScene(scene);
    //}
    //public void LoadScene(string scene)
    //{       
    //    SceneManager.LoadScene(scene);
    //}

    public void LoadSavedScene()
    {
        SceneManager.LoadScene(sceneToLoadName);
    }
    //public void ReloadScene()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}
    public void Quit()
    {
        Application.Quit();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LoadSavedScene();
    }
}
