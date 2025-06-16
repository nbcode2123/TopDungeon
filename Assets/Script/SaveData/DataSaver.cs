using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    public static void SaveToJson<T>(T data, string fullPath)
    {
        string directory = Path.GetDirectoryName(fullPath);
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        // Serialize và ghi file
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(fullPath, json);

        Debug.Log($" Đã lưu JSON tại: {fullPath}");
    }
    public static void SaveListToJson(List<Vector2Int> positions, string filePath)
    {
        Vector2IntListWrapper wrapper = new Vector2IntListWrapper(positions);
        string json = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Đã lưu vào: " + filePath);
    }
    public static List<Vector2Int> LoadListFromJson(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Debug.LogWarning("Không tìm thấy file!");
            return new List<Vector2Int>();
        }

        string json = File.ReadAllText(filePath);
        Vector2IntListWrapper wrapper = JsonUtility.FromJson<Vector2IntListWrapper>(json);
        return wrapper.list;
    }


}
[System.Serializable]
public class Vector2IntListWrapper
{
    public List<Vector2Int> list;

    public Vector2IntListWrapper(List<Vector2Int> input)
    {
        list = input;
    }
}

public static class FileHelper
{
    public static void DeleteFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log("Đã xoá file: " + filePath);
        }
        else
        {
            Debug.LogWarning("Không tìm thấy file để xoá: " + filePath);
        }
    }
}

