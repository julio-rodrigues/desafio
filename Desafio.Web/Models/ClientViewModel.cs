using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Web.Models {
    public class ClientViewModel {
        public ClientViewModel() {
            ClientId = Guid.NewGuid();
        }
        [Key]
        public Guid ClientId { get; set; }

        [MaxLength(100, ErrorMessage = "Esse campo deve ter ate 100 caracteres.")]
        [Required]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [MaxLength(100, ErrorMessage = "Esse campo deve ter ate 100 caracteres.")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [MaxLength(11, ErrorMessage = "Esse campo deve ter ate 11 caracteres.")]
        [Required]
        [DisplayName("CPF")]
        public string CPF { get; set; }

    }
}