using System.Globalization;
using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.DAL
{
    public class Constants
    {
        public const int OnlineTimeout = 5;

        public const string PromouterChecklistTypeCode = "Promouter";
        public const string EmployerChecklistTypeCode = "Employer";
        public const string EmployerMainChecklistTypeCode = "EmployerMain";
        public const string DefaultAvatarImage = "motorcycle.jpeg";

        public const string DesiredWorkCode = "DESIRED_WORK";
        public const string WorkExperienceCode = "WORK_EXPERIENCE";
        public const string CityCode = "CITY";
        public const string GenderCode = "GENDER";
        public const string SalaryCode = "SALARY";
        public const string EmployerNameCode = "EMPLOYER_NAME";
        public const string VacancyCode = "VACANCY";
        public const string EducationCode = "EDUCATION";
        public const string DateOfBirthCode = "DATE_OF_BIRTH";
        public const string MedicalBookCode = "MEDICAL_BOOK";
        public const string CarCode = "CAR";
        public const string MobilePhoneCode = "MOBILE_PHONE";
        public const string HeightCode = "HEIGHT";
        public const string WeightCode = "WEIGHT";
        public const string BuildCode = "BUILD";
        public const string EyeColorCode = "EYE_COLOR";
        public const string HairLengthCode = "HAIR_LENGTH";
        public const string SkinTypeCode = "SKIN_TYPE";
        public const string HairColorCode = "HAIR_COLOR";
        public const string SizeClothesCode = "SIZE_CLOTHES";
        public const string SizeShoesCode = "SIZE_SHOES";
        public const string SizeChestCode = "SIZE_CHEST";
        public const string RollerSkatesCode = "ROLLER_SKATES";
        public const string WinterSkatesCode = "WINTER_SKATES";
        public const string HobbiesCode = "HOBBIES";
        public const string AboutCode = "ABOUT";
        public const string AddressCode = "ADDRESS";
        public const string DesiredWorkTimeCode = "DESIRED_WORK_TIME";
        public const string FirstNameCode = "FIRST_NAME";
        public const string LastNameCode = "LAST_NAME";
        public const string MiddleNameCode = "MIDDLE_NAME";
        public const string ReadyForWorkCode = "READY_FOR_WORK";

        public const string StartWorkCode = "START_WORK";
        public const string EndWorkCode = "END_WORK";
        public const string WorkCode = "WORK_CODE";
        public const string EmailCode = "EMAIL_CODE";

        public const string EmployerTypeCode = "EMPLOYER_TYPE";
        public const string CompanyTypeCode = "COMPANY_TYPE";
        public const string CompanySubTypeCode = "COMPANY_SUB_TYPE";
        public const string JobTitleCode = "JOB_TITLE";

        public const string OperationCode = "OPERATIONS_CODE";

        #region Education

        public static readonly string[] EducationValues =
        {
            "Среднее",
            "Среднее полное",
            "Неоконченное высшее",
            "Высшее"
        };

        #endregion

        #region Salary

        public static readonly int[] SalaryValues =
        {
            150, 170, 180, 200, 220, 240, 250,
            270, 280, 300, 350, 400, 450, 500, 550, 600, 650, 700,
            800, 900, 1000, 1500, 2000, 3000, 4000, 5000
        };

        #endregion

        #region Gender

        public const string MaleCode = "Мужской";
        public const string FemaleCode = "Женский";

        public static readonly string[] GenderValues =
        {
            MaleCode,
            FemaleCode
        };

        #endregion

        #region City

        public static readonly string[] CityValues =
        {
            "Адыгейск",
            "Майкоп",
            "Горно-Алтайск",
            "Алейск",
            "Барнаул",
            "Белокуриха",
            "Бийск",
            "Горняк",
            "Заринск",
            "Змеиногорск",
            "Камень-на-Оби",
            "Новоалтайск",
            "Рубцовск",
            "Славгород",
            "Яровое",
            "Белогорск",
            "Благовещенск",
            "Завитинск",
            "Зея",
            "Райчихинск",
            "Свободный",
            "Сковородино",
            "Тында",
            "Шимановск",
            "Архангельск",
            "Вельск",
            "Каргополь",
            "Коряжма",
            "Котлас",
            "Мезень",
            "Мирный",
            "Новодвинск",
            "Няндома",
            "Онега",
            "Северодвинск",
            "Сольвычегодск",
            "Шенкурск",
            "Астрахань",
            "Ахтубинск",
            "Знаменск",
            "Камызяк",
            "Нариманов",
            "Харабали",
            "Агидель",
            "Баймак",
            "Белебей",
            "Белорецк",
            "Бирск",
            "Благовещенск",
            "Давлеканово",
            "Дюртюли",
            "Ишимбай",
            "Кумертау",
            "Межгорье",
            "Мелеуз",
            "Нефтекамск",
            "Октябрьский",
            "Салават",
            "Сибай",
            "Стерлитамак",
            "Туймазы",
            "Уфа",
            "Учалы",
            "Янаул",
            "Алексеевка",
            "Белгород",
            "Бирюч",
            "Валуйки",
            "Грайворон",
            "Губкин",
            "Короча",
            "Новый Оскол",
            "Старый Оскол",
            "Строитель",
            "Шебекино",
            "Брянск",
            "Дятьково",
            "Жуковка",
            "Злынка",
            "Карачев",
            "Клинцы",
            "Мглин",
            "Новозыбков",
            "Почеп",
            "Севск",
            "Сельцо",
            "Стародуб",
            "Сураж",
            "Трубчевск",
            "Унеча",
            "Фокино",
            "Бабушкин",
            "Гусиноозёрск",
            "Закаменск",
            "Кяхта",
            "Северобайкальск",
            "Улан-Удэ",
            "Александров",
            "Владимир",
            "Вязники",
            "Гороховец",
            "Гусь-Хрустальный",
            "Камешково",
            "Карабаново",
            "Киржач",
            "Ковров",
            "Кольчугино",
            "Костерёво",
            "Курлово",
            "Лакинск",
            "Меленки",
            "Муром",
            "Петушки",
            "Покров",
            "Радужный",
            "Собинка",
            "Струнино",
            "Судогда",
            "Суздаль",
            "Юрьев-Польский",
            "Волгоград",
            "Волжский",
            "Дубовка",
            "Жирновск",
            "Калач-на-Дону",
            "Камышин",
            "Котельниково",
            "Котово",
            "Краснослободск",
            "Ленинск",
            "Михайловка",
            "Николаевск",
            "Новоаннинский",
            "Палласовка",
            "Петров Вал",
            "Серафимович",
            "Суровикино",
            "Урюпинск",
            "Фролово",
            "Бабаево",
            "Белозерск",
            "Великий Устюг",
            "Вологда",
            "Вытегра",
            "Грязовец",
            "Кадников",
            "Кириллов",
            "Красавино",
            "Никольск",
            "Сокол",
            "Тотьма",
            "Устюжна",
            "Харовск",
            "Череповец",
            "Бобров",
            "Богучар",
            "Борисоглебск",
            "Бутурлиновка",
            "Воронеж",
            "Калач",
            "Лиски",
            "Нововоронеж",
            "Новохопёрск",
            "Острогожск",
            "Павловск",
            "Поворино",
            "Россошь",
            "Семилуки",
            "Эртиль",
            "Буйнакск",
            "Дагестанские Огни",
            "Дербент",
            "Избербаш",
            "Каспийск",
            "Кизилюрт",
            "Кизляр",
            "Махачкала",
            "Хасавюрт",
            "Южно-Сухокумск",
            "Биробиджан",
            "Облучье",
            "Балей",
            "Борзя",
            "Краснокаменск",
            "Могоча",
            "Нерчинск",
            "Петровск-Забайкальский",
            "Сретенск",
            "Хилок",
            "Чита",
            "Шилка",
            "Вичуга",
            "Гаврилов Посад",
            "Заволжск",
            "Иваново",
            "Кинешма",
            "Комсомольск",
            "Кохма",
            "Наволоки",
            "Плёс",
            "Приволжск",
            "Пучеж",
            "Родники",
            "Тейково",
            "Фурманов",
            "Шуя",
            "Южа",
            "Юрьевец",
            "Карабулак",
            "Магас",
            "Малгобек",
            "Назрань",
            "Алзамай",
            "Ангарск",
            "Байкальск",
            "Бирюсинск",
            "Бодайбо",
            "Братск",
            "Вихоревка",
            "Железногорск-Илимский",
            "Зима",
            "Иркутск",
            "Киренск",
            "Нижнеудинск",
            "Саянск",
            "Свирск",
            "Слюдянка",
            "Тайшет",
            "Тулун",
            "Усолье-Сибирское",
            "Усть-Илимск",
            "Усть-Кут",
            "Черемхово",
            "Шелехов",
            "Баксан",
            "Майский",
            "Нальчик",
            "Нарткала",
            "Прохладный",
            "Терек",
            "Тырныауз",
            "Чегем",
            "Багратионовск",
            "Балтийск",
            "Гвардейск",
            "Гурьевск",
            "Гусев",
            "Зеленоградск",
            "Калининград",
            "Краснознаменск",
            "Ладушкин",
            "Мамоново",
            "Неман",
            "Нестеров",
            "Озёрск",
            "Пионерский",
            "Полесск",
            "Правдинск",
            "Светлогорск",
            "Светлый",
            "Славск",
            "Советск",
            "Черняховск",
            "Приморск",
            "Городовиковск",
            "Лагань",
            "Элиста",
            "Балабаново",
            "Белоусово",
            "Боровск",
            "Ермолино",
            "Жиздра",
            "Жуков",
            "Калуга",
            "Киров",
            "Козельск",
            "Кондрово",
            "Кремёнки",
            "Людиново",
            "Малоярославец",
            "Медынь",
            "Мещовск",
            "Мосальск",
            "Обнинск",
            "Сосенский",
            "Спас-Деменск",
            "Сухиничи",
            "Таруса",
            "Юхнов",
            "Вилючинск",
            "Елизово",
            "Петропавловск-Камчатский",
            "Карачаевск",
            "Теберда",
            "Усть-Джегута",
            "Черкесск",
            "Беломорск",
            "Кемь",
            "Кондопога",
            "Костомукша",
            "Лахденпохья",
            "Медвежьегорск",
            "Олонец",
            "Петрозаводск",
            "Питкяранта",
            "Пудож",
            "Сегежа",
            "Сортавала",
            "Суоярви",
            "Анжеро-Судженск",
            "Белово",
            "Берёзовский",
            "Гурьевск",
            "Калтан",
            "Кемерово",
            "Киселёвск",
            "Ленинск-Кузнецкий",
            "Мариинск",
            "Междуреченск",
            "Мыски",
            "Новокузнецк",
            "Осинники",
            "Полысаево",
            "Прокопьевск",
            "Салаир",
            "Тайга",
            "Таштагол",
            "Топки",
            "Юрга",
            "Белая Холуница",
            "Вятские Поляны",
            "Зуевка",
            "Киров",
            "Кирово-Чепецк",
            "Кирс",
            "Котельнич",
            "Луза",
            "Малмыж",
            "Мураши",
            "Нолинск",
            "Омутнинск",
            "Орлов",
            "Слободской",
            "Советск",
            "Сосновка",
            "Уржум",
            "Яранск",
            "Воркута",
            "Вуктыл",
            "Емва",
            "Инта",
            "Микунь",
            "Печора",
            "Сосногорск",
            "Сыктывкар",
            "Усинск",
            "Ухта",
            "Буй",
            "Волгореченск",
            "Галич",
            "Кологрив",
            "Кострома",
            "Макарьев",
            "Мантурово",
            "Нерехта",
            "Нея",
            "Солигалич",
            "Чухлома",
            "Шарья",
            "Абинск",
            "Анапа",
            "Апшеронск",
            "Армавир",
            "Белореченск",
            "Геленджик",
            "Горячий Ключ",
            "Гулькевичи",
            "Ейск",
            "Кореновск",
            "Краснодар",
            "Кропоткин",
            "Крымск",
            "Курганинск",
            "Лабинск",
            "Новокубанск",
            "Новороссийск",
            "Приморско-Ахтарск",
            "Славянск-на-Кубани",
            "Сочи",
            "Темрюк",
            "Тимашёвск",
            "Тихорецк",
            "Туапсе",
            "Усть-Лабинск",
            "Хадыженск",
            "Артёмовск",
            "Ачинск",
            "Боготол",
            "Бородино",
            "Дивногорск",
            "Дудинка",
            "Енисейск",
            "Железногорск",
            "Заозёрный",
            "Зеленогорск",
            "Игарка",
            "Иланский",
            "Канск",
            "Кодинск",
            "Красноярск",
            "Лесосибирск",
            "Минусинск",
            "Назарово",
            "Норильск",
            "Сосновоборск",
            "Ужур",
            "Уяр",
            "Шарыпово",
            "Далматово",
            "Катайск",
            "Курган",
            "Куртамыш",
            "Макушино",
            "Петухово",
            "Шадринск",
            "Шумиха",
            "Щучье",
            "Дмитриев",
            "Железногорск",
            "Курск",
            "Курчатов",
            "Льгов",
            "Обоянь",
            "Рыльск",
            "Суджа",
            "Фатеж",
            "Щигры",
            "Бокситогорск",
            "Волосово",
            "Волхов",
            "Всеволожск",
            "Выборг",
            "Высоцк",
            "Гатчина",
            "Ивангород",
            "Каменногорск",
            "Кингисепп",
            "Кириши",
            "Кировск",
            "Коммунар",
            "Лодейное Поле",
            "Луга",
            "Любань",
            "Никольское",
            "Новая Ладога",
            "Отрадное",
            "Пикалёво",
            "Подпорожье",
            "Приморск",
            "Приозерск",
            "Светогорск",
            "Сертолово",
            "Сланцы",
            "Сосновый Бор",
            "Сясьстрой",
            "Тихвин",
            "Тосно",
            "Шлиссельбург",
            "Грязи",
            "Данков",
            "Елец",
            "Задонск",
            "Лебедянь",
            "Липецк",
            "Усмань",
            "Чаплыгин",
            "Магадан",
            "Сусуман",
            "Волжск",
            "Звенигово",
            "Йошкар-Ола",
            "Козьмодемьянск",
            "Ардатов",
            "Инсар",
            "Ковылкино",
            "Краснослободск",
            "Рузаевка",
            "Саранск",
            "Темников",
            "Москва",
            "Апрелевка",
            "Балашиха",
            "Бронницы",
            "Верея",
            "Видное",
            "Волоколамск",
            "Воскресенск",
            "Высоковск",
            "Голицыно",
            "Дедовск",
            "Дзержинский",
            "Дмитров",
            "Долгопрудный",
            "Домодедово",
            "Дрезна",
            "Дубна",
            "Егорьевск",
            "Железнодорожный",
            "Жуковский",
            "Зарайск",
            "Звенигород",
            "Ивантеевка",
            "Истра",
            "Кашира",
            "Климовск",
            "Клин",
            "Коломна",
            "Котельники",
            "Королёв",
            "Красноармейск",
            "Красногорск",
            "Краснозаводск",
            "Краснознаменск",
            "Кубинка",
            "Куровское",
            "Ликино-Дулёво",
            "Лобня",
            "Лосино-Петровский",
            "Луховицы",
            "Лыткарино",
            "Люберцы",
            "Можайск",
            "Московский",
            "Мытищи",
            "Наро-Фоминск",
            "Ногинск",
            "Одинцово",
            "Ожерелье",
            "Озёры",
            "Орехово-Зуево",
            "Павловский Посад",
            "Пересвет",
            "Подольск",
            "Протвино",
            "Пушкино",
            "Пущино",
            "Раменское",
            "Реутов",
            "Рошаль",
            "Руза",
            "Сергиев Посад",
            "Серпухов",
            "Солнечногорск",
            "Старая Купавна",
            "Ступино",
            "Талдом",
            "Троицк",
            "Фрязино",
            "Химки",
            "Хотьково",
            "Черноголовка",
            "Чехов",
            "Шатура",
            "Щёлково",
            "Щербинка",
            "Электрогорск",
            "Электросталь",
            "Электроугли",
            "Юбилейный",
            "Яхрома",
            "Апатиты",
            "Гаджиево",
            "Заозёрск",
            "Заполярный",
            "Кандалакша",
            "Кировск",
            "Ковдор",
            "Кола",
            "Мончегорск",
            "Мурманск",
            "Оленегорск",
            "Островной",
            "Полярные Зори",
            "Полярный",
            "Североморск",
            "Снежногорск",
            "Нарьян-Мар",
            "Арзамас",
            "Балахна",
            "Богородск",
            "Бор",
            "Ветлуга",
            "Володарск",
            "Ворсма",
            "Выкса",
            "Горбатов",
            "Городец",
            "Дзержинск",
            "Заволжье",
            "Княгинино",
            "Кстово",
            "Кулебаки",
            "Лукоянов",
            "Лысково",
            "Навашино",
            "Нижний Новгород",
            "Павлово",
            "Первомайск",
            "Перевоз",
            "Саров",
            "Семёнов",
            "Сергач",
            "Урень",
            "Чкаловск",
            "Шахунья",
            "Боровичи",
            "Валдай",
            "Великий Новгород",
            "Малая Вишера",
            "Окуловка",
            "Пестово",
            "Сольцы",
            "Старая Русса",
            "Холм",
            "Чудово",
            "Барабинск",
            "Бердск",
            "Болотное",
            "Искитим",
            "Карасук",
            "Каргат",
            "Куйбышев",
            "Купино",
            "Новосибирск",
            "Обь",
            "Татарск",
            "Тогучин",
            "Черепаново",
            "Чулым",
            "Исилькуль",
            "Калачинск",
            "Называевск",
            "Омск",
            "Тара",
            "Тюкалинск",
            "Абдулино",
            "Бугуруслан",
            "Бузулук",
            "Гай",
            "Кувандык",
            "Медногорск",
            "Новотроицк",
            "Оренбург",
            "Орск",
            "Соль-Илецк",
            "Сорочинск",
            "Ясный",
            "Болхов",
            "Дмитровск",
            "Ливны",
            "Малоархангельск",
            "Мценск",
            "Новосиль",
            "Орёл",
            "Белинский",
            "Городище",
            "Заречный",
            "Каменка",
            "Кузнецк",
            "Нижний Ломов",
            "Никольск",
            "Пенза",
            "Сердобск",
            "Спасск",
            "Сурск",
            "Александровск",
            "Березники",
            "Верещагино",
            "Горнозаводск",
            "Гремячинск",
            "Губаха",
            "Добрянка",
            "Кизел",
            "Красновишерск",
            "Краснокамск",
            "Кудымкар",
            "Кунгур",
            "Лысьва",
            "Нытва",
            "Оса",
            "Оханск",
            "Очёр",
            "Пермь",
            "Соликамск",
            "Усолье",
            "Чайковский",
            "Чердынь",
            "Чёрмоз",
            "Чернушка",
            "Чусовой",
            "Арсеньев",
            "Артём",
            "Большой Камень",
            "Владивосток",
            "Дальнегорск",
            "Дальнереченск",
            "Лесозаводск",
            "Находка",
            "Партизанск",
            "Спасск-Дальний",
            "Уссурийск",
            "Фокино",
            "Великие Луки",
            "Гдов",
            "Дно",
            "Невель",
            "Новоржев",
            "Новосокольники",
            "Опочка",
            "Остров",
            "Печоры",
            "Порхов",
            "Псков",
            "Пустошка",
            "Пыталово",
            "Себеж",
            "Азов",
            "Аксай",
            "Батайск",
            "Белая Калитва",
            "Волгодонск",
            "Гуково",
            "Донецк",
            "Зверево",
            "Зерноград",
            "Каменск-Шахтинский",
            "Константиновск",
            "Красный Сулин",
            "Миллерово",
            "Морозовск",
            "Новочеркасск",
            "Новошахтинск",
            "Пролетарск",
            "Ростов-на-Дону",
            "Сальск",
            "Семикаракорск",
            "Таганрог",
            "Цимлянск",
            "Шахты",
            "Касимов",
            "Кораблино",
            "Михайлов",
            "Новомичуринск",
            "Рыбное",
            "Ряжск",
            "Рязань",
            "Сасово",
            "Скопин",
            "Спас-Клепики",
            "Спасск-Рязанский",
            "Шацк",
            "Жигулёвск",
            "Кинель",
            "Нефтегорск",
            "Новокуйбышевск",
            "Октябрьск",
            "Отрадный",
            "Похвистнево",
            "Самара",
            "Сызрань",
            "Тольятти",
            "Чапаевск",
            "Зеленогорск",
            "Колпино",
            "Красное Село",
            "Кронштадт",
            "Ломоносов",
            "Павловск",
            "Петергоф",
            "Пушкин",
            "Санкт-Петербург",
            "Сестрорецк",
            "Аркадак",
            "Аткарск",
            "Балаково",
            "Балашов",
            "Вольск",
            "Ершов",
            "Калининск",
            "Красноармейск",
            "Красный Кут",
            "Маркс",
            "Новоузенск",
            "Петровск",
            "Пугачёв",
            "Ртищево",
            "Саратов",
            "Хвалынск",
            "Шиханы",
            "Энгельс",
            "Александровск-Сахалинский",
            "Анива",
            "Долинск",
            "Корсаков",
            "Курильск",
            "Макаров",
            "Невельск",
            "Оха",
            "Поронайск",
            "Северо-Курильск",
            "Томари",
            "Углегорск",
            "Холмск",
            "Шахтёрск",
            "Южно-Сахалинск",
            "Алапаевск",
            "Арамиль",
            "Артёмовский",
            "Асбест",
            "Берёзовский",
            "Богданович",
            "Верхний Тагил",
            "Верхняя Пышма",
            "Верхняя Салда",
            "Верхняя Тура",
            "Верхотурье",
            "Волчанск",
            "Дегтярск",
            "Екатеринбург",
            "Заречный",
            "Ивдель",
            "Ирбит",
            "Каменск-Уральский",
            "Камышлов",
            "Карпинск",
            "Качканар",
            "Кировград",
            "Краснотурьинск",
            "Красноуральск",
            "Красноуфимск",
            "Кушва",
            "Лесной",
            "Михайловск",
            "Невьянск",
            "Нижние Серги",
            "Нижний Тагил",
            "Нижняя Салда",
            "Нижняя Тура",
            "Новая Ляля",
            "Новоуральск",
            "Первоуральск",
            "Полевской",
            "Ревда",
            "Реж",
            "Североуральск",
            "Серов",
            "Среднеуральск",
            "Сухой Лог",
            "Сысерть",
            "Тавда",
            "Талица",
            "Туринск",
            "Алагир",
            "Ардон",
            "Беслан",
            "Владикавказ",
            "Дигора",
            "Моздок",
            "Велиж",
            "Вязьма",
            "Гагарин",
            "Демидов",
            "Десногорск",
            "Дорогобуж",
            "Духовщина",
            "Ельня",
            "Починок",
            "Рославль",
            "Рудня",
            "Сафоново",
            "Смоленск",
            "Сычёвка",
            "Ярцево",
            "Благодарный",
            "Будённовск",
            "Георгиевск",
            "Ессентуки",
            "Железноводск",
            "Зеленокумск",
            "Изобильный",
            "Ипатово",
            "Кисловодск",
            "Лермонтов",
            "Минеральные Воды",
            "Михайловск",
            "Невинномысск",
            "Нефтекумск",
            "Новоалександровск",
            "Новопавловск",
            "Пятигорск",
            "Светлоград",
            "Ставрополь",
            "Жердевка",
            "Кирсанов",
            "Котовск",
            "Мичуринск",
            "Моршанск",
            "Рассказово",
            "Тамбов",
            "Уварово",
            "Агрыз",
            "Азнакаево",
            "Альметьевск",
            "Арск",
            "Бавлы",
            "Болгар",
            "Бугульма",
            "Буинск",
            "Елабуга",
            "Заинск",
            "Зеленодольск",
            "Казань",
            "Лаишево",
            "Лениногорск",
            "Мамадыш",
            "Менделеевск",
            "Мензелинск",
            "Набережные Челны",
            "Нижнекамск",
            "Нурлат",
            "Тетюши",
            "Чистополь",
            "Андреаполь",
            "Бежецк",
            "Белый",
            "Бологое",
            "Весьегонск",
            "Вышний Волочёк",
            "Западная Двина",
            "Зубцов",
            "Калязин",
            "Кашин",
            "Кимры",
            "Конаково",
            "Красный Холм",
            "Кувшиново",
            "Лихославль",
            "Нелидово",
            "Осташков",
            "Ржев",
            "Старица",
            "Тверь",
            "Торжок",
            "Торопец",
            "Удомля",
            "Асино",
            "Кедровый",
            "Колпашево",
            "Северск",
            "Стрежевой",
            "Томск",
            "Алексин",
            "Белёв",
            "Богородицк",
            "Болохово",
            "Венёв",
            "Донской",
            "Ефремов",
            "Кимовск",
            "Киреевск",
            "Липки",
            "Новомосковск",
            "Плавск",
            "Суворов",
            "Тула",
            "Узловая",
            "Чекалин",
            "Щёкино",
            "Ясногорск",
            "Советск",
            "Ак-Довурак",
            "Кызыл",
            "Туран",
            "Чадан",
            "Шагонар",
            "Заводоуковск",
            "Ишим",
            "Тобольск",
            "Тюмень",
            "Ялуторовск",
            "Воткинск",
            "Глазов",
            "Ижевск",
            "Камбарка",
            "Можга",
            "Сарапул",
            "Барыш",
            "Димитровград",
            "Инза",
            "Новоульяновск",
            "Сенгилей",
            "Ульяновск",
            "Амурск",
            "Бикин",
            "Вяземский",
            "Комсомольск-на-Амуре",
            "Николаевск-на-Амуре",
            "Советская Гавань",
            "Хабаровск",
            "Абаза",
            "Абакан",
            "Саяногорск",
            "Сорск",
            "Черногорск",
            "Белоярский",
            "Когалым",
            "Лангепас",
            "Лянтор",
            "Мегион",
            "Нефтеюганск",
            "Нижневартовск",
            "Нягань",
            "Покачи",
            "Пыть-Ях",
            "Радужный",
            "Советский",
            "Сургут",
            "Урай",
            "Ханты-Мансийск",
            "Югорск",
            "Аша",
            "Бакал",
            "Верхнеуральск",
            "Верхний Уфалей",
            "Еманжелинск",
            "Златоуст",
            "Карабаш",
            "Карталы",
            "Касли",
            "Катав-Ивановск",
            "Копейск",
            "Коркино",
            "Куса",
            "Кыштым",
            "Магнитогорск",
            "Миасс",
            "Миньяр",
            "Нязепетровск",
            "Озёрск",
            "Пласт",
            "Сатка",
            "Сим",
            "Снежинск",
            "Трёхгорный",
            "Троицк",
            "Усть-Катав",
            "Чебаркуль",
            "Челябинск",
            "Южноуральск",
            "Юрюзань",
            "Аргун",
            "Грозный",
            "Гудермес",
            "Урус-Мартан",
            "Шали",
            "Алатырь",
            "Канаш",
            "Козловка",
            "Мариинский Посад",
            "Новочебоксарск",
            "Цивильск",
            "Чебоксары",
            "Шумерля",
            "Ядрин",
            "Анадырь",
            "Билибино",
            "Певек",
            "Алдан",
            "Верхоянск",
            "Вилюйск",
            "Ленск",
            "Мирный",
            "Нерюнгри",
            "Нюрба",
            "Олёкминск",
            "Покровск",
            "Среднеколымск",
            "Томмот",
            "Удачный",
            "Якутск",
            "Губкинский",
            "Лабытнанги",
            "Муравленко",
            "Надым",
            "Новый Уренгой",
            "Ноябрьск",
            "Салехард",
            "Тарко-Сале",
            "Гаврилов-Ям",
            "Данилов",
            "Любим",
            "Мышкин",
            "Переславль-Залесский",
            "Пошехонье",
            "Ростов",
            "Рыбинск",
            "Тутаев",
            "Углич",
            "Ярославль",
        };

        #endregion

        #region Work
        
        public static readonly string[] WorkValues =
        {
            "Мерчендайзер",
            "Супервайзер",
            "Курьер",
            "Аудитор/Чекер",
            "Тайный покупатель",
            "Промоутер",
            "Аниматор",
            "Промо-модель",
            "Ростовая кукла",
            "Интервьюер",
            "Модель",
            "Разнорабочий",
            "Бармен",
            "Официант",
            "Хостес",
        };

        #endregion

        #region Phone

        public static readonly string[] MobilePhoneValues =
        {
            "+7",
        };

        #endregion

        #region Company type

        public const string DirectEmployer = "Прямой работодатель";
        public const string RecroutingCompany = "Рекрутинговая компания";

        public static readonly string[] CompanyTypeValues =
        {
            DirectEmployer,
            RecroutingCompany ,
        };

        #endregion

        #region Company sub type

        public static readonly string[] CompanySubTypeValues =
        {
            "Модельное агенство",
            "Рекламное агентство",
            "Маркетинговое агентство",
            "Ивент агентство",
            "Прямой заказчик"
        };

        #endregion

        #region Employer type

        public const string CompanyRepresenter = "Представитель компании";
        public const string PrivateEmployer = "Частный работодатель";
        public const string PrivateRecruiter = "Частный рекрутер";

        public static readonly string[] EmployerTypeValues =
        {
            CompanyRepresenter,
            PrivateEmployer,
            PrivateRecruiter
        };

        #endregion

        #region Operations

        public const string Login = "Login";
        public const string Logout = "Logout";

        public static readonly string[] OperationValues =
        {
            Login,
            Logout
        };
        #endregion


        public DataAccessLayer DataAccessLayer { get;private set; }

        private Constants() { }

        internal Constants(DataAccessLayer dataAccessLayer)
        {
            DataAccessLayer = dataAccessLayer;
        }

        public Photo DefaultAvatar
        {
            get { return DataAccessLayer.DbContext.Set<Photo>().Single(x => x.SourceUrl == DefaultAvatarImage); }
        }

        public ChecklistType PromouterChecklistType 
        {
            get { return DataAccessLayer.Get<ChecklistType>(PromouterChecklistTypeCode); }
        }

        public ChecklistType EmployerChecklistType
        {
            get { return DataAccessLayer.Get<ChecklistType>(EmployerChecklistTypeCode); }
        }

        public ChecklistType EmployerMainChecklistType
        {
            get { return DataAccessLayer.Get<ChecklistType>(EmployerMainChecklistTypeCode); }
        }

        public Attrib DesiredWork 
        {
            get { return DataAccessLayer.Get<Attrib>(DesiredWorkCode); }
        }

        public Attrib City 
        {
            get { return DataAccessLayer.Get<Attrib>(CityCode); }
        }

        public Attrib Gender 
        {
            get { return DataAccessLayer.Get<Attrib>(GenderCode); }
        }

        public Attrib Salary 
        {
            get { return DataAccessLayer.Get<Attrib>(SalaryCode); }
        }

        public Attrib EmployerName 
        {
            get { return DataAccessLayer.Get<Attrib>(EmployerNameCode); }
        }

        public Attrib Vacancy
        {
            get { return DataAccessLayer.Get<Attrib>(VacancyCode); }
        }

        public Attrib Education 
        {
            get { return DataAccessLayer.Get<Attrib>(EducationCode); }
        }

        public Attrib WorkExperience 
        {
            get { return DataAccessLayer.Get<Attrib>(WorkExperienceCode); }
        }

        public Attrib DateOfBirth 
        {
            get { return DataAccessLayer.Get<Attrib>(DateOfBirthCode); }
        }
        
        public Attrib MedicalBook 
        {
            get { return DataAccessLayer.Get<Attrib>(MedicalBookCode); }
        }

        public Attrib Car
        {
            get { return DataAccessLayer.Get<Attrib>(CarCode); }
        }

        public Attrib MobilePhone
        {
            get
            {
                return DataAccessLayer.Get<Attrib>(MobilePhoneCode);
            }
        }

        public Attrib Height
        {
            get { return DataAccessLayer.Get<Attrib>(HeightCode); }
        }

        public Attrib Weight
        {
            get { return DataAccessLayer.Get<Attrib>(WeightCode); }
        }

        public Attrib Build
        {
            get { return DataAccessLayer.Get<Attrib>(BuildCode); }
        }    

        public Attrib EyeColor
        {
            get { return DataAccessLayer.Get<Attrib>(EyeColorCode); }
        }

        public Attrib SkinType
        {
            get { return DataAccessLayer.Get<Attrib>(SkinTypeCode); }
        }

        public Attrib HairColor
        {
            get { return DataAccessLayer.Get<Attrib>(HairColorCode); }
        }

        public Attrib HairLength
        {
            get { return DataAccessLayer.Get<Attrib>(HairLengthCode); }
        }

        public Attrib SizeClothes
        {
            get { return DataAccessLayer.Get<Attrib>(SizeClothesCode); }
        }

        public Attrib SizeShoes
        {
            get { return DataAccessLayer.Get<Attrib>(SizeShoesCode); }
        }

        public Attrib SizeChest
        {
            get { return DataAccessLayer.Get<Attrib>(SizeChestCode); }
        }

        public Attrib RollerSkates
        {
            get { return DataAccessLayer.Get<Attrib>(RollerSkatesCode); }
        }

        public Attrib WinterSkates
        {
            get { return DataAccessLayer.Get<Attrib>(WinterSkatesCode); }
        }

        public Attrib Hobbies
        {
            get { return DataAccessLayer.Get<Attrib>(HobbiesCode); }
        }

        public Attrib About
        {
            get { return DataAccessLayer.Get<Attrib>(AboutCode); }
        }

        public Attrib Address
        {
            get { return DataAccessLayer.Get<Attrib>(AddressCode); }
        }
       
        public Attrib DesiredWorkTime
        {
            get { return DataAccessLayer.Get<Attrib>(DesiredWorkTimeCode); }
        }

        public Attrib FirstName
        {
            get { return DataAccessLayer.Get<Attrib>(FirstNameCode); }
        }

        public Attrib LastName
        {
            get { return DataAccessLayer.Get<Attrib>(LastNameCode); }
        }

        public Attrib MiddleName
        {
            get { return DataAccessLayer.Get<Attrib>(MiddleNameCode); }
        }

        public Attrib ReadyForWork
        {
            get {return DataAccessLayer.Get<Attrib>(ReadyForWorkCode); }
        }

        public Attrib StartWork
        {
            get { return DataAccessLayer.Get<Attrib>(StartWorkCode); }
        }

        public Attrib EndWork
        {
            get { return DataAccessLayer.Get<Attrib>(EndWorkCode); }
        }

        public Attrib Work
        {
            get { return DataAccessLayer.Get<Attrib>(WorkCode); }
        }

        public Attrib Email
        {
            get { return DataAccessLayer.Get<Attrib>(EmailCode); }
        }

        public Attrib CompanySubType
        {
            get { return DataAccessLayer.Get<Attrib>(CompanySubTypeCode); }
        }

        public Attrib JobTitle
        {
            get { return DataAccessLayer.Get<Attrib>(JobTitleCode); }
        }

        public Attrib EmployerType
        {
            get { return DataAccessLayer.Get<Attrib>(EmployerTypeCode); }
        }

        public Attrib CompanyType
        {
            get { return DataAccessLayer.Get<Attrib>(CompanyTypeCode); }
        }
    }
}
