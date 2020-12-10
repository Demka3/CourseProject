# CourseProject
Проект представляет собой WPF приложение для шифровки/расшифровки строк по ключу,
при этом шифровка/расшифровка применяется только к символам русского алфавита, все остальные символы остаются без изменений.
Используется шифр Виженера.

В приложении есть 5 кнопок:

1) "Выбрать файл к расшифровке" - при нажатии открывается окно выбора файла в формате .txt,
после выбора происходит расшифровка строк в файле и вывод расшифрованных строк в основное окно приложения.
При чтении данных из файла приложенние поддерживает кодировки UTF-8, Unicode, BigEndianUnicode, а также дефолтную кодировку для Вашей ОС.

2) "Указать ключ" - при нажатии пользователю предлагаетсяв диалоговом окне ввести новый ключ, который может состоять только из букв русского алфавита.
Ключ по умолчанию - скорпион.

3) "Просмотреть ключ" - кнопка, отображающая текущий ключ.

4) "Сохранить" - кнопка предоставляет возможность сохранить информацию из основного окна приложения (как расшифрованную, так и зашифрованную)
в файл с именем и директорию, указанные пользователем.
Сохранение происходит в дефолтной для Вашей ОС кодировке.

5) "Зашифровать" - при нажатии открывается диалоговое окно, предлагающее пользователю ввести строку для зашифровки.
После ввода строки и клика на кнопку "Готово" пользователь может сохранить зашифрованную строку в txt файл с произвольным именем в произвольную директорию.
В основном окне приложения выведется зашифрованная строка.

Во всех открывающихся диалоговых окнах при нажатии на кнопку "Отмена" диалоговые окна закроются, никаких действий не произойдет.

В проекте присутствует тест алгоритма шифровки и последующей расшифровки с использованием строки,
состоящей из 1000 случайных символов английского и русского алфавитов, цифр и некоторых других символов.
Ключ тоже генерируется случайным образом из букв русского алфавита, длиной 10 символов.
