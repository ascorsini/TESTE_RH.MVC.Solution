using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TESTE_RH.MVC.Models
{
    public class PessoaViewModel
    {
        [Key]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public int PessoaID { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nacionalidade { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string CPF_MASK { get; set; }
        public string CEP { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string CEP_MASK { get; set; }
        public string Estado { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Telefone { get; set; }

        public List<PessoaViewModel> ListaPessoas { get; set; }
    }
}
