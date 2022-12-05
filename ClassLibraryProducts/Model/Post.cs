using System.ComponentModel.DataAnnotations;


namespace ClassLibraryProducts
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }

        //public DateFormat PostDate { get; set; }
        public string PostDate { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        
        public string Description { get; set; }

        public string AuthorFirstname { get; set; }

        public string AuthorLastname { get; set;}


    }
}
