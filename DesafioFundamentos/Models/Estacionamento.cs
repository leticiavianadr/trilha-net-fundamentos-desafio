using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private List<string> veiculos;

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            this.veiculos = new List<string>();
        }

        public void AdicionarVeiculo()
        {
            Console.Write("Digite a placa do veículo para estacionar: ");
            string placa = Console.ReadLine()?.Trim();

            if (!string.IsNullOrEmpty(placa))
            {
                veiculos.Add(placa);
            }
            else
            {
                Console.WriteLine("Placa inválida. Digite a placa do veículo que você deseja estacionar.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.Write("Digite a placa do veículo para remover: ");
            string placa = Console.ReadLine()?.Trim();

            if (veiculos.Any(x => x.ToUpperInvariant() == placa.ToUpperInvariant()))
            {
                Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                if (int.TryParse(Console.ReadLine(), out int horas) && horas >= 0)
                {
                    decimal valorTotal = precoInicial + precoPorHora * horas;
                    veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Quantidade de horas inválida.");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
