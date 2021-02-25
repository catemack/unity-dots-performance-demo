using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FramerateTracker : MonoBehaviour
{
    public Text text;

    private List<float> frameTimeHistory = new List<float>();

    void Update()
    {
        while (frameTimeHistory.Count >= 500)
            frameTimeHistory.RemoveAt(0);

        frameTimeHistory.Add(Time.deltaTime);

        var averageFrameTime = frameTimeHistory.Sum() / frameTimeHistory.Count;
        var fps = 1 / averageFrameTime;

        text.text = $"FPS: {Mathf.FloorToInt(fps)}";
    }
}
