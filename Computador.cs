using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW_Prova
{
    internal class Computador
    {
		#region Propriedades C# Completa
		private int _id;
		public int ID
		{
			get { return _id; }
			set
			{
				try
				{
					_id = value;
				}
				catch
				{
					throw new Exception("id deve ser numérico inteiro");
				}
			}
		}

		private string _fabricante;
		public string Fabricante
		{
			get { return _fabricante; }
			set
			{
				if (!String.IsNullOrEmpty(value))
				{
					_fabricante = value;
				}
				else
					throw new Exception("Fabricante deve ser inserido");
			}
		}

		private string _modeloProcessador;
		public string ModeloProcessador
		{
			get { return _modeloProcessador; }
			set
			{
				if (!String.IsNullOrEmpty(value))
				{
					_modeloProcessador = value;
				}
				else
					throw new Exception("Modelo deve ser inserido");
			}
		}

		private double _qtMemoriaRam;
		public double QtMemoriaRam
		{
			get { return _qtMemoriaRam; }
			set
			{
				try
				{
					_qtMemoriaRam = value;
				}
				catch
				{
					throw new Exception("Memória deve ser numérico");
				}
			}
		}

		private double _ramDisponivel;
		public double RamDisponivel
		{
			get { return _ramDisponivel; }
			set
			{
				try
				{
					_ramDisponivel = value;
				}
				catch
				{
					throw new Exception("Memória deve ser numérico");
				}
			}
		}

		private double _tamanhoHD;

		public double TamanhoHD
		{
			get { return _tamanhoHD; }
			set
			{
				try
				{
					_tamanhoHD = value;

				}
				catch (Exception)
				{
					throw new Exception("Tamanho do HD deve ser numérico");
				}
			}
		}

		private bool _estado;
		public bool Estado
		{
			get
			{
				return _estado;
			}
			set
			{
				try
				{
					_estado = value;
				}
				catch (Exception)
				{
					throw new Exception("Tamanho do HD deve ser true ou false");
				}
			}
		}

		public Software softwareEmExecucao;
        #endregion

        #region Construtor	
        public Computador(int id, string fab, string model, double memoria, bool estado, double hd)
		{
			this.ID = id;
			this.Fabricante = fab;
			this.ModeloProcessador = model;
			this.QtMemoriaRam = memoria;
			this.TamanhoHD = hd;
			this.Estado = estado;
			this.softwareEmExecucao = null;
		}
        #endregion

        #region Métodos
        public void IniciarSoftware(Software software)
		{
			if (software != null)
			{
				softwareEmExecucao = software;
			}
		}

		public void PararSoftware()
		{
			if (softwareEmExecucao != null)
			{
				softwareEmExecucao = null;
			}
		}

		public void AlocarRam(double ramSoftware)
		{
			RamDisponivel = QtMemoriaRam - ramSoftware;
		}

		public void DesalocarRam()
		{
			RamDisponivel = QtMemoriaRam;
		}

		public string ChecarEstado()
		{
			if (Estado)
			{
				return "Ligado";
			}
			else
			{
				return "Desligado";
			}
		}

		public void Ligar_Desligar()
        {
            if (!Estado)
            {
				Estado = true;
            }
            else
            {
				Estado = false;
            }
        }

		public List<string> MostrarEspecificacoes()
		{
			List<string> specs = new List<string>();
			specs.Add(ID.ToString());
			specs.Add(Fabricante);
			specs.Add(ModeloProcessador);
			specs.Add(QtMemoriaRam.ToString());
			specs.Add(ChecarEstado());
			specs.Add(TamanhoHD.ToString());

			return specs;
		}
		#endregion
	}
}
