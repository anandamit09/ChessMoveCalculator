using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene("TestCase1");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene("TestCase2");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            SceneManager.LoadScene("Enemy");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}

