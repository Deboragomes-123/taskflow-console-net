using System;
using TaskFlow.Console;

var manager = new TaskManager();
bool running = true;

while (running)
{
    System.Console.WriteLine("\n=== TaskFlow - Gerenciador de Tarefas ===");
    System.Console.WriteLine("1. Adicionar Tarefa");
    System.Console.WriteLine("2. Listar Tarefas");
    System.Console.WriteLine("3. Concluir Tarefa");
    System.Console.WriteLine("4. Sair");
    System.Console.Write("Escolha uma opção: ");

    string? choice = System.Console.ReadLine();

    switch (choice)
    {
        case "1":
            System.Console.Write("Digite o título da tarefa: ");
            string? title = System.Console.ReadLine();
            try
            {
                if (title != null)
                {
                    manager.AddTask(title);
                    System.Console.WriteLine("Tarefa adicionada com sucesso!");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Erro: {ex.Message}");
            }
            break;

        case "2":
            System.Console.WriteLine("\n--- Lista de Tarefas ---");
            if (!manager.Tasks.Any())
            {
                System.Console.WriteLine("Nenhuma tarefa registada.");
            }
            else
            {
                foreach (var t in manager.Tasks)
                {
                    string status = t.IsCompleted ? "[Concluída]" : "[Pendente]";
                    System.Console.WriteLine($"{status} ID: {t.Id} - {t.Title}");
                }
            }
            break;

        case "3":
            System.Console.Write("Digite o ID (Guid) da tarefa a concluir: ");
            string? inputId = System.Console.ReadLine();
            if (Guid.TryParse(inputId, out Guid id))
            {
                bool success = manager.CompleteTask(id);
                if (success)
                    System.Console.WriteLine("Tarefa marcada como concluída!");
                else
                    System.Console.WriteLine("Tarefa não encontrada.");
            }
            else
            {
                System.Console.WriteLine("ID inválido.");
            }
            break;

        case "4":
            running = false;
            System.Console.WriteLine("A sair...");
            break;

        default:
            System.Console.WriteLine("Opção inválida.");
            break;
    }
}