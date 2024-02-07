
using NetTopologySuite.Geometries;
//using Newtonsoft.Json;
//using GeoJSON.Net.Converters;
//using Newtonsoft.Json;

namespace ApiServer.Models;
public class PrayerMd:DateBase  
    {  
        public int id { get; set; }  
       // public int userId { get; set; }  
        public string address { get; set; } =null!; 
        public string name {get;set;}
    
        public string content {get;set;}
  
        
        public Point point{get;set;}
        public List<string> imageUrls { get; set; }
    }  