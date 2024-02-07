using NetTopologySuite.Geometries;

namespace ApiServer.Models;
public class City:DateBase 
    {  
       // public int userId { get; set; }  
        public string name { get; set; } =null!; 
        public bool? hasService {get;set;}
      
    }  
public class CityView:City  
    {  
      public string area{get;set;}
    }  
public class CityMd:City  
    {  
        public int Id { get; set; }  
       // public int userId { get; set; }  
       
        public MultiPolygon? area{get;set;}
    } 