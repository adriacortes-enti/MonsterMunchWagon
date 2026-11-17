using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool pickUpObject = false;
    bool isPickedUp = false;
    PlayerInteractions plyrHand;
    public string tootltip;

    public void Interact(PlayerInteractions playerHand) 
    {
        ExecuteInteraction(playerHand);

        if (pickUpObject && !playerHand.heldObj)
        {
            playerHand.heldObj = gameObject;

            //attatch object to player's hand
            gameObject.transform.parent = playerHand.gameObject.transform;
            gameObject.GetComponent<Rigidbody>().detectCollisions = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            isPickedUp = true;
            plyrHand = playerHand;            
        }
    }

    public void Drop(PlayerInteractions playerHand, float throwStrength)
    {
        playerHand.heldObj = null;
        isPickedUp = false;
        plyrHand = null;
        gameObject.transform.parent = null;
        gameObject.GetComponent<Rigidbody>().detectCollisions = true;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * throwStrength, ForceMode.Impulse);
    }

    void Update()
    {
        if (pickUpObject && isPickedUp)
        {
            gameObject.transform.position = plyrHand.gameObject.transform.position;
            gameObject.transform.rotation = plyrHand.gameObject.transform.rotation;
        }
    }

    protected abstract void ExecuteInteraction(PlayerInteractions playerHand);
}
