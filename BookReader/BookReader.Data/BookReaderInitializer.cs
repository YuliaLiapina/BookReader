using BookReader.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BookReader.Data
{
    public class BookReaderInitializer : CreateDatabaseIfNotExists<BookReaderDbContext>
    {
        protected override void Seed(BookReaderDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var roleAdmin = new IdentityRole { Name = "Admin" };
            var roleUser = new IdentityRole { Name = "User" };
            var roleModerator = new IdentityRole { Name = "Moderator" };

            roleManager.Create(roleAdmin);
            roleManager.Create(roleUser);
            roleManager.Create(roleModerator);

            var admin = new ApplicationUser { Email = "Admin@gmail.com", UserName = "Adminka" };
            admin.RegistrationDate = DateTime.Now;
            string password = "Admin@gmail.com1";
            var result = userManager.Create(admin, password);

            if(result.Succeeded)
            {
                userManager.AddToRole(admin.Id, roleAdmin.Name);
                userManager.AddToRole(admin.Id, roleUser.Name);
            }

            var atlasShrugged = new Book { Cover = "/Content/Books/AtlasShrugged/AtlasShruggedCover.jpg", Name = "Атлант расправил плечи", Annotation = "К власти в США приходят социалисты и правительство берет курс на «равные возможности», считая справедливым за счет талантливых и состоятельных сделать богатыми никчемных и бесталанных. Гонения на бизнес приводят к разрушению экономики, к тому же один за другим при загадочных обстоятельствах начинают исчезать талантливые люди и лучшие предприниматели. Главные герои романа стальной король Хэнк Риарден и вице-президент железнодорожной компании Дагни Таггерт тщетно пытаются противостоять трагическим событиям. Вместо всеобщего процветания общество погружается в апатию и хаос.", Body = "/Content/Books/AtlasShrugged/AtlasShrugged.txt" };
            var atlasShruggedAuthor = new Author { FirstName = "Айн", LastName = "Рэнд" };
            var antiytopia = new Genre { Name = "Антиутопия" };
            var novel = new Genre { Name = "Роман" };
            atlasShrugged.Authors.Add(atlasShruggedAuthor);
            atlasShrugged.Genres.Add(antiytopia);

            var aviator = new Book { Cover = "/Content/Books/Aviator/AviatorCover.jpg", Name = "Авиатор", Annotation = "Если человек родился в корзине терпящего бедствие воздушного шара, к гадалке ходить не надо - он вырастет авиатором. Тем более что отец Конора Брокхарта, будущего покорителя неба, капитан гвардии скромного островного государства, состоит на службе у короля-романтика, для которого слава и богатство ничто в сравнении с заботой о своих подданных. И все вроде бы идет своим чередом, ничто не нарушает идиллию, но в один несчастливый день в государстве происходит переворот, доброго короля убивают, а на его месте утверждается злобный генерал Бонвилан. Но не может такого быть, чтобы человек, родившийся в воздухе, смирился с подобной несправедливостью. И Конор Брокхарт начинает борьбу...", Body = "/Content/Books/Aviator/Aviator.txt" };
            var aviatorAuthor = new Author { FirstName = "Йон", LastName = "Колфер" };
            var fantasy = new Genre { Name = "Фантастика" };
            var kids = new Genre { Name = "Детская литература" };
            aviator.Authors.Add(aviatorAuthor);
            aviator.Genres.Add(fantasy);
            aviator.Genres.Add(kids);

            var braveNewWorld = new Book { Cover = "/Content/Books/BraveNewWorld/WorldCover.jpg", Name = "О дивный новый мир", Annotation = "«О дивный новый мир » – культовая антиутопия Олдоса Хаксли, изданная миллионными тиражами по всему миру", Body = "/Content/Books/BraveNewWorld/BraveNewWorld.txt" };
            var braveNewWorldAuthor = new Author { FirstName = "Олдос", LastName = "Хаксли" };
            braveNewWorld.Authors.Add(braveNewWorldAuthor);
            braveNewWorld.Genres.Add(antiytopia);
            braveNewWorld.Genres.Add(novel);

            var dandelionWine = new Book { Cover = "/Content/Books/DandelionWine/WineCover.jpg", Name = "Вино из одуванчиков", Annotation = "Семейство Сполдингов, проживающее в маленьком американском городке, бережно хранит свои традиции. Одна из них — приготовление вина из одуванчиков, «пойманного и закупоренного в бутылки лета». А двенадцатилетний Дуглас Сполдинг решает сохранить память о летних днях по-своему: он ведет дневник, фиксируя в нем не только «обряды и обыкновения», но и собственные «открытия и откровения». Очень богатым на них оказывается это лето — сотканное из множества важных событий, обретений и потерь. Яркое, удивительное, фантастическое лето 1928 года…", Body = "/Content/Books/DandelionWine/DandelionWine.txt" };
            var dandelionWineAuthor = new Author { FirstName = "Рэй", LastName = "Брэдбери" };
            dandelionWine.Authors.Add(dandelionWineAuthor);
            var scienceFiction = new Genre { Name = "Научная фантастика" };
            dandelionWine.Genres.Add(scienceFiction);
            dandelionWine.Genres.Add(novel);

            var empireOfAngels = new Book { Cover = "/Content/Books/EmpireOfAngels/EmpireOfAngelsCover.jpg", Name = "Имерия ангелов", Annotation = "Начинается роман весьма оригинально – на первой же странице на главного героя падает «Боинг». Герой немедленно попадает на небеса, где устраивается работать ангелом-хранителем. В его ведении – три разноплановые человеческие души: одна из них по ходу жизни превращается в чернокожую топ-модель, другая – во французского писателя (очевидны автопортретные черты), третья – в российского детдомовца.", Body = "/Content/Books/EmpireOfAngels/EmpireOfAngels.txt" };
            var empireOfAngelsAuthor = new Author { FirstName = "Бернар", LastName = "Вербер" };
            empireOfAngels.Authors.Add(empireOfAngelsAuthor);
            empireOfAngels.Genres.Add(novel);

            var flowersForElgernon = new Book { Cover = "/Content/Books/FlowersForElgernon/FlowersCover.jpg", Name = "Цветы для Элджернона", Annotation = "Чарли Гордон — идиот. В прямом смысле этого слова — с самого детства он болен фенилкетонурией, при которой умственная отсталость практически неизбежна. Сейчас ему около тридцати, он работает уборщиком в пекарне и ходит на занятия для умственно отсталых. И именно он стал первым в мире человеком, подвергшемся экспериментальной операции по устранению этого заболевания — грубо говоря, хирурги удалили повреждённые участки его мозга и заменили их здоровыми. Что получилось в итоге? Много разного получилось, надо сказать...", Body = "/Content/Books/FlowersForElgernon/FlowersForElgernon.txt" };
            var flowersForElgernonAuthor = new Author { FirstName = "Дэниел", LastName = "Киз" };
            flowersForElgernon.Authors.Add(flowersForElgernonAuthor);
            flowersForElgernon.Genres.Add(scienceFiction);

            var greenMile = new Book { Cover = "/Content/Books/GreenMile/GreenMileCover.jpg", Name = "Зеленая миля", Annotation = "В тюрьме «Холодная гора» блок смертников называют Зеленой Милей. Там видели разных заключенных, но однажды на Милю привозят Джона Коффи – огромного негра, который якобы совершил страшное преступление – жестоко убил двух маленьких девочек. И вот Полу Эджкомбу и другим сотрудника блока предстоит узнать, что не все бывает таким, каким кажется. Иногда тот, кто за решеткой, может быть лучше того, кто снаружи. А смерть может стать желанным избавлением от тяжкого бремени жизни.", Body = "/Content/Books/GreenMile/GreenMile.txt" };
            var greenMileAuthor = new Author { FirstName = "Стивен", LastName = "Кинг" };
            var drama = new Genre { Name = "Драма" };
            greenMile.Authors.Add(greenMileAuthor);
            greenMile.Genres.Add(fantasy);
            greenMile.Genres.Add(drama);

            var gulliverJourney = new Book { Cover = "/Content/Books/GulliverJourney/GulliverCover.jpg", Name = "Путешествия Гулливера", Annotation = "Книга о невероятных приключениях Гулливера давно стала любимым произведением взрослых и детей. Она по праву входит в золотой фонд мировой литературы. Однажды корабельный врач Лемюэль Гулливер попадает в удивительную страну Лилипутию, где живут крошечные человечки. вместе с ним ребята узнают о сказочном государстве, о его законах и обычаях. Но на этом приключения отважного моряка не заканчиваются, страсть Гулливера к путешествиям приводит его в страну великанов, где люди похожи на горы, а кошка - страшный зверь и даже с мухами приходится сражаться...", Body = "/Content/Books/GulliverJourney/GulliverJourney.txt" };
            var gulliverJourneyAuthor = new Author { FirstName = "Джонатан", LastName = "Свифт" };
            gulliverJourney.Authors.Add(gulliverJourneyAuthor);
            gulliverJourney.Genres.Add(kids);
            gulliverJourney.Genres.Add(fantasy);

            var hobbit = new Book { Cover = "/Content/Books/Hobbit/HobbitCover.jpg", Name = "Хоббит, или туда и обратно", Annotation = "Книга всемирно известного английского писателя Дж.Р.Р. Толкина «Хоббит, или Туда и обратно» по праву считается классикой детской литературы XX века. Невероятные приключения ее героя Бильбо Бэггинса и его друзей способны и рассмешить, и растрогать, и заставить ребенка задуматься о многих важных вещах. Уже несколько десятилетий история полного опасностей путешествия маленького отряда к заветной цели захватывает воображение детей и взрослых. Благодаря первокласному переводу Н. Рахмановой, уже ставшим классическим, удивительный мир героев Дж.Р.Р. Толкина откроется перед читателями во всей своей полноте и многоцветии.", Body = "/Content/Books/Hobbit/Hobbit.txt" };
            var hobbitAuthor = new Author { FirstName = "Джон Рональд Руэл", LastName = "Толкин" };
            var adventures = new Genre { Name = "Приключения" };
            hobbit.Authors.Add(hobbitAuthor);
            hobbit.Genres.Add(adventures);
            hobbit.Genres.Add(fantasy);
            hobbit.Genres.Add(kids);

            var littlePrince = new Book { Cover = "/Content/Books/LittlePrince/PrinceCover.jpg", Name = "Маленький принц", Annotation = "Книга «Маленький принц» рассказывает о необыкновенной встрече пилота (из-за неполадок в моторе летчику пришлось посадить самолет в пустыне) с Маленьким принцем, гостем с другой планеты.", Body = "/Content/Books/LittlePrince/LittlePrince.txt" };
            var littlePrinceAuthor = new Author { FirstName = "Антуан де", LastName = "Сент-Экзюпери" };
            littlePrince.Authors.Add(littlePrinceAuthor);
            littlePrince.Genres.Add(novel);
            littlePrince.Genres.Add(kids);

            var masterAndMargarita = new Book { Cover = "/Content/Books/MasterAndMargarita/MasterCover.jpg", Name = "Мастер и Маргарита", Annotation = "\"Мастер и Маргарита\" - блистательный шедевр, созданный Михаилом Булгаковым, завораживающая мистическая дьяволиада, обнажающая вечные темы: истинной любви и верности, добра и зла, смерти и бессмертия. Эта история вечна, как и сама любовь! Великий и вечный роман писателя претерпел многочисленные запреты к изданию и гонения, не хуже чем судьба романа о Понтии Пилате самого Мастера. Впервые был издан в 1966 году с купюрами в журнальном варианте, а полный текст романа был опубликован только в 80-е годы ХХ века. До официальной публикации распространялся в перепечатанных вручную копиях и сразу приобрел невероятную популярность и любовь читателя. Феерическая сатира на быт и нравы Москвы 30-х годов, одновременно пронзительная история любви Мастера и Маргариты и вечная библейская тема борьбы добра со злом, роман о Понтии Пилате внутри романа - таковы далеко не все пласты этого гениального произведения Михаила Булгакова.", Body = "/Content/Books/MasterAndMargarita/MasterAndMargarita.txt" };
            var masterAndMargaritaAuthor = new Author { FirstName = "Михаил", LastName = "Булгаков" };
            masterAndMargarita.Authors.Add(masterAndMargaritaAuthor);
            masterAndMargarita.Genres.Add(novel);
            masterAndMargarita.Genres.Add(fantasy);

            var paddington = new Book { Cover = "/Content/Books/Paddington/PaddingtonCover.jpg", Name = "Все о медвежонке Паддингтоне", Annotation = "Истории английского писателя Майкла Бонда о медвежонке по имени Паддингтон давно уже стали классикой английской детской литературы. Если речь заходит о самых знаменитых литературных медведях, англичане обязательно называют Винни Пуха и Паддингтона.Эта история началась в Лондоне, на Паддингтонском вокзале. Маленький медвежонок, приехавший из Дремучего Перу, стоял в сторонке и терпеливо ждал, когда кто-нибудь обратит на него внимание. К счастью, мистер и миссис Браун решили позаботиться об отважном путешественнике и даже придумали для него звучное имя — Паддингтон.С тех пор в доме Браунов забыли про покой и порядок. Любознательный, трудолюбивый медвежонок не любил сидеть без дела: он и обед приготовит, и газон подстрижет, и даже поможет в ремонте. Правда, почему-то большинство этих затей превращалось в проделки и проказы. Но Паддингтон совсем не виноват в том, что с ним все время что-нибудь приключается. Такой уж это медведь — где он, там никогда не бывает скучно.", Body = "/Content/Books/Paddington/Padington.txt" };
            var paddingtonAuthor = new Author { FirstName = "Майкл", LastName = "Бонд" };
            paddington.Authors.Add(paddingtonAuthor);
            paddington.Genres.Add(kids);

            var kratchayshayaIstoriyaVremeni = new Book { Cover = "/Content/Books/KratchayshayaIstoriyaVremeni/KratchayshayaIstoriyaVremeniCover.jpg", Name = "Кратчайшая история времени", Annotation = "Природе пространства и времени, происхождению Вселенной посвящена эта научно-популярная книга знаменитого английского астрофизика Стивена Хокинга, написанная в соавторстве с популяризатором науки Леонардом Млодиновым. Это новая версия всемирно известной «Краткой истории времени», пополненная последними данными космологии, попытка еще проще и понятнее изложить самые сложные теории.", Body = "/Content/Books/KratchayshayaIstoriyaVremeni/KratchayshayaIstoriyaVremeni.txt" };
            var kratchayshayaIstoriyaVremeniAuthor = new Author { FirstName = "Стмвен", LastName = "Хокинг" };
            var popularScience = new Genre { Name = "Научно-популярная литература" };
            kratchayshayaIstoriyaVremeni.Authors.Add(kratchayshayaIstoriyaVremeniAuthor);
            kratchayshayaIstoriyaVremeni.Genres.Add(popularScience);

            var galaxy = new Book { Cover = "/Content/Books/Galaxy/GalaxyCover.jpg", Name = "Автостопом по галактике", Annotation = "Хочется узнать, как готовить межгалактический коктейль? Возможно интересно, как прожить в космосе на 30 долларов? Без проблем, отправившись в межгалактическое путешествие автостопом, можно раскрыть тайну завещания Бога для его мира. Тогда многое станет ясным.", Body = "/Content/Books/Galaxy/TheHitchhikersGuideToTheGalaxy.txt" };
            var galaxyAuthor = new Author { FirstName = "Дуглас", LastName = "Адамс" };
            var humor = new Genre { Name = "Юмор" };
            galaxy.Authors.Add(galaxyAuthor);
            galaxy.Genres.Add(scienceFiction);
            galaxy.Genres.Add(novel);
            galaxy.Genres.Add(humor);

            var shoushenk = new Book { Cover = "/Content/Books/TheShawshankRedemption/ShoushenkCover.jpg", Name = "Побег из Шоушенка", Annotation = "Книга «Побег из Шоушенка» соединяет ужасы тюремной жизни и фантастику побега. Шоушенк – название тюрьмы. Энди, вице-президент солидного банка, приговаривается к двум пожизненным заключениям по обвинению в убийстве жены и ее любовника. Он отбывает заключение в тюрьме Шоушенк, где проходит все круги ада, проявляя недюжинное мужество, упорство и хладнокровие. Если тебе нет еще 30-ти, а ты получаешь пожизненное, то приготовся к худшему: для тебя выхода из Шоушенка не будет.", Body = "/Content/Books/TheShawshankRedemption/TheShawshankRedemption.txt" };
            var shoushenkAuthor = new Author { FirstName = "Стивен", LastName = "Кинг" };
            var detective = new Genre { Name = "Детектив" };
            shoushenk.Authors.Add(shoushenkAuthor);
            shoushenk.Genres.Add(drama);
            shoushenk.Genres.Add(detective);

            var winnieThePooh = new Book { Cover = "/Content/Books/WinnieThePooh/WinnieCover.jpg", Name = "Винни Пух и все-все-все", Annotation = "Удивительная сказка А.Милна о медвежонке Винни-Пухе и его друзьях в пересказе Бориса Владимировича Заходера и проиллюстрированная Эдуардом Васильевичем Назаровым стала узнаваемой и любимой. Миллионы ребят и взрослых считают Винни-Пуха своим русским медвежонком. А ведь совсем недавно его называли «Уинни-тзе-Пу» и он не знал ни слова по-русски.", Body = "/Content/Books/WinnieThePooh/WinnieThePooh.txt" };
            var winnieThePoohAuthor = new Author { FirstName = "Алан Александр", LastName = "Милн" };
            winnieThePooh.Authors.Add(winnieThePoohAuthor);
            winnieThePooh.Genres.Add(kids);

            var forrestGump = new Book { Cover = "/Content/Books/ForrestGump/ForrestGumpCover.jpg", Name = "Форрест Гамп", Annotation = "История умственно отсталого юноши, рассказанная им самим на страницах этой книги, является воплощением мифа об «американской мечте» и одновременно острой сатирой на американское общество второй половины XX века.", Body = "/Content/Books/ForrestGump/ForrestGump.txt" };
            var forrestGumpAuthor = new Author { FirstName = "Уинстон", LastName = "Грум" };
            forrestGump.Authors.Add(forrestGumpAuthor);
            forrestGump.Genres.Add(humor);
            forrestGump.Genres.Add(drama);

            var listBooks = new List<Book>() { forrestGump, winnieThePooh, shoushenk, galaxy, kratchayshayaIstoriyaVremeni, paddington, masterAndMargarita, littlePrince, hobbit, gulliverJourney, greenMile, flowersForElgernon, empireOfAngels, dandelionWine, braveNewWorld, aviator, atlasShrugged };
            context.Books.AddRange(listBooks);

            var listGenres = new List<Genre>() { drama, humor, kids, detective, novel, scienceFiction, popularScience, fantasy, antiytopia, adventures };
            context.Genres.AddRange(listGenres);
                        
            var listAuthors = new List<Author>() { forrestGumpAuthor, winnieThePoohAuthor, shoushenkAuthor, galaxyAuthor, kratchayshayaIstoriyaVremeniAuthor, paddingtonAuthor, masterAndMargaritaAuthor, littlePrinceAuthor, hobbitAuthor, gulliverJourneyAuthor, greenMileAuthor, flowersForElgernonAuthor, empireOfAngelsAuthor, dandelionWineAuthor, braveNewWorldAuthor, aviatorAuthor, atlasShruggedAuthor };
            context.Authors.AddRange(listAuthors);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
