# Тестовое задание ITExpert

# Задача 1
Необходимо реализовать веб-приложение на Asp.Net Core.
Заметка по проекту: решение может показаться излишне переусложнённым, но реализовано данным образом только для того,
чтобы несмотря на простое задание постараться раскрыть свой опыт.  


# Задача 2

### 1. Написать запрос, который возвращает наименование клиентов и кол-во контактов клиентов

Аггрегируем через GROUP BY

```sql
SELECT
cl.ClientName,
count([cc.Id]) as ContactsCount
FROM Clients cl
LEFT JOIN ClientContacts cc
ON cc.ClientId = [cl.Id]
GROUP BY [cl.Id];
```

![image](https://github.com/darthdev59/ITExpert/assets/78018833/220d6fd3-8da7-4cab-9d25-c2d7ad9c593d)


### 2. Написать запрос, который возвращает список клиентов, у которых есть более 2 контактов

Используем Having

```sql
SELECT
cl.ClientName,
count([cc.Id]) as ContactsCount
FROM Clients cl
LEFT JOIN ClientContacts cc
ON cc.ClientId = [cl.Id]
GROUP BY [cl.Id]
HAVING count([cc.Id]) > 2;
```
![image](https://github.com/darthdev59/ITExpert/assets/78018833/5a843bf2-fc48-4278-9390-41ed4f5a15cc)

# Задача 3 (опционально)
Написать запрос, который возвращает интервалы для одинаковых Id. Например, есть такой набор данных
```sql
SELECT * FROM (
SELECT
Id,
lag(dt) OVER (PARTITION BY Id) as Sd,
Dt as Ed
FROM Dates
) as res
WHERE Sd IS NOT NULL
```
Так же можно немного инвертировать и использовать lead()
