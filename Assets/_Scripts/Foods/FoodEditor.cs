using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Types;

[CustomEditor(typeof(FoodHolder))]
public class FoodEditor : Editor
{
    #region SerializedProperties
    SerializedProperty food;
    SerializedProperty foodName;
    SerializedProperty sprite;
    SerializedProperty type;
    SerializedProperty drinks;
    SerializedProperty sides;
    SerializedProperty baseIngredient;
    SerializedProperty semiProcessed;
    SerializedProperty dishType;
    #endregion

    private void OnEnable()
    {
        food = serializedObject.FindProperty("food");
        foodName = serializedObject.FindProperty("foodName");
        sprite = serializedObject.FindProperty("sprite");
        type = serializedObject.FindProperty("type");
        drinks = serializedObject.FindProperty("drinks");
        sides = serializedObject.FindProperty("sides");
        baseIngredient = serializedObject.FindProperty("baseIngredient");
        semiProcessed = serializedObject.FindProperty("semiProcessed");
        dishType = serializedObject.FindProperty("dishType");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(food);
        EditorGUILayout.PropertyField(foodName);
        EditorGUILayout.PropertyField(sprite);
        EditorGUILayout.PropertyField(drinks);
        EditorGUILayout.PropertyField(type);

        FoodType currType = (FoodType)type.enumValueIndex;

        switch (currType)
        {
            case FoodType.Ingredient:
                {
                    EditorGUILayout.PropertyField(baseIngredient); break;
                }
            case FoodType.SemiProcessed:
                {
                    EditorGUILayout.PropertyField(semiProcessed); break;
                }
            case FoodType.Dish:
                {
                    EditorGUILayout.PropertyField(dishType);
                    EditorGUILayout.PropertyField(sides);
                    break;
                }
            case FoodType.SideDish:
                {
                    EditorGUILayout.PropertyField(sides);
                    break;
                }
            default: { break; }
        }

        serializedObject.ApplyModifiedProperties();
    }
}
