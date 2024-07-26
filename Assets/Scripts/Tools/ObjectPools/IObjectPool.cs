using UnityEngine;


/// <summary>
/// Generic object pool for GameObjects.
/// </summary>
/// <typeparam name="T">Type of pooled object extended MonoBehaviour</typeparam>
public interface IObjectPool<T> where T : MonoBehaviour
{
    /// <summary>
    /// Try retrieved item from the object pool, creating a new one if the pool is empty and pool isExpandable.
    /// </summary>
    /// <returns>Success retrieved item from the pool.</returns>
    public bool TryPop(out T getingObject, Vector3 position);

    /// <summary>
    /// Adds an item to the object pool.
    /// </summary>
    /// <param name="item">The GameObject to be added to the pool.</param>
    public void Push(T poolingObject);

    public bool ÑheckingForActive();
}
