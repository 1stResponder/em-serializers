﻿// ———————————————————————–
// <copyright file="ValidationException.cs" company="EDXLSharp">
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

namespace EDXLSharp
{
  /// <summary>
  /// Represents an error validating a portion of a message
  /// </summary>
  public class ValidationException : Exception
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationException" /> class
    /// </summary>
    public ValidationException() : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationException" /> class with a specified error message 
    /// </summary>
    /// <param name="message">string specifying the error message</param>
    public ValidationException(string message) : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception
    /// </summary>
    /// <param name="message">string specifying the error message</param>
    /// <param name="innerException">Reference to an inner exception causing this message</param>
    public ValidationException(string message, Exception innerException) : base(message, innerException)
    {
    }
  }
}