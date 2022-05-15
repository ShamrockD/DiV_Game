using UnityEngine;

public class DestroyObjectComponent : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectToDestroy;

    public void DestroyThisObject()
    {
        Object.Destroy(_gameObjectToDestroy);
    }
}
