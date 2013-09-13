using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaDataAccessLayer.Helpers;

namespace PandaDataAccessLayer
{
    public partial class MainInitializer
    {
        public void addTestData()
        {
            addAnonimousUser();
            addUser4();
            addUser5();
            addUser6();
            addUser7();
            addUser8();
            addUser9();
            addUser10();
            addUser11();
            addUser12();
            addUser13();
            addUser14();
            addBlog();
            addStaticPages();
        }

        private void addStaticPages()
        {
            //add static pages
            DataAccessLayer.Create(new StaticPageUnit()
            {
                Code = "About",
                Content = "О проекте"
            });

            DataAccessLayer.Create(new StaticPageUnit()
            {
                Code = "Dictionary",
                Content = "Словарь"
            });

            DataAccessLayer.Create(new StaticPageUnit()
            {
                Code = "FAQ",
                Content = "Вопрос-Ответ"
            });

            DataAccessLayer.Create(new StaticPageUnit()
            {
                Code = "Contacts",
                Content = "Контакты"
            });

            DataAccessLayer.Create(new StaticPageUnit()
            {
                Code = "PaidServices",
                Content = "Платные услуги"
            });

            DataAccessLayer.Create(new StaticPageUnit()
            {
                Code = "Commercial",
                Content = "Реклама на сайте"
            });

            DataAccessLayer.Create(new StaticPageUnit()
            {
                Code = "SiteTerms",
                Content = "Условия пользования сайтом"
            });

            DataAccessLayer.Create(new StaticPageUnit()
            {
                Code = "ToWorker",
                Content = "Работодателям"
            });

            DataAccessLayer.Create(new StaticPageUnit()
            {
                Code = "Regulations",
                Content = "Правила сайта"
            });

            DataAccessLayer.Create(new StaticPageUnit()
            {
                Code = "Applicants",
                Content = "Соискателям"
            });

            DataAccessLayer.Create(new StaticPageUnit()
            {
                Code = "Tips for Newcomers",
                Content = "Советы новичкам"
            });

            DataAccessLayer.Create(new StaticPageUnit()
            {
                Code = "Useful Articles",
                Content = "Полезные статьи"
            });

            DataAccessLayer.Create(new StaticPageUnit()
            {
                Code = "Help",
                Content = "Помощь"
            });

            DataAccessLayer.Create(new StaticPageUnit()
            {
                Code = "FiveReasons",
                Content = "<div class=\"five-reasons\">" +
                        "<div class=\"simple-delimiter\"></div>" +
                        "<div class=\"simple-bg\"></div>" +
                        "<div class=\"reasons left\">" +
                            "<h1>5 причин, по которым стоит заказать услуги у нас</h1>" +
                            "<ul>" +
                                "<li>Только проверенные участники проходят отбор</li>" +
                                "<li>Вы сами выбираете исполнителя</li>" +
                                "<li>0% комиссии для заказчиков</li>" +
                                "<li>Оперативный подход</li>" +
                                "<li>Простой и понятный интерфейс</li>" +
                            "</ul>" +
                        "</div>" +
                        "<div class=\"reasons-image right\"><img src=\"/Content/img/five-resons.png\" /></div>" +
                        "<div class=\"clear\"></div>" +
                    "</div>"
            });
        }


        public void addBlog()
        {
            DataAccessLayer.Create(new BlogPost
            {
                FullText = @"<p><b>Власти Египта</b> <i>12 сентября</i> продлили действие режима чрезвычайного положения в ряде провинций страны. Об этом сообщает Agence France-Presse.
Режим ЧП, в соответствии с новым постановлением, продлен на два месяца. Причиной этого власти страны указали продолжающиеся сложности с обеспечением безопасности в Египте. Режим чрезвычайного положения действует в Египте с 14 августа; первоначально предполагалось, что он продлится один месяц.
Дальнейшее продление режима ЧП, в соответствии с ранее подписанным временным президентом Египта Адли Мансуром указом, будет возможно только после одобрения этой меры на всенародном референдуме.
Чрезвычайное положение в Египте было введено после того, как в стране начались массовые беспорядки, вызванные разгоном сидячих лагерей протеста сторонников отстраненного от власти в начале июля президента Мохаммеда Мурси. В первый же день беспорядков были убиты более тысячи человек.</p>",
                ShortDescription = @"Власти Египта 12 сентября продлили действие режима чрезвычайного положения в ряде провинций страны",
                Picture = DataAccessLayer.Create(new Photo
                {
                   SourceUrl = "~/Content/img/del-3-0.png"
                }),
                Title = "Власти Египта продлили действие режима чрезвычайного положения"
            });
            DataAccessLayer.Create(new BlogPost
            {
                FullText = @"<p>Студия Warner Bros. анонсировала серию фильмов по книге Джоан Роулинг «Фантастические звери и места их обитания», сообщает IGN. Сценарий первого фильма серии напишет сама писательница. Эта работа станет ее дебютом в качестве сценариста. Писательница заявила, что, когда Warner Bros. предложили ей экранизировать книгу, она просто не могла представить, что сценаристом станет какой-то другой автор.

«Фантастические звери и места их обитания» — одна из книг, написанных Роулинг в дополнение к серии о Гарри Поттере. По учебнику с таким названием обучаются герои поттерианы. Главным героем новых фильмов станет Ньют Скамандер — вымышленный автор учебника.

Сама Роулинг заявила, что давно планировала развить историю этого персонажа. «Как знают самые упорные фанаты Гарри Поттера, мне так нравится этот герой, что я даже женила его внука Рольфа на одном из моих самых любимых персонажей — Полумне Лавгуд», — сказала писательница.

Также Роулинг заявила, что фильмы о фантастических чудовищах не будут являться ни приквелами, ни сиквелами к «Гарри Поттеру». События в новых картинах, тем не менее, будут разворачиваться в той же магической вселенной. Действие первого фильма, по словам Роулинг, начнется в Нью-Йорке за 70 лет до истории о Гарри Поттере.

Серия фильмов о Гарри Поттере завершилась в 2011 году лентой «Гарри Поттер и Дары Смерти: Часть 2». Всего было снято восемь картин по семи книгам. Экранизацией всей серии занималась компания Warner Bros., Роулинг выступала консультантом при создании всех фильмов. Франшиза стала самой прибыльной киносерией в истории кино, собрав в мировом прокате 7,7 миллиарда долларов.</p>",
                ShortDescription = "Студия Warner Bros. анонсировала серию фильмов по книге Джоан Роулинг «Фантастические звери и места их обитания»",
                Picture = DataAccessLayer.Create(new Photo
                {
                    SourceUrl = "~/Content/img/del-3-0.png"
                }),
                Title = "О волшебных зверях из «Гарри Поттера» снимут серию фильмов"
            });
            DataAccessLayer.Create(new BlogPost
            {
                FullText = @"<p>Космический зонд «Вояджер-1» покинул Солнечную систему и вышел в межзвездное пространство, официально сообщили в NASA.

В NASA пояснили, что соответствующие выводы были сделаны на основании анализа последних данных, полученных от аппарата. «Теперь мы определенно можем ответить на вопрос а там ли мы?: да, мы там», - говорится в сообщении агентства. Когда именно аппарат покинул Солнечную систему, в NASA не уточнили.

Сообщения о том, что «Вояджер-1», возможно, покинул пределы Солнечной системы, на основании расчетов различных групп ученых появлялись и ранее, однако впоследствии в NASA опровергали их.

«Вояджер-1», запущенный в 1977 году, стал первым аппаратом в истории человечества, вышедшим за пределы Солнечной системы. Ранее в том же году NASA запустила «Вояджер-2», однако он до границы Солнечной системы пока не добрался.

В настоящее время «Вояджер-1» находится на расстоянии примерно в 18,4 миллиарда километров от Земли, что составляет 123 астрономические единицы (1 а.е. равна расстоянию от Земли до Солнца). Ожидается, что энергии от радиоизотопных источников, которые питают аппарат, хватит до 2025 года.</p>",
                ShortDescription = "Космический зонд «Вояджер-1» покинул Солнечную систему и вышел в межзвездное пространство",
                Picture = DataAccessLayer.Create(new Photo
                {
                    SourceUrl = "~/Content/img/del-3-0.png"
                }),
                Title = "Космический зонд «Вояджер-1» покинул Солнечную систему и вышел в межзвездное пространство"
            });
            DataAccessLayer.Create(new BlogPost
            {
                FullText = @"<p>Космический зонд «Вояджер-1» покинул Солнечную систему и вышел в межзвездное пространство, официально сообщили в NASA.

В NASA пояснили, что соответствующие выводы были сделаны на основании анализа последних данных, полученных от аппарата. «Теперь мы определенно можем ответить на вопрос а там ли мы?: да, мы там», - говорится в сообщении агентства. Когда именно аппарат покинул Солнечную систему, в NASA не уточнили.

Сообщения о том, что «Вояджер-1», возможно, покинул пределы Солнечной системы, на основании расчетов различных групп ученых появлялись и ранее, однако впоследствии в NASA опровергали их.

«Вояджер-1», запущенный в 1977 году, стал первым аппаратом в истории человечества, вышедшим за пределы Солнечной системы. Ранее в том же году NASA запустила «Вояджер-2», однако он до границы Солнечной системы пока не добрался.

В настоящее время «Вояджер-1» находится на расстоянии примерно в 18,4 миллиарда километров от Земли, что составляет 123 астрономические единицы (1 а.е. равна расстоянию от Земли до Солнца). Ожидается, что энергии от радиоизотопных источников, которые питают аппарат, хватит до 2025 года.</p>",
                ShortDescription = "Космический зонд «Вояджер-1» покинул Солнечную систему и вышел в межзвездное пространство",
                Picture = DataAccessLayer.Create(new Photo
                {
                    SourceUrl = "~/Content/img/del-3-0.png"
                }),
                Title = "Космический зонд «Вояджер-1» покинул Солнечную систему и вышел в межзвездное пространство"
            });
            DataAccessLayer.Create(new BlogPost
            {
                FullText = @"<p>Космический зонд «Вояджер-1» покинул Солнечную систему и вышел в межзвездное пространство, официально сообщили в NASA.

В NASA пояснили, что соответствующие выводы были сделаны на основании анализа последних данных, полученных от аппарата. «Теперь мы определенно можем ответить на вопрос а там ли мы?: да, мы там», - говорится в сообщении агентства. Когда именно аппарат покинул Солнечную систему, в NASA не уточнили.

Сообщения о том, что «Вояджер-1», возможно, покинул пределы Солнечной системы, на основании расчетов различных групп ученых появлялись и ранее, однако впоследствии в NASA опровергали их.

«Вояджер-1», запущенный в 1977 году, стал первым аппаратом в истории человечества, вышедшим за пределы Солнечной системы. Ранее в том же году NASA запустила «Вояджер-2», однако он до границы Солнечной системы пока не добрался.

В настоящее время «Вояджер-1» находится на расстоянии примерно в 18,4 миллиарда километров от Земли, что составляет 123 астрономические единицы (1 а.е. равна расстоянию от Земли до Солнца). Ожидается, что энергии от радиоизотопных источников, которые питают аппарат, хватит до 2025 года.</p>",
                ShortDescription = "Космический зонд «Вояджер-1» покинул Солнечную систему и вышел в межзвездное пространство",
                Picture = DataAccessLayer.Create(new Photo
                {
                    SourceUrl = "~/Content/img/del-3-0.png"
                }),
                Title = "Космический зонд «Вояджер-1» покинул Солнечную систему и вышел в межзвездное пространство"
            });
            DataAccessLayer.Create(new BlogPost
            {
                FullText = @"<p>Ученые обнаружили необычное поведение ионов при движении внутри углеродных нанотрубок. Оказалось, что его скорость не прямо возрастает с увеличением диаметра последних, но определяет близостью к оптимальному диаметру поры. Исследование опубликовано в журнале Nature Communications.

Эксперимент проводился на однослойных углеродных нанотрубках с диаметром от 0,6 до 2 нанометров и длиной около одного миллиметра. Наблюдая за тем, как внутри нанотрубок двигаются разные одновалентные катионы (Li+,K+,Cs+, Na+), ученые обнаружили, что скорость этого движения имеет колоколообразную зависимость от диаметра.

Оказалось, что при увеличении диаметра более оптимальных 1,6 нанометров скорость ионов неожиданно падала, а не увеличивалась, как этого можно было ожидать. При оптимальном диаметре она была примерно в пять раз больше, чем при другом в том же диапазоне.

Наблюдение стало неожиданностью для ученых, так как существующие модели не предсказывали такого поведения. По словам исследователей, такое экзотическое поведение может объясняться действием гидратирующей оболочки из молекул воды, которая имеется у каждого иона в растворе. Исследование может иметь важное значение для создания более совершенных элементов питания (где ключевую роль играет транспорт ионов), обессоливания воды или даже секвенирования ДНК методом протаскивания через пору.</p>",
                Picture = DataAccessLayer.Create(new Photo
                {
                    SourceUrl = "~/Content/img/del-3-0.png"
                }),
                ShortDescription = "У ионов в нанотрубках выявили экзотическое поведение",
                Title = "У ионов в нанотрубках выявили экзотическое поведение"
            });
            DataAccessLayer.DbContext.SaveChanges();
        }

