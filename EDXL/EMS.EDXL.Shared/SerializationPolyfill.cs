namespace System
{
  /// <summary>
  /// Represents a SerializableAttribute
  /// </summary>
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Delegate)]
  public class SerializableAttribute : Attribute
  {
  }
}
