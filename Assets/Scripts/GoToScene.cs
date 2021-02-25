using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public string Scene;

    public void OnClick()
    {
        SceneManager.LoadScene(Scene);
    }
}
