using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Attribute to contain the data.
/// </summary>
public class ListToPopupAttribute : PropertyAttribute
{
    public Type myType;
    public string propertyName;

    public ListToPopupAttribute(Type _myType, string _propertyName)
    {
        myType = _myType;
        propertyName = _propertyName;
    }
}

#if UNITY_EDITOR
/// <summary>
/// Drawer to draw the list of the strings in the inspector.
/// </summary>
[CustomPropertyDrawer(typeof(ListToPopupAttribute))]
public class ListToPopupDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ListToPopupAttribute popupAttribute = attribute as ListToPopupAttribute;
        List<string> propertiesList = null;

        // Try to get the data from the list
        var fieldInfo = popupAttribute.myType.GetField(popupAttribute.propertyName);

        if (fieldInfo != null)
            propertiesList = fieldInfo.GetValue(popupAttribute.myType) as List<string>;

        // Draw a dropdown box in the inspector and fill it with the data in the list
        if (propertiesList != null && propertiesList.Count > 0)
        {
            int selectedIndex = Mathf.Max(propertiesList.IndexOf(property.stringValue), 0);
            selectedIndex = EditorGUI.Popup(position, property.name, selectedIndex, propertiesList.ToArray());
            property.stringValue = propertiesList[selectedIndex];
        }
        else
        {
            EditorGUI.LabelField(position, "No data avaible");
        }
    }
}
#endif
