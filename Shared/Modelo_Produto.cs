using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Desafio_CRUD.Shared
{
    
    public class Modelo_Produto
    {
        [Required (ErrorMessage = "ID é obrigatório")]
        public int ID { get; set; }
        [Required (ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }
        [Required (ErrorMessage = "Descrição é obrigatório")]
        public string Descricao { get; set; }
        [Required (ErrorMessage = "Valor é obrigatório")]
        public double Valor { get; set; }
    }
}