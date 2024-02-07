namespace ApiServer.Models;
public class Post
{
    public int Id { get; set; }
    public List<Tag> Tags { get; } =  new List<Tag>();
}

public class Tag
{
    public int Id { get; set; }
    public List<Post> Posts { get; } = new List<Post>();
}