using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JogoGournet
{
    public class Pergunta
    {
        public Pergunta()
        {
            PerguntaVinculada = new List<Pergunta>();
        }
        public List<Pergunta> PerguntaVinculada { get; set; }
        public string Nome { get; set; }

    }

}
