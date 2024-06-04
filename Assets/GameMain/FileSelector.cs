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
        // 打开文件选择对话框，并返回用户选择的文件路径
        string filePath = EditorUtility.OpenFilePanel("Select a file", "", "");

        // 如果用户选择了文件，则打印文件路径
        if (!string.IsNullOrEmpty(filePath))
        {
            Debug.LogError("Selected file: " + filePath);
        }
    }

    public void OpenFileWithFilters()
    {
        // 定义文件过滤器
        string[] extensions = { "txt", "xml", "json", "csv" };
        string filter = "Text files,XML files,JSON files,CSV files (*.txt,*.xml,*.json,*.csv)|*.txt;*.xml;*.json;*.csv";

        // 打开文件选择对话框，并返回用户选择的文件路径
        string filePath = EditorUtility.OpenFilePanelWithFilters("Select a file", "", extensions);

        // 如果用户选择了文件，则打印文件路径
        if (!string.IsNullOrEmpty(filePath))
        {
            Debug.LogError("Selected file: " + filePath);
        }
    }
}
