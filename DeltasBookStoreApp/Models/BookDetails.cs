using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DeltasBookStoreApp.Models
{
    public class BookDetails
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Book Name")]
        [Required(ErrorMessage = "Book Name can't be empty")]
        public string BookName { get; set; } = null!;

        [DisplayName("Author Name")]
        [Required(ErrorMessage = "Author Name can't be empty")]
        public string AuthorName { get; set; } = null!;

        [DisplayName("Publisher Name")]
        [Required(ErrorMessage = "Publisher Name can't be empty")]
        public string PublisherName { get; set; } = null!;

        [DisplayName("Published Date")]
        [Required(ErrorMessage = "Published Date can't be empty")]
        [DataType(DataType.Date, ErrorMessage = "Published Date is not valid")]
        public string PublishedDate { get; set; } = null!;

        [DisplayName("Price")]
        [Required(ErrorMessage = "Price can't be empty")]
        [DataType(DataType.Currency, ErrorMessage = "Price is not valid")]
        [Range(0.01, 10000, ErrorMessage = "Price must be greater than 0 and lesser than 10000")]
        public float Price { get; set; }

        [DisplayName("Book Description")]
        public string BookDescription { get; set; } = null!;

        [DisplayName("Total Copies Sold")]
        [Required(ErrorMessage = "Total Copies Sold can't be empty")]
        [DataType(DataType.Text)]
        public int TotalCopiesSold { get; set; }

        [DefaultValue("Y")]
        public string IsActive { get; set; } = "Y";
    }
}
