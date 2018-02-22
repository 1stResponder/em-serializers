// ———————————————————————–
// <copyright file="StringGeoTools.cs" company="EDXLSharp">
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// ———————————————————————–

using System;
using System.Collections.Generic;
//using System.Data.SqlTypes;
using System.Linq;
using System.Text;
//using Microsoft.SqlServer.Types;
//TODO: System.Spatial isn't in System library for .NET Core.  using System.Spatial;
//using System.Data.SqlTypes;

namespace EMS.EDXL.Utilities
{
  /// <summary>
  /// Static Class To Check Validity of Geographic Objects Represented in Free Text Strings
  /// </summary>
  [Serializable]
  public static partial class StringGeoTools
  {
    /// <summary>
    /// Validates A Circle In The Form latitude,longitude radius
    /// </summary>
    /// <param name="s">latitude,longitude radius in the form WGS84 km</param>
    public static void CheckCircle(string s)
    {
      if (s == null)
      {
        throw new ArgumentNullException("Input string can't be null");
      }

      int index = s.LastIndexOf(" ");
      if (index == -1)
      {
        throw new FormatException("Circle input string must be in the format lat,lon<space>radius");
      }

      double radius = double.Parse(s.Substring(index + 1));
      if (radius < 0)
      {
        throw new FormatException("Circle radius must be greater than 0");
      }

      string pointstr = s.Substring(0, index);
      CheckPoint(pointstr);
    }

    /// <summary>
    /// Flips (Reverses) the order of coordinates listed in the definition of a polygon
    /// Example:
    /// Input: "1,3 4,5 6,7 1,3"
    /// Output:"1,3 7,6 4,5 1,3" 
    /// </summary>
    /// <param name="poly">Space Delimited String of WGS84 Comma Separated Pairs</param>
    /// <returns>String with reversed order points</returns>
    public static string FlipPolygon(string poly)
    {
      string fixedPoly = string.Empty;
      string[] points = poly.Split(' ');
      for (int p = points.Length - 1; p >= 0; p--)
      {
        fixedPoly += points[p];
        if (p != 0)
        {
          fixedPoly += " ";
        }
      }

      return fixedPoly;
    }

    /// <summary>
    /// Validates A Polygon In The Form latitude,longitude latitude,longitude ...
    /// Constructs a SQLGeography from a string of coordinates, makes it a 'valid' polygon, and returns the modified coordinates in a string.
    /// Throws unique FormatException with value "Needs Flipped" when the SQLGeography fails to instantiate
    /// A fork of StringGeoTools.CheckPolygon()
    /// </summary>
    /// <param name="s">Space Delimited String of WGS84 Comma Separated Pairs</param>
    /// <returns>Valid polygon string of points</returns>
    public static string ValidatePolygon(string s)
    {
      // The validated polygon to return, as a string
      string fixedPoly = string.Empty;
      if (s == null)
      {
        throw new ArgumentNullException("Input string can not be null");
      }

      char[] seperator = new char[1] { ' ' };
      char[] seperator2 = new char[1] { ',' };
      string[] split2;
      List<string> split = s.Split(seperator).ToList();
      
      foreach (string point in split)
      {
        StringGeoTools.CheckPoint(point);
      }

      if (split[0] != split[split.Count - 1])
      {
          throw new FormatException("Invalid Polygon! First and last points must be equal");
      }

      StringBuilder sqlstring = new StringBuilder();
      foreach (string point in split)
      {
        split2 = point.Split(seperator2);
        sqlstring.Append(split2[1]);
        sqlstring.Append(" ");
        sqlstring.Append(split2[0]);
        sqlstring.Append(",");
      }

      // Remove last comma
      sqlstring.Remove(sqlstring.Length - 1, 1);

      StringBuilder fullstr = new StringBuilder();
      fullstr.Append("POLYGON ((");
      fullstr.Append(sqlstring.ToString());
      fullstr.Append("))");
      //TODO: Need to address SQL and SqlGeography issues in CORE
      //SqlChars schars;
      try
      {
        //schars = new SqlChars(fullstr.ToString().ToCharArray());
        //TODO: Determine replacement text here...maybe from Npgsql
        //SqlGeography.STPolyFromText(schars, 4326);
        fixedPoly = s; // everything looks fine, return value is set to the be the same as the input
      }
      catch (ArgumentException ae)
      {
        //TODO:Fix SQL stuff
        //if (!ae.ToString().Contains("24205"))
        //{
        //  // Force it into a SQL Geometry type, which allows us to make the bad polygon valid
        //  schars = new SqlChars(fullstr.ToString().ToCharArray());
        //  SqlGeometry g = SqlGeometry.STGeomFromText(schars, 4326);
        //  ////Console.WriteLine("Valid = " + g.STIsValid());
        //  if (!g.STIsValid())
        //  {
        //    g = g.MakeValid();

        //    // Write the polygon back out as a string for the XML side
        //    for (int i = 1; i <= g.STNumPoints().Value; i++)
        //    {
        //      fixedPoly += g.STPointN(i).STY.ToString();
        //      fixedPoly += ",";
        //      fixedPoly += g.STPointN(i).STX.ToString();
        //      fixedPoly += " ";
        //    }

        //    // Repeat the first point to close the loop
        //    fixedPoly += g.STPointN(1).STY.ToString();
        //    fixedPoly += ",";
        //    fixedPoly += g.STPointN(1).STX.ToString();
        //  }
        //  else
        //  {
        //    throw new FormatException("Needs Flipped");  // ArgumentException with 24205 but not isValid()
        //  }
        //}
        //else
        //{
        //  throw new FormatException("Needs Flipped"); // ArgumentException, but not 24205
        //}
      }
      catch (Exception e)
      {
        throw new FormatException("Invalid Polygon! " + e.ToString()); // Other Exception
      }

      return fixedPoly;
    }

