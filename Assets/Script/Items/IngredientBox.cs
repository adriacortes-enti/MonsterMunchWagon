using UnityEngine;

public class IngredientBox : Interactable
{
    public GameObject item;

    protected override void ExecuteInteraction(PlayerInteractions playerHand)
    {
        Debug.Log("attempted to give");

        if (!playerHand.heldObj)
        {
            GameObject createdItem = Instantiate(item);
            createdItem.GetComponent<Interactable>().Interact(playerHand);
        }
    }
}
