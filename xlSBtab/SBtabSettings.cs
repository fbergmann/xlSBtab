using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace xlSBtab
{
  [Serializable]
  public class SBtabSettings
  {
    public string PythonInterpreter { get; set; }
    public string SBtabDir { get; set; }

    public static string SettingsFile
    {
      get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "sbtab-settings.xml"); }
    }

    public static SBtabSettings Instance
    {
      get
      {
        if (_instance == null)
          _instance = GetDefault();
        return _instance;
      }
      set
      {
        _instance = value;
        _instance.Save();
      }
    }

    public static SBtabSettings GetDefault()
    {
      var instance = FromXmlFile(SettingsFile);
      if (instance == null)
      {
        var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var master = dir == null ? "" : Path.Combine(dir, "default_config.xml");
        if (File.Exists(master))
          instance = FromXmlFile(master);
        if (instance == null)
          return new SBtabSettings {
            PythonInterpreter = @"C:\Python27\python.exe",
            SBtabDir = @"E:\Development\SBtab\scripts" 
          };
      }
      return instance;
    }

    public void Save()
    {
      WriteXmlToFile(SettingsFile);
    }

    private static SBtabSettings _instance;


    public static SBtabSettings FromXmlFile(string fileName)
    {
      try
      {
        var serializer = new System.Xml.Serialization.XmlSerializer(typeof(SBtabSettings));
        var text = File.ReadAllText(fileName);
        using (var stringReader = new StringReader(text))
        {
          return (SBtabSettings)serializer.Deserialize(stringReader);
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Could not load settings: {0}\n\n{1}", ex.Message, ex.StackTrace);
        return null;
      }
    }

    public void WriteXmlToFile(string fileName)
    {
      var serializer = new System.Xml.Serialization.XmlSerializer(GetType());
      using (var stream = new StringWriter())
      {
        serializer.Serialize(stream, this);
        stream.Flush();
        File.WriteAllText(fileName, stream.ToString());
      }
    }

  }
}