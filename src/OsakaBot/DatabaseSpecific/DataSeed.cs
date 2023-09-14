using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using Telegram.Bot.Types;

namespace Osaka.Bot.DatabaseSpecific;

public class DataSeed
{
    public void Initialize(BotDbContext context)
    {
        RegularUserRole guest = new() { Name = "Гость" };
        RegularUserRole resident = new() { Name = "Резидент" };
        RegularUserRole eventTenant = new() { Name = "Событийный арендатор" };
        RegularUserRole constantTenant = new() { Name = "Временный арендатор" };
        RegularUserRole worker = new() { Name = "Сотрудник" };

        context.AddRange(guest, resident, eventTenant, constantTenant, worker);
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
        };
        context.AddRange(mainF);
        context.SaveChanges();

        Post post01_1_t1_i1 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "*Приветствую вас в ОЭЗ Томск!*\n\nЯ ваш помощник и проводник. Для навигации используйте кнопки и команды меню (внизу слева).",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[0] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post02_11_t2_i1 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post03_111_t2_i2 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post04_1111_t7_i3 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post05_1112_t8_i4 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post06_1113_t9_i5 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post07_114_t26_i6 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post08_1141_t27_i6 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post09_112_t3_i7 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post10_1121_t4_i8 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post11_1122_t5_i9 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post12_1123_t6_i10 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post13_113_t0_i11 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post14_1131_t10_i12 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post15_1132_t12_i13 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post16_11321_t13_i9 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post17_11322_t14_i8 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post18_11323_t15_i10 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post19_12_t18_i14 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post20_121_t19_i0 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post21_13_t21_i15 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post22_14_t22_i16 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post23_15_t24_i17 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post24_16_t25_i17 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post25_17_t20_i0 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post26_2_t28_i18 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post27_21_t29_i19 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post28_22_t30_i20 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post29_23_t31_i21 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post30_24_t0_i0 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
                Media = new Media[] { mainF[-1] }
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post post31_25_t32_i22 = new()
        {
            Label = "",
            Title = "",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };

        Post[] mainP = new Post[] { post01_1_t1_i1, post02_11_t2_i1, post03_111_t2_i2, post04_1111_t7_i3, post05_1112_t8_i4, post06_1113_t9_i5, post07_114_t26_i6, post08_1141_t27_i6, post09_112_t3_i7, post10_1121_t4_i8, post11_1122_t5_i9, post12_1123_t6_i10, post13_113_t0_i11, post14_1131_t10_i12, post15_1132_t12_i13, post16_11321_t13_i9, post17_11322_t14_i8, post18_11323_t15_i10, post19_12_t18_i14, post20_121_t19_i0, post21_13_t21_i15, post22_14_t22_i16, post23_15_t24_i17, post24_16_t25_i17, post25_17_t20_i0, post26_2_t28_i18, post27_21_t29_i19, post28_22_t30_i20, post29_23_t31_i21, post30_24_t0_i0, post31_25_t32_i22 };
        context.Add(mainP);
        context.SaveChanges();

