using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using CharacterCreator2D;

namespace CharacterEditor2D
{
    public static class EditorUtils
    {
        public static string GetAssetPath(string completePath)
        {
            string val = "";

            if (completePath.Contains(Application.dataPath)) //..jika path contains project path
            {
                int assetindex = completePath.IndexOf("Assets/");
                val = completePath.Substring(assetindex);
            }

            return val;
        }

        public static T LoadScriptable<T>(string path) where T : UnityEngine.ScriptableObject
        {
            T val = (T)AssetDatabase.LoadAssetAtPath(path, typeof(T));

            if (val == null)
            {
                val = ScriptableObject.CreateInstance<T>();
                AssetDatabase.CreateAsset(val, path);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }

            return val;
        }

        public static List<T> GetPrefabs<T>(string path) where T : UnityEngine.MonoBehaviour
        {
            return GetPrefabs<T>(path, false);
        }

        public static List<T> GetPrefabs<T>(string path, bool readThroughFolders) where T : UnityEngine.MonoBehaviour
        {
            List<T> val = new List<T>();

            string[] files = readThroughFolders ? Directory.GetFiles(path, "*.prefab", SearchOption.AllDirectories) :
                Directory.GetFiles(path, "*.prefab");

            foreach (string f in files)
            {
                T temp = (T)AssetDatabase.LoadAssetAtPath(f, typeof(T));
                if (temp != null)
                    val.Add(temp);
            }

            return val;
        }

        public static List<T> GetScriptables<T>(string path) where T : UnityEngine.ScriptableObject
        {
            return GetScriptables<T>(path, false);
        }

        public static List<T> GetScriptables<T>(string path, bool readThroughFolders) where T : UnityEngine.ScriptableObject
        {
            if (!Directory.Exists(path))
                return new List<T>();
            List<T> val = new List<T>();
            string[] files = readThroughFolders ? Directory.GetFiles(path, "*.asset", SearchOption.AllDirectories) :
                Directory.GetFiles(path, "*.asset");
            foreach (string f in files)
            {
                T temp = (T)AssetDatabase.LoadAssetAtPath(f, typeof(T));
                if (temp != null)
                    val.Add(temp);
            }
            return val;
        }

        public static Texture2D CreateTexture(int width, int height, Color col)
        {
            Color[] pix = new Color[width * height];

            for (int i = 0; i < pix.Length; i++)
                pix[i] = col;

            Texture2D result = new Texture2D(width, height);
            result.SetPixels(pix);
            result.Apply();

            return result;
        }
    }
}