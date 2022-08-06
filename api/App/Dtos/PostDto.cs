namespace api.App.Dtos
{
    public class PostDto
    {
        public string Content { get; set; }
        public string UserName { get; set; }
        public string Url { get; set; }
        public string ReactionsQuantity { get; set; }
        public string CommentsQuantity { get; set; }
    }
}