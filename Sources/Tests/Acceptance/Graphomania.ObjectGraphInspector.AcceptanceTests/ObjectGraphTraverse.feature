@Имитация
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
	| company1       | ID       | 1                        |
	| company1       | Title    | "ИГИТ"                   |
	| department1    | ID       | 2                        |
	| department1    | Title    | "Отдел разработки"       |
	| department2    | ID       | 3                        |
	| department2    | Title    | "Отдел 3d-моделирования" |
	
	Если выполнить обход графа,

	То на выходе будет список элементов, описывающих объекты объектного графа:
	| Тип элемента | Тип объекта | ID объекта | ID начала | ID конца | Имя связи   | Содержимое атрибутов объекта в JSON                   |
	| Node         | Company     | 1          |           |          |             | { Name: "Теплосеть 1", Description: "Тепловая сеть" } |
	| Node         | Department  | 2          |           |          |             | { Name: "Теплосеть 1", Description: "Тепловая сеть" } |
	| Node         | Department  | 3          |           |          |             | { Name: "Теплосеть 1", Description: "Тепловая сеть" } |
	| Relation     |             |            | 1         | 2        | Departments |                                                       |
	| Relation     |             |            | 1         | 3        | Departments |                                                       |



Структура сценария: Сравнение различных стратегий обхода объектного графа.
	Допустим есть объектный граф с глубиной 3
	И минимальным количеством дочерних элементов 1 
	И максимальным количеством 10.

	Если выбрана <Стратегия> обхода графа (для 300 элементов),
	То должен быть <прирост скорости> обхода относительно эталонного (однопоточный алгоритм обхода вглубь).
	
	Примеры: 
	| Стратегия                        | прирост скорости |
	| DepthFirstSingleThreadStrategy   | 0                |
	| BreadthFirstSingleThreadStrategy | 0                |
	| DepthFirstMultiThreadStrategy    | > 200            |  