﻿using Desafio.Domain.Entities;
using Desafio.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Infra.Data.Repository {
    public class ClientRepository : BaseRepository<Client>{
        public bool NameExist(string Name, Guid ClientId) {
            return CountWhere(c => c.Name.ToUpper() == Name.ToUpper() && c.ClientId != ClientId) == 0 ? false : true;
        }
    }
}
