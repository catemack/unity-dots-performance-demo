using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnTracker_Monobehaviour : MonoBehaviour
{
    private Text timerText;

    private float elapsed = 0;

    private void Start()
    {
        timerText = GetComponent<Text>();
    }

    void Update()
    {
        var spawnerActive = false;
        foreach (var root in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            if (root.GetComponentsInChildren<Spawner_Monobehaviour>().Any(spawner => spawner.Count < spawner.MaxCount))
            {
                spawnerActive = true;
                break;
            }
        }

        if (!spawnerActive)
            return;
        
        elapsed += Time.deltaTime;

        var elapsedInt = Mathf.FloorToInt(elapsed);
        var elapsedSeconds = elapsedInt % 60;
        var elapsedMinutes = (elapsedInt - elapsedSeconds) / 60;

        var secondsString = (elapsedSeconds < 10) ? $"0{elapsedSeconds}" : elapsedSeconds.ToString();
        var minutesString = (elapsedMinutes < 10) ? $"0{elapsedMinutes}" : elapsedMinutes.ToString();

        timerText.text = $"Spawn Timer: {minutesString}:{secondsString}";
    }
}
