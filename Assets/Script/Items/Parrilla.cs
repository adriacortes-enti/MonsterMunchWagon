using UnityEngine;

public class Parrilla : Interactable
{
    public GameObject foodPos1;
    public GameObject foodPos2;

    GameObject food1;
    GameObject food2;

    protected override void ExecuteInteraction(PlayerInteractions playerHand)
    {
        if (playerHand.heldObj && playerHand.heldObj.GetComponent<Ingredient>().itemID == "meat")
        {
            food1 = playerHand.heldObj;
            playerHand.heldObj = null;

            Debug.Log("Working");
            food1.GetComponent<Ingredient>().plyrHand = foodPos1;
            food1.GetComponent<Rigidbody>().detectCollisions = true;
        }
        else
        {
            Debug.Log("no");
        }
    }
}
