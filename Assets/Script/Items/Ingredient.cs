using UnityEngine;

public class Ingredient : Interactable
{
    public Station parentStation;
    public int stationSlot;
    public bool isCooking = false;

    public float cookTime;
    public GameObject result;
    public string desiredStationID;

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
