using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectCounter_Monobehaviour : MonoBehaviour
{
    private Text counterText;

    public void Start()
    {
        counterText = GetComponent<Text>();
    }

    public void Update()
    {
        var spawnCount = 0;

        foreach (var root in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            spawnCount += root.GetComponentsInChildren<TransformSpeed_Monobehaviour>().Length;
        }

        counterText.text = $"Objects: {spawnCount}";
    }
}
