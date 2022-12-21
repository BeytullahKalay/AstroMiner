using UnityEngine;

public interface  ICollectible
{
    public bool GetIsConnected();

    public void CallConnectedActions(Transform playerTransform,CollectActions collectActions);

    public void CallReleasedActions();

    public Transform GetCollectibleTransform();
}
