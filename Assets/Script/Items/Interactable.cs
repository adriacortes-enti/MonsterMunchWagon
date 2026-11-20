using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool pickUpObject = false;
    public GameObject plyrHand;
    public string itemID;

    public virtual void Interact(PlayerInteractions playerHand) 
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
            plyrHand = playerHand.gameObject;            
        }
    }

    public void Drop(PlayerInteractions playerHand, float throwStrength)
    {
        playerHand.heldObj = null;
        plyrHand = null;
        gameObject.transform.parent = null;
        gameObject.GetComponent<Rigidbody>().detectCollisions = true;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * throwStrength, ForceMode.Impulse);
    }

    protected virtual void Update()
    {
        if (pickUpObject && plyrHand)
        {
            gameObject.transform.position = plyrHand.gameObject.transform.position;
            gameObject.transform.rotation = plyrHand.gameObject.transform.rotation;
        }
    }

    protected abstract void ExecuteInteraction(PlayerInteractions playerHand);
}