        public void addAnonimousUser()
        {
            var user = DataAccessLayer.Create(new PromouterUser
            {
                Email = "anonimous@gmail.com",
                Password = "123",
                IsAdmin = true,
            });

            DataAccessLayer.Create(new Session
            {
                LastHit = DateTime.UtcNow,
                User = user
            });


            var desiredWorkEntity = DataAccessLayer.Create(new EntityList() { });
            var desiredWorkTimeEntity = DataAccessLayer.Create(new EntityList() { });
            var workExperienceEntity = DataAccessLayer.Create(new EntityList() { });

            var works = new[]
                {
                    DataAccessLayer.Get<DictValue>("MERC"),
                    DataAccessLayer.Get<DictValue>("SUPER"),
                    DataAccessLayer.Get<DictValue>("COURIER"),
                    DataAccessLayer.Get<DictValue>("AUDITOR"),
                    DataAccessLayer.Get<DictValue>("BUYER"),
                    DataAccessLayer.Get<DictValue>("PROMOUTER"),
                    DataAccessLayer.Get<DictValue>("ANIMATOR"),
                    DataAccessLayer.Get<DictValue>("PROMO_MODEL"),
                    DataAccessLayer.Get<DictValue>("MASCOT"),
                    DataAccessLayer.Get<DictValue>("INTERVIEWER"),
                    DataAccessLayer.Get<DictValue>("MODEL"),
                    DataAccessLayer.Get<DictValue>("WORKER"),
                    DataAccessLayer.Get<DictValue>("BARMEN"),
                    DataAccessLayer.Get<DictValue>("WAITER"),
                    DataAccessLayer.Get<DictValue>("HOSTESS"),
                };

            foreach (var t in works)
            {
                DataAccessLayer.Create(new DesiredWork
                {
                    EntityList = desiredWorkEntity,
                    Work = t
                });
            }

            for (int i = 0; i < 7; i++)
            {
                DataAccessLayer.Create(new DesiredWorkTime
                {
                    EntityList = desiredWorkTimeEntity,
                    StartTime = new DateTime(2013, 09, 13, 9, 0, 0),
                    EndTime = new DateTime(2013, 09, 13, 12, 0, 0),
                    DayOfWeek = i
                });
                DataAccessLayer.Create(new DesiredWorkTime
                {
                    EntityList = desiredWorkTimeEntity,
                    StartTime = new DateTime(2013, 09, 13, 14, 0, 0),
                    EndTime = new DateTime(2013, 09, 13, 21, 0, 0),
                    DayOfWeek = i
                });
            }

            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Грузчик",
                Title = "МегаМарт",
                Start = new DateTime(2010, 8, 1),
                End = new DateTime(2010, 12, 7),
                Hours = 500,
            });
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Сторож",
                Title = "Гаражный кооператив 'Знамя коммунизма'",
                Start = new DateTime(2010, 12, 19),
                End = new DateTime(2011, 2, 20),
                Hours = 300,
            });
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Подниматель пингвинов",
                Title = "Let it snow research laboratory inc.",
                Start = new DateTime(2011, 3, 1),
                End = new DateTime(2011, 12, 1),
                Hours = 1000,
            });
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Гитарист",
                Title = "Ранетки",
                Start = new DateTime(2012, 2, 1),
                End = new DateTime(2012, 12, 9),
                Hours = 900,
            });
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Автомеханик",
                Title = "СТО Кованый поршень",
                Start = new DateTime(2013, 1, 1),
                End = new DateTime(2013, 8, 1),
                Hours = 700,
            });


            DataAccessLayer.Update(user.MainChecklist, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.LastNameCode),
                    Value = "Вознюкова"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.MiddleNameCode),
                    Value = "Андреевна"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.FirstNameCode),
                    Value = "Екатерина"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.GenderCode),
                    Value = Constants.FemaleCode
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.DateOfBirthCode),
                    Value = new DateTime(1985, 12, 02).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.MedicalBookCode),
                    Value = true.ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CarCode),
                    Value = "Toyuta Alteza"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.MobilePhoneCode),
                    Value = "+7 912 383 3395"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value = Constants.SalaryValuesCode[9]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value = "Тюмень"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EducationCode),
                    Value = Constants.EducationValuesCode[3]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.BuildCode),
                    Value = "Спортивное"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.HeightCode),
                    Value = "176 см."
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WeightCode),
                    Value = "66 кг."
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SkinTypeCode),
                    Value = "Смуглая"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EyeColorCode),
                    Value = "Голубой"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.HairColorCode),
                    Value = "Блондинко"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.HairLengthCode),
                    Value = "Длинные"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SizeClothesCode),
                    Value = "48(M)"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SizeShoesCode),
                    Value = "39"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SizeChestCode),
                    Value = "2"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkExperienceCode),
                    Value = workExperienceEntity.Id.ToString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.DesiredWorkCode),
                    Value = desiredWorkEntity.Id.ToString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.DesiredWorkTimeCode),
                    Value = desiredWorkTimeEntity.Id.ToString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value = "Make love, not war"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.HobbiesCode),
                    Value = "Музыка, сторожить гаражные кооперативы, поднимать пингвинов"
                },
            });

            var mainAlbum = user.Albums.First();
            var avatar = DataAccessLayer.Create(new Photo()
            {
                Album = mainAlbum,
                SourceUrl = "~/Content/img/del-2.png"
            });
            DataAccessLayer.DbContext.SaveChanges();
            user.Avatar = avatar;

            for (var i = 0; i < 5; i++)
            {
                DataAccessLayer.Create(new Photo()
                {
                    Album = mainAlbum,
                    SourceUrl = "~/Content/img/del-5.png"
                });
                DataAccessLayer.Create(new Photo()
                {
                    Album = mainAlbum,
                    SourceUrl = "~/Content/img/del-2.png"
                });
                DataAccessLayer.Create(new Photo()
                {
                    Album = mainAlbum,
                    SourceUrl = "~/Content/img/del-0.png"
                });
            }
            DataAccessLayer.DbContext.SaveChanges();
        }


        public void addUser4()
        {
            var user = DataAccessLayer.Create(new PromouterUser
            {
                Email = "ivan@gmail.com",
                Password = "123",
            });

            DataAccessLayer.Create(new Session
            {
                LastHit = DateTime.UtcNow,
                User = user
            });


            var desiredWorkEntity = DataAccessLayer.Create(new EntityList() { });
            var desiredWorkTimeEntity = DataAccessLayer.Create(new EntityList() { });
            var workExperienceEntity = DataAccessLayer.Create(new EntityList() { });

            var works = new[]
                {
                    DataAccessLayer.Get<DictValue>("MERC"),
                    DataAccessLayer.Get<DictValue>("SUPER"),
                    DataAccessLayer.Get<DictValue>("BUYER"),
                    DataAccessLayer.Get<DictValue>("PROMOUTER"),
                    DataAccessLayer.Get<DictValue>("PROMO_MODEL"),
                    DataAccessLayer.Get<DictValue>("WAITER"),
                    DataAccessLayer.Get<DictValue>("HOSTESS"),
                };

            foreach (var t in works)
            {
                DataAccessLayer.Create(new DesiredWork
                {
                    EntityList = desiredWorkEntity,
                    Work = t
                });
            }

            var random = new Random();
            for (int i = 0; i < 7; i++)
            {

                DataAccessLayer.Create(new DesiredWorkTime
                {
                    EntityList = desiredWorkTimeEntity,
                    StartTime = new DateTime(2013, 09, 13, 8, 45, 0),
                    EndTime = new DateTime(2013, 09, 13, 11, 15, 0),
                    DayOfWeek = i
                });
                if (1 == random.Next(3))
                {
                    DataAccessLayer.Create(new DesiredWorkTime
                    {
                        EntityList = desiredWorkTimeEntity,
                        StartTime = new DateTime(2013, 09, 13, 12, 00, 0),
                        EndTime = new DateTime(2013, 09, 13, 13, 15, 0),
                        DayOfWeek = i
                    });
                }
                if (6 == random.Next(7))
                {
                    DataAccessLayer.Create(new DesiredWorkTime
                    {
                        EntityList = desiredWorkTimeEntity,
                        StartTime = new DateTime(2013, 09, 13, 14, 0, 0),
                        EndTime = new DateTime(2013, 09, 13, 21, 0, 0),
                        DayOfWeek = i
                    });
                }
            }

            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Сортировщик спичек",
                Title = "Спички inc.",
                Start = new DateTime(2010, 9, 1),
                End = new DateTime(2010, 12, 7),
                Hours = 500,
            });
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Сторож",
                Title = "Гаражный кооператив 'Знамя социализма'",
                Start = new DateTime(2011, 1, 19),
                End = new DateTime(2011, 2, 20),
                Hours = 300,
            });
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Подниматель пингвинов",
                Title = "Let it snow research laboratory inc.",
                Start = new DateTime(2011, 3, 1),
                End = new DateTime(2011, 12, 1),
                Hours = 1000,
            });
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Гитарист",
                Title = "Ранетки",
                Start = new DateTime(2012, 2, 1),
                End = new DateTime(2012, 12, 9),
                Hours = 900,
            });
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Автомеханик",
                Title = "СТО Кованый поршень",
                Start = new DateTime(2013, 1, 1),
                End = new DateTime(2013, 9, 1),
                Hours = 700,
            });


            DataAccessLayer.Update(user.MainChecklist, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.LastNameCode),
                    Value = "Пупкин"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.MiddleNameCode),
                    Value = "Васильевич"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.FirstNameCode),
                    Value = "Васильевич"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.GenderCode),
                    Value = Constants.MaleCode
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.DateOfBirthCode),
                    Value = new DateTime(1992, 5, 5).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.MedicalBookCode),
                    Value = false.ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CarCode),
                    Value = "BMW M5"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.MobilePhoneCode),
                    Value = "+7 912 383 6959"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value = Constants.SalaryValuesCode[2]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value = "Махачкала"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EducationCode),
                    Value = Constants.EducationValuesCode[2]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.BuildCode),
                    Value = "Неспротивное"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.HeightCode),
                    Value = "156 см."
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WeightCode),
                    Value = "97 кг."
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SkinTypeCode),
                    Value = "Белая"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EyeColorCode),
                    Value = "Серые"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.HairColorCode),
                    Value = "Шатенка"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.HairLengthCode),
                    Value = "Лысая"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SizeClothesCode),
                    Value = "56(XXL)"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SizeShoesCode),
                    Value = "45"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SizeChestCode),
                    Value = "5"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkExperienceCode),
                    Value = workExperienceEntity.Id.ToString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.DesiredWorkCode),
                    Value = desiredWorkEntity.Id.ToString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.DesiredWorkTimeCode),
                    Value = desiredWorkTimeEntity.Id.ToString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value = "Я такая какая есть"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.HobbiesCode),
                    Value = "Разводить кроликов"
                },
            });

            var mainAlbum = user.Albums.First();
            var avatar = DataAccessLayer.Create(new Photo()
            {
                Album = mainAlbum,
                SourceUrl = "~/Content/img/del-5.png"
            });
            DataAccessLayer.DbContext.SaveChanges();
            user.Avatar = avatar;

            for (var i = 0; i < 5; i++)
            {
                var t = random.Next(5);
                if (t == 1)
                {
                    DataAccessLayer.Create(new Photo()
                    {
                        Album = mainAlbum,
                        SourceUrl = "~/Content/img/del-3.png"
                    });
                }
                if (t == 2)
                {
                    DataAccessLayer.Create(new Photo()
                    {
                        Album = mainAlbum,
                        SourceUrl = "~/Content/img/del-0.png"
                    });
                }
                if (t == 3)
                {
                    DataAccessLayer.Create(new Photo()
                    {
                        Album = mainAlbum,
                        SourceUrl = "~/Content/img/del-2.png"
                    });
                }
            }

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 5
            });
            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 3
            });
            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 4
            });
            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 2
            });
            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 1
            });
            DataAccessLayer.DbContext.SaveChanges();
        }

        public void addUser5()
        {
            var user = DataAccessLayer.Create(new PromouterUser
            {
                Email = "kate@gmail.com",
                Password = "123",
            });

            DataAccessLayer.Create(new Session
            {
                LastHit = DateTime.UtcNow,
                User = user
            });


            var desiredWorkEntity = DataAccessLayer.Create(new EntityList() { });
            var desiredWorkTimeEntity = DataAccessLayer.Create(new EntityList() { });
            var workExperienceEntity = DataAccessLayer.Create(new EntityList() { });

            var works = new[]
                {
                    DataAccessLayer.Get<DictValue>("MERC"),
                    DataAccessLayer.Get<DictValue>("SUPER"),
                    DataAccessLayer.Get<DictValue>("BUYER"),
                    DataAccessLayer.Get<DictValue>("PROMOUTER"),
                    DataAccessLayer.Get<DictValue>("ANIMATOR"),
                    DataAccessLayer.Get<DictValue>("PROMO_MODEL"),
                    DataAccessLayer.Get<DictValue>("WAITER"),
                    DataAccessLayer.Get<DictValue>("HOSTESS"),
                };

            foreach (var t in works)
            {
                DataAccessLayer.Create(new DesiredWork
                {
                    EntityList = desiredWorkEntity,
                    Work = t
                });
            }

            var random = new Random();
            for (int i = 0; i < 7; i++)
            {
                
                DataAccessLayer.Create(new DesiredWorkTime
                {
                    EntityList = desiredWorkTimeEntity,
                    StartTime = new DateTime(2013, 09, 13, 8, 45, 0),
                    EndTime = new DateTime(2013, 09, 13, 11, 15, 0),
                    DayOfWeek = i
                });
                if (1 == random.Next(3))
                {
                    DataAccessLayer.Create(new DesiredWorkTime
                    {
                        EntityList = desiredWorkTimeEntity,
                        StartTime = new DateTime(2013, 09, 13, 12, 00, 0),
                        EndTime = new DateTime(2013, 09, 13, 13, 15, 0),
                        DayOfWeek = i
                    });
                }
                if (6 == random.Next(7))
                {
                    DataAccessLayer.Create(new DesiredWorkTime
                    {
                        EntityList = desiredWorkTimeEntity,
                        StartTime = new DateTime(2013, 09, 13, 14, 0, 0),
                        EndTime = new DateTime(2013, 09, 13, 21, 0, 0),
                        DayOfWeek = i
                    });
                }
            }

            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Сортировщик спичек",
                Title = "Спички inc.",
                Start = new DateTime(2010, 9, 1),
                End = new DateTime(2010, 12, 7),
                Hours = 500,
            });
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Сторож",
                Title = "Гаражный кооператив 'Знамя социализма'",
                Start = new DateTime(2011, 1, 19),
                End = new DateTime(2011, 2, 20),
                Hours = 300,
            });
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Подниматель пингвинов",
                Title = "Let it snow research laboratory inc.",
                Start = new DateTime(2011, 3, 1),
                End = new DateTime(2011, 12, 1),
                Hours = 1000,
            });
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Гитарист",
                Title = "Ранетки",
                Start = new DateTime(2012, 2, 1),
                End = new DateTime(2012, 12, 9),
                Hours = 900,
            });
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Автомеханик",
                Title = "СТО Кованый поршень",
                Start = new DateTime(2013, 1, 1),
                End = new DateTime(2013, 9, 1),
                Hours = 700,
            });


            DataAccessLayer.Update(user.MainChecklist, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.LastNameCode),
                    Value = "Торопышкина"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.MiddleNameCode),
                    Value = "Сергеевна"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.FirstNameCode),
                    Value = "Фроська"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.GenderCode),
                    Value = Constants.FemaleCode
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.DateOfBirthCode),
                    Value = new DateTime(1992, 5, 5).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.MedicalBookCode),
                    Value = false.ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CarCode),
                    Value = "BMW M5"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.MobilePhoneCode),
                    Value = "+7 912 383 6959"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value = Constants.SalaryValuesCode[2]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value = "Махачкала"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EducationCode),
                    Value = Constants.EducationValuesCode[2]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.BuildCode),
                    Value = "Неспротивное"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.HeightCode),
                    Value = "156 см."
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WeightCode),
                    Value = "97 кг."
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SkinTypeCode),
                    Value = "Белая"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EyeColorCode),
                    Value = "Серые"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.HairColorCode),
                    Value = "Шатенка"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.HairLengthCode),
                    Value = "Лысая"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SizeClothesCode),
                    Value = "56(XXL)"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SizeShoesCode),
                    Value = "45"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SizeChestCode),
                    Value = "5"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkExperienceCode),
                    Value = workExperienceEntity.Id.ToString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.DesiredWorkCode),
                    Value = desiredWorkEntity.Id.ToString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.DesiredWorkTimeCode),
                    Value = desiredWorkTimeEntity.Id.ToString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value = "Я такая какая есть"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.HobbiesCode),
                    Value = "Разводить кроликов"
                },
            });

            var mainAlbum = user.Albums.First();
            var avatar = DataAccessLayer.Create(new Photo()
            {
                Album = mainAlbum,
                SourceUrl = "~/Content/img/del-5.png"
            });
            DataAccessLayer.DbContext.SaveChanges();
            user.Avatar = avatar;

            for (var i = 0; i < 5; i++)
            {
                var t = random.Next(5);
                if (t == 1)
                {
                    DataAccessLayer.Create(new Photo()
                    {
                        Album = mainAlbum,
                        SourceUrl = "~/Content/img/del-3.png"
                    });
                }
                if (t == 2)
                {
                    DataAccessLayer.Create(new Photo()
                    {
                        Album = mainAlbum,
                        SourceUrl = "~/Content/img/del-0.png"
                    });
                }
                if (t == 3)
                {
                    DataAccessLayer.Create(new Photo()
                    {
                        Album = mainAlbum,
                        SourceUrl = "~/Content/img/del-2.png"
                    });
                }
            }

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 5
            });
            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 3
            });
            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 4
            });
            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 2
            });
            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 1
            });
            DataAccessLayer.DbContext.SaveChanges();
        }

        public void addUser6()
        {
            var user = DataAccessLayer.Create(new PromouterUser
            {
                Email = "max@gmail.com",
                Password = "123",
            });

            DataAccessLayer.Create(new Session
            {
                LastHit = DateTime.UtcNow,
                User = user
            });


            var desiredWorkEntity = DataAccessLayer.Create(new EntityList() { });
            var desiredWorkTimeEntity = DataAccessLayer.Create(new EntityList() { });
            var workExperienceEntity = DataAccessLayer.Create(new EntityList() { });

            var works = new[]
                {
                    DataAccessLayer.Get<DictValue>("MERC"),
                    DataAccessLayer.Get<DictValue>("SUPER"),
                    DataAccessLayer.Get<DictValue>("BUYER"),
                    DataAccessLayer.Get<DictValue>("PROMOUTER"),
                    DataAccessLayer.Get<DictValue>("PROMO_MODEL"),
                    DataAccessLayer.Get<DictValue>("WAITER"),
                    DataAccessLayer.Get<DictValue>("HOSTESS"),
                };

            foreach (var t in works)
            {
                DataAccessLayer.Create(new DesiredWork
                {
                    EntityList = desiredWorkEntity,
                    Work = t
                });
            }

            var random = new Random();
            for (int i = 0; i < 7; i++)
            {

                DataAccessLayer.Create(new DesiredWorkTime
                {
                    EntityList = desiredWorkTimeEntity,
                    StartTime = new DateTime(2013, 09, 13, 8, 45, 0),
                    EndTime = new DateTime(2013, 09, 13, 11, 15, 0),
                    DayOfWeek = i
                });
                if (1 == random.Next(3))
                {
                    DataAccessLayer.Create(new DesiredWorkTime
                    {
                        EntityList = desiredWorkTimeEntity,
                        StartTime = new DateTime(2013, 09, 13, 12, 00, 0),
                        EndTime = new DateTime(2013, 09, 13, 13, 15, 0),
                        DayOfWeek = i
                    });
                }
                if (6 == random.Next(7))
                {
                    DataAccessLayer.Create(new DesiredWorkTime
                    {
                        EntityList = desiredWorkTimeEntity,
                        StartTime = new DateTime(2013, 09, 13, 14, 0, 0),
                        EndTime = new DateTime(2013, 09, 13, 21, 0, 0),
                        DayOfWeek = i
                    });
                }
            }

            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Сортировщик спичек",
                Title = "Спички inc.",
                Start = new DateTime(2010, 9, 1),
                End = new DateTime(2010, 12, 7),
                Hours = 500,
            });
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Сторож",
                Title = "Гаражный кооператив 'Знамя социализма'",
                Start = new DateTime(2011, 1, 19),
                End = new DateTime(2011, 2, 20),
                Hours = 300,
            });
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Подниматель пингвинов",
                Title = "Let it snow research laboratory inc.",
                Start = new DateTime(2011, 3, 1),
                End = new DateTime(2011, 12, 1),
                Hours = 1000,
            });
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Гитарист",
                Title = "Ранетки",
                Start = new DateTime(2012, 2, 1),
                End = new DateTime(2012, 12, 9),
                Hours = 900,
            });
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Автомеханик",
                Title = "СТО Кованый поршень",
                Start = new DateTime(2013, 1, 1),
                End = new DateTime(2013, 7, 1),
                Hours = 700,
            });


            DataAccessLayer.Update(user.MainChecklist, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.LastNameCode),
                    Value = "Высильев"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.MiddleNameCode),
                    Value = "Владимирович"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.FirstNameCode),
                    Value = "Максим"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.GenderCode),
                    Value = Constants.MaleCode
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.DateOfBirthCode),
                    Value = new DateTime(1992, 5, 5).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.MedicalBookCode),
                    Value = false.ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CarCode),
                    Value = "BMW M5"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.MobilePhoneCode),
                    Value = "+7 912 383 6959"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value = Constants.SalaryValuesCode[2]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value = "Махачкала"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EducationCode),
                    Value = Constants.EducationValuesCode[2]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.BuildCode),
                    Value = "Спортивное"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.HeightCode),
                    Value = "190 см."
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WeightCode),
                    Value = "97 кг."
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SkinTypeCode),
                    Value = "Черная"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EyeColorCode),
                    Value = "Голубые"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.HairColorCode),
                    Value = "Блондин"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.HairLengthCode),
                    Value = "Короткие"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SizeClothesCode),
                    Value = "56(XXL)"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SizeShoesCode),
                    Value = "45"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SizeChestCode),
                    Value = "5"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkExperienceCode),
                    Value = workExperienceEntity.Id.ToString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.DesiredWorkCode),
                    Value = desiredWorkEntity.Id.ToString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.DesiredWorkTimeCode),
                    Value = desiredWorkTimeEntity.Id.ToString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value = "Я такая какая есть"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.HobbiesCode),
                    Value = "Разводить кроликов"
                },
            });

            var mainAlbum = user.Albums.First();

            var avatar = DataAccessLayer.Create(new Photo()
            {
                Album = mainAlbum,
                SourceUrl = "~/Content/img/del-1.png"
            });
            DataAccessLayer.DbContext.SaveChanges();
            user.Avatar = avatar;

            for (var i = 0; i < 5; i++)
            {
                var t = random.Next(5);
                if (t == 1)
                {
                    DataAccessLayer.Create(new Photo()
                    {
                        Album = mainAlbum,
                        SourceUrl = "~/Content/img/del-3.png"
                    });
                }
                if (t == 2)
                {
                    DataAccessLayer.Create(new Photo()
                    {
                        Album = mainAlbum,
                        SourceUrl = "~/Content/img/del-0.png"
                    });
                }
                if (t == 3)
                {
                    DataAccessLayer.Create(new Photo()
                    {
                        Album = mainAlbum,
                        SourceUrl = "~/Content/img/del-2.png"
                    });
                }
            }

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).Last().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 5
            });
            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).Last().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 3
            });
            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 4
            });
            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 2
            });
            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 1
            });

            DataAccessLayer.DbContext.SaveChanges();
        }


        public void addUser7()
        {
            var user = DataAccessLayer.Create(new PromouterUser
            {
                Email = "roma@gmail.com",
                Password = "123",
            });

            DataAccessLayer.Create(new Session
            {
                LastHit = DateTime.UtcNow,
                User = user
            });


            var desiredWorkEntity = DataAccessLayer.Create(new EntityList() { });
            var desiredWorkTimeEntity = DataAccessLayer.Create(new EntityList() { });
            var workExperienceEntity = DataAccessLayer.Create(new EntityList() { });

            var works = new[]
                {
                    DataAccessLayer.Get<DictValue>("MERC"),
                    DataAccessLayer.Get<DictValue>("SUPER"),
                    DataAccessLayer.Get<DictValue>("BUYER"),
                    DataAccessLayer.Get<DictValue>("PROMOUTER"),
                    DataAccessLayer.Get<DictValue>("PROMO_MODEL"),
                    DataAccessLayer.Get<DictValue>("WAITER"),
                    DataAccessLayer.Get<DictValue>("HOSTESS"),
                };

            foreach (var t in works)
            {
                DataAccessLayer.Create(new DesiredWork
                {
                    EntityList = desiredWorkEntity,
                    Work = t
                });
            }

            var random = new Random();
            for (int i = 0; i < 7; i++)
            {

                DataAccessLayer.Create(new DesiredWorkTime
                {
                    EntityList = desiredWorkTimeEntity,
                    StartTime = new DateTime(2013, 09, 13, 8, 45, 0),
                    EndTime = new DateTime(2013, 09, 13, 11, 15, 0),
                    DayOfWeek = i
                });
                if (1 == random.Next(3))
                {
                    DataAccessLayer.Create(new DesiredWorkTime
                    {
                        EntityList = desiredWorkTimeEntity,
                        StartTime = new DateTime(2013, 09, 13, 12, 00, 0),
                        EndTime = new DateTime(2013, 09, 13, 13, 15, 0),
                        DayOfWeek = i
                    });
                }
                if (6 == random.Next(7))
                {
                    DataAccessLayer.Create(new DesiredWorkTime
                    {
                        EntityList = desiredWorkTimeEntity,
                        StartTime = new DateTime(2013, 09, 13, 14, 0, 0),
                        EndTime = new DateTime(2013, 09, 13, 21, 0, 0),
                        DayOfWeek = i
                    });
                }
            }

            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Сортировщик спичек",
                Title = "Спички inc.",
                Start = new DateTime(2010, 9, 1),
                End = new DateTime(2010, 12, 7),
                Hours = 500,
            });
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Сторож",
                Title = "Гаражный кооператив 'Знамя социализма'",
                Start = new DateTime(2011, 1, 19),
                End = new DateTime(2011, 2, 20),
                Hours = 300,
            });
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Подниматель пингвинов",
                Title = "Let it snow research laboratory inc.",
                Start = new DateTime(2011, 3, 1),
                End = new DateTime(2011, 12, 1),
                Hours = 1000,
            });
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Гитарист",
                Title = "Ранетки",
                Start = new DateTime(2012, 2, 1),
                End = new DateTime(2012, 12, 9),
                Hours = 900,
            });
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Автомеханик",
                Title = "СТО Кованый поршень",
                Start = new DateTime(2013, 1, 1),
                End = new DateTime(2013, 6, 1),
                Hours = 700,
            });


            DataAccessLayer.Update(user.MainChecklist, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.LastNameCode),
                    Value = "Нововсильцев"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.MiddleNameCode),
                    Value = "Геннадиевич"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.FirstNameCode),
                    Value = "Роман"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.GenderCode),
                    Value = Constants.MaleCode
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.DateOfBirthCode),
                    Value = new DateTime(1992, 5, 5).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.MedicalBookCode),
                    Value = false.ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CarCode),
                    Value = "BMW M5"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.MobilePhoneCode),
                    Value = "+7 912 383 6959"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value = Constants.SalaryValuesCode[2]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value = "Махачкала"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EducationCode),
                    Value = Constants.EducationValuesCode[2]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.BuildCode),
                    Value = "Неспротивное"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.HeightCode),
                    Value = "156 см."
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WeightCode),
                    Value = "97 кг."
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SkinTypeCode),
                    Value = "Белая"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EyeColorCode),
                    Value = "Серые"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.HairColorCode),
                    Value = "Брюнет"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.HairLengthCode),
                    Value = "Лысый"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SizeClothesCode),
                    Value = "58(XXL)"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SizeShoesCode),
                    Value = "45"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkExperienceCode),
                    Value = workExperienceEntity.Id.ToString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.DesiredWorkCode),
                    Value = desiredWorkEntity.Id.ToString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.DesiredWorkTimeCode),
                    Value = desiredWorkTimeEntity.Id.ToString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value = "Люблю пить и есть"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.HobbiesCode),
                    Value = "<b>Собирать</b> <i>и</i> <del>разбирать</del> машину"
                },
            });

            var mainAlbum = user.Albums.First();
            var avatar = DataAccessLayer.Create(new Photo()
            {
                Album = mainAlbum,
                SourceUrl = "~/Content/img/del-4.png"
            });
            DataAccessLayer.DbContext.SaveChanges();
            user.Avatar = avatar;

            for (var i = 0; i < 5; i++)
            {
                var t = random.Next(5);
                if (t == 1)
                {
                    DataAccessLayer.Create(new Photo()
                    {
                        Album = mainAlbum,
                        SourceUrl = "~/Content/img/del-1.png"
                    });
                }
                if (t == 2)
                {
                    DataAccessLayer.Create(new Photo()
                    {
                        Album = mainAlbum,
                        SourceUrl = "~/Content/img/del-0.png"
                    });
                }
                if (t == 3)
                {
                    DataAccessLayer.Create(new Photo()
                    {
                        Album = mainAlbum,
                        SourceUrl = "~/Content/img/del-5.png"
                    });
                }
            }

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).Last().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 5
            });
            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).Last().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Съешь еще этих мягких мексиканских кактусов",
                Rating = 3
            });
            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 4
            });
            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 2
            });
            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
				Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 1
            });

            DataAccessLayer.DbContext.SaveChanges();
        }



        public void addUser8()
        {
            var user = DataAccessLayer.Create(new PromouterUser
            {
                Email = "roma@gmail.com",
                Password = "123",
            });

            DataAccessLayer.Create(new Session
            {
                LastHit = DateTime.UtcNow,
                User = user
            });


            var desiredWorkEntity = DataAccessLayer.Create(new EntityList() { });
            var desiredWorkTimeEntity = DataAccessLayer.Create(new EntityList() { });
            var workExperienceEntity = DataAccessLayer.Create(new EntityList() { });

            var works = new[]
                {
                    DataAccessLayer.Get<DictValue>("MERC"),
                    DataAccessLayer.Get<DictValue>("SUPER"),
                    DataAccessLayer.Get<DictValue>("BUYER"),
                    DataAccessLayer.Get<DictValue>("PROMOUTER"),
                    DataAccessLayer.Get<DictValue>("PROMO_MODEL"),
                    DataAccessLayer.Get<DictValue>("WAITER"),
                    DataAccessLayer.Get<DictValue>("HOSTESS"),
                };

            foreach (var t in works)
            {
                DataAccessLayer.Create(new DesiredWork
                {
                    EntityList = desiredWorkEntity,
                    Work = t
                });
            }

            var random = new Random();
            for (int i = 0; i < 7; i++)
            {

                DataAccessLayer.Create(new DesiredWorkTime
                {
                    EntityList = desiredWorkTimeEntity,
                    StartTime = new DateTime(2013, 09, 13, 8, 45, 0),
                    EndTime = new DateTime(2013, 09, 13, 11, 15, 0),
                    DayOfWeek = i
                });
                if (1 == random.Next(3))
                {
                    DataAccessLayer.Create(new DesiredWorkTime
                    {
                        EntityList = desiredWorkTimeEntity,
                        StartTime = new DateTime(2013, 09, 13, 12, 00, 0),
                        EndTime = new DateTime(2013, 09, 13, 13, 15, 0),
                        DayOfWeek = i
                    });
                }
                if (6 == random.Next(7))
                {
                    DataAccessLayer.Create(new DesiredWorkTime
                    {
                        EntityList = desiredWorkTimeEntity,
                        StartTime = new DateTime(2013, 09, 13, 14, 0, 0),
                        EndTime = new DateTime(2013, 09, 13, 21, 0, 0),
                        DayOfWeek = i
                    });
                }
            }

            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Сортировщик спичек",
                Title = "Спички inc.",
                Start = new DateTime(2010, 9, 1),
                End = new DateTime(2010, 12, 7),
                Hours = 500,
            });
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Сторож",
                Title = "Гаражный кооператив 'Знамя социализма'",
                Start = new DateTime(2011, 1, 19),
                End = new DateTime(2011, 2, 20),
                Hours = 300,
            });
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Подниматель пингвинов",
                Title = "Let it snow research laboratory inc.",
                Start = new DateTime(2011, 3, 1),
                End = new DateTime(2011, 12, 1),
                Hours = 1000,
            });
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Гитарист",
                Title = "Ранетки",
                Start = new DateTime(2012, 2, 1),
                End = new DateTime(2012, 12, 9),
                Hours = 900,
            });
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = workExperienceEntity,
                WorkName = "Автомеханик",
                Title = "СТО Кованый поршень",
                Start = new DateTime(2013, 1, 1),
                End = new DateTime(2013, 6, 1),
                Hours = 700,
            });


            DataAccessLayer.Update(user.MainChecklist, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.LastNameCode),
                    Value = "Нововсильцев"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.MiddleNameCode),
                    Value = "Геннадиевич"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.FirstNameCode),
                    Value = "Роман"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.GenderCode),
                    Value = Constants.MaleCode
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.DateOfBirthCode),
                    Value = new DateTime(1992, 5, 5).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.MedicalBookCode),
                    Value = false.ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CarCode),
                    Value = "BMW M5"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.MobilePhoneCode),
                    Value = "+7 912 383 6959"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value = Constants.SalaryValuesCode[2]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value = "Москва"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EducationCode),
                    Value = Constants.EducationValuesCode[2]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.BuildCode),
                    Value = "Неспротивное"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.HeightCode),
                    Value = "156 см."
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WeightCode),
                    Value = "97 кг."
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SkinTypeCode),
                    Value = "Белая"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EyeColorCode),
                    Value = "Серые"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.HairColorCode),
                    Value = "Брюнет"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.HairLengthCode),
                    Value = "Лысый"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SizeClothesCode),
                    Value = "58(XXL)"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SizeShoesCode),
                    Value = "45"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkExperienceCode),
                    Value = workExperienceEntity.Id.ToString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.DesiredWorkCode),
                    Value = desiredWorkEntity.Id.ToString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.DesiredWorkTimeCode),
                    Value = desiredWorkTimeEntity.Id.ToString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value = "Люблю пить и есть"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.HobbiesCode),
                    Value = "<b>Собирать</b> <i>и</i> <del>разбирать</del> машину"
                },
            });

            var mainAlbum = user.Albums.First();
            var avatar = DataAccessLayer.Create(new Photo()
            {
                Album = mainAlbum,
                SourceUrl = "~/Content/img/del-0.png"
            });
            DataAccessLayer.DbContext.SaveChanges();
            user.Avatar = avatar;

            for (var i = 0; i < 5; i++)
            {
                var t = random.Next(5);
                if (t == 1)
                {
                    DataAccessLayer.Create(new Photo()
                    {
                        Album = mainAlbum,
                        SourceUrl = "~/Content/img/del-1.png"
                    });
                }
                if (t == 2)
                {
                    DataAccessLayer.Create(new Photo()
                    {
                        Album = mainAlbum,
                        SourceUrl = "~/Content/img/del-0.png"
                    });
                }
                if (t == 3)
                {
                    DataAccessLayer.Create(new Photo()
                    {
                        Album = mainAlbum,
                        SourceUrl = "~/Content/img/del-5.png"
                    });
                }
            }

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).Last().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 5
            });
       
            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 1
            });

            DataAccessLayer.DbContext.SaveChanges();
        }



        public void addUser9()
        {
            var user = DataAccessLayer.Create(new EmployerUser
            {
                Email = "roga@gmail.com",
                Password = "123",
            });

            DataAccessLayer.Create(new Session
            {
                LastHit = DateTime.UtcNow,
                User = user
            });

            DataAccessLayer.Update(user.MainChecklist, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EmployerNameCode),
                    Value = "Рога и копытца"
                },


                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AddressCode),
                    Value = "ул. Мебели, 14, офис 12"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.MobilePhoneCode),
                    Value = "+7 912 383 6959"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value = "Москва"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value = "Сделаем все что вы хотите."
                },
            });

            var mainAlbum = user.Albums.First();
            var avatar = DataAccessLayer.Create(new Photo()
            {
                Album = mainAlbum,
                SourceUrl = "~/Content/img/del-1-4.png"
            });
            DataAccessLayer.DbContext.SaveChanges();
            user.Avatar = avatar;

            for (var i = 0; i < 5; i++)
            {
                DataAccessLayer.Create(new Photo()
                {
                    Album = mainAlbum,
                    SourceUrl = "~/Content/img/del-1-2.png"
                });
                DataAccessLayer.Create(new Photo()
                {
                    Album = mainAlbum,
                    SourceUrl = "~/Content/img/del-1-4.png"
                });
                DataAccessLayer.Create(new Photo()
                {
                    Album = mainAlbum,
                    SourceUrl = "~/Content/img/del-1-0.png"
                });
            }

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).Last().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 5
            });

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 3
            });

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).OrderBy(x => new Guid()).Last().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 1
            });

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 1
            });


            DataAccessLayer.Create(user, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value =  Constants.SalaryValuesCode[0]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.StartWorkCode),
                    Value =  new DateTime(2013, 1,1).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EndWorkCode),
                    Value =  new DateTime(2013, 9, 29).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value =  "But I must explain to you how all this mistaken idea of denouncing pleasure.",
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value =  "Норильск"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.GenderCode),
                    Value = Constants.FemaleCode,
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkCode),
                    Value = "MERC"
                },
            });

            DataAccessLayer.Create(user, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value =  Constants.SalaryValuesCode[1]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.StartWorkCode),
                    Value =  new DateTime(2012, 1,1).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EndWorkCode),
                    Value =  new DateTime(2013, 4, 5).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value =  "But I must explain to you how all this mistaken idea of denouncing pleasure.",
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value =  "Махачкала"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.GenderCode),
                    Value = Constants.MaleCode,
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkCode),
                    Value = "WORKER"
                },
            });

            DataAccessLayer.Create(user, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value =  Constants.SalaryValuesCode[3]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.StartWorkCode),
                    Value =  new DateTime(2012, 1,1).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EndWorkCode),
                    Value =  new DateTime(2013, 4, 5).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value =  "Описание работы",
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value =  "Тюмень"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkCode),
                    Value = "MERC"
                },
            });

            DataAccessLayer.Create(user, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value =  Constants.SalaryValuesCode[1]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.StartWorkCode),
                    Value =  new DateTime(2012, 1,1).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EndWorkCode),
                    Value =  new DateTime(2013, 4, 5).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value =  "Стационар, куриные котлетки",
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value =  "Тюмень"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkCode),
                    Value = "WORKER"
                },
            });
            DataAccessLayer.DbContext.SaveChanges();
        }


        public void addUser10()
        {
            var user = DataAccessLayer.Create(new EmployerUser
            {
                Email = "roof@gmail.com",
                Password = "123",
            });

            DataAccessLayer.Create(new Session
            {
                LastHit = DateTime.UtcNow,
                User = user
            });

            DataAccessLayer.Update(user.MainChecklist, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EmployerNameCode),
                    Value = "Рожочки и копытца"
                },


                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AddressCode),
                    Value = "ул. Тюменская, 14, офис 12"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.MobilePhoneCode),
                    Value = "+7 912 383 6959"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value = "Тюмень"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value = "Сделаем все что вы хотите."
                },
            });

            var mainAlbum = user.Albums.First();
            var avatar = DataAccessLayer.Create(new Photo()
            {
                Album = mainAlbum,
                SourceUrl = "~/Content/img/del-1-3.png"
            });
            DataAccessLayer.DbContext.SaveChanges();
            user.Avatar = avatar;

            for (var i = 0; i < 5; i++)
            {
                DataAccessLayer.Create(new Photo()
                {
                    Album = mainAlbum,
                    SourceUrl = "~/Content/img/del-1-3.png"
                });
                DataAccessLayer.Create(new Photo()
                {
                    Album = mainAlbum,
                    SourceUrl = "~/Content/img/del-1-4.png"
                });
                DataAccessLayer.Create(new Photo()
                {
                    Album = mainAlbum,
                    SourceUrl = "~/Content/img/del-1-0.png"
                });
            }

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).Last().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 5
            });

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 3
            });

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).OrderBy(x => new Guid()).Last().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 1
            });

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).OrderBy(x => new Guid()).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 1
            });


            DataAccessLayer.Create(user, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value =  Constants.SalaryValuesCode[0]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.StartWorkCode),
                    Value =  new DateTime(2013, 1,1).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EndWorkCode),
                    Value =  new DateTime(2013, 9, 29).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value =  "But I must explain to you how all this mistaken idea of denouncing pleasure.",
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value =  "Норильск"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.GenderCode),
                    Value = Constants.FemaleCode,
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkCode),
                    Value = "HOSTESS"
                },
            });

            DataAccessLayer.Create(user, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value =  Constants.SalaryValuesCode[1]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.StartWorkCode),
                    Value =  new DateTime(2012, 1,1).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EndWorkCode),
                    Value =  new DateTime(2013, 4, 5).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value =  "But I must explain to you how all this mistaken idea of denouncing pleasure.",
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value =  "Москва"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.GenderCode),
                    Value = Constants.MaleCode,
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkCode),
                    Value = "WAITER"
                },
            });

            DataAccessLayer.Create(user, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value =  Constants.SalaryValuesCode[3]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.StartWorkCode),
                    Value =  new DateTime(2012, 1,1).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EndWorkCode),
                    Value =  new DateTime(2013, 4, 5).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value =  "Описание работы",
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value =  "Тюмень"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkCode),
                    Value = "MERC"
                },
            });

            DataAccessLayer.Create(user, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value =  Constants.SalaryValuesCode[1]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.StartWorkCode),
                    Value =  new DateTime(2012, 1,1).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EndWorkCode),
                    Value =  new DateTime(2013, 4, 5).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value =  "Стационар, куриные котлетки",
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value =  "Тюмень"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkCode),
                    Value = "MERC"
                },
            });
            DataAccessLayer.DbContext.SaveChanges();
        }

        public void addUser11()
        {
            var user = DataAccessLayer.Create(new EmployerUser
            {
                Email = "pupkin@gmail.com",
                Password = "123",
            });

            DataAccessLayer.Create(new Session
            {
                LastHit = DateTime.UtcNow,
                User = user
            });


            var desiredWorkEntity = DataAccessLayer.Create(new EntityList() { });
            var desiredWorkTimeEntity = DataAccessLayer.Create(new EntityList() { });
            var workExperienceEntity = DataAccessLayer.Create(new EntityList() { });

            DataAccessLayer.Update(user.MainChecklist, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EmployerNameCode),
                    Value = "Пупкин и Ко"
                },


                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AddressCode),
                    Value = "ул. Тюменская, 14, офис 12"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.MobilePhoneCode),
                    Value = "+7 912 383 6959"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value = "Тюмень"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value = "Сделаем все что вы хотите."
                },
            });

            var mainAlbum = user.Albums.First();
            var avatar = DataAccessLayer.Create(new Photo()
            {
                Album = mainAlbum,
                SourceUrl = "~/Content/img/del-1-1.png"
            });
            DataAccessLayer.DbContext.SaveChanges();
            user.Avatar = avatar;

            for (var i = 0; i < 5; i++)
            {
                DataAccessLayer.Create(new Photo()
                {
                    Album = mainAlbum,
                    SourceUrl = "~/Content/img/del-1-3.png"
                });
                DataAccessLayer.Create(new Photo()
                {
                    Album = mainAlbum,
                    SourceUrl = "~/Content/img/del-1-4.png"
                });
                DataAccessLayer.Create(new Photo()
                {
                    Album = mainAlbum,
                    SourceUrl = "~/Content/img/del-1-0.png"
                });
            }

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).Last().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 5
            });

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 3
            });

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).OrderBy(x => new Guid()).Last().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 1
            });

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).OrderBy(x => new Guid()).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 1
            });


            DataAccessLayer.Create(user, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value =  Constants.SalaryValuesCode[0]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.StartWorkCode),
                    Value =  new DateTime(2013, 1,1).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EndWorkCode),
                    Value =  new DateTime(2013, 9, 29).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value =  "But I must explain to you how all this mistaken idea of denouncing pleasure.",
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value =  "Норильск"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.GenderCode),
                    Value = Constants.FemaleCode,
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkCode),
                    Value = "HOSTESS"
                },
            });

            DataAccessLayer.Create(user, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value =  Constants.SalaryValuesCode[1]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.StartWorkCode),
                    Value =  new DateTime(2012, 1,1).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EndWorkCode),
                    Value =  new DateTime(2013, 4, 5).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value =  "But I must explain to you how all this mistaken idea of denouncing pleasure.",
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value =  "Москва"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.GenderCode),
                    Value = Constants.MaleCode,
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkCode),
                    Value = "WAITER"
                },
            });

            DataAccessLayer.Create(user, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value =  Constants.SalaryValuesCode[3]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.StartWorkCode),
                    Value =  new DateTime(2012, 1,1).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EndWorkCode),
                    Value =  new DateTime(2013, 4, 5).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value =  "Описание работы",
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value =  "Тюмень"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkCode),
                    Value = "MERC"
                },
            });

            DataAccessLayer.Create(user, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value =  Constants.SalaryValuesCode[1]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.StartWorkCode),
                    Value =  new DateTime(2012, 1,1).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EndWorkCode),
                    Value =  new DateTime(2013, 4, 5).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value =  "Стационар, куриные котлетки",
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value =  "Тюмень"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkCode),
                    Value = "MERC"
                },
            });
            DataAccessLayer.DbContext.SaveChanges();
        }

        public void addUser12()
        {
            var user = DataAccessLayer.Create(new EmployerUser
            {
                Email = "KoKo@gmail.com",
                Password = "123",
            });

            DataAccessLayer.Create(new Session
            {
                LastHit = DateTime.UtcNow,
                User = user
            });

            DataAccessLayer.Update(user.MainChecklist, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EmployerNameCode),
                    Value = "Ко и Ко"
                },


                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AddressCode),
                    Value = "ул. Тюменская, 14, офис 12"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.MobilePhoneCode),
                    Value = "+7 912 383 6959"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value = "Тюмень"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value = "Сделаем все что вы хотите."
                },
            });

            var mainAlbum = user.Albums.First();
            var avatar = DataAccessLayer.Create(new Photo()
            {
                Album = mainAlbum,
                SourceUrl = "~/Content/img/del-1-1.png"
            });
            DataAccessLayer.DbContext.SaveChanges();
            user.Avatar = avatar;

            for (var i = 0; i < 5; i++)
            {
                DataAccessLayer.Create(new Photo()
                {
                    Album = mainAlbum,
                    SourceUrl = "~/Content/img/del-1-3.png"
                });
                DataAccessLayer.Create(new Photo()
                {
                    Album = mainAlbum,
                    SourceUrl = "~/Content/img/del-1-4.png"
                });
                DataAccessLayer.Create(new Photo()
                {
                    Album = mainAlbum,
                    SourceUrl = "~/Content/img/del-1-0.png"
                });
            }

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).Last().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Rating = 5
            });

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system.",
                Rating = 3
            });

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).OrderBy(x => new Guid()).Last().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system.",
                Rating = 1
            });

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).OrderBy(x => new Guid()).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system.",
                Rating = 1
            });


            DataAccessLayer.Create(user, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value =  Constants.SalaryValuesCode[0]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.StartWorkCode),
                    Value =  new DateTime(2013, 1, 1).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EndWorkCode),
                    Value =  new DateTime(2013, 9, 29).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value =  "But I must explain to you how all this mistaken idea of denouncing pleasure.",
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value =  "Норильск"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.GenderCode),
                    Value = Constants.FemaleCode,
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkCode),
                    Value = "HOSTESS"
                },
            });

            DataAccessLayer.Create(user, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value =  Constants.SalaryValuesCode[1]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.StartWorkCode),
                    Value =  new DateTime(2012, 1,1).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EndWorkCode),
                    Value =  new DateTime(2013, 4, 5).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value =  "But I must explain to you how all this mistaken idea of denouncing pleasure.",
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value =  "Москва"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.GenderCode),
                    Value = Constants.MaleCode,
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkCode),
                    Value = "WAITER"
                },
            });

            DataAccessLayer.Create(user, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value =  Constants.SalaryValuesCode[3]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.StartWorkCode),
                    Value =  new DateTime(2012, 1,1).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EndWorkCode),
                    Value =  new DateTime(2013, 4, 5).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value =  "Описание работы",
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value =  "Тюмень"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkCode),
                    Value = "MERC"
                },
            });

            DataAccessLayer.Create(user, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value =  Constants.SalaryValuesCode[1]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.StartWorkCode),
                    Value =  new DateTime(2012, 1,1).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EndWorkCode),
                    Value =  new DateTime(2013, 4, 5).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value =  "Стационар, куриные котлетки",
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value =  "Тюмень"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkCode),
                    Value = "MERC"
                },
            });
            DataAccessLayer.DbContext.SaveChanges();
        }

        public void addUser13()
        {
            var user = DataAccessLayer.Create(new EmployerUser
            {
                Email = "sidorov@gmail.com",
                Password = "123",
            });

            DataAccessLayer.Create(new Session
            {
                LastHit = DateTime.UtcNow,
                User = user
            });

            DataAccessLayer.Update(user.MainChecklist, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EmployerNameCode),
                    Value = "Сидоров и Ко"
                },


                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AddressCode),
                    Value = "ул. Тюменская, 14, офис 12"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.MobilePhoneCode),
                    Value = "+7 912 383 6959"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value = "Тюмень"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value = "Сделаем все что вы хотите."
                },
            });

            var mainAlbum = user.Albums.First();
            var avatar = DataAccessLayer.Create(new Photo()
            {
                Album = mainAlbum,
                SourceUrl = "~/Content/img/del-1-1.png"
            });
            DataAccessLayer.DbContext.SaveChanges();
            user.Avatar = avatar;

            for (var i = 0; i < 5; i++)
            {
                DataAccessLayer.Create(new Photo()
                {
                    Album = mainAlbum,
                    SourceUrl = "~/Content/img/del-1-3.png"
                });
                DataAccessLayer.Create(new Photo()
                {
                    Album = mainAlbum,
                    SourceUrl = "~/Content/img/del-1-4.png"
                });
                DataAccessLayer.Create(new Photo()
                {
                    Album = mainAlbum,
                    SourceUrl = "~/Content/img/del-1-0.png"
                });
            }

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).Last().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system.",
                Rating = 5
            });

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system.",
                Rating = 3
            });

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).OrderBy(x => new Guid()).Last().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system.",
                Rating = 1
            });

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).OrderBy(x => new Guid()).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system.",
                Rating = 1
            });


            DataAccessLayer.Create(user, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value =  Constants.SalaryValuesCode[0]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.StartWorkCode),
                    Value =  new DateTime(2013, 1,1).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EndWorkCode),
                    Value =  new DateTime(2013, 9, 29).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value =  "But I must explain to you how all this mistaken idea of denouncing pleasure.",
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value =  "Норильск"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.GenderCode),
                    Value = Constants.FemaleCode,
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkCode),
                    Value = "HOSTESS"
                },
            });

            DataAccessLayer.Create(user, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value =  Constants.SalaryValuesCode[1]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.StartWorkCode),
                    Value =  new DateTime(2012, 1,1).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EndWorkCode),
                    Value =  new DateTime(2013, 4, 5).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value =  "But I must explain to you how all this mistaken idea of denouncing pleasure.",
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value =  "Москва"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.GenderCode),
                    Value = Constants.MaleCode,
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkCode),
                    Value = "WAITER"
                },
            });

            DataAccessLayer.Create(user, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value =  Constants.SalaryValuesCode[3]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.StartWorkCode),
                    Value =  new DateTime(2012, 1,1).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EndWorkCode),
                    Value =  new DateTime(2013, 4, 5).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value =  "Описание работы",
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value =  "Тюмень"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkCode),
                    Value = "MERC"
                },
            });

            DataAccessLayer.Create(user, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value =  Constants.SalaryValuesCode[1]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.StartWorkCode),
                    Value =  new DateTime(2012, 1,1).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EndWorkCode),
                    Value =  new DateTime(2013, 4, 5).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value =  "Стационар, куриные котлетки",
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value =  "Тюмень"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkCode),
                    Value = "MERC"
                },
            });
            DataAccessLayer.DbContext.SaveChanges();
        }


        public void addUser14()
        {
            var user = DataAccessLayer.Create(new EmployerUser
            {
                Email = "petrov@gmail.com",
                Password = "123",
            });

            DataAccessLayer.Create(new Session
            {
                LastHit = DateTime.UtcNow,
                User = user
            });

            DataAccessLayer.Update(user.MainChecklist, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EmployerNameCode),
                    Value = "Петров и Ко"
                },


                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AddressCode),
                    Value = "ул. Тюменская, 14, офис 12"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.MobilePhoneCode),
                    Value = "+7 912 383 6959"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value = "Тюмень"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value = "Сделаем все что вы хотите."
                },
            });

            var mainAlbum = user.Albums.First();
            var avatar = DataAccessLayer.Create(new Photo()
            {
                Album = mainAlbum,
                SourceUrl = "~/Content/img/del-1-1.png"
            });
            DataAccessLayer.DbContext.SaveChanges();
            user.Avatar = avatar;

            for (var i = 0; i < 5; i++)
            {
                DataAccessLayer.Create(new Photo()
                {
                    Album = mainAlbum,
                    SourceUrl = "~/Content/img/del-1-3.png"
                });
                DataAccessLayer.Create(new Photo()
                {
                    Album = mainAlbum,
                    SourceUrl = "~/Content/img/del-1-4.png"
                });
                DataAccessLayer.Create(new Photo()
                {
                    Album = mainAlbum,
                    SourceUrl = "~/Content/img/del-1-0.png"
                });
            }

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).Last().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system.",
                Rating = 5
            });

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "But occasionally circumstances occur in which toil and pain can procure him some great pleasure. To take a trivial example, which of us ever undertakes laborious physical exercise, except to obtain some advantage from it? But who has any right to find fault with a man who chooses to enjoy a pleasure that has no annoying consequences, or one who avoids a pain that produces no resultant pleasure?",
                Rating = 3
            });

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).OrderBy(x => new Guid()).Last().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system.",
                Rating = 1
            });

            DataAccessLayer.Create(new Review
            {
                AuthorId = DataAccessLayer.Get<UserBase>(x => x.Id != user.Id).OrderBy(x => new Guid()).First().Id,
                RecieverId = user.Id,
                Title = "Lorem ipsum",
                Text = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system.",
				Rating = 1
            });


            DataAccessLayer.Create(user, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value =  Constants.SalaryValuesCode[0]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.StartWorkCode),
                    Value =  new DateTime(2013, 1,1).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EndWorkCode),
                    Value =  new DateTime(2013, 9, 29).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value =  "But I must explain to you how all this mistaken idea of denouncing pleasure.",
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value =  "Норильск"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.GenderCode),
                    Value = Constants.FemaleCode,
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkCode),
                    Value = "HOSTESS"
                },
            });

            DataAccessLayer.Create(user, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value =  Constants.SalaryValuesCode[1]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.StartWorkCode),
                    Value =  new DateTime(2012, 1,1).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EndWorkCode),
                    Value =  new DateTime(2013, 4, 5).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value =  "But I must explain to you how all this mistaken idea of denouncing pleasure.",
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value =  "Москва"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.GenderCode),
                    Value = Constants.MaleCode,
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkCode),
                    Value = "WAITER"
                },
            });

            DataAccessLayer.Create(user, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value =  Constants.SalaryValuesCode[3]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.StartWorkCode),
                    Value =  new DateTime(2012, 1,1).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EndWorkCode),
                    Value =  new DateTime(2013, 4, 5).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value =  "Описание работы",
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value =  "Тюмень"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkCode),
                    Value = "MERC"
                },
            });

            DataAccessLayer.Create(user, new List<AttribValue>
            {
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.SalaryCode),
                    Value =  Constants.SalaryValuesCode[1]
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.StartWorkCode),
                    Value =  new DateTime(2012, 1,1).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.EndWorkCode),
                    Value =  new DateTime(2013, 4, 5).ToPandaString()
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.AboutCode),
                    Value =  "Стационар, куриные котлетки",
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.CityCode),
                    Value =  "Тюмень"
                },
                new AttribValue
                {
                    Attrib = DataAccessLayer.Get<Attrib>(Constants.WorkCode),
                    Value = "MERC"
                },
            });
            DataAccessLayer.DbContext.SaveChanges();
        }
    }
}
