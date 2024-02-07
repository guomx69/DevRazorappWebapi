public class DateBase{ 
    public DateTime createdUtcDate { get; set; }
    public DateTime updatedUtcDate { get; set; }    

    public DateBase(){
            this.createdUtcDate=DateTime.UtcNow;
            this.updatedUtcDate=DateTime.UtcNow;

           // System.Console.WriteLine("DateBase called, Result::"+this.createdUtcDate);
        }
}