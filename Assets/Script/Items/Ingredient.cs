using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ingredient : Interactable
{
    public Station parentStation;
    public int stationSlot;
    public bool isCooking = false;

    public float cookTime;
    public GameObject result; //para cocinas
    public GameObject mergeResult; //para fusionar (pan + salchicha)

    [Serialize]
    public List<string> desiredStationsID;
        
    protected override void Update()
    {
        base.Update(); //run parent update

        if (isCooking && result)
        {
            if (cookTime > 0)
            {
                cookTime -= Time.deltaTime;
            }
            else
            {
                isCooking = false;
                parentStation.CookIngredient(stationSlot);
            }
        }
    }

    public override void Interact(PlayerInteractions playerHand)
    {
        base.Interact(playerHand);

        //usar desiredStationID con una ID de objeto si los ingredientes sedeben fusionar
        //por ejemplo pan + salchicha
        for (int i = 0; i < desiredStationsID.Count; i++)
        {
            if (playerHand.heldObj.GetComponent<Ingredient>().desiredStationsID[i] == itemID)
            {
                GameObject resultTmp;
                resultTmp = playerHand.heldObj.GetComponent<Ingredient>().mergeResult;
                resultTmp = Instantiate(resultTmp);
                Destroy(playerHand.heldObj);

                resultTmp.GetComponent<Interactable>().plyrHand = playerHand.gameObject;
                playerHand.heldObj = resultTmp;

                resultTmp.transform.parent = playerHand.gameObject.transform;
                resultTmp.GetComponent<Rigidbody>().detectCollisions = false;
                resultTmp.GetComponent<Rigidbody>().useGravity = false;

                Destroy(gameObject);
            }
        }
    }

    protected override void ExecuteInteraction(PlayerInteractions playerHand)
    {
        if (parentStation)
        {
            if (stationSlot == 1) parentStation.food1 = null;
            else if (stationSlot == 2) parentStation.food2 = null;

            parentStation = null;
            stationSlot = 0;

            isCooking = false;
        }
    }
}
