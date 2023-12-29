using System.Diagnostics;
using AddressBookShared.Interfaces;

namespace AddressBookShared.Services;
public class FileService : IFileService
{
    private readonly string _filePath = @"C:\Projects\content.json";

    /// <summary>
    /// Saves content to file
    /// </summary>
    /// <param name="content">Content to be saved</param>
    /// <returns>Returns true if save is successfull. Else return false</returns>
    public bool SaveContentToFile(string content)
    {
        try
        {
            //Using Streamwriter to write content to file
            using (var sw = new StreamWriter(_filePath))
            {
                sw.WriteLine(content);
                return true;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        //Returns false if save is not successfull or something went wrong.
        return false;
    }


    /// <summary>
    /// Get content from file
    /// </summary>
    /// <returns>Returns the text from file if found. Else return null</returns>
    public string GetContentFromFile()
    {
        try
        {
            //Check if the file exist
            if (File.Exists(_filePath))
            {
                //Streamreader reads content from file 
                using (var sr = new StreamReader(_filePath))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        //Returns null if file is not found or something went wrong
        return null!;
    }

}
