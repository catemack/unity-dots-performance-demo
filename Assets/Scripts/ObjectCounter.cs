using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCounter : MonoBehaviour
{
    private Text counterText;

    public void Start()
    {
        counterText = GetComponent<Text>();
    }

    public void Update()
    {
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        var entityQuery = entityManager.CreateEntityQuery(ComponentType.ReadOnly<TransformSpeed>());

        counterText.text = $"Objects: {entityQuery.CalculateEntityCount()}";
    }
}
