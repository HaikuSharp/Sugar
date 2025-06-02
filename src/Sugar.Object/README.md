# Sugar.Object

## Установка

Добавьте пакет через NuGet:

```bash
dotnet add package Sugar.Object
```

Или установите через менеджер пакетов в Visual Studio.

## Возможности:

### Sugar.Object.AnyObject

Специальный тип, который считается равным любому другому объекту.

```csharp
// Все сравнения возвращают true
var any = AnyObject.Any;
bool result1 = any == "test";       // true
bool result2 = any == 123;          // true
bool result3 = any == new object(); // true
```
