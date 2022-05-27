using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject EndGameUI;
    public void GameOver()
    {
        EndGameUI.SetActive(true);
    }
    public void Restart()
    {
        EndGameUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
