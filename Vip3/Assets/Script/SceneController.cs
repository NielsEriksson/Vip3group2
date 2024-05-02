using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] string sceneToLoadName;
    public static string lastScene;

    private void Start(){
        if(lastScene == null)return;
        else if (sceneToLoadName == lastScene){
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        }    
    }
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
        lastScene = SceneManager.GetActiveScene().name;
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
