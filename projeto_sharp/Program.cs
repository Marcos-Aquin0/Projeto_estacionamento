using System.ComponentModel.Design;
using System.Net;
using System.Reflection;
using estaciona.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal preco_inicial = 0;
decimal preco_hora = 0;
int vagas;
decimal caixa = 0;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                  "Digite o preço inicial:");
preco_inicial = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Agora digite o preço por hora:");
preco_hora = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Agora digite quantas vagas o estacionamento possui:");
vagas = Convert.ToInt32(Console.ReadLine());

Estacionamento parking = new Estacionamento(preco_inicial, preco_hora, vagas, caixa);

Console.WriteLine("Seja bem-vindo(a)!");
int flag = 0;

while(flag >=0){
    switch(flag){
        case 0:
            parking.Informacoes();
            break;
        case 1:
            parking.Cadastrar_carro();
            break;
        case 2:
            parking.Remover_carro();
            break;
        case 3:
            parking.Listar_carro();
            break;
        default: 
            break;
    }
    if(flag == 4){
        parking.Encerrar();
        break;
    }
    parking.menu_estacionamento();
    flag = Convert.ToInt32(Console.ReadLine());
}