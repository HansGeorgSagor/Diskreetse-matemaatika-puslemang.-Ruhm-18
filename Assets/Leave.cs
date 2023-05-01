using UnityEngine;
using UnityEngine.SceneManagement;

public class Leave : MonoBehaviour
{
    
    int currentSceneIndex;

   
    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentSceneIndex > 0)
            {
                SceneManager.LoadScene(currentSceneIndex - 1);
            }
        }
    }
}
