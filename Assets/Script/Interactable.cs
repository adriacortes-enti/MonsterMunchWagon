using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool pickUpObject = false;

    public void Interact(PlayerInteractions playerHand) 
    {
        print("Interacting");

        if (pickUpObject && !playerHand.heldObj)
        {
            playerHand.heldObj = gameObject;

            //attatch object to player's hand
            gameObject.transform.parent = playerHand.gameObject.transform;
            gameObject.GetComponent<Rigidbody>().detectCollisions = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            gameObject.transform.position = playerHand.gameObject.transform.position;
            gameObject.transform.rotation = playerHand.gameObject.transform.rotation;
            
        }
    }

    public void Drop(PlayerInteractions playerHand, float throwStrength)
    {
        playerHand.heldObj = null;
        gameObject.transform.parent = null;
        gameObject.GetComponent<Rigidbody>().detectCollisions = true;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * throwStrength, ForceMode.Impulse);

    }
}
