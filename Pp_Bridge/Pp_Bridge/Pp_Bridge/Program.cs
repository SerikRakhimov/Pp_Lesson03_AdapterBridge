using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Bridge

namespace Pp_Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаем новый пункт меню, на русском языке
            Console.WriteLine("На русском языке:");
            Menu menu = new AboutMenu(new Russian());
            menu.DoWork();
            Console.WriteLine("\nНа английском языке:");
            // теперь нужно на английском
            menu.Language = new English();
            menu.DoWork();

            Console.ReadLine();
        }
    }

    interface ILanguage
    {
        void Small();
        void Full();
    }

    class Russian : ILanguage
    {
        public void Small()
        {
            Console.WriteLine("О программне");
        }

        public void Full()
        {
            Console.WriteLine("Версия программы 1.0.0.0.");
        }
    }

    class English : ILanguage
    {
        public void Small()
        {
            Console.WriteLine("About the program");
        }

        public void Full()
        {
            Console.WriteLine("Version of the program 1.0.0.0.");
        }
    }

    abstract class Menu
    {
        protected ILanguage language;
        public ILanguage Language
        {
            set { language = value; }
        }
        public Menu(ILanguage lang)
        {
            language = lang;
        }
        public virtual void DoWork()
        {
            language.Small();
            language.Full();
        }
    }

    class AboutMenu : Menu
    {
        public AboutMenu(ILanguage lang) : base(lang)
        {
        }
    }
    class CorporateProgrammer : Menu
    {
        public CorporateProgrammer(ILanguage lang)
            : base(lang)
        {
        }
    }

}
