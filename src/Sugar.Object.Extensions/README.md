# Sugar.Object.Extensions

## Установка

Добавьте пакет через NuGet:

```bash
dotnet add package Sugar.Object.Extensions
```

Или установите через менеджер пакетов в Visual Studio.

## Возможности

### 1. Безопасное приведение типов (`ObjectCastExtensions`)
```csharp
public static class ObjectCastExtensions
{
    public static bool Is<TCast>(this object source);
    public static bool Is<TCast>(this object source, out TCast cast);
    public static TCast As<TCast>(this object source) where TCast : class;
}
```

### 2. Работа с `null` (`ObjectNullExtensions`)
```csharp
public static class ObjectNullExtensions
{
    public static bool IsNil(this object source);
    public static bool IsNotNil(this object source);
}
```

### 3. Информация о типах (`ObjectTypeExtensions`)
```csharp
public static class ObjectTypeExtensions
{
    // Статическая информация о типе (из generic параметра)
    public static Type CurrentType { get; }
    public static string CurrentTypeName { get; }
    public static string CurrentTypeFullName { get; }
    
    // Динамическая информация о типе (через GetType())
    public static Type Type { get; }
    public static string TypeName { get; }
    public static string TypeFullName { get; }
}
```

### 4. Пустой метод (`ObjectCommonExtensions`)
```csharp
public static class ObjectCommonExtensions
{
    public static void Forget(this object source);
}
```

## Примеры использования

### Приведение типов
```csharp
object obj = "Hello World";

// Проверка типа
if (obj.Is<string>())
{
    Console.WriteLine("Это строка");
}

// Безопасное приведение
var str = obj.As<string>();
Console.WriteLine(str?.ToUpper()); // HELLO WORLD

// Проверка с приведением
if (obj.Is<string>(out var s))
{
    Console.WriteLine($"Длина строки: {s.Length}");
}
```

### Проверка на null
```csharp
object maybeNull = GetPossibleNull();

if (maybeNull.IsNil)
{
    Console.WriteLine("Объект null");
}

if (maybeNull.IsNotNil)
{
    Console.WriteLine("Объект не null");
}
```

### Информация о типах
```csharp
List<int> numbers = new List<int>();

Console.WriteLine(numbers.CurrentTypeName);      // "List`1"
Console.WriteLine(numbers.CurrentTypeFullName); // "System.Collections.Generic.List`1"

Console.WriteLine(numbers.TypeName);            // "List`1"
Console.WriteLine(numbers.TypeFullName);        // "System.Collections.Generic.List`1"
```

### Метод Forget
```csharp
GetSomeObject()
    .Process()
    .Forget(); // Явно указываем, что результат не используется
```