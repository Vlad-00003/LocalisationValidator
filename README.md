## LocalisationValidator - English
This is a small program. It's purpose - update the lang files with the new fields from the original (english) without modifying existing lines.

---
### Usage
1. Grab yourself a [**latest release**](https://github.com/Vlad-00003/LocalisationValidator/releases) *you only need the exe, the over files is just a hash sum*
2. Move the **LocalisationValidator.exe** to the **game's managed folder**. As it requires Assembly-CSharp.dll to ~~exist~~ run. For example: `D:\Games\Steam\steamapps\common\Shoppe Keep 2\Shoppe Keep 2_Data\Managed\LocalisationValidator.exe`
3. Run it.

The program creates the log file called `LocalisationValidator.log.txt`, so you can easily see wich fields (if any) was added.

Keep in mind - that as soon as you would run it - it would append text to your files and sort them the simular way `Language_English.txt` is sorted.

You also can specify path to the localization files as the argument:
+ Open command promt (cmd), navigate to the `Managed` folder and run `LocalisationValidator.exe <YOUR_PATH>`. Ex: `LocalisationValidator.exe D:\Games\Shoppe Keep 2\Localization`
+ Create a shortcut
  - Right click the program -> create shortcut
  - Open shortcut's properties
  - Add your path to the end of the **Target** field.

---

### Compiling
1. Download the repo *clone it wia git, download zip or open in VS, it doesn't matter*
2. Add refrence to the game's `Assembly-CSharp.dll`. *It requires to be able to use the JSONObject class*
3. ???
4. Profit =)
---

If you have any issues with it - open one [**here**](https://github.com/Vlad-00003/LocalisationValidator/issues/new)

---
## LocalisationValidator - Русский вариант
Это небольшая программка созданная для того, чтобы дополнять языковые файлы в случае изменения оргинального текста. Существующие записи затронуты не будут.

---
### Использование
1. Скачайте [**последнюю версию**](https://github.com/Vlad-00003/LocalisationValidator/releases). *Вам нужен только exe файл, остальное - хэш суммы.*
2. Переместите **LocalisationValidator.exe** в папку **managed** игры. Для ~~существования~~ работы, приложению требуется Assembly-CSharp.dll. К примеру: `D:\Games\Steam\steamapps\common\Shoppe Keep 2\Shoppe Keep 2_Data\Managed\LocalisationValidator.exe`
3. Запустите его.

Программа создаёт файл журнала под названием `LocalisationValidator.log.txt` в той же папке, где находиться. В нём вы сможете просмотреть какие поля были добавлены (если вообще были).

Учтите вот что - как только вы запустите программу - она попытается добраться до файлов перевода - дополнить строки и отсортировать остальные файлы в том же порядке, что и `Language_English.txt`. Если файлы не будут найдены - она предложит вам ввести путь вручную.

Так же вы можете указать путь к файлам локализации вручную, для этого:
+ Через консоль:
  -Откройте интерпретатор командной строки, перейдите в папку `Managed` в директории игры и запустите программу, добавив путь в качестве аргумента - `LocalisationValidator.exe <YOUR_PATH>`. Например: `LocalisationValidator.exe D:\Games\Shoppe Keep 2\Localization`
+ Через ярлык 
  - ПКМ на программе -> Создать ярлык
  - Откройте его свойства
  - Добавьте ваш путь в конец поля **Объект**
---
Если у вас возникли какие-то трудности с программой или её компиляцией - вы можете [**открыть обращение**](https://github.com/Vlad-00003/LocalisationValidator/issues/new)

---

### Сборка
1. Скачайте репозиторий. *Не важно - клонируете ли вы его через git, скачаете архив zip или же сразу откроете в Visual Studio*
2. В проекте добавьте ссылку на `Assembly-CSharp.dll` игры. *Она нужна для использования класса JSONObject*
3. ???
4. Profit =)
