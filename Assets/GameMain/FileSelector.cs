using UnityEngine;
using UnityEditor;

public class FileSelector : MonoBehaviour
{
    private void Start()
    {
        OpenFile();
    }
    public void OpenFile()
    {
        // ���ļ�ѡ��Ի��򣬲������û�ѡ����ļ�·��
        string filePath = EditorUtility.OpenFilePanel("Select a file", "", "");

        // ����û�ѡ�����ļ������ӡ�ļ�·��
        if (!string.IsNullOrEmpty(filePath))
        {
            Debug.LogError("Selected file: " + filePath);
        }
    }

    public void OpenFileWithFilters()
    {
        // �����ļ�������
        string[] extensions = { "txt", "xml", "json", "csv" };
        string filter = "Text files,XML files,JSON files,CSV files (*.txt,*.xml,*.json,*.csv)|*.txt;*.xml;*.json;*.csv";

        // ���ļ�ѡ��Ի��򣬲������û�ѡ����ļ�·��
        string filePath = EditorUtility.OpenFilePanelWithFilters("Select a file", "", extensions);

        // ����û�ѡ�����ļ������ӡ�ļ�·��
        if (!string.IsNullOrEmpty(filePath))
        {
            Debug.LogError("Selected file: " + filePath);
        }
    }
}
