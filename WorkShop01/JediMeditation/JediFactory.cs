namespace JediMeditation
{
    public class JediFactory
    {
        
        public static IJedi CreateJedi(string name)
        {
            char type = name[0];
            Jedi jedi;

            switch (type)
            {
                case 'm': jedi = new Master(name); break;
                case 'k': jedi = new Knight(name); break;
                case 'p': jedi = new Padawan(name); break;
                default: jedi = null; break;
            }

            return jedi;
        }

    }
}
