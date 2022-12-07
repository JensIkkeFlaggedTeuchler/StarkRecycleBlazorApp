using System.ComponentModel.DataAnnotations;


// Charlie - Ændret range 07/12/22
namespace ClassLibraryProducts
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }

        //public DateFormat PostDate { get; set; }
        public string PostDate { get; set; }

        [StringLength(10000, MinimumLength = 1, ErrorMessage = "Must include a title between 1 - 10000 Characters")]
        public string Title { get; set; }
        [StringLength(50, MinimumLength =1,ErrorMessage ="Must include a Description between 1 - 50 Characters")]
        public string Description { get; set; }
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Must include a Firstname between 1 - 20 Characters")]
        public string AuthorFirstname { get; set; }
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Must include a Lastname between 1 - 20 Characters")]
        public string AuthorLastname { get; set;}


    }
}