    /// <summary>
    /// Validates A Circle In The Form latitude,longitude latitude,longitude ...
    /// </summary>
    /// <param name="s">Space Delimited String of WGS84 Comma Separated Pairs</param>
    public static void CheckPolygon(string s)
    {
      if (s == null)
      {
        throw new ArgumentNullException("Polygon input string can not be null");
      }

      char[] seperator = new char[1] { ' ' };
      char[] seperator2 = new char[1] { ',' };
      string[] split2;
      List<string> split = s.Split(seperator).ToList();

      // if we are dealing with a point, treat it differently than a regular polygon
      if (split.Count == 2 && split[0].Equals(split[1]))
      {
        CheckPoint(split[0]);
        return;
      }

      foreach (string point in split)
      {
        CheckPoint(point);
      }

      if (split[0] != split[split.Count - 1])
      {
        throw new FormatException("Invalid Polygon! First and last points must be equal");
      }

      StringBuilder sqlstring = new StringBuilder();
      foreach (string point in split)
      {
        split2 = point.Split(seperator2);
        sqlstring.Append(split2[1]);
        sqlstring.Append(" ");
        sqlstring.Append(split2[0]);
        sqlstring.Append(",");
      }

      // Remove last comma
      sqlstring.Remove(sqlstring.Length - 1, 1);

      StringBuilder fullstr = new StringBuilder();
      fullstr.Append("POLYGON ((");
      fullstr.Append(sqlstring.ToString());
      fullstr.Append("))");
      //TODO: FIX SQL Stuff
      //SqlChars schars;
      try
      {
        //schars = new SqlChars(fullstr.ToString().ToCharArray());
        //SqlGeography.STPolyFromText(schars, 4326);
        return;
      }
      catch (ArgumentException ae)
      {
        string strae = ae.ToString();
        /*if (!ae.ToString().Contains("24205"))
        {
          throw ae;
        }*/
      }
      catch (Exception e)
      {
        throw new FormatException("Invalid Polygon! " + e.ToString());
      }

      try
      {
        split = sqlstring.ToString().Split(seperator2).ToList();
        split.Reverse();
        sqlstring = new StringBuilder();
        foreach (string point in split)
        {
          sqlstring.Append(point);
          sqlstring.Append(",");
        }

        // Remove last comma
        sqlstring.Remove(sqlstring.Length - 1, 1);
        fullstr = new StringBuilder();
        fullstr.Append("POLYGON ((");
        fullstr.Append(sqlstring.ToString());
        fullstr.Append("))");
        //TODO: Fix Sql Stuff
        //schars = new SqlChars(fullstr.ToString().ToCharArray());
        //SqlGeography.STPolyFromText(schars, 4326);
        return;
      }
      catch (Exception e)
      {
        throw new FormatException("Invalid Polygon! " + e.ToString());
      }
    }

