using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevelButton : MonoBehaviour
{


    public void OnClick()
    {
        SceneManager.LoadScene(0);
    }
}
