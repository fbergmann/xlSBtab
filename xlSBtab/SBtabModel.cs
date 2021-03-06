﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace xlSBtab
{
  public class SBtabModel
  {
    private static string _tempDir;
    public static string TempDir
    {
      get {  if (string.IsNullOrWhiteSpace(_tempDir))
      {
        _tempDir = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), "xlsbtab");
      }
        return _tempDir;
      }
      set { _tempDir = value; }
    }


    public static string GetExcelPos(int startRow, int index)
    {
      return ((char)('A' + index)).ToString() + (startRow + 1).ToString();
    }

    public static int AddFileToSheet(Worksheet sheet, string file, int startRow = 0)
    {
      var lines = File.ReadLines(file).ToList();
      var start = GetExcelPos(startRow, 0);
      string endPos = string.Empty;
      string tableName = string.Empty;
      int maxCols = 0;
      for (int row = 0; row < lines.Count; row++)
      {
        var line = lines[row];
        if (row == 0) tableName = GuessName(line);
        if (row == 1)
        {
          start = GetExcelPos(startRow, 0);
          maxCols = line.Split(new[] { '\t' }).Length;
        }
        var cols = line.Split(new[] { '\t' });
        if (cols.Length < 2) continue;
        for (int index = 0; index < Math.Min(cols.Length, maxCols); index++)
        {
          var col = cols[index];
          endPos = GetExcelPos(startRow, index);
          Range next = sheet.Range[endPos];
          next.Value2 = col;
        }
        ++startRow;
      }

      // now style it as table
      var SourceRange = sheet.Range[start, endPos];
      if (string.IsNullOrWhiteSpace(tableName))
        tableName = "table" + SourceRange.Worksheet.ListObjects.Count;

      SourceRange.Worksheet.ListObjects.Add(
        XlListObjectSourceType.xlSrcRange,
        SourceRange, 
        Type.Missing, 
        XlYesNoGuess.xlGuess, Type.Missing)
        .Name = tableName;

      SourceRange.Select();

      SourceRange.Worksheet.ListObjects[tableName].TableStyle = "TableStyleLight2";

      return startRow;
    }

    public static string GuessName(string line)
    {
      int lastIndex = line.LastIndexOf('\'');
      int secondLastIndex;
      string name;
      if (lastIndex == -1)
      {
        lastIndex = line.LastIndexOf('\"');
        if (lastIndex == -1)
        {
          return "Unknown";
        }
        secondLastIndex = line.LastIndexOf('\"', lastIndex - 1);
        name = line.Substring(secondLastIndex + 1, lastIndex - secondLastIndex - 1);
        return name;
      }
      secondLastIndex = line.LastIndexOf('\'', lastIndex - 1);
      name = line.Substring(secondLastIndex, lastIndex - secondLastIndex);
      return name;
    }

    public static void RemoveExistingTsvFiles(string dir)
    {
      var files = Directory.GetFiles(dir, "*.tsv", SearchOption.TopDirectoryOnly);
      foreach (var file in files)
        File.Delete(file);
    }

    public static void LoadFile(string fileName, Worksheet sheet)
    {
      var dir = SBtabSettings.Instance.SBtabDir;

      if (!Directory.Exists(TempDir))
        Directory.CreateDirectory(TempDir);

      RemoveExistingTsvFiles(TempDir);

      
      var builder = new StringBuilder();
      builder.AppendFormat("\"{0}\" ", Path.Combine(dir, "convert.py"));
      builder.AppendFormat("\"{0}\" ", fileName);
      builder.AppendFormat("\"{0}\" ", TempDir);

      var info = new ProcessStartInfo
      {
        FileName = SBtabSettings.Instance.PythonInterpreter,
        WorkingDirectory = dir,
        Arguments = builder.ToString(),
        CreateNoWindow = true,
        UseShellExecute = false
      };

      Process.Start(info).WaitForExit();

      sheet.Name = Path.GetFileNameWithoutExtension(fileName);
      sheet.Cells.ClearContents();

      var files = Directory.GetFiles(TempDir, "*.tsv", SearchOption.TopDirectoryOnly);
      int startRow = 0;
      foreach (var file in files)
      {
        startRow = AddFileToSheet(sheet, file, startRow);
        ++startRow;
      }
    }

    public static string ToSBtab(Worksheet sheet)
    {
      var builder = new StringBuilder();

      var cells = sheet.Cells;

      int maxCount = 0;
      int maxRows = cells.Rows.Count;
      bool countLength = true;
      int emptyCount = 0;
      for (int i = 0; i < maxRows; ++i)
      {
        int maxCols = cells.Columns.Count;
        object firstValue = sheet.Range[GetExcelPos(i, 0)].Value;
        bool isHeaderRow = firstValue is string && ((string)firstValue).StartsWith("!");
        countLength = countLength || isHeaderRow;
        if (firstValue == null)
        {
          ++emptyCount;
          builder.AppendLine();
          if (emptyCount == 3)
            break;
          continue;
        }

        if (isHeaderRow)
        {
          if (!((string)firstValue).StartsWith("!!"))
          {
            string name = ((string)firstValue).Replace("!", "").Trim();
            builder.AppendFormat("!!SBtab SBtabVersion=\"0.8\" Document=\"{0}\" TableType=\"{1}\" TableName=\"{1}\"{2}",
              sheet.Name, name, Environment.NewLine);
            ;
          }
        }

        emptyCount = 0;

        if (countLength)
        {
          maxCount = 0;
          for (int j = 0; j < maxCols; ++j)
          {
            var current = sheet.Range[GetExcelPos(i, j)];
            object currentValue = current.Value;
            if (currentValue == null) break;
            ++maxCount;
          }
          countLength = false;
        }

        for (int j = 0; j < maxCount; ++j)
        {
          var current = sheet.Range[GetExcelPos(i, j)];
          object currentValue = current.Value;

          if (currentValue != null)
            builder.AppendFormat("{0}", currentValue);

          if (j + 1 < maxCount)
            builder.AppendFormat("\t");
        }
        builder.AppendLine();
      }

      return builder.ToString();
    }

    private static void SaveDelete(string fileName)
    {
      if (File.Exists(fileName))
      {
        try
        {
          File.Delete(fileName);
        }
        catch (Exception)
        {
        }
      }
    }

    public static bool SaveSheetAs(string fileName, Worksheet sheet)
    {
      var dir = SBtabSettings.Instance.SBtabDir;
      var sbTab = ToSBtab(sheet);
      string tsvFileName = Path.Combine(TempDir, "out.tsv");
      string sbmlFile = Path.Combine(TempDir, "new_sbml.xml");

      SaveDelete(tsvFileName);
      SaveDelete(sbmlFile);

      if (!Directory.Exists(TempDir))
        Directory.CreateDirectory(TempDir);


      File.WriteAllText(tsvFileName, sbTab);

      var builder = new StringBuilder();
      builder.AppendFormat("\"{0}\" ", Path.Combine(dir, "toSBML.py"));
      builder.AppendFormat("\"{0}\" ", tsvFileName);
      builder.AppendFormat("\"{0}\" ", sbmlFile);

      var info = new ProcessStartInfo
      {
        FileName = SBtabSettings.Instance.PythonInterpreter,
        WorkingDirectory = dir,
        Arguments = builder.ToString(),
        CreateNoWindow = true,
        UseShellExecute = false
      };

      Process.Start(info).WaitForExit();

      if (!File.Exists(sbmlFile))
      {
        return false;
      }

      SaveDelete(fileName);

      File.Move(sbmlFile, fileName);
      return true;
    }

    public static string Validate(Worksheet sheet)
    {
      var dir = SBtabSettings.Instance.SBtabDir;
      var sbTab = ToSBtab(sheet);
      string tsvFileName = Path.Combine(TempDir, "out.tsv");
      string reportFile = Path.Combine(TempDir, "validate.txt");

      SaveDelete(tsvFileName);
      SaveDelete(reportFile);

      if (!Directory.Exists(TempDir))
        Directory.CreateDirectory(TempDir);


      File.WriteAllText(tsvFileName, sbTab);

      var builder = new StringBuilder();
      builder.AppendFormat("\"{0}\" ", Path.Combine(dir, "validate.py"));
      builder.AppendFormat("\"{0}\" ", tsvFileName);
      builder.AppendFormat("\"{0}\" ", reportFile);

      var info = new ProcessStartInfo
      {
        FileName = SBtabSettings.Instance.PythonInterpreter,
        WorkingDirectory = dir,
        Arguments = builder.ToString(),
        CreateNoWindow = true,
        UseShellExecute = false
      };

      Process.Start(info).WaitForExit();

      if (!File.Exists(reportFile))
      {
        return "Validation failed ... ";
      }

      return File.ReadAllText(reportFile); 
    }
  }
}