using System.Linq;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTimer : MonoBehaviour
{
    private Text timerText;
    private float timer;

    private void Start()
    {
        timerText = GetComponent<Text>();
    }

    void Update()
    {
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        var spawnerEntityQuery = entityManager.CreateEntityQuery(ComponentType.ReadOnly<Spawner>());
        var spawnerComponentDatas = spawnerEntityQuery.ToComponentDataArray<Spawner>(Allocator.Temp);

        if (spawnerComponentDatas.Any(spawner => spawner.Count < spawner.MaxCount))
        {
            timer += Time.deltaTime;

            var totalSeconds = Mathf.FloorToInt(timer);
            var seconds = totalSeconds % 60;
            var minutes = (totalSeconds - seconds) / 60;

            var minutesText = minutes < 10 ? $"0{minutes}" : minutes.ToString();
            var secondsText = seconds < 10 ? $"0{seconds}" : seconds.ToString();

            timerText.text = $"Spawn Timer: {minutesText}:{secondsText}";
        }

        spawnerComponentDatas.Dispose();
    }
}
