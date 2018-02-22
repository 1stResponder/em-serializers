/*-----------------------------------------------------------------------
  Limitations of NIEMSharp Serializer:
   Most of these limitations have to do with how XML gets converted to JSON.  
   
   1] Json will treat empty elements as null when converting.  
       ex: <myEl /> --> "myEl": null 
   This is a problem with objects specifically because we have objects that are required by other elements but can be empty.  In this 
   scenario, the program will throw an error since a required object is null.  What we need instead, is for empty elements which are 
   objects to be treated as empty and not null.
   
       ex: <myEl /> --> "myEl": {}
       
   To make this happen, I created a function that goes through the XML, node by node, and gets the name of each node.  If that name is 
   one that I specified as a valid empty object then the function adds an attribute which contains that nodes type and then continues 
   on.  This attribute makes it clear to the JSON that the element is an object so the JSON will convert it correctly.   
    
       ex: <myEL /> --> <myEl p12:jsontype="NIEMSharp.MutualAidRequest.AidResponding.AidRespondingContactInformation, NIEMSharp" />
       
   This works but it does require manually specifying each object that can be empty.  Right now, these objects are only specified for 
   NIEMSharp so when using the other libraries the issue will still exist.  It should not throw errors (since null elements are 
   ignored) but it will not include them when deserializing.  
   
   
   2] Json will treat one element arrays as strings when converting.  This problem makes sense since there is no way for JSON to know 
   that a single element is an array without an attribute (which is not necessary for the schema or XML).  In this scenario, the 
   program will throw an error since a List/Array != string.  
    
       ex: <myEL>one</myEL> --> "myEL": "one"
       
   To fix this, I did the same as above except I specified names of elements that should be lists/Arrays. 
   
       ex: <myEL>one</myEL> --> <myEl p12:Array="true">one</myEL>
       <myEl p12:Array="true">one</myEL> --> "myEl": ["one"]
       
   Like before, I had to manually enter all the names of elements that are lists so this will not work with other libraries.  
   This means that deserializing single item lists from the other libraries can cause fatal errors unless they have this 
   attribute.
  
  3] Child elements from other libraries have no namespace as far as JSON is concerned.  In order to prevent errors I had to 
  manually remove any default namespaces they may of been given.  Also, if this kind of element has a namespace prefix it will be 
  ignored since the JSON will convert the element name to "prefix--name" and that element will not exist in the other library.  
  
  4] Attributes must be manually specified in the libraries in which they come from.  Otherwise, they will be turned into 
  normal elements during serialization and ignored during deserialization.  You can specify an attribute by adding this above 
  the class member:

    [JsonProperty(PropertyName = "@myName")]

   Where myName is the element's name and the @ tells JSON.net it's an attribute.  

  5] Be cautious when renaming elements or changing namespaces/namespace prefixes.  Many objects/members had to be hard coded during the JSON serialization/deserialization.  Mainly dynamic members and the objects that substitute them.  
-----------------------------------------------------------------------*/