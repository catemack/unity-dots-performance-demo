using Unity.Entities;
using UnityEngine;

public class StartDemo : MonoBehaviour
{
    public GameObject SpawnerPrefab;

    public void CreateSpawnerAsEntity()
    {
        var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
        var prefabEntity = GameObjectConversionUtility.ConvertGameObjectHierarchy(SpawnerPrefab, settings);
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        entityManager.Instantiate(prefabEntity);
    }

    public void CreateSpawnerAsMonobehaviour()
    {
        Instantiate(SpawnerPrefab);
    }
}
