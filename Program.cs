using System;
using UserManagement.Application;

namespace UserManagement.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var userService = new UserService();
            string option;

            do
            {
                Console.WriteLine("==========================");
                Console.WriteLine("  Gestão de Usuários  ");
                Console.WriteLine("==========================");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Adicionar usuário");
                Console.WriteLine("2 - Listar usuários");
                Console.WriteLine("3 - Atualizar usuário");
                Console.WriteLine("4 - Excluir usuário");
                Console.WriteLine("5 - Sair");
                Console.WriteLine("==========================");
                Console.Write("Opção: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("==========================");
                        Console.WriteLine("  Adicionar Novo Usuário  ");
                        Console.WriteLine("==========================");
                        Console.Write("Nome: ");
                        var name = Console.ReadLine();
                        Console.Write("Email: ");
                        var email = Console.ReadLine();

                        Console.Write("Confirmar adição do usuário? (s/n): ");
                        var confirmAdd = Console.ReadLine();
                        if (confirmAdd?.ToLower() == "s")
                        {
                            userService.CreateUser(name, email);
                            Console.WriteLine("\nUsuário adicionado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("\nOperação cancelada.");
                        }
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;


                    case "2":
                        var users = userService.GetAllUsers();
                        foreach (var user in users)
                        {
                            Console.WriteLine($"ID: {user.Id}, Nome: {user.Name}, Email: {user.Email}");
                        }
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("==========================");
                        Console.WriteLine("  Atualizar Usuário  ");
                        Console.WriteLine("==========================");
                        Console.Write("ID do usuário: ");
                        var idToUpdate = int.Parse(Console.ReadLine());
                        Console.Write("Novo Nome: ");
                        var newName = Console.ReadLine();
                        Console.Write("Novo Email: ");
                        var newEmail = Console.ReadLine();

                        Console.Write("Confirmar atualização do usuário? (s/n): ");
                        var confirmUpdate = Console.ReadLine();
                        if (confirmUpdate?.ToLower() == "s")
                        {
                            userService.UpdateUser(idToUpdate, newName, newEmail);
                            Console.WriteLine("\nUsuário atualizado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("\nOperação cancelada.");
                        }
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("==========================");
                        Console.WriteLine("  Excluir Usuário  ");
                        Console.WriteLine("==========================");
                        Console.Write("ID do usuário: ");
                        var idToDelete = int.Parse(Console.ReadLine());

                        Console.Write("Tem certeza que deseja excluir este usuário? (s/n): ");
                        var confirmDelete = Console.ReadLine();
                        if (confirmDelete?.ToLower() == "s")
                        {
                            userService.DeleteUser(idToDelete);
                            Console.WriteLine("\nUsuário excluído com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("\nOperação cancelada.");
                        }
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "5":
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

            } while (option != "5");
        }
    }
}
