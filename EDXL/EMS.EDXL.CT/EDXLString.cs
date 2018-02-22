using System;
using System.Xml.Serialization;

namespace EMS.EDXL.CT
{
  public struct EDXLString
  {
    private string _RealString;

    public EDXLString(string input)
    {
      _RealString = string.Empty;
      SetWrappedString(input);
    }

    [XmlText]
    public string EDXLCustomFormat
    {
      get
      {
        return NormalizeWhiteSpace(_RealString, ' ');
      }

      set
      {
        SetWrappedString(value);
      }
    }

    public static implicit operator string(EDXLString custom)
    {
      return custom._RealString;
    }

    public static implicit operator EDXLString(string _string)
    {
      return new EDXLString { _RealString = _string };
    }

    internal void SetWrappedString (string input)
    {
      if (input.Length > 0 && input.Length < 1024)
      {
        _RealString = input;
      }
      else
      {
        throw new ArgumentOutOfRangeException("EDXLString must be at least 1 character, but less than 1024 characters in length.");
      }
    }

    internal static string NormalizeWhiteSpace(string input, char normalizeTo = ' ')
    {
      if (string.IsNullOrEmpty(input))
        return string.Empty;

      int current = 0;
      char[] output = new char[input.Length];
      bool skipped = false;

      foreach (char c in input.ToCharArray())
      {
        if (char.IsWhiteSpace(c))
        {
          if (!skipped)
          {
            if (current > 0)
              output[current++] = normalizeTo;

            skipped = true;
          }
        }
        else
        {
          skipped = false;
          output[current++] = c;
        }
      }

      return new string(output, 0, skipped ? current - 1 : current);
    }
  }
}
