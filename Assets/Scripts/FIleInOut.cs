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
    /// 파일을 저장할 파일 이름
    /// </summary>
    public string textFileName = "textPlayer.txt";
    public string jsonFIleName = "jsonPlayer.json";
    /// <summary>
    /// 정보를 저장할 폴더
    /// </summary>
    public string folderName = "PlayerData";
    /// <summary>
    /// 실제 경로들
    /// </summary>
    string folderPath;
    string txtPath;
    string jsonPath;
    private void Awake()
    {
        instance = this;
        // 다양한 플렛폼에서 사용
        Debug.Log(Application.persistentDataPath);
        // 현재 어플리케이션의 경로
        Debug.Log(Application.dataPath);
        folderPath = Path.Combine(Application.dataPath, folderName);
        txtPath = Path.Combine(Application.dataPath, folderName, textFileName);
        jsonPath = Path.Combine(Application.dataPath, folderName, jsonFIleName);

    }

    void Start()
    {
        

    }
    #region txt 파일
    /// <summary>
    /// 폴더가 있는지 확인 후 폴더를 생성
    /// </summary>
    public void CreateFoldder()
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            Debug.Log("폴더 생성 완료");
        }
    }
    /// <summary>
    /// 텍스트 파일 저장
    /// </summary>
    
    public void SaveText(string content)
    {
        CreateFoldder();
        File.WriteAllText(txtPath, content);

        Debug.Log("txt 파일 저장 완료");
    }
    public string LoadText()
    {
        if(File.Exists(txtPath))
        {
            return File.ReadAllText(txtPath);
        }
        Debug.Log("txt 파일 로드 실패");
        return null;
    }
    public void UpdateFile(string newContent)
    {
        if(File.Exists(txtPath))
        {
            File.WriteAllText(txtPath, newContent);
            Debug.Log("txt 파일 수정 완료");
        }
        else
        {
            Debug.LogWarning("txt 파일 수정 실패");   // 무조건 수정해야하는 부분에 Debug.LogWarring을 사용
        }
    }
    public void DeleteFIle()
    {
        if(File.Exists(txtPath))
        {
            File.Delete(txtPath);
            Debug.Log("txt 파일 삭제 완료");
        }
        else
        {
            Debug.LogWarning("txt 파일 삭제 실패");
        }
    }

    #endregion

    #region json 파일
    public void SaveJson(PlayerData player)
    {
        //prettyPrint란 json 형태의 모양을 사람이 읽기 쉽게 표기해주는 방식
        string jsonString = JsonUtility.ToJson(player, true);
        File.WriteAllText(jsonPath, jsonString);
        Debug.Log("JSON 저장 완료");
    }

    public PlayerData LoadJson()
    {
        if(File.Exists(jsonPath))
        {
            string json = File.ReadAllText(jsonPath);
            return JsonUtility.FromJson<PlayerData>(json);  // 똑같은 json 호출 가능함
        }
        else
        {
            Debug.LogWarning("json 파일 로드 실패");
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
            Debug.Log("json 파일 저장 완료");
        }
    }
    public void DeleteJson()
    {
        if (File.Exists(jsonPath))
        {
            File.Delete(jsonPath);
            Debug.Log("json 파일 삭제 완료");
        }
    }
    #endregion 
    
    // 파일 입출력이 안될시 권한을 확인해봐야됨!
    void Update()
    {
        
    }

}
