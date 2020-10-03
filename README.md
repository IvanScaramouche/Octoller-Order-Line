# Octoller.LineCommander
> Небольшая библиотека написанная (и находящаяся в доработке) в качестве проекта для обучения.

> README находится в процессе написания

Библиотека позволяет, реализуя специальные интерфейсы, создавать обработчики строковых команд, перекладывая парсинг строки и запуск обработчиков на внутренние классы. 

### На текущий момент поддерживаются следующие возможности:
* Передаяа любого колличества аргументов в команду посредствам разделения символом `,`

      CL> команда:аргумент1,аргумент2,аргумент3... аргументN
      

* Выполнение цепочки команд с использованием `команд-переходов`, определяющих условие перехода к следующей команде. 
 
      CL> команда:аргумент,аргумент,аргумент & команда:аргумент && команда:аргумент,аргумент || команда  
       
  **&**  — используется для разделения нескольких команд в одной командной строке. Команды выполняются последовательно.

  **&&** — запускает команду, стоящую за символом &&, только если команда, стоящая перед этим символом была выполнена успешно.

  **||** — запускает команду, стоящую за символом ||, только если команда, стоящая перед символом || не была выполнена.
  
  
* Пропуск через обработчики команд объекта реализующего интерфейс `IChContext`, что позволяет отследить успешное выполнение команд, получить результат выполнения или сообщения об ошибках

* Содержит встроенную команду `help` позволяющую вывести список всех загруженных команд с указанием ключа и описанием

### Использование
Для создания собственной команды необходимо реализовать интерфейсы `IOrderHeader` и `IOrderHandler`

`IOrderHeader` - отвечает за строковое имя команды, её описание для `help` и позволяет получить объект обработчика данной команды

```C#
using Octoller.OrderLineHandler.ServiceObjects;
using Octoller.OrderLineHandler.Processor;

public sealed class ContainerMore : IOrderHeader {

  private static string key = "more";
  private static string description = 
      "выводит большее число из полученного массива";

  public string Key {
      get => key;
  }

  public string Description {
      get => description;
  }

  // Возвращает объект обработчика команды     
  public IOrderHandler GetHandler() {
      return new OrderMore();
  }
}
```

`IOrderHandler` - отвечает за результат выполнения команды и обработку передаваемого контекста

```C#
using Octoller.OrderLineHandler.ServiceObjects;
using Octoller.OrderLineHandler.Processor;

public sealed class OrderMore : IOrderHandler {

  private int[] numbers = null;
  private bool isError = false;

  //метод обработки
  public bool Invoke(IChContext context) {
      if (isError) {
          context.Complite = false;
          context.SetError("Некорректный аргумент.");
          return false;
      } else {
          context.Complite = true;
          int max = numbers.Max();
          System.Console.WriteLine(max);
          return true;
      }
  }

  //парсим и проверяем на корректность полученные аргументы из командной строки
  public void SetArgument(params string[] arg) {
      if (arg != null && arg.Length > 0) {
          List<int> temp = new List<int>();
          foreach (var a in arg) {
              if (int.TryParse(a, out int i)) {
                  temp.Add(i);
              } else {
                  isError = true;
                  break;
              }
          }
          numbers = temp.ToArray();
      } else {
          isError = true;
      }
  }
}
```

     In the process of writing...
