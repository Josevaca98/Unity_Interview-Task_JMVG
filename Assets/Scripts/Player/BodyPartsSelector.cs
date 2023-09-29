using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
public class BodyPartsSelector : MonoBehaviour
{

    //Handles Body Part Selection Updates

    //Full Character Body
    [SerializeField] private CharacterBody_SO characterBody;
    //Body Part Selections
    [SerializeField] private BodyPartSelection[] bodyPartsSelections;


    // Start is called before the first frame update
    void Start()
    {
        //Get all current body parts
        for (int i = 0; i < bodyPartsSelections.Length; i++)
        {
            GetCurrentBodyParts(i);
        }
    }

    public void NextBodyPart(int partIndex)
    {
        if(ValidateIndexValue(partIndex))
        {
            if(bodyPartsSelections[partIndex].bodyPartCurrentIndex < bodyPartsSelections[partIndex].bodyPartsOptions.Length - 1)
            {
                bodyPartsSelections[partIndex].bodyPartCurrentIndex++;
            }
            else
            {
                bodyPartsSelections[partIndex].bodyPartCurrentIndex = 0;
            }

            UpdateCurrentPart(partIndex);
        }
    }

    public void PreviousBodyPart(int partIndex)
    {
        if(ValidateIndexValue(partIndex))
        {
            if(bodyPartsSelections[partIndex].bodyPartCurrentIndex > 0)
            {
                bodyPartsSelections[partIndex].bodyPartCurrentIndex--;
            }
            else
            {
                bodyPartsSelections[partIndex].bodyPartCurrentIndex = bodyPartsSelections[partIndex].bodyPartsOptions.Length - 1;
            }

            UpdateCurrentPart(partIndex);
        }
    }

    private void GetCurrentBodyParts(int partIndex)
    {
        // Get Current Body Part Name
        bodyPartsSelections[partIndex].bodyPartNameTextComponent.text = characterBody.characterBodyParts[partIndex].bodyPart.bodyPartName;
        // Get Current Body Part Animation ID
        bodyPartsSelections[partIndex].bodyPartCurrentIndex = characterBody.characterBodyParts[partIndex].bodyPart.bodyPartAnimationID;
    }


    private void UpdateCurrentPart(int partIndex)
    {
        //Update Selection Name Text
        bodyPartsSelections[partIndex].bodyPartNameTextComponent.text = bodyPartsSelections[partIndex].bodyPartsOptions[bodyPartsSelections[partIndex].bodyPartCurrentIndex].bodyPartName;
        //Update Character Body Part
        characterBody.characterBodyParts[partIndex].bodyPart = bodyPartsSelections[partIndex].bodyPartsOptions[bodyPartsSelections[partIndex].bodyPartCurrentIndex];
    }

    private bool ValidateIndexValue(int partIndex)
    {
        if (partIndex > bodyPartsSelections.Length || partIndex < 0)
        {
            Debug.Log("Index value does not match any body parts!");
            return false;
        }
        else
        {
            return true;
        }
    }
}
    [System.Serializable]
    public class BodyPartSelection
    {
        public string bodyPartName;
        public BodyParts_SO[] bodyPartsOptions;
        public Text bodyPartNameTextComponent;
        [HideInInspector] public int bodyPartCurrentIndex;
    }