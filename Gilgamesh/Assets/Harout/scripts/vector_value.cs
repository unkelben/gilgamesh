using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu]
public class vector_value : ScriptableObject, ISerializationCallbackReceiver
{
   
    [Header ("Value running in game")]
    public Vector2 initialValue;
    [Header("Value by default when starting")]
    public Vector2 defaultValue;


    public void OnAfterDeserialize()
    {
        
    }

    public void OnBeforeSerialize()
    {

    }




    
}
