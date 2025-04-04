# Compression_String

![Static Badge](https://img.shields.io/badge/Language-C%23-blue?logo=c-sharp)

Это консольное приложение на **C#** для сжатия и восстановления строк, которое реализует алгоритм замены последовательностей одинаковых символов на комбинацию символа и числа повторений.

## Описание

Приложение предоставляет:

- **Сжатие строк**:
  - Заменяет последовательности одинаковых символов форматом "символ+количество" (например, "aaabbb" → "a3b3")
  - Сохраняет одиночные символы без изменений

- **Восстановление строк**:
  - Преобразует сжатые строки обратно в оригинальный формат
  - Поддерживает многоцифровые счетчики повторений

- **Особенности**:
  - Поддержка только строчных латинских букв (a-z)
  - Валидация ввода
  - Подробные сообщения об ошибках

## Сборка и запуск

```bash
dotnet build
dotnet run
