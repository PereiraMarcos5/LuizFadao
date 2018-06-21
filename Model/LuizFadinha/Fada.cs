using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizFadinha
{
    public class Fada
    {
        //Nome
        //Familia
        //Cor
        //Cor Asa
        //TamanhoAsa
        //AsaQuebrada
        //é Mulher
        //faz Barulho
        //Elemento

        private string nome;
        private string familia;
        private string cor;
        private string corAsa;
        private decimal tamanhoAsa;
        private bool asaQuebrada;
        private bool eMulher;
        private bool fazBarulho;
        private string elemento;
        private string p1;
        private string p2;
        private string p3;
        private string p4;
        private string p5;
        private string p6;


        public string Nome
        {
            get { return nome; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Preencha alguma coisa");
                }

                if (value.Count() == 1)
                {
                    throw new Exception("Numero de caracteres deve ser no minímo 2");
                }

                nome = value;
            }
        }


        public string Familia
        {
            get { return familia; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Digite alguma coisa");
                }
                if (value.Count() == 2)
                {
                    throw new Exception("Numero de caracteres deve ser no minímo 3");
                }

                familia = value;
            }
        }

        public string Cor
        {
            get { return cor; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Digite alguma coisa");
                }

                if (value.Count() == 1)
                {
                    throw new Exception("Cor deve conter ao menos 2 caracteres");
                }


                cor = value;
            }
        }


        public string CorAsa
        {
            get { return corAsa; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Digite alguma coisa");
                }
                if (value.Count() == 1)
                {
                    throw new Exception("Cor da Asa deve conter ao menos 2 caracteres");
                }

                corAsa = value;
            }
        }







        public decimal TamanhoAsa
        {
            get { return tamanhoAsa; }
            set
            {
                if (value > 50)
                {
                    throw new Exception("Tamanho da Asa deve ser menor que 50 centímetros");
                }

                if (value < 2)
                {
                    throw new Exception("Tamanho da  Asa tem que ser maior que 2 centímetros");
                }

                tamanhoAsa = value;
            }
        }

        public bool AsaQuebrada
        {
            get
            {
                return asaQuebrada;
            }
            set
            {
                asaQuebrada = value;
            }
        }

        public bool EMulher
        {
            get
            {
                return eMulher;
            }
            set
            {
                eMulher = value;
            }

        }

        public bool FazBarulho
        {
            get { return fazBarulho; }
            set { fazBarulho = value; }
        }



        public string Elemento
        {
            get { return elemento; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Digite Algum Elemento");
                }

                if (value.Count() == 1)
                {
                    throw new Exception("Elemento deve conter ao menos 2 caracteres");
                }
                elemento = value;
            }
        }
        public Fada(string nome, string familia, string cor, string corAsa, decimal tamanhoAsa, bool asaQuebrada, bool eMulher, bool fazBarulho, string elemento)
        {
            Nome = nome;
            Familia = familia;
            Cor = cor;
            CorAsa = corAsa;
            TamanhoAsa = tamanhoAsa;
            Elemento = elemento;
        }

        public Fada(string nome, string familia, string cor)
        {
            Nome = nome;
            Familia = familia;
            Cor = cor;


        }

        public Fada(string p1, string p2, string p3, string p4, string p5, string p6)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
            this.p5 = p5;
            this.p6 = p6;
        }

    }
}