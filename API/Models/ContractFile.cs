using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("ContractFiles")]
    public class ContractFile
    {
        public int ContractFileId { get; set; }
        public string Url { get; set; }
        public string PublicID  {get; set;}

    }
}