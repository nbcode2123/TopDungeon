using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class DataDelete
{

    public static void DeleteAllFilePath()
    {
        string filePathConcept = Path.Combine(Application.persistentDataPath, "ConceptId.json");
        string filePath = Path.Combine(Application.persistentDataPath, "DungeonController.json");
        string filePathDirection = Path.Combine(Application.persistentDataPath, "Direction.json");
        string filePathCharacter = Path.Combine(Application.persistentDataPath, "Character.json");

        FileHelper.DeleteFile(filePathConcept);
        FileHelper.DeleteFile(filePath);
        FileHelper.DeleteFile(filePathDirection);
        FileHelper.DeleteFile(filePathCharacter);
    }
}