        Post dia01_poll1_2 = new()
        {
            Label = "Как можно к вам обращаться?",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Text = new()
                {
                    OriginalText = "Как можно к вам обращаться?",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia02_poll1_2 = new()
        {
            Label = "Укажите ваш номер телефона",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "Укажите ваш номер телефона (в формате +7900900XXXX)",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia03_poll1_2 = new()
        {
            Label = "Укажите вашу электронную почту",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "Укажите вашу электронную почту",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia04_poll2 = new()
        {
            Label = "Укажите название компании, в которой вы работаете",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "Укажите название компании, в которой вы работаете",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia05_poll2 = new()
        {
            Label = "Укажите вашу должность",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "Укажите вашу должность",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia06_poll3 = new()
        {
            Label = "В какую дату и время вы хотели бы арендовать помещение?",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "В какую дату и время вы хотели бы арендовать помещение?",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia07_poll3 = new()
        {
            Label = "Какая цель и тема у проводимого мероприятия?",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "Какая цель и тема у проводимого мероприятия?",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia08_poll3 = new()
        {
            Label = "Какое количество посетителей вы ожидаете?",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "Какое количество посетителей вы ожидаете?",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia09_poll4 = new()
        {
            Label = "Какой тип площадей необходим для проекта?",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "Какой тип площадей необходим для проекта?",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia10_poll4 = new()
        {
            Label = "Какая площадь помещений вам необходима? Укажите в квадратных метрах.",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "Какая площадь помещений вам необходима? Укажите в квадратных метрах.",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia11_poll4 = new()
        {
            Label = "На какой период планируете начало аренды? Если точная дата не определена, укажите плановые месяц и год.",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "На какой период планируете начало аренды? Если точная дата не определена, укажите плановые месяц и год.",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia12_poll5 = new()
        {
            Label = "Текущая стадия реализации проекта (идея, стартап, действующее предприятие, др.)",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "Текущая стадия реализации проекта (идея, стартап, действующее предприятие, др.)",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia13_poll5 = new()
        {
            Label = "Сколько человек работает сейчас над проектом?",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "Сколько человек работает сейчас над проектом?",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia14_poll5 = new()
        {
            Label = "Какой объем инвестиций планируется?",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "Какой объем инвестиций планируется?",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia15_poll6 = new()
        {
            Label = "Какая площадь земельного участка необходима для строительства объектов в рамках вашего проекта? Укажите в гектарах или квадратных метрах.",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "Какая площадь земельного участка необходима для строительства объектов в рамках вашего проекта? Укажите в гектарах или квадратных метрах.",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia16_poll6 = new()
        {
            Label = "На какой период планируется начало строительства? Укажите плановые месяц и год.",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "На какой период планируется начало строительства? Укажите плановые месяц и год.",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia17_poll7 = new()
        {
            Label = "В какой день недели вы хотели забронировать помещение?",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "В какой день недели вы хотели забронировать помещение?",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia18_poll7 = new()
        {
            Label = "В какое время?",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "В какое время?",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia19_poll7 = new()
        {
            Label = "На какой промежуток времени?",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "На какой промежуток времени?",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia20_poll7 = new()
        {
            Label = "У вас есть дополнительные пожелания?",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "У вас есть дополнительные пожелания?",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia21_poll8 = new()
        {
            Label = "Опишите своими словами проблему или ситуацию, требующую технического обслуживания или ремонта",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "Опишите своими словами проблему или ситуацию, требующую технического обслуживания или ремонта",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia22_poll8 = new()
        {
            Label = "Укажите адрес: здание, этаж, помещение",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "Укажите адрес: здание, этаж, помещение",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia23_poll9 = new()
        {
            Label = "Опишите проблему",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "Опишите, пожалуйста, проблему, на решение которой направлено предложение",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia24_poll9 = new()
        {
            Label = "Опишите своими словами суть предложения или идеи",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "Опишите своими словами суть рационализаторского предложения или идеи – как это должно работать",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia25_poll9 = new()
        {
            Label = "Укажите общедоступные примеры",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "Укажите, если есть, общедоступные примеры внедрения подобных решений – идеальный или близкий к этому вариант",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia26_poll9 = new()
        {
            Label = "Какие ресурсы будут необходимы?",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "Какие на ваш взгляд ресурсы будут необходимы для внедрения вашего предложения? (возможные варианты: предложение может быть реализовано исключительно силами УК ОЭЗ, либо с участием какого-либо органа муниципальной, региональной или федеральной власти, либо с участием представителей какого-либо бизнеса и т.п.)",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };
        Post dia27_poll9 = new()
        {
            Label = "В процессе внедрения вашего предложения возможно ли ваше участие?",
            Content = new()
            {
                Type = InnerMessageType.Unsupported,
                Label = "",
                Text = new()
                {
                    OriginalText = "В процессе внедрения вашего предложения возможно ли ваше участие (как компании и/или персональное), и, если да, в какой форме?",
                    PlainText = null,
                    PreparedText = null,
                    Surrogates = null
                },
            },
            RoleVisibility = null,
            Keyboard = null,
            UserInput = null,
            OnUserScopeClear = null
        };

        Post[] diaP = new Post[] { dia01_poll1_2, dia02_poll1_2, dia03_poll1_2, dia04_poll2, dia05_poll2, dia06_poll3, dia07_poll3, dia08_poll3, dia09_poll4, dia10_poll4, dia11_poll4, dia12_poll5, dia13_poll5, dia14_poll5, dia15_poll6, dia16_poll6, dia17_poll7, dia18_poll7, dia19_poll7, dia20_poll7, dia21_poll8, dia22_poll8, dia23_poll9, dia24_poll9, dia25_poll9, dia26_poll9, dia27_poll9 };
        context.Add(diaP);
        context.SaveChanges();
    }
}