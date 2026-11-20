using System;
using System.Collections.Generic;
using UnityEngine;

public class Station : Interactable
{
    public GameObject foodPos1;
    public GameObject foodPos2;

    public GameObject food1;
    public GameObject food2;

    [Serializable]
    public struct Recipe
    {
        public string ingredientID;
        public string resultID;
        public float cookTime;
    }

    public List<Recipe> allowedRecipes;

    protected override void ExecuteInteraction(PlayerInteractions playerHand)
    {
        if (playerHand.heldObj)
        {
            for (int i = 0; i < allowedRecipes.Count; i++)
            {
                if (playerHand.heldObj.GetComponent<Ingredient>().itemID == allowedRecipes[i].ingredientID)
                {
                    Debug.Log("Working");
                    if (!food1)
                    {
                        food1 = playerHand.heldObj;
                        playerHand.heldObj = null;

                        food1.GetComponent<Ingredient>().plyrHand = foodPos1;
                        food1.GetComponent<Rigidbody>().detectCollisions = true;
                        food1.GetComponent<Ingredient>().parentStation = this;
                        food1.GetComponent<Ingredient>().stationSlot = 1;
                    }
                    else if (!food2)
                    {
                        food2 = playerHand.heldObj;
                        playerHand.heldObj = null;

                        food2.GetComponent<Ingredient>().plyrHand = foodPos2;
                        food2.GetComponent<Rigidbody>().detectCollisions = true;
                        food2.GetComponent<Ingredient>().parentStation = this;
                        food2.GetComponent<Ingredient>().stationSlot = 2;
                    }
                }
                else
                {
                    Debug.Log("no se puede cocinar esto aqui");
                }
            }
        }
    }

}
