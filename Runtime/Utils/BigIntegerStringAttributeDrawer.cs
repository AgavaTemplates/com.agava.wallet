using System;
using System.Numerics;
using UnityEngine;
using UnityEditor;

namespace Agava.Wallet.Utils
{
    public class BigIntegerStringAttribute : PropertyAttribute { }
    
#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(BigIntegerStringAttribute))]
    public class BigIntegerStringAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var startColor = GUI.color;

            try
            {
                if (property.type != "string")
                    throw new Exception();

                var result = BigInteger.Parse(property.stringValue);
                
                if (result < 0)
                    throw new ArgumentOutOfRangeException(nameof(result) + " less than 0");
            }
            catch (Exception)
            {
                GUI.color = Color.red;
            }

            EditorGUI.PropertyField(position, property, label);
            GUI.color = startColor;
        }
    }
#endif
}