using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public void Save()
    {
        RoomData roomData = new RoomData();
        foreach(GameObject obj in MainEditor.Instance.ListObjects)
        {
            PieceData pieceData = new PieceData();
            pieceData.r = obj.GetComponentInChildren<Renderer>().material.color.r;
            pieceData.g = obj.GetComponentInChildren<Renderer>().material.color.g;
            pieceData.b = obj.GetComponentInChildren<Renderer>().material.color.b;
            pieceData.name = obj.name;
            pieceData.xPos = obj.transform.position.x;
            pieceData.yPos = obj.transform.position.y;
            pieceData.zPos = obj.transform.position.z;
            pieceData.rotation = obj.transform.rotation.eulerAngles.y;
            pieceData.material = obj.GetComponentInChildren<Renderer>().material.name;
            roomData.ListPieces.Add(pieceData);
        }
        string path = Path.Combine(Application.persistentDataPath, "toto.txt");
        WriteToBinaryFile<RoomData>(path, roomData);

        Debug.Log(path);
    }
    public void Load()
    {
        string path = Path.Combine(Application.persistentDataPath, "toto.txt");
        RoomData roomData=ReadFromBinaryFile<RoomData>(path);

        foreach(GameObject objToSearch in MainEditor.Instance.ListAllObjects)
        {
            if(objToSearch.name==)
        }

        foreach (PieceData pieceData in roomData.ListPieces)
        {
            Instantiate(pieceData.name, new Vector3(pieceData.xPos, pieceData.yPos, pieceData.zPos), Quaternion.Euler(0f, pieceData.rotation, 0f));
            
        }
        
    }
    /// <summary>
    /// Writes the given object instance to a binary file.
    /// <para>Object type (and all child types) must be decorated with the [Serializable] attribute.</para>
    /// <para>To prevent a variable from being serialized, decorate it with the [NonSerialized] attribute; cannot be applied to properties.</para>
    /// </summary>
    /// <typeparam name="T">The type of object being written to the binary file.</typeparam>
    /// <param name="filePath">The file path to write the object instance to.</param>
    /// <param name="objectToWrite">The object instance to write to the binary file.</param>
    /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
    public static void WriteToBinaryFile<T>(string filePath, T objectToWrite)
    {
        using (Stream stream = File.Open(filePath, FileMode.Create))
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            binaryFormatter.Serialize(stream, objectToWrite);
        }
    }

    /// <summary>
    /// Reads an object instance from a binary file.
    /// </summary>
    /// <typeparam name="T">The type of object to read from the binary file.</typeparam>
    /// <param name="filePath">The file path to read the object instance from.</param>
    /// <returns>Returns a new instance of the object read from the binary file.</returns>
    public static T ReadFromBinaryFile<T>(string filePath)
    {
        using (Stream stream = File.Open(filePath, FileMode.Open))
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            return (T)binaryFormatter.Deserialize(stream);
        }
    }
}
