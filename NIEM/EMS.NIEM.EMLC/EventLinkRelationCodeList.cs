//-----------------------------------------------------------------------
// <copyright file="EventLinkRelationCodeList.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

namespace EMS.NIEM.EMLC
{
  /// <summary>
  /// Code list for event link relations or types
  /// </summary>
  public enum EventLinkRelationCodeList
  {
    /// <summary>
    /// THE LINKED OBJECT IS THE PARENT OF THIS OBJECT.
    /// </summary>
    PARENT,

    /// <summary>
    /// THE LINKED OBJECT IS THE PRODUCER OF THIS OBJECT.
    /// </summary>
    PARENT_PRODUCER,

    /// <summary>
    /// THE LINKED OBJECT IS THE OWNER OF THIS OBJECT.
    /// </summary>
    PARENT_OWNER,

    /// <summary>
    /// THE LINKED OBJECT IS THE MANAGER OF THIS OBJECT.
    /// </summary>
    PARENT_MANAGER,

    /// <summary>
    /// THE LINKED OBJECT IS THE LEADER (COMMANDER) OF THIS OBJECT.
    /// </summary>
    PARENT_LEADER,

    /// <summary>
    /// THE LINKED OBJECT IS THE SOURCE OF THIS OBJECT.
    /// </summary>
    PARENT_SOURCE,

    /// <summary>
    /// THE LINKED OBJECT IS THE TASKING THAT ELICITED THIS OBJECT.
    /// </summary>
    PARENT_TASKING,

    /// <summary>
    /// THE LINKED OBJECT IS A CHILD OF THIS OBJECT.
    /// </summary>
    CHILD,

    /// <summary>
    /// THE LINKED OBJECT IS A CORRELATED ELEMENT OF THIS OBJECT.
    /// </summary>
    CHILD_CORRELATED,

    /// <summary>
    /// THE LINKED OBJECT IS A FUSED ELEMENT OF THIS OBJECT.
    /// </summary>
    CHILD_FUSED,

    /// <summary>
    /// THE LINKED OBJECT IS AN ALTERNATE ELEMENT OF THIS OBJECT.
    /// </summary>
    CHILD_ALTERNATE,

    /// <summary>
    /// THE LINKED OBJECT IS A COMPOSITE ELEMENT OF THIS OBJECT.
    /// </summary>
    CHILD_COMPOSITE,

    /// <summary>
    /// THE LINKED OBJECT IS A REFINEMENT OF THIS OBJECT.
    /// </summary>
    REFINEMENT,

    /// <summary>
    /// THE LINKED OBJECT IS AN AMPLIFICATION OF THIS OBJECT.
    /// </summary>
    REFINEMENT_AMPLIFICATION,

    /// <summary>
    /// THE LINKED OBJECT IS A URL FOR A RESOURCE THAT IS A REFINEMENT OF THIS OBJECT.
    /// </summary>
    REFINEMENT_URL,

    /// <summary>
    /// THE LINKED OBJECT IS A TASKING FROM THIS OBJECT.
    /// </summary>
    TASKING,

    /// <summary>
    /// THE LINKED OBJECT IS AN OBJECT OF A TASKING FROM THIS OBJECT.
    /// </summary>
    TASKING_OBJECT,

    /// <summary>
    /// THE LINKED OBJECT IS AN INDIRECT OBJECT OF A TASKING FROM THIS OBJECT.
    /// </summary>
    TASKING_INDIRECT,

    /// <summary>
    /// THE LINKED OBJECT IS A SUBJECT OF A TASKING FROM THIS OBJECT.
    /// </summary>
    TASKING_SUBJECT,

    /// <summary>
    /// THE LINKED OBJECT IS AT THIS OBJECT.
    /// </summary>
    TASKING_PREPOSITION_AT,

    /// <summary>
    /// THE LINKED OBJECT IS BY THIS OBJECT.
    /// </summary>
    TASKING_PREPOSITION_BY,

    /// <summary>
    /// THE LINKED OBJECT IS WITH THIS OBJECT.
    /// </summary>
    TASKING_PREPOSITION_WITH,

    /// <summary>
    /// THE LINKED OBJECT IS FROM THIS OBJECT.
    /// </summary>
    TASKING_PREPOSITION_FROM,

    /// <summary>
    /// THE LINKED OBJECT IS REGARDING THIS OBJECT.
    /// </summary>
    TASKING_PREPOSITION_REGARDING,

    /// <summary>
    /// THE LINKED OBJECT IS VIA THIS OBJECT.
    /// </summary>
    TASKING_PREPOSITION_VIA
  }
}
