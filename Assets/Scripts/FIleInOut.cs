using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[SerializeField]
public class PlayerData
{
    public string Name;
    public int Stage;
    public int Score;
}
public class FIleInOut : MonoBehaviour
{
    public static FIleInOut instance = null;
    /// <summary>
    /// ������ ������ ���� �̸�
    /// </summary>
    public string textFileName = "textPlayer.txt";
    public string jsonFIleName = "jsonPlayer.json";
    /// <summary>
    /// ������ ������ ����
    /// </summary>
    public string folderName = "PlayerData";
    /// <summary>
    /// ���� ��ε�
    /// </summary>
    string folderPath;
    string txtPath;
    string jsonPath;
    private void Awake()
    {
        instance = this;
        // �پ��� �÷������� ���
        Debug.Log(Application.persistentDataPath);
        // ���� ���ø����̼��� ���
        Debug.Log(Application.dataPath);
        folderPath = Path.Combine(Application.dataPath, folderName);
        txtPath = Path.Combine(Application.dataPath, folderName, textFileName);
        jsonPath = Path.Combine(Application.dataPath, folderName, jsonFIleName);

    }

    void Start()
    {
        

    }
    #region txt ����
    /// <summary>
    /// ������ �ִ��� Ȯ�� �� ������ ����
    /// </summary>
    public void CreateFoldder()
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            Debug.Log("���� ���� �Ϸ�");
        }
    }
    /// <summary>
    /// �ؽ�Ʈ ���� ����
    /// </summary>
    
    public void SaveText(string content)
    {
        CreateFoldder();
        File.WriteAllText(txtPath, content);

        Debug.Log("txt ���� ���� �Ϸ�");
    }
    public string LoadText()
    {
        if(File.Exists(txtPath))
        {
            return File.ReadAllText(txtPath);
        }
        Debug.Log("txt ���� �ε� ����");
        return null;
    }
    public void UpdateFile(string newContent)
    {
        if(File.Exists(txtPath))
        {
            File.WriteAllText(txtPath, newContent);
            Debug.Log("txt ���� ���� �Ϸ�");
        }
        else
        {
            Debug.LogWarning("txt ���� ���� ����");   // ������ �����ؾ��ϴ� �κп� Debug.LogWarring�� ���
        }
    }
    public void DeleteFIle()
    {
        if(File.Exists(txtPath))
        {
            File.Delete(txtPath);
            Debug.Log("txt ���� ���� �Ϸ�");
        }
        else
        {
            Debug.LogWarning("txt ���� ���� ����");
        }
    }

    #endregion

    #region json ����
    public void SaveJson(PlayerData player)
    {
        //prettyPrint�� json ������ ����� ����� �б� ���� ǥ�����ִ� ���
        string jsonString = JsonUtility.ToJson(player, true);
        File.WriteAllText(jsonPath, jsonString);
        Debug.Log("JSON ���� �Ϸ�");
    }

    public PlayerData LoadJson()
    {
        if(File.Exists(jsonPath))
        {
            string json = File.ReadAllText(jsonPath);
            return JsonUtility.FromJson<PlayerData>(json);  // �Ȱ��� json ȣ�� ������
        }
        else
        {
            Debug.LogWarning("json ���� �ε� ����");
            return null;
        }
    }
    public void UpdateJsonField(string name, int stgae, int score)
    {
        PlayerData data = LoadJson();
        if(data != null)
        {
            data.Name = name;
            data.Stage = stgae;
            data.Score = score;
            SaveJson(data);
            Debug.Log("json ���� ���� �Ϸ�");
        }
    }
    public void DeleteJson()
    {
        if (File.Exists(jsonPath))
        {
            File.Delete(jsonPath);
            Debug.Log("json ���� ���� �Ϸ�");
        }
    }
    #endregion 
    
    // ���� ������� �ȵɽ� ������ Ȯ���غ��ߵ�!
    void Update()
    {
        
    }

}
