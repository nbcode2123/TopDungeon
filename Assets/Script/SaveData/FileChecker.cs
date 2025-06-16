using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileChecker : MonoBehaviour
{
    public static bool CheckFile(string filePath)
    {
        return File.Exists(filePath);

    }
}
