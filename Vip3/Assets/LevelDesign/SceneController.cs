using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] string sceneToLoadName;
    public static string lastScene;
    public CurrentlyAvailableShopItemsSO itemsSO;

    private void Start(){
        if(lastScene == null)return;
        else if (sceneToLoadName == lastScene){
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z); //move player close to where it came from
        if(CameraMovement.instance != null)
            CameraMovement.instance.RecenterCamera();
        Death death = FindObjectOfType<Death>();
        death.respawnPoint = transform; //setting respawn point depending on what the previous scene was
        }    
    }
    public void LoadSavedScene()
    {
        lastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneToLoadName);
    }
    public void Quit()
    {
        Application.Quit();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LoadSavedScene(); //when collided load next scene
    }

    public void LoadNewGame()
    {
        PlayerPrefs.DeleteAll();
        itemsSO.items.Clear();
        SceneManager.LoadScene(sceneToLoadName);
    }
}
