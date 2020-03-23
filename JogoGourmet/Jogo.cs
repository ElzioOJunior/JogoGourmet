using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace JogoGournet
{
    public class Jogo
    {

        private List<Pergunta> _listaPerguntas;

        public void Iniciar()
        {
            //Cria uma lista com as perguntas
            MontarPergunta();

            while (MessageBox.Show("Deixe me prever o prato que mais gosta!", "Sou seu garçom virtual...", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                //Inicio do jogo
                Perguntar(_listaPerguntas);
            }
            
        }

        private void Perguntar(List<Pergunta> perguntas)
        {
            var pergunta = "O prato que voce pensou é";

            //percorre as perguntas existentes
            for (int index = 0; index < perguntas.Count; index++)
            {
                //identifica a pergunta atual
                var perguntaAtual = perguntas[index];

                //analisa a resposta do usuário. Caso SIM, decide se acertou ou se deve continuar a perguntar. Se NÃO, abre a interação om o usuário para inserir um novo prato 
                if (MessageBox.Show($"{pergunta} {perguntaAtual.Nome} ?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    AnalisarResposta(perguntaAtual);
                    break;

                }
                else if ((index + 1) == perguntas.Count)
                {
                    //interação com as 2 perguntas necessárias e adição na lista de perguntas
                    var primeiraPerguntaDoUsuario = Interaction.InputBox("Desisto", "Qual prato você pensou ?");
                    string segundaPerguntaDoUsuario = Interaction.InputBox("Complete", $"{primeiraPerguntaDoUsuario ?? "null"} é _______ mas {perguntas[index].Nome} não.");
                    AdicionarPerguntaDoUsuario(index, perguntas, primeiraPerguntaDoUsuario, segundaPerguntaDoUsuario);

                    break;
                }
            }
        }

        private void AnalisarResposta(Pergunta pergunta)
        {
            //se não existe pergunta vinculada a pergunta atual, então acertou, senão pergunta novamente com a pergunta vinculada
            if (!pergunta.PerguntaVinculada.Any())
                MessageBox.Show("Acertei de Novo");
            else
                Perguntar(pergunta.PerguntaVinculada);

        }

        private void AdicionarPerguntaDoUsuario(int index, List<Pergunta> perguntas, string primeiraPerguntaDoUsuario, string segundaPerguntaDoUsuario)
        {
            //adiciona interação do usuário na lista de perguntas e vincula a primeira pergunta
            var perguntaDoUsuario = new Pergunta() { Nome = segundaPerguntaDoUsuario ?? "null" };
            perguntaDoUsuario.PerguntaVinculada.Add(new Pergunta() { Nome = primeiraPerguntaDoUsuario ?? "null" });

            //altera a ordem das perguntas
            var perguntaIndex = perguntas[index];
            perguntas[index] = perguntaDoUsuario;
            perguntas.Add(perguntaIndex);

        }

        private void MontarPergunta()
        {
            _listaPerguntas = new List<Pergunta>();

            var massa = new Pergunta(){ Nome = "Massa" };
            var lasanha = new Pergunta() { Nome = "Lasanha" };
            var bolo = new Pergunta() { Nome = "Bolo de Chocolate" };

            //adiciona a lasanha como pergunta vinculada
            massa.PerguntaVinculada.Add(lasanha);
            _listaPerguntas.Add(massa);
            _listaPerguntas.Add(bolo);

        }

    }
}
