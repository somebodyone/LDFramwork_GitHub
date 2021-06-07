using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace DLBASE
{
    public class AddTagAndLayer : AssetPostprocessor
    {
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            foreach (string s in importedAssets)
            {
                if (s.Equals("Assets/DLFramework/Editor/AddTagAndLayer.cs"))
                {
                    //增加一个你的的layer，比如：wall
                    AddLayer("Game");
                    return;
                }
            }
        }

        public static void AddTag(string tag)
        {
            if (!isHasTag(tag))
            {
                SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
                SerializedProperty it = tagManager.GetIterator();
                while (it.NextVisible(true))
                {
                    if (it.name == "tags")
                    {
                        for (int i = 0; i < it.arraySize; i++)
                        {
                            SerializedProperty dataPoint = it.GetArrayElementAtIndex(i);
                            if (string.IsNullOrEmpty(dataPoint.stringValue))
                            {
                                dataPoint.stringValue = tag;
                                tagManager.ApplyModifiedProperties();
                                return;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 添加layer
        /// </summary>
        /// <param name="layer"></param>
        static int AddLayer(string layer)
        {
            if (IsHasLayer(layer) == -1)
            {
                SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
                SerializedProperty it = tagManager.GetIterator();
                while (it.NextVisible(true))
                {
                    if (it.name == "layers")
                    {
                        for (int i = 0; i < it.arraySize; i++)
                        {
                            if (i == 3 || i == 6 || i == 7) continue;
                            SerializedProperty dataPoint = it.GetArrayElementAtIndex(i);
                            if (string.IsNullOrEmpty(dataPoint.stringValue))
                            {
                                dataPoint.stringValue = layer;
                                tagManager.ApplyModifiedProperties();
                                return i;
                            }
                        }
                    }
                }
            }
            return -1;
        }

        static bool isHasTag(string tag)
        {
            for (int i = 0; i < UnityEditorInternal.InternalEditorUtility.tags.Length; i++)
            {
                if (UnityEditorInternal.InternalEditorUtility.tags[i].Contains(tag))
                    return true;
            }
            return false;
        }

        static int IsHasLayer(string layer)
        {
            SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/Tagmanager.asset"));
            SerializedProperty it = tagManager.GetIterator();
            while (it.NextVisible(true))
            {
                if (it.name == "layers")
                {
                    for (int i = 0; i < it.arraySize; i++)
                    {
                        SerializedProperty sp = it.GetArrayElementAtIndex(i);
                        if (!string.IsNullOrEmpty(sp.stringValue))
                        {
                            if (sp.stringValue.Equals(layer))
                            {
                                sp.stringValue = string.Empty;
                                tagManager.ApplyModifiedProperties();
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < UnityEditorInternal.InternalEditorUtility.layers.Length; i++)
            {
                if (UnityEditorInternal.InternalEditorUtility.layers[i].Contains(layer))
                    return i;
            }
            return -1;
        }
    }
}
