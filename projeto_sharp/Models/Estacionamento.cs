using System.ComponentModel.Design;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace estaciona.Models
{
    public class Estacionamento
    {
        private decimal preco_inicial { get; set; }
        private decimal preco_hora { get; set; }
        private int vagas { get; set; }
        private decimal caixa { get; set; }
        
        // constructor para poder receber os valores obrigatórios
        public Estacionamento(decimal preco_inicial, decimal preco_hora, int vagas, decimal caixa){
            this.preco_inicial = preco_inicial;
            this.preco_hora = preco_hora;
            this.vagas = vagas;
            this.caixa = caixa;
        }

        public void menu_estacionamento(){
            Console.WriteLine(@"Digite a opção desejada:
                                0 - Informações
                                1 - Cadastrar carro
                                2 - Remover carro
                                3 - Listar carros no estacionamento
                                4 - Encerrar programa
            ");
        }
        public void Informacoes(){
            Console.WriteLine(@$"Os preços do estacionamento são:
            preço inicial: R${this.preco_inicial} reais
            preço por hora: R${this.preco_hora} reais
            {this.vagas} vagas disponíveis"
            );
        }
        
        private List<Dictionary<string, string>> lista_carros = new List<Dictionary<string, string>>();
        public void Cadastrar_carro(){
            if (this.vagas == 0){
                Console.WriteLine("Estacionamento cheio, volte mais tarde!");
            }
            else{
                Dictionary<string, string> carro = new Dictionary<string, string>();
                
                Console.Write("Digite a placa do carro: ");
                carro["placa"] = Console.ReadLine() ?? "abc";
                while (carro["placa"] == "abc"){
                    carro["placa"] = Console.ReadLine() ?? "abc"; 
                };

                Console.Write("Informe o modelo do carro: ");
                carro["modelo"] = Console.ReadLine() ?? "abc";
                while (carro["modelo"] == "abc"){
                    carro["modelo"] = Console.ReadLine() ?? "abc"; 
                };
                lista_carros.Add(carro);
                this.vagas--;
            }
        }
        public void Remover_carro(){
            Console.WriteLine("Informe a placa do carro que você deseja retirar: ");
            string? remove = Console.ReadLine();
            if(remove == null){
                Console.WriteLine("placa não foi informada");
                return;
            }
            Console.WriteLine("Informe quanto tempo ele ficou estacionado: ");
            int tempo = Convert.ToInt32(Console.ReadLine());
            
            foreach(var carro in lista_carros){
                if (carro["placa"] == remove){
                    decimal total = 0;
                    if (tempo > 1) {
                        total = this.preco_inicial + (tempo-1) * this.preco_hora;
                    }
                    else {
                        total = this.preco_inicial; 
                    }
                    Console.WriteLine($"O carro de placa {remove} ficou {tempo} horas e pagou {total} reais");
                    lista_carros.Remove(carro);
                    this.vagas++;
                    this.caixa += total;
                    break;
                }
            }
            Console.WriteLine();
            
        }
        public void Listar_carro(){
            foreach (var carro in lista_carros)
        {
            Console.WriteLine("Carro:");
            foreach (var item in carro)
            {
                Console.WriteLine($"  {item.Key}: {item.Value}");
            }
            Console.WriteLine(); 
        }
        }
        public void Encerrar(){
            Console.WriteLine($"Programa finalizado. O estacionamento conseguiu {this.caixa} reais");
        }
        
    }
}


