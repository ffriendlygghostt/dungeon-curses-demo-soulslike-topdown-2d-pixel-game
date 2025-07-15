# Soulslike Top-Down 2D Prototype (In Development)

[RU]

**Разработчик:** 1–2 человека  
**Движок:** Unity 2022.3.4f1  
**Статус:** Прототип на стадии активной разработки  
**Цель проекта:** Изучение разработки игр и создание первого демо-проекта для портфолио

## О проекте

	Этот проект — попытка совместить механики Soulslike с видом сверху (Top-Down 2D).
Проект начался как дипломная работа для колледжа и продолжает дорабатываться для портфолио.  
Основной упор: сложные боевые и статусные механики, разнообразный билдострой и синергия элементов, взаимодействие с окружением, создание атмосферы.
Проект создается одним человеком (в некоторых моментах — в паре), без готовых шаблонов и с упором на самостоятельное понимание всех этапов разработки.

## Видео демонстрации  
[https://www.youtube.com/watch?v=Y1_PqqWpjOI]

## Реализованные механики и системы (актуально на 15.07.2025)

### Карта и окружение
- Лабиринтовая структура уровней с ветвлениями (создание через TiledMap + Props в Unity).
- Реалистичное освещение (Light2D) с затемнением неосвещённых зон.
- Иммерсивные элементы:
  - Свечи, которые тухнут от удара мечом, загораются от огня, гаснут при заморозке.
  - Ловушки: фаерболлы, айсболлы, пики в полу (с разными условиями активации), пилы. Каждая ловушка накладывает стихийный переодический (и нет) урон.

### Система статусов и синергий
- Элементы: огонь, гниение (тот же яд), кровотечение, охлаждение, заморозка.
- Продуманная система взаимодействий между статусами:
  
| Эффект 1       | Эффект 2         | Результат                                                                        |
|----------------|------------------|-----------------------------------------------------------------------------------|
| Огонь          | Лёд              | Снимает заморозку/охлаждение, вызывает взрыв пара (урон + стан).                  |
| Огонь          | Гниение          | +50% урона тика гниения сразу, снимает гниение полностью.                         |
| Огонь          | Кровотечение     | Мгновенно наносит 50% накопленного урона кровотечения, снимает его.              |
| Кровотечение   | Гниение          | Вызывает взрыв обоих эффектов, мгновенно нанося весь накопленный урон.           |
| Кровотечение   | Охлаждение       | Увеличивает длительность кровотечения на 50%, сразу станит цель.                  |
| Кровотечение   | Заморозка        | Аналогично охлаждению.                                                             |
| Гниение        | Охлаждение       | Снимается, нанося 50% урона от гниения.                                           |
| Гниение        | Кровотечение     | Суммируются тики, усиливая эффект.                                                |
| Гниение        | Огонь            | Усиливает длительность огня, гниение снимается.                                   |
| Охлаждение     | Огонь            | Снимается, вызывает взрыв пара.                                                   |
| Охлаждение     | Кровотечение     | Увеличивает длительность кровотечения, станит цель.                               |
| Охлаждение     | Гниение          | Нет эффекта.                                                                      |


 Задумка похожа на систему из Genshin Impact, но с более глубоким влиянием на билдострой и баланс.
С виду система является перегруженной и в дальнейшем потребует упрощения или доработок, чтобы сделать её понятнее игрокам. Её перегруженность связанна с идеей реализации множества билдов и разных подходов к бою.

### Взаимодействие с предметами и торговля
- Сундуки с системой подсветки, партиклами и выпадением предметов/монет.
- Торговец с возможностью покупки предметов (UI пока упрощённый, но рабочий, возможность легко добавлять предметы и убирать их).
- Система предметов и билдостроя (вполне рабочая система под создание новых предметов, требует структурной доработки и более чистого кода).

### UI и инвентарь
- Меню, главное меню, интерфейс здоровья, стамины, кошелек.
- Инвентарь с возможностью перемещения предметов на пкм (очень упрощённый). Требует доработки UX/UI (планируется ближе к системам из No Rest for the Wicked и Elden Ring). Требует внедрение взаимодействия через перенос предметов или двойной клик.

### Боевая система
- Атака через силуэт меча с коллайдером. (В топ-давн игре хотелось бы получить возможность бить во все стороны, однако приобретенная графика, конечно, больше походит на бит-э-мап боёвку (лево-право), из-за чего попытка сделать её под топ-давн возможно сыграет немного негативно в ощущениях боя).
- Дэш с окном неуязвимости. (дефолт для солзов)
- Слоты для активных предметов (3 штуки). (Систему необходимо доработать для удобства, а сами активные предметы, как механику, пересмотреть).
- Система парирования (ОЧЕНЬ популярная механика в наши-то времена, станит врага на пару секунд).

### Враги
- Простое AI через raycast (NavMesh2D пока не подключён из-за технических сложностей).
- Реализовано три типа врагов:
  - Скелет с парируемой и непарируемой-дэш атаками.
  - Паук обычный.
  - Паук ядовитый.
- Планируется добавить ещё минимум 4 врага и одного босса для финальной демо.

### Прочее
- Записки для развития лора
- Комната с загадкой через моральный подтекст.
- Система лечения (эстус в виде книги) с текущими анимациями и логикой. (Требует исправления кучки багов, в целом работоспособная).



## Что планируется в следующих версиях

- Полноценная система билдостроя:
  - Предметы, влияющие на синергию статусов.
  - Предметы, усиления примитивных характеристик.
  - Предметы дающие аткивные способности.
- Система проклятий после смерти:
  - Отказ от потери душ и уход в более игро-механическую стезю.
  - Проклятия усложняют игру, снимаются только определённым способом (например, молитвенной статуей).
- Улучшение AI врагов и реализация босса с паттернами атак.
- Введение оставшихся четырёх типов врагов.
- Завершение и полировка демо-версии для полноценного размещения в портфолио.

## Текущие сложности

- Проблемы с NavMesh2D: требуется доработка для корректной работы с системой уровней.
- Sorting Layers и работа с Tiled2D: пришлось отказаться от некоторых элементов для правильного отображения слоёв.
- Общая доработка и «облизывание» систем для удобства игрока и читаемости геймплея.

## Почему проект выкладывается в открытый доступ

Целью публикации является демонстрация прогресса в разработке и привлечение внимания к своим навыкам как разработчика.  
Проект активно дорабатывается и будет обновляться по мере работы.

---

## Лицензия

Проект опубликован для ознакомления и учебных целей.  
Некоторые графические и аудиофайлы, использованные в проекте, защищены авторскими правами и лицензиями магазинов (Unity Asset Store, itch.io и т.п.).

**Запрещается:**
- Использовать материалы проекта в коммерческих целях.
- Копировать или распространять ассеты проекта отдельно от исходного кода.

**Лицензия:** Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 (CC BY-NC-ND 4.0)

---

[EN]


- Developer: 1–2 people  
- Engine: Unity 2022.3.4f1  
- Status: Prototype in active development  
- Project goal: Learning game development and creating a first demo project for portfolio purposes

## About the Project

This project is an attempt to combine Soulslike mechanics with a top-down 2D perspective  
It started as a college diploma project and is now being further developed as a portfolio piece  
Main focus - complex combat and status effect mechanics, diverse build-crafting and element synergy, environmental interactions, and atmospheric world-building  
The project is created by a solo developer (sometimes in collaboration), without using ready-made templates, emphasizing independent understanding of all development stages

## Video Demonstration  
[https://www.youtube.com/watch?v=Y1_PqqWpjOI]

## Implemented Mechanics and Systems (as of 15-07-2025)

### Map and Environment
- Labyrinth-style level structure with branching paths (created using TiledMap + Props in Unity)
- Realistic lighting (Light2D) with darkened non-illuminated areas
- Immersive elements  
  - Candles that extinguish when hit by a sword, light up with fire, or go out when frozen  
  - Traps - fireballs, ice balls, floor spikes (with different activation conditions), saws  
  - Each trap applies elemental periodic or instant damage  

### Status and Synergy System
- Elements - fire, decay (poison), bleeding, chilling, freezing  
- Thought-out interaction system between statuses

Fire 		+ Ice        -> Removes freeze or chilling, triggers steam explosion (damage + stun)  
Fire 		+ Decay      -> Instantly applies +50% decay tick damage, fully removes decay  
Fire 		+ Bleeding   -> Instantly applies 50% of accumulated bleeding damage, removes it  
Bleeding 	+ Decay      -> Triggers both effects' explosion, instantly dealing all accumulated damage  
Bleeding 	+ Chilling   -> Increases bleeding duration by 50%, instantly stuns the target  
Bleeding 	+ Freezing   -> Same as chilling  
Decay 		+ Chilling   -> Removed, dealing 50% of decay damage instantly  
Decay 		+ Bleeding   -> Tick effects are combined, increasing total effect  
Decay 		+ Fire       -> Increases fire duration, removes decay  
Chilling 	+ Fire       -> Removed, triggers steam explosion  
Chilling 	+ Bleeding   -> Increases bleeding duration, stuns the target  
Chilling 	+ Decay      -> No effect

The concept is somewhat similar to Genshin Impact’s system but with deeper influence on build-crafting and game balance  
At first glance, the system may seem overloaded and will likely require simplification or refinement to make it clearer for players  
Its complexity is tied to the idea of enabling many builds and different combat approaches

### Item Interaction and Trading
- Chests with highlighting, particles, and item or coin drops
- Merchant with the ability to buy items (UI is basic but functional, easy to add or remove items)
- Item and build system (a functional setup for creating new items, requires structural refinement and cleaner code)

### UI and Inventory
- Menus, main menu, health, stamina, and coin interface
- Inventory with basic item movement using right-click (very simplified)  
  Requires UX or UI refinement (planned closer to systems from No Rest for the Wicked and Elden Ring)  
  Needs implementation of item dragging or double-click interaction  

### Combat System
- Attacking via sword silhouette with collider  
  For a top-down game, the goal was to enable attacks in all directions, but the acquired graphics lean more towards beat ‘em up combat (left-right), which may slightly affect combat feel negatively  
- Dash with invincibility window (Soulslike default)
- Active item slots (3)  
  System needs improvement for usability, and active item mechanics need review  
- Parry system (very popular mechanic nowadays, stuns enemies for a couple of seconds)

### Enemies
- Simple AI using raycast (NavMesh2D not yet connected due to technical challenges)
- Three enemy types implemented  
  - Skeleton with parryable and non-parryable dash attacks  
  - Regular spider  
  - Poison spider  
- Planned to add at least 4 more enemies and one boss for the final demo

### Other Features
- Notes to develop the game’s lore
- A room with a moral-based puzzle
- Healing system (Estus-like book) with current animations and logic (requires fixing several bugs, but generally functional)

## Planned Features in Future Versions

- Full-fledged build-crafting system  
  - Items affecting status synergy  
  - Items enhancing base stats  
  - Items granting active abilities  
- Curse system after death  
  - Moving away from soul loss, focusing on gameplay mechanics instead  
  - Curses increase difficulty and can only be removed through specific means (e g prayer statues)  
- Improved enemy AI and boss implementation with attack patterns  
- Introduction of the remaining four enemy types  
- Completion and polishing of the demo version for portfolio release  

## Current Challenges

- NavMesh2D issues - requires refinement for correct level system integration
- Sorting Layers and Tiled2D - had to abandon certain elements to ensure proper layer rendering
- Overall refinement and polishing of systems for player usability and gameplay readability

## Why the Project Is Publicly Available

The purpose of publishing is to showcase development progress and attract attention to the developer’s skills  
The project is actively being worked on and will be updated as development continues

## License

The project is published for learning and demonstration purposes  
Some graphics and audio files used in the project are protected by copyrights and licenses from asset stores (Unity Asset Store, itch.io, etc)

Not Allowed:  
- Using project materials for commercial purposes  
- Copying or distributing project assets separately from the source code  

License: Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 (CC BY-NC-ND 4.0)
