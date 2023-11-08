namespace Calculadora.Service
{
    public class Calculadora
    {
        private List<string> _historico;

        public Calculadora()
        {
            _historico = new List<string>();
        }

        public int Somar(int n1, int n2)
        {
            AddHistorico("somar", n1, n2);
            return n1 + n2;
        }

        public int Subtrair(int n1, int n2)
        {
            AddHistorico("subtrair", n1, n2);
            return n1 - n2;
        }

        public int Multiplicar(int n1, int n2)
        {
            AddHistorico("multiplicar", n1, n2);
            return n1 * n2;
        }

        public int Dividir(int n1, int n2)
        {
            AddHistorico("dividir", n1, n2);
            return n1 / n2;
        }

        private void AddHistorico(string op, int op1, int op2)
        {
            _historico.Insert(0, $"{op}: {op1},{op2}");
        }

        public List<string> Historico()
        {
            return this._historico;
        }
    }
}
