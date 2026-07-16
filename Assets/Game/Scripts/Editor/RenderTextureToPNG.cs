using System.IO;
using UnityEditor;
using UnityEngine;

public class RenderTextureToPNG : EditorWindow
{
    [MenuItem("Tools/Save Render Texture to PNG")]
    public static void SaveRTToPNG()
    {
        RenderTexture renderTexture = Selection.activeObject as RenderTexture;
        
        if (renderTexture == null)
            return;
        
        string path = EditorUtility.SaveFilePanel("Save PNG", "Assets", "texture.png", "png");
        
        if (path.Length != 0)
        {
            RenderTexture.active = renderTexture;
            Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            texture2D.Apply();
            
            byte[] bytes = texture2D.EncodeToPNG();
            File.WriteAllBytes(path, bytes);
            AssetDatabase.Refresh();
        }
    }
}