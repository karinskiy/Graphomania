Функция: Object graph traverse
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Сценарий: Анализ графа.
	Допустим на входе будет объектный граф, описанный таблицей, типы объектов лежат в сборке "DomainModel":
	| Тип объекта     | Аргументы конструктора       | Имя экземпляра | Связан с   | Метод присвоения      |
	| HeatingNetwork  | ctor: "Теплосеть 1"          | network        |            |                       |
	| HeatingSource   | ctor: "Котельная 1", network | hs1            |            |                       |
	| ConnectionPoint | method: "p1"                 | hs1-point1     | hs1        | CreateConnectionPoint |
	| Location        | ctor:                        | location1      | hs1-point1 | Point                 |
	К тому же свойства объектов содержат следующие значения:
	| Имя экземпляра | Свойство    | Значение        |
	| network        | Description | "Тепловая сеть" |
	| hs1-point1     | Location    | @location1      |

	Тогда на выходе будет список элементов, описывающих объекты объектного графа:
	| Тип элемента | Тип объекта    | ID объекта | ID начала | ID конца | Имя связи    | Содержимое атрибутов объекта в JSON                   |
	| Node         | HeatingNetwork | 1          |           |          |              | { Name: "Теплосеть 1", Description: "Тепловая сеть" } |
	| Node         | HeatingSource  | 2          |           |          |              | { Name: "Теплосеть 1", Description: "Тепловая сеть" } |
	| Relation     |                |            | 1         | 2        | Connectables |                                                       |
