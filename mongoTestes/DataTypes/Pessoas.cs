using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoRepository;

namespace mongoTestes.DataTypes
{
    [CollectionName("Pessoas")]
   public class Pessoas : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DtNasc { get; set; }
        public List<Enderecos> Enderecos { get; set; }

        public Pessoas()
        {
            this.Enderecos = new List<DataTypes.Enderecos>();
        }
    }
}
