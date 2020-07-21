using System.Runtime.Serialization;

namespace SysMecanica
{
    [DataContract]
    public class Produto
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public string Descricao { get; set; }
        [DataMember]
        public double Preco { get; set; }
        
    }
}
