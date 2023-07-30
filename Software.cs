using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW_Prova
{
    internal class Software
    {
        #region Propriedades Forma Clássica
        private string _nome;
        public string GetNome()
        {
            if (_nome.Length > 20)
            {
                return _nome.Substring(0,20);
            }
            return _nome;
        }
        public void SetNome(string nome)
        {
            if (!String.IsNullOrEmpty(nome))
            {
                _nome = nome;
            }
            else
                throw new Exception("Nome deve ser inserido");
        }

        private int _id;
        public int GetID()
        {
            return _id;
        }
        public void SetID(int id)
        {
            try
            {
                if (id > 0)
                {
                    _id = id;
                }
                else
                {
                    throw new Exception("id deve ser positivo");
                }
            }
            catch
            {
                throw new Exception("ID deve ser numérico inteiro");
            }
        }

        private string _desenvolvedora;
        public string GetDesenvolvedora()
        {
            if (!String.IsNullOrEmpty(_desenvolvedora))
            {
                return _desenvolvedora;
            }
            else
            {
                return "Vazio";
            }
        }

        public void SetDesenvolvedora(string desenvolvedora)
        {
            _desenvolvedora = desenvolvedora;
        }

        private string _descricao;
        public string GetDescricao()
        {
            if (!String.IsNullOrEmpty(_descricao))
            {
                return _descricao;
            }
            else
            {
                return "Vazio";
            }
        }
        public void SetDescricao(string descricao)
        {
            _descricao = descricao;
        }

        private string _enderecoIcone;
        public string GetEnderecoIcone()
        {
            return _enderecoIcone;
        }
        public void SetEnderecoIcone(string endereco)
        {
            if (!String.IsNullOrEmpty(endereco))
            {
                _enderecoIcone = endereco;
            }
            else
                throw new Exception("Endereço deve ser inserido");
        }

        private double _ram;
        public double GetRam()
        {
            return _ram;
        }
        public void SetRam(double ram)
        {
            try
            {
                if (ram > 0)
                {
                    _ram = ram;
                }
                else
                {
                    throw new Exception("Ram não pode ser negativa");
                }
            }
            catch
            {
                throw new Exception("Ram deve ser numérico");
            }
        }
        #endregion

        #region Construtor
        public Software(string nome, int id, string descricao, string dev, string enderecoIcone, double ram)
        {
            SetNome(nome);
            SetID(id);
            SetDescricao(descricao);
            SetDesenvolvedora(dev);
            SetEnderecoIcone(enderecoIcone);
            SetRam(ram);
        }
        #endregion

        #region Método
        public List<string> MostrarEspecificacoes()
        {
            List<string> specs = new List<string>();
            specs.Add(GetNome());
            specs.Add(GetID().ToString());
            specs.Add(GetDescricao());
            specs.Add(GetDesenvolvedora());
            specs.Add(GetRam().ToString());

            return specs;
        }
        #endregion
    }
}
