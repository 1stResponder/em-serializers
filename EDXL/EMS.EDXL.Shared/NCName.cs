// ———————————————————————–
// <copyright file="NCName.cs" company="EDXLSharp">
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
using System.Xml.Serialization;

namespace EMS.EDXL.Shared
{
  /// <summary>
  /// Class for the XML Schema Type NCNAME
  /// </summary>
  [Serializable]
  public partial class NCName
  {
    #region Private Member Variables

    /// <summary>
    /// String to hold internal val of the NCName
    /// </summary>
    private string nameInternal;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the NCName class
    /// Default Constructor - Does Nothing
    /// </summary>
    public NCName() 
    { 
    }

    /// <summary>
    /// Initializes a new instance of the NCName class
    /// Constructor to Initialize the string val
    /// </summary>
    /// <param name="instring">NCName String Value</param>
    public NCName(string instring)
    {
      this.Parse(instring);
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// The NCName String
    /// </summary>
    [XmlElement(DataType = "NCName")]
    public string Name
    {
      get { return this.nameInternal; }
      set { this.Parse(value); }
    }
    #endregion

    #region Public Member Functions

    /// <summary>
    /// Returns The NCName String
    /// </summary>
    /// <returns>The NCName String</returns>
    public override string ToString()
    {
      return this.nameInternal;
    }

    #endregion

    #region Private Member Functions

    /// <summary>
    /// Parses from a String
    /// </summary>
    /// <param name="instring">String Value to Parse</param>
    private void Parse(string instring)
    {
      if (instring == null)
      {
        throw new ArgumentNullException("Input String Can't Be Null!");
      }

      if (instring.Length == 0)
      {
        throw new ArgumentException("String Length can't be 0");
      }

      // Check first character
      char c = instring[0];

      if (c == '_' || this.IsLetter(c))
      {
        // Check the rest of the characters
        for (int i = 1; i < instring.Length; i++)
        {
          c = instring[i];
          if (!this.IsNCNameChar(c))
          {
            throw new ArgumentException("Invalid character: " + c);
          }
        }

        // All characters have been checked
        this.nameInternal = instring;
        return;
      }

      throw new ArgumentException("Invalid character: " + c);
    }

    /// <summary>
    /// Determines Whether This is a Valid NCName Character
    /// </summary>
    /// <param name="c">character to analyze</param>
    /// <returns>True if Valid</returns>
    private bool IsNCNameChar(char c)
    {
      return
      this._isAsciiBaseChar(c) ||
      this._isAsciiDigit(c) ||
      c == '.' || c == '-' || c == '_' ||
      this._isNonAsciiBaseChar(c) ||
      this._isNonAsciiDigit(c) ||
      this.IsIdeographic(c) ||
      this.IsCombiningChar(c) ||
      this.IsExtender(c);
    }

    /// <summary>
    /// Determines Whether This is a Valid Letter
    /// </summary>
    /// <param name="c">character to analyze</param>
    /// <returns>True if Valid</returns>
    private bool IsLetter(char c)
    {
      return
        this._isAsciiBaseChar(c) ||
        this._isNonAsciiBaseChar(c) ||
        this.IsIdeographic(c);
    }

    /// <summary>
    /// Determines Whether This is a Valid ASCII Base Character
    /// </summary>
    /// <param name="c">character to analyze</param>
    /// <returns>True if Valid</returns>
    private bool _isAsciiBaseChar(char c)
    {
      return
        this._charInRange(c, 0x0041, 0x005A) ||
        this._charInRange(c, 0x0061, 0x007A);
    }

    /// <summary>
    /// Determines Whether This is a Valid Non-ASCII Base Character
    /// </summary>
    /// <param name="c">character to analyze</param>
    /// <returns>True if Valid</returns>
    private bool _isNonAsciiBaseChar(char c)
    {
      return
        this._charInRange(c, 0x00C0, 0x00D6) ||
        this._charInRange(c, 0x00D8, 0x00F6) ||
        this._charInRange(c, 0x00F8, 0x00FF) ||
        this._charInRange(c, 0x0100, 0x0131) ||
        this._charInRange(c, 0x0134, 0x013E) ||
        this._charInRange(c, 0x0141, 0x0148) ||
        this._charInRange(c, 0x014A, 0x017E) ||
        this._charInRange(c, 0x0180, 0x01C3) ||
        this._charInRange(c, 0x01CD, 0x01F0) ||
        this._charInRange(c, 0x01F4, 0x01F5) ||
        this._charInRange(c, 0x01FA, 0x0217) ||
        this._charInRange(c, 0x0250, 0x02A8) ||
        this._charInRange(c, 0x02BB, 0x02C1) ||
        c == 0x0386 ||
        this._charInRange(c, 0x0388, 0x038A) ||
        c == 0x038C ||
        this._charInRange(c, 0x038E, 0x03A1) ||
        this._charInRange(c, 0x03A3, 0x03CE) ||
        this._charInRange(c, 0x03D0, 0x03D6) ||
        c == 0x03DA ||
        c == 0x03DC ||
        c == 0x03DE ||
        c == 0x03E0 ||
        this._charInRange(c, 0x03E2, 0x03F3) ||
        this._charInRange(c, 0x0401, 0x040C) ||
        this._charInRange(c, 0x040E, 0x044F) ||
        this._charInRange(c, 0x0451, 0x045C) ||
        this._charInRange(c, 0x045E, 0x0481) ||
        this._charInRange(c, 0x0490, 0x04C4) ||
        this._charInRange(c, 0x04C7, 0x04C8) ||
        this._charInRange(c, 0x04CB, 0x04CC) ||
        this._charInRange(c, 0x04D0, 0x04EB) ||
        this._charInRange(c, 0x04EE, 0x04F5) ||
        this._charInRange(c, 0x04F8, 0x04F9) ||
        this._charInRange(c, 0x0531, 0x0556) ||
        c == 0x0559 ||
        this._charInRange(c, 0x0561, 0x0586) ||
        this._charInRange(c, 0x05D0, 0x05EA) ||
        this._charInRange(c, 0x05F0, 0x05F2) ||
        this._charInRange(c, 0x0621, 0x063A) ||
        this._charInRange(c, 0x0641, 0x064A) ||
        this._charInRange(c, 0x0671, 0x06B7) ||
        this._charInRange(c, 0x06BA, 0x06BE) ||
        this._charInRange(c, 0x06C0, 0x06CE) ||
        this._charInRange(c, 0x06D0, 0x06D3) ||
        c == 0x06D5 ||
        this._charInRange(c, 0x06E5, 0x06E6) ||
        this._charInRange(c, 0x0905, 0x0939) ||
        c == 0x093D ||
        this._charInRange(c, 0x0958, 0x0961) ||
        this._charInRange(c, 0x0985, 0x098C) ||
        this._charInRange(c, 0x098F, 0x0990) ||
        this._charInRange(c, 0x0993, 0x09A8) ||
        this._charInRange(c, 0x09AA, 0x09B0) ||
        c == 0x09B2 ||
        this._charInRange(c, 0x09B6, 0x09B9) ||
        this._charInRange(c, 0x09DC, 0x09DD) ||
        this._charInRange(c, 0x09DF, 0x09E1) ||
        this._charInRange(c, 0x09F0, 0x09F1) ||
        this._charInRange(c, 0x0A05, 0x0A0A) ||
        this._charInRange(c, 0x0A0F, 0x0A10) ||
        this._charInRange(c, 0x0A13, 0x0A28) ||
        this._charInRange(c, 0x0A2A, 0x0A30) ||
        this._charInRange(c, 0x0A32, 0x0A33) ||
        this._charInRange(c, 0x0A35, 0x0A36) ||
        this._charInRange(c, 0x0A38, 0x0A39) ||
        this._charInRange(c, 0x0A59, 0x0A5C) ||
        c == 0x0A5E ||
        this._charInRange(c, 0x0A72, 0x0A74) ||
        this._charInRange(c, 0x0A85, 0x0A8B) ||
        c == 0x0A8D ||
        this._charInRange(c, 0x0A8F, 0x0A91) ||
        this._charInRange(c, 0x0A93, 0x0AA8) ||
        this._charInRange(c, 0x0AAA, 0x0AB0) ||
        this._charInRange(c, 0x0AB2, 0x0AB3) ||
        this._charInRange(c, 0x0AB5, 0x0AB9) ||
        c == 0x0ABD ||
        c == 0x0AE0 ||
        this._charInRange(c, 0x0B05, 0x0B0C) ||
        this._charInRange(c, 0x0B0F, 0x0B10) ||
        this._charInRange(c, 0x0B13, 0x0B28) ||
        this._charInRange(c, 0x0B2A, 0x0B30) ||
        this._charInRange(c, 0x0B32, 0x0B33) ||
        this._charInRange(c, 0x0B36, 0x0B39) ||
        c == 0x0B3D ||
        this._charInRange(c, 0x0B5C, 0x0B5D) ||
        this._charInRange(c, 0x0B5F, 0x0B61) ||
        this._charInRange(c, 0x0B85, 0x0B8A) ||
        this._charInRange(c, 0x0B8E, 0x0B90) ||
        this._charInRange(c, 0x0B92, 0x0B95) ||
        this._charInRange(c, 0x0B99, 0x0B9A) ||
        c == 0x0B9C ||
        this._charInRange(c, 0x0B9E, 0x0B9F) ||
        this._charInRange(c, 0x0BA3, 0x0BA4) ||
        this._charInRange(c, 0x0BA8, 0x0BAA) ||
        this._charInRange(c, 0x0BAE, 0x0BB5) ||
        this._charInRange(c, 0x0BB7, 0x0BB9) ||
        this._charInRange(c, 0x0C05, 0x0C0C) ||
        this._charInRange(c, 0x0C0E, 0x0C10) ||
        this._charInRange(c, 0x0C12, 0x0C28) ||
        this._charInRange(c, 0x0C2A, 0x0C33) ||
        this._charInRange(c, 0x0C35, 0x0C39) ||
        this._charInRange(c, 0x0C60, 0x0C61) ||
        this._charInRange(c, 0x0C85, 0x0C8C) ||
        this._charInRange(c, 0x0C8E, 0x0C90) ||
        this._charInRange(c, 0x0C92, 0x0CA8) ||
        this._charInRange(c, 0x0CAA, 0x0CB3) ||
        this._charInRange(c, 0x0CB5, 0x0CB9) ||
        c == 0x0CDE ||
        this._charInRange(c, 0x0CE0, 0x0CE1) ||
        this._charInRange(c, 0x0D05, 0x0D0C) ||
        this._charInRange(c, 0x0D0E, 0x0D10) ||
        this._charInRange(c, 0x0D12, 0x0D28) ||
        this._charInRange(c, 0x0D2A, 0x0D39) ||
        this._charInRange(c, 0x0D60, 0x0D61) ||
        this._charInRange(c, 0x0E01, 0x0E2E) ||
        c == 0x0E30 ||
        this._charInRange(c, 0x0E32, 0x0E33) ||
        this._charInRange(c, 0x0E40, 0x0E45) ||
        this._charInRange(c, 0x0E81, 0x0E82) ||
        c == 0x0E84 ||
        this._charInRange(c, 0x0E87, 0x0E88) ||
        c == 0x0E8A ||
        c == 0x0E8D ||
        this._charInRange(c, 0x0E94, 0x0E97) ||
        this._charInRange(c, 0x0E99, 0x0E9F) ||
        this._charInRange(c, 0x0EA1, 0x0EA3) ||
        c == 0x0EA5 ||
        c == 0x0EA7 ||
        this._charInRange(c, 0x0EAA, 0x0EAB) ||
        this._charInRange(c, 0x0EAD, 0x0EAE) ||
        c == 0x0EB0 ||
        this._charInRange(c, 0x0EB2, 0x0EB3) ||
        c == 0x0EBD ||
        this._charInRange(c, 0x0EC0, 0x0EC4) ||
        this._charInRange(c, 0x0F40, 0x0F47) ||
        this._charInRange(c, 0x0F49, 0x0F69) ||
        this._charInRange(c, 0x10A0, 0x10C5) ||
        this._charInRange(c, 0x10D0, 0x10F6) ||
        c == 0x1100 ||
        this._charInRange(c, 0x1102, 0x1103) ||
        this._charInRange(c, 0x1105, 0x1107) ||
        c == 0x1109 ||
        this._charInRange(c, 0x110B, 0x110C) ||
        this._charInRange(c, 0x110E, 0x1112) ||
        c == 0x113C ||
        c == 0x113E ||
        c == 0x1140 ||
        c == 0x114C ||
        c == 0x114E ||
        c == 0x1150 ||
        this._charInRange(c, 0x1154, 0x1155) ||
        c == 0x1159 ||
        this._charInRange(c, 0x115F, 0x1161) ||
        c == 0x1163 ||
        c == 0x1165 ||
        c == 0x1167 ||
        c == 0x1169 ||
        this._charInRange(c, 0x116D, 0x116E) ||
        this._charInRange(c, 0x1172, 0x1173) ||
        c == 0x1175 ||
        c == 0x119E ||
        c == 0x11A8 ||
        c == 0x11AB ||
        this._charInRange(c, 0x11AE, 0x11AF) ||
        this._charInRange(c, 0x11B7, 0x11B8) ||
        c == 0x11BA ||
        this._charInRange(c, 0x11BC, 0x11C2) ||
        c == 0x11EB ||
        c == 0x11F0 ||
        c == 0x11F9 ||
        this._charInRange(c, 0x1E00, 0x1E9B) ||
        this._charInRange(c, 0x1EA0, 0x1EF9) ||
        this._charInRange(c, 0x1F00, 0x1F15) ||
        this._charInRange(c, 0x1F18, 0x1F1D) ||
        this._charInRange(c, 0x1F20, 0x1F45) ||
        this._charInRange(c, 0x1F48, 0x1F4D) ||
        this._charInRange(c, 0x1F50, 0x1F57) ||
        c == 0x1F59 ||
        c == 0x1F5B ||
        c == 0x1F5D ||
        this._charInRange(c, 0x1F5F, 0x1F7D) ||
        this._charInRange(c, 0x1F80, 0x1FB4) ||
        this._charInRange(c, 0x1FB6, 0x1FBC) ||
        c == 0x1FBE ||
        this._charInRange(c, 0x1FC2, 0x1FC4) ||
        this._charInRange(c, 0x1FC6, 0x1FCC) ||
        this._charInRange(c, 0x1FD0, 0x1FD3) ||
        this._charInRange(c, 0x1FD6, 0x1FDB) ||
        this._charInRange(c, 0x1FE0, 0x1FEC) ||
        this._charInRange(c, 0x1FF2, 0x1FF4) ||
        this._charInRange(c, 0x1FF6, 0x1FFC) ||
        c == 0x2126 ||
        this._charInRange(c, 0x212A, 0x212B) ||
        c == 0x212E ||
        this._charInRange(c, 0x2180, 0x2182) ||
        this._charInRange(c, 0x3041, 0x3094) ||
        this._charInRange(c, 0x30A1, 0x30FA) ||
        this._charInRange(c, 0x3105, 0x312C) ||
        this._charInRange(c, 0xAC00, 0xD7A3);
    }

    /// <summary>
    /// Determines Whether This is a Valid Ideographic Character
    /// </summary>
    /// <param name="c">character to analyze</param>
    /// <returns>True if Valid</returns>
    private bool IsIdeographic(char c)
    {
      return
        this._charInRange(c, 0x4E00, 0x9FA5) ||
          c == 0x3007 ||
        this._charInRange(c, 0x3021, 0x3029);
    }

    /// <summary>
    /// Determines Whether This is a Valid Combination Character
    /// </summary>
    /// <param name="c">character to analyze</param>
    /// <returns>True if Valid</returns>
    private bool IsCombiningChar(char c)
    {
      return
        this._charInRange(c, 0x0300, 0x0345) ||
        this._charInRange(c, 0x0360, 0x0361) ||
        this._charInRange(c, 0x0483, 0x0486) ||
        this._charInRange(c, 0x0591, 0x05A1) ||
        this._charInRange(c, 0x05A3, 0x05B9) ||
        this._charInRange(c, 0x05BB, 0x05BD) ||
        c == 0x05BF ||
        this._charInRange(c, 0x05C1, 0x05C2) ||
        c == 0x05C4 ||
        this._charInRange(c, 0x064B, 0x0652) ||
        c == 0x0670 ||
        this._charInRange(c, 0x06D6, 0x06DC) ||
        this._charInRange(c, 0x06DD, 0x06DF) ||
        this._charInRange(c, 0x06E0, 0x06E4) ||
        this._charInRange(c, 0x06E7, 0x06E8) ||
        this._charInRange(c, 0x06EA, 0x06ED) ||
        this._charInRange(c, 0x0901, 0x0903) ||
        c == 0x093C ||
        this._charInRange(c, 0x093E, 0x094C) ||
        c == 0x094D ||
        this._charInRange(c, 0x0951, 0x0954) ||
        this._charInRange(c, 0x0962, 0x0963) ||
        this._charInRange(c, 0x0981, 0x0983) ||
        c == 0x09BC ||
        c == 0x09BE ||
        c == 0x09BF ||
        this._charInRange(c, 0x09C0, 0x09C4) ||
        this._charInRange(c, 0x09C7, 0x09C8) ||
        this._charInRange(c, 0x09CB, 0x09CD) ||
        c == 0x09D7 ||
        this._charInRange(c, 0x09E2, 0x09E3) ||
        c == 0x0A02 ||
        c == 0x0A3C ||
        c == 0x0A3E ||
        c == 0x0A3F ||
        this._charInRange(c, 0x0A40, 0x0A42) ||
        this._charInRange(c, 0x0A47, 0x0A48) ||
        this._charInRange(c, 0x0A4B, 0x0A4D) ||
        this._charInRange(c, 0x0A70, 0x0A71) ||
        this._charInRange(c, 0x0A81, 0x0A83) ||
        c == 0x0ABC ||
        this._charInRange(c, 0x0ABE, 0x0AC5) ||
        this._charInRange(c, 0x0AC7, 0x0AC9) ||
        this._charInRange(c, 0x0ACB, 0x0ACD) ||
        this._charInRange(c, 0x0B01, 0x0B03) ||
        c == 0x0B3C ||
        this._charInRange(c, 0x0B3E, 0x0B43) ||
        this._charInRange(c, 0x0B47, 0x0B48) ||
        this._charInRange(c, 0x0B4B, 0x0B4D) ||
        this._charInRange(c, 0x0B56, 0x0B57) ||
        this._charInRange(c, 0x0B82, 0x0B83) ||
        this._charInRange(c, 0x0BBE, 0x0BC2) ||
        this._charInRange(c, 0x0BC6, 0x0BC8) ||
        this._charInRange(c, 0x0BCA, 0x0BCD) ||
        c == 0x0BD7 ||
        this._charInRange(c, 0x0C01, 0x0C03) ||
        this._charInRange(c, 0x0C3E, 0x0C44) ||
        this._charInRange(c, 0x0C46, 0x0C48) ||
        this._charInRange(c, 0x0C4A, 0x0C4D) ||
        this._charInRange(c, 0x0C55, 0x0C56) ||
        this._charInRange(c, 0x0C82, 0x0C83) ||
        this._charInRange(c, 0x0CBE, 0x0CC4) ||
        this._charInRange(c, 0x0CC6, 0x0CC8) ||
        this._charInRange(c, 0x0CCA, 0x0CCD) ||
        this._charInRange(c, 0x0CD5, 0x0CD6) ||
        this._charInRange(c, 0x0D02, 0x0D03) ||
        this._charInRange(c, 0x0D3E, 0x0D43) ||
        this._charInRange(c, 0x0D46, 0x0D48) ||
        this._charInRange(c, 0x0D4A, 0x0D4D) ||
        c == 0x0D57 ||
        c == 0x0E31 ||
        this._charInRange(c, 0x0E34, 0x0E3A) ||
        this._charInRange(c, 0x0E47, 0x0E4E) ||
        c == 0x0EB1 ||
        this._charInRange(c, 0x0EB4, 0x0EB9) ||
        this._charInRange(c, 0x0EBB, 0x0EBC) ||
        this._charInRange(c, 0x0EC8, 0x0ECD) ||
        this._charInRange(c, 0x0F18, 0x0F19) ||
        c == 0x0F35 ||
        c == 0x0F37 ||
        c == 0x0F39 ||
        c == 0x0F3E ||
        c == 0x0F3F ||
        this._charInRange(c, 0x0F71, 0x0F84) ||
        this._charInRange(c, 0x0F86, 0x0F8B) ||
        this._charInRange(c, 0x0F90, 0x0F95) ||
        c == 0x0F97 ||
        this._charInRange(c, 0x0F99, 0x0FAD) ||
        this._charInRange(c, 0x0FB1, 0x0FB7) ||
        c == 0x0FB9 ||
        this._charInRange(c, 0x20D0, 0x20DC) ||
        c == 0x20E1 ||
        this._charInRange(c, 0x302A, 0x302F) ||
        c == 0x3099 ||
        c == 0x309A;
    }

    /// <summary>
    /// Determines Whether This is a Valid Digit Character
    /// </summary>
    /// <param name="c">character to analyze</param>
    /// <returns>True if Valid</returns>
    private bool IsDigit(char c)
    {
      return
        this._isAsciiDigit(c) ||
        this._isNonAsciiDigit(c);
    }

    /// <summary>
    /// Determines Whether This is a Valid ASCII Digit Character
    /// </summary>
    /// <param name="c">character to analyze</param>
    /// <returns>True if Valid</returns>
    private bool _isAsciiDigit(char c)
    {
      return
        this._charInRange(c, 0x0030, 0x0039);
    }

    /// <summary>
    /// Determines Whether This is a Valid Non-ASCII Digit Character
    /// </summary>
    /// <param name="c">character to analyze</param>
    /// <returns>True if Valid</returns>
    private bool _isNonAsciiDigit(char c)
    {
      return
        this._charInRange(c, 0x0660, 0x0669) ||
        this._charInRange(c, 0x06F0, 0x06F9) ||
        this._charInRange(c, 0x0966, 0x096F) ||
        this._charInRange(c, 0x09E6, 0x09EF) ||
        this._charInRange(c, 0x0A66, 0x0A6F) ||
        this._charInRange(c, 0x0AE6, 0x0AEF) ||
        this._charInRange(c, 0x0B66, 0x0B6F) ||
        this._charInRange(c, 0x0BE7, 0x0BEF) ||
        this._charInRange(c, 0x0C66, 0x0C6F) ||
        this._charInRange(c, 0x0CE6, 0x0CEF) ||
        this._charInRange(c, 0x0D66, 0x0D6F) ||
        this._charInRange(c, 0x0E50, 0x0E59) ||
        this._charInRange(c, 0x0ED0, 0x0ED9) ||
        this._charInRange(c, 0x0F20, 0x0F29);
    }

    /// <summary>
    /// Determines Whether This is a Valid Extender Character
    /// </summary>
    /// <param name="c">character to analyze</param>
    /// <returns>True if Valid</returns>
    private bool IsExtender(char c)
    {
      return
        c == 0x00B7 ||
        c == 0x02D0 ||
        c == 0x02D1 ||
        c == 0x0387 ||
        c == 0x0640 ||
        c == 0x0E46 ||
        c == 0x0EC6 ||
        c == 0x3005 ||
        this._charInRange(c, 0x3031, 0x3035) ||
        this._charInRange(c, 0x309D, 0x309E) ||
        this._charInRange(c, 0x30FC, 0x30FE);
    }

    /// <summary>
    /// Determines Whether This is Character is is the specified hex range 
    /// </summary>
    /// <param name="c">character to analyze</param>
    /// <param name="start">Beginning DEC Value</param>
    /// <param name="end">Ending DEC Value</param>
    /// <returns>True if Valid</returns>
    private bool _charInRange(char c, int start, int end)
    {
      return c >= start && c <= end;
    }

    #endregion
  }
}
