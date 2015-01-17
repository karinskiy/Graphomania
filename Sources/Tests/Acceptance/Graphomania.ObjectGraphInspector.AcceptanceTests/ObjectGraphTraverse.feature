Функция: Object graph traverse
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Сценарий: Обход графа и получение плоского списка его элементов.
	Допустим на входе будет объектный граф, описанный таблицей, типы объектов лежат в сборке "DomainModel":
	| Тип объекта | Аргументы конструктора | Имя экземпляра | Связан с | Метод присвоения |
	| Company     | ctor:                  | company1       |          |                  |
	| Department  | ctor:                  | department1    | company1 | Departments      |
	| Department  | ctor:                  | department2    | company1 | Departments      |
	К тому же свойства объектов содержат следующие значения:
	| Имя экземпляра | Свойство | Значение                 |
	| company1       | Title    | "ИГИТ"                   |
	| department1    | Title    | "Отдел разработки"       |
	| department2    | Title    | "Отдел 3d-моделирования" |

	Тогда на выходе будет список элементов, описывающих объекты объектного графа:
	| Тип элемента | Тип объекта | ID объекта | ID начала | ID конца | Имя связи    | Содержимое атрибутов объекта в JSON                   |
	| Node         | Company     | 1          |           |          |              | { Name: "Теплосеть 1", Description: "Тепловая сеть" } |
	| Node         | Department  | 2          |           |          |              | { Name: "Теплосеть 1", Description: "Тепловая сеть" } |
	| Relation     |             |            | 1         | 2        | Connectables |                                                       |