    /// <summary>
    /// Checks The Two Character Country String
    /// </summary>
    /// <param name="s">Two Character Country String</param>
    public static void CheckCountry(string s)
    {
      if (s == null)
      {
        throw new ArgumentNullException("Country input string can't be null");
      }

      if (s.Length != 2)
      {
        throw new FormatException("Country must be a two character ISO 3166-1 country code");
      }

      if (!(char.IsLetterOrDigit(s, 0) && char.IsLetterOrDigit(s, 1)))
      {
        throw new FormatException("Country must be a two character ISO 3166-1 country code");
      }
    }

    /// <summary>
    /// Checks The Char[2] Pair Dash Delimited String
    /// </summary>
    /// <param name="s">Two Character Pairs ex. US-CA</param>
    public static void CheckSubdivision(string s)
    {
      if (s == null)
      {
        throw new ArgumentNullException("Subdivision input string can't be null");
      }

      if (s.Length != 6 && s.IndexOf("-") != 2 && s.Length != 5)
      {
        throw new FormatException("Subdivision must be a ISO 3166-1 country code in the form xx-xx or xx-xxx");
      }

      if (s.Length == 5 && !(char.IsLetterOrDigit(s, 0) && char.IsLetterOrDigit(s, 1) && char.IsLetterOrDigit(s, 3) && char.IsLetterOrDigit(s, 4)))
      {
        throw new FormatException("Subdivision must be a ISO 3166-1 country code in the form xx-xx where x is a letter or digit");
      }
      else if (s.Length == 6 && !(char.IsLetterOrDigit(s, 0) && char.IsLetterOrDigit(s, 1) && char.IsLetterOrDigit(s, 3) && char.IsLetterOrDigit(s, 4) && char.IsLetterOrDigit(s, 5)))
      {
        throw new FormatException("Subdivision must be a ISO 3166-1 country code in the form xx-xxx where x is a letter or digit");
      }
    }

    /// <summary>
    /// Validates A UN LOC Code
    /// </summary>
    /// <param name="s">UN LOC Code String</param>
    public static void CheckLocCodeUN(string s)
    {
      if (s == null)
      {
        throw new ArgumentNullException("Input string can't be null");
      }

      if (s.Length != 6 && s.IndexOf("-") != 2)
      {
        throw new FormatException("UN LOC Code must be a ISO 3166-1 country code followed by a UN LOC Code in the form xx-xxx");
      }

      /* NEED TO RESOLVE THIS
    else if (s.Length == 6 && !(char.IsLetterOrDigit(s, 0) && char.IsLetterOrDigit(s, 1) && char.IsLetterOrDigit(s, 3) && char.IsLetterOrDigit(s, 4) && char.IsLetterOrDigit(s, 5)))
    {
      throw new FormatException("UNLocCode Must be a ISO 3166-1 country code followed by a UNLOCCode in the form xx-xxx where x is a letter or digit");
    }*/
    }

    /// <summary>
    /// Checks A Comma Delimited WGS84 Decimal String
    /// </summary>
    /// <param name="s">latitude,longitude in WGS84 Decimal</param>
    public static void CheckPoint(string s)
    {
      if (s == null)
      {
        throw new ArgumentNullException("Point input string can not be null");
      }

      int index = s.IndexOf(",");
      if (index == -1)
      {
        throw new FormatException("Point coordinates must be WGS84 comma separated lat,lon pairs");
      }

      double lat = double.Parse(s.Substring(0, index));
      if (lat > 90.0 || lat < -90.0)
      {
        throw new FormatException("WGS84 Latitudes must be between -90.0 and +90.0");
      }

      double lon = double.Parse(s.Substring(index + 1));
      if (lon > 180.0 || lon < -180.0)
      {
        throw new FormatException("WGS84 Longitudes must be between -180.0 and +180.0");
      }
    }

    /// <summary>
    /// Checks A Decimal Value To be Not Null and Greater Than 0
    /// </summary>
    /// <param name="d">Decimal Value</param>
    public static void CheckDecimal(decimal? d)
    {
      if (d == null)
      {
        return;
      }

      if (d < 0)
      {
        throw new ArgumentException("Decimal value must be greater then 0");
      }
    }
  }
}
