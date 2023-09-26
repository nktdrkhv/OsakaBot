namespace Osaka.Bot.DatabaseSpecific;

public class DataSeed
{
    public void Initialize(BotDbContext context)
    {
        #region Roles

        UserRole anon = new() { Name = "Анонимный пользователь" };
        UserRole guest = new() { Name = "Гость" };
        UserRole resident = new() { Name = "Резидент" };
        UserRole eventTenant = new() { Name = "Событийный арендатор" };
        UserRole constantTenant = new() { Name = "Арендатор" };
        UserRole worker = new() { Name = "Сотрудник" };

        #endregion

        #region Files

        context.AddRange(anon, guest, resident, eventTenant, constantTenant, worker);
        context.SaveChanges();

        Media[] mainF = new Media[]
        {
            new Media(MediaType.Photo, path: "Files/Main/1.png"),
            new Media(MediaType.Photo, path: "Files/Main/2.png"),
            new Media(MediaType.Photo, path: "Files/Main/3.png"),
            new Media(MediaType.Photo, path: "Files/Main/4.png"),
            new Media(MediaType.Photo, path: "Files/Main/5.png"),
            new Media(MediaType.Photo, path: "Files/Main/6.png"),
            new Media(MediaType.Photo, path: "Files/Main/7.png"),
            new Media(MediaType.Photo, path: "Files/Main/8.png"),
            new Media(MediaType.Photo, path: "Files/Main/9.png"),
            new Media(MediaType.Photo, path: "Files/Main/10.png"),
            new Media(MediaType.Photo, path: "Files/Main/11.png"),
            new Media(MediaType.Photo, path: "Files/Main/12.png"),
            new Media(MediaType.Photo, path: "Files/Main/13.png"),
            new Media(MediaType.Photo, path: "Files/Main/14.png"),
            new Media(MediaType.Photo, path: "Files/Main/15.png"),
            new Media(MediaType.Photo, path: "Files/Main/16.png"),
            new Media(MediaType.Photo, path: "Files/Main/17.png"),
            new Media(MediaType.Photo, path: "Files/Main/18.png"),
            new Media(MediaType.Photo, path: "Files/Main/19.png"),
            new Media(MediaType.Photo, path: "Files/Main/20.png"),
            new Media(MediaType.Photo, path: "Files/Main/21.png"),
            new Media(MediaType.Photo, path: "Files/Main/22.png"),
            new Media(MediaType.Photo, path: "Files/Main/23.png"),
        };
        context.AddRange(mainF);
        context.SaveChanges();

        Media[] optF = new Media[]
        {
            new Media(MediaType.Photo, path: "Files/Options/v1a.png"),
            new Media(MediaType.Photo, path: "Files/Options/v2a.png"),
            new Media(MediaType.Photo, path: "Files/Options/v3a.png"),
            new Media(MediaType.Photo, path: "Files/Options/v1b.png"),
            new Media(MediaType.Photo, path: "Files/Options/v2b.png"),
            new Media(MediaType.Photo, path: "Files/Options/v3b.png"),
        };
        context.AddRange(optF);
        context.SaveChanges();

        #endregion

        #region Prime posts

        /* предупреждение */
        Post post00 = new()
        {
            Title = "Предупреждение для зарегистрированных",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalPreparedText = "<b>Обратите внимание,</b> ваша текущая роль: <i>{p:role}</i>. При оставлении новой заявки через меню ниже, она может смениться, но <i>её можно вернуть обратно</i>. Нажмите /menu для возврата в основное меню",
                    PreparedText = "<b>Обратите внимание,</b> ваша текущая роль: <i>{0}</i>. При оставлении новой заявки через меню ниже, она может смениться, но <i>её можно вернуть обратно</i>. Нажмите /menu для возврата в основное меню",
                    Surrogates = new[] { new UserRoleTextSetter() { Position = 0 } }
                }
            },
            RoleVisibility = new[] { guest, resident, eventTenant, constantTenant, worker }
        };

        /* первое меню */
        Post post01_1_t1_i1 = new()
        {
            Title = "Первичное меню",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalPreparedText = "<b>Приветствую вас в ОЭЗ Томск!</b>\n\nЯ ваш помощник и проводник. Для навигации используйте кнопки и команды меню (внизу слева).",
                },
                Media = new Media[] { mainF[0] }
            }
        };
        var post01_a = new Post()
        {
            Title = "Назад, узнать об ОЭЗ",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new() { OriginalText = "Нажмите «Назад» для возврата" },
            }
        };

        /* об оэз, инлайн: общие сведения, норм.доки, контакты, инфра */
        Post post02_11_t2_i2 = new()
        {
            Title = "Об ОЭЗ",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalPreparedText = "<b>ОЭЗ “Томск”</b> технико-внедренческого типа создана в 2006 году (до 2055 года).\n\nЗдесь действует особый режим ведения предпринимательской деятельности, может применяться процедура свободной таможенной зоны.\n\nОЭЗ расположена на двух площадках – Южной и Северной, где создана необходимая инфраструктура, находятся объекты резидентов, выделены участки для реализации новых проектов. С 2015 года в ОЭЗ «Томск» разрешена промышленно-производственная деятельность.",
                },
                Media = new Media[] { mainF[1] }
            },
        };

        /* Узнать об ОЭЗ -> Общие сведения */
        // Post post03_111_t2_i2 

        /* сервисы и поддержка, сокр, ссылка */
        Post post04_1111_t7_i3 = new()
        {
            Title = "Сервисы и поддержка",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalPreparedText = "Управляющая компания <i>АО «Особая экономическая зона «Томск»</i> предлагает всестороннюю поддержку и услуги для развития бизнеса резидентов.\n\n → Аренда коммерческих помещений, переговорных комнат и конференц-залов\n → Помощь при строительстве и проектировании\n → Услуги по сопровождению проекта и документации\n → Техническое обслуживание объектов ОЭЗ\n → Консультирование по получению статуса резидента\n → Организация и проведение мероприятий",
                },
                Media = new Media[] { mainF[2] }
            },
        };

        /* льготы */
        Post post05_1112_t8_i4 = new()
        {
            Title = "Льготы",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalPreparedText = "Участники <i>ОЭЗ «Томск»</i> имеют различные привелегии, такие как:\n\n → Снижение налога УСН и иных видов налогов\n → Льготная ставка аренды помещений\n → Возможность бесплатного получения юридического адреса в бизнес-центрах ОЭЗ\n С полным списком приемуществ вы можете ознакомиться по ссылке",
                },
                Media = new Media[] { mainF[3] }
            },
        };

        /* путь получения статуса */
        Post post06_1113_t9_i5 = new()
        {
            Title = "Путь получения статуса",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalPreparedText = "Получение статуса резидента <b>ОЭЗ «Томск»</b> состоит из нескольких этапов:\n\n 1. Отправка заявки и бизнес-плана в УК\n 2. УК пересылавет информацию в Департамент инвестиций Томской области\n 3. Происходит установление соответсвия заявки критериям <i>(до 55 рабочих дней)</i>\n 4. Затем она отправляется в экспертный совет <i>(до 15 рабочих дней)</i>\n 5. Трёхстороннее соглашение между Администрацией томской области, ОЭЗ «Томск» и резидентом\n\nПодробнее можно узнать по ссылке:",
                },
                Media = new Media[] { mainF[4] }
            },
        };

        /* нормативные документы */
        Post post07_114_t26_i6 = new()
        {
            Title = "Общие нормативные документы",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Media = new Media[] { mainF[5] }
            },
        };

        /* документы для статуса */
        Post post08_1141_t27_i6 = new()
        {
            Title = "Нормативные документы для статуса резидента",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Media = new Media[] { mainF[5] }
            },
        };

        /* общие контакты */
        Post post09_112_t3_i7 = new()
        {
            Title = "Контакты УК",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalPreparedText = "В этом разделе можно найти <i>контакты управляющей компании ОЭЗ «Томск»</i> и бизнес-центров на Южной площадке",
                },
                Media = new Media[] { mainF[6] }
            },
        };

        /* иц */
        Post post10_1121_t4_i8 = new()
        {
            Title = "Контакты ИЦ",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalPreparedText = "<b>Адрес:</b> 634055, Томск, пр. Развития, 3\n<b>Таможенный пост:</b> +7 (3822) 47-97-68\n<b>Пост охраны: +7 (3822) 488-792</b>\n<b>Email:</b> sb@oez.tomsk.ru",
                },
                Media = new Media[] { mainF[7] }
            },
        };

        /* цит */
        Post post11_1122_t5_i9 = new()
        {
            Title = "Контакты ЦИТ",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalPreparedText = "<b>Адрес:</b> 634055 г. Томск, пр. Академический, 8/8\n<b>Таможенный пост:</b> +7 (3822) 46-78-57\n<b>Пост охраны: +7 (3822) 488-791</b>\n<b>Email:</b> sb@oez.tomsk.ru",
                },
                Media = new Media[] { mainF[8] }
            },
        };

        /* нвц */
        Post post12_1123_t6_i10 = new()
        {
            Title = "Контакты НВЦ",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalPreparedText = "<b>Адрес:</b> 634055, г. Томск, пр. Развития, 8\n<b>Таможенный пост:</b> +7 (3822) 47-96-79\n<b>Пост охраны: +7 (3822) 48-87-94</b>\n<b>Email:</b> sb@oez.tomsk.ru",
                },
                Media = new Media[] { mainF[9] }
            },
        };

        /* инфра: об оэз, смена поста */
        Post post13_113_t0_i11 = new()
        {
            Title = "Об ОЭЗ, разветвление",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Media = new Media[] { mainF[10] }
            },
        };

        /* северная */
        Post post14_1131_t10_i12 = new()
        {
            Title = "Северная площадка",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalPreparedText = " → 83.5Га – общая площадь\n → Площадка для размещения химических производств, металлургии, строительных предприятий, промышленного производства",
                },
                Media = new Media[] { mainF[11] }
            },
        };

        /* южная */
        Post post15_1132_t12_i13 = new()
        {
            Title = "Южная площадка",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalPreparedText = " → 192.5Га – общая площадь\n → Действующая специализация: <i>информационные технологии, высокотехнологичное производство, девелоперские проекты, региональный выстовачный центр</i>",
                },
                Media = new Media[] { mainF[12] }
            },
        };

        /* инвентум */
        Post post16_11321_t13_i9 = new()
        {
            Title = "Об Инвентуме",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalPreparedText = " → 8 этажей и 80 парковочных мест\n → Офисные помещения\n → Лабораторные помещения\n → Производственные помещения\n → Меньшая стоимость аренды для компаний арендаторов со статусом резидента",
                },
                Media = new Media[] { mainF[8] }
            },
        };

        /* технум */
        Post post17_11322_t14_i8 = new()
        {
            Title = "О Технуме",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalPreparedText = " → 7 этажей и 200 парковочных мест\n → Офисные помещения\n → Лабораторные помещения\n → Производственные помещения\n → Меньшая стоимость аренды для компаний арендаторов со статусом резидента",
                },
                Media = new Media[] { mainF[7] }
            },
        };

        /* витум */
        Post post18_11323_t15_i10 = new()
        {
            Title = "О Витуме",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalPreparedText = " → 5 этажей и 110 парковочных мест\n → Офисные помещения\n → Лабораторные помещения\n → Производственные помещения\n → Меньшая стоимость аренды для компаний арендаторов со статусом резидента",
                },
                Media = new Media[] { mainF[9] }
            },
        };

        /* аренда для мироприятий */
        Post post19_12_t18_i14 = new()
        {
            Title = "Аренда для мероприятий",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalPreparedText = "Бизнес-центры на <b>Южной площадке</b> располагают всем необходимым для проведения форумов, презентаций, совещаний, выставок, квизов и других мероприятий.\n\nДорога до центра города составляет <i>около 15 минут</i>, современные корпуса в экологически чистом районе окружены лесопарком и имеют вместительные парковки.\n\nЗалы оборудованы кондиционерами и гардеробными комнатами, в зданиях есть пространства для кофе-брейков, переговорные комнаты, лифты, системы безопасности",
                },
                Media = new Media[] { mainF[13] }
            },
        };

        /* выбор, карусель вариантов */
        Post post20_121_t19_i0 = new()
        {
            Title = "Аренда для мероприятий: варианты",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalText = "Воспользуйтесь кнопками ниже и выберите подходящий вариант",
                },
                Media = new Media[] { mainF[22] }
            },
        };

        /*аренда для нерезидентов*/
        Post post21_13_t21_i15 = new()
        {
            Title = "Аренда для нерезидентов",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalPreparedText = "В ОЭЗ «Томск» можно <i>арендовать помещения</i> разных типов, <i>не имея</i> статуса резидента. Расскажите о ваших потребностях и мы подберем подходящие помещения, или выберите вручную",
                },
                Media = new Media[] { mainF[14] }
            },
        };

        /*стать резидентом*/
        Post post22_14_t22_i16 = new()
        {
            Title = "Стать резидентом",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalPreparedText = "Резиденты ОЭЗ «Томск» пользуются <i>льготами и преференциями</i>, могут применять таможенную процедуру <i>свободной таможенной зоны</i>",
                },
                Media = new Media[] { mainF[15] }
            },
        };

        /*авторизация*/
        Post post23_15_t24_i17 = new()
        {
            Title = "Авторизация",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalPreparedText = "Если вы уже взаимодействовали с ОЭЗ, выберите <i>свой текущий статус</i> и укажите контактные данные. Это позволит нам связаться с вами после ваших новых обращений.",
                },
                Media = new Media[] { mainF[16] }
            },
        };

        /*я гость*/
        Post post24_16_t25_i17 = new()
        {
            Title = "Авторизация для гостей",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalPreparedText = "Если вы хотите обратиться к УК ОЭЗ «Томск», пожалуйста, оставьте <i>ваши контакты</i>, чтобы мы могли связаться с вами",
                },
                Media = new Media[] { mainF[16] }
            },
        };

        /*существующие варианты аренды для резидентов и не-резидентов*/
        Post post25_17_t20_i0 = new()
        {
            Title = "Аренда помещений для резидентов и нерезидентов",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalText = "Воспользуйтесь кнопками ниже и выберите подходящий вариант",
                },
                Media = new Media[] { mainF[22] }
            },
        };

        /*второе меню*/
        Post post26_2_t28_i18 = new()
        {
            Title = "Вторичное меню",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalPreparedText = "Рады, что вы снова обратились в УК ОЭЗ «Томск»!\n\n<i>{p:weather}</i>\n\n<b>Чем мы можем вам помочь?</b>",
                    PreparedText = "Рады, что вы снова обратились в УК ОЭЗ «Томск»!\n{0}\n<b>Чем мы можем вам помочь?</b>",
                    Surrogates = new TextSetterBase[] { new WeatherTextSetter(56.478517, 85.047436) { Position = 0 } }
                },
                Media = new Media[] { mainF[17] }
            },
        };

        /*мои заявки*/
        Post post27_21_t29_i19 = new()
        {
            Title = "Мои заявки и вопросы",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalPreparedText = "<b>Отправленные:</b>\n{p:tickets:unread}\n\n<b>В обработке:</b>\n{p:tickets:inprogress}\n\n<b>Обработанные:</b>\n{p:tickets:accept}\n\n<b>Отклонённые:</b>\n{p:tickets:decline}",
                    PreparedText = "<b>Отправленные:</b>\n{0}\n\n<b>В обработке:</b>\n{1}\n\n<b>Обработанные:</b>\n{2}\n\n<b>Отклонённые:</b>\n{3}",
                    Surrogates = new[]
                    {
                        new TicketsTextSetter(SentReportStatus.Unread, 5) {Position = 0},
                        new TicketsTextSetter(SentReportStatus.InProgress, 5){Position = 1},
                        new TicketsTextSetter(SentReportStatus.Accept, 5){Position = 2},
                        new TicketsTextSetter(SentReportStatus.Decline, 5){Position = 3},
                    }
                },
                Media = new Media[] { mainF[19] }
            },
        };

        /*мои контакты*/
        Post post28_22_t30_i20 = new()
        {
            Title = "Мои контакты",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalPreparedText = "Ваши актуальные контактные данные:\n\n{p:contactlist}",
                    PreparedText = "Ваши актуальные контактные данные:\n\n{0}",
                    Surrogates = new[] { new ContactListTextSetter() { Position = 0 } }
                },
                Media = new Media[] { mainF[19] }
            },
        };

        /*сообщить о проблеме*/
        Post post29_23_t31_i21 = new()
        {
            Title = "Сообщить о проблеме",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalText = "Выберите проблему, о которой хотите сообщить",
                },
                Media = new Media[] { mainF[20] }
            },
        };

        /*рационализаторское предложение*/
        //Post post30_24_t0_i0

        /*забронировать зал*/
        Post post31_25_t32_i22 = new()
        {
            Title = "Бронирование конференц-зала, переговорки",
            Content = new()
            {
                Type = InnerMessageType.Photo,
                Text = new()
                {
                    OriginalText = "Воспользуйтесь кнопками ниже и выберите подходящий конференц-зал",
                },
            },
        };

        Post[] mainP = new Post[] { post00, post01_1_t1_i1, post01_a, post02_11_t2_i2, /*post03_111_t2_i2,*/ post04_1111_t7_i3, post05_1112_t8_i4, post06_1113_t9_i5, post07_114_t26_i6, post08_1141_t27_i6, post09_112_t3_i7, post10_1121_t4_i8, post11_1122_t5_i9, post12_1123_t6_i10, post13_113_t0_i11, post14_1131_t10_i12, post15_1132_t12_i13, post16_11321_t13_i9, post17_11322_t14_i8, post18_11323_t15_i10, post19_12_t18_i14, /*post20_121_t19_i0,*/ post21_13_t21_i15, post22_14_t22_i16, post23_15_t24_i17, post24_16_t25_i17, post25_17_t20_i0, post26_2_t28_i18, post27_21_t29_i19, post28_22_t30_i20, post29_23_t31_i21, /*post30_24_t0_i0,*/ post31_25_t32_i22 };
        context.AddRange(mainP);
        context.SaveChanges();

        # endregion

        #region Prime dia

        Post dia01_poll1 = new()
        {
            Title = "Имя",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "Как можно к вам обращаться?",
                },
            },
        };
        Post dia02_poll1 = new()
        {
            Title = "Телефон",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "Укажите ваш номер телефона (в формате +7900900XXXX)",
                },
            },
        };
        Post dia03_poll1 = new()
        {
            Title = "Почта",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "Укажите вашу электронную почту",
                },
            },
        };
        Post dia04_poll1 = new()
        {
            Title = "Компания",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "Укажите название компании, в которой вы работаете",
                },
            },
        };
        Post dia05_poll1 = new()
        {
            Title = "Должность",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "Укажите вашу должность",
                },
            },
        };
        Post dia06_poll2 = new()
        {
            Title = "Дата и время аренды под мероприятие",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "В какую дату и время вы хотели бы арендовать помещение?",
                },
            },
        };
        Post dia07_poll2 = new()
        {
            Title = "Цель и тема мероприятия",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "Какая цель и тема у проводимого мероприятия?",
                },
            },
        };
        Post dia08_poll2 = new()
        {
            Title = "Количество поситителей",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "Какое количество посетителей вы ожидаете?",
                },
            },
        };
        Post dia09_poll3 = new()
        {
            Title = "Типо площедей для проекта",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "Какой тип площадей необходим для проекта?",
                },
            },
        };
        Post dia10_poll3 = new()
        {
            Title = "Необходимая площадь для проекта",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "Какая площадь помещений вам необходима? Укажите в квадратных метрах",
                },
            },
        };
        Post dia11_poll3 = new()
        {
            Title = "Период начала аренды",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "На какой период планируете начало аренды? Если точная дата не определена, укажите плановые месяц и год",
                },
            },
        };
        Post dia12_poll4 = new()
        {
            Title = "Стадия реализации",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "Текущая стадия реализации проекта (идея, стартап, действующее предприятие, др.)",
                },
            },
        };
        Post dia13_poll4 = new()
        {
            Title = "Количество сотрудников",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "Сколько человек работает сейчас над проектом?",
                },
            },
        };
        Post dia14_poll4 = new()
        {
            Title = "Планируемые инвестиции",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "Какой объем инвестиций планируется?",
                },
            },
        };
        Post dia15_poll5 = new()
        {
            Title = "Необходимая площадь земельного участка",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "Какая площадь земельного участка необходима для строительства объектов в рамках вашего проекта? Укажите в гектарах или квадратных метрах",
                },
            },
        };
        Post dia16_poll5 = new()
        {
            Title = "Период начала строительства",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "На какой период планируется начало строительства? Укажите плановые месяц и год",
                },
            },
        };
        Post dia17_poll6 = new()
        {
            Title = "День для арендф",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "В какой день вы хотели забронировать помещение? (в формате: <i>день.месяц.год</i>)",
                },
            },
        };
        Post dia18_poll6 = new()
        {
            Title = "Время бронирования",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "В какое время?",
                },
            },
        };
        Post dia19_poll6 = new()
        {
            Title = "Длительность бронирования",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "На какой промежуток времени? В минутах",
                },
            },
        };
        Post dia20_poll6 = new()
        {
            Title = "Дополнительные пожелания",
            Content = new()
            {
                Text = new()
                {
                    OriginalText = "У вас есть дополнительные пожелания?",
                },
            },
        };
        Post dia21_poll7 = new()
        {
            Title = "Техническая проблема",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "Опишите своими словами проблему или ситуацию, требующую технического обслуживания или ремонта",
                },
            },
        };
        Post dia22_poll7 = new()
        {
            Title = "Точный адрес",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "Укажите адрес: здание, этаж, помещение",
                },
            },
        };
        Post dia23_poll8 = new()
        {
            Title = "Рационализаторская проблема",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "Опишите, пожалуйста, проблему, на решение которой направлено предложение",
                },
            },
        };
        Post dia24_poll8 = new()
        {
            Title = "Суть предложения",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "Опишите своими словами суть рационализаторского предложения или идеи – как это должно работать",
                },
            },
        };
        Post dia25_poll8 = new()
        {
            Title = "Общедоступные примеры",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "Укажите, если есть, общедоступные примеры внедрения подобных решений – идеальный или близкий к этому вариант",
                },
            },
        };
        Post dia26_poll8 = new()
        {
            Title = "Необходимые ресурсы",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "Какие на ваш взгляд ресурсы будут необходимы для внедрения вашего предложения? (возможные варианты: предложение может быть реализовано исключительно силами УК ОЭЗ, либо с участием какого-либо органа муниципальной, региональной или федеральной власти, либо с участием представителей какого-либо бизнеса и т.п.)",
                },
            },
        };
        Post dia27_poll8 = new()
        {
            Title = "Возможно ли участие",
            Content = new()
            {
                Type = InnerMessageType.Text,
                Text = new()
                {
                    OriginalText = "В процессе внедрения вашего предложения возможно ли ваше участие (как компании и/или персональное), и, если да, в какой форме?",
                },
            },
        };

        Post[] diaP = new Post[] { dia01_poll1, dia02_poll1, dia03_poll1, dia04_poll1, dia05_poll1, dia06_poll2, dia07_poll2, dia08_poll2, dia09_poll3, dia10_poll3, dia11_poll3, dia12_poll4, dia13_poll4, dia14_poll4, dia15_poll5, dia16_poll5, dia17_poll6, dia18_poll6, dia19_poll6, dia20_poll6, dia21_poll7, dia22_poll7, dia23_poll8, dia24_poll8, dia25_poll8, dia26_poll8, dia27_poll8 };
        context.AddRange(diaP);
        context.SaveChanges();

        #endregion

        #region Vars

        var name = new Variable() { Name = "name", ShowedName = "Имя" };
        var phone = new Variable() { Name = "phone", ShowedName = "Телефон" };
        var email = new Variable() { Name = "email", ShowedName = "Почта" };
        var organization = new Variable() { Name = "organization", ShowedName = "Компания" };
        var title = new Variable() { Name = "title", ShowedName = "Должность" };

        var event_date_time = new Variable() { Name = "event_date_time ", ShowedName = "Дата и время аренды под мероприятие" };
        var event_subject = new Variable() { Name = "event_subject", ShowedName = "Цель и тема мероприятия" };
        var event_visitors = new Variable() { Name = "event_visitors", ShowedName = "Количество поситителей" };

        var area_premises = new Variable() { Name = "area_premises", ShowedName = "Необходимая площадь для проекта" };
        var area_type = new Variable() { Name = "area_type", ShowedName = "Тип площадей" };
        var area_rental_start = new Variable() { Name = "area_rental_start", ShowedName = "Планируемое начало аренды" };

        var project_stage = new Variable() { Name = "project_stage", ShowedName = "Стадия реализации" };
        var project_crew = new Variable() { Name = "project_crew", ShowedName = "Количество сотрудников" };
        var project_volume = new Variable() { Name = "project_volume", ShowedName = "Планируемые инвестиции" };

        var building_premises = new Variable() { Name = "building_premises", ShowedName = "Необходимая площадь земельного участка" };
        var building_start = new Variable() { Name = "building_start", ShowedName = "Период начала строительства" };

        var hall_date = new Variable() { Name = "hall_date", ShowedName = "День для аренды" };
        var hall_time = new Variable() { Name = "hall_time", ShowedName = "Время бронирования" };
        var hall_period = new Variable() { Name = "hall_period", ShowedName = "Длительность бронирования" };
        var hall_wish = new Variable() { Name = "hall_wish", ShowedName = "Дополнительные пожелания" };

        //var problem_reason = new Variable() { Name = "problem_reason", ShowedName = "Тип неисправности" };
        var problem_main = new Variable() { Name = "problem_main", ShowedName = "Техническая проблема" };
        var problem_address = new Variable() { Name = "problem_address", ShowedName = "Точный адрес" };

        var solution_main = new Variable() { Name = "solution_main", ShowedName = "Рационализаторская проблема" };
        var solution_idea = new Variable() { Name = "solution_idea", ShowedName = "Суть предложения" };
        var solution_example = new Variable() { Name = "solution_example", ShowedName = "Общедоступные примеры" };
        var solution_res = new Variable() { Name = "solution_res", ShowedName = "Необходимые ресурсы" };
        var solution_involve = new Variable() { Name = "solution_involve", ShowedName = "Возможно ли участие" };

        var vars = new Variable[] { name, phone, email, organization, title, event_date_time, event_subject, event_visitors, area_premises, area_type, area_rental_start, project_stage, project_crew, project_volume, building_premises, building_start, hall_date, hall_time, hall_period, hall_wish, problem_main, problem_address, solution_main, solution_idea, solution_example, solution_res, solution_involve };
        context.Variables.AddRange(vars);
        context.SaveChanges();

        #endregion

        #region Commands

        var startTrigger = new Trigger(
            true,
            new CleanScopeEffect(true, 0),
            new SendPostEffect(post00, 1),
            new SendPostEffect(post01_1_t1_i1, 2));
        var start1Command = new TextCommand()
        {
            Name = "start",
            Order = 0,
            Description = "Начать заново",
            RoleVisibility = new[] { anon },
            Trigger = startTrigger
        };
        var start2Command = new TextCommand()
        {
            Name = "start",
            Order = 10,
            Description = "Вернуться в начало",
            RoleVisibility = new[] { guest, resident, eventTenant, constantTenant, worker },
            Trigger = startTrigger
        };
        var menuCommand = new TextCommand()
        {
            Name = "menu",
            Order = 1,
            Description = "Главное меню",
            RoleVisibility = new[] { guest, resident, eventTenant, constantTenant, worker
            },
            Trigger = new(
                true,
                new CleanScopeEffect(true, 0),
                new SendPostEffect(post26_2_t28_i18, 1)
            )
        };
        var ticketsCommand = new TextCommand()
        {
            Name = "tickets",
            Order = 2,
            Description = "Мои заявки и вопросы",
            RoleVisibility = new[] { guest, resident, eventTenant, constantTenant, worker },
            Trigger = new(
                true,
                new CleanScopeEffect(true, 0),
                new SendPostEffect(post27_21_t29_i19, 1))
        };
        var contactsCommand = new TextCommand()
        {
            Name = "contacts",
            Order = 3,
            Description = "Мои контакты",
            RoleVisibility = new[] { guest, resident, eventTenant, constantTenant, worker },
            Trigger = new(
                true,
                new CleanScopeEffect(true, 0),
                new SendPostEffect(post28_22_t30_i20, 1))
        };
        var issuesCommand = new TextCommand()
        {
            Name = "issues",
            Order = 4,
            Description = "Сообщить о проблеме",
            RoleVisibility = new[] { guest, resident, eventTenant, constantTenant, worker },
            Trigger = new(
                true,
                new CleanScopeEffect(true, 0),
                new SendPostEffect(post29_23_t31_i21, 1))
        };
        var reserveCommand = new TextCommand()
        {
            Name = "reserve",
            Order = 5,
            Description = "Забронировать конференц-зал / переговорную",
            RoleVisibility = new[] { resident, worker, constantTenant },
            Trigger = new(
                true,
                new CleanScopeEffect(true, 0),
                new SendPostEffect(post31_25_t32_i22, 1))
        };

        var commands = new TextCommand[] { start1Command, start2Command, menuCommand, ticketsCommand, contactsCommand, issuesCommand, reserveCommand };
        context.BotCommands.AddRange(commands);
        context.SaveChanges();


        #endregion

        #region Dialogues

        var d1_contacts = new Dialogue(
            "Контактные данные",
            new DialogueField(0, name, new IncludedPost(dia01_poll1)),
            new DialogueField(1, phone, new IncludedPost(dia02_poll1, autoInput: AutoInputType.Contact)),
            new DialogueField(2, email, new IncludedPost(dia03_poll1)),
            new DialogueField(3, organization, new IncludedPost(dia04_poll1)),
            new DialogueField(4, title, new IncludedPost(dia05_poll1))
            );
        var d2_event = new Dialogue(
            title: "Ожидания от помещения на мероприятие",
            new DialogueField(0, event_date_time, new IncludedPost(dia06_poll2)),
            new DialogueField(1, event_subject, new IncludedPost(dia07_poll2)),
            new DialogueField(2, event_visitors, new IncludedPost(dia08_poll2))
        );
        var d3_area = new Dialogue(
            title: "Требования к арендуемой площади",
            new DialogueField(0, area_type, new IncludedPost(dia09_poll3)),
            new DialogueField(1, area_premises, new IncludedPost(dia10_poll3)),
            new DialogueField(2, area_rental_start, new IncludedPost(dia11_poll3))
        );
        var d4_project = new Dialogue(
            title: "Ключевые параметры проекта",
            new DialogueField(0, project_stage, new IncludedPost(dia12_poll4)),
            new DialogueField(1, project_crew, new IncludedPost(dia13_poll4)),
            new DialogueField(2, project_volume, new IncludedPost(dia14_poll4))
        );
        var d5_building = new Dialogue(
            title: "Планы на строительство",
            new DialogueField(0, building_premises, new IncludedPost(dia15_poll5)),
            new DialogueField(1, building_start, new IncludedPost(dia16_poll5))
        );
        var d6_hall = new Dialogue(
            title: "Ожидаемая дата и время бронирования конференц-зала / переговорки",
            new DialogueField(0, hall_date, new IncludedPost(dia17_poll6, autoInput: AutoInputType.LongDate)),
            new DialogueField(1, hall_time, new IncludedPost(dia18_poll6)),
            new DialogueField(2, hall_period, new IncludedPost(dia19_poll6)),
            new DialogueField(3, hall_wish, new IncludedPost(dia20_poll6))
        );
        var d7_problem = new Dialogue(
            title: "Неисправность в ОЭЗ",
            new DialogueField(0, problem_main, new IncludedPost(dia21_poll7)),
            new DialogueField(order: 1, problem_address, new IncludedPost(dia22_poll7))
        );
        var d8_solution = new Dialogue(
            title: "Рационализаторское предложение",
            new DialogueField(0, solution_main, new IncludedPost(dia23_poll8)),
            new DialogueField(1, solution_idea, new IncludedPost(dia24_poll8)),
            new DialogueField(2, solution_example, new IncludedPost(dia25_poll8)),
            new DialogueField(3, solution_res, new IncludedPost(dia26_poll8)),
            new DialogueField(4, solution_involve, new IncludedPost(dia27_poll8))
        );

        context.Dialogues.AddRange(d1_contacts, d2_event, d3_area, d4_project, d5_building, d6_hall, d7_problem, d8_solution);
        context.SaveChanges();

        #endregion

        #region 

        var r_eventTenant = new Report(
            "Аренда помещения для мероприятия",
            "Событийная аренда",
            new IncludedDialogue(0, d1_contacts),
            new IncludedDialogue(1, d2_event)
            );
        var r_constantTenant = new Report(
            "Долгосрочная аренда",
            "Заявка на долгосрочную аренду",
            new IncludedDialogue(0, d1_contacts),
            new IncludedDialogue(1, d3_area)
            );
        var r_residentWithRent = new Report(
            "Получение статуса резидента (аренда)",
            "Заявка на статус резидента (аренда)",
            new IncludedDialogue(0, d1_contacts),
            new IncludedDialogue(1, d4_project),
            new IncludedDialogue(2, d3_area)
            );
        var r_residentWithBuild = new Report(
            "Получение статуса резидента (строительство)",
            "Заявка на статус резидента (строительство)",
            new IncludedDialogue(0, d1_contacts),
            new IncludedDialogue(1, d4_project),
            new IncludedDialogue(2, d5_building)
            );
        var r_promblem_electr = new Report(
            "Проблема в электроснабжении",
            "Проблема: электроснабжение",
            new IncludedDialogue(0, d1_contacts),
            new IncludedDialogue(1, d7_problem)
            );
        var r_promblem_water = new Report(
            "Проблема в водоснабжении / канализации",
            "Проблема: водоснабжение / канализация",
            new IncludedDialogue(0, d1_contacts),
            new IncludedDialogue(1, d7_problem)
            );
        var r_promblem_internet = new Report(
            "Проблема с интернетом / телефонией / серверными комнатами",
            "Проблема: интернет / телефония / серверные",
            new IncludedDialogue(0, d1_contacts),
            new IncludedDialogue(1, d7_problem)
            );
        var r_promblem_heating = new Report(
            "Проблема с отоплением / кондиционированием",
            "Проблема: отопление / кондиционирование",
            new IncludedDialogue(0, d1_contacts),
            new IncludedDialogue(1, d7_problem)
            );
        var r_promblem_other = new Report(
            "Мелкий и средний ремонт",
            "Проблема: другое",
            new IncludedDialogue(0, d1_contacts),
            new IncludedDialogue(1, d7_problem)
            );
        var r_booking_meeting = new Report(
            "Бронирование конференц-зала / переговорной",
            "Бронирование конференц-зала / переговорной",
            new IncludedDialogue(0, d1_contacts),
            new IncludedDialogue(1, d6_hall)
            );
        var r_idea = new Report(
            "Рационализаторское предложение",
            "Рационализаторское предложение",
            new IncludedDialogue(0, d1_contacts),
            new IncludedDialogue(1, d8_solution)
            );


        context.Reports.AddRange(r_eventTenant, r_constantTenant, r_residentWithRent, r_residentWithBuild, r_promblem_electr, r_promblem_heating, r_promblem_water, r_promblem_internet, r_promblem_other, r_booking_meeting, r_idea);
        context.SaveChanges();

        #endregion

        #region Filling posts with content

        // ------------------   1   ------------------
        var kb01_a = new KeyboardReply("Назад в первое меню", "Об ОЭЗ", true, true, true,
                            new ButtonReply(new Text() { OriginalText = "Назад" }, trigger: new(false, new RemoveShowedMessageEffect(new(post02_11_t2_i2))))
                        );
        var kb01 = new KeyboardReply("Первое меню", null, true, true, false,
            new ButtonReply(new Text() { OriginalText = "📕 Узнать об ОЭЗ" }, 1, 1,
                new Trigger(
                    false,
                    new SendPostEffect(post01_a, 0),
                    new SendPostEffect(post02_11_t2_i2, 0)
                )),
            new ButtonReply(new Text() { OriginalText = "📢 Аренда для мероприятий" }, 1, 2,
                new Trigger(
                    false,
                    new SendPostEffect(post19_12_t18_i14)
                )),
            new ButtonReply(new Text() { OriginalText = "📠 Аренда для нерезидентов" }, 1, 3,
                new Trigger(
                    false,
                    new SendPostEffect(post21_13_t21_i15)
                )),
            new ButtonReply(new Text() { OriginalText = "💼 Стать резидентом" }, 1, 4,
                new Trigger(
                    false,
                    new SendPostEffect(post22_14_t22_i16)
                )),
            new ButtonReply(new Text() { OriginalText = "👥 Я уже часть ОЭЗ" }, 1, 5,
                new Trigger(
                    false,
                    new SendPostEffect(post23_15_t24_i17)
                )),
            new ButtonReply(new Text() { OriginalText = "👤 Я гость" }, 2, 5,
                new Trigger(
                    false,
                    new SendPostEffect(post24_16_t25_i17)
                ))
        );
        post01_1_t1_i1.Keyboard = kb01;
        // ------------------   -   ------------------

        // var kb02 = ney
        // post02_11_t2_i2.Keyboard = null;

        //

        context.SaveChanges();

        #endregion
    }
}