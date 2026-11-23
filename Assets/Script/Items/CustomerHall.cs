using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CustomerHall : Interactable
{
    public TextMeshPro txtBox1;
    public TextMeshPro txtBox2;
    public TextMeshPro txtBox3;

    [Serialize]
    public List<string> ordersID;
    public List<bool> ordersStatus;

    private void Start()
    {
        UpdateCustomer();
    }

    protected override void Update()
    {
        base.Update(); //run parent update

        
    }

    protected override void ExecuteInteraction(PlayerInteractions playerHand)
    {
        for (int i = 0; i < ordersID.Count; i++)
        {
            if (playerHand.heldObj && playerHand.heldObj.GetComponent<Ingredient>().itemID == ordersID[i])
            {
                

                //TODO: give money

                ordersStatus[i] = true;
                UpdateCustomer();
                Destroy(playerHand.heldObj);
                return;
            }
        }
    }

    void UpdateCustomer()
    {
        bool isDone = false;

        for (int i = 0; i < ordersStatus.Count; i++)
        {
            if (ordersStatus[i]) isDone = true;
            else
            {
                isDone = false;
                break;
            }
        }

        //reset customer once completed
        if (isDone)
        {
            ordersID = new List<string>();
            ordersStatus = new List<bool>();

            //TEST
            ordersID.Add("cooked_meat");
            ordersID.Add("hot_dog");
            ordersID.Add("bun");

            for (int i = 0; i < ordersID.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        txtBox1.text = ordersID[i];
                        break;
                    case 1:
                        txtBox2.text = ordersID[i];
                        break;
                    case 2:
                        txtBox3.text = ordersID[i];
                        break;
                }
            }

            for (int i = 0; i < ordersID.Count; i++)
            {
                ordersStatus.Add(false);
            }
        }
    }
}
