using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Body", menuName = "Character Body")]
public class CharacterBody_SO : ScriptableObject
{
    //Details for the full character body
    public BodyPart[] characterBodyParts;
}

[System.Serializable]
public class BodyPart
{
    public string bodypartName;
    public BodyParts_SO bodyPart;
}
