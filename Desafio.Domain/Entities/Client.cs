using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Entities {
    public class Client {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }

        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
