using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Interactable : MonoBehaviour
{
    public string interactionText = "Interact";

    void Reset()
    {
        // Ensure collider is trigger by default for interactions
        var col = GetComponent<Collider2D>();
        if (col != null) col.isTrigger = true;
    }

    public virtual void OnInteract(GameObject interactor)
    {
        Debug.Log($"{name} interacted by {interactor.name}");
    }
}
