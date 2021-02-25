using UnityEngine;

public class Spawner_Monobehaviour : MonoBehaviour
{
    public GameObject Prefab;
    public int MaxCount;
    public int Count { get; private set; }

    private Unity.Mathematics.Random rng;

    private void Start()
    {
        Count = 0;

        var intTime = (uint)System.DateTime.Now.Ticks;
        rng = new Unity.Mathematics.Random(intTime);
    }

    void Update()
    {
        if (Count >= MaxCount)
        {
            Destroy(gameObject);
            return;
        }

        Count++;

        var instance = Instantiate(Prefab);
        var transformSpeed = instance.AddComponent<TransformSpeed_Monobehaviour>();

        transformSpeed.speed = new Vector3(rng.NextFloat(-2, 2), rng.NextFloat(-2, 2), rng.NextFloat(-2, 2));
        transformSpeed.rotationSpeed = Vector3.forward * rng.NextFloat(-2, 2);
    }
}
