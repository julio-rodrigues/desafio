using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Web.Models {
    public class ProductViewModel {
        public ProductViewModel() {
            ProductId = Guid.NewGuid();
        }
        
        [Key]
        public Guid ProductId { get; set; }

        [MaxLength(100, ErrorMessage = "Esse campo deve ter ate 100 caracteres.")]
        [Required]
        [DisplayName("Nome")]
        public string Name { get; set; }

        public bool Ativo { get; set; }
    }
}