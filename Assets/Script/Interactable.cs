using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool pickUpObject = false;

    public void Interact(GameObject player) 
    {
        print("Interacting");
    }
}
