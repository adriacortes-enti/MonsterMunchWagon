using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngredientBox : Interactable
{
    public GameObject item;
    public string boxTitle;

    void Awake()
    {
        gameObject.GetComponentInChildren<TextMeshPro>().text = boxTitle;
    }

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
