using Humanizer;
using Humanizer.Inflections;
using System;
using System.ComponentModel;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DateTime dataFimPagamento = new DateTime(2021, 10, 14);
            DateTime dataCorrente = DateTime.Now;

            TimeSpan tempo = TimeSpan.FromMinutes(40);
            Console.WriteLine(tempo);

            TimeSpan diferencaDeTempo = dataFimPagamento - dataCorrente;

            string mensagem = $"Vencimento em: {TimeSpanHumanizeExtensions.Humanize(tempo)}";

            Console.WriteLine(mensagem);
            
            //Humanizer 
            DatasETempoHumanizer();
            MedidasComputacionaisHumanizer();
            TruncandoStringsHumanizer();

            Vocabularies.Default.AddPlural("homem", "homens");
            Vocabularies.Default.AddSingular("homens", "homem");
            Vocabularies.Default.AddPlural("real", "reais");
            GeralString();
            Console.ReadLine();
            
        }

        /* ===== HUMANIZER ===== */
        public static void DatasETempoHumanizer()
        {
            //Trabalhando com DateTime e TimeSpan
            Console.WriteLine("\nTrabalhando com DateTime e TimeSpan");

            DateTime agora = DateTime.UtcNow;
            agora = DateTime.UtcNow;
            Console.WriteLine(agora.AddHours(-30).Humanize()); //ontem
            Console.WriteLine(agora.AddHours(25).Humanize()); //amanhã
            Console.WriteLine(agora.AddMinutes(-2).Humanize()); //2 minutos atrás
            Console.WriteLine(agora.AddMinutes(2).Humanize()); //em um minuto 
            Console.WriteLine(agora.AddMonths(-11).Humanize()); //11 meses atrás
            Console.WriteLine(agora.AddMonths(-13).Humanize()); //um ano atrás 
            Console.WriteLine(agora.AddYears(-10).Humanize()); //10 anos atrás
            Console.WriteLine(TimeSpan.FromMinutes(2).Humanize()); //2 minutos
            Console.WriteLine(TimeSpan.FromMinutes(-2).Humanize()); //2 minutos
            Console.WriteLine(TimeSpan.FromDays(28).Humanize()); //4 semanas
            Console.WriteLine(TimeSpan.FromDays(365 * 4).Humanize()); //208 semanas
            Console.WriteLine(TimeSpan.FromMilliseconds(1299630020).Humanize()); //2 semanas
            Console.WriteLine(TimeSpan.FromMilliseconds(1299630020).Humanize(3)); //2 semanas, 1 dia, 1 hora
            Console.WriteLine(TimeSpan.FromMilliseconds(1).Humanize()); //1 milisegundo
            Console.WriteLine(TimeSpan.FromMilliseconds(2).Humanize()); //2 milisegundos
            Console.WriteLine(TimeSpan.FromDays(1).Humanize()); //1 dia
            Console.WriteLine(TimeSpan.FromDays(2).Humanize()); //2 dias
            Console.WriteLine(TimeSpan.FromDays(16).Humanize()); //2 semanas
            DateTime dataFim = new DateTime(2019, 6, 30);
            TimeSpan diferenca = dataFim - agora;
            Console.WriteLine("Em " + TimeSpanHumanizeExtensions.Humanize(diferenca)); //Em 14 semanas
            Console.WriteLine(DateTimeOffset.UtcNow.AddHours(1).Humanize()); // em um hora

        }

        public static void MedidasComputacionaisHumanizer()
        {

            //Unidades de Medida Computacionais
            Console.WriteLine("\nUnidades de Medida Computacionais");
            var filesize = (10).Megabytes();

            Console.WriteLine(filesize.Kilobytes); //10240
            Console.WriteLine(filesize.Gigabytes);//0.009765625

            Console.WriteLine((10).Megabytes().Humanize());//10 MB
            Console.WriteLine((1024).Megabytes().Humanize());//1 GB
            Console.WriteLine((1024 * 1024 * 500).Kilobytes().Humanize());//500 GB
        }

        public static void TruncandoStringsHumanizer()
        {

            //Truncando Strings
            Console.WriteLine("\nTruncando Strings");

            Console.WriteLine("Texto longo para truncar".Truncate(10, "...", Truncator.FixedLength));
            Console.WriteLine("Texto longo para truncar".Truncate(10, "---", Truncator.FixedLength));
            Console.WriteLine("Texto longo para truncar".Truncate(8, "...", Truncator.FixedNumberOfCharacters));
            Console.WriteLine("Texto longo para truncar".Truncate(6, "---", Truncator.FixedNumberOfCharacters));
            Console.WriteLine("Texto longo para truncar".Truncate(2, Truncator.FixedNumberOfWords));
            Console.WriteLine("Texto longo para truncar".Truncate(2, "...", Truncator.FixedNumberOfWords));
            Console.WriteLine("abcdef".Truncate(4, "*", Truncator.FixedLength));

            Console.WriteLine("Texto longo para truncar".Truncate(10, "...", Truncator.FixedLength, TruncateFrom.Left));
            Console.WriteLine("Texto longo para truncar".Truncate(8, "...", Truncator.FixedNumberOfCharacters, TruncateFrom.Left));

        }

        public enum EnumUnderTest
        {
            [Description("Custom description")]
            MemberWithDescriptionAttribute,
            MemberWithoutDescriptionAttribute,
            ALLCAPITALS
        }

        private static void GeralString()
        {
            //Adicionando novas palavras
            Console.WriteLine("\nAdicionando novas palavras");
            Console.WriteLine("Quero_retornar_texto_Aqui".Humanize(LetterCasing.Title));
            Console.WriteLine("QueroRetornarTextoAqui".Humanize(LetterCasing.Title));
            Console.WriteLine("QueroRetornarTextoAqui".Humanize(LetterCasing.LowerCase));
            Console.WriteLine("quero_retornar texto aqui".Camelize());
            Console.WriteLine("quero_retornar texto aqui".Pascalize());
            Console.WriteLine("UmTexto".Underscore());
            Console.WriteLine("um_texto".Dasherize());
            Console.WriteLine("um_texto".Hyphenate());
            Console.WriteLine("UmTexto".Kebaberize());
            Console.WriteLine(1.ToWords());
            Console.WriteLine(155.ToWords());
            Console.WriteLine(3785.ToWords());
            Console.WriteLine(EnumUnderTest.MemberWithDescriptionAttribute.Humanize());
            Console.WriteLine(EnumUnderTest.MemberWithoutDescriptionAttribute.Humanize());
            Console.WriteLine(EnumUnderTest.MemberWithoutDescriptionAttribute.Humanize().Transform(To.TitleCase));
        }
    }
}