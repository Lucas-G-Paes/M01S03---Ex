using ProjetoEstacionamento;

string opcao;

List<Carro> carros = new List<Carro>();

do
{
  Console.WriteLine("Bem vindos ao Estacionamento PARE AQUI.");
  Console.WriteLine("1 - Cadastrar Carro.");
  Console.WriteLine("2 - Registrar Entrada.");
  Console.WriteLine("3 - Registrar Saida.");
  Console.WriteLine("4 - Consultar Histórico");
  Console.WriteLine("5 - Sair");
  
  opcao = Console.ReadLine();

  if(opcao == "1")
  {
    CadastrarCarro();
  }

  if(opcao == "2")
  {
    RegistrarEntrada();
  }

  if(opcao == "3")
  {
    RegistrarSaida();
  }

  if (opcao == "4")
  {
    ConsultarHistorico();
  }

  Console.WriteLine("Tecle Enter para continuar");
  Console.ReadLine();
  
} while(opcao != "5");


void CadastrarCarro()
{
    Carro carro = new Carro();

    Console.WriteLine("Informe a Marca do Carro:");
    carro.Marca = Console.ReadLine();

    Console.WriteLine("Informe o Modelo do Carro:");
    carro.Modelo = Console.ReadLine();

    Console.WriteLine("Informe a Cor do Carro:");
    carro.Cor = Console.ReadLine();

    Console.WriteLine("Informe a Placa do Carro:");
    carro.Placa = Console.ReadLine();

    carros.Add(carro);

}
Carro ObterCarro(string placa)
{
  foreach(var carro in carros)
  {
    if (placa == carro.Placa)
    {
      return carro;
    }
  }
  return null;
}

void GerarTicket()
{
  Console.WriteLine("Qual a placa do carro?");
  string placa = Console.ReadLine();

  var carro = ObterCarro(placa);
  if(carro == null)
  {
     Console.WriteLine("Carro não encontrado");
     return;
  }
  foreach(var ticket in carro.Tickets)
  {
    if(ticket.Ativo == true)
    {
      Console.WriteLine("Carro já está no estacionamento.");
      return;
    }
  }

  Ticket ticketNovo = new Ticket();
  carro.Tickets.Add(ticketNovo);
  Console.WriteLine("Ticket Criado");

}


void FecharTicket()
{
  Console.WriteLine("Qual a placa do carro?");
  string placa = Console.ReadLine();

  var carro = ObterCarro(placa);
  if(carro == null)
  {
    Console.WriteLine("Carro não encontrado");
    return;
  }
  Ticket ticketAberto = null;
    foreach(var ticket in carro.Tickets)
    {
      if(ticket.Ativo == true)
      {
        ticketAberto = ticket;
      }
    }
    if(ticketAberto == null)
    {
      Console.WriteLine("Este carro não possui ticket aberto.");
      return;
    }

    ticketAberto.FecharTicket();
}

void Historico()
{
  Console.WriteLine("Qual a placa do Veículo");
  string placa = Console.ReadLine();

  var carro = ObterCarro(placa);
  if(carro == null)
  {
    Console.WriteLine("Carro não cadastrado"); 
    return; 
  }

  Console.WriteLine("-------Entrada-------|--------Saída--------|--Ativo--|--Valor--|");

  foreach(var ticket in carro.Tickets)
  {
    if (ticket.Ativo == true)
    {
      Console.WriteLine($"{ticket.Entrada} | -------------------- | { ticket.Ativo.ToString()} | R$00,00");
    }
    else 
    {
      Console.WriteLine($"{ticket.Entrada}  | {ticket.Saida} | { ticket.Ativo.ToString()} | R${ticket.ValorPagar()}");
    }
  }
}


void RegistrarEntrada()
{
  GerarTicket();
}

void RegistrarSaida()
{
  FecharTicket();
}

void ConsultarHistorico()
{
  Historico();
}



