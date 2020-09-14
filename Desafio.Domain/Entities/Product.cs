using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Entities {
    public class Product {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public bool Ativo { get; set; }
    }
}
