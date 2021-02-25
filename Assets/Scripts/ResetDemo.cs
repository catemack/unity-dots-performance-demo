using Unity.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetDemo : MonoBehaviour
{
    public void ResetEntities()
    {
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        var spawnerQuery = entityManager.CreateEntityQuery(ComponentType.ReadOnly<Spawner>());
        var transformSpeedQuery = entityManager.CreateEntityQuery(ComponentType.ReadOnly<TransformSpeed>());

        var spawnerEntities = spawnerQuery.ToEntityArray(Unity.Collections.Allocator.TempJob);
        var transformEntities = transformSpeedQuery.ToEntityArray(Unity.Collections.Allocator.TempJob);

        foreach (var entity in spawnerEntities)
            entityManager.DestroyEntity(entity);

        foreach (var entity in transformEntities)
            entityManager.DestroyEntity(entity);

        spawnerEntities.Dispose();
        transformEntities.Dispose();
    }

    public void ResetMonobehaviours()
    {
        // todo: destroy all dynamically instantiated stuff
        foreach (var root in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            foreach (var spawner in root.GetComponentsInChildren<Spawner_Monobehaviour>())
                Destroy(spawner.gameObject);

            foreach (var transformSpeed in root.GetComponentsInChildren<TransformSpeed_Monobehaviour>())
                Destroy(transformSpeed.gameObject);
        }
    }
}
