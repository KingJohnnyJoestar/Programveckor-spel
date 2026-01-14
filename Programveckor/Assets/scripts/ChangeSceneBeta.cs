using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneBeta : MonoBehaviour
{
    [SerializeField] int newScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(newScene);
    }
}
