using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumListBehaviour : MonoBehaviour, ISerializationCallbackReceiver
{
    public static List<string> TempList;
    public EnumListBehaviourSO enumList = null;

    [ListToPopup(typeof(EnumListBehaviour), "TempList")]
    public string currentElementSelected;

    public void OnBeforeSerialize()
    {
        // Load the data
        if (enumList != null)
            TempList = enumList.enumList;
        else
        {
            TempList = null;
            currentElementSelected = "";
        }
    }

    public void OnAfterDeserialize() { }
}
