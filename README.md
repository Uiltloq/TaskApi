# TaskApi
Тестовое задание:
Создать REST API для работы с задачами.
1. Задача имеет поля: дата, наименование, статус выполнения. Задача может содержать несколько файлов.
2. API должен позволять работать с задачами (добавлять, удалять, обновлять, получать) и файлами. Учитывать, что файл может быть большим (в районе 100мб).
3. API может быть использован в разных клиентах (сайт, мобильные приложения). Задач может быть много (несколько тысяч).
4. Решение должно быть слабосвязанным, с выделенными слоями.
5. API должен иметь тестовый интерфейс в браузере (swagger или аналогичный). БД должна содержать тестовые данные.  Рекомендуется использовать .NET 5.0 или выше, БД MSSQL и какую-то ORM.

API:
GET: /api/task/ - Выводит список всех задач
POST: /api/task - Создает новую задачу
GET: /api/task/id - Выводит задачу по id
PUT: /api/task/id - Изменяет задачу по id
DELETE: /api/task/id - Удаляет задачу по id
GET: /api/task/value - Выводит предел задач
POST: /api/task/uploadfile - Загружает файл, к определенной задаче

GET: /api/file/id - Выводит файл по id
DELETE: /api/file/id - Удалаяет файл по id
GET: /api/file - Выводит список файлов