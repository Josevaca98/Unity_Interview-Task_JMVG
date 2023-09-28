using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Body Part", menuName = "Body Part")]
public class BodyParts_SO : ScriptableObject 
{
    //BodyParts Details
    public string bodyPartName;
    public int bodyPartAnimationID;

    //List Containing All BodyParts Animations
    public List<AnimationClip> allBodyPartAnimations = new List<AnimationClip>();   
} 