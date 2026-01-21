using restWithASPNET10Study.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace restWithASPNET10Study.Data.Dto
{

    public class BookDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public DateTime Launch_date { get; set; }
    }
}
